Imports System.IO
Imports SMUI.GUI.Class1
Imports System.Xml.Xsl
Imports System.ComponentModel

Public Class Form存储管理

    Function GetDirectoryLength(dirPath As String) As Long
        If Not Directory.Exists(dirPath) Then
            Return 0
        End If
        Dim len As Long = 0
        Dim di As New DirectoryInfo(dirPath)
        For Each fi As FileInfo In di.GetFiles()
            len += fi.Length
        Next
        Dim dis As DirectoryInfo() = di.GetDirectories()
        If dis.Length > 0 Then
            For i As Integer = 0 To dis.Length - 1
                len += GetDirectoryLength(dis(i).FullName)
            Next
        End If
        Return len
    End Function

    Function 转换字节数显示(字节数 As Long) As String
        If 字节数 = 0 Then
            Return 获取动态多语言文本("data/StorageManagementWindow/A3")
            Exit Function
        End If
        Dim a As Long = 字节数 / 1024
        If a < 1024 Then
            Return a & " KB"
        Else
            Return Format(a / 1024, "0.0") & " MB"
        End If
    End Function

    Sub 初始化显示()
        Me.D1.Text = 获取动态多语言文本("data/StorageManagementWindow/A1")
        Me.D2.Text = ""
        Me.D3.Text = ""
        Me.D4.Text = ""
        Me.D5.Text = ""
        Me.D6.Text = ""
        Me.D7.Text = ""
        Me.D8.Text = ""
        Me.D9.Text = ""
        Me.D10.Text = ""
        Me.D11.Text = ""
        Me.D12.Text = ""
        Me.D13.Text = ""
        Me.D14.Text = ""
        Me.D15.Text = ""
        Me.D16.Text = ""
    End Sub


    Private Sub Form存储管理_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Label1.Text = 获取动态多语言文本("data/StorageManagementWindow/S1")
            Me.Label2.Text = 获取动态多语言文本("data/StorageManagementWindow/S2")
            Me.Label3.Text = 获取动态多语言文本("data/StorageManagementWindow/S3")
            Me.Label4.Text = 获取动态多语言文本("data/StorageManagementWindow/S4")
            Me.Label5.Text = 获取动态多语言文本("data/StorageManagementWindow/S5")
            Me.Label6.Text = 获取动态多语言文本("data/StorageManagementWindow/S6")
            Me.Label7.Text = 获取动态多语言文本("data/StorageManagementWindow/S7")
            Me.Label8.Text = 获取动态多语言文本("data/StorageManagementWindow/S8")
            Me.Label10.Text = 获取动态多语言文本("data/StorageManagementWindow/S9")
            Me.Label11.Text = 获取动态多语言文本("data/StorageManagementWindow/S10")
            Me.Label12.Text = 获取动态多语言文本("data/StorageManagementWindow/S11")
            Me.Label13.Text = 获取动态多语言文本("data/StorageManagementWindow/S12")
            Me.Label14.Text = 获取动态多语言文本("data/StorageManagementWindow/S13")
            Me.Label15.Text = 获取动态多语言文本("data/StorageManagementWindow/S14")
            Me.Label16.Text = 获取动态多语言文本("data/StorageManagementWindow/S15")
            Me.Label17.Text = 获取动态多语言文本("data/StorageManagementWindow/S16")
            Me.DarkButton1.Text = 获取动态多语言文本("data/StorageManagementWindow/B1")
        End If
        初始化显示()
    End Sub
    Private Sub Form存储管理_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Me.BackgroundWorker1.ReportProgress(1, FileIO.FileSystem.GetFileInfo(Application.ExecutablePath).Length)
        On Error Resume Next
        Dim a As Long = 0
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\Lake1059.GitAPI.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\Lake1059.Internet.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\SMUI.Windows.Core.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\SMUI.Windows.Nexus.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\SMUI.Windows.PakManager.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\SMUI.Windows.SmapiWebAPI.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\WindowsMF.dll").Length
        Me.BackgroundWorker1.ReportProgress(2, a)
        a = 0
        a += GetDirectoryLength(Application.StartupPath & "\7za64")
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\7zFull64.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\BetterFolderBrowser.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\DarkUI.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\Imazen.WebP.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\libwebp.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\Microsoft.WindowsAPICodePack.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\Microsoft.WindowsAPICodePack.Shell.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\Newtonsoft.Json.dll").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\SevenZipSharp.dll").Length
        Me.BackgroundWorker1.ReportProgress(3, a)
        a = 0
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\updatehistory.rtf").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\updatehistory_old.rtf").Length
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\User License Agreement.rtf").Length
        Me.BackgroundWorker1.ReportProgress(4, a)
        a = 0
        a += GetDirectoryLength(Application.StartupPath & "\locales")
        If ST1.是否安装了谷歌浏览器组件 = True Then
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\CefSharp.BrowserSubprocess.Core.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\CefSharp.BrowserSubprocess.exe").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\CefSharp.Core.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\CefSharp.Core.Runtime.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\CefSharp.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\CefSharp.WinForms.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\chrome_100_percent.pak").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\chrome_200_percent.pak").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\chrome_elf.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\d3dcompiler_47.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\icudtl.dat").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\libcef.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\libEGL.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\libGLESv2.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\resources.pak").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\snapshot_blob.bin").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\v8_context_snapshot.bin").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\vk_swiftshader.dll").Length
            a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\vulkan-1.dll").Length
        End If
        Me.BackgroundWorker1.ReportProgress(5, a)
        a = 0
        Dim path114514 As String = Path1.应用程序用户数据路径 & "\WebCache"
        a += GetDirectoryLength(path114514 & "\Cache")
        a += GetDirectoryLength(path114514 & "\Service Worker")
        Me.BackgroundWorker1.ReportProgress(6, a)
        a = 0
        a += GetDirectoryLength(path114514 & "\Local Storage")
        a += GetDirectoryLength(path114514 & "\WebStorage")
        Me.BackgroundWorker1.ReportProgress(7, a)
        a = 0
        a += GetDirectoryLength(path114514 & "\Network")
        Me.BackgroundWorker1.ReportProgress(8, a)
        a = 0
        a += GetDirectoryLength(path114514 & "\GPUCache")
        Me.BackgroundWorker1.ReportProgress(9, a)
        a = 0
        a += FileIO.FileSystem.GetFileInfo(Application.StartupPath & "\debug.log").Length
        Me.BackgroundWorker1.ReportProgress(10, a)
        a = 0
        a += GetDirectoryLength(path114514 & "\databases")
        Me.BackgroundWorker1.ReportProgress(11, a)
        a = 0

        a += FileIO.FileSystem.GetFileInfo(Path1.应用程序用户数据路径 & "\Settings.xml").Length
        a += FileIO.FileSystem.GetFileInfo(Path1.应用程序用户数据路径 & "\Keys.dat").Length
        Me.BackgroundWorker1.ReportProgress(12, a)
        a = 0
        a += GetDirectoryLength(Path1.应用程序用户数据路径 & "\Update")
        Me.BackgroundWorker1.ReportProgress(13, a)
        a = 0
        a += GetDirectoryLength(Path1.临时自动下载路径)
        Me.BackgroundWorker1.ReportProgress(14, a)
        a = 0
        a += GetDirectoryLength(Path1.临时自动解压路径)
        Me.BackgroundWorker1.ReportProgress(15, a)
        a = 0
        a += GetDirectoryLength(Path1.应用程序插件数据路径)
        Me.BackgroundWorker1.ReportProgress(16, a)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                Me.D1.Text = 转换字节数显示(e.UserState)
            Case 2
                Me.D2.Text = 转换字节数显示(e.UserState)
            Case 3
                Me.D3.Text = 转换字节数显示(e.UserState)
            Case 4
                Me.D4.Text = 转换字节数显示(e.UserState)
            Case 5
                Me.D5.Text = 转换字节数显示(e.UserState)
            Case 6
                Me.D6.Text = 转换字节数显示(e.UserState)
            Case 7
                Me.D7.Text = 转换字节数显示(e.UserState)
            Case 8
                Me.D8.Text = 转换字节数显示(e.UserState)
            Case 9
                Me.D9.Text = 转换字节数显示(e.UserState)
            Case 10
                Me.D10.Text = 转换字节数显示(e.UserState)
            Case 11
                Me.D11.Text = 转换字节数显示(e.UserState)
            Case 12
                Me.D12.Text = 转换字节数显示(e.UserState)
            Case 13
                Me.D13.Text = 转换字节数显示(e.UserState)
            Case 14
                Me.D14.Text = 转换字节数显示(e.UserState)
            Case 15
                Me.D15.Text = 转换字节数显示(e.UserState)
            Case 16
                Me.D16.Text = 转换字节数显示(e.UserState)
        End Select
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        Dim path114514 As String = Path1.应用程序用户数据路径 & "\WebCache"
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\Cache", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\Service Worker", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D6.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        Dim path114514 As String = Path1.应用程序用户数据路径 & "\WebCache"
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\Local Storage", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\WebStorage", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D7.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        Dim path114514 As String = Path1.应用程序用户数据路径 & "\WebCache"
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\Network", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D8.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        Dim path114514 As String = Path1.应用程序用户数据路径 & "\WebCache"
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\GPUCache", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D9.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        My.Computer.FileSystem.DeleteDirectory(Application.StartupPath & "\debug.log", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D10.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        Dim path114514 As String = Path1.应用程序用户数据路径 & "\WebCache"
        My.Computer.FileSystem.DeleteDirectory(path114514 & "\databases", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D11.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        My.Computer.FileSystem.DeleteDirectory(Path1.应用程序用户数据路径 & "\Update", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D13.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        My.Computer.FileSystem.DeleteDirectory(Path1.临时自动下载路径, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D14.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        My.Computer.FileSystem.DeleteDirectory(Path1.临时自动解压路径, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D15.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        On Error Resume Next
        My.Computer.FileSystem.DeleteDirectory(Path1.应用程序用户数据路径 & "\WebCache", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        Me.D6.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
        Me.D7.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
        Me.D8.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
        Me.D9.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
        Me.D10.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
        Me.D11.Text = 获取动态多语言文本("data/StorageManagementWindow/A4")
    End Sub
End Class