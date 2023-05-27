<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form搜索
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
        Me.DarkTextBox1 = New DarkUI.Controls.DarkTextBox()
        Me.DarkButton1 = New DarkUI.Controls.DarkButton()
        Me.DarkLabel1 = New DarkUI.Controls.DarkLabel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.DarkLabel2 = New DarkUI.Controls.DarkLabel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.DarkButton2 = New DarkUI.Controls.DarkButton()
        Me.DarkButton3 = New DarkUI.Controls.DarkButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'DarkTextBox1
        '
        Me.DarkTextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.DarkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DarkTextBox1.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.0!)
        Me.DarkTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkTextBox1.Location = New System.Drawing.Point(10, 10)
        Me.DarkTextBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.DarkTextBox1.Name = "DarkTextBox1"
        Me.DarkTextBox1.Size = New System.Drawing.Size(264, 24)
        Me.DarkTextBox1.TabIndex = 0
        '
        'DarkButton1
        '
        Me.DarkButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton1.Location = New System.Drawing.Point(234, 40)
        Me.DarkButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(40, 24)
        Me.DarkButton1.TabIndex = 1
        Me.DarkButton1.Text = "GO"
        '
        'DarkLabel1
        '
        Me.DarkLabel1.AutoSize = True
        Me.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel1.Location = New System.Drawing.Point(7, 44)
        Me.DarkLabel1.Name = "DarkLabel1"
        Me.DarkLabel1.Size = New System.Drawing.Size(92, 17)
        Me.DarkLabel1.TabIndex = 2
        Me.DarkLabel1.Text = "你要搜索什么？"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(10, 71)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(62, 21)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "项名称"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(10, 97)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(89, 21)
        Me.RadioButton2.TabIndex = 4
        Me.RadioButton2.Text = "Name 键值"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(10, 123)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(93, 21)
        Me.RadioButton3.TabIndex = 5
        Me.RadioButton3.Text = "Author 键值"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(10, 149)
        Me.RadioButton4.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(108, 21)
        Me.RadioButton4.TabIndex = 6
        Me.RadioButton4.Text = "UniqueID 键值"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(10, 175)
        Me.RadioButton5.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(158, 21)
        Me.RadioButton5.TabIndex = 7
        Me.RadioButton5.Text = "依赖项（反向搜索依赖）"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(10, 201)
        Me.RadioButton6.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(194, 21)
        Me.RadioButton6.TabIndex = 8
        Me.RadioButton6.Text = "包含的文件夹（不搜索子目录）"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(10, 227)
        Me.RadioButton7.Margin = New System.Windows.Forms.Padding(5)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(84, 21)
        Me.RadioButton7.TabIndex = 9
        Me.RadioButton7.Text = "NEXUS ID"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'DarkLabel2
        '
        Me.DarkLabel2.AutoSize = True
        Me.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DarkLabel2.Location = New System.Drawing.Point(7, 263)
        Me.DarkLabel2.Margin = New System.Windows.Forms.Padding(10, 10, 10, 0)
        Me.DarkLabel2.Name = "DarkLabel2"
        Me.DarkLabel2.Size = New System.Drawing.Size(80, 17)
        Me.DarkLabel2.TabIndex = 10
        Me.DarkLabel2.Text = "模糊搜索选项"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(10, 290)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(5, 10, 5, 0)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(123, 21)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "不区分字母大小写"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(10, 316)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(159, 21)
        Me.CheckBox2.TabIndex = 12
        Me.CheckBox2.Text = "不区分中英文的标点符号"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(10, 342)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(159, 21)
        Me.CheckBox3.TabIndex = 13
        Me.CheckBox3.Text = "逐字拆分搜索（特耗时）"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'DarkButton2
        '
        Me.DarkButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DarkButton2.Location = New System.Drawing.Point(234, 69)
        Me.DarkButton2.Margin = New System.Windows.Forms.Padding(5)
        Me.DarkButton2.Name = "DarkButton2"
        Me.DarkButton2.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton2.Size = New System.Drawing.Size(40, 24)
        Me.DarkButton2.TabIndex = 14
        Me.DarkButton2.Text = "..."
        '
        'DarkButton3
        '
        Me.DarkButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DarkButton3.Location = New System.Drawing.Point(189, 69)
        Me.DarkButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.DarkButton3.Name = "DarkButton3"
        Me.DarkButton3.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton3.Size = New System.Drawing.Size(40, 24)
        Me.DarkButton3.TabIndex = 15
        Me.DarkButton3.Text = "C"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Form搜索
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 371)
        Me.Controls.Add(Me.DarkButton3)
        Me.Controls.Add(Me.DarkButton2)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DarkLabel2)
        Me.Controls.Add(Me.RadioButton7)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.DarkLabel1)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.DarkTextBox1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 410)
        Me.Name = "Form搜索"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "搜索"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DarkTextBox1 As DarkUI.Controls.DarkTextBox
    Friend WithEvents DarkButton1 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkLabel1 As DarkUI.Controls.DarkLabel
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents DarkLabel2 As DarkUI.Controls.DarkLabel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents DarkButton2 As DarkUI.Controls.DarkButton
    Friend WithEvents DarkButton3 As DarkUI.Controls.DarkButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
