Imports System.ComponentModel
Imports System.Threading
Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form直接联网更新单个项

    Public 当前正在进行更新的单个项的N网ID As Integer
    Public 当前正在进行更新的单个项路径 As String = ""
    Public 当前正在进行直接更新的操作类型 As 在线更新操作类型
    Public 当前正在进行新建项的项名称 As String = ""
    Public 当前正在进行新建项的目标分类 As String = ""

    Public 这份进程正在使用的临时解压目录 As String = Path1.临时自动解压路径 & "\" & Now.Hour & Now.Minute & Now.Second & Now.Millisecond
    Private Sub Form直接联网更新单个项_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If 当前正在进行更新的单个项的N网ID = 12230 Then
            MsgBox("不准用来操作 12230 号页面，没有这种操作！" & vbNewLine & vbNewLine & "Not allowed to operate 12230, there is no such operation!", MsgBoxStyle.Exclamation, "不要在酒吧里点炒饭")
            Me.Close()
        End If

        Select Case 当前正在进行直接更新的操作类型
            Case 在线更新操作类型.更新项
                Me.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/Title") & " - " & 当前正在进行更新的单个项的N网ID & " - " & IO.Path.GetFileName(当前正在进行更新的单个项路径)
            Case 在线更新操作类型.新建项
                Me.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/Title2") & " - " & 当前正在进行更新的单个项的N网ID & " - " & IO.Path.GetFileName(当前正在进行新建项的项名称)
        End Select

        Me.Panel2.BorderStyle = BorderStyle.None : Me.Panel3.BorderStyle = BorderStyle.None
        Me.Panel2.Dock = DockStyle.Fill : Me.Panel3.Dock = DockStyle.Fill
        Me.Panel2.Visible = True
        Me.Label2.Width = 0

    End Sub

    Private Sub Form直接联网更新单个项_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S1")
        If xml_Settings.SelectSingleNode("data/LastUsed_DirectDownloadItemUpdateUserMember").InnerText = "True" Then
            Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5")
        Else
            Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A6")
        End If

        Me.Panel2.Controls.Clear()
        Application.DoEvents()
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Form直接联网更新单个项_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = False
        On Error Resume Next
        是否终止下载 = True
        Me.BackgroundWorker1.CancelAsync()
        Me.BackgroundWorker2.CancelAsync()
        Me.BackgroundWorker3.CancelAsync()
        Me.BackgroundWorker4.CancelAsync()
        Me.BackgroundWorker5.CancelAsync()
    End Sub

    Private Sub Form直接联网更新单个项_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose(True)
    End Sub

    Private Sub Form直接联网更新单个项_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        调整下载界面内容()
    End Sub

    Sub 调整下载界面内容()
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.Panel4.Left = (Me.Panel4.Parent.Width - Me.Panel4.Width) / 2
        Me.Panel4.Top = (Me.Panel4.Parent.Height - Me.Panel4.Height) / 2
        Me.Label5.Left = Me.Panel4.Left
        Me.Label5.Top = Me.Panel4.Top - Me.Label5.Height
        Me.Label3.Left = Me.Panel4.Left
        Me.Label3.Top = Me.Panel4.Top + Me.Panel4.Height
    End Sub


    ReadOnly a As New SMUI.Windows.Nexus.GetModFileList With {
            .ST_ApiKey = xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText
        }

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        e.Result = a.StartGet("stardewvalley", 当前正在进行更新的单个项的N网ID, SMUI.Windows.Nexus.NexusModsApiObject.FileType.main_optional)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Result <> "" Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
            MsgBox(e.Result, MsgBoxStyle.Critical, "BGW1_Completed")
            Exit Sub
        End If

        Dim 主要文件标题 As New Label With {.AutoSize = False, .Font = New Font("Microsoft YaHei UI", 13, FontStyle.Bold), .Text = "   " & 获取动态多语言文本("data/DynamicText/mainFile"), .Height = 50, .TextAlign = ContentAlignment.MiddleLeft, .Dock = DockStyle.Top}
        Me.Panel2.Controls.Add(主要文件标题)
        主要文件标题.BringToFront()
        For i = a.category_name.Count - 1 To 0 Step -1
            If a.category_name(i).ToLower = "main" Then
                生成文件列表(a, i)
            End If
        Next
        Dim 可选文件标题 As New Label With {.AutoSize = False, .Font = New Font("Microsoft YaHei UI", 13, FontStyle.Bold), .Text = "   " & 获取动态多语言文本("data/DynamicText/optionalFiles"), .Height = 50, .TextAlign = ContentAlignment.MiddleLeft, .Dock = DockStyle.Top}
        Me.Panel2.Controls.Add(可选文件标题)
        可选文件标题.BringToFront()
        For i = a.category_name.Count - 1 To 0 Step -1
            If a.category_name(i).ToLower = "optional" Then
                生成文件列表(a, i)
            End If
        Next
        'Dim 其他文件标题 As New Label With {.AutoSize = False, .Font = New Font("Microsoft YaHei UI", 13, FontStyle.Bold), .Text = "   Miscellaneous", .Height = 50, .TextAlign = ContentAlignment.MiddleLeft, .Dock = DockStyle.Top}
        'Me.Panel2.Controls.Add(其他文件标题)
        '其他文件标题.BringToFront()
        'For i = a.category_name.Count - 1 To 0 Step -1
        '    If a.category_name(i).ToLower = "miscellaneous" Then
        '        生成文件列表(a, i)
        '    End If
        'Next
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
    End Sub

    Private Sub 生成文件列表(ByVal a As SMUI.Windows.Nexus.GetModFileList, ByVal i As Integer)
        Dim 独立容器 As New Panel With {.Dock = DockStyle.Top, .Padding = New Padding(30, 5, 30, 5), .Height = 100}
        Dim 标题文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 25, .TextAlign = ContentAlignment.TopLeft, .Font = New Font("等线", 14, FontStyle.Bold), .LinkColor = Color1.绿色, .LinkBehavior = LinkBehavior.HoverUnderline, .Text = a.name(i)}
        Dim 状态文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 20, .TextAlign = ContentAlignment.TopLeft, .Font = New Font("Yu Gothic", 11.25, FontStyle.Bold), .ForeColor = ColorTranslator.FromWin32(RGB(218, 142, 53))}
        Dim 简介文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Fill, .Font = New Font("Microsoft YaHei UI", 10), .TextAlign = ContentAlignment.TopLeft, .ForeColor = Color.Gray, .AutoEllipsis = True, .Text = a.description(i).Replace("<br/>", vbNewLine)}

        If a.size_kb(i) < 1024 Then
            状态文字.Text = "Ver " & a.version(i) & " | " & a.size_kb(i) & "KB | " & a.uploaded_time(i) & " | ID " & a.file_id(i)
        Else
            状态文字.Text = "Ver " & a.version(i) & " | " & Format(a.size_kb(i) / 1024, "0.0") & "MB | " & a.uploaded_time(i) & " | ID " & a.file_id(i)
        End If

        AddHandler 标题文字.LinkClicked,
            Sub()
                选定下载文件的ID = a.file_id(i)

                Dim x1 = a.name(i)
                选定下载的文件 = x1
                Dim x2 = a.version(i)
                选定下载的文件版本 = x2
                If Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5") Then
                    Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S3")
                    Me.BackgroundWorker2.RunWorkerAsync()
                ElseIf Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A6") Then
                    Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S13")
                    If ST1.是否安装了谷歌浏览器组件 = True And ST1.用于内置谷歌浏览器_是否已经初始化 = False Then
                        初始化谷歌浏览器组件() : ST1.用于内置谷歌浏览器_是否已经初始化 = True
                    End If
                    If ChromiumBrowser.Visible = False Then ChromiumBrowser.Show(Form1)
                    ChromiumBrowser.浏览器窗口内_需要回调给哪个更新模组窗口 = Me
                    ChromiumBrowser.ChromiumWebBrowser1.LoadUrl("https://www.nexusmods.com/stardewvalley/mods/" & 当前正在进行更新的单个项的N网ID & "?tab=files&file_id=" & 选定下载文件的ID & "&nmm=1")
                    ST1.用于内置谷歌浏览器_当前正在更新模组 = True
                End If
            End Sub

        Dim 分隔间距 As New Label With {.AutoSize = False, .Dock = DockStyle.Left, .Width = 5}
        独立容器.Controls.Add(分隔间距)
        独立容器.Controls.Add(标题文字)
        独立容器.Controls.Add(状态文字)
        独立容器.Controls.Add(简介文字)
        分隔间距.SendToBack()
        状态文字.BringToFront()
        简介文字.BringToFront()
        Me.Panel2.Controls.Add(独立容器)
        独立容器.BringToFront()
    End Sub

    Dim 选定下载的文件 As String = ""
    Dim 选定下载的文件版本 As String = ""
    Dim 选定下载文件的ID As Integer

    ReadOnly b As New SMUI.Windows.Nexus.GetModFileDownloadURL With {
           .ST_ApiKey = xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText
       }

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Select Case xml_Settings.SelectSingleNode("data/LastUsed_DirectDownloadItemUpdateUserMember").InnerText.ToLower
            Case "true"
                e.Result = b.StartGet("stardewvalley", 当前正在进行更新的单个项的N网ID, 选定下载文件的ID)
            Case "false"
                e.Result = b.StartGet("stardewvalley", 当前正在进行更新的单个项的N网ID, 选定下载文件的ID, ST1.用于内置谷歌浏览器_获取到的key, ST1.用于内置谷歌浏览器_获取到的expires)
        End Select
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        If e.Result <> "" Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
            MsgBox(e.Result, MsgBoxStyle.Critical, "BGW2")
            Exit Sub
        End If

        Dim 选项数组 As String() = {}
        Dim 下载地址数组 As String() = {}
        For i = 0 To b.name.Count - 1
            ReDim Preserve 选项数组(选项数组.Count)
            选项数组(选项数组.Count - 1) = b.name(i)
            ReDim Preserve 下载地址数组(下载地址数组.Count)
            下载地址数组(下载地址数组.Count - 1) = b.URI(i)
        Next
        Dim k1 As Integer = 0
        If xml_Settings.SelectSingleNode("data/AutoSelectFirstNexusDownloadServer").InnerText.ToLower = "true" Then
            k1 = 0
            GoTo 自动选择转到行
        End If

        Dim dig1 As New SingleSelectionDialog(获取动态多语言文本("data/DirectOnlineUpdateWindow/S6"), 选项数组, 获取动态多语言文本("data/DirectOnlineUpdateWindow/S7"), 100, 500)
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S6")
        k1 = dig1.ShowDialog(Me)
自动选择转到行:
        If k1 <> -1 Then
            确认的下载地址 = b.URI(k1)
            If My.Computer.FileSystem.DirectoryExists(Path1.临时自动下载路径) = False Then
                My.Computer.FileSystem.CreateDirectory(Path1.临时自动下载路径)
            End If
            保存位置 = Path1.临时自动下载路径 & "\" & 当前正在进行更新的单个项的N网ID & "-" & 选定下载的文件 & "-" & 选定下载的文件版本 & ".zip"
            Me.Panel2.Visible = False
            Me.Panel3.Visible = True
            调整下载界面内容()
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S8")
            Me.Timer1.Enabled = True
            Me.BackgroundWorker3.RunWorkerAsync()
        Else
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
        End If
    End Sub

    Dim 确认的下载地址 As String = ""

    Dim 保存位置 As String = ""
    Dim 已下载字节数 As Long = 0
    Dim 总字节数 As Long = 0
    Dim 是否终止下载 As Boolean = False
    Dim 上一秒的已下载字节数 As Long = 0
    Dim 下载服务器返回的标头信息 As New Net.WebHeaderCollection

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        e.Result = Lake1059.Internet.下载文件.DownloadFileFromNexus(确认的下载地址, 保存位置, 已下载字节数, 总字节数, 是否终止下载, 下载服务器返回的标头信息)
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        Me.Timer1.Enabled = False
        Me.Label3.Text = ""
        Me.Label5.Text = ""
        Me.Label2.Width = Me.Label2.Parent.Width
        If e.Result <> "" Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
            MsgBox(e.Result, MsgBoxStyle.Critical, "BGW3")
            Me.Panel2.Visible = True
            Me.Panel3.Visible = False
            Exit Sub
        End If

        Select Case IO.Path.GetExtension(保存位置).ToLower
            Case ".zip", ".7z"
            Case ".rar"
                Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
                MsgBox(获取动态多语言文本("data/DirectOnlineUpdateWindow/S19"), MsgBoxStyle.Critical, "BGW3_Completed")
                Me.Panel2.Visible = True
                Me.Panel3.Visible = False
                Exit Sub
            Case Else
                Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
                MsgBox(获取动态多语言文本("data/DirectOnlineUpdateWindow/S18") & IO.Path.GetExtension(保存位置).ToLower, MsgBoxStyle.Critical, "BGW3_Completed")
                Me.Panel2.Visible = True
                Me.Panel3.Visible = False
                Exit Sub
        End Select

        If My.Computer.FileSystem.DirectoryExists(这份进程正在使用的临时解压目录) = True Then
            My.Computer.FileSystem.DeleteDirectory(这份进程正在使用的临时解压目录, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(这份进程正在使用的临时解压目录)
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S9")
        Me.BackgroundWorker4.RunWorkerAsync()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If 总字节数 = 0 Then Exit Sub
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Me.Timer1.Enabled = False
            Exit Sub
        End If
        If Format(已下载字节数 / 1024, "0") < 1024 Then
            Me.Label3.Text = Format(已下载字节数 / 1024, "0") & " KB / " & Format(总字节数 / 1024, "0") & " KB"
        Else
            Me.Label3.Text = Format(已下载字节数 / 1024 / 1024, "0.0") & " MB / " & Format(总字节数 / 1024 / 1024, "0.0") & " MB"
        End If
        If 已下载字节数 - 上一秒的已下载字节数 > 0 Then
            If Format((已下载字节数 - 上一秒的已下载字节数) / 1024, "0") > 1024 Then
                Me.Label3.Text &= "   " & Format((已下载字节数 - 上一秒的已下载字节数) / 1024 / 1024, "0.0") & " MB/S"
            Else
                Me.Label3.Text &= "   " & Format((已下载字节数 - 上一秒的已下载字节数) / 1024, "0") & " KB/S"
            End If
        End If

        Me.Label5.Text = Format((已下载字节数 / 总字节数) * 100, "0.0") & "%"
        Me.Label2.Width = 已下载字节数 / 总字节数 * Me.Label2.Parent.Width

        上一秒的已下载字节数 = 已下载字节数
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Me.Timer1.Enabled = False
        End If
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Try
            Dim zip1 As New SevenZip.SevenZipExtractor(保存位置)
            For i As Integer = 0 To zip1.ArchiveFileData.Count - 1
                zip1.ExtractFiles(这份进程正在使用的临时解压目录 & "\", zip1.ArchiveFileData(i).Index)
            Next
            zip1.Dispose()
            e.Result = ""
        Catch ex As Exception
            e.Result = ex.Message
        End Try
    End Sub

    Private Sub BackgroundWorker4_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        If e.Result <> "" Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
            MsgBox(e.Result, MsgBoxStyle.Critical, "BGW4")
            Me.Panel2.Visible = True
            Me.Panel3.Visible = False
            Exit Sub
        End If
        '开始评估
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S10")
        Application.DoEvents()

        Dim 解压出的文件夹列表 As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(这份进程正在使用的临时解压目录)
        Dim 单层套娃兼容后_解压出的文件夹列表 As String() = {}
        Dim 实际解压路径算起位置 As String = ""
        If 解压出的文件夹列表.Count = 1 And My.Computer.FileSystem.FileExists(这份进程正在使用的临时解压目录 & "\" & 解压出的文件夹列表(0) & "\manifest.json") = False Then
            单层套娃兼容后_解压出的文件夹列表 = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(这份进程正在使用的临时解压目录 & "\" & 解压出的文件夹列表(0))
            实际解压路径算起位置 = 这份进程正在使用的临时解压目录 & "\" & 解压出的文件夹列表(0)
        Else
            实际解压路径算起位置 = 这份进程正在使用的临时解压目录
        End If

        Select Case 当前正在进行直接更新的操作类型
            Case 在线更新操作类型.更新项

                Dim 纯文本安装命令_检测控制命令用 As String = My.Computer.FileSystem.ReadAllText(当前正在进行更新的单个项路径 & "\Code").Replace(" ", "").ToUpper
                Dim myItemCode As New SMUI.Windows.Core.TaskQueue With {.ItemPath = 当前正在进行更新的单个项路径}
                myItemCode.LoadCode()

                Dim 准备处理的文件夹列表 As String() = {}
                If 单层套娃兼容后_解压出的文件夹列表.Count = 0 Then
                    准备处理的文件夹列表 = 解压出的文件夹列表
                Else
                    准备处理的文件夹列表 = 单层套娃兼容后_解压出的文件夹列表
                End If
                Dim CDCD计数 As Integer = 0
                For i = 0 To myItemCode.Task_Code.Count - 1
                    Select Case myItemCode.Task_Code(i)
                        Case SMUI.Windows.Core.Objects.CDTask.CDCD
                            CDCD计数 += 1
                            If My.Computer.FileSystem.DirectoryExists(实际解压路径算起位置 & "\" & myItemCode.Task_Parameter1(i)) = False Then
                                更新项评估不通过操作()
                                添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A1"), Color1.黄色)
                                Exit Sub
                            End If
                            If My.Computer.FileSystem.FileExists(实际解压路径算起位置 & "\" & myItemCode.Task_Parameter1(i) & "\manifest.json") = False Then
                                If InStr(纯文本安装命令_检测控制命令用, "CR-CDS-CDCD-AMD") > 0 Then Continue For
                                更新项评估不通过操作()
                                添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A2"), Color1.黄色)
                                Exit Sub
                            End If
                        Case Windows.Core.Objects.CDTask.CDMAD
                            CDCD计数 += 1   '也算
                            If My.Computer.FileSystem.DirectoryExists(实际解压路径算起位置 & "\" & myItemCode.Task_Parameter1(i)) = False Then
                                更新项评估不通过操作()
                                添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A1"), Color1.黄色)
                                Exit Sub
                            End If
                            If My.Computer.FileSystem.FileExists(实际解压路径算起位置 & "\" & myItemCode.Task_Parameter1(i) & "\manifest.json") = True Then
                                更新项评估不通过操作()
                                添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A10"), Color1.黄色)
                                Exit Sub
                            End If
                        Case SMUI.Windows.Core.Objects.CDTask.CDGCD, SMUI.Windows.Core.Objects.CDTask.CDGCF, SMUI.Windows.Core.Objects.CDTask.CDGRF, SMUI.Windows.Core.Objects.CDTask.CDVD, SMUI.Windows.Core.Objects.CDTask.CDF
                            更新项评估不通过操作()
                            添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A3"), Color1.黄色)
                            Exit Sub
                    End Select
                Next
                If CDCD计数 <> 准备处理的文件夹列表.Count Then
                    更新项评估不通过操作()
                    添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A4"), Color1.黄色)
                    Exit Sub
                End If
                Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S_10_1")
                Application.DoEvents()

                For i = 0 To myItemCode.Task_Code.Count - 1
                    Select Case myItemCode.Task_Code(i)
                        Case SMUI.Windows.Core.Objects.CDTask.CDCD, Windows.Core.Objects.CDTask.CDMAD
                            If My.Computer.FileSystem.DirectoryExists(myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i)) = True Then
                                My.Computer.FileSystem.DeleteDirectory(myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i), FileIO.DeleteDirectoryOption.DeleteAllContents)
                            End If
                            My.Computer.FileSystem.CopyDirectory(实际解压路径算起位置 & "\" & myItemCode.Task_Parameter1(i), myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i), True)
                            'Case Windows.Core.Objects.CDTask.CDGCF, Windows.Core.Objects.CDTask.CDGRF, Windows.Core.Objects.CDTask.CDF
                            '    If My.Computer.FileSystem.FileExists(myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i)) = True Then
                            '        My.Computer.FileSystem.DeleteFile(myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
                            '    End If
                            '    My.Computer.FileSystem.CopyFile(实际解压路径算起位置 & "\" & myItemCode.Task_Parameter1(i), myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i), True)
                    End Select
                Next
                Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S11")
                Application.DoEvents()
                TimerSleep.Sleep(1500)

            Case 在线更新操作类型.新建项

                Dim 自动编写的安装命令 As String = ""
                Dim 准备处理的文件夹列表 As String() = {}
                If 单层套娃兼容后_解压出的文件夹列表.Count = 0 Then
                    准备处理的文件夹列表 = 解压出的文件夹列表
                Else
                    准备处理的文件夹列表 = 单层套娃兼容后_解压出的文件夹列表
                End If

                Dim 新建项完整路径 As String = 检查并返回当前所选子库路径(False) & "\" & 当前正在进行新建项的目标分类 & "\" & 当前正在进行新建项的项名称
                If My.Computer.FileSystem.DirectoryExists(新建项完整路径) = False Then
                    My.Computer.FileSystem.CreateDirectory(新建项完整路径)
                End If

                Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S17")
                Application.DoEvents()

                For i = 0 To 准备处理的文件夹列表.Count - 1
                    My.Computer.FileSystem.MoveDirectory(实际解压路径算起位置 & "\" & 准备处理的文件夹列表(i), 新建项完整路径 & "\" & 准备处理的文件夹列表(i), True)
                Next
                Dim 文件 As System.IO.FileInfo
                Dim 目录 As New System.IO.DirectoryInfo(实际解压路径算起位置)
                For Each 文件 In 目录.GetFiles("*.*")
                    My.Computer.FileSystem.MoveFile(实际解压路径算起位置 & "\" & 文件.Name, 新建项完整路径 & "\" & 文件.Name, True)
                Next


                If 准备处理的文件夹列表.Count = 0 Then
                    新建项评估不通过操作()
                    添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A8"), Color1.黄色)
                    Exit Sub
                End If
                If My.Computer.FileSystem.FileExists(新建项完整路径 & "\manifest.json") = True Then
                    新建项评估不通过操作()
                    添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A9"), Color1.黄色)
                    Exit Sub
                End If
                For i = 0 To 准备处理的文件夹列表.Count - 1
                    If My.Computer.FileSystem.FileExists(新建项完整路径 & "\" & 准备处理的文件夹列表(i) & "\manifest.json") = False Then
                        新建项评估不通过操作()
                        添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A7"), Color1.黄色)
                        Exit Sub
                    Else
                        If 自动编写的安装命令 = "" Then
                            自动编写的安装命令 &= "CDCD" & vbNewLine & 准备处理的文件夹列表(i)
                        Else
                            自动编写的安装命令 &= vbNewLine & "CDCD" & vbNewLine & 准备处理的文件夹列表(i)
                        End If
                    End If
                Next

                My.Computer.FileSystem.WriteAllText(新建项完整路径 & "\Code", 自动编写的安装命令, False, System.Text.Encoding.UTF8)
                Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S15")
                Application.DoEvents()
                TimerSleep.Sleep(1500)
        End Select

        If My.Computer.FileSystem.DirectoryExists(这份进程正在使用的临时解压目录) = True Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S14")
            Application.DoEvents()
            My.Computer.FileSystem.DeleteDirectory(这份进程正在使用的临时解压目录, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Me.Close()
    End Sub

    Sub 更新项评估不通过操作()
        Dim msg1 As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DirectOnlineUpdateWindow/S12"), 150, 500)
        msg1.ShowDialog(Me)
        Process.Start(这份进程正在使用的临时解压目录)
        Form1.配置部署ToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Sub 新建项评估不通过操作()
        Dim msg1 As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DirectOnlineUpdateWindow/S12"), 150, 500)
        msg1.ShowDialog(Me)
        Process.Start(这份进程正在使用的临时解压目录)
        For i = 0 To Form1.ListView3.Items.Count - 1
            If Form1.ListView3.Items.Item(i).Text = 当前正在进行新建项的目标分类 And Form1.ListView3.Items.Item(i).SubItems(1).Text = 当前正在进行新建项的项名称 Then
                GoTo jx1
            End If
        Next
        Form1.ListView3.Items.Add(当前正在进行新建项的目标分类)
        Form1.ListView3.Items.Item(Form1.ListView3.Items.Count - 1).SubItems.Add(当前正在进行新建项的项名称)
jx1:
        If Form1.ListView3.SelectedItems.Count = 0 Then Form1.ListView3.Items.Item(Form1.ListView3.Items.Count - 1).Selected = True
        If Form1.ListView3.Items.Count = 1 Then
            Form1.模拟按下配置队列选项卡切换按钮()
        End If
        Me.Close()
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        Select Case Me.DarkButton1.Text
            Case 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5")
                Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A6")
                xml_Settings.SelectSingleNode("data/LastUsed_DirectDownloadItemUpdateUserMember").InnerText = "False"
            Case 获取动态多语言文本("data/DirectOnlineUpdateWindow/A6")
                Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5")
                xml_Settings.SelectSingleNode("data/LastUsed_DirectDownloadItemUpdateUserMember").InnerText = "True"
        End Select
    End Sub


End Class