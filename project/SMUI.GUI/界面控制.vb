Imports SMUI.GUI.Class1

Module 界面控制

    Public Sub 启动时初始化界面()
        Form1.Panel起始页面.Dock = DockStyle.Fill
        Form1.Panel起始页面.BorderStyle = BorderStyle.None
        Form1.Panel管理模组.Dock = DockStyle.Fill
        Form1.Panel管理模组.BorderStyle = BorderStyle.None
        Form1.Panel配置队列.Dock = DockStyle.Fill
        Form1.Panel配置队列.BorderStyle = BorderStyle.None

        Form1.Panel新闻公告.Dock = DockStyle.Fill
        Form1.Panel新闻公告.BorderStyle = BorderStyle.None
        Form1.Panel模组列表.Dock = DockStyle.Fill
        Form1.Panel模组列表.BorderStyle = BorderStyle.None
        Form1.Panel下载模组.Dock = DockStyle.Fill
        Form1.Panel下载模组.BorderStyle = BorderStyle.None
        Form1.Panel主题内容.Dock = DockStyle.Fill
        Form1.Panel主题内容.BorderStyle = BorderStyle.None
        Form1.Panel创作者自由面板.Dock = DockStyle.Fill
        Form1.Panel创作者自由面板.BorderStyle = BorderStyle.None
        Form1.Panel更新历史以及关于和许可协议.Dock = DockStyle.Fill
        Form1.Panel更新历史以及关于和许可协议.BorderStyle = BorderStyle.None

        Form1.RichTextBox1.AutoWordSelection = False
        Form1.RichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Form1.RichTextBox1, 300)

        Form1.RichTextBox3.AutoWordSelection = False
        Form1.RichTextBox3.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Form1.RichTextBox3, 300)

        Form1.RichTextBox4.AutoWordSelection = False
        Form1.RichTextBox4.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Form1.RichTextBox4, 300)

        Form1.Panel起始页面.Visible = True
        Form1.Panel主选项卡.Left = (Form1.Panel主选项卡.Parent.Width - Form1.Panel主选项卡.Width) * 0.5
        Form1.Label主动态标记.Left = Form1.Panel主选项卡.Left
        Form1.Label分类计数显示.Parent = Form1.Label子库分类菜单
        Form1.Label预览图计数显示.Parent = Form1.Label预览图菜单

        'Application.DoEvents()
        Form1.ListView1.Width = Form1.Panel9.Width + ST1.系统滚动条宽度
        Form1.ListView2.Width = Form1.Panel11.Width - 5 '+ ST1.系统滚动条宽度

        Form1.RichTextBox1.Width = Form1.Panel10.Width + ST1.系统滚动条宽度
        Form1.RichTextBox1.Height = Form1.Label1.Height
        Form1.RichTextBox1.Location = Form1.Label1.Location
        Form1.RichTextBox1.RightMargin = Form1.RichTextBox1.Width - ST1.系统滚动条宽度 - 12


        Form1.ListView1.Columns.Item(0).Width = Form1.ListView1.Width - 5 - ST1.系统滚动条宽度

        Form1.ListView1.ForeColor = Color1.白色
        Form1.ListView2.ForeColor = Color1.白色
        Form1.RichTextBox1.ForeColor = Color1.白色
    End Sub

    Public Sub 校准RichTextBox1的尺寸和位置()
        Form1.RichTextBox1.Width = Form1.Panel10.Width + ST1.系统滚动条宽度
        Form1.RichTextBox1.Height = Form1.Label1.Height
        Form1.RichTextBox1.Location = Form1.Label1.Location
        Form1.RichTextBox1.RightMargin = Form1.RichTextBox1.Width - ST1.系统滚动条宽度 - 15
    End Sub

    Public Sub 校准RichTextBox3的尺寸和位置()
        Form1.RichTextBox3.Width = Form1.Panel17.Width + ST1.系统滚动条宽度 + 2
        Form1.RichTextBox3.Height = Form1.Label6.Height
        Form1.RichTextBox3.Location = Form1.Label6.Location
        Form1.RichTextBox3.RightMargin = Form1.RichTextBox3.Width - 17 + ST1.系统滚动条宽度
    End Sub
    Public Sub 校准RichTextBox4的尺寸和位置()
        Form1.RichTextBox4.Width = Form1.Panel18.Width + ST1.系统滚动条宽度 + 2
        Form1.RichTextBox4.Height = Form1.Label8.Height
        Form1.RichTextBox4.Location = Form1.Label8.Location
        Form1.RichTextBox4.RightMargin = Form1.RichTextBox4.Width - 17 + ST1.系统滚动条宽度
    End Sub

    Public Sub 调整配置队列选项卡界面()
        If ST1.是否已启动完毕 = False Then Exit Sub
        If Form1.WindowState = FormWindowState.Minimized Then Exit Sub
        Form1.Panel配置队列左上面板.Width = Form1.Panel配置队列左上面板.Parent.Width * 0.5
        Form1.Panel配置队列左下面板.Width = Form1.Panel配置队列左下面板.Parent.Width * 0.5
        Form1.Panel配置队列上方面板.Height = Form1.Panel配置队列.Height * 0.5 - Form1.Panel配置队列顶部面板.Height - 30
        Form1.ToolStripTextBox1.Width = 494

        Form1.ColumnHeader7.Width = Form1.ListView3.Width - Form1.ColumnHeader6.Width - 25
        Form1.ColumnHeader8.Width = Form1.ListView4.Width - Form1.ColumnHeader9.Width - 25
        校准RichTextBox3的尺寸和位置()
        校准RichTextBox4的尺寸和位置()
        ST1.是否已经初始化了配置队列选项卡界面 = True

    End Sub

    Public Sub 切换主选项卡按钮状态(哪个选项卡 As Integer)
        Form1.Label起始页面.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
        Form1.Label管理模组.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
        Form1.Label配置队列.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
        Select Case 哪个选项卡
            Case 1
                Form1.Label起始页面.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
            Case 2
                Form1.Label管理模组.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
            Case 3
                Form1.Label配置队列.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        End Select
    End Sub

    Public Sub 隐藏所有主选项卡()
        Form1.Panel起始页面.Visible = False
        Form1.Panel管理模组.Visible = False
        Form1.Panel配置队列.Visible = False
    End Sub

    Public Sub 切换起始页面内容选项卡按钮状态(sender As Object)
        Form1.Panel新闻公告.Visible = False
        Form1.Panel模组列表.Visible = False
        Form1.Panel下载模组.Visible = False
        Form1.Panel主题内容.Visible = False
        Form1.Panel创作者自由面板.Visible = False
        Form1.Panel更新历史以及关于和许可协议.Visible = False
        Form1.Label新闻公告.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Form1.Label模组列表.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Form1.Label下载模组.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Form1.Label主题内容.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Form1.Label创作者自由面板.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Form1.Label关于和许可协议.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Form1.Label查看更新历史.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        sender.BackColor = ColorTranslator.FromWin32(RGB(80, 80, 80))
    End Sub

    Public Sub 显示模式窗体(ByVal 哪个窗口 As Form, ByVal 以谁为基准显示 As Form)
        哪个窗口.Left = (以谁为基准显示.Width - 哪个窗口.Width) * 0.5 + 以谁为基准显示.Left
        哪个窗口.Top = (以谁为基准显示.Height - 哪个窗口.Height) * 0.5 + 以谁为基准显示.Top
        哪个窗口.ShowDialog(以谁为基准显示)
    End Sub

    Public Sub 显示窗体(ByVal 哪个窗口 As Form, ByVal 以谁为基准显示 As Form)
        If 哪个窗口.Visible = True Then
            哪个窗口.Focus()
            哪个窗口.Left = (以谁为基准显示.Width - 哪个窗口.Width) * 0.5 + 以谁为基准显示.Left
            哪个窗口.Top = (以谁为基准显示.Height - 哪个窗口.Height) * 0.5 + 以谁为基准显示.Top
        Else
            哪个窗口.Left = (以谁为基准显示.Width - 哪个窗口.Width) * 0.5 + 以谁为基准显示.Left
            哪个窗口.Top = (以谁为基准显示.Height - 哪个窗口.Height) * 0.5 + 以谁为基准显示.Top
            哪个窗口.Show(以谁为基准显示)
        End If
    End Sub

    Public Sub 调整项列表列宽(Optional 切换 As Boolean = False)
        If ST1.是否已启动完毕 = False Then Exit Sub
        If ST1.是否正在显示项的所属列 = False Then
            If 切换 = True Then
                ST1.是否正在显示项的所属列 = True
                Form1.ColumnHeader4.Width = 150
                Form1.ColumnHeader5.Width = 150
                Form1.ColumnHeader3.Width = 100
                Form1.ColumnHeader2.Width = Form1.ListView2.Parent.Width - 400 - 10 - ST1.系统滚动条宽度
            Else
                Form1.ColumnHeader5.Width = 0
                Form1.ColumnHeader4.Width = 150
                Form1.ColumnHeader3.Width = 100
                Form1.ColumnHeader2.Width = Form1.ListView2.Parent.Width - 250 - 10 - ST1.系统滚动条宽度
            End If
        Else
            If 切换 = True Then
                ST1.是否正在显示项的所属列 = False
                Form1.ColumnHeader5.Width = 0
                Form1.ColumnHeader4.Width = 150
                Form1.ColumnHeader3.Width = 100
                Form1.ColumnHeader2.Width = Form1.ListView2.Parent.Width - 250 - 10 - ST1.系统滚动条宽度
            Else
                Form1.ColumnHeader4.Width = 150
                Form1.ColumnHeader5.Width = 150
                Form1.ColumnHeader3.Width = 100
                Form1.ColumnHeader2.Width = Form1.ListView2.Parent.Width - 400 - 10 - ST1.系统滚动条宽度
            End If
        End If
    End Sub

    Sub 高DPI兼容处理控件(控件 As Control, 对齐方式 As DockStyle)
        Dim a As Integer
        控件.AutoSize = True
        a = 控件.Width
        控件.Dock = 对齐方式
        控件.AutoSize = False
        控件.Width = a + 20
    End Sub

    Public Sub 高DPI兼容处理_主界面()

        高DPI兼容处理控件(Form1.Label保存并从队列中移除, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label仅保存, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label移除配置队列中的项, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label移除配置队列里的全部项, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label刷新项的数据内容, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label添加文件, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label添加文件夹, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label全部复制, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label所有命令, DockStyle.Right)
        高DPI兼容处理控件(Form1.Label自动完成, DockStyle.Right)
    End Sub




End Module
