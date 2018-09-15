<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppMonitor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cSendTextStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cRouteTextStatus = New System.Windows.Forms.TextBox()
        Me.cSendTextTimestamp = New System.Windows.Forms.TextBox()
        Me.cRouteTextTimestamp = New System.Windows.Forms.TextBox()
        Me.cTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cSendTextLastStarted = New System.Windows.Forms.TextBox()
        Me.cRouteTextLastStarted = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cSendTextElapsed = New System.Windows.Forms.TextBox()
        Me.cRouteTextElapsed = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SendText"
        '
        'cSendTextStatus
        '
        Me.cSendTextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSendTextStatus.Location = New System.Drawing.Point(95, 44)
        Me.cSendTextStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cSendTextStatus.Name = "cSendTextStatus"
        Me.cSendTextStatus.ReadOnly = True
        Me.cSendTextStatus.Size = New System.Drawing.Size(98, 19)
        Me.cSendTextStatus.TabIndex = 1
        Me.cSendTextStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 83)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "RouteText"
        '
        'cRouteTextStatus
        '
        Me.cRouteTextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cRouteTextStatus.Location = New System.Drawing.Point(95, 80)
        Me.cRouteTextStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cRouteTextStatus.Name = "cRouteTextStatus"
        Me.cRouteTextStatus.ReadOnly = True
        Me.cRouteTextStatus.Size = New System.Drawing.Size(98, 19)
        Me.cRouteTextStatus.TabIndex = 3
        Me.cRouteTextStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cSendTextTimestamp
        '
        Me.cSendTextTimestamp.Location = New System.Drawing.Point(364, 43)
        Me.cSendTextTimestamp.Margin = New System.Windows.Forms.Padding(2)
        Me.cSendTextTimestamp.Name = "cSendTextTimestamp"
        Me.cSendTextTimestamp.ReadOnly = True
        Me.cSendTextTimestamp.Size = New System.Drawing.Size(136, 20)
        Me.cSendTextTimestamp.TabIndex = 4
        Me.cSendTextTimestamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cRouteTextTimestamp
        '
        Me.cRouteTextTimestamp.Location = New System.Drawing.Point(364, 79)
        Me.cRouteTextTimestamp.Margin = New System.Windows.Forms.Padding(2)
        Me.cRouteTextTimestamp.Name = "cRouteTextTimestamp"
        Me.cRouteTextTimestamp.ReadOnly = True
        Me.cRouteTextTimestamp.Size = New System.Drawing.Size(136, 20)
        Me.cRouteTextTimestamp.TabIndex = 5
        Me.cRouteTextTimestamp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cTimer
        '
        '
        'NotifyIcon
        '
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "AppMonitor"
        Me.NotifyIcon.Visible = True
        '
        'cSendTextLastStarted
        '
        Me.cSendTextLastStarted.Location = New System.Drawing.Point(210, 43)
        Me.cSendTextLastStarted.Margin = New System.Windows.Forms.Padding(2)
        Me.cSendTextLastStarted.Name = "cSendTextLastStarted"
        Me.cSendTextLastStarted.ReadOnly = True
        Me.cSendTextLastStarted.Size = New System.Drawing.Size(136, 20)
        Me.cSendTextLastStarted.TabIndex = 6
        Me.cSendTextLastStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cRouteTextLastStarted
        '
        Me.cRouteTextLastStarted.Location = New System.Drawing.Point(210, 79)
        Me.cRouteTextLastStarted.Margin = New System.Windows.Forms.Padding(2)
        Me.cRouteTextLastStarted.Name = "cRouteTextLastStarted"
        Me.cRouteTextLastStarted.ReadOnly = True
        Me.cRouteTextLastStarted.Size = New System.Drawing.Size(136, 20)
        Me.cRouteTextLastStarted.TabIndex = 7
        Me.cRouteTextLastStarted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(246, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Last Started"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(400, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Last Update"
        '
        'cSendTextElapsed
        '
        Me.cSendTextElapsed.Location = New System.Drawing.Point(518, 43)
        Me.cSendTextElapsed.Margin = New System.Windows.Forms.Padding(2)
        Me.cSendTextElapsed.Name = "cSendTextElapsed"
        Me.cSendTextElapsed.ReadOnly = True
        Me.cSendTextElapsed.Size = New System.Drawing.Size(98, 20)
        Me.cSendTextElapsed.TabIndex = 11
        Me.cSendTextElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cRouteTextElapsed
        '
        Me.cRouteTextElapsed.Location = New System.Drawing.Point(518, 79)
        Me.cRouteTextElapsed.Margin = New System.Windows.Forms.Padding(2)
        Me.cRouteTextElapsed.Name = "cRouteTextElapsed"
        Me.cRouteTextElapsed.ReadOnly = True
        Me.cRouteTextElapsed.Size = New System.Drawing.Size(98, 20)
        Me.cRouteTextElapsed.TabIndex = 12
        Me.cRouteTextElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(545, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Elapsed"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(34, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "App"
        '
        'AppMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 118)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cRouteTextElapsed)
        Me.Controls.Add(Me.cSendTextElapsed)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cRouteTextLastStarted)
        Me.Controls.Add(Me.cSendTextLastStarted)
        Me.Controls.Add(Me.cRouteTextTimestamp)
        Me.Controls.Add(Me.cSendTextTimestamp)
        Me.Controls.Add(Me.cRouteTextStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cSendTextStatus)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "AppMonitor"
        Me.Text = "AppMonitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cSendTextStatus As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cRouteTextStatus As TextBox
    Friend WithEvents cSendTextTimestamp As TextBox
    Friend WithEvents cRouteTextTimestamp As TextBox
    Friend WithEvents cTimer As Timer
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents cSendTextLastStarted As TextBox
    Friend WithEvents cRouteTextLastStarted As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cSendTextElapsed As TextBox
    Friend WithEvents cRouteTextElapsed As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
