Imports System.Data.SqlClient
Imports System.Configuration

Public Class AppMonitor

    Public Const APP_NAME As String = "AppMonitor"
    Const APP_VERSION As String = "v180915"
    Const APP_STATUS_STARTING As String = "Starting"
    Const APP_STATUS_RUNNING As String = "Running"
    Const APP_STATUS_STOPPING As String = "Stopping"
    Const APP_STATUS_UNKNOWN As String = "Unknown"
    Const APP_STATUS_OFFLINE As String = "Offline"

    Structure AppStatus
        Public AppStatus As String
        Public Timestamp As String
    End Structure

    Structure StatusColor
        Public Foreground As Color
        Public Background As Color
    End Structure

    Dim gDBConn As SqlConnection
    Dim gCycleInterval As Integer
    Dim gSendText_CycleInterval As Integer 'create a KVP, with AppName as the key, for these two
    Dim gRouteText_CycleInterval As Integer
    Dim gGlobalAppStatus As String = "" 'global  app status, across all monitored apps


    Function GetAppStatus(pAppName As String, Optional pAppStatus As String = "") As AppStatus

        Dim lAppStatus As AppStatus
        Dim lCmd As New SqlCommand
        Dim lReader As SqlDataReader

        lAppStatus = Nothing

        Try

            lCmd = gDBConn.CreateCommand

            lCmd.CommandText = "GetAppStatus"
            lCmd.CommandType = CommandType.StoredProcedure

            lCmd.Parameters.Add("@AppName", SqlDbType.VarChar)
            lCmd.Parameters("@AppName").Value = pAppName

            ' app status Is an optional parameter, if specified use it otherwise display most current status
            If pAppStatus > "" Then
                lCmd.Parameters.Add("@AppStatus", SqlDbType.VarChar)
                lCmd.Parameters("@AppStatus").Value = pAppStatus
            End If

            lReader = lCmd.ExecuteReader(CommandBehavior.SingleRow)
            lReader.Read()

            If lReader.HasRows Then

                With lAppStatus

                    .AppStatus = lReader.GetString(0)
                    .Timestamp = lReader.GetDateTime(1).ToString

                End With

            End If

        Catch ex As Exception

            MessageBox.Show("GetAppStatus: " & ex.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Shutdown() ' try to shutdown gracefully
            Application.Exit()

        Finally

            lReader = Nothing

            lCmd.Dispose()
            lCmd = Nothing

        End Try

        GetAppStatus = lAppStatus

    End Function


    Function Startup() As Integer

        Dim lError As Integer = 0
        Dim lAnyError As Integer = 0

        lError = DBOpen()
        If lError <> 0 Then lAnyError = -1 'If we cannot open the database, flag the error but keep going in case there are more errors during initialization

        Startup = lAnyError

    End Function


    Sub Shutdown()

        DBClose()

    End Sub


    Public Function DBOpen() As Integer

        Dim lError As Integer = 0
        Dim lConnectionString As String

        Try
            lConnectionString = ConfigurationManager.ConnectionStrings("SendText").ConnectionString
            gDBConn = New SqlConnection(lConnectionString)
            gDBConn.Open()
        Catch ex As Exception
            MessageBox.Show("DBOpen: " & ex.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lError = -1 ' Flag failure to open database
        End Try

        DBOpen = lError

    End Function


    Public Sub DBClose()

        Try
            gDBConn.Close()
            gDBConn.Dispose()
        Catch
            ' No worries if error encountered while closing
        Finally
            gDBConn = Nothing
        End Try

    End Sub


    Public Function GetAppConfig(pAppName As String, pConfigName As String, pDefaultValue As String) As String

        Dim lCmd As New SqlCommand
        Dim lResults As String

        Try

            lCmd = gDBConn.CreateCommand

            lCmd.CommandText = "GetAppConfig"
            lCmd.CommandType = CommandType.StoredProcedure

            lCmd.Parameters.Add("@AppName", SqlDbType.VarChar)
            lCmd.Parameters("@AppName").Value = pAppName
            lCmd.Parameters.Add("@ConfigName", SqlDbType.VarChar)
            lCmd.Parameters("@ConfigName").Value = pConfigName

            lResults = lCmd.ExecuteScalar
            If IsNothing(lResults) Then lResults = pDefaultValue 'If configuration not defined just use default value

        Catch ex As Exception
            MessageBox.Show("GetAppConfig: " & ex.ToString, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lResults = pDefaultValue ' If we encountered an error just use default value but log it anyway

        Finally

            lCmd.Dispose()
            lCmd = Nothing

        End Try

        GetAppConfig = lResults

    End Function


    Function GetDBTime() As DateTime

        Dim lCmd As New SqlCommand
        Dim lResults As String

        lResults = DateTime.Now.ToLocalTime.ToString ' this should never be used but. . .

        Try

            lCmd = gDBConn.CreateCommand

            lCmd.CommandText = "select GETDATE()"
            lCmd.CommandType = CommandType.Text

            lResults = lCmd.ExecuteScalar

        Catch ex As Exception
            MessageBox.Show("GetDBTime: " & ex.ToString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Shutdown() ' try to shutdown gracefully
            Application.Exit()

        Finally

            lCmd.Dispose()
            lCmd = Nothing

        End Try

        GetDBTime = Convert.ToDateTime(lResults)

    End Function


    Sub LoadAppConfigs()

        Dim lCycleInterval As String

        lCycleInterval = GetAppConfig(APP_NAME, "Cycle_Interval", "10000")
        If IsNumeric(lCycleInterval) Then
            gCycleInterval = Val(lCycleInterval)
        Else
            gCycleInterval = 10000
        End If

        lCycleInterval = GetAppConfig("SendText", "Cycle_Interval", "10000")
        If IsNumeric(lCycleInterval) Then
            gSendText_CycleInterval = Val(lCycleInterval)
        Else
            gSendText_CycleInterval = 10000
        End If

        lCycleInterval = GetAppConfig("RouteText", "Cycle_Interval", "10000")
        If IsNumeric(lCycleInterval) Then
            gRouteText_CycleInterval = Val(lCycleInterval)
        Else
            gRouteText_CycleInterval = 10000
        End If

    End Sub


    Private Sub AppMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim lError As Integer = 0

        WindowState = FormWindowState.Minimized ' start minimized, only open on-request

        lError = Startup()

        If lError = 0 Then

            LoadAppConfigs() ' Subroutine just uses defaults if it fails for whatever reason
            cTimer.Interval = gCycleInterval

        Else

            MessageBox.Show(APP_NAME & " is shutting down", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Shutdown() ' try to shutdown gracefully
            Application.Exit()

        End If

    End Sub


    Private Sub AppMonitor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Main_Loop()
        cTimer.Start()

    End Sub


    Private Sub AppMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lShutdownRequest = DialogResult

        lShutdownRequest = MessageBox.Show("Do you want to shutdown " + APP_NAME + "?", "Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If lShutdownRequest = Windows.Forms.DialogResult.Yes Then

            Shutdown() ' shutdown gracefully before app self-terminates
            e.Cancel = False 'allow the form to be closed and the app will exit

        Else

            WindowState = FormWindowState.Minimized
            e.Cancel = True 'stop the form from being closed and minimize it instead

        End If

    End Sub


    Private Sub Tick(sender As Object, e As EventArgs) Handles cTimer.Tick

        Main_Loop()

    End Sub


    Sub Main_Loop()

        Dim lCurrentGlobalAppStatus As String
        Dim lAppStatus As AppStatus
        Dim lLastUpdate As DateTime
        Dim lElapsed As TimeSpan

        lCurrentGlobalAppStatus = APP_STATUS_RUNNING

        lAppStatus = GetAppStatus("SendText", APP_STATUS_STARTING)
        cSendTextLastStarted.Text = lAppStatus.Timestamp ' display the time the app was last started

        lAppStatus = GetAppStatus("SendText") ' get the most recent status
        cSendTextTimestamp.Text = lAppStatus.Timestamp

        lLastUpdate = Convert.ToDateTime(lAppStatus.Timestamp)
        lElapsed = GetDBTime() - lLastUpdate ' always use database-time
        cSendTextElapsed.Text = lElapsed.TotalSeconds.ToString

        If (lAppStatus.AppStatus = APP_STATUS_RUNNING) And (lElapsed.TotalMilliseconds > (gSendText_CycleInterval * 2)) Then ' if running but the status is stale
            lAppStatus.AppStatus = APP_STATUS_UNKNOWN
        End If

        cSendTextStatus.Text = lAppStatus.AppStatus
        cSendTextStatus.BackColor = GetStatusColor(lAppStatus.AppStatus).Background
        cSendTextStatus.ForeColor = GetStatusColor(lAppStatus.AppStatus).Foreground

        ' Running > Unknown > Starting > Stopping
        ' NOTE: Offline apps do not effect the global app status

        If (lAppStatus.AppStatus = APP_STATUS_UNKNOWN) And lCurrentGlobalAppStatus = APP_STATUS_RUNNING Then lCurrentGlobalAppStatus = APP_STATUS_UNKNOWN
        If (lAppStatus.AppStatus = APP_STATUS_STARTING) And lCurrentGlobalAppStatus = APP_STATUS_RUNNING Then lCurrentGlobalAppStatus = APP_STATUS_STARTING
        If lAppStatus.AppStatus = APP_STATUS_STOPPING Then lCurrentGlobalAppStatus = APP_STATUS_STOPPING


        lAppStatus = GetAppStatus("RouteText", APP_STATUS_STARTING)
        cRouteTextLastStarted.Text = lAppStatus.Timestamp ' display the time the app was last started

        lAppStatus = GetAppStatus("RouteText") ' get the most recent status
        cRouteTextTimestamp.Text = lAppStatus.Timestamp

        lLastUpdate = Convert.ToDateTime(lAppStatus.Timestamp)
        lElapsed = GetDBTime() - lLastUpdate ' always use database-time
        cRouteTextElapsed.Text = lElapsed.TotalSeconds.ToString

        If (lAppStatus.AppStatus = APP_STATUS_RUNNING) And (lElapsed.TotalMilliseconds > (gRouteText_CycleInterval * 2)) Then ' if running but the status is stale
            lAppStatus.AppStatus = APP_STATUS_UNKNOWN
        End If

        cRouteTextStatus.Text = lAppStatus.AppStatus
        cRouteTextStatus.BackColor = GetStatusColor(lAppStatus.AppStatus).Background
        cRouteTextStatus.ForeColor = GetStatusColor(lAppStatus.AppStatus).Foreground

        ' Running > Unknown > Starting > Stopping
        ' NOTE: Offline apps do not effect the global app status

        If (lAppStatus.AppStatus = APP_STATUS_UNKNOWN) And lCurrentGlobalAppStatus = APP_STATUS_RUNNING Then lCurrentGlobalAppStatus = APP_STATUS_UNKNOWN
        If (lAppStatus.AppStatus = APP_STATUS_STARTING) And lCurrentGlobalAppStatus = APP_STATUS_RUNNING Then lCurrentGlobalAppStatus = APP_STATUS_STARTING
        If lAppStatus.AppStatus = APP_STATUS_STOPPING Then lCurrentGlobalAppStatus = APP_STATUS_STOPPING


        If lCurrentGlobalAppStatus <> gGlobalAppStatus Then

            gGlobalAppStatus = lCurrentGlobalAppStatus
            DisplayAppStatus()
            WindowState = FormWindowState.Normal 'display the status if the global app status changed

        End If

    End Sub


    Function GetStatusColor(pAppStatus As String) As StatusColor

        Dim lStatusColor As New StatusColor

        With lStatusColor
            Select Case pAppStatus
                Case APP_STATUS_RUNNING
                    .Background = Color.Lime
                    .Foreground = Color.Black
                Case APP_STATUS_STARTING, APP_STATUS_OFFLINE
                    .Background = Color.Yellow
                    .Foreground = Color.Black
                Case APP_STATUS_STOPPING
                    .Background = Color.Red
                    .Foreground = Color.White
                Case Else
                    .Background = Color.Black
                    .Foreground = Color.White
            End Select
        End With

        GetStatusColor = lStatusColor

    End Function


    Private Sub NotifyIcon_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon.DoubleClick

        WindowState = FormWindowState.Normal

    End Sub


    Sub DisplayAppStatus()

        ' NOTE: Offline apps do not effect the global app status

        Select Case gGlobalAppStatus
            Case APP_STATUS_RUNNING
                NotifyIcon.Icon = New Icon(Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("AppMonitor.Green.ico"))
            Case APP_STATUS_STARTING
                NotifyIcon.Icon = New Icon(Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("AppMonitor.Yellow.ico"))
            Case APP_STATUS_STOPPING
                NotifyIcon.Icon = New Icon(Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("AppMonitor.Red.ico"))
            Case APP_STATUS_UNKNOWN
                NotifyIcon.Icon = New Icon(Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("AppMonitor.Unknown.ico"))
        End Select

        NotifyIcon.Visible = True

    End Sub
End Class
