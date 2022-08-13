<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form导入
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
        Me.DarkButton1 = New DarkUI.Controls.DarkButton()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DarkContextMenu1 = New DarkUI.Controls.DarkContextMenu()
        Me.激活拖拽ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DarkButton2 = New DarkUI.Controls.DarkButton()
        Me.DarkButton3 = New DarkUI.Controls.DarkButton()
        Me.DarkButton4 = New DarkUI.Controls.DarkButton()
        Me.DarkTextBox1 = New DarkUI.Controls.DarkTextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DarkButton5 = New DarkUI.Controls.DarkButton()
        Me.DarkButton6 = New DarkUI.Controls.DarkButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DarkContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DarkButton1
        '
        Me.DarkButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton1.Location = New System.Drawing.Point(440, 212)
        Me.DarkButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(130, 35)
        Me.DarkButton1.TabIndex = 10
        Me.DarkButton1.TabStop = False
        Me.DarkButton1.Text = "开始导入"
        '
        'ListView1
        '
        Me.ListView1.AllowDrop = True
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.ContextMenuStrip = Me.DarkContextMenu1
        Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(14, 14)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(5)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(416, 199)
        Me.ListView1.StateImageList = Me.ImageList1
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 347
        '
        'DarkContextMenu1
        '
        Me.DarkContextMenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.DarkContextMenu1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.激活拖拽ToolStripMenuItem})
        Me.DarkContextMenu1.Name = "DarkContextMenu1"
        Me.DarkContextMenu1.ShowImageMargin = False
        Me.DarkContextMenu1.Size = New System.Drawing.Size(100, 26)
        '
        '激活拖拽ToolStripMenuItem
        '
        Me.激活拖拽ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.激活拖拽ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.激活拖拽ToolStripMenuItem.Name = "激活拖拽ToolStripMenuItem"
        Me.激活拖拽ToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.激活拖拽ToolStripMenuItem.Text = "激活拖拽"
        Me.激活拖拽ToolStripMenuItem.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(1, 23)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DarkButton2
        '
        Me.DarkButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton2.Location = New System.Drawing.Point(440, 14)
        Me.DarkButton2.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton2.Name = "DarkButton2"
        Me.DarkButton2.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton2.Size = New System.Drawing.Size(130, 35)
        Me.DarkButton2.TabIndex = 3
        Me.DarkButton2.TabStop = False
        Me.DarkButton2.Text = "添加打包文件"
        '
        'DarkButton3
        '
        Me.DarkButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton3.Location = New System.Drawing.Point(440, 59)
        Me.DarkButton3.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton3.Name = "DarkButton3"
        Me.DarkButton3.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton3.Size = New System.Drawing.Size(130, 35)
        Me.DarkButton3.TabIndex = 4
        Me.DarkButton3.TabStop = False
        Me.DarkButton3.Text = "移除选中"
        '
        'DarkButton4
        '
        Me.DarkButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton4.Location = New System.Drawing.Point(440, 104)
        Me.DarkButton4.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton4.Name = "DarkButton4"
        Me.DarkButton4.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton4.Size = New System.Drawing.Size(130, 35)
        Me.DarkButton4.TabIndex = 6
        Me.DarkButton4.TabStop = False
        Me.DarkButton4.Text = "清除密码本"
        '
        'DarkTextBox1
        '
        Me.DarkTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox1.Location = New System.Drawing.Point(14, 223)
        Me.DarkTextBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkTextBox1.Name = "DarkTextBox1"
        Me.DarkTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.DarkTextBox1.Size = New System.Drawing.Size(336, 24)
        Me.DarkTextBox1.TabIndex = 7
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(440, 183)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(75, 21)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "使用密码"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DarkButton5
        '
        Me.DarkButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton5.Font = New System.Drawing.Font("Yu Gothic UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkButton5.Location = New System.Drawing.Point(400, 223)
        Me.DarkButton5.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton5.Name = "DarkButton5"
        Me.DarkButton5.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton5.Size = New System.Drawing.Size(30, 24)
        Me.DarkButton5.TabIndex = 10
        Me.DarkButton5.Text = "..."
        '
        'DarkButton6
        '
        Me.DarkButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton6.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkButton6.Location = New System.Drawing.Point(360, 223)
        Me.DarkButton6.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton6.Name = "DarkButton6"
        Me.DarkButton6.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.DarkButton6.Size = New System.Drawing.Size(30, 24)
        Me.DarkButton6.TabIndex = 11
        Me.DarkButton6.Text = "●"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(14, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(440, 156)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(123, 21)
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "完成后关闭控制台"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Form导入
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.DarkButton6)
        Me.Controls.Add(Me.DarkButton5)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DarkTextBox1)
        Me.Controls.Add(Me.DarkButton4)
        Me.Controls.Add(Me.DarkButton3)
        Me.Controls.Add(Me.DarkButton2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 300)
        Me.Name = "Form导入"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "导入"
        Me.DarkContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents DarkButton2 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkButton3 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkButton4 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkTextBox1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents DarkButton5 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkButton6 As DarkUI.Controls.DarkButton
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button1 As Button
    Friend WithEvents DarkContextMenu1 As DarkUI.Controls.DarkContextMenu
    Friend WithEvents 激活拖拽ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox2 As CheckBox
End Class
