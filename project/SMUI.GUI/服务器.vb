Imports System.IO
Imports System.Management
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI.GUI.Class1
Module 服务器
    Public 正在进行更新 As Boolean = False
    Public 获取到的更新内容描述 As String = ""

    Public Sub 运行后台服务器检查更新()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\Portable") = True Then
            添加调试文本(获取动态多语言文本("data/DynamicText/Sever.0"), Color1.绿色)
            Exit Sub
        End If
        If ST1.当前是否正在使用Steam版本 = True Then
            添加调试文本(获取动态多语言文本("data/DynamicText/Sever.11"), Color1.绿色)
            Exit Sub
        End If
        正在进行更新 = True
        Form1.Label更新状态标记.Text = 获取动态多语言文本("data/DynamicText/Sever.1")
        Dim 服务器获取_更新 As New System.ComponentModel.BackgroundWorker
        Dim 服务器获取_自动更新 As New System.ComponentModel.BackgroundWorker
        Dim 自动更新界面刷新 As New Timer With {.Interval = 1000}

        Dim 更新_标题 As String = ""
        Dim 更新_版本 As String = ""
        Dim 更新_发布者 As String = ""
        Dim 更新_下载地址 As String = ""
        Dim 更新_内容描述 As String = ""
        Dim 更新_发布时间 As String = ""
        AddHandler 服务器获取_更新.DoWork,
            Sub(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
                Dim a As New Lake1059.GitAPI.Release
                Select Case xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText
                    Case "1"
                        a.获取仓库发布版信息(Lake1059.GitAPI.GitApiObject.开源代码平台.Gitee, "Lake1059/StardewMUI-5")
                    Case Else
                        a.获取仓库发布版信息(Lake1059.GitAPI.GitApiObject.开源代码平台.GitHub, "Lake1059/StardewMUI-5")
                End Select

                If a.ErrorString <> "" Then
                    e.Result = a.ErrorString
                    Exit Sub
                End If
                更新_标题 = a.发布标题
                更新_发布者 = a.发布者用户名
                更新_版本 = a.版本标签
                更新_发布时间 = a.发布时间
                For i = 0 To a.文件名.Count - 1
                    If a.文件名(i) = "StardewMUI 5 Installer.exe" Or a.文件名(i) = "StardewMUI.5.Installer.exe" Then
                        更新_下载地址 = a.文件下载地址(i)
                        Exit For
                    End If
                Next
                更新_内容描述 = a.发布描述
            End Sub
        AddHandler 服务器获取_更新.RunWorkerCompleted,
            Sub(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
                If e.Result <> "" Then
                    Form1.Label更新状态标记.Text = "Error: " & e.Result
                    正在进行更新 = False
                ElseIf 更新_下载地址 = "" Then
                    Form1.Label更新状态标记.Text = 获取动态多语言文本("data/DynamicText/Sever.2")
                    正在进行更新 = False
                Else
                    If SMUI.Windows.Core.SharedFunction.CompareVersion(更新_版本, Application.ProductVersion) > 0 Then
                        Form1.Label更新状态标记.Text = 获取动态多语言文本("data/DynamicText/Sever.3")
                        Application.DoEvents()
                        服务器获取_自动更新.RunWorkerAsync()
                    Else
                        Form1.Label更新状态标记.Text = 更新_标题 & " Release by " & 更新_发布者 ' & " in " & 更新_发布时间
                        正在进行更新 = False
                    End If
                    获取到的更新内容描述 = 更新_内容描述
                End If
            End Sub

        Dim 已下载字节数 As Long = 0
        Dim 总字节数 As Long = 0
        Dim 是否终止下载 As Boolean = False
        Dim 上一秒的已下载字节数 As Long = 0

        AddHandler 服务器获取_自动更新.DoWork,
            Sub(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
                ST1.全局状态_是否正在下载更新 = True
                e.Result = Lake1059.Internet.下载文件.DownloadFile(更新_下载地址, Path1.更新安装程序文件路径, 已下载字节数, 总字节数, 是否终止下载)
            End Sub
        AddHandler 服务器获取_自动更新.RunWorkerCompleted,
            Sub(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
                ST1.全局状态_是否正在下载更新 = False
                If My.Computer.FileSystem.FileExists(Path1.更新安装程序文件路径) = True Then
                    ST1.全局状态_是否需要在退出后安装更新 = True
                    MsgBox(获取动态多语言文本("data/DynamicText/Sever.4"))
                Else
                    MsgBox(获取动态多语言文本("data/DynamicText/Sever.5") & vbNewLine & vbNewLine & e.Result)
                    正在进行更新 = False
                End If
                GC.Collect()
            End Sub
        AddHandler 自动更新界面刷新.Tick,
            Sub(sender As Object, e As EventArgs)
                If 总字节数 = 0 Then Exit Sub
                If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
                    Form1.Label更新状态标记.Text = 获取动态多语言文本("data/DynamicText/Sever.4")
                    自动更新界面刷新.Enabled = False
                    Exit Sub
                End If
                Form1.Label更新状态标记.Text = 获取动态多语言文本("data/DynamicText/Sever.6") & 更新_版本 & "   " & Format(已下载字节数 / 1024 / 1024, "0.0") & " MB / " & Format(总字节数 / 1024 / 1024, "0.0") & " MB"
                If 已下载字节数 - 上一秒的已下载字节数 > 0 Then
                    Form1.Label更新状态标记.Text &= "   " & Format((已下载字节数 - 上一秒的已下载字节数) / 1024, "0") & " KB/s"
                End If
                Form1.Label更新状态标记.Text &= "   " & Format(已下载字节数 / 总字节数, "0.00") * 100 & " %"
                上一秒的已下载字节数 = 已下载字节数
            End Sub

        服务器获取_更新.RunWorkerAsync()
        自动更新界面刷新.Enabled = True

    End Sub

    Public Sub 向服务器发送用户统计()
        If My.Settings.上次发送用户统计的日期 = Now.Year & "/" & Now.Month & "/" & Now.Day Then Exit Sub
        If My.Computer.Network.IsAvailable = False Then Exit Sub
        添加调试文本(获取动态多语言文本("data/DynamicText/Sever.7"), Color1.白色)
        Dim 服务器发送 As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True}
        AddHandler 服务器发送.DoWork,
           Sub(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
               Try
                   Dim 地址传递 As String = ""
                   If xml_Settings.SelectSingleNode("data/PrivacyChoice").InnerText = "2" Then
                       地址传递 = "http://47.94.89.191:30003/user"
                       GoTo jx1
                   End If
                   Dim 软件版本 As String = "appver=" & Application.ProductVersion
                   Dim 系统名称 As String = "&sysname=" & My.Computer.Info.OSFullName
                   Dim MyReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor\0")
                   Dim 处理器名称 As String = "&cpuname=" & MyReg.GetValue("ProcessorNameString").ToString()
                   Dim 内存大小 As String = "&ram=" & Format(My.Computer.Info.TotalPhysicalMemory / 1024 / 1024 / 1024, "0.0") & "GB"
                   Dim m As New ManagementClass("Win32_VideoController")
                   Dim mn As ManagementObjectCollection = m.GetInstances()
                   Dim mos As New ManagementObjectSearcher("Select * from Win32_VideoController")
                   Dim DisplayName As String = ""
                   For Each mo As ManagementObject In mos.[Get]()
                       If DisplayName = "" Then
                           DisplayName = mo("Name").ToString()
                       Else
                           DisplayName &= " | " & mo("Name").ToString()
                       End If
                   Next

                   Dim 显卡列表 As String
                   If DisplayName = "" Then
                       显卡列表 = ""
                   Else
                       显卡列表 = "&gpulist=" & DisplayName
                   End If
                   Dim 显示器分辨率 As String = Screen.PrimaryScreen.Bounds.Size.Width & "x" & Screen.PrimaryScreen.Bounds.Size.Height
                   Dim 显示器刷新率 As String = mn(0)("CurrentRefreshRate")
                   Dim g1 As Graphics = Form1.CreateGraphics
                   Dim 屏幕DPI As String = g1.DpiX & "x" & g1.DpiY
                   Dim 显示器信息 As String = "&screen=" & 显示器分辨率 & " " & 显示器刷新率 & "FPS " & 屏幕DPI & "DPI"
                   Dim 用户语言 As String = "&lang=" & xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText

                   mn.Dispose()
                   m.Dispose()

                   Dim 输出1 As String = "report"
                   输出1 &= vbNewLine & 系统名称
                   输出1 &= vbNewLine & 处理器名称
                   输出1 &= vbNewLine & 内存大小
                   输出1 &= vbNewLine & DisplayName
                   输出1 &= vbNewLine & 显示器信息
                   服务器发送.ReportProgress(1, 输出1)

                   地址传递 = "http://47.94.89.191:30003/user?" & 软件版本 & 系统名称 & 处理器名称 & 内存大小 & 显卡列表 & 显示器信息 & 用户语言

                   Dim 画个圈圈诅咒那些攻击服务器的弱智孤儿 As Boolean = True
jx1:
                   Dim uri As New Uri(地址传递)
                   Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
                   myReq.ContinueTimeout = 5000
                   myReq.UserAgent = "StardewMUI 5 Official Application"
                   myReq.Accept = "application/text"
                   myReq.MediaType = "text"
                   myReq.Method = "GET"
                   myReq.KeepAlive = False
                   'myReq.Headers.Add("content-type", "application/text")
                   Dim result As HttpWebResponse = DirectCast(myReq.GetResponse, HttpWebResponse)
                   Dim receviceStream As Stream = result.GetResponseStream()
                   Dim readerOfStream As New StreamReader(receviceStream, Text.Encoding.GetEncoding("utf-8"))
                   Dim strHTML As String = readerOfStream.ReadToEnd()
                   readerOfStream.Close()
                   receviceStream.Close()
                   result.Close()
                   e.Result = strHTML
               Catch ex As Exception
                   e.Result = ex.Message
               End Try
           End Sub
        AddHandler 服务器发送.ProgressChanged,
           Sub(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
               添加调试文本(e.UserState, Color1.白色)
           End Sub

        AddHandler 服务器发送.RunWorkerCompleted,
           Sub(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
               If InStr(e.Result, "{") > 0 Then
                   Dim JsonData As Object = CType(JsonConvert.DeserializeObject(e.Result), JObject)
                   If JsonData.item("code") IsNot Nothing Then
                       If JsonData.item("code").ToString = "100" Then
                           添加调试文本(获取动态多语言文本("data/DynamicText/Sever.9"), Color1.白色)
                           My.Settings.上次发送用户统计的日期 = Now.Year & "/" & Now.Month & "/" & Now.Day
                           My.Settings.Save()
                       Else
                           添加调试文本("Error " & JsonData.item("code").ToString & "：" & JsonData.item("msg").ToString, Color1.红色)
                       End If
                   Else
                       添加调试文本(e.Result, Color1.红色)
                   End If
               Else
                   添加调试文本(e.Result, Color1.红色)
               End If
           End Sub
        服务器发送.RunWorkerAsync()
    End Sub

    Public Sub 运行后台服务器获取新闻()
        If ST1.本次启动时候已经获取了新闻 = True Then Exit Sub
        GC.Collect()
        If My.Computer.Network.IsAvailable = False Then
            Form1.Panel新闻公告.Controls.Clear()
            Form1.Panel新闻公告.Controls.Add(New Label With {.Text = 获取动态多语言文本("data/DynamicText/Sever.8"), .Dock = DockStyle.Fill, .AutoSize = False, .TextAlign = ContentAlignment.MiddleCenter})
            Exit Sub
        End If
        'ST1.新闻容器背景图存储 = Form1.Panel4.BackgroundImage
        'Form1.Panel4.BackgroundImage = Nothing
        Application.DoEvents()
        Form1.Panel新闻公告.Controls.Clear()
        Application.DoEvents()
        Dim 服务器获取_新闻 As New System.ComponentModel.BackgroundWorker
        Dim 新闻_标题 As String() = {}
        Dim 新闻_副标题 As String() = {}
        Dim 新闻_类型 As String() = {}
        Dim 新闻_内容 As String() = {}
        AddHandler 服务器获取_新闻.DoWork,
            Sub(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
                Dim a As New Lake1059.GitAPI.TextFileString
                Dim x1 As String = ""
                Select Case xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText
                    Case "Chinese"
                        x1 = "news_Chinese.json"
                    Case "English"
                        x1 = "news_English.json"
                End Select
                Select Case xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText
                    Case "1"
                        a.获取文本文件数据(Lake1059.GitAPI.GitApiObject.开源代码平台.Gitee, "Lake1059/StardewMUI-5", "main", x1, xml_Settings.SelectSingleNode("data/GiteePersonalAccessTokens").InnerText, True)
                    Case Else
                        a.获取文本文件数据(Lake1059.GitAPI.GitApiObject.开源代码平台.GitHub, "Lake1059/StardewMUI-5", "main", x1, xml_Settings.SelectSingleNode("data/GitHubPersonalAccessTokens").InnerText, True)
                End Select

                If a.ErrorString <> "" Then
                    e.Result = a.ErrorString
                    Exit Sub
                Else
                    e.Result = ""
                End If
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a.网页返回字符串), JObject)
                For i = 0 To JsonData.item("Object").count - 1
                    ReDim Preserve 新闻_标题(新闻_标题.Count)
                    新闻_标题(新闻_标题.Count - 1) = JsonData.item("Object").item(i)("Title").ToString
                    ReDim Preserve 新闻_副标题(新闻_副标题.Count)
                    新闻_副标题(新闻_副标题.Count - 1) = JsonData.item("Object").item(i)("Subtitle").ToString
                    ReDim Preserve 新闻_类型(新闻_类型.Count)
                    新闻_类型(新闻_类型.Count - 1) = JsonData.item("Object").item(i)("Type").ToString
                    ReDim Preserve 新闻_内容(新闻_内容.Count)
                    新闻_内容(新闻_内容.Count - 1) = JsonData.item("Object").item(i)("Body").ToString
                Next
            End Sub
        AddHandler 服务器获取_新闻.RunWorkerCompleted,
            Sub(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)

                If e.Result = "" Then
                    Form1.Panel新闻公告.Visible = False
                    Application.DoEvents()
                    For i = 0 To 新闻_标题.Count - 1
                        Dim L1 As New LinkLabel With {
                            .Text = 新闻_标题(i),
                            .TextAlign = ContentAlignment.MiddleLeft,
                            .Dock = DockStyle.Top,
                            .AutoSize = False,
                            .Height = 40, '35
                            .AutoEllipsis = True,
                            .Font = New Font("Microsoft YaHei UI", 11),
                            .ActiveLinkColor = ColorTranslator.FromWin32(RGB(238, 130, 238)),
                            .LinkColor = ColorTranslator.FromWin32(RGB(0, 191, 255)),
                            .LinkBehavior = LinkBehavior.HoverUnderline,
                            .BackColor = Color.Transparent
                         }
                        Form1.Panel新闻公告.Controls.Add(L1)
                        L1.BringToFront()
                        Dim L2 As New Label With {
                            .Text = "   " & 新闻_副标题(i),
                            .TextAlign = ContentAlignment.TopLeft,
                            .Dock = DockStyle.Top,
                            .AutoSize = False,
                            .AutoEllipsis = True,
                            .Height = 25,
                            .Font = New Font("Microsoft YaHei UI", 9),
                            .ForeColor = Color.Silver,
                            .BackColor = Color.Transparent
                         }
                        Form1.Panel新闻公告.Controls.Add(L2)
                        L2.BringToFront()
                        Dim 临时变量_内容 = 新闻_内容(i)
                        Select Case 新闻_类型(i).ToLower
                            Case "link"
                                AddHandler L1.LinkClicked,
                                Sub(sender2, e2)
                                    System.Diagnostics.Process.Start(临时变量_内容)
                                End Sub
                            Case "msg"
                                AddHandler L1.LinkClicked,
                                Sub(sender2, e2)
                                    MsgBox(临时变量_内容)
                                End Sub
                            Case "msg<br>"
                                AddHandler L1.LinkClicked,
                                Sub(sender2, e2)
                                    MsgBox(临时变量_内容.Replace("<br>", vbNewLine))
                                End Sub

                        End Select
                    Next
                    Application.DoEvents()
                    Form1.Panel新闻公告.Visible = True
                Else
                    Form1.Panel新闻公告.Controls.Add(New Label With {.Text = e.Result, .Dock = DockStyle.Fill, .AutoSize = False})
                End If
                ST1.本次启动时候已经获取了新闻 = True
            End Sub
        Application.DoEvents()
        服务器获取_新闻.RunWorkerAsync()
    End Sub

End Module
