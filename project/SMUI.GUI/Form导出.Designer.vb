<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form导出
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DarkButton5 = New DarkUI.Controls.DarkButton()
        Me.DarkTextBox1 = New DarkUI.Controls.DarkTextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DarkButton1 = New DarkUI.Controls.DarkButton()
        Me.DarkButton6 = New DarkUI.Controls.DarkButton()
        Me.DarkButton2 = New DarkUI.Controls.DarkButton()
        Me.DarkTextBox2 = New DarkUI.Controls.DarkTextBox()
        Me.DarkButton4 = New DarkUI.Controls.DarkButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DarkButton5
        '
        Me.DarkButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton5.Font = New System.Drawing.Font("Yu Gothic UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkButton5.Location = New System.Drawing.Point(540, 14)
        Me.DarkButton5.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton5.Name = "DarkButton5"
        Me.DarkButton5.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton5.Size = New System.Drawing.Size(30, 24)
        Me.DarkButton5.TabIndex = 12
        Me.DarkButton5.Text = "..."
        '
        'DarkTextBox1
        '
        Me.DarkTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox1.Location = New System.Drawing.Point(14, 14)
        Me.DarkTextBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkTextBox1.Name = "DarkTextBox1"
        Me.DarkTextBox1.Size = New System.Drawing.Size(516, 24)
        Me.DarkTextBox1.TabIndex = 11
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(440, 56)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(123, 21)
        Me.CheckBox2.TabIndex = 16
        Me.CheckBox2.Text = "完成后关闭控制台"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(440, 83)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 21)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "加密导出"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DarkButton1
        '
        Me.DarkButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton1.Location = New System.Drawing.Point(440, 112)
        Me.DarkButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(130, 35)
        Me.DarkButton1.TabIndex = 15
        Me.DarkButton1.TabStop = False
        Me.DarkButton1.Text = "开始导出"
        '
        'DarkButton6
        '
        Me.DarkButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton6.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkButton6.Location = New System.Drawing.Point(360, 123)
        Me.DarkButton6.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton6.Name = "DarkButton6"
        Me.DarkButton6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.DarkButton6.Size = New System.Drawing.Size(30, 24)
        Me.DarkButton6.TabIndex = 19
        Me.DarkButton6.Text = "●"
        '
        'DarkButton2
        '
        Me.DarkButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton2.Font = New System.Drawing.Font("Yu Gothic UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkButton2.Location = New System.Drawing.Point(400, 123)
        Me.DarkButton2.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton2.Name = "DarkButton2"
        Me.DarkButton2.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton2.Size = New System.Drawing.Size(30, 24)
        Me.DarkButton2.TabIndex = 18
        Me.DarkButton2.Text = "..."
        '
        'DarkTextBox2
        '
        Me.DarkTextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkTextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox2.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkTextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox2.Location = New System.Drawing.Point(14, 123)
        Me.DarkTextBox2.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkTextBox2.Name = "DarkTextBox2"
        Me.DarkTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.DarkTextBox2.Size = New System.Drawing.Size(336, 24)
        Me.DarkTextBox2.TabIndex = 17
        '
        'DarkButton4
        '
        Me.DarkButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton4.Location = New System.Drawing.Point(330, 83)
        Me.DarkButton4.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton4.Name = "DarkButton4"
        Me.DarkButton4.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton4.Size = New System.Drawing.Size(100, 30)
        Me.DarkButton4.TabIndex = 20
        Me.DarkButton4.TabStop = False
        Me.DarkButton4.Text = "清除密码本"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "选择保存路径"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 96)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "设置密码"
        '
        'Form导出
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(584, 161)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DarkButton4)
        Me.Controls.Add(Me.DarkButton6)
        Me.Controls.Add(Me.DarkButton2)
        Me.Controls.Add(Me.DarkTextBox2)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.DarkButton5)
        Me.Controls.Add(Me.DarkTextBox1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 200)
        Me.Name = "Form导出"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "导出"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents DarkButton5 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkTextBox1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkButton6 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkButton2 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkTextBox2 As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkButton4 As DarkUI.Controls.DarkButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
