Imports System.ComponentModel
Imports DarkUI.Controls
Imports SMUI.GUI.Class1
Imports SMUI.Windows.Core
Imports SMUI.Windows.PakManager

Public Class Form1

#Region "主窗口"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SevenZip.SevenZipBase.SetLibraryPath(Application.StartupPath & "\7zFull64.dll")
        加载自定义语言文件()
        Application.DoEvents()


        启动时加载用户设置()
        读取导入导出密码本()
        启动时初始化界面()
        If Form调试.Visible = False Then Form调试.Hide()

        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\CefSharp.dll") = False Then
            添加调试文本(获取动态多语言文本("data/DynamicText/Other.3"), Color1.黄色) : Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\CefSharp.Core.dll") = False Then
            添加调试文本(获取动态多语言文本("data/DynamicText/Other.3"), Color1.黄色) : Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\CefSharp.WinForms.dll") = False Then
            添加调试文本(获取动态多语言文本("data/DynamicText/Other.3"), Color1.黄色) : Exit Sub
        End If
        ST1.是否安装了谷歌浏览器组件 = True
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.Panel主选项卡.Left = (Me.Panel主选项卡.Parent.Width - Me.Panel主选项卡.Width) * 0.5
        Me.Label主动态标记.Left = Me.Panel主选项卡.Left
        Me.Panel配置队列左上面板.Width = Me.Panel配置队列左上面板.Parent.Width * 0.5
        Me.Panel配置队列左下面板.Width = Me.Panel配置队列左下面板.Parent.Width * 0.5
        Me.Panel配置队列上方面板.Height = Me.Panel配置队列.Height * 0.5 - Me.Panel配置队列顶部面板.Height - 30
        Me.ListView2.Width = Me.ListView2.Parent.Width - 5 '+ ST1.系统滚动条宽度
        Application.DoEvents()
        调整项列表列宽()
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        If IO.Path.GetFileName(IO.Path.GetDirectoryName(Application.ExecutablePath)).ToLower = "debug" Then
            添加调试文本(获取动态多语言文本("data/DynamicText/Sever.10"), Color1.黄色)
        Else
            运行后台服务器检查更新()
        End If

        Select Case xml_Settings.SelectSingleNode("data/PrivacyChoice").InnerText
            Case "1", "2"
                向服务器发送用户统计()
        End Select

        刷新标题栏主信息显示()
        SYS1.检查用户身份组()
        启动后自动登录NEXUSAPI()
        If xml_Settings.SelectSingleNode("data/AutoGetNews").InnerText = "True" Then
            Label新闻公告_MouseClick(Label新闻公告, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
        End If

        Me.RichTextBox3.BorderStyle = BorderStyle.None
        Me.RichTextBox4.BorderStyle = BorderStyle.None

        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText) = True Then
            扫描数据子库()
            If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText) = True Then
                扫描分类(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText)
            End If
        End If

        Dim graphics As Graphics = Me.CreateGraphics
        If graphics.DpiX <> 96 Then 高DPI兼容处理_主界面()

        谷歌浏览器组件版本提醒()

        ST1.是否已启动完毕 = True
        调整项列表列宽()
        '=============================================
        扫描插件并加载()
        Application.DoEvents()
        If 付费功能解锁.解锁直接从N网下载并新建项的功能 = True Then Me.下载并新建项ToolStripMenuItem.Visible = True
        '=============================================
        DeveloperEvent.Raise_StartLoadedEvent()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        e.Cancel = False
        xml_Settings.SelectSingleNode("data/MainWindowWidth").InnerText = Me.Width
        xml_Settings.SelectSingleNode("data/MainWindowHeight").InnerText = Me.Height
        xml_Settings.Save(Path1.应用程序设置文件路径)
        保存导入导出密码本()
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        If ST1.全局状态_是否需要在退出后安装更新 = True Then
            If My.Computer.FileSystem.FileExists(Path1.更新安装程序文件路径) = True Then
                Shell(Path1.更新安装程序文件路径, AppWinStyle.NormalFocus)
            Else
                MsgBox("No update installers found.", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
#End Region

#Region "起始页面功能"
    Private Sub Label立即检查更新_Click(sender As Object, e As EventArgs) Handles Label立即检查更新.Click
        If 正在进行更新 = True Then
            MsgBox("当前已有更新任务")
            Exit Sub
        End If
        运行后台服务器检查更新()
    End Sub

    Private Sub RichTextBox2_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox2.LinkClicked
        点击文档中的链接时触发(e.LinkText)
        Me.DarkLinkMenu.Show(MousePosition)
    End Sub

    Private Sub Label内容中心_Click(sender As Object, e As EventArgs) Handles Label内容中心.Click

    End Sub

    Private Sub Label内容中心_MouseDown(sender As Object, e As MouseEventArgs) Handles Label内容中心.MouseDown
        Me.DCM内容中心.Show(Me.Left + (Me.Width - Me.DCM内容中心.Width) - 7, MousePosition.Y + (Me.Label内容中心.Height - e.Y) + 9)
    End Sub

    Private Sub Label更新状态标记_Click(sender As Object, e As EventArgs) Handles Label更新状态标记.Click
        If 服务器.获取到的更新内容描述 <> "" Then
            Dim a As New SingleSelectionDialog("changlog", {"OK"}, 服务器.获取到的更新内容描述, 200, 500)
            a.ShowDialog(Me)
        End If
    End Sub

    Private Sub Label参与翻译SMUI_Click(sender As Object, e As EventArgs) Handles Label参与翻译SMUI.Click
        Process.Start("https://stardewmui.fandom.com/zh/wiki/English_Data")
    End Sub

#End Region

#Region "标签按钮视觉效果"

    Sub 一级按钮鼠标移上事件(sender As Object, e As EventArgs) Handles Label设置选项.MouseEnter, Label内容中心.MouseEnter, LabelRunSMAPI.MouseEnter
        sender.ForeColor = Color.LimeGreen
    End Sub

    Sub 一级按钮鼠标移走事件(sender As Object, e As EventArgs) Handles Label设置选项.MouseLeave, LabelRunSMAPI.MouseLeave, Label内容中心.MouseLeave
        sender.ForeColor = ColorTranslator.FromWin32(RGB(240, 240, 240))
    End Sub

    Sub 二级按钮鼠标移上事件(sender As Object, e As EventArgs) Handles LabelUniqueID显示.MouseEnter, Label依赖项数量显示.MouseEnter, Label作者显示.MouseEnter, Label更新地址显示.MouseEnter, Label预览图菜单.MouseEnter, Label项菜单.MouseEnter, Label调试.MouseEnter, Label刷新.MouseEnter, Label描述菜单.MouseEnter, Label筛选.MouseEnter, Label搜索.MouseEnter, Label子库分类菜单.MouseEnter, Label保存并从队列中移除.MouseEnter, Label仅保存.MouseEnter, Label自动完成.MouseEnter, Label移除配置队列中的项.MouseEnter, Label添加文件夹.MouseEnter, Label添加文件.MouseEnter, Label所有命令.MouseEnter, Label刷新项的数据内容.MouseEnter, Label全部复制.MouseEnter, Label参与翻译SMUI.MouseEnter, Label模组更新检查器.MouseEnter, Label存档编辑器.MouseEnter, Label检查模组安装情况.MouseEnter, Label传统管理方式.MouseEnter, Label立即检查更新.MouseEnter, Label插件和扩展内容.MouseEnter, Label角落预览图菜单.MouseEnter, Label移除配置队列里的全部项.MouseEnter, Label关于和许可协议.MouseEnter
        sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Sub 二级按钮鼠标移走事件(sender As Object, e As EventArgs) Handles Label子库分类菜单.MouseLeave, LabelUniqueID显示.MouseLeave, Label依赖项数量显示.MouseLeave, Label作者显示.MouseLeave, Label更新地址显示.MouseLeave, Label项菜单.MouseLeave, Label刷新.MouseLeave, Label搜索.MouseLeave, Label筛选.MouseLeave, Label调试.MouseLeave, Label描述菜单.MouseLeave, Label预览图菜单.MouseLeave, Label保存并从队列中移除.MouseLeave, Label仅保存.MouseLeave, Label自动完成.MouseLeave, Label移除配置队列中的项.MouseLeave, Label添加文件夹.MouseLeave, Label添加文件.MouseLeave, Label所有命令.MouseLeave, Label刷新项的数据内容.MouseLeave, Label全部复制.MouseLeave, Label参与翻译SMUI.MouseLeave, Label模组更新检查器.MouseLeave, Label存档编辑器.MouseLeave, Label检查模组安装情况.MouseLeave, Label传统管理方式.MouseLeave, Label立即检查更新.MouseLeave, Label插件和扩展内容.MouseLeave, Label角落预览图菜单.MouseLeave, Label移除配置队列里的全部项.MouseLeave, Label关于和许可协议.MouseLeave
        sender.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
    End Sub

#End Region

#Region "主选项卡切换"
    Private Sub Label起始页面_Click(sender As Object, e As EventArgs) Handles Label起始页面.Click
        切换主选项卡按钮状态(1)
        隐藏所有主选项卡()
        Me.Panel起始页面.Visible = True
    End Sub

    Private Sub Label管理模组_Click(sender As Object, e As EventArgs) Handles Label管理模组.Click
        切换主选项卡按钮状态(2)
        隐藏所有主选项卡()
        Me.Panel管理模组.Visible = True
        Me.ListView2.Width = Me.ListView2.Parent.Width - 5
        调整项列表列宽()
    End Sub

    Private Sub Label配置队列_Click(sender As Object, e As EventArgs) Handles Label配置队列.Click
        切换主选项卡按钮状态(3)
        隐藏所有主选项卡()
        Me.Panel配置队列.Visible = True
        调整配置队列选项卡界面()
    End Sub

    Public Sub 模拟按下配置队列选项卡切换按钮()
        Label配置队列_Click(Label配置队列, New EventArgs)
    End Sub

#End Region

#Region "起始页面二级选项卡切换"

    Private Sub Label新闻公告_MouseClick(sender As Object, e As MouseEventArgs) Handles Label新闻公告.MouseClick
        Select Case e.Button
            Case MouseButtons.Right
                ST1.本次启动时候已经获取了新闻 = False
        End Select
        切换起始页面内容选项卡按钮状态(sender)
        Me.Panel新闻公告.Visible = True
        运行后台服务器获取新闻()
    End Sub

    Private Sub Label模组列表_Click(sender As Object, e As EventArgs) Handles Label模组列表.Click
        切换起始页面内容选项卡按钮状态(sender)
        Me.Panel模组列表.Visible = True
        If 模组分类数组.Count = 0 Then
            在线模组列表功能.初始化模组分类数组()
        End If
        If Me.Panel模组列表.Controls.Count = 0 Then Me.DCM模组列表.Show(MousePosition)
    End Sub

    Private Sub Label下载模组_Click(sender As Object, e As EventArgs) Handles Label统计数据.Click
        切换起始页面内容选项卡按钮状态(sender)
        Me.Panel统计数据.Visible = True
    End Sub

    Private Sub Label主题内容_Click(sender As Object, e As EventArgs) Handles Label主题内容.Click
        切换起始页面内容选项卡按钮状态(sender)
        Me.Panel主题内容.Visible = True
    End Sub

    Private Sub Label创作者自由面板_Click(sender As Object, e As EventArgs) Handles Label创作者自由面板.Click
        切换起始页面内容选项卡按钮状态(sender)
        Me.Panel创作者自由面板.Visible = True
    End Sub

    Private Sub Label关于和许可协议_Click(sender As Object, e As EventArgs) Handles Label关于和许可协议.Click
        Process.Start("https://github.com/Lake1059/StardewMUI-5/blob/main/Copyright+License.md")
    End Sub

    Private Sub Label查看更新历史_Click(sender As Object, e As EventArgs) Handles Label查看更新历史.Click
        切换起始页面内容选项卡按钮状态(sender)
        Me.Panel更新历史.Visible = True
        Me.RichTextBox2.LoadFile(Application.StartupPath & "\updatehistory.rtf")
    End Sub
#End Region

#Region "调出其他窗口"

    Private Sub Label设置选项_Click(sender As Object, e As EventArgs) Handles Label设置选项.Click
        If Form设置.Visible = False Then
            显示窗体(Form设置, Me)
        Else
            Form设置.Close()
        End If
    End Sub

    Private Sub Label输出_Click(sender As Object, e As EventArgs) Handles Label调试.Click
        显示窗体(Form调试, Me)
    End Sub

    Private Sub Label插件和扩展内容_Click(sender As Object, e As EventArgs) Handles Label插件和扩展内容.Click
        显示模式窗体(Form插件和扩展内容, Me)
    End Sub

    Private Sub Label搜索_Click(sender As Object, e As EventArgs) Handles Label搜索.Click
        If Form搜索.Visible = False Then
            显示窗体(Form搜索, Me)
        Else
            Form搜索.Close()
        End If
    End Sub

    Private Sub Label模组更新检查器_Click(sender As Object, e As EventArgs) Handles Label模组更新检查器.Click
        If Form模组检查更新操作台.Visible = False Then
            Form模组检查更新操作台.Show()
        End If
        Form模组检查更新操作台.Focus()
        Me.检查更新加入表中ToolStripMenuItem.Visible = True
        Me.检查更新加入表中ToolStripMenuItem1.Visible = True
    End Sub

#End Region

#Region "列表视图焦点屏蔽"

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ListView2_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView2.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView2.KeyPress
        e.Handled = True
    End Sub

    Private Sub ListView3_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView3.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView3.KeyPress
        e.Handled = True
    End Sub

    Private Sub ListView4_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView4.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView4.KeyPress
        e.Handled = True
    End Sub

#End Region

#Region "列表视图所有操作"
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        DeveloperEvent.Raise_CategoryListviewSelectedIndexChangedEvent()
        Select Case Me.ListView1.SelectedItems.Count
            Case 1
                刷新项列表()
                ST1.是否处于搜索筛选结果 = False
            Case Else
                If ST1.是否处于搜索筛选结果 = True Then Exit Sub
                清除模组列表()
        End Select

    End Sub

    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        'If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
        '    Dim a As String() = e.Data.GetData(GetType(String()))
        '    For i = 0 To a.Count - 1
        '        Me.ListView1.Items.Add(IO.Path.GetFileName(a(i)))
        '        Me.ListView1.Items(Me.ListView1.Items.Count - 1).StateImageIndex = 0
        '    Next
        'Else
        '    e.Effect = DragDropEffects.Copy
        'End If
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop
        'If ST1.当前用户身份组 <> Security.Principal.WindowsBuiltInRole.Administrator Then
        '    Dim a As String() = e.Data.GetData(DataFormats.FileDrop)
        '    For i = 0 To a.Count - 1
        '        Me.ListView1.Items.Add(IO.Path.GetFileName(a(i)))
        '        Me.ListView1.Items(Me.ListView1.Items.Count - 1).StateImageIndex = 0
        '    Next
        'End If
    End Sub

    Private Sub ListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDown
        If e.Button = MouseButtons.Right Then
            ST1.打开了分类的菜单还是项的菜单 = 1
        End If
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        DeveloperEvent.Raise_ItemListviewSelectedIndexChangedEvent()
        项列表计数显示()
        Select Case Me.ListView2.SelectedItems.Count
            Case 1
                读取项信息并显示()
            Case Else
                重置模组信息显示()
        End Select
    End Sub

    Private Sub ListView2_DragEnter(sender As Object, e As DragEventArgs) Handles ListView2.DragEnter
        'If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
        '    Dim a As String() = e.Data.GetData(GetType(String()))
        '    For i = 0 To a.Count - 1
        '        Me.ListView2.Items.Add(IO.Path.GetFileName(a(i)))
        '        Me.ListView2.Items(Me.ListView2.Items.Count - 1).StateImageIndex = 0
        '    Next
        'Else
        '    e.Effect = DragDropEffects.Copy
        'End If
    End Sub

    Private Sub ListView2_DragDrop(sender As Object, e As DragEventArgs) Handles ListView2.DragDrop
        'If ST1.当前用户身份组 <> Security.Principal.WindowsBuiltInRole.Administrator Then
        '    Dim a As String() = e.Data.GetData(DataFormats.FileDrop)
        '    For i = 0 To a.Count - 1
        '        Me.ListView2.Items.Add(IO.Path.GetFileName(a(i)))
        '        Me.ListView2.Items(Me.ListView2.Items.Count - 1).StateImageIndex = 0
        '    Next
        'End If
    End Sub

    Private Sub ListView2_SizeChanged(sender As Object, e As EventArgs) Handles ListView2.SizeChanged

    End Sub

#End Region

#Region "管理员身份激活拖拽"
    Private Sub 激活拖拽ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 激活拖拽ToolStripMenuItem.Click
        FileDroper.Dispose()
        FileDroper = New WindowsMF.Class1.FileDropHandler(Me.ListView1)
    End Sub

    Private Sub 激活拖拽ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 激活拖拽ToolStripMenuItem1.Click
        FileDroper.Dispose()
        FileDroper = New WindowsMF.Class1.FileDropHandler(Me.ListView2)
    End Sub

    Private Sub 激活项数据内容表的拖拽ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 激活项数据内容表的拖拽ToolStripMenuItem.Click
        FileDroper.Dispose()
        FileDroper = New WindowsMF.Class1.FileDropHandler(Me.ListView4)
    End Sub

#End Region

#Region "其他界面调整"

#End Region

#Region "数据子库菜单"

    Private Sub Label子库分类菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label子库分类菜单.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                ST1.打开了分类的菜单还是项的菜单 = 1
                Dim mouseX As Integer = MousePosition.X
                Dim mouseY As Integer = MousePosition.Y
                If Me.DCM1.Width >= Me.Panel9.Width Then
                    Me.DCM1.Show(mouseX - e.X - 1, mouseY + (Me.DCM1.Height - e.Y) + 1)
                Else
                    Me.DCM1.Show(mouseX - e.X + (Me.Label子库分类菜单.Width - Me.DCM1.Width) + 1, mouseY + (Me.Label子库分类菜单.Height - e.Y) + 1)
                End If
        End Select
    End Sub

    Private Sub Label子库分类菜单_Click(sender As Object, e As EventArgs) Handles Label子库分类菜单.Click

    End Sub

    Private Sub 刷新子库列表ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新子库列表ToolStripMenuItem.Click
        清除模组列表()
        清除分类列表()
        扫描数据子库()
    End Sub

    Private Sub 新建数据子库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建数据子库ToolStripMenuItem.Click
        Dim s1 As String = 检查并返回当前模组数据仓库路径()
        If s1 = "" Then Exit Sub
        Dim a As New InputTextDialog(获取动态多语言文本("data/DynamicText/NewSubLibrary"), 获取动态多语言文本("data/DynamicText/ManageMod.5"))
        a.TranslateButtonText(获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel"))
Line1:
        Dim s2 As String = a.ShowDialog(Me)
        If s2 = "" Then Exit Sub
        If My.Computer.FileSystem.DirectoryExists(s1 & "\" & s2) = True Then
            Dim b As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.6") & vbNewLine & vbNewLine & s1 & "\" & s2,, 500)
            b.ShowDialog(Me)
            GoTo Line1
        Else
            My.Computer.FileSystem.CreateDirectory(s1 & "\" & s2)
            扫描数据子库()
        End If
    End Sub

    Private Sub 导入数据子库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入数据子库ToolStripMenuItem.Click
        Form导入.Text = 获取动态多语言文本("data/DynamicText/ManageMod.25")
        显示模式窗体(Form导入, Me)
    End Sub

    Private Sub 导出数据子库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出数据子库ToolStripMenuItem.Click
        Form导出.Text = 获取动态多语言文本("data/DynamicText/ManageMod.28")
        显示模式窗体(Form导出, Me)
    End Sub

#End Region

#Region "分类菜单和分类右键菜单"
    Private Sub 刷新分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新分类ToolStripMenuItem.Click
        清除模组列表()
        Dim a As String = 检查并返回当前所选子库路径()
        If a = "" Then Exit Sub
        扫描分类(a)
    End Sub

    Private Sub 新建分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建分类ToolStripMenuItem.Click
        Dim a As String = 检查并返回当前所选子库路径()
        If a = "" Then Exit Sub
        Dim d1 As New InputTextDialog(获取动态多语言文本("data/DynamicText/NewCategory"), 获取动态多语言文本("data/DynamicText/ManageMod.7"),, 500)
        d1.TranslateButtonText(获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel"))
Line1:
        Dim s1 As String = d1.ShowDialog(Me)
        If s1 = "" Then Exit Sub
        If My.Computer.FileSystem.DirectoryExists(a & "\" & s1) = True Then
            Dim b As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.6") & vbNewLine & vbNewLine & a & "\" & s1,, 500)
            b.ShowDialog(Me)
            GoTo Line1
        Else
            My.Computer.FileSystem.CreateDirectory(a & "\" & s1)
            Me.ListView1.Items.Add(s1)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).StateImageIndex = 0
        End If
        Me.Label分类计数显示.Text = Me.ListView1.Items.Count
    End Sub

    Private Sub 转移分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 转移分类ToolStripMenuItem.Click
        Dim x As New DarkContextMenu With {.ShowImageMargin = False, .ShowCheckMargin = False}
        Dim a As String() = SharedFunction.SearchFolderWithoutSub(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText)
        x.Items.Add(New ToolStripMenuItem With {.Text = 获取动态多语言文本("data/DynamicText/ManageMod.15"), .Enabled = False})
        x.Items.Add(New ToolStripSeparator)
        For i = 0 To a.Count - 1
            Dim m As New ToolStripMenuItem With {.Text = a(i)}
            x.Items.Add(m)
            AddHandler m.Click,
                Sub(s1 As Object, e1 As EventArgs)
                    Dim i2 As Integer = 0
                    Do Until i2 = Me.ListView1.Items.Count
                        If Me.ListView1.Items.Item(i2).Selected = True Then
                            Dim 当前选择的目标子库 As String = s1.Text
                            Dim 原路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView1.Items.Item(i2).Text
                            Dim 目标路径 As String = 检查并返回当前模组数据仓库路径(False) & "\" & 当前选择的目标子库 & "\" & Me.ListView1.Items.Item(i2).Text
                            If My.Computer.FileSystem.DirectoryExists(目标路径) = False Then
                                My.Computer.FileSystem.MoveDirectory(原路径, 目标路径)
                                Me.ListView1.Items.Item(i2).Remove()
                                i2 -= 1
                            End If
                        End If
                        i2 += 1
                    Loop
                    清除模组列表()
                    Me.Label分类计数显示.Text = Me.ListView1.Items.Count
                End Sub
        Next
        x.Show(MousePosition)
    End Sub

    Private Sub 删除分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除分类ToolStripMenuItem.Click
        Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/DeletionInProgress"), {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DynamicText/ManageMod.8"),, 500)
        If a.ShowDialog(Me) = 0 Then
            Dim i As Integer = 0
            Do Until i = Me.ListView1.Items.Count
                If Me.ListView1.Items.Item(i).Selected = True Then
                    My.Computer.FileSystem.DeleteDirectory(检查并返回当前所选子库路径(False) & "\" & Me.ListView1.Items.Item(i).Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                    Me.ListView1.Items.Item(i).Remove()
                    i -= 1
                End If
                i += 1
            Loop
        End If
        Me.Label分类计数显示.Text = Me.ListView1.Items.Count
    End Sub

    Private Sub 导入分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入分类ToolStripMenuItem.Click
        Form导入.Text = 获取动态多语言文本("data/DynamicText/ManageMod.26")
        显示模式窗体(Form导入, Me)
    End Sub

    Private Sub 导出分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出分类ToolStripMenuItem.Click
        Form导出.Text = 获取动态多语言文本("data/DynamicText/ManageMod.29")
        显示模式窗体(Form导出, Me)
    End Sub

    Private Sub 打开选择分类的文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开选择分类的文件夹ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 1 Then Process.Start(检查并返回当前所选子库路径() & "\" & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text)
    End Sub

    Private Sub 重命名分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重命名分类ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As New InputTextDialog("", 获取动态多语言文本("data/DynamicText/ManageMod.9") & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text, Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text)
        a.TranslateButtonText(获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel"))
Line1:
        Dim s1 As String = a.ShowDialog(Me)
        If s1 = "" Then Exit Sub
        If My.Computer.FileSystem.DirectoryExists(检查并返回当前所选子库路径(False) & "\" & s1) = True Then
            Dim b As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.6") & vbNewLine & vbNewLine & s1,, 500)
            b.ShowDialog(Me)
            GoTo Line1
        Else
            Dim x As String = Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text
            My.Computer.FileSystem.RenameDirectory(检查并返回当前所选子库路径(False) & "\" & x, s1)
            Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text = s1
            For i = 0 To 当前项列表中项的分类集合.Count - 1
                If 当前项列表中项的分类集合(i) = x Then 当前项列表中项的分类集合(i) = s1
            Next
            For i = 0 To Me.ListView2.Items.Count - 1
                If Me.ListView2.Items.Item(i).SubItems(3).Text = x Then Me.ListView2.Items.Item(i).SubItems(3).Text = s1
            Next
        End If

    End Sub

    Private Sub 查看选中分类的属性ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 查看选中分类的属性ToolStripMenuItem.Click

    End Sub

    Private Sub 清除Config缓存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除Config缓存ToolStripMenuItem.Click
        Dim a As String = 检查并返回当前所选子库路径(False)
        Dim p As String() = {}
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            Dim x As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(a & "\" & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).Text)
            For i9 = 0 To x.Count - 1
                ReDim Preserve p(p.Count)
                p(p.Count - 1) = a & "\" & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).Text & "\" & x(i9)
            Next
        Next

        For i3 = 0 To p.Count - 1
            If My.Computer.FileSystem.DirectoryExists(p(i3) & "\.config") = False Then Continue For
            My.Computer.FileSystem.DeleteDirectory(p(i3) & "\.config", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Next
        MsgBox("Finish.")
    End Sub

#End Region

#Region "项菜单和刷新功能"
    Private Sub Label项菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label项菜单.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                ST1.打开了分类的菜单还是项的菜单 = 2
                Dim mouseX As Integer = MousePosition.X
                Dim mouseY As Integer = MousePosition.Y
                Me.DCM6.Show(mouseX - e.X, mouseY + (Me.Label项菜单.Height - e.Y) + 1)
        End Select
    End Sub

    Private Sub Label刷新_MouseDown(sender As Object, e As MouseEventArgs) Handles Label刷新.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                刷新项列表数据()
            Case MouseButtons.Right
                刷新项列表()
        End Select
    End Sub

    Private Sub 新建项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建项ToolStripMenuItem.Click
        Dim a As String = 检查并返回当前选择分类路径()
        If a = "" Then Exit Sub
        Dim d1 As New InputTextDialog(获取动态多语言文本("data/DynamicText/NewItem"), 获取动态多语言文本("data/DynamicText/ManageMod.11"),, 500)
        d1.TranslateButtonText(获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel"))
Line1:
        Dim s1 As String = d1.ShowDialog(Me)
        If s1 = "" Then Exit Sub
        If My.Computer.FileSystem.DirectoryExists(a & "\" & s1) = True Then
            Dim b As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.6") & vbNewLine & vbNewLine & a & "\" & s1,, 500)
            b.ShowDialog(Me)
            GoTo Line1
        Else
            My.Computer.FileSystem.CreateDirectory(a & "\" & s1)

            Me.ListView2.Items.Add(s1)
            Me.ListView2.Items.Item(Me.ListView2.Items.Count - 1).StateImageIndex = 2
            Me.ListView2.Items.Item(Me.ListView2.Items.Count - 1).ForeColor = Color1.橙色
            Me.ListView2.Items.Item(Me.ListView2.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DynamicText/Unavailable"))
            Me.ListView2.Items.Item(Me.ListView2.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DynamicText/ManageMod.12"))
            Me.ListView2.Items.Item(Me.ListView2.Items.Count - 1).SubItems.Add(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text)
            ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
            当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text
            Me.ListView3.Items.Add(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text)
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add(s1)
            If Me.ListView3.SelectedItems.Count = 0 Then Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).Selected = True
            If Me.ListView3.Items.Count = 1 Then
                Label配置队列_Click(sender, e)
            End If
        End If
        Me.Label项列表计数显示.Text = Me.ListView2.Items.Count
    End Sub

    Private Sub 下载并新建项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 下载并新建项ToolStripMenuItem.Click
        显示模式窗体(Form下载并新建项输入对话框, Me)
    End Sub

    Private Sub 移动项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移动项ToolStripMenuItem.Click
        Dim x As New DarkContextMenu With {.ShowImageMargin = False, .ShowCheckMargin = False}
        Dim a As String() = SharedFunction.SearchFolderWithoutSub(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText)
        x.Items.Add(New ToolStripMenuItem With {.Text = 获取动态多语言文本("data/DynamicText/ManageMod.14"), .Enabled = False})
        x.Items.Add(New ToolStripSeparator)
        For i = 0 To a.Count - 1
            Dim m As New ToolStripMenuItem With {.Text = a(i)}
            x.Items.Add(m)
            AddHandler m.Click,
                Sub(s1 As Object, e1 As EventArgs)
                    Dim i2 As Integer = 0
                    Do Until i2 = Me.ListView2.Items.Count
                        If Me.ListView2.Items.Item(i2).Selected = True Then
                            Dim 当前选择的目标分类 As String = s1.Text
                            Dim 原路径 As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(i2) & "\" & Me.ListView2.Items.Item(i2).Text
                            Dim 目标路径 As String = 检查并返回当前所选子库路径(False) & "\" & 当前选择的目标分类 & "\" & Me.ListView2.Items.Item(i2).Text
                            If My.Computer.FileSystem.DirectoryExists(目标路径) = False Then
                                My.Computer.FileSystem.MoveDirectory(原路径, 目标路径)
                                Dim Array对象 As New ArrayList(当前项列表中项的分类集合)
                                Array对象.RemoveAt(i2)
                                当前项列表中项的分类集合 = DirectCast(Array对象.ToArray(GetType(String)), String())
                                Me.ListView2.Items.Item(i2).Remove()
                                i2 -= 1
                            End If
                        End If
                        i2 += 1
                    Loop
                    x.Dispose()
                End Sub
        Next
        x.Show(MousePosition)
    End Sub

    Private Sub 删除项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除项ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count = 0 Then Exit Sub
        Dim str As String
        Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/DeletionInProgress"), {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DynamicText/ManageMod.13"),, 500)
        If a.ShowDialog(Me) = 0 Then
            Dim i As Integer = 0
            Do Until i = Me.ListView2.Items.Count
                If Me.ListView2.Items.Item(i).Selected = True Then
                    str = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(i) & "\" & Me.ListView2.Items.Item(i).Text
                    My.Computer.FileSystem.DeleteDirectory(str, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                    Dim Array对象 As New ArrayList(当前项列表中项的分类集合)
                    Array对象.RemoveAt(i)
                    当前项列表中项的分类集合 = DirectCast(Array对象.ToArray(GetType(String)), String())
                    Me.ListView2.Items.Item(i).Remove()
                    i -= 1
                End If
                i += 1
            Loop
        End If
        Me.Label项列表计数显示.Text = Me.ListView2.Items.Count
    End Sub

    Private Sub 导入项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导入项ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then
            Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.3"),, 500)
            a.ShowDialog(Me)
            Exit Sub
        End If
        Form导入.Text = 获取动态多语言文本("data/DynamicText/ManageMod.27")
        显示模式窗体(Form导入, Me)
    End Sub

    Private Sub 导出项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 导出项ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count = 0 Then
            Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.17"),, 500)
            a.ShowDialog(Me)
            Exit Sub
        End If
        Form导出.Text = 获取动态多语言文本("data/DynamicText/ManageMod.30")
        显示模式窗体(Form导出, Me)
    End Sub

    Private Sub 批量创建ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量创建ToolStripMenuItem.Click
        显示窗体(Form批量创建, Me)
    End Sub

    Private Sub 从Mods中覆盖到仓库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 从Mods中覆盖到仓库ToolStripMenuItem.Click
        安装卸载后台统一执行操作(后台操作类型.更新项_直接覆盖)
    End Sub

    Private Sub 从Mods中替换到仓库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 从Mods中替换到仓库ToolStripMenuItem.Click
        安装卸载后台统一执行操作(后台操作类型.更新项_完全替换)
    End Sub

    Private Sub 切换显示所属分类ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 切换显示所属分类ToolStripMenuItem.Click
        调整项列表列宽(True)
    End Sub


#End Region

#Region "筛选功能"

    Private Sub Label筛选_MouseDown(sender As Object, e As MouseEventArgs) Handles Label筛选.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                Dim mouseX As Integer = MousePosition.X
                Dim mouseY As Integer = MousePosition.Y
                Me.DCM10.Show(mouseX - e.X, mouseY + (Me.Label筛选.Height - e.Y) + 1)
        End Select
    End Sub

    Private Sub 全选ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全选ToolStripMenuItem.Click
        For i = 0 To Me.ListView2.Items.Count - 1
            Me.ListView2.Items.Item(i).Selected = True
        Next
    End Sub

    Private Sub 反选ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 反选ToolStripMenuItem.Click
        For i = 0 To Me.ListView2.Items.Count - 1
            If Me.ListView2.Items.Item(i).Selected = True Then
                Me.ListView2.Items.Item(i).Selected = False
            Else
                Me.ListView2.Items.Item(i).Selected = True
            End If
        Next
    End Sub

    Private Sub 选择当前列表已安装ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选择当前列表已安装ToolStripMenuItem.Click
        选中已安装()
    End Sub

    Private Sub 选择当前列表未安装ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选择当前列表未安装ToolStripMenuItem.Click
        选中未安装()
    End Sub

    Private Sub 选择当前列表在线更新可用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选择当前列表在线更新可用ToolStripMenuItem.Click
        选中在线更新可用()
    End Sub

    Private Sub 选择当前列表本地更新可用ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选择当前列表本地更新可用ToolStripMenuItem.Click
        选中更新可用()
    End Sub

    Private Sub 选择当前列表已有新的ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选择当前列表已有新的ToolStripMenuItem.Click
        选中已有新的()
    End Sub

    Private Sub 扫描当前子库已安装ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 扫描当前子库已安装ToolStripMenuItem.Click
        全局筛选已安装()
    End Sub

    Private Sub 扫描当前子库未安装ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 扫描当前子库未安装ToolStripMenuItem.Click
        全局筛选未安装()
    End Sub

    Private Sub 扫描当前子库文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 扫描当前子库文件夹ToolStripMenuItem.Click
        全局筛选文件夹()
    End Sub

    Private Sub 扫描当前子库文件ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 扫描当前子库文件ToolStripMenuItem.Click
        全局筛选文件()
    End Sub

#End Region

#Region "描述菜单和描述面板功能"

    Private Sub Label描述菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label描述菜单.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                Dim mouseX As Integer = MousePosition.X
                Dim mouseY As Integer = MousePosition.Y
                Me.DCM11.Show(mouseX - e.X, mouseY + (Me.Label描述菜单.Height - e.Y) + 1)
        End Select
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        点击文档中的链接时触发(e.LinkText)
        Me.DarkLinkMenu.Show(MousePosition)
    End Sub

    Private Sub 新建RTF文档ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新建RTF文档ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Me.RichTextBox1.LoadFile(Application.StartupPath & "\newrtf.rtf")
    End Sub

    Private Sub 在写字板中编辑RTFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 在写字板中编辑RTFToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim a As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text
        If My.Computer.FileSystem.FileExists(a & "\README.rtf") = False Then
            Dim x As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DynamicText/ManageMod.23"))
            Select Case x.ShowDialog(Me)
                Case -1, 0
                    Exit Sub
                Case 1
                    My.Computer.FileSystem.CopyFile(Application.StartupPath & "\newrtf.rtf", a & "\README.rtf")
            End Select
        End If
jx1:
        If My.Computer.FileSystem.FileExists("C:\Program Files\Windows NT\Accessories\wordpad.exe") = True Then
            Shell("""" & "C:\Program Files\Windows NT\Accessories\wordpad.exe" & """" & " " & """" & a & "\README.rtf" & """", AppWinStyle.NormalFocus)
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\Windows NT\Accessories\wordpad.exe") = True Then
            Shell("""" & "C:\Program Files (x86)\Windows NT\Accessories\wordpad.exe" & """" & " " & """" & a & "\README.rtf" & """", AppWinStyle.NormalFocus)
            Exit Sub
        End If
        Dim b As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.24"))
        b.ShowDialog(Me)
    End Sub

    Private Sub 保存到RTF富文本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存到RTF富文本ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim a As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text
        Me.RichTextBox1.SaveFile(a & "\README.rtf")
        If My.Computer.FileSystem.FileExists(a & "\README") = True Then My.Computer.FileSystem.DeleteFile(a & "\README", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Label描述类型.Text = "RTF"
        Dim x As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/Yes")}, 获取动态多语言文本("data/DynamicText/ManageMod.21"))
        x.ShowDialog(Me)
    End Sub

    Private Sub 保存到TXT纯文本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存到TXT纯文本ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim a As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text
        My.Computer.FileSystem.WriteAllText(a & "\README", Me.RichTextBox1.Text, False)
        If My.Computer.FileSystem.FileExists(a & "\README.rtf") = True Then My.Computer.FileSystem.DeleteFile(a & "\README.rtf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Label描述类型.Text = "TXT"
        Dim x As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/Yes")}, 获取动态多语言文本("data/DynamicText/ManageMod.22"))
        x.ShowDialog(Me)
    End Sub

    Private Sub 切换滚动条显示ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 切换滚动条显示ToolStripMenuItem.Click

    End Sub

    Private Sub 设置选中内容的字体ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置选中内容的字体ToolStripMenuItem.Click
        Dim a As New FontDialog
        a.ShowDialog(Me)
        If a.Font IsNot Nothing Then Me.RichTextBox1.SelectionFont = a.Font
    End Sub

    Private Sub 设置选中内容的颜色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 设置选中内容的颜色ToolStripMenuItem.Click
        Dim a As New ColorDialog
        a.ShowDialog(Me)
        If a.Color <> Nothing Then Me.RichTextBox1.SelectionColor = a.Color
    End Sub

    Private Sub 清除选择内容的格式ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除选择内容的格式ToolStripMenuItem.Click
        Me.RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
        Me.RichTextBox1.SelectionBackColor = Me.RichTextBox1.BackColor
        Me.RichTextBox1.SelectionColor = Me.RichTextBox1.ForeColor
        Me.RichTextBox1.SelectionFont = Me.RichTextBox1.Font
        Me.RichTextBox1.SelectionIndent = 0
    End Sub

#End Region

#Region "项右键菜单"

    Private Sub 安装ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 安装ToolStripMenuItem.Click
        安装卸载后台统一执行操作(后台操作类型.安装)
    End Sub

    Private Sub 卸载ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 卸载ToolStripMenuItem.Click
        安装卸载后台统一执行操作(后台操作类型.卸载)
    End Sub

    Private Sub 配置部署ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 配置部署ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count = 0 Then
            Dim msg As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.17"))
            msg.ShowDialog(Me)
            Exit Sub
        End If
        For k = 0 To Me.ListView2.SelectedItems.Count - 1
            Dim 分类 As String = 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(k))
            Dim 项 As String = Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(k)).Text
            If My.Computer.FileSystem.DirectoryExists(检查并返回当前所选子库路径(False) & "\" & 分类 & "\" & 项) = False Then
                GoTo jx
            End If
            For i = 0 To Me.ListView3.Items.Count - 1
                If Me.ListView3.Items.Item(i).Text = 分类 And Me.ListView3.Items.Item(i).SubItems(1).Text = 项 Then
                    GoTo jx
                End If
            Next
            Me.ListView3.Items.Add(分类)
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add(项)
jx:
        Next
        If Me.ListView3.SelectedItems.Count = 0 Then Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).Selected = True
        If Me.ListView3.Items.Count = 1 Then
            Label配置队列_Click(sender, e)
        End If
    End Sub

    Private Sub 打开选中项的文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开选中项的文件夹ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 0 Then
            Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.10"))
            Exit Sub
        End If
        Process.Start(检查并返回当前所选子库路径() & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text)
    End Sub


#End Region

#Region "显示项信息功能集"

    Private Sub Label更新地址显示_MouseDown(sender As Object, e As MouseEventArgs) Handles Label更新地址显示.MouseDown
        Dim a As DarkContextMenu = 生成更新地址表菜单()
        a.Show(MousePosition.X - e.X - 1, MousePosition.Y - e.Y - a.Height)
        If a.Top <> MousePosition.Y - e.Y - a.Height Then a.Top = MousePosition.Y - e.Y - a.Height
    End Sub

    Private Sub LabelUniqueID显示_MouseDown(sender As Object, e As MouseEventArgs) Handles LabelUniqueID显示.MouseDown
        Dim a As DarkContextMenu = 生成UniqueID菜单()
        a.Show(MousePosition.X - e.X - 1, MousePosition.Y - e.Y - a.Height)
        If a.Top <> MousePosition.Y - e.Y - a.Height Then a.Top = MousePosition.Y - e.Y - a.Height
    End Sub

    Private Sub Label作者显示_MouseDown(sender As Object, e As MouseEventArgs) Handles Label作者显示.MouseDown
        Dim a As DarkContextMenu = 生成作者列表菜单()
        a.Show(MousePosition.X - e.X - 1, MousePosition.Y - e.Y - a.Height)
        If Panel10.Width <a.Width Then
            a.Show(MousePosition.X - e.X + 1 + (Panel10.Width - a.Width), MousePosition.Y - e.Y - a.Height)
        End If
        If a.Top <> MousePosition.Y - e.Y - a.Height Then a.Top = MousePosition.Y - e.Y - a.Height
    End Sub

    Private Sub Label依赖项数量显示_Click(sender As Object, e As EventArgs) Handles Label依赖项数量显示.Click
        If Form依赖项表.Visible = False Then
            Form依赖项表.Left = Me.Left + 7 + 15
            Form依赖项表.Top = Me.Top + Me.Height - Form依赖项表.Height - 38 - 15
            Form依赖项表.Show(Me)
        Else
            Form依赖项表.Close()
        End If
    End Sub


#End Region

#Region "设置字体功能"
    Private Sub 标准字体ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 标准字体ToolStripMenuItem.Click
        设置字体_默认()
    End Sub

    Private Sub 粗体ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 粗体ToolStripMenuItem.Click
        设置字体_粗体()
    End Sub

    Private Sub 斜体ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 斜体ToolStripMenuItem.Click
        设置字体_斜体()
    End Sub

    Private Sub 下划线ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 下划线ToolStripMenuItem.Click
        设置字体_下划线()
    End Sub

    Private Sub 删除线ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除线ToolStripMenuItem.Click
        设置字体_删除线()
    End Sub

#End Region

#Region "设置分类颜色功能"
    Private Sub Default220220220ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Default220220220ToolStripMenuItem.Click
        设置分类颜色_白色()
    End Sub

    Private Sub OrangeRed255690ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrangeRed255690ToolStripMenuItem.Click
        设置分类颜色_红色()
    End Sub

    Private Sub DarkOrange2551400ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkOrange2551400ToolStripMenuItem.Click
        设置分类颜色_橙色()
    End Sub

    Private Sub YellowL2402400ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YellowL2402400ToolStripMenuItem.Click
        设置分类颜色_黄色()
    End Sub

    Private Sub LimeGreen5020550ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimeGreen5020550ToolStripMenuItem.Click
        设置分类颜色_绿色()
    End Sub

    Private Sub AquaL0230230ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AquaL0230230ToolStripMenuItem.Click
        设置分类颜色_青色()
    End Sub

    Private Sub DeepSkyBlue0191255ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeepSkyBlue0191255ToolStripMenuItem.Click
        设置分类颜色_蓝色()
    End Sub

    Private Sub Violet238130238ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Violet238130238ToolStripMenuItem.Click
        设置分类颜色_紫色()
    End Sub


#End Region

#Region "配置队列界面控制"
    Private Sub Panel17_Paint(sender As Object, e As PaintEventArgs) Handles Panel17.Paint

    End Sub

    Private Sub Panel17_SizeChanged(sender As Object, e As EventArgs) Handles Panel17.SizeChanged
        If ST1.是否已启动完毕 = False Then Exit Sub
        校准RichTextBox3的尺寸和位置()
    End Sub

    Private Sub Panel18_Paint(sender As Object, e As PaintEventArgs) Handles Panel18.Paint

    End Sub

    Private Sub Panel18_SizeChanged(sender As Object, e As EventArgs) Handles Panel18.SizeChanged
        If ST1.是否已启动完毕 = False Then Exit Sub
        校准RichTextBox4的尺寸和位置()
    End Sub


#End Region

#Region "配置队列功能"

    Private Sub ListView4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView4.SelectedIndexChanged

    End Sub

    Private Sub ListView4_DragEnter(sender As Object, e As DragEventArgs) Handles ListView4.DragEnter
        If Me.ListView3.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
            Dim 配置队列_选中项的路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text
            Dim 要复制的文件和文件夹列表 As String() = e.Data.GetData(GetType(String()))
            For i = 0 To 要复制的文件和文件夹列表.Count - 1
                Dim a As String = 要复制的文件和文件夹列表(i)
                If IO.Directory.Exists(a) = True Then
                    My.Computer.FileSystem.CopyDirectory(a, 配置队列_选中项的路径 & "\" & IO.Path.GetFileName(a), FileIO.UIOption.AllDialogs)
                Else
                    My.Computer.FileSystem.CopyFile(a, 配置队列_选中项的路径 & "\" & IO.Path.GetFileName(a), FileIO.UIOption.AllDialogs)
                End If
            Next
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListView4_DragDrop(sender As Object, e As DragEventArgs) Handles ListView4.DragDrop
        If Me.ListView3.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim 配置队列_选中项的路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text
        If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
            Dim 要复制的文件和文件夹列表 As String() = e.Data.GetData(DataFormats.FileDrop)
            For i = 0 To 要复制的文件和文件夹列表.Count - 1
                Dim a As String = 要复制的文件和文件夹列表(i)
                If IO.Directory.Exists(a) = True Then
                    My.Computer.FileSystem.CopyDirectory(a, 配置队列_选中项的路径 & "\" & IO.Path.GetFileName(a), FileIO.UIOption.AllDialogs)
                Else
                    My.Computer.FileSystem.CopyFile(a, 配置队列_选中项的路径 & "\" & IO.Path.GetFileName(a), FileIO.UIOption.AllDialogs)
                End If
            Next
            重新扫描项的数据内容(配置队列_选中项的路径)
        End If
    End Sub

    Private Sub Label移除配置队列中的项_Click(sender As Object, e As EventArgs) Handles Label移除配置队列中的项.Click
        Dim i As Integer = 0
        Do Until i = Me.ListView3.Items.Count
            If Me.ListView3.Items.Item(i).Selected = True Then
                Me.ListView3.Items.Item(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
        重置配置队列选择状态()
        If Me.ListView3.Items.Count = 0 Then Label管理模组_Click(sender, e)
    End Sub

    Private Sub Label移除配置队列里的全部项_Click(sender As Object, e As EventArgs) Handles Label移除配置队列里的全部项.Click
        Me.ListView3.Items.Clear()
        重置配置队列选择状态()
        Label管理模组_Click(sender, e)
    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged
        选中队列中的项时触发读取()
    End Sub

    Private Sub Label保存并从队列中移除_Click(sender As Object, e As EventArgs) Handles Label保存并从队列中移除.Click
        If Me.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        If 保存到项() = True Then
            Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Remove()
            If Me.ListView3.Items.Count = 0 Then Label管理模组_Click(sender, e)
        End If
    End Sub

    Private Sub Label仅保存_Click(sender As Object, e As EventArgs) Handles Label仅保存.Click
        If Me.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        保存到项()
        Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text = Me.ToolStripTextBox1.Text
        Dim msg As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Deploy.4"))
        msg.ShowDialog(Me)
    End Sub

    Private Sub Label刷新项的数据内容_Click(sender As Object, e As EventArgs) Handles Label刷新项的数据内容.Click
        重新扫描项的数据内容(检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text)
    End Sub

    Private Sub Label添加文件_Click(sender As Object, e As EventArgs) Handles Label添加文件.Click
        If Me.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        Dim x As New OpenFileDialog With {.Multiselect = True}
        x.ShowDialog(Me)
        If x.FileNames.Count = 0 Then Exit Sub
        Dim 配置队列_选中项的路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text
        Dim 要复制的文件和文件夹列表 As String() = x.FileNames
        For i = 0 To 要复制的文件和文件夹列表.Count - 1
            Dim a As String = 要复制的文件和文件夹列表(i)
            My.Computer.FileSystem.CopyFile(a, 配置队列_选中项的路径 & "\" & IO.Path.GetFileName(a), FileIO.UIOption.AllDialogs)
        Next
        重新扫描项的数据内容(配置队列_选中项的路径)
    End Sub

    Private Sub Label添加文件夹_Click(sender As Object, e As EventArgs) Handles Label添加文件夹.Click
        If Me.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        Dim x As New WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser With {.Multiselect = True}
        x.ShowDialog(Me)
        If x.SelectedPaths.Count = 0 Then Exit Sub
        Dim 配置队列_选中项的路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text
        Dim 要复制的文件和文件夹列表 As String() = x.SelectedPaths
        For i = 0 To 要复制的文件和文件夹列表.Count - 1
            Dim a As String = 要复制的文件和文件夹列表(i)
            My.Computer.FileSystem.CopyDirectory(a, 配置队列_选中项的路径 & "\" & IO.Path.GetFileName(a), FileIO.UIOption.AllDialogs)
        Next
        重新扫描项的数据内容(配置队列_选中项的路径)
    End Sub

    Private Sub Label自动完成_Click(sender As Object, e As EventArgs) Handles Label自动完成.Click
        自动生成命令()
    End Sub

    Private Sub Label所有命令_Click(sender As Object, e As EventArgs) Handles Label所有命令.Click
    End Sub

    Private Sub Label所有命令_MouseDown(sender As Object, e As MouseEventArgs) Handles Label所有命令.MouseDown
        Dim a As ContextMenuStrip = 显示所有命令()
        a.Show(Me.Left + (Me.Width - a.Width) - 7, MousePosition.Y + (Me.Label所有命令.Height - e.Y))
        If a.Left <> Me.Left + (Me.Width - a.Width) - 7 Then a.Left = Me.Left + (Me.Width - a.Width) - 7
    End Sub

    Private Sub Label全部复制_Click(sender As Object, e As EventArgs) Handles Label全部复制.Click
        Clipboard.SetText(Me.RichTextBox4.Text)
    End Sub

    Private Sub 插入名称ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 插入名称ToolStripMenuItem.Click
        If Me.ListView4.SelectedItems.Count = 1 Then
            Me.RichTextBox3.Text = Me.RichTextBox3.Text.Insert(Me.RichTextBox3.SelectionStart, Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text)
        End If
    End Sub

    Private Sub 复制名称ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制名称ToolStripMenuItem.Click
        If Me.ListView4.SelectedItems.Count = 1 Then
            Clipboard.SetText(Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text)
        End If
    End Sub

    Private Sub 重命名ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重命名ToolStripMenuItem.Click
        If Me.ListView4.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim 模组路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text
        Select Case Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).SubItems(1).Text
            Case 获取动态多语言文本("data/DynamicText/Folder")
                Dim a As New InputTextDialog("", 获取动态多语言文本("data/DynamicText/ManageMod.18"), Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text)
                a.TranslateButtonText(获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel"))
返回1:
                Dim x As String = a.ShowDialog(Me)
                If x = "" Then Exit Sub
                If My.Computer.FileSystem.DirectoryExists(模组路径 & "\" & x) = True Then
                    Dim b As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.19"))
                    b.ShowDialog(Me)
                    GoTo 返回1
                Else
                    My.Computer.FileSystem.RenameDirectory(模组路径 & "\" & Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text, x)
                    Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text = x
                End If
            Case 获取动态多语言文本("data/DynamicText/File")
                Dim a As New InputTextDialog("", 获取动态多语言文本("data/DynamicText/ManageMod.18"), Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text)
                a.TranslateButtonText(获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel"))
返回2:
                Dim x As String = a.ShowDialog(Me)
                If x = "" Then Exit Sub
                If My.Computer.FileSystem.FileExists(模组路径 & "\" & x) = True Then
                    Dim b As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.19"))
                    b.ShowDialog(Me)
                    GoTo 返回2
                Else
                    My.Computer.FileSystem.RenameFile(模组路径 & "\" & Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text, x)
                    Me.ListView4.Items.Item(Me.ListView4.SelectedIndices(0)).Text = x
                End If
        End Select
    End Sub

    Private Sub 上移ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 上移ToolStripMenuItem.Click
        If ListView4.SelectedIndices.Count > 0 Then
            For i As Integer = 0 To ListView4.SelectedIndices.Count - 1
                Dim index As Integer = ListView4.SelectedIndices(i)
                If index > 0 Then
                    If ListView4.SelectedIndices.Contains(index - 1) Then
                        Continue For
                    End If
                    Dim tmp As ListViewItem = ListView4.Items(index)
                    ListView4.Items.RemoveAt(index)
                    ListView4.Items.Insert(index - 1, tmp)
                    ListView4.Items(index - 1).Focused = True
                End If
            Next
        End If
    End Sub

    Private Sub 下移ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 下移ToolStripMenuItem.Click
        If ListView4.SelectedIndices.Count > 0 Then
            For i As Integer = ListView4.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = ListView4.SelectedIndices(i)
                If index < ListView4.Items.Count - 1 Then
                    If ListView4.SelectedIndices.Contains(index + 1) Then
                        Continue For
                    End If
                    Dim tmp As ListViewItem = ListView4.Items(index)
                    ListView4.Items.RemoveAt(index)
                    ListView4.Items.Insert(index + 1, tmp)
                    ListView4.Items(index + 1).Focused = True
                End If
            Next
        End If
    End Sub

    Private Sub 提取压缩包ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 提取压缩包ToolStripMenuItem.Click

    End Sub

    Private Sub 拿出内容ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 拿出内容ToolStripMenuItem.Click

    End Sub

    Private Sub 内容套层ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 内容套层ToolStripMenuItem.Click

    End Sub

    Private Sub 删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除ToolStripMenuItem.Click
        If Me.ListView4.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        Dim i As Integer = 0
        Dim 模组路径 As String = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text
        Do Until i = Me.ListView4.Items.Count
            If Me.ListView4.Items.Item(i).Selected = True Then
                Select Case Me.ListView4.Items.Item(i).SubItems(1).Text
                    Case 获取动态多语言文本("data/DynamicText/Folder")
                        My.Computer.FileSystem.DeleteDirectory(模组路径 & "\" & Me.ListView4.Items.Item(i).Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                        Application.DoEvents()
                        Me.ListView4.Items.Item(i).Remove()
                        i -= 1
                    Case 获取动态多语言文本("data/DynamicText/File")
                        My.Computer.FileSystem.DeleteFile(模组路径 & "\" & Me.ListView4.Items.Item(i).Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                        Application.DoEvents()
                        Me.ListView4.Items.Item(i).Remove()
                        i -= 1
                End Select
            End If
            i += 1
        Loop
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        定时检查安装命令和项数据()
    End Sub

    Private Sub RichTextBox3_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox3.TextChanged

    End Sub

    Private Sub RichTextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox3.KeyDown
        Debug.Print(e.Alt.ToString)
    End Sub

    Private Sub RichTextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles RichTextBox3.KeyUp
        Debug.Print(e.Alt.ToString)
    End Sub

#End Region

#Region "链接菜单"
    Private Sub 访问链接ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 访问链接ToolStripMenuItem.Click
        Process.Start(ST1.点击的链接)
    End Sub

    Private Sub 复制链接ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制链接ToolStripMenuItem.Click
        Clipboard.SetText(ST1.点击的链接)
    End Sub
#End Region

#Region "启动项功能"

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ST1.是否已启动完毕 = False Then Exit Sub
        Dim temp As Process() = Process.GetProcessesByName("StardewModdingAPI")
        If temp.Count = 0 Then
            Select Case xml_Settings.SelectSingleNode("data/StartOptions").InnerText
                Case "1"
                    Me.LabelRunSMAPI.Text = "Run SMAPI"
                Case "2"
                    Me.LabelRunSMAPI.Text = "Run Steam"
                Case "3"
                    Me.LabelRunSMAPI.Text = "Run NCR"
                Case "4"
                    Me.LabelRunSMAPI.Text = "Shell Command"
            End Select

            'If My.Computer.FileSystem.FileExists(Path1.SMAPI日志文件夹路径 & "\SMAPI-crash.txt") = True Then
            '    'FormSMAPICrash.ShowDialog()
            'End If
        ElseIf temp.Count = 1 Then
            Me.LabelRunSMAPI.Text = "SMAPI Running"
        ElseIf temp.Count > 1 Then
            Me.LabelRunSMAPI.Text = temp.Count & " SMAPI s !!!"
        End If

    End Sub

    Private Sub LabelRunSMAPI_Click(sender As Object, e As EventArgs) Handles LabelRunSMAPI.Click
        Select Case xml_Settings.SelectSingleNode("data/StartOptions").InnerText
            Case "1"
                Dim a As New Process
                a.StartInfo.FileName = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\StardewModdingAPI.exe"
                a.StartInfo.WorkingDirectory = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText
                a.StartInfo.UseShellExecute = True
                a.Start()
            Case "2"
                'Dim a As New Process
                'a.StartInfo.FileName = "steam.exe"
                ''a.StartInfo.WorkingDirectory = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText
                'a.StartInfo.UseShellExecute = True
                'a.StartInfo.Arguments = "-applaunch 413150"
                'a.Start()
            Case "3"
                Dim a As New Process
                a.StartInfo.FileName = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Natural Color - Launcher.bat"
                a.StartInfo.WorkingDirectory = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText
                a.StartInfo.UseShellExecute = True
                a.Start()
            Case "4"
                Shell(xml_Settings.SelectSingleNode("data/UserStartOptions").InnerText, AppWinStyle.NormalFocus)
        End Select
    End Sub



#End Region

#Region "预览图菜单和预览图功能"

    Private Sub Label预览图菜单_Click(sender As Object, e As EventArgs) Handles Label预览图菜单.Click

    End Sub

    Private Sub Label预览图菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label预览图菜单.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                Dim mouseX As Integer = MousePosition.X
                Dim mouseY As Integer = MousePosition.Y
                Me.DCM13.DropShadowEnabled = True
                Me.DCM13.Show(mouseX - e.X, mouseY + (Me.Label预览图菜单.Height - e.Y) + 1)
        End Select
    End Sub

    Private Sub Label角落预览图菜单_Click(sender As Object, e As EventArgs) Handles Label角落预览图菜单.Click

    End Sub

    Private Sub Label角落预览图菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label角落预览图菜单.MouseDown
        Me.DCM13.DropShadowEnabled = False
        Me.DCM13.Show(MousePosition.X + (Me.Label角落预览图菜单.Width - e.X) - Me.DCM13.Width, MousePosition.Y - e.Y - Me.DCM13.Height - 1)
    End Sub

    Private Sub 文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 文件夹ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim str As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text
        If My.Computer.FileSystem.DirectoryExists(str & "\Screenshot") = True Then
            System.Diagnostics.Process.Start(str & "\Screenshot")
        Else
            Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DynamicText/ManageMod.20"))
            If a.ShowDialog(Me) = 0 Then
                My.Computer.FileSystem.CreateDirectory(str & "\Screenshot")
                System.Diagnostics.Process.Start(str & "\Screenshot")
            End If
        End If
    End Sub

    Private Sub 复制ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制ToolStripMenuItem.Click
        Clipboard.SetImage(Me.PictureBox1.Image)
    End Sub

    Private Sub 删除此图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除此图ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim str As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text
        If My.Computer.FileSystem.DirectoryExists(str & "\Screenshot") = True Then
            My.Computer.FileSystem.DeleteDirectory(str & "\Screenshot", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Me.PictureBox1.Image = Nothing
            Me.Panel预览图.Visible = False
        End If
    End Sub

    Private Sub 删除所有图ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除所有图ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Exit Sub
        End If
        Dim str As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text
        If 当前项信息_预览图文件表.Count < 1 Then Exit Sub
        If My.Computer.FileSystem.FileExists(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引)) = True Then
            My.Computer.FileSystem.DeleteFile(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Me.PictureBox1.Image = Nothing
            Me.Panel预览图.Visible = False
        End If
    End Sub

    Private Sub 缩放处理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 缩放处理ToolStripMenuItem.Click

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Select Case e.X / Me.PictureBox1.Width
            Case <= 0.15
                Me.PictureBox1.Cursor = Cursors.PanWest
            Case >= 0.85
                Me.PictureBox1.Cursor = Cursors.PanEast
            Case Else
                Me.PictureBox1.Cursor = Cursors.Default
        End Select
    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If e.Button = MouseButtons.Left Then
            Select Case Me.PictureBox1.Cursor
                Case Cursors.PanWest
                    Dim a As Integer = ST1.全局状态_当前正在显示的预览图索引 - 1
                    If a < 0 Then Exit Sub
                    ST1.全局状态_当前正在显示的预览图索引 -= 1
                    加载预览图(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引))
                    Me.ToolTip1.SetToolTip(Me.PictureBox1, ST1.全局状态_当前正在显示的预览图索引 + 1 & "/" & 当前项信息_预览图文件表.Count)
                Case Cursors.PanEast
                    Dim a As Integer = ST1.全局状态_当前正在显示的预览图索引 + 1
                    If a > 当前项信息_预览图文件表.Count - 1 Then Exit Sub
                    ST1.全局状态_当前正在显示的预览图索引 += 1
                    加载预览图(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引))
                    Me.ToolTip1.SetToolTip(Me.PictureBox1, ST1.全局状态_当前正在显示的预览图索引 + 1 & "/" & 当前项信息_预览图文件表.Count)
            End Select
        End If
    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Select Case Me.PictureBox1.Cursor
                Case Cursors.PanWest, Cursors.PanEast
                Case Else
                    Process.Start(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引))
            End Select
        End If
    End Sub

    Private Sub PictureBox1_MouseWheel(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseWheel
        Select Case e.Delta
            Case > 0
                Dim a As Integer = ST1.全局状态_当前正在显示的预览图索引 - 1
                If a < 0 Then Exit Sub
                ST1.全局状态_当前正在显示的预览图索引 -= 1
                加载预览图(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引))
                Me.ToolTip1.SetToolTip(Me.PictureBox1, ST1.全局状态_当前正在显示的预览图索引 + 1 & "/" & 当前项信息_预览图文件表.Count)
            Case < 0
                Dim a As Integer = ST1.全局状态_当前正在显示的预览图索引 + 1
                If a > 当前项信息_预览图文件表.Count - 1 Then Exit Sub
                ST1.全局状态_当前正在显示的预览图索引 += 1
                加载预览图(当前项信息_预览图文件表(ST1.全局状态_当前正在显示的预览图索引))
                Me.ToolTip1.SetToolTip(Me.PictureBox1, ST1.全局状态_当前正在显示的预览图索引 + 1 & "/" & 当前项信息_预览图文件表.Count)
        End Select
    End Sub
#End Region

#Region "内容中心"

    Private Sub StardewMUI5NEXUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StardewMUI5NEXUSToolStripMenuItem.Click
        Process.Start("https://www.nexusmods.com/stardewvalley/mods/12230")
    End Sub

    Private Sub 产品简体中文维基ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 产品简体中文维基ToolStripMenuItem.Click
        Process.Start("https://stardewmui.fandom.com/zh/wiki/StardewMUI_Wiki")
    End Sub

    Private Sub EnglishWikiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnglishWikiToolStripMenuItem.Click
        Process.Start("https://stardewmui.fandom.com/wiki/StardewMUI_Wiki")
    End Sub

    Private Sub 产品Gitee仓库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 产品Gitee仓库ToolStripMenuItem.Click
        Process.Start("https://gitee.com/Lake1059/StardewMUI-5")
    End Sub

    Private Sub 产品GitHub仓库ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 产品GitHub仓库ToolStripMenuItem.Click
        Process.Start("https://github.com/Lake1059/StardewMUI-5")
    End Sub

    Private Sub 欢迎赞助ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 欢迎赞助ToolStripMenuItem.Click
        Process.Start("https://afdian.net/@1059Studio")
    End Sub

    Private Sub SupportMeOnKofiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportMeOnKofiToolStripMenuItem.Click
        Process.Start("https://ko-fi.com/lake1059")
    End Sub

    Private Sub ContactMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContactMeToolStripMenuItem.Click
        Process.Start("mailto:vb1059@Outlook.com")
    End Sub

    Private Sub 开发者哔哩哔哩主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 开发者哔哩哔哩主页ToolStripMenuItem.Click
        Process.Start("https://space.bilibili.com/319785096")
    End Sub

    Private Sub 星露谷Steam商店页面ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 星露谷Steam商店页面ToolStripMenuItem.Click
        Process.Start("https://store.steampowered.com/app/413150/Stardew_Valley/")
    End Sub

    Private Sub StardewValleyOfficialWikiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StardewValleyOfficialWikiToolStripMenuItem.Click
        Process.Start("https://stardewvalleywiki.com/Stardew_Valley_Wiki")
    End Sub

    Private Sub StardewValleyNexusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StardewValleyNexusToolStripMenuItem.Click
        Process.Start("https://www.nexusmods.com/stardewvalley")
    End Sub

    Private Sub StardewValleyModDropToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StardewValleyModDropToolStripMenuItem.Click
        Process.Start("https://www.moddrop.com/stardew-valley/")
    End Sub

    Private Sub StardewValleyForumsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StardewValleyForumsToolStripMenuItem.Click
        Process.Start("https://forums.stardewvalley.net/")
    End Sub

    Private Sub SMAPI官网ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SMAPI官网ToolStripMenuItem.Click
        Process.Start("https://smapi.io")
    End Sub

    Private Sub 模组数据表ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 模组数据表ToolStripMenuItem.Click
        Process.Start("https://smapi.io/mods")
    End Sub

    Private Sub 日志分析器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 日志分析器ToolStripMenuItem.Click
        Process.Start("https://smapi.io/log")
    End Sub

    Private Sub 农场布局规划器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 农场布局规划器ToolStripMenuItem.Click
        Process.Start("https://stardew.info/")
    End Sub

    Private Sub 存档预测器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 存档预测器ToolStripMenuItem.Click
        Process.Start("https://mouseypounds.github.io/stardew-predictor")
    End Sub

    Private Sub 存档进度检查器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 存档进度检查器ToolStripMenuItem.Click
        Process.Start("https://mouseypounds.github.io/stardew-checkup")
    End Sub

    Private Sub 软件安装目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 软件安装目录ToolStripMenuItem.Click
        Process.Start(Application.StartupPath)
    End Sub

    Private Sub 用户配置数据文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 用户配置数据文件夹ToolStripMenuItem.Click
        Process.Start(Path1.应用程序用户数据路径)
    End Sub

    Private Sub 插件目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 插件目录ToolStripMenuItem.Click
        Process.Start(Path1.应用程序插件数据路径)
    End Sub

    Private Sub 下载更新目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 下载更新目录ToolStripMenuItem.Click
        Process.Start(IO.Path.GetDirectoryName(Path1.更新安装程序文件路径))
    End Sub

    Private Sub 谷歌浏览器缓存目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 谷歌浏览器缓存目录ToolStripMenuItem.Click
        Process.Start(Path1.应用程序用户数据路径 & "\WebCache")
    End Sub

    Private Sub 当前星露谷游戏目录ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 当前星露谷游戏目录ToolStripMenuItem.Click
        Process.Start(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
    End Sub

    Private Sub 星露谷Mods文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 星露谷Mods文件夹ToolStripMenuItem.Click
        Process.Start(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods")
    End Sub

    Private Sub 星露谷Content文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 星露谷Content文件夹ToolStripMenuItem.Click
        Process.Start(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Content")
    End Sub

    Private Sub 星露谷存档文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 星露谷存档文件夹ToolStripMenuItem.Click
        If FileIO.FileSystem.DirectoryExists(Path1.星露谷存档路径) = True Then Process.Start(Path1.星露谷存档路径)
    End Sub

    Private Sub SMAPI日志文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SMAPI日志文件夹ToolStripMenuItem.Click
        If FileIO.FileSystem.DirectoryExists(Path1.SMAPI日志文件夹路径) = True Then Process.Start(Path1.SMAPI日志文件夹路径)
    End Sub

    Private Sub 存储管理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 存储管理ToolStripMenuItem.Click
        显示窗体(Form存储管理, Me)
    End Sub

#End Region

#Region "在线模组列表功能"

    Private Sub 清除内容ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 清除内容ToolStripMenuItem.Click
        Me.Panel模组列表.Controls.Clear()
    End Sub

    Private Sub 最新的10个模组ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 最新的10个模组ToolStripMenuItem.Click
        获取模组列表并显示(Me.Panel模组列表, Windows.Nexus.NexusModsApiObject.ListModType.TheLatest10ModsReleased)
    End Sub

    Private Sub 最近更新的10个模组ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 最近更新的10个模组ToolStripMenuItem.Click
        获取模组列表并显示(Me.Panel模组列表, Windows.Nexus.NexusModsApiObject.ListModType.TheLatest10ModsUpdated)
    End Sub

    Private Sub 有史以来最热门的10个模组ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 有史以来最热门的10个模组ToolStripMenuItem.Click
        获取模组列表并显示(Me.Panel模组列表, Windows.Nexus.NexusModsApiObject.ListModType.The10EveryTimeHotMods)
    End Sub

#End Region

#Region "项右键菜单编辑器功能"

    Private Sub 重命名项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重命名项ToolStripMenuItem.Click
        If Me.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        For i = 0 To Me.ListView3.Items.Count - 1
            If 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) = Me.ListView3.Items.Item(i).Text Then
                If Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text = Me.ListView3.Items.Item(i).SubItems(1).Text Then
                    MsgBox(获取动态多语言文本("data/DynamicText/ManageMod.33"), MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        Next

        Dim a As New InputTextDialog("", 获取动态多语言文本("data/DynamicText/ManageMod.34") & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text, Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text)
nextline:
        Dim b As String = a.ShowDialog(Me)
        If b = "" Then Exit Sub
        Dim c As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\"
        If My.Computer.FileSystem.DirectoryExists(c & b) = True Then
            MsgBox(获取动态多语言文本("data/DynamicText/ManageMod.6"), MsgBoxStyle.Exclamation)
            GoTo nextline
        End If
        My.Computer.FileSystem.RenameDirectory(检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text, b)
        Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text = b
    End Sub

    Private Sub 用VisualStudioCode打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 用VisualStudioCode打开ToolStripMenuItem.Click
        If xml_Settings.SelectSingleNode("data/VisualStudioCodePath").InnerText = "" Then Exit Sub
        Shell("""" & xml_Settings.SelectSingleNode("data/VisualStudioCodePath").InnerText & """" & " " & """" & 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text & """", AppWinStyle.NormalFocus)
    End Sub

    Private Sub 用VisualStudio打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 用VisualStudio打开ToolStripMenuItem.Click
        If xml_Settings.SelectSingleNode("data/VisualStudioPath").InnerText = "" Then Exit Sub
        Shell("""" & xml_Settings.SelectSingleNode("data/VisualStudioPath").InnerText & """" & " " & """" & 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text & """", AppWinStyle.NormalFocus)
    End Sub

    Private Sub 用Notepad打开ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 用Notepad打开ToolStripMenuItem.Click
        If xml_Settings.SelectSingleNode("data/NotepadPath").InnerText = "" Then Exit Sub
        Shell("""" & xml_Settings.SelectSingleNode("data/NotepadPath").InnerText & """" & " " & """" & 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text & """", AppWinStyle.NormalFocus)
    End Sub

    Private Sub 可视化清单编辑器ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 可视化清单编辑器ToolStripMenuItem.Click

    End Sub

    Private Sub 简单编辑ConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 简单编辑ConfigToolStripMenuItem.Click

    End Sub

    Private Sub 清除Config缓存ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 清除Config缓存ToolStripMenuItem1.Click
        Dim a As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Me.ListView2.SelectedIndices(0)) & "\" & Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(0)).Text & "\.config"
        If My.Computer.FileSystem.DirectoryExists(a) = False Then Exit Sub
        My.Computer.FileSystem.DeleteDirectory(a, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
        MsgBox("Finish.")
    End Sub

#End Region

#Region "模组检查更新表"
    Private Sub 检查更新加入表中ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 检查更新加入表中ToolStripMenuItem.Click
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            模组检查更新_添加一个分类的数据到列表中(检查并返回当前所选子库路径(False) & "\" & Me.ListView1.Items(Me.ListView1.SelectedIndices(i)).Text)
        Next
    End Sub

    Private Sub 检查更新加入表中ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles 检查更新加入表中ToolStripMenuItem1.Click
        For i = 0 To Me.ListView2.SelectedItems.Count - 1
            模组检查更新_添加一个项的数据到列表中(检查并返回当前选择分类路径(False) & "\" & Me.ListView2.Items(Me.ListView2.SelectedIndices(i)).Text)
        Next
    End Sub
#End Region


    ReadOnly 分割线 As Integer = 0


End Class
