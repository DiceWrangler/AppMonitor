Imports System.Data.SqlClient
Imports System.Configuration

Public Class AppMonitor

    Public Const APP_NAME As String = "AppMonitor"
    Const APP_VERSION As String = "v180908"
    Const APP_STATUS_STARTING As String = "Starting"
    Const APP_STATUS_RUNNING As String = "Running"
    Const APP_STATUS_STOPPING As String = "Stopping"

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
    Dim gShutdownRequested As Boolean = False


    Function GetAppStatus(pAppName As String) As AppStatus

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


    Sub LoadAppConfigs()

        Dim lCycleInterval As String

        lCycleInterval = GetAppConfig(APP_NAME, "Cycle_Interval", "10000")
        If IsNumeric(lCycleInterval) Then
            gCycleInterval = Val(lCycleInterval)
        Else
            gCycleInterval = 10000
        End If

    End Sub

    Private Sub AppMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim lError As Integer = 0

        lError = Startup()

        If lError = 0 Then
            LoadAppConfigs() ' Subroutine just uses defaults if it fails for whatever reason
            cTimer.Interval = gCycleInterval
        Else
            MessageBox.Show(APP_NAME & " is shutting down", "STOP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Shutdown()
            Application.Exit()
        End If

    End Sub


    Private Sub AppMonitor_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Main_Loop()
        cTimer.Start()

    End Sub


    Private Sub AppMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Shutdown()

    End Sub

    Private Sub Tick(sender As Object, e As EventArgs) Handles cTimer.Tick

        Main_Loop()

    End Sub


    Sub Main_Loop()

        Dim lAppStatus As AppStatus

        lAppStatus = GetAppStatus("SendText")
        cSendTextStatus.Text = lAppStatus.AppStatus
        cSendTextTimestamp.Text = lAppStatus.Timestamp
        cSendTextStatus.BackColor = GetStatusColor(lAppStatus.AppStatus).Background
        cSendTextStatus.ForeColor = GetStatusColor(lAppStatus.AppStatus).Foreground

        lAppStatus = GetAppStatus("RouteText")
        cRouteTextStatus.Text = lAppStatus.AppStatus
        cRouteTextTimestamp.Text = lAppStatus.Timestamp
        cRouteTextStatus.BackColor = GetStatusColor(lAppStatus.AppStatus).Background
        cRouteTextStatus.ForeColor = GetStatusColor(lAppStatus.AppStatus).Foreground

    End Sub

    Function GetStatusColor(pAppStatus As String) As StatusColor

        Dim lStatusColor As New StatusColor

        With lStatusColor
            Select Case pAppStatus
                Case APP_STATUS_RUNNING
                    .Background = Color.Lime
                    .Foreground = Color.Black
                Case APP_STATUS_STARTING
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
End Class
