Imports System.Xml

Public Class Class1

    ''' <summary>
    ''' 包含语言文件数据
    ''' </summary>
    Public Shared ReadOnly xml_lang As New XmlDocument
    ''' <summary>
    ''' 包含设置数据
    ''' </summary>
    Public Shared ReadOnly xml_Settings As New XmlDocument
    ''' <summary>
    ''' 表示最新版本的空设置文件，禁止在运行时修改
    ''' </summary>
    Public Shared ReadOnly xml_Settings_Lock As New XmlDocument


    ''' <summary>
    ''' 全局状态
    ''' </summary>
    Public Class ST1
        Public Shared 是否已启动完毕 As Boolean = False
        Public Shared 系统滚动条宽度 As Integer = SystemInformation.VerticalScrollBarWidth
        Public Shared 是否已经初始化了配置队列选项卡界面 As Boolean = False
        Public Shared 全局状态_是否正在下载更新 As Boolean = False
        Public Shared 全局状态_是否需要在退出后安装更新 As Boolean = False
        Public Shared 本次启动时候已经获取了新闻 As Boolean = False
        Public Shared 新闻容器背景图存储 As Image = Nothing
        Public Shared 当前用户身份组 As Security.Principal.WindowsBuiltInRole = Security.Principal.WindowsBuiltInRole.User
        Public Shared ReadOnly 需要替换为换行符的标记字符 As String = "/crlf/"
        Public Shared 打开了分类的菜单还是项的菜单 As Integer = 0
        Public Shared 是否正在显示项的所属列 As Boolean = False
        Public Shared 是否处于搜索筛选结果 As Boolean = False
        Public Shared 全局状态_当前正在显示的预览图索引 As Integer = 0
        Public Shared 点击的链接 As String = ""
        Public Shared 是否正在使用自定义语言包 As Boolean = False

        Public Shared NEXUS登录状态 As String = ""
        Public Shared 上次用的会员下载还是免费下载 As Integer = 1

        Public Shared 当前正在进行更新的单个项的N网ID As Integer = 0
        Public Shared 用于内置IE浏览器_当前正在更新模组 As Boolean = False
        Public Shared 用于内置IE浏览器_获取到的key As String = ""
        Public Shared 用于内置IE浏览器_获取到的expires As String = ""

    End Class

    ''' <summary>
    ''' 全局路径
    ''' </summary>
    Public Class Path1
        Shared ReadOnly wsh As New IWshRuntimeLibrary.IWshShell_Class
        Public Shared ReadOnly 桌面路径 As String = wsh.SpecialFolders.Item("Desktop")
        Public Shared ReadOnly AppDataRoaming As String = wsh.SpecialFolders.Item("AppData")
        Public Shared ReadOnly 星露谷存档路径 As String = wsh.SpecialFolders.Item("AppData") & "\StardewValley\Saves"
        Public Shared ReadOnly SMAPI日志文件夹路径 As String = wsh.SpecialFolders.Item("AppData") & "\StardewValley\ErrorLogs"
        Public Shared ReadOnly 应用程序用户数据路径 As String = "C:\Users\Public\1059 Studio\SMUI Client 5 Cache"
        Public Shared ReadOnly 更新安装程序文件路径 As String = "C:\Users\Public\1059 Studio\SMUI Client 5 Cache\Update\StardewMUI 5 Installer.exe"
        Public Shared ReadOnly 应用程序设置文件路径 As String = "C:\Users\Public\1059 Studio\SMUI Client 5 Cache\Settings.xml"
        Public Shared ReadOnly 开始菜单快捷方式路径 As String = wsh.SpecialFolders.Item("AppData") & "\Microsoft\Windows\Start Menu\Programs\StardewMUI 5\SMUI.GUI.lnk"
        Public Shared ReadOnly 桌面快捷方式路径 As String = wsh.SpecialFolders.Item("Desktop") & "\SMUI.GUI.lnk"
        Public Shared ReadOnly 应用程序插件数据路径 As String = "C:\Users\Public\1059 Studio\SMUI Client 5 Cache\Plugin"

        Public Shared ReadOnly 临时自动下载路径 As String = "C:\Users\Public\1059 Studio\SMUI Client 5 Cache\Download"
        Public Shared ReadOnly 临时自动解压路径 As String = "C:\Users\Public\1059 Studio\SMUI Client 5 Cache\Decompress"
    End Class

    ''' <summary>
    ''' 预定义颜色表
    ''' </summary>
    Public Class Color1
        Public Shared 白色 As Color = ColorTranslator.FromWin32(RGB(220, 220, 220))
        Public Shared 红色 As Color = ColorTranslator.FromWin32(RGB(255, 69, 0))
        Public Shared 橙色 As Color = ColorTranslator.FromWin32(RGB(255, 140, 0))
        Public Shared 黄色 As Color = ColorTranslator.FromWin32(RGB(240, 240, 0))
        Public Shared 绿色 As Color = ColorTranslator.FromWin32(RGB(50, 205, 50))
        Public Shared 青色 As Color = ColorTranslator.FromWin32(RGB(0, 230, 230))
        Public Shared 蓝色 As Color = ColorTranslator.FromWin32(RGB(0, 191, 255))
        Public Shared 紫色 As Color = ColorTranslator.FromWin32(RGB(238, 130, 238))
    End Class

    Public Class Font1
        Public Shared 粗体 As Font
        Public Shared 斜体 As Font
        Public Shared 下划线 As Font
        Public Shared 删除线 As Font
        Public Shared 粗体下划线 As Font
        Public Shared 粗体删除线 As Font
        Public Shared 斜体下划线 As Font
        Public Shared 斜体删除线 As Font
    End Class
End Class
