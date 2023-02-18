<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("程序关键信息（非专业人员请勿修改，否则后果自负）", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("程序内置项", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("用户自定义项", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"玩家名字（存档列表显示）", "SaveGameInfo", "Farmer/name"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"玩家名字（游戏内实际）", "[game]", "SaveGame/player/name"}, -1, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, Nothing)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"农场名字（存档列表显示）", "SaveGameInfo", "Farmer/farmName"}, -1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"农场名字（游戏内实际）", "[game]", "SaveGame/player/farmName"}, -1)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"农场选择", "[game]", "SaveGame/whichFarm"}, -1)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"最喜欢的东西", "[game]", "SaveGame/player/favoriteThing"}, -1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"明日天气", "[game]", "SaveGame/weatherForTomorrow"}, -1)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"金币（存档列表显示）", "SaveGameInfo", "Farmer/money"}, -1)
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"金币（游戏内实际）", "[game]", "SaveGame/player/money"}, -1)
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"年（存档列表显示）", "SaveGameInfo", "Farmer/yearForSaveGame"}, -1)
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"年（游戏内实际）", "[game]", "SaveGame/player/yearForSaveGame"}, -1)
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"季节（存档列表显示）", "SaveGameInfo", "Farmer/seasonForSaveGame"}, -1)
        Dim ListViewItem13 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"季节（游戏内实际）", "[game]", "SaveGame/player/seasonForSaveGame"}, -1)
        Dim ListViewItem14 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"季节（其他值）", "[game]", "SaveGame/currentSeason"}, -1)
        Dim ListViewItem15 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"天数（存档列表显示）", "SaveGameInfo", "Farmer/dayOfMonthForSaveGame"}, -1)
        Dim ListViewItem16 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"天数（游戏内实际）", "[game]", "SaveGame/player/dayOfMonthForSaveGame"}, -1)
        Dim ListViewItem17 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"生命值上限", "[game]", "SaveGame/player/maxHealth"}, -1)
        Dim ListViewItem18 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"生命值", "[game]", "SaveGame/player/health"}, -1)
        Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"体力值上限", "[game]", "SaveGame/player/maxStamina"}, -1)
        Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"体力值", "[game]", "SaveGame/player/stamina"}, -1)
        Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"耕种等级", "[game]", "SaveGame/player/farmingLevel"}, -1)
        Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"采矿等级", "[game]", "SaveGame/player/miningLevel"}, -1)
        Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"采集等级", "[game]", "SaveGame/player/foragingLevel"}, -1)
        Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"钓鱼等级", "[game]", "SaveGame/player/fishingLevel"}, -1)
        Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"战斗等级", "[game]", "SaveGame/player/combatLevel"}, -1)
        Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"幸运等级", "[game]", "SaveGame/player/luckLevel"}, -1)
        Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"赌场齐币", "[game]", "SaveGame/player/clubCoins"}, -1)
        Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"齐钻", "[game]", "SaveGame/player/qiGems"}, -1)
        Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"最深矿洞层数", "[game]", "SaveGame/player/deepestMineLevel"}, -1)
        Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"游戏版本", "[game]", "SaveGame/gameVersion"}, -1)
        Dim ListViewItem31 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"游戏修补版本", "[game]", "SaveGame/gameVersionLabel"}, -1)
        Dim ListViewItem32 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"已应用的补丁修复", "[game]", "SaveGame/lastAppliedSaveFix"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.扫描存档ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.选择存档ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存存档ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.编辑数组ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.刷新所有ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.修改值ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.复制XML节点路径ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.扫描存档ToolStripMenuItem, Me.选择存档ToolStripMenuItem, Me.保存存档ToolStripMenuItem, Me.编辑数组ToolStripMenuItem, Me.刷新所有ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(2)
        Me.MenuStrip1.Size = New System.Drawing.Size(859, 32)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '扫描存档ToolStripMenuItem
        '
        Me.扫描存档ToolStripMenuItem.Name = "扫描存档ToolStripMenuItem"
        Me.扫描存档ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.扫描存档ToolStripMenuItem.Text = "扫描存档"
        '
        '选择存档ToolStripMenuItem
        '
        Me.选择存档ToolStripMenuItem.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.选择存档ToolStripMenuItem.Name = "选择存档ToolStripMenuItem"
        Me.选择存档ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.选择存档ToolStripMenuItem.Text = "选择存档"
        '
        '保存存档ToolStripMenuItem
        '
        Me.保存存档ToolStripMenuItem.Name = "保存存档ToolStripMenuItem"
        Me.保存存档ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.保存存档ToolStripMenuItem.Text = "保存存档"
        '
        '编辑数组ToolStripMenuItem
        '
        Me.编辑数组ToolStripMenuItem.Name = "编辑数组ToolStripMenuItem"
        Me.编辑数组ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.编辑数组ToolStripMenuItem.Text = "编辑数组"
        Me.编辑数组ToolStripMenuItem.Visible = False
        '
        '刷新所有ToolStripMenuItem
        '
        Me.刷新所有ToolStripMenuItem.Name = "刷新所有ToolStripMenuItem"
        Me.刷新所有ToolStripMenuItem.Size = New System.Drawing.Size(68, 28)
        Me.刷新所有ToolStripMenuItem.Text = "刷新所有"
        Me.刷新所有ToolStripMenuItem.Visible = False
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.SystemColors.Control
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        ListViewGroup1.Header = "程序关键信息（非专业人员请勿修改，否则后果自负）"
        ListViewGroup1.Name = "ListViewGroup3"
        ListViewGroup2.Header = "程序内置项"
        ListViewGroup2.Name = "ListViewGroup1"
        ListViewGroup3.Header = "用户自定义项"
        ListViewGroup3.Name = "ListViewGroup2"
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        ListViewItem1.Group = ListViewGroup2
        ListViewItem2.Group = ListViewGroup2
        ListViewItem3.Group = ListViewGroup2
        ListViewItem4.Group = ListViewGroup2
        ListViewItem5.Group = ListViewGroup2
        ListViewItem6.Group = ListViewGroup2
        ListViewItem7.Group = ListViewGroup2
        ListViewItem8.Group = ListViewGroup2
        ListViewItem9.Group = ListViewGroup2
        ListViewItem10.Group = ListViewGroup2
        ListViewItem11.Group = ListViewGroup2
        ListViewItem12.Group = ListViewGroup2
        ListViewItem13.Group = ListViewGroup2
        ListViewItem14.Group = ListViewGroup2
        ListViewItem15.Group = ListViewGroup2
        ListViewItem16.Group = ListViewGroup2
        ListViewItem17.Group = ListViewGroup2
        ListViewItem18.Group = ListViewGroup2
        ListViewItem19.Group = ListViewGroup2
        ListViewItem20.Group = ListViewGroup2
        ListViewItem21.Group = ListViewGroup2
        ListViewItem22.Group = ListViewGroup2
        ListViewItem23.Group = ListViewGroup2
        ListViewItem24.Group = ListViewGroup2
        ListViewItem25.Group = ListViewGroup2
        ListViewItem26.Group = ListViewGroup2
        ListViewItem27.Group = ListViewGroup2
        ListViewItem28.Group = ListViewGroup2
        ListViewItem29.Group = ListViewGroup2
        ListViewItem30.Group = ListViewGroup1
        ListViewItem31.Group = ListViewGroup1
        ListViewItem32.Group = ListViewGroup1
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17, ListViewItem18, ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30, ListViewItem31, ListViewItem32})
        Me.ListView1.Location = New System.Drawing.Point(0, 32)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(859, 629)
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.StateImageList = Me.ImageList1
        Me.ListView1.TabIndex = 10
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "属性"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "文件"
        Me.ColumnHeader2.Width = 125
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "XML 节点路径"
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "值"
        Me.ColumnHeader4.Width = 200
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.DropShadowEnabled = False
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.修改值ToolStripMenuItem, Me.ToolStripSeparator1, Me.复制XML节点路径ToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.ShowImageMargin = False
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(158, 54)
        '
        '修改值ToolStripMenuItem
        '
        Me.修改值ToolStripMenuItem.Name = "修改值ToolStripMenuItem"
        Me.修改值ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.修改值ToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.修改值ToolStripMenuItem.Text = "修改值"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(154, 6)
        '
        '复制XML节点路径ToolStripMenuItem
        '
        Me.复制XML节点路径ToolStripMenuItem.Name = "复制XML节点路径ToolStripMenuItem"
        Me.复制XML节点路径ToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.复制XML节点路径ToolStripMenuItem.Text = "复制 XML 节点路径"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(1, 23)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.DropShadowEnabled = False
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(36, 4)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(38, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(859, 661)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(875, 700)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMUI.SaveEditor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 扫描存档ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 选择存档ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存存档ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 编辑数组ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 刷新所有ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents 修改值ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents 复制XML节点路径ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
End Class
