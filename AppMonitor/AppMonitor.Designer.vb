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
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SendText"
        '
        'cSendTextStatus
        '
        Me.cSendTextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSendTextStatus.Location = New System.Drawing.Point(149, 64)
        Me.cSendTextStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cSendTextStatus.Name = "cSendTextStatus"
        Me.cSendTextStatus.ReadOnly = True
        Me.cSendTextStatus.Size = New System.Drawing.Size(76, 19)
        Me.cSendTextStatus.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 119)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "RouteText"
        '
        'cRouteTextStatus
        '
        Me.cRouteTextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cRouteTextStatus.Location = New System.Drawing.Point(149, 115)
        Me.cRouteTextStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cRouteTextStatus.Name = "cRouteTextStatus"
        Me.cRouteTextStatus.ReadOnly = True
        Me.cRouteTextStatus.Size = New System.Drawing.Size(76, 19)
        Me.cRouteTextStatus.TabIndex = 3
        '
        'cSendTextTimestamp
        '
        Me.cSendTextTimestamp.Location = New System.Drawing.Point(253, 64)
        Me.cSendTextTimestamp.Margin = New System.Windows.Forms.Padding(2)
        Me.cSendTextTimestamp.Name = "cSendTextTimestamp"
        Me.cSendTextTimestamp.ReadOnly = True
        Me.cSendTextTimestamp.Size = New System.Drawing.Size(136, 20)
        Me.cSendTextTimestamp.TabIndex = 4
        '
        'cRouteTextTimestamp
        '
        Me.cRouteTextTimestamp.Location = New System.Drawing.Point(253, 119)
        Me.cRouteTextTimestamp.Margin = New System.Windows.Forms.Padding(2)
        Me.cRouteTextTimestamp.Name = "cRouteTextTimestamp"
        Me.cRouteTextTimestamp.ReadOnly = True
        Me.cRouteTextTimestamp.Size = New System.Drawing.Size(136, 20)
        Me.cRouteTextTimestamp.TabIndex = 5
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
        'AppMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 366)
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
End Class
