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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cSendTextStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cRouteTextStatus = New System.Windows.Forms.TextBox()
        Me.cSendTextTimestamp = New System.Windows.Forms.TextBox()
        Me.cRouteTextTimestamp = New System.Windows.Forms.TextBox()
        Me.cTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SendText"
        '
        'cSendTextStatus
        '
        Me.cSendTextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cSendTextStatus.Location = New System.Drawing.Point(199, 79)
        Me.cSendTextStatus.Name = "cSendTextStatus"
        Me.cSendTextStatus.ReadOnly = True
        Me.cSendTextStatus.Size = New System.Drawing.Size(100, 22)
        Me.cSendTextStatus.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "RouteText"
        '
        'cRouteTextStatus
        '
        Me.cRouteTextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cRouteTextStatus.Location = New System.Drawing.Point(199, 141)
        Me.cRouteTextStatus.Name = "cRouteTextStatus"
        Me.cRouteTextStatus.ReadOnly = True
        Me.cRouteTextStatus.Size = New System.Drawing.Size(100, 22)
        Me.cRouteTextStatus.TabIndex = 3
        '
        'cSendTextTimestamp
        '
        Me.cSendTextTimestamp.Location = New System.Drawing.Point(337, 79)
        Me.cSendTextTimestamp.Name = "cSendTextTimestamp"
        Me.cSendTextTimestamp.ReadOnly = True
        Me.cSendTextTimestamp.Size = New System.Drawing.Size(180, 22)
        Me.cSendTextTimestamp.TabIndex = 4
        '
        'cRouteTextTimestamp
        '
        Me.cRouteTextTimestamp.Location = New System.Drawing.Point(337, 146)
        Me.cRouteTextTimestamp.Name = "cRouteTextTimestamp"
        Me.cRouteTextTimestamp.ReadOnly = True
        Me.cRouteTextTimestamp.Size = New System.Drawing.Size(180, 22)
        Me.cRouteTextTimestamp.TabIndex = 5
        '
        'cTimer
        '
        '
        'AppMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cRouteTextTimestamp)
        Me.Controls.Add(Me.cSendTextTimestamp)
        Me.Controls.Add(Me.cRouteTextStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cSendTextStatus)
        Me.Controls.Add(Me.Label1)
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
End Class
