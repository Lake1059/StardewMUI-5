<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form下载并新建项输入对话框
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DarkTextBox1 = New DarkUI.Controls.DarkTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DarkTextBox2 = New DarkUI.Controls.DarkTextBox()
        Me.DarkButton1 = New DarkUI.Controls.DarkButton()
        Me.DarkComboBox1 = New DarkUI.Controls.DarkComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "新建项名称"
        '
        'DarkTextBox1
        '
        Me.DarkTextBox1.AllowDrop = True
        Me.DarkTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox1.Location = New System.Drawing.Point(22, 49)
        Me.DarkTextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.DarkTextBox1.Name = "DarkTextBox1"
        Me.DarkTextBox1.Size = New System.Drawing.Size(343, 23)
        Me.DarkTextBox1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 145)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "访问 NEXUS 页面 ID"
        '
        'DarkTextBox2
        '
        Me.DarkTextBox2.AllowDrop = True
        Me.DarkTextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox2.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkTextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox2.Location = New System.Drawing.Point(22, 172)
        Me.DarkTextBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.DarkTextBox2.Name = "DarkTextBox2"
        Me.DarkTextBox2.Size = New System.Drawing.Size(100, 29)
        Me.DarkTextBox2.TabIndex = 3
        Me.DarkTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DarkButton1
        '
        Me.DarkButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton1.Location = New System.Drawing.Point(265, 212)
        Me.DarkButton1.Margin = New System.Windows.Forms.Padding(10)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(100, 30)
        Me.DarkButton1.TabIndex = 4
        Me.DarkButton1.Text = "确认"
        '
        'DarkComboBox1
        '
        Me.DarkComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.DarkComboBox1.DropDownHeight = 300
        Me.DarkComboBox1.FormattingEnabled = True
        Me.DarkComboBox1.IntegralHeight = False
        Me.DarkComboBox1.ItemHeight = 20
        Me.DarkComboBox1.Location = New System.Drawing.Point(22, 109)
        Me.DarkComboBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.DarkComboBox1.Name = "DarkComboBox1"
        Me.DarkComboBox1.Size = New System.Drawing.Size(343, 26)
        Me.DarkComboBox1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "目标分类"
        '
        'Form下载并新建项输入对话框
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(384, 261)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DarkComboBox1)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.DarkTextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DarkTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "Form下载并新建项输入对话框"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "下载并新建项"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DarkTextBox1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DarkTextBox2 As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkComboBox1 As DarkUI.Controls.DarkComboBox
    Friend WithEvents Label3 As Label
End Class
