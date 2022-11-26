
Imports SMUI.Windows.PakManager
Imports SMUI.Windows.Core
Imports DarkUI.Controls
Imports SMUI.GUI.Class1

Module 管理模组

    Public Sub 扫描数据子库()
        Form1.切换数据子库ToolStripMenuItem.DropDownItems.Clear()
        Form1.删除数据子库ToolStripMenuItem.DropDownItems.Clear()
        Form1.转移分类ToolStripMenuItem.DropDownItems.Clear()
        If My.Computer.FileSystem.DirectoryExists(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText) = False Then
            Dim d1 As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.1"))
            d1.ShowDialog(Form1)
            Exit Sub
        End If
        Dim a As String() = SharedFunction.SearchFolderWithoutSub(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText)

        For i = 0 To a.Count - 1

            Dim m1 As New ToolStripMenuItem With {
                .Text = a(i)
            }
            Dim x As Integer = i
            AddHandler m1.Click,
                Sub()
                    Dim s1 As String = a(x)
                    xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText = s1
                    For i3 = 0 To Form1.切换数据子库ToolStripMenuItem.DropDownItems.Count - 1
                        Form1.切换数据子库ToolStripMenuItem.DropDownItems.Item(i3).Image = My.Resources.白
                    Next
                    m1.Image = My.Resources.绿
                    扫描分类(s1)
                    清除模组列表()
                    清除配置队列()
                End Sub
            Form1.切换数据子库ToolStripMenuItem.DropDownItems.Add(m1)
            If xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText = m1.Text Then
                m1.Image = My.Resources.绿
            Else
                m1.Image = My.Resources.白
            End If

            Dim m2 As New ToolStripMenuItem With {
              .Text = a(i)
             }
            Dim x2 As Integer = i
            AddHandler m2.Click,
                Sub()
                    Dim s1 As String = a(x2)
                    Dim d2 As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/DeletionInProgress"), {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DynamicText/ManageMod.4"),, 500)
                    If d2.ShowDialog(Form1) = 0 Then
                        My.Computer.FileSystem.DeleteDirectory(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & s1, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                        Form1.删除数据子库ToolStripMenuItem.DropDownItems.Remove(m2)
                        Form1.切换数据子库ToolStripMenuItem.DropDownItems.Remove(m1)
                        If xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText = s1 Then
                            清除分类列表()
                            清除模组列表()
                            清除配置队列()
                            xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText = ""
                        End If
                    End If
                End Sub
            Form1.删除数据子库ToolStripMenuItem.DropDownItems.Add(m2)
            m2.Image = My.Resources.红

        Next
        DeveloperEvent.Raise_SubLibraryListUpdatedEvent()
    End Sub

    Public Sub 清除分类列表()
        Form1.ListView1.Items.Clear()
        Form1.Label分类计数显示.Text = 0
    End Sub

    Public Sub 扫描分类(选择的数据子库 As String)
        Form1.ListView1.Items.Clear()
        If 检查并返回当前所选子库路径() = "" Then Exit Sub
        Dim a As String() = SharedFunction.SearchFolderWithoutSub(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText)
        For i = 0 To a.Count - 1
            Form1.ListView1.Items.Add(a(i))
            Dim b1 As String = xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText & "\" & a(i)
            If My.Computer.FileSystem.FileExists(b1 & "\Color") = True Then
                Select Case My.Computer.FileSystem.ReadAllText(b1 & "\Color")
                    Case "RED"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 1
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.红色
                    Case "ORANGE"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 2
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.橙色
                    Case "YELLOW"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 3
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.黄色
                    Case "GREEN"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 4
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.绿色
                    Case "AQUA"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 5
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.青色
                    Case "BLUE"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 6
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.蓝色
                    Case "PURPLE"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 7
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).ForeColor = Color1.紫色
                    Case Else
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 0
                End Select
            Else
                Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).StateImageIndex = 0
            End If
            If My.Computer.FileSystem.FileExists(b1 & "\Font") = True Then
                Select Case My.Computer.FileSystem.ReadAllText(b1 & "\Font")
                    Case "BD"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Bold)
                    Case "LC"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Italic)
                    Case "UL"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Underline)
                    Case "SO"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Strikeout)
                    Case "BD+UL"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = Font1.粗体下划线
                    Case "BD+SO"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = Font1.粗体删除线
                    Case "LC+UL"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = Font1.斜体下划线
                    Case "LC+SO"
                        Form1.ListView1.Items.Item(Form1.ListView1.Items.Count - 1).Font = Font1.斜体删除线
                End Select
            End If
        Next
        Form1.Label分类计数显示.Text = Form1.ListView1.Items.Count
        DeveloperEvent.Raise_CategoryListUpdatedEvent()
    End Sub

    Public Sub 清除模组列表()
        Form1.ListView2.Items.Clear()
        当前项列表中项的分类集合 = {}
        重置模组信息显示()
    End Sub

    Public Sub 刷新项列表()
        If Form1.ListView1.SelectedItems.Count <> 1 Then
            Dim x As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.3"))
            x.ShowDialog(Form1)
            Exit Sub
        End If
        重置模组信息显示()
        清除模组列表()
        Dim a1 As String = Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(0)).Text
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(检查并返回当前所选子库路径() & "\" & a1)
        For Each mDir In mDirInfo.GetDirectories
            Form1.ListView2.Items.Add(mDir.Name)
            ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
            当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = a1
        Next
        刷新项列表数据()
    End Sub

    Public Sub 刷新项列表数据()
        For i = 0 To Form1.ListView2.Items.Count - 1
            Dim itempath As String = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(i) & "\" & Form1.ListView2.Items.Item(i).Text
            Dim a As New SMUI.Windows.Core.ItemInfoReader
            Dim ct As New SMUI.Windows.Core.Objects.ItemCalculateType With {
                    .InstallStatus = True,
                    .Version = True,
                    .InstalledVersion = True
             }
            a.ReadItemInfo(itempath, ct, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
            If a.ErrorString = "" Then
                If Form1.ListView2.Items.Item(i).SubItems.Count <= 4 Then
                    Form1.ListView2.Items.Item(i).SubItems.Add("")
                    Form1.ListView2.Items.Item(i).SubItems.Add("")
                    Form1.ListView2.Items.Item(i).SubItems.Add(当前项列表中项的分类集合(i))
                End If
                If a.Version.Count > 0 And a.InstalledVersion.Count > 0 Then
                    If a.Version(0) <> a.InstalledVersion(0) Then
                        If a.InstallStatus = SMUI.Windows.Core.Objects.InstallStatus.Incomplete Then
                            Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.3")
                            Form1.ListView2.Items.Item(i).SubItems(1).Text = a.Version(0)
                            GoTo 结束版本号高低判断
                        End If

                        Select Case SMUI.Windows.Core.SharedFunction.CompareVersion(a.Version(0), a.InstalledVersion(0))
                            Case = 0
                                Form1.ListView2.Items.Item(i).SubItems(1).Text = a.Version(0)
                            Case > 0
                                Form1.ListView2.Items.Item(i).SubItems(1).Text = a.Version(0) & " ← " & a.InstalledVersion(0)
                                Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.UpdateAvailable")
                            Case < 0
                                Form1.ListView2.Items.Item(i).SubItems(1).Text = a.Version(0) & " → " & a.InstalledVersion(0)
                                Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.YouInstalledNewOne")
                        End Select
结束版本号高低判断:
                    Else
                        Form1.ListView2.Items.Item(i).SubItems(1).Text = a.Version(0)
                    End If

                Else
                    If a.Version.Count > 0 Then
                        Form1.ListView2.Items.Item(i).SubItems(1).Text = a.Version(0)
                    ElseIf My.Computer.FileSystem.FileExists(itempath & "\Version") = True Then
                        Form1.ListView2.Items.Item(i).SubItems(1).Text = My.Computer.FileSystem.ReadAllText(itempath & "\Version")
                    Else
                        Form1.ListView2.Items.Item(i).SubItems(1).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.Unknow")
                    End If
                    Form1.ListView2.Items.Item(i).StateImageIndex = 0
                    Form1.ListView2.Items.Item(i).ForeColor = Color1.白色
                End If

                Select Case Form1.ListView2.Items.Item(i).SubItems(2).Text
                    Case "", 获取动态多语言文本("data/DynamicText/ManageMod.12")
                        Form1.ListView2.Items.Item(i).SubItems(2).Text = 根据安装状态返回多语言字符(a.InstallStatus)
                End Select

                根据安装状态设置项的颜色标记(a.InstallStatus, Form1.ListView2.Items.Item(i), True)

                If My.Computer.FileSystem.FileExists(itempath & "\Font") = True Then
                    Select Case My.Computer.FileSystem.ReadAllText(itempath & "\Font")
                        Case "BD"
                            Form1.ListView2.Items.Item(i).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Bold)
                        Case "LC"
                            Form1.ListView2.Items.Item(i).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Italic)
                        Case "UL"
                            Form1.ListView2.Items.Item(i).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Underline)
                        Case "SO"
                            Form1.ListView2.Items.Item(i).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Strikeout)
                        Case "BD+UL"
                            Form1.ListView2.Items.Item(i).Font = Font1.粗体下划线
                        Case "BD+SO"
                            Form1.ListView2.Items.Item(i).Font = Font1.粗体删除线
                        Case "LC+UL"
                            Form1.ListView2.Items.Item(i).Font = Font1.斜体下划线
                        Case "LC+SO"
                            Form1.ListView2.Items.Item(i).Font = Font1.斜体删除线
                    End Select
                End If

            Else
                Form1.ListView2.Items.Item(i).SubItems.Add("Core Error")
                Form1.ListView2.Items.Item(i).SubItems.Add(a.ErrorString)
                Form1.ListView2.Items.Item(i).StateImageIndex = 1
                Form1.ListView2.Items.Item(i).ForeColor = Color.Red

            End If
        Next
        项列表计数显示()
    End Sub

    Public Function 根据安装状态返回多语言字符(安装状态 As Objects.InstallStatus) As String
        Select Case 安装状态
            Case Objects.InstallStatus.Unknow
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.Unknow")
            Case Objects.InstallStatus.NotDeployed
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.0")
            Case Objects.InstallStatus.Installed
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.1")
            Case Objects.InstallStatus.UnInstalled
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.2")
            Case Objects.InstallStatus.Incomplete
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.3")
            Case Objects.InstallStatus.FolderCopied
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.5")
            Case Objects.InstallStatus.FolderNotCopied
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.6")
            Case Objects.InstallStatus.AdditionalContent
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.10")
            Case Objects.InstallStatus.FileReplaced
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.20")
            Case Objects.InstallStatus.FileNotReplaced
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.21")
            Case Objects.InstallStatus.FileCopied
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.30")
            Case Objects.InstallStatus.FileNotCopied
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.31")
            Case Objects.InstallStatus.NeedCopyFile
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.35")
            Case Objects.InstallStatus.CoverContent
                Return 获取动态多语言文本("data/DynamicText/InstallStatus.40")
            Case Else
                Return "???"
        End Select
    End Function

    Public Sub 根据安装状态设置项的颜色标记(安装状态 As Objects.InstallStatus, 哪个项 As ListViewItem, Optional 跳过未安装的处理 As Boolean = False)
        Select Case 安装状态
            Case Objects.InstallStatus.UnInstalled
                If 跳过未安装的处理 = True Then Exit Sub
                哪个项.StateImageIndex = 0
                哪个项.ForeColor = Color1.白色
            Case Objects.InstallStatus.Installed
                哪个项.StateImageIndex = 4
                哪个项.ForeColor = Color1.绿色
            Case Objects.InstallStatus.Incomplete
                哪个项.StateImageIndex = 5
                哪个项.ForeColor = Color1.青色
            Case Objects.InstallStatus.FolderCopied, Objects.InstallStatus.FileCopied, Objects.InstallStatus.FileReplaced, Objects.InstallStatus.AdditionalContent, Objects.InstallStatus.CoverContent
                哪个项.StateImageIndex = 7
                哪个项.ForeColor = Color1.紫色
            Case Objects.InstallStatus.NeedCopyFile
                哪个项.StateImageIndex = 6
                哪个项.ForeColor = Color1.蓝色
            Case Objects.InstallStatus.NotDeployed
                哪个项.StateImageIndex = 1
                哪个项.ForeColor = Color1.红色
        End Select
    End Sub

    Public Sub 重置模组信息显示()
        Form1.RichTextBox1.Clear()
        Form1.Label更新地址显示.Text = " NEXUS Moddrop GitHub"
        Form1.Label依赖项数量显示.Text = " Requirements"
        Form1.LabelUniqueID显示.Text = " UniqueID"
        Form1.Label作者显示.Text = " Author"
        Form1.Panel版本比较器.Visible = False
        Form1.Label版本比较器_库中的版本.Text = ""
        Form1.Label版本比较器_游戏中的版本.Text = ""
        Form1.Label描述类型.Text = " Type"
        Form1.Panel预览图.Visible = False
        Form1.PictureBox1.Image = Nothing
        If Form依赖项表.Visible = True Then
            Form依赖项表.Text = "依赖项表"
            Form依赖项表.ListView1.Items.Clear()
        End If
        校准RichTextBox1的尺寸和位置()
    End Sub

    Public 当前项信息_N网ID列表 As String() = {}
    Public 当前项信息_呵呵鱼ID列表 As String() = {}
    Public 当前项信息_Github仓库列表 As String() = {}
    Public 当前项信息_ModDropID列表 As String() = {}
    Public 当前项信息_内容包列表 As String() = {}
    Public 当前项信息_依赖项列表 As String() = {}
    Public 当前项信息_依赖项必须性列表 As Boolean() = {}
    Public 当前项信息_UniqueID列表 As String() = {}
    Public 当前项信息_作者列表 As String() = {}
    Public 当前项信息_预览图文件表 As String() = {}


    Public 当前项列表中项的分类集合 As String() = {}

    Public Sub 读取项信息并显示()
        重置模组信息显示()
        '没啥卵用的保险措施
        If 当前项列表中项的分类集合.Count <= Form1.ListView2.SelectedIndices(0) Then Exit Sub
        Dim 项路径 As String = 检查并返回当前所选子库路径() & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(0)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).Text

        Dim a As New SMUI.Windows.Core.ItemInfoReader
        Dim iCT As SMUI.Windows.Core.Objects.ItemCalculateType
        iCT.All = True
        a.ReadItemInfo(项路径, iCT, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
        If a.ErrorString = "" Then
            If My.Computer.FileSystem.FileExists(项路径 & "\README.rtf") = True Then
                Form1.RichTextBox1.LoadFile(项路径 & "\README.rtf")
                Form1.Label描述类型.Text = "RTF"
            ElseIf My.Computer.FileSystem.FileExists(项路径 & "\README") = True Then
                Form1.RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(项路径 & "\README")
                Form1.Label描述类型.Text = "TXT"
            ElseIf a.Description.Count > 0 Then
                For i = 0 To a.Description.Count - 1
                    If i = 0 Then
                        Form1.RichTextBox1.Text = a.Description(0)
                    Else
                        Form1.RichTextBox1.Text &= vbNewLine & vbNewLine & a.Description(i)
                    End If
                Next
                Form1.Label描述类型.Text = "JSON"
            Else
                Form1.Label描述类型.Text = "None"
            End If
            'FormRTF编辑器.RichTextBox1.Rtf = Form1.RichTextBox1.Rtf

            当前项信息_N网ID列表 = a.NexusID
            当前项信息_呵呵鱼ID列表 = a.ChuckleFishID
            当前项信息_Github仓库列表 = a.GitHub
            当前项信息_ModDropID列表 = a.ModDrop
            If a.NexusID.Count > 0 And a.ModDrop.Count > 0 Then
                Form1.Label更新地址显示.Text = " NEXUS: " & a.NexusID(0) & "  ModDrop"
            ElseIf a.NexusID.Count > 0 Then
                Form1.Label更新地址显示.Text = " NEXUS: " & a.NexusID(0)
            ElseIf a.ModDrop.Count > 0 Then
                Form1.Label更新地址显示.Text = " ModDrop: " & a.ModDrop(0)
            ElseIf a.GitHub.Count > 0 Then
                Form1.Label更新地址显示.Text = " GitHub"
            Else
                Form1.Label更新地址显示.Text = " No Update Keys"
            End If

            当前项信息_内容包列表 = a.ContentPackFor
            当前项信息_依赖项列表 = a.Dependencies
            当前项信息_依赖项必须性列表 = a.DependenciesIsRequired
            If a.ContentPackFor.Count + a.DependenciesIsRequired.Count > 0 Then
                Form1.Label依赖项数量显示.Text = " Requirements: C" & a.ContentPackFor.Count & " + R" & a.DependenciesIsRequired.Count
            Else
                Form1.Label依赖项数量显示.Text = " No Requirements"
            End If

            当前项信息_UniqueID列表 = a.UniqueID
            Select Case a.UniqueID.Count
                Case > 1
                    Form1.LabelUniqueID显示.Text = " [" & a.UniqueID.Count & "] UniqueID: " & a.UniqueID(0)
                Case 1
                    Form1.LabelUniqueID显示.Text = " UniqueID: " & a.UniqueID(0)
                Case 0
                    Form1.LabelUniqueID显示.Text = " No UniqueID"
            End Select

            当前项信息_作者列表 = a.Author
            Select Case a.Author.Count
                Case > 1
                    Form1.Label作者显示.Text = " [" & a.Author.Count & "] " & a.Author(0)
                Case 1
                    Form1.Label作者显示.Text = " Author: " & a.Author(0)
                Case 0
                    Form1.Label作者显示.Text = " No Author"
            End Select

            If a.Version.Count > 0 And a.InstalledVersion.Count > 0 Then
                If SMUI.Windows.Core.SharedFunction.CompareVersion(a.Version(0), a.InstalledVersion(0)) <> 0 Then
                    Form1.Label版本比较器_库中的版本.Text = a.Version(0)
                    Form1.Label版本比较器_游戏中的版本.Text = a.InstalledVersion(0)
                    Form1.Panel版本比较器.Visible = True
                End If
            End If

            If My.Computer.FileSystem.DirectoryExists(项路径 & "\Screenshot") = True Then
                当前项信息_预览图文件表 = {}
                ST1.全局状态_当前正在显示的预览图索引 = Nothing
                Dim 文件 As System.IO.FileInfo
                Dim 目录 As New System.IO.DirectoryInfo(项路径 & "\Screenshot")
                For Each 文件 In 目录.GetFiles("*.*")
                    ReDim Preserve 当前项信息_预览图文件表(当前项信息_预览图文件表.Count)
                    当前项信息_预览图文件表(当前项信息_预览图文件表.Count - 1) = 文件.FullName
                Next
                If 当前项信息_预览图文件表.Count > 0 Then
                    加载预览图(当前项信息_预览图文件表(0))
                    ST1.全局状态_当前正在显示的预览图索引 = 0
                    Form1.Label预览图计数显示.Text = 当前项信息_预览图文件表.Count & " "
                End If
            End If
            If Form依赖项表.Visible = True Then Form依赖项表.刷新前置表项()
            校准RichTextBox1的尺寸和位置()
        Else
            Dim x As New SingleSelectionDialog("CORE ERROR", {获取动态多语言文本("data/DynamicText/OK")}, a.ErrorString)
            x.ShowDialog(Form1)
        End If

    End Sub

    Public Sub 项列表计数显示()
        If Form1.ListView2.Items.Count = 0 Then
            Form1.Label项列表计数显示.Text = "0 "
            Exit Sub
        End If
        If Form1.ListView2.SelectedItems.Count > 1 Then
            Form1.Label项列表计数显示.Text = Form1.ListView2.SelectedItems.Count & "/" & Form1.ListView2.Items.Count & " "
        Else
            Form1.Label项列表计数显示.Text = Form1.ListView2.Items.Count & " "
        End If
    End Sub

    Public Sub 加载预览图(ByVal 文件 As String)
        Select Case IO.Path.GetExtension(文件).ToLower
            Case ".jpg", ".jpeg", ".png", ".bmp"
                Dim fs As New IO.FileStream(文件, IO.FileMode.Open, IO.FileAccess.Read)
                Form1.Panel预览图.Visible = True
                Form1.PictureBox1.Image = Image.FromStream(fs)
                fs.Close()
            Case ".gif"
                Dim img As Image = Image.FromFile(文件)
                Dim mstr As New IO.MemoryStream()
                img.Save(mstr, Imaging.ImageFormat.Gif)
                Form1.Panel预览图.Visible = True
                Form1.PictureBox1.Image = Image.FromStream(mstr)
                img.Dispose()
            Case ".webp"
                'Imazen.WebP.Extern.LoadLibrary.LoadByPath(Application.StartupPath & "\libwebp.dll", False)
                Dim bytes As Byte() = IO.File.ReadAllBytes(文件)
                Dim newdec As New Imazen.WebP.SimpleDecoder()
                Dim img As Bitmap = newdec.DecodeFromBytes(bytes, bytes.Length)
                Form1.Panel预览图.Visible = True
                Form1.PictureBox1.Image = img
                'Application.DoEvents()
                'img.Dispose()
        End Select
        Form1.ToolTip1.SetToolTip(Form1.PictureBox1, ST1.全局状态_当前正在显示的预览图索引 + 1 & "/" & 当前项信息_预览图文件表.Count)
    End Sub



    Public Function 生成更新地址表菜单() As DarkContextMenu
        Dim a As New DarkContextMenu
        If Form1.ListView2.SelectedItems.Count <> 1 Then
            Return a
            Exit Function
        End If
        a.ImageScalingSize = New Size(23, 23)
        a.DropShadowEnabled = False
        a.ShowCheckMargin = False
        a.BackColor = SystemColors.Control
        For i = 0 To 当前项信息_N网ID列表.Count - 1
            Dim x As New ToolStripMenuItem With {
                .Image = My.Resources.NEXUS,
                .Text = "NEXUS: " & 当前项信息_N网ID列表(i)
            }
            a.Items.Add(x)
            AddHandler x.Click,
                Sub(s, e)
                    Process.Start("https://www.nexusmods.com/stardewvalley/mods/" & Mid(x.Text, 8))
                End Sub
            AddHandler a.Items.Add(获取动态多语言文本("data/DynamicText/CopyLink2")).Click,
                Sub(s, e)
                    Clipboard.SetText("https://www.nexusmods.com/stardewvalley/mods/" & Mid(x.Text, 8))
                End Sub
            If Mid(x.Text, 8) <= 0 Then Continue For
            AddHandler a.Items.Add(获取动态多语言文本("data/DynamicText/DirectOnlineUpdate")).Click,
               Sub(s, e)
                   Dim 新的更新窗口 As New Form直接联网更新单个项 With {
                       .当前正在进行更新的单个项的N网ID = Mid(x.Text, 8),
                       .当前正在进行直接更新的操作类型 = 在线更新操作类型.更新项,
                       .当前正在进行更新的单个项路径 = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(0)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).Text
                   }
                   显示窗体(新的更新窗口, Form1)
               End Sub
        Next

        If 付费功能解锁.解锁自由输入直接更新项功能的NEXUSID = True Then
            Dim x As New ToolStripMenuItem With {
                .Image = My.Resources.NEXUS
            }
            If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "Chinese" Or ST1.是否正在使用自定义语言包 = True Then
                x.Text = "自由输入 ID 进行更新"
            Else
                x.Text = "Enter ID to update"
            End If
            a.Items.Add(x)
            AddHandler x.Click,
                Sub(s, e)
                    If Form直接联网更新单个项.Visible = True Then Exit Sub
                    x.Text = 获取动态多语言文本("data/DynamicText/UpdateMod.2")
                    Dim m1 As New InputTextDialog("Lake1059.Plugin1.UnlockFreeInputID", 获取动态多语言文本("data/DynamicText/UpdateMod.1"))
                    Dim m2 As String = m1.ShowDialog(Form1)
                    If m2 = "" Or m2 Is Nothing Then Exit Sub
                    Dim 新的更新窗口 As New Form直接联网更新单个项 With {
                        .当前正在进行更新的单个项的N网ID = m2,
                        .当前正在进行直接更新的操作类型 = 在线更新操作类型.更新项,
                        .当前正在进行更新的单个项路径 = 检查并返回当前所选子库路径(False) & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(0)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).Text
                    }
                    显示窗体(新的更新窗口, Form1)
                End Sub
        End If


        If 当前项信息_ModDropID列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
        For i = 0 To 当前项信息_ModDropID列表.Count - 1
            Dim x As New ToolStripMenuItem With {
                .Image = My.Resources.ModDrop_White32,
                .Text = "ModDrop: " & 当前项信息_ModDropID列表(i)
            }
            a.Items.Add(x)
            AddHandler x.Click,
                Sub(s, e)
                    Process.Start("https://www.moddrop.com/stardew-valley/mods/" & Mid(x.Text, 10))
                End Sub
            AddHandler a.Items.Add(获取动态多语言文本("data/DynamicText/CopyLink2")).Click,
                Sub(s, e)
                    Clipboard.SetText("https://www.moddrop.com/stardew-valley/mods/" & Mid(x.Text, 10))
                End Sub
        Next

        If 当前项信息_N网ID列表.Count = 0 And 当前项信息_ModDropID列表.Count = 0 Then
            GoTo jx1
        End If
        If 当前项信息_Github仓库列表.Count > 0 Then a.Items.Add(New ToolStripSeparator)
jx1:
        For i = 0 To 当前项信息_Github仓库列表.Count - 1
            Dim x As New ToolStripMenuItem With {
                .Image = My.Resources.Github,
                .Text = 当前项信息_Github仓库列表(i)
            }
            a.Items.Add(x)
            AddHandler x.Click,
                Sub(s, e)
                    Process.Start("https://github.com/" & x.Text)
                End Sub
            AddHandler a.Items.Add(获取动态多语言文本("data/DynamicText/CopyLink2")).Click,
                Sub(s, e)
                    Clipboard.SetText("https://github.com/" & x.Text)
                End Sub
        Next

        Return a
    End Function

    Public Function 生成UniqueID菜单() As DarkContextMenu
        Dim a As New DarkContextMenu
        If Form1.ListView2.SelectedItems.Count <> 1 Then
            Return a
            Exit Function
        End If
        a.ImageScalingSize = New Size(23, 23)
        a.DropShadowEnabled = False
        a.ShowCheckMargin = False
        a.BackColor = SystemColors.Control
        For i = 0 To 当前项信息_UniqueID列表.Count - 1
            Dim x As New ToolStripMenuItem With {
                .Image = My.Resources.SMAPI,
                .Text = 当前项信息_UniqueID列表(i)
            }
            a.Items.Add(x)
            AddHandler x.Click,
                Sub(s, e)
                    Clipboard.SetText(s.Text)
                End Sub
        Next

        Return a
    End Function

    Public Function 生成作者列表菜单() As DarkContextMenu
        Dim a As New DarkContextMenu
        If Form1.ListView2.SelectedItems.Count <> 1 Then
            Return a
            Exit Function
        End If
        a.ImageScalingSize = New Size(23, 23)
        a.DropShadowEnabled = False
        a.ShowCheckMargin = False
        a.BackColor = SystemColors.Control
        For i = 0 To 当前项信息_作者列表.Count - 1
            Dim x As New ToolStripMenuItem With {
                .Image = My.Resources.NEXUS,
                .Text = 当前项信息_作者列表(i)
            }
            a.Items.Add(x)
            AddHandler x.Click,
                Sub(s, e)
                    Clipboard.SetText(s.Text)
                End Sub
        Next

        Return a
    End Function

End Module
