Imports SMUI.GUI.Class1

Module 安装卸载统一后台线程

    Public 要批量创建项的路径数据列表 As String() = {}
    Public 要创建一个项的路径数据列表 As String() = {}
    Public 要创建一个项的项名称 As String = ""
    Public 自动创建项的目标分类 As String = ""

    Enum 后台操作类型
        安装 = 1
        卸载 = 2
        更新项_直接覆盖 = 3
        更新项_完全替换 = 4
        批量创建项 = 11
        创建一个项 = 12
    End Enum

    Public Sub 安装卸载后台统一执行操作(ByVal 安装还是卸载 As 后台操作类型)
        Dim 项列表 As String() = {}
        Dim 所属分类列表 As String() = {}
        Dim 索引列表 As Integer() = {}
        Dim 线程ID As String = Now.Second & Now.Millisecond
        For i = 0 To Form1.ListView2.SelectedItems.Count - 1
            Select Case Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).SubItems(2).Text
                Case 获取动态多语言文本("data/DynamicText/InstallMessage.1"), 获取动态多语言文本("data/DynamicText/InstallMessage.2")
                Case Else
                    ReDim Preserve 项列表(项列表.Count)
                    项列表(项列表.Count - 1) = Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text
                    ReDim Preserve 所属分类列表(所属分类列表.Count)
                    所属分类列表(所属分类列表.Count - 1) = 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i))
                    ReDim Preserve 索引列表(索引列表.Count)
                    索引列表(索引列表.Count - 1) = Form1.ListView2.SelectedIndices(i)
                    Select Case 安装还是卸载
                        Case 后台操作类型.安装
                            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallMessage.1")
                        Case 后台操作类型.卸载
                            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallMessage.2")
                        Case 后台操作类型.更新项_直接覆盖, 后台操作类型.更新项_完全替换
                            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallMessage.3")
                    End Select

            End Select
        Next

        Select Case 安装还是卸载
            Case 后台操作类型.批量创建项, 后台操作类型.创建一个项
            Case Else
                If 项列表.Count = 0 Then
                    添加调试文本(线程ID & " " & 获取动态多语言文本("data/DynamicText/InstallMessage.4"), Color1.橙色)
                    Exit Sub
                Else
                    添加调试文本(线程ID & " " & 获取动态多语言文本("data/DynamicText/InstallMessage.5") & Form1.ListView2.SelectedItems.Count & vbNewLine & 线程ID & " " & 获取动态多语言文本("data/DynamicText/InstallMessage.6") & 项列表.Count, Color1.蓝色)
                End If
        End Select

        Dim 后台线程 As New ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True}

        AddHandler 后台线程.DoWork,
            Sub(s, e)
                Select Case 安装还是卸载
                    Case 后台操作类型.批量创建项
                        后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.7"))
                        For i = 0 To 要批量创建项的路径数据列表.Count - 1
                            Dim str_1 As String = 检查并返回当前所选子库路径(False) & "\" & 自动创建项的目标分类 & "\" & IO.Path.GetFileName(要批量创建项的路径数据列表(i))
                            Dim str_2 As String = IO.Path.GetFileName(要批量创建项的路径数据列表(i))
                            If My.Computer.FileSystem.DirectoryExists(str_1) = True Then
                                后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.8") & str_2)
                            Else
                                后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.9") & str_2)
                                My.Computer.FileSystem.CreateDirectory(str_1)
                                后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.10") & str_2)
                                My.Computer.FileSystem.CopyDirectory(要批量创建项的路径数据列表(i), str_1 & "\" & str_2)
                                后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.11"))
                                My.Computer.FileSystem.WriteAllText(str_1 & "\Code", "CDCD" & vbNewLine & str_2, False)
                                后台线程.ReportProgress(30, 获取动态多语言文本("data/DynamicText/InstallMessage.12"))
                            End If
                        Next
                        Exit Sub
                    Case 后台操作类型.创建一个项
                        后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.7"))
                        Dim str_1 As String = 检查并返回当前所选子库路径(False) & "\" & 自动创建项的目标分类 & "\" & 要创建一个项的项名称
                        Dim str_2 As String = 要创建一个项的项名称
                        If My.Computer.FileSystem.DirectoryExists(str_1) = True Then
                            后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.8") & str_2)
                        Else
                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.9") & str_2)
                            My.Computer.FileSystem.CreateDirectory(str_1)
                            For i = 0 To 要创建一个项的路径数据列表.Count - 1
                                Dim str_3 As String = IO.Path.GetFileName(要创建一个项的路径数据列表(i))
                                后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.10") & str_3)
                                My.Computer.FileSystem.CopyDirectory(要创建一个项的路径数据列表(i), str_1 & "\" & str_3)
                            Next
                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.11") & str_2)
                            Dim str_安装命令 As String = ""
                            For i = 0 To 要创建一个项的路径数据列表.Count - 1
                                If str_安装命令 = "" Then
                                    str_安装命令 = "CDCD" & vbNewLine & IO.Path.GetFileName(要创建一个项的路径数据列表(i))
                                Else
                                    str_安装命令 &= vbNewLine & "CDCD" & vbNewLine & IO.Path.GetFileName(要创建一个项的路径数据列表(i))
                                End If
                            Next
                            My.Computer.FileSystem.WriteAllText(str_1 & "\Code", str_安装命令, False)
                            后台线程.ReportProgress(30, 获取动态多语言文本("data/DynamicText/InstallMessage.12"))
                        End If
                        Exit Sub
                    Case Else
                End Select

                后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.13"))
                Dim a As New SMUI.Windows.Core.TaskQueue With {
                    .GamePath = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText,
                    .GameBackupPath = xml_Settings.SelectSingleNode("data/StardewValleyGameBackUpPath").InnerText
                }

                For i = 0 To 项列表.Count - 1
                    a.ItemPath = 检查并返回当前所选子库路径(False) & "\" & 所属分类列表(i) & "\" & 项列表(i)
                    Dim abc1 As String = a.LoadCode
                    If abc1 = "" Then
                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.14") & 项列表(i))
                    Else
                        后台线程.ReportProgress(50, 获取动态多语言文本("data/DynamicText/InstallMessage.15") & abc1 & " | " & 获取动态多语言文本("data/DynamicText/InstallMessage.16") & 项列表(i) & " | " & 获取动态多语言文本("data/DynamicText/InstallMessage.17") & 所属分类列表(i))
                        后台线程.ReportProgress(60, i)
                        Continue For
                    End If

                    For i2 = 0 To a.Task_Code.Count - 1
                        Select Case 安装还是卸载
                            Case 后台操作类型.安装
                                Select Case a.Task_Code(i2)
                                    Case SMUI.Windows.Core.Objects.CDTask.CDCD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.18") & a.Task_Parameter1(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDGCD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.19") & a.Task_Parameter2(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDMAD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.20") & a.Task_Parameter1(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDGRF
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.21") & a.Task_Parameter2(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDGCF
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.22") & a.Task_Parameter2(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDF
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.23") & a.Task_Parameter2(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDVD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.24"))
                                    Case SMUI.Windows.Core.Objects.CDTask.SUB_D_EX_IN
                                        后台线程.ReportProgress(20, 获取动态多语言文本("data/DynamicText/InstallMessage.25") & vbNewLine & a.Task_Parameter1(i2).Replace("|", vbNewLine))
                                End Select
                                Dim abc2 As String = a.PerformInstall(i2)
                                If abc2 <> "" Then
                                    后台线程.ReportProgress(50, abc2 & " | " & 获取动态多语言文本("data/DynamicText/InstallMessage.26") & a.Code_LineMark(i2))
                                    后台线程.ReportProgress(50, 获取动态多语言文本("data/DynamicText/InstallMessage.27"))
                                    For y1 = i2 To 0 Step -1
                                        Dim xyz1 As String = a.PerformUnInstall(y1)
                                        If xyz1 <> "" Then 后台线程.ReportProgress(50, xyz1)
                                    Next
                                    Exit For
                                End If

                            Case 后台操作类型.卸载
                                Select Case a.Task_Code(i2)
                                    Case SMUI.Windows.Core.Objects.CDTask.CDCD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.28") & a.Task_Parameter1(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDGCD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.29") & a.Task_Parameter2(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDMAD
                                        后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.30"))
                                        Continue For
                                    Case SMUI.Windows.Core.Objects.CDTask.CDGRF
                                        If My.Computer.FileSystem.FileExists(a.GameBackupPath & "\" & a.Task_Parameter2(i2)) = True Then
                                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.31") & a.Task_Parameter2(i2))
                                        Else
                                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.32") & a.Task_Parameter2(i2))
                                        End If
                                    Case SMUI.Windows.Core.Objects.CDTask.CDGCF
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.33") & a.Task_Parameter2(i2))
                                    Case SMUI.Windows.Core.Objects.CDTask.CDF
                                        If My.Computer.FileSystem.FileExists(a.GameBackupPath & "\" & a.Task_Parameter2(i2)) = True Then
                                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.31") & a.Task_Parameter2(i2))
                                        Else
                                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.32") & a.Task_Parameter2(i2))
                                        End If
                                    Case SMUI.Windows.Core.Objects.CDTask.CDVD
                                        后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.34"))
                                End Select
                                Dim abc2 As String = a.PerformUnInstall(i2)
                                If abc2 <> "" Then
                                    后台线程.ReportProgress(50, abc2 & " | " & 获取动态多语言文本("data/DynamicText/InstallMessage.26") & a.Code_LineMark(i2))
                                    后台线程.ReportProgress(50, 获取动态多语言文本("data/DynamicText/InstallMessage.35"))
                                    Exit For
                                End If

                            Case 后台操作类型.更新项_直接覆盖
                                Select Case a.Task_Code(i2)
                                    Case SMUI.Windows.Core.Objects.CDTask.CDCD
                                        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & a.Task_Parameter1(i2)) = True Then
                                            后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.36") & a.Task_Parameter1(i2))
                                            My.Computer.FileSystem.CopyDirectory(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & a.Task_Parameter1(i2), 检查并返回当前所选子库路径(False) & "\" & 所属分类列表(i) & "\" & 项列表(i) & "\" & a.Task_Parameter1(i2), True)

                                        Else
                                            后台线程.ReportProgress(50, 获取动态多语言文本("data/DynamicText/InstallMessage.37") & a.Task_Parameter1(i2))
                                        End If
                                End Select
                            Case 后台操作类型.更新项_完全替换
                                Select Case a.Task_Code(i2)
                                    Case SMUI.Windows.Core.Objects.CDTask.CDCD
                                        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & a.Task_Parameter1(i2)) = True Then
                                            If My.Computer.FileSystem.DirectoryExists(检查并返回当前所选子库路径(False) & "\" & 所属分类列表(i) & "\" & 项列表(i) & "\" & a.Task_Parameter1(i2)) = True Then
                                                后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.38") & a.Task_Parameter1(i2))
                                                My.Computer.FileSystem.DeleteDirectory(检查并返回当前所选子库路径(False) & "\" & 所属分类列表(i) & "\" & 项列表(i) & "\" & a.Task_Parameter1(i2), FileIO.DeleteDirectoryOption.DeleteAllContents)
                                            End If
                                            后台线程.ReportProgress(40, 获取动态多语言文本("data/DynamicText/InstallMessage.39") & a.Task_Parameter1(i2))
                                            My.Computer.FileSystem.CopyDirectory(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & a.Task_Parameter1(i2), 检查并返回当前所选子库路径(False) & "\" & 所属分类列表(i) & "\" & 项列表(i) & "\" & a.Task_Parameter1(i2), True)
                                        Else
                                            后台线程.ReportProgress(50, 获取动态多语言文本("data/DynamicText/InstallMessage.37") & a.Task_Parameter1(i2))
                                        End If
                                End Select
                        End Select

                    Next

                    Select Case 安装还是卸载
                        Case 后台操作类型.安装
                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.40") & 项列表(i))
                            后台线程.ReportProgress(60, i)
                        Case 后台操作类型.卸载
                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.41") & 项列表(i))
                            后台线程.ReportProgress(60, i)
                        Case 后台操作类型.更新项_直接覆盖, 后台操作类型.更新项_完全替换
                            后台线程.ReportProgress(10, 获取动态多语言文本("data/DynamicText/InstallMessage.42") & 项列表(i))
                            后台线程.ReportProgress(70, i)
                    End Select

                Next

            End Sub

        AddHandler 后台线程.ProgressChanged,
            Sub(s, e)
                '用进度数值控制输出字的颜色
                Select Case e.ProgressPercentage
                    Case 10 '黑色
                        添加调试文本(线程ID & " " & e.UserState, Color1.白色)
                    Case 20 '蓝色
                        添加调试文本(线程ID & " " & e.UserState, Color1.蓝色)
                    Case 30 '绿色
                        添加调试文本(线程ID & " " & e.UserState, Color1.绿色)
                    Case 40 '紫色
                        添加调试文本(线程ID & " " & e.UserState, Color1.紫色)
                        If Form调试.Visible = True Then
                            Form调试.Focus()
                        Else
                            显示窗体(Form调试, Form1)
                        End If
                    Case 50 '红色
                        添加调试文本(线程ID & " " & e.UserState, Color1.红色)
                        If Form调试.Visible = True Then
                            Form调试.Focus()
                        Else
                            显示窗体(Form调试, Form1)
                        End If
                    Case 60 '调用刷新安装状态
                        Dim i As Integer = e.UserState
                        If Form1.ListView2.Items.Item(索引列表(i)).Text = 项列表(i) And 当前项列表中项的分类集合(索引列表(i)) = 所属分类列表(i) Then
                            Dim smuia As New SMUI.Windows.Core.ItemInfoReader
                            Dim smuictype As New SMUI.Windows.Core.Objects.ItemCalculateType With {.InstallStatus = True}
                            smuia.ReadItemInfo(检查并返回当前所选子库路径(False) & "\" & 所属分类列表(i) & "\" & 项列表(i), smuictype, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
                            If smuia.ErrorString = "" Then
                                根据安装状态设置项的颜色标记(smuia.InstallStatus, Form1.ListView2.Items.Item(索引列表(i)))
                                Form1.ListView2.Items.Item(索引列表(i)).SubItems(2).Text = 根据安装状态返回多语言字符(smuia.InstallStatus)
                            Else
                                Form1.ListView2.Items.Item(索引列表(i)).SubItems(1).Text = 获取动态多语言文本("data/DynamicText/InstallMessage.47")
                                Form1.ListView2.Items.Item(索引列表(i)).SubItems(2).Text = smuia.ErrorString
                                Form1.ListView2.Items.Item(索引列表(i)).StateImageIndex = 1
                                Form1.ListView2.Items.Item(索引列表(i)).ForeColor = Color1.红色
                            End If
                        End If
                    Case 70 '本地更新完成
                        Dim i As Integer = e.UserState
                        If Form1.ListView2.Items.Item(索引列表(i)).Text = 项列表(i) And 当前项列表中项的分类集合(索引列表(i)) = 所属分类列表(i) Then
                            Form1.ListView2.Items.Item(索引列表(i)).SubItems(1).Text = 获取动态多语言文本("data/DynamicText/InstallMessage.43")
                            Form1.ListView2.Items.Item(索引列表(i)).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallMessage.44")
                        End If
                End Select
            End Sub

        AddHandler 后台线程.RunWorkerCompleted,
            Sub(s, e)
                添加调试文本(线程ID & " " & 获取动态多语言文本("data/DynamicText/InstallMessage.45"), Color1.白色)
                If 安装还是卸载 = 后台操作类型.更新项_完全替换 Or 安装还是卸载 = 后台操作类型.更新项_直接覆盖 Then
                    添加调试文本(获取动态多语言文本("data/DynamicText/InstallMessage.46"), Color1.蓝色)
                End If
            End Sub
        后台线程.RunWorkerAsync()
    End Sub

End Module
