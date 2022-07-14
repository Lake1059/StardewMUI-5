<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChromiumBrowser
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ChromiumWebBrowser1 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ChromiumWebBrowser1
        '
        Me.ChromiumWebBrowser1.ActivateBrowserOnCreation = False
        Me.ChromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromiumWebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.ChromiumWebBrowser1.Name = "ChromiumWebBrowser1"
        Me.ChromiumWebBrowser1.Size = New System.Drawing.Size(1184, 761)
        Me.ChromiumWebBrowser1.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ChromiumBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.ChromiumWebBrowser1)
        Me.Name = "ChromiumBrowser"
        Me.ShowIcon = False
        Me.Text = "Chromium Embedded Framework"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChromiumWebBrowser1 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents Timer1 As Timer
End Class
