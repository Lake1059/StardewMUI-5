<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form分发
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label预设菜单 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label项菜单 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DCM1 = New DarkUI.Controls.DarkContextMenu()
        Me.刷新预设ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.新增预设ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.重命名预设ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.删除预设ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.克隆预设ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DCM2 = New DarkUI.Controls.DarkContextMenu()
        Me.创建分类打包文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建项打包文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.创建子库打包文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.删除打包文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.克隆打包文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.运行预设ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.DCM1.SuspendLayout()
        Me.DCM2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 461)
        Me.Panel2.TabIndex = 13
        '
        'ListView1
        '
        Me.ListView1.AllowDrop = True
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 36)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(200, 420)
        Me.ListView1.TabIndex = 2
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 180
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label16.Location = New System.Drawing.Point(0, 456)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(200, 5)
        Me.Label16.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Location = New System.Drawing.Point(0, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(200, 5)
        Me.Label14.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label预设菜单)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 31)
        Me.Panel3.TabIndex = 1
        '
        'Label预设菜单
        '
        Me.Label预设菜单.AutoEllipsis = True
        Me.Label预设菜单.BackColor = System.Drawing.Color.Transparent
        Me.Label预设菜单.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label预设菜单.Location = New System.Drawing.Point(0, 0)
        Me.Label预设菜单.Name = "Label预设菜单"
        Me.Label预设菜单.Size = New System.Drawing.Size(200, 30)
        Me.Label预设菜单.TabIndex = 10
        Me.Label预设菜单.Text = " 预设菜单"
        Me.Label预设菜单.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 1)
        Me.Label9.TabIndex = 8
        '
        'Label24
        '
        Me.Label24.AutoEllipsis = True
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label24.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label24.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.Location = New System.Drawing.Point(200, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(1, 461)
        Me.Label24.TabIndex = 14
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ListView2)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Panel12)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(201, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(250, 461)
        Me.Panel4.TabIndex = 15
        '
        'ListView2
        '
        Me.ListView2.AllowDrop = True
        Me.ListView2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ListView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.ListView2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListView2.ForeColor = System.Drawing.SystemColors.Control
        Me.ListView2.FullRowSelect = True
        Me.ListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView2.HideSelection = False
        Me.ListView2.Location = New System.Drawing.Point(0, 36)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.ShowItemToolTips = True
        Me.ListView2.Size = New System.Drawing.Size(244, 420)
        Me.ListView2.TabIndex = 3
        Me.ListView2.TabStop = False
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 230
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label15.Location = New System.Drawing.Point(0, 456)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(250, 5)
        Me.Label15.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Location = New System.Drawing.Point(0, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(250, 5)
        Me.Label17.TabIndex = 5
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.Label项菜单)
        Me.Panel12.Controls.Add(Me.Label10)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(250, 31)
        Me.Panel12.TabIndex = 2
        '
        'Label项菜单
        '
        Me.Label项菜单.AutoEllipsis = True
        Me.Label项菜单.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label项菜单.Location = New System.Drawing.Point(0, 0)
        Me.Label项菜单.Name = "Label项菜单"
        Me.Label项菜单.Size = New System.Drawing.Size(250, 30)
        Me.Label项菜单.TabIndex = 29
        Me.Label项菜单.Text = " 打包文件菜单"
        Me.Label项菜单.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoEllipsis = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label10.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(250, 1)
        Me.Label10.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(451, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1, 461)
        Me.Label1.TabIndex = 16
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.ListView3)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(452, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(432, 461)
        Me.Panel5.TabIndex = 17
        '
        'ListView3
        '
        Me.ListView3.AllowDrop = True
        Me.ListView3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ListView3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.ListView3.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListView3.ForeColor = System.Drawing.SystemColors.Control
        Me.ListView3.FullRowSelect = True
        Me.ListView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView3.HideSelection = False
        Me.ListView3.Location = New System.Drawing.Point(0, 36)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.ShowItemToolTips = True
        Me.ListView3.Size = New System.Drawing.Size(429, 420)
        Me.ListView3.TabIndex = 3
        Me.ListView3.TabStop = False
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 400
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(0, 456)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(432, 5)
        Me.Label2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(0, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 5)
        Me.Label3.TabIndex = 5
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(432, 31)
        Me.Panel6.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoEllipsis = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(432, 30)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = " 内容菜单"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoEllipsis = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(432, 1)
        Me.Label8.TabIndex = 8
        '
        'DCM1
        '
        Me.DCM1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.DCM1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DCM1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.刷新预设ToolStripMenuItem, Me.ToolStripSeparator2, Me.新增预设ToolStripMenuItem, Me.重命名预设ToolStripMenuItem, Me.删除预设ToolStripMenuItem, Me.ToolStripSeparator4, Me.克隆预设ToolStripMenuItem, Me.ToolStripSeparator1, Me.运行预设ToolStripMenuItem})
        Me.DCM1.Name = "DarkContextMenu1"
        Me.DCM1.ShowImageMargin = False
        Me.DCM1.ShowItemToolTips = False
        Me.DCM1.Size = New System.Drawing.Size(156, 179)
        '
        '刷新预设ToolStripMenuItem
        '
        Me.刷新预设ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.刷新预设ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.刷新预设ToolStripMenuItem.Name = "刷新预设ToolStripMenuItem"
        Me.刷新预设ToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.刷新预设ToolStripMenuItem.Text = "刷新预设"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator2.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(108, 6)
        '
        '新增预设ToolStripMenuItem
        '
        Me.新增预设ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.新增预设ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.新增预设ToolStripMenuItem.Name = "新增预设ToolStripMenuItem"
        Me.新增预设ToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.新增预设ToolStripMenuItem.Text = "新增预设"
        '
        '重命名预设ToolStripMenuItem
        '
        Me.重命名预设ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.重命名预设ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.重命名预设ToolStripMenuItem.Name = "重命名预设ToolStripMenuItem"
        Me.重命名预设ToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.重命名预设ToolStripMenuItem.Text = "重命名预设"
        '
        '删除预设ToolStripMenuItem
        '
        Me.删除预设ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.删除预设ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.删除预设ToolStripMenuItem.Name = "删除预设ToolStripMenuItem"
        Me.删除预设ToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.删除预设ToolStripMenuItem.Text = "删除预设"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator4.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(108, 6)
        '
        '克隆预设ToolStripMenuItem
        '
        Me.克隆预设ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.克隆预设ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.克隆预设ToolStripMenuItem.Name = "克隆预设ToolStripMenuItem"
        Me.克隆预设ToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.克隆预设ToolStripMenuItem.Text = "克隆预设"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DCM2
        '
        Me.DCM2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.DCM2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DCM2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.创建分类打包文件ToolStripMenuItem, Me.创建项打包文件ToolStripMenuItem, Me.创建子库打包文件ToolStripMenuItem, Me.ToolStripSeparator5, Me.删除打包文件ToolStripMenuItem, Me.ToolStripSeparator6, Me.克隆打包文件ToolStripMenuItem})
        Me.DCM2.Name = "DarkContextMenu1"
        Me.DCM2.ShowImageMargin = False
        Me.DCM2.ShowItemToolTips = False
        Me.DCM2.Size = New System.Drawing.Size(148, 128)
        '
        '创建分类打包文件ToolStripMenuItem
        '
        Me.创建分类打包文件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.创建分类打包文件ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.创建分类打包文件ToolStripMenuItem.Name = "创建分类打包文件ToolStripMenuItem"
        Me.创建分类打包文件ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.创建分类打包文件ToolStripMenuItem.Text = "创建分类打包文件"
        '
        '创建项打包文件ToolStripMenuItem
        '
        Me.创建项打包文件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.创建项打包文件ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.创建项打包文件ToolStripMenuItem.Name = "创建项打包文件ToolStripMenuItem"
        Me.创建项打包文件ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.创建项打包文件ToolStripMenuItem.Text = "创建项打包文件"
        '
        '创建子库打包文件ToolStripMenuItem
        '
        Me.创建子库打包文件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.创建子库打包文件ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.创建子库打包文件ToolStripMenuItem.Name = "创建子库打包文件ToolStripMenuItem"
        Me.创建子库打包文件ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.创建子库打包文件ToolStripMenuItem.Text = "创建子库打包文件"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator5.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(152, 6)
        '
        '删除打包文件ToolStripMenuItem
        '
        Me.删除打包文件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.删除打包文件ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.删除打包文件ToolStripMenuItem.Name = "删除打包文件ToolStripMenuItem"
        Me.删除打包文件ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.删除打包文件ToolStripMenuItem.Text = "删除打包文件"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripSeparator6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator6.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(152, 6)
        '
        '克隆打包文件ToolStripMenuItem
        '
        Me.克隆打包文件ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.克隆打包文件ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.克隆打包文件ToolStripMenuItem.Name = "克隆打包文件ToolStripMenuItem"
        Me.克隆打包文件ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.克隆打包文件ToolStripMenuItem.Text = "克隆打包文件"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(108, 6)
        '
        '运行预设ToolStripMenuItem
        '
        Me.运行预设ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.运行预设ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.运行预设ToolStripMenuItem.Name = "运行预设ToolStripMenuItem"
        Me.运行预设ToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.运行预设ToolStripMenuItem.Text = "运行预设"
        '
        'Form分发
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(884, 461)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form分发"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "批量分发管理器"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.DCM1.ResumeLayout(False)
        Me.DCM2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label预设菜单 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ListView2 As ListView
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label项菜单 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents ListView3 As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents DCM1 As DarkUI.Controls.DarkContextMenu
    Friend WithEvents 刷新预设ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents 新增预设ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 删除预设ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents 克隆预设ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DCM2 As DarkUI.Controls.DarkContextMenu
    Friend WithEvents 创建分类打包文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 创建项打包文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 创建子库打包文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents 删除打包文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents 克隆打包文件ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 重命名预设ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents 运行预设ToolStripMenuItem As ToolStripMenuItem
End Class
