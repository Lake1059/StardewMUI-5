Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports SMUI.Windows.PakManager
Imports SMUI.GUI.Class1

Module Module2
    'Win32 API
    Public Declare Auto Function ReleaseCapture Lib "user32.dll" Alias "ReleaseCapture" () As Boolean
    Public Declare Auto Function SendMessage Lib "user32.dll" Alias "SendMessage" (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
    'Win32 Message
    Public Const WM_SYSCOMMAND As Integer = &H112&
    Public Const SC_MOVE As Integer = &HF010&
    Public Const HTCAPTION As Integer = &H2&

    Public Const WM_USER As Integer = &H400
    Public Const EM_GETPARAFORMAT As Integer = WM_USER + 61
    Public Const EM_SETPARAFORMAT As Integer = WM_USER + 71
    Public Const MAX_TAB_STOPS As Long = 32
    Public Const PFM_LINESPACING As UInteger = &H100

    <StructLayout(LayoutKind.Sequential)>
    Private Structure PARAFORMAT2
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Public rgxTabs As Integer()
        Public dySpaceBefore As Integer
        Public dySpaceAfter As Integer
        Public dyLineSpacing As Integer
        Public sStyle As Short
        Public bLineSpacingRule As Byte
        Public bOutlineLevel As Byte
        Public wShadingWeight As Short
        Public wShadingStyle As Short
        Public wNumberingStart As Short
        Public wNumberingStyle As Short
        Public wNumberingTab As Short
        Public wBorderSpace As Short
        Public wBorderWidth As Short
        Public wBorders As Short
    End Structure

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function SendMessage(hWnd As HandleRef, msg As Integer, wParam As Integer, ByRef lParam As PARAFORMAT2) As IntPtr
    End Function

    Public Sub 刷新标题栏主信息显示()
        Form1.Text = "StardewMUI 5 " & Application.ProductVersion

        Dim a As String
        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText) = False Then
            a = "Path Not Set"
            ST1.当前SMAPI版本号 = ""
        ElseIf My.Computer.FileSystem.FileExists(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\StardewModdingAPI.exe") = True Then
            Dim fv As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\StardewModdingAPI.exe")
            a = "SMAPI " & fv.ProductVersion
            ST1.当前SMAPI版本号 = fv.ProductVersion
        Else
            a = "No Install SMAPI"
            ST1.当前SMAPI版本号 = ""
        End If

        Dim b As String
        If My.Computer.FileSystem.FileExists(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Stardew Valley.exe") = True Then
            Dim fv2 As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Stardew Valley.exe")
            b = "Stardew Valley " & fv2.FileVersion
            ST1.当前星露谷版本号 = fv2.FileMajorPart & "." & fv2.FileMinorPart & "." & fv2.FileBuildPart
        Else
            b = "SDV Game Not Found"
            ST1.当前星露谷版本号 = ""
        End If

        Form1.Label5.Text = b & vbNewLine & a
    End Sub

    Public Sub 启动后自动登录NEXUSAPI()
        Form1.Label7.Text = ""
        Dim 启动时登录N网API后台线程 As New BackgroundWorker
        If My.Computer.Network.IsAvailable = False Then
            Form1.Label7.Text = ""
            Exit Sub
        End If
        If xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText = "" Then
            Form1.Label7.Text = 获取动态多语言文本("data/DynamicText/NotLogInNexusWebApi")
            Exit Sub
        End If
        AddHandler 启动时登录N网API后台线程.DoWork,
            Sub(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
                Dim a As New SMUI.Windows.Nexus.GetUserInfo With {
                    .ST_ApiKey = xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText
                }
                Dim x As String = a.StartGet
                If x <> "" Then
                    e.Result = 获取动态多语言文本("data/DynamicText/LogInFailed")
                Else
                    e.Result = 获取动态多语言文本("data/DynamicText/LoggedNexusWebApi") & vbNewLine & 获取动态多语言文本("data/DynamicText/UserName") & a.name
                End If
            End Sub
        AddHandler 启动时登录N网API后台线程.RunWorkerCompleted,
            Sub(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
                Form1.Label7.Text = e.Result
            End Sub
        启动时登录N网API后台线程.RunWorkerAsync()
    End Sub

    Public Sub 设置富文本框行高(ByVal RichTextBoxObject As Control, ByVal LineHeight As Integer)
        Dim fmt As New PARAFORMAT2()
        fmt.cbSize = Marshal.SizeOf(fmt)
        fmt.bLineSpacingRule = 4
        ' bLineSpacingRule
        fmt.dyLineSpacing = LineHeight
        fmt.dwMask = PFM_LINESPACING
        SendMessage(New HandleRef(RichTextBoxObject, RichTextBoxObject.Handle), EM_SETPARAFORMAT, 4, fmt)
    End Sub

    Public Function 计算文件数量(ByVal 路径 As String, Optional ByVal 子目录 As Boolean = False) As Integer
        Dim totalFile As Integer = 0
        Dim dirInfo As New System.IO.DirectoryInfo(路径)
        totalFile += dirInfo.GetFiles().Length
        If 子目录 = True Then
            For Each subdir As System.IO.DirectoryInfo In dirInfo.GetDirectories()
                totalFile += 计算文件数量(subdir.FullName, True)
            Next
        End If
        Return totalFile
    End Function

    Public Function 计算文件夹大小(ByVal 路径 As String, Optional ByVal 子目录 As Boolean = True) As Long
        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objDir As New DirectoryInfo(路径)
        Dim objSubFolder As DirectoryInfo
        Try
            For Each objFileInfo In objDir.GetFiles()
                lngDirSize += objFileInfo.Length
            Next
            If 子目录 Then
                For Each objSubFolder In objDir.GetDirectories()
                    lngDirSize += 计算文件夹大小(objSubFolder.FullName)
                Next
            End If
        Catch Ex As Exception
            Ex.ToString()
        End Try
        Return lngDirSize
    End Function

    Public Sub 添加调试文本(ByVal 文本 As String, ByVal 颜色 As Color)
        Dim a As String = "[" & Now.TimeOfDay.Hours & ":" & Now.TimeOfDay.Minutes & ":" & Now.TimeOfDay.Seconds & "] " & 文本
        Form调试.RichTextBox1.AppendText(vbNewLine & a)
        Form调试.RichTextBox1.Select(Form调试.RichTextBox1.TextLength - a.Length, a.Length)
        Form调试.RichTextBox1.SelectionColor = 颜色
        Form调试.RichTextBox1.Select(Form调试.RichTextBox1.TextLength, 0)
        Form调试.RichTextBox1.ScrollToCaret()
    End Sub

    Public Sub 创建快捷方式(ByVal 目标文件 As String, ByVal 图标路径 As String, ByVal 快捷方式位置 As String, Optional 描述 As String = "")
        Dim shell As New IWshRuntimeLibrary.WshShell()
        Dim shortcut As IWshRuntimeLibrary.IWshShortcut = CType(shell.CreateShortcut(快捷方式位置), IWshRuntimeLibrary.IWshShortcut)
        shortcut.TargetPath = 目标文件
        shortcut.WorkingDirectory = IO.Path.GetDirectoryName(目标文件)
        shortcut.Description = 描述
        shortcut.IconLocation = 图标路径
        shortcut.Save()
    End Sub

    Public Function 获取动态多语言文本(节点路径 As String) As String
        Try
            If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "Chinese" And ST1.是否正在使用自定义语言包 = False Then
                Return xml_lang.SelectSingleNode(节点路径).Attributes("chs").Value
            Else
                Return xml_lang.SelectSingleNode(节点路径).InnerText.Replace("/crlf/", vbNewLine)
            End If
        Catch ex As Exception
            Return "Missing language xml node: " & 节点路径
        End Try

    End Function


    Public Function 检查并返回当前选择分类路径(Optional 显示不可用对话框 As Boolean = True) As String
        Dim a As String = 检查并返回当前所选子库路径(显示不可用对话框)
        If a = "" Then
            Return "" : Exit Function
        Else
            If Form1.ListView1.SelectedItems.Count = 1 Then
                Return a & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(0)).Text
            Else
                If 显示不可用对话框 = False Then Return "" : Exit Function
                Dim d1 As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.3"))
                d1.ShowDialog(Form1)
                Return ""
            End If
        End If
    End Function

    Public Function 检查并返回当前所选子库路径(Optional 显示不可用对话框 As Boolean = True) As String
        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText) = False Then
            If 显示不可用对话框 = False Then Return "" : Exit Function
            Dim d1 As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.1"))
            d1.ShowDialog(Form1)
            Return ""
            Exit Function
        End If
        If xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText = "" Then
            If 显示不可用对话框 = False Then Return "" : Exit Function
            Dim d1 As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.2"))
            d1.ShowDialog(Form1)
            Return ""
            Exit Function
        End If
        Return xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText
    End Function

    Public Function 检查并返回当前模组数据仓库路径(Optional 显示不可用对话框 As Boolean = True) As String
        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText) = False Then
            If 显示不可用对话框 = False Then Return "" : Exit Function
            Dim d1 As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.1"))
            d1.ShowDialog(Form1)
            Return ""
        Else
            Return xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText
        End If
    End Function


    Public Sub 点击文档中的链接时触发(链接 As String)
        ST1.点击的链接 = 链接
        Form1.访问链接ToolStripMenuItem.Text = 获取动态多语言文本("data/DynamicText/GoToLink") '& ST1.点击的链接
        Form1.复制链接ToolStripMenuItem.Text = 获取动态多语言文本("data/DynamicText/CopyLink") '& ST1.点击的链接
    End Sub



End Module
