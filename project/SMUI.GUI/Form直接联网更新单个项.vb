Imports System.ComponentModel
Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form直接联网更新单个项
    Private Sub Form直接联网更新单个项_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ST1.当前正在进行更新的单个项的N网ID = 12230 Then
            MsgBox("不准用来操作 12230 号页面，没有这种操作！" & vbNewLine & vbNewLine & "Not allowed to operate 12230, there is no such operation!", MsgBoxStyle.Exclamation, "请不要在酒吧里点炒饭")
            Me.Close()
        End If

        Me.Panel2.BorderStyle = BorderStyle.None : Me.Panel3.BorderStyle = BorderStyle.None
        Me.Panel2.Dock = DockStyle.Fill : Me.Panel3.Dock = DockStyle.Fill
        Me.Panel2.Visible = True
        Me.Label2.Width = 0
    End Sub

    Private Sub Form直接联网更新单个项_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/Title")
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S1")
        If ST1.上次用的会员下载还是免费下载 = 1 Then
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
        e.Result = a.StartGet("stardewvalley", ST1.当前正在进行更新的单个项的N网ID, SMUI.Windows.Nexus.NexusModsApiObject.FileType.main_optional)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Result <> "" Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S2")
            MsgBox(e.Result, MsgBoxStyle.Critical, "BGW1")
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
                    If ChromiumBrowser.Visible = False Then ChromiumBrowser.Show(Form1)

                    ChromiumBrowser.ChromiumWebBrowser1.LoadUrl("https://www.nexusmods.com/stardewvalley/mods/" & ST1.当前正在进行更新的单个项的N网ID & "?tab=files&file_id=" & 选定下载文件的ID & "&nmm=1")
                    ST1.用于内置IE浏览器_当前正在更新模组 = True
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
    Dim 选定下载文件的ID As Integer = 0

    ReadOnly b As New SMUI.Windows.Nexus.GetModFileDownloadURL With {
           .ST_ApiKey = xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText
       }

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        If Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5") Then
            e.Result = b.StartGet("stardewvalley", ST1.当前正在进行更新的单个项的N网ID, 选定下载文件的ID)
        Else
            e.Result = b.StartGet("stardewvalley", ST1.当前正在进行更新的单个项的N网ID, 选定下载文件的ID, ST1.用于内置IE浏览器_获取到的key, ST1.用于内置IE浏览器_获取到的expires)
        End If
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
        Dim dig1 As New SingleSelectionDialog(获取动态多语言文本("data/DirectOnlineUpdateWindow/S6"), 选项数组, 获取动态多语言文本("data/DirectOnlineUpdateWindow/S7"), 100, 500)
        Dim k1 As Integer = dig1.ShowDialog(Me)
        If k1 <> -1 Then
            确认的下载地址 = b.URI(k1)
            If My.Computer.FileSystem.DirectoryExists(Path1.临时自动下载路径) = False Then
                My.Computer.FileSystem.CreateDirectory(Path1.临时自动下载路径)
            End If
            保存位置 = Path1.临时自动下载路径 & "\" & ST1.当前正在进行更新的单个项的N网ID & "-" & 选定下载的文件 & "-" & 选定下载的文件版本 & ".zip"
            Me.Panel2.Visible = False
            Me.Panel3.Visible = True
            调整下载界面内容()
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S8")
            Me.Timer1.Enabled = True
            'Me.Timer2.Enabled = True
            Me.BackgroundWorker3.RunWorkerAsync()
        End If
    End Sub

    Dim 确认的下载地址 As String = ""

    Dim 保存位置 As String = ""
    Dim 已下载字节数 As Long = 0
    Dim 总字节数 As Long = 0
    Dim 是否终止下载 As Boolean = False
    Dim 上一秒的已下载字节数 As Long = 0

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        e.Result = Lake1059.Internet.下载文件.DownloadFile(确认的下载地址, 保存位置, 已下载字节数, 总字节数, 是否终止下载)
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        Me.Timer1.Enabled = False
        'Me.Timer2.Enabled = False
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
        If My.Computer.FileSystem.DirectoryExists(Path1.临时自动解压路径) = True Then
            My.Computer.FileSystem.DeleteDirectory(Path1.临时自动解压路径, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(Path1.临时自动解压路径)
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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If 总字节数 = 0 Then Exit Sub
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Me.Timer2.Enabled = False
            Exit Sub
        End If
        Me.Label5.Text = Format((已下载字节数 / 总字节数) * 100, "0.0") & "%"
        Me.Label2.Width = 已下载字节数 / 总字节数 * Me.Label2.Parent.Width
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Try
            Dim zip1 As New SevenZip.SevenZipExtractor(保存位置)
            For i As Integer = 0 To zip1.ArchiveFileData.Count - 1
                zip1.ExtractFiles(Path1.临时自动解压路径 & "\", zip1.ArchiveFileData(i).Index)
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
        Dim myItemCode As New SMUI.Windows.Core.TaskQueue With {
            .ItemPath = 检查并返回当前可用子库路径(False) & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(0)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).Text
        }
        myItemCode.LoadCode()
        Dim 压缩包内文件夹计数 As Integer = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(Path1.临时自动解压路径).Count
        Dim CDCD计数 As Integer = 0
        For i = 0 To myItemCode.Task_Code.Count - 1
            Select Case myItemCode.Task_Code(i)
                Case SMUI.Windows.Core.Objects.CDTask.CDCD
                    CDCD计数 += 1
                    If My.Computer.FileSystem.DirectoryExists(Path1.临时自动解压路径 & "\" & myItemCode.Task_Parameter1(i)) = False Then
                        评估不通过操作()
                        添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A1"), Color1.黄色)
                        Exit Sub
                    End If
                    If My.Computer.FileSystem.FileExists(Path1.临时自动解压路径 & "\" & myItemCode.Task_Parameter1(i) & "\manifest.json") = False Then
                        评估不通过操作()
                        添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A2"), Color1.黄色)
                        Exit Sub
                    End If
                Case SMUI.Windows.Core.Objects.CDTask.CDGCD, SMUI.Windows.Core.Objects.CDTask.CDGCF, SMUI.Windows.Core.Objects.CDTask.CDGRF, SMUI.Windows.Core.Objects.CDTask.CDMAD, SMUI.Windows.Core.Objects.CDTask.CDVD, SMUI.Windows.Core.Objects.CDTask.CDF
                    评估不通过操作()
                    添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A3"), Color1.黄色)
                    Exit Sub
            End Select
        Next
        If 压缩包内文件夹计数 <> CDCD计数 Then
            评估不通过操作()
            添加调试文本(获取动态多语言文本("data/DirectOnlineUpdateWindow/A4"), Color1.黄色)
            Exit Sub
        End If
        Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S_10_1")
        Application.DoEvents()
        '开始更新数据
        For i = 0 To myItemCode.Task_Code.Count - 1
            Select Case myItemCode.Task_Code(i)
                Case SMUI.Windows.Core.Objects.CDTask.CDCD
                    If My.Computer.FileSystem.DirectoryExists(myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i)) = True Then
                        My.Computer.FileSystem.DeleteDirectory(myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    My.Computer.FileSystem.CopyDirectory(Path1.临时自动解压路径 & "\" & myItemCode.Task_Parameter1(i), myItemCode.ItemPath & "\" & myItemCode.Task_Parameter1(i), True)
            End Select
        Next
        Dim msg1 As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DirectOnlineUpdateWindow/S11"))
        msg1.ShowDialog(Me)
        If My.Computer.FileSystem.DirectoryExists(Path1.临时自动解压路径) = True Then
            Me.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S14")
            Application.DoEvents()
            My.Computer.FileSystem.DeleteDirectory(Path1.临时自动解压路径, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        Me.Close()
    End Sub

    Sub 评估不通过操作()
        Dim msg1 As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DirectOnlineUpdateWindow/S12"), 150, 500)
        msg1.ShowDialog(Me)
        Process.Start(Path1.临时自动解压路径)
        Form1.配置部署ToolStripMenuItem.PerformClick()
        Me.Close()
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5") Then
            Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A6")
            ST1.上次用的会员下载还是免费下载 = 2
        Else
            Me.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A5")
            ST1.上次用的会员下载还是免费下载 = 1
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class