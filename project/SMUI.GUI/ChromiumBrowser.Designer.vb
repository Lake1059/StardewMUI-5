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
        Me.DarkMenuStrip1 = New DarkUI.Controls.DarkMenuStrip()
        Me.挂起任务继续操作ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.重置直接更新项流程状态ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NEXUS账户页ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刷新ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.返回ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.前进ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.停止ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.转到地址ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.DarkMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChromiumWebBrowser1
        '
        Me.ChromiumWebBrowser1.ActivateBrowserOnCreation = False
        Me.ChromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromiumWebBrowser1.Location = New System.Drawing.Point(0, 32)
        Me.ChromiumWebBrowser1.Name = "ChromiumWebBrowser1"
        Me.ChromiumWebBrowser1.Size = New System.Drawing.Size(1184, 729)
        Me.ChromiumWebBrowser1.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'DarkMenuStrip1
        '
        Me.DarkMenuStrip1.AutoSize = False
        Me.DarkMenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.DarkMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.挂起任务继续操作ToolStripMenuItem, Me.NEXUS账户页ToolStripMenuItem, Me.刷新ToolStripMenuItem, Me.返回ToolStripMenuItem, Me.前进ToolStripMenuItem, Me.停止ToolStripMenuItem, Me.转到地址ToolStripMenuItem, Me.ToolStripTextBox1})
        Me.DarkMenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.DarkMenuStrip1.Name = "DarkMenuStrip1"
        Me.DarkMenuStrip1.Padding = New System.Windows.Forms.Padding(1)
        Me.DarkMenuStrip1.Size = New System.Drawing.Size(1184, 32)
        Me.DarkMenuStrip1.TabIndex = 1
        Me.DarkMenuStrip1.Text = "DarkMenuStrip1"
        '
        '挂起任务继续操作ToolStripMenuItem
        '
        Me.挂起任务继续操作ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.挂起任务继续操作ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.重置直接更新项流程状态ToolStripMenuItem})
        Me.挂起任务继续操作ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.挂起任务继续操作ToolStripMenuItem.Name = "挂起任务继续操作ToolStripMenuItem"
        Me.挂起任务继续操作ToolStripMenuItem.Size = New System.Drawing.Size(128, 30)
        Me.挂起任务继续操作ToolStripMenuItem.Text = "中断的任务继续选项"
        '
        '重置直接更新项流程状态ToolStripMenuItem
        '
        Me.重置直接更新项流程状态ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.重置直接更新项流程状态ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.重置直接更新项流程状态ToolStripMenuItem.Image = Global.SMUI.GUI.My.Resources.Resources.模块
        Me.重置直接更新项流程状态ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.重置直接更新项流程状态ToolStripMenuItem.Name = "重置直接更新项流程状态ToolStripMenuItem"
        Me.重置直接更新项流程状态ToolStripMenuItem.Size = New System.Drawing.Size(224, 38)
        Me.重置直接更新项流程状态ToolStripMenuItem.Text = "重置直接更新项流程状态"
        '
        'NEXUS账户页ToolStripMenuItem
        '
        Me.NEXUS账户页ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.NEXUS账户页ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.NEXUS账户页ToolStripMenuItem.Name = "NEXUS账户页ToolStripMenuItem"
        Me.NEXUS账户页ToolStripMenuItem.Size = New System.Drawing.Size(101, 30)
        Me.NEXUS账户页ToolStripMenuItem.Text = "NEXUS 账户页"
        '
        '刷新ToolStripMenuItem
        '
        Me.刷新ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.刷新ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem"
        Me.刷新ToolStripMenuItem.Size = New System.Drawing.Size(44, 30)
        Me.刷新ToolStripMenuItem.Text = "刷新"
        '
        '返回ToolStripMenuItem
        '
        Me.返回ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.返回ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.返回ToolStripMenuItem.Name = "返回ToolStripMenuItem"
        Me.返回ToolStripMenuItem.Size = New System.Drawing.Size(60, 30)
        Me.返回ToolStripMenuItem.Text = "← 后退"
        '
        '前进ToolStripMenuItem
        '
        Me.前进ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.前进ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.前进ToolStripMenuItem.Name = "前进ToolStripMenuItem"
        Me.前进ToolStripMenuItem.Size = New System.Drawing.Size(60, 30)
        Me.前进ToolStripMenuItem.Text = "前进 →"
        '
        '停止ToolStripMenuItem
        '
        Me.停止ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.停止ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.停止ToolStripMenuItem.Name = "停止ToolStripMenuItem"
        Me.停止ToolStripMenuItem.Size = New System.Drawing.Size(64, 30)
        Me.停止ToolStripMenuItem.Text = "停止 ❌"
        '
        '转到地址ToolStripMenuItem
        '
        Me.转到地址ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.转到地址ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.转到地址ToolStripMenuItem.Name = "转到地址ToolStripMenuItem"
        Me.转到地址ToolStripMenuItem.Size = New System.Drawing.Size(80, 30)
        Me.转到地址ToolStripMenuItem.Text = "转到地址："
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!)
        Me.ToolStripTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(550, 30)
        '
        'ChromiumBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.ChromiumWebBrowser1)
        Me.Controls.Add(Me.DarkMenuStrip1)
        Me.MainMenuStrip = Me.DarkMenuStrip1
        Me.Name = "ChromiumBrowser"
        Me.ShowIcon = False
        Me.Text = "Chromium Embedded Framework"
        Me.DarkMenuStrip1.ResumeLayout(False)
        Me.DarkMenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChromiumWebBrowser1 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DarkMenuStrip1 As DarkUI.Controls.DarkMenuStrip
    Friend WithEvents NEXUS账户页ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 刷新ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 返回ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 前进ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 停止ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 转到地址ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents 挂起任务继续操作ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 重置直接更新项流程状态ToolStripMenuItem As ToolStripMenuItem
End Class
