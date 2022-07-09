<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form批量创建
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DarkContextMenu1 = New DarkUI.Controls.DarkContextMenu()
        Me.打开文件夹ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.删除ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DarkButton1 = New DarkUI.Controls.DarkButton()
        Me.DarkTextBox1 = New DarkUI.Controls.DarkTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DarkComboBox1 = New DarkUI.Controls.DarkComboBox()
        Me.DarkContextMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "选择批量创建的操作类型"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(22, 49)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(206, 21)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.Text = "将每个文件夹视为一个独立的模组"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(22, 76)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(182, 21)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "将所选的文件夹作为一个模组"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.ContextMenuStrip = Me.DarkContextMenu1
        Me.ListView1.ForeColor = System.Drawing.Color.Silver
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(22, 110)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(10)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(643, 362)
        Me.ListView1.StateImageList = Me.ImageList1
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 250
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 100
        '
        'DarkContextMenu1
        '
        Me.DarkContextMenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.DarkContextMenu1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkContextMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开文件夹ToolStripMenuItem, Me.ToolStripSeparator1, Me.删除ToolStripMenuItem})
        Me.DarkContextMenu1.Name = "DarkContextMenu1"
        Me.DarkContextMenu1.ShowImageMargin = False
        Me.DarkContextMenu1.Size = New System.Drawing.Size(156, 77)
        '
        '打开文件夹ToolStripMenuItem
        '
        Me.打开文件夹ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.打开文件夹ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.打开文件夹ToolStripMenuItem.Name = "打开文件夹ToolStripMenuItem"
        Me.打开文件夹ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.打开文件夹ToolStripMenuItem.Text = "文件夹"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        '删除ToolStripMenuItem
        '
        Me.删除ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.删除ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem"
        Me.删除ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.删除ToolStripMenuItem.Text = "删除"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(1, 25)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DarkButton1
        '
        Me.DarkButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton1.Location = New System.Drawing.Point(565, 19)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(100, 35)
        Me.DarkButton1.TabIndex = 4
        Me.DarkButton1.Text = "开始创建"
        '
        'DarkTextBox1
        '
        Me.DarkTextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DarkTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox1.Location = New System.Drawing.Point(22, 519)
        Me.DarkTextBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.DarkTextBox1.Name = "DarkTextBox1"
        Me.DarkTextBox1.Size = New System.Drawing.Size(350, 24)
        Me.DarkTextBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 492)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "若要将多个文件夹创建为一个项，请输入该新项的名称"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(609, 492)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "目标分类"
        '
        'DarkComboBox1
        '
        Me.DarkComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.DarkComboBox1.FormattingEnabled = True
        Me.DarkComboBox1.Location = New System.Drawing.Point(465, 519)
        Me.DarkComboBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.DarkComboBox1.Name = "DarkComboBox1"
        Me.DarkComboBox1.Size = New System.Drawing.Size(200, 24)
        Me.DarkComboBox1.TabIndex = 8
        '
        'Form批量创建
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(684, 561)
        Me.Controls.Add(Me.DarkComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DarkTextBox1)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form批量创建"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "批量创建"
        Me.DarkContextMenu1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkTextBox1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DarkComboBox1 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkContextMenu1 As DarkUI.Controls.DarkContextMenu
    Friend WithEvents 打开文件夹ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents 删除ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
End Class
