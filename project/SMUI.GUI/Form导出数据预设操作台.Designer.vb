<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form导出数据预设操作台
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DarkTextBox1 = New DarkUI.Controls.DarkTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DarkComboBox1 = New DarkUI.Controls.DarkComboBox()
        Me.DarkComboBox2 = New DarkUI.Controls.DarkComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DarkComboBox3 = New DarkUI.Controls.DarkComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.DarkButton1 = New DarkUI.Controls.DarkButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "预设列表"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.IntegralHeight = False
        Me.ListBox1.ItemHeight = 30
        Me.ListBox1.Location = New System.Drawing.Point(13, 37)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(10, 10, 10, 3)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(200, 412)
        Me.ListBox1.TabIndex = 1
        Me.ListBox1.TabStop = False
        '
        'ListBox2
        '
        Me.ListBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox2.ForeColor = System.Drawing.SystemColors.Control
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.IntegralHeight = False
        Me.ListBox2.ItemHeight = 30
        Me.ListBox2.Location = New System.Drawing.Point(223, 219)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(0, 10, 3, 3)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox2.Size = New System.Drawing.Size(549, 230)
        Me.ListBox2.TabIndex = 2
        Me.ListBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "预设名称"
        '
        'DarkTextBox1
        '
        Me.DarkTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox1.Location = New System.Drawing.Point(223, 37)
        Me.DarkTextBox1.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.DarkTextBox1.Name = "DarkTextBox1"
        Me.DarkTextBox1.Size = New System.Drawing.Size(247, 23)
        Me.DarkTextBox1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 70)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "导出对象"
        '
        'DarkComboBox1
        '
        Me.DarkComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.DarkComboBox1.FormattingEnabled = True
        Me.DarkComboBox1.Location = New System.Drawing.Point(223, 97)
        Me.DarkComboBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.DarkComboBox1.Name = "DarkComboBox1"
        Me.DarkComboBox1.Size = New System.Drawing.Size(165, 24)
        Me.DarkComboBox1.TabIndex = 6
        '
        'DarkComboBox2
        '
        Me.DarkComboBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.DarkComboBox2.FormattingEnabled = True
        Me.DarkComboBox2.Location = New System.Drawing.Point(393, 97)
        Me.DarkComboBox2.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.DarkComboBox2.Name = "DarkComboBox2"
        Me.DarkComboBox2.Size = New System.Drawing.Size(230, 24)
        Me.DarkComboBox2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(390, 70)
        Me.Label4.Margin = New System.Windows.Forms.Padding(10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "选择分类"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(220, 131)
        Me.Label5.Margin = New System.Windows.Forms.Padding(10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "选择项"
        '
        'DarkComboBox3
        '
        Me.DarkComboBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.DarkComboBox3.FormattingEnabled = True
        Me.DarkComboBox3.Location = New System.Drawing.Point(223, 158)
        Me.DarkComboBox3.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.DarkComboBox3.Name = "DarkComboBox3"
        Me.DarkComboBox3.Size = New System.Drawing.Size(400, 24)
        Me.DarkComboBox3.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(220, 192)
        Me.Label6.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "步骤列表"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DarkOrange
        Me.LinkLabel1.Location = New System.Drawing.Point(289, 192)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(56, 17)
        Me.LinkLabel1.TabIndex = 30
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "添加步骤"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.DarkOrange
        Me.LinkLabel2.Location = New System.Drawing.Point(351, 192)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(56, 17)
        Me.LinkLabel2.TabIndex = 31
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "更新步骤"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.ActiveLinkColor = System.Drawing.Color.LimeGreen
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.DarkOrange
        Me.LinkLabel3.Location = New System.Drawing.Point(413, 192)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(56, 17)
        Me.LinkLabel3.TabIndex = 32
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "删除步骤"
        '
        'DarkButton1
        '
        Me.DarkButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DarkButton1.Location = New System.Drawing.Point(633, 97)
        Me.DarkButton1.Margin = New System.Windows.Forms.Padding(10)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(139, 85)
        Me.DarkButton1.TabIndex = 33
        Me.DarkButton1.Text = "运行当前预设"
        '
        'Form导出数据预设操作台
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DarkComboBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DarkComboBox2)
        Me.Controls.Add(Me.DarkComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DarkTextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "Form导出数据预设操作台"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "导出数据预设操作台"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DarkTextBox1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DarkComboBox1 As DarkUI.Controls.DarkComboBox
    Friend WithEvents DarkComboBox2 As DarkUI.Controls.DarkComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DarkComboBox3 As DarkUI.Controls.DarkComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
End Class
