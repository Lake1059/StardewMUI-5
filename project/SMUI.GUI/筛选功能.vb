Imports SMUI.Windows.PakManager
Imports SMUI.GUI.Class1
Module 筛选功能

    Sub 选中已安装()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.1") Then
                Form1.ListView2.Items.Item(i).Selected = True
            Else
                Form1.ListView2.Items.Item(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).EnsureVisible()
        Else
            Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/OK"))
            m.ShowDialog(Form1)
        End If
    End Sub

    Sub 选中未安装()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.2") Then
                Form1.ListView2.Items.Item(i).Selected = True
            Else
                Form1.ListView2.Items.Item(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).EnsureVisible()
        Else
            Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/OK"))
            m.ShowDialog(Form1)
        End If
    End Sub

    Sub 选中更新可用()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.UpdateAvailable") Then
                Form1.ListView2.Items.Item(i).Selected = True
            Else
                Form1.ListView2.Items.Item(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).EnsureVisible()
        Else
            Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/OK"))
            m.ShowDialog(Form1)
        End If
    End Sub

    Sub 选中已有新的()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.YouInstalledNewOne") Then
                Form1.ListView2.Items.Item(i).Selected = True
            Else
                Form1.ListView2.Items.Item(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).EnsureVisible()
        Else
            Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/OK"))
            m.ShowDialog(Form1)
        End If
    End Sub

    Sub 选中在线更新可用()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DynamicText/InstallStatus.OnlineUpdateAvailable") Then
                Form1.ListView2.Items.Item(i).Selected = True
            Else
                Form1.ListView2.Items.Item(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).EnsureVisible()
        Else
            Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/OK"))
            m.ShowDialog(Form1)
        End If
    End Sub

    Sub 全局筛选已安装()
        Form1.ListView2.Items.Clear()
        当前项列表中项的分类集合 = {}
        重置模组信息显示()
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(检查并返回当前所选子库路径(False))
        For Each mDir In mDirInfo.GetDirectories
            Dim mDir2 As IO.DirectoryInfo
            Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
            For Each mDir2 In mDirInfo2.GetDirectories
                Dim a As New SMUI.Windows.Core.ItemInfoReader
                a.ReadItemInfo(mDir2.FullName, New Windows.Core.Objects.ItemCalculateType With {.InstallStatus = True}, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
                If a.ErrorString <> "" Then
                    Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, a.ErrorString)
                    m.ShowDialog(Form1)
                ElseIf a.InstallStatus = Windows.Core.Objects.InstallStatus.Installed Then
                    Form1.ListView2.Items.Add(mDir2.Name)
                    ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
                    当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = IO.Path.GetFileName(IO.Path.GetDirectoryName(mDir2.FullName))
                End If
            Next
        Next
        'ST1.是否处于搜索筛选结果 = True
        刷新项列表数据()
    End Sub

    Sub 全局筛选未安装()
        Form1.ListView2.Items.Clear()
        重置模组信息显示()
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(检查并返回当前所选子库路径(False))
        For Each mDir In mDirInfo.GetDirectories
            Dim mDir2 As IO.DirectoryInfo
            Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
            For Each mDir2 In mDirInfo2.GetDirectories
                Dim a As New SMUI.Windows.Core.ItemInfoReader
                a.ReadItemInfo(mDir2.FullName, New Windows.Core.Objects.ItemCalculateType With {.InstallStatus = True}, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
                If a.ErrorString <> "" Then
                    Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, a.ErrorString)
                    m.ShowDialog(Form1)
                ElseIf a.InstallStatus = Windows.Core.Objects.InstallStatus.UnInstalled Then
                    Form1.ListView2.Items.Add(mDir2.Name)
                    ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
                    当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = IO.Path.GetFileName(IO.Path.GetDirectoryName(mDir2.FullName))
                End If
            Next
        Next
        刷新项列表数据()
    End Sub

    Sub 全局筛选文件夹()
        Form1.ListView2.Items.Clear()
        重置模组信息显示()
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(检查并返回当前所选子库路径(False))
        For Each mDir In mDirInfo.GetDirectories
            Dim mDir2 As IO.DirectoryInfo
            Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
            For Each mDir2 In mDirInfo2.GetDirectories
                Dim a As New SMUI.Windows.Core.ItemInfoReader
                a.ReadItemInfo(mDir2.FullName, New Windows.Core.Objects.ItemCalculateType With {.InstallStatus = True}, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
                If a.ErrorString <> "" Then
                    Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, a.ErrorString)
                    m.ShowDialog(Form1)
                Else
                    Select Case a.InstallStatus
                        Case Windows.Core.Objects.InstallStatus.AdditionalContent, Windows.Core.Objects.InstallStatus.FolderCopied, Windows.Core.Objects.InstallStatus.FolderNotCopied, Windows.Core.Objects.InstallStatus.CoverContent
                            Form1.ListView2.Items.Add(mDir2.Name)
                            ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
                            当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = IO.Path.GetFileName(IO.Path.GetDirectoryName(mDir2.FullName))
                    End Select
                End If
            Next
        Next
        刷新项列表数据()
    End Sub

    Sub 全局筛选文件()
        Form1.ListView2.Items.Clear()
        重置模组信息显示()
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(检查并返回当前所选子库路径(False))
        For Each mDir In mDirInfo.GetDirectories
            Dim mDir2 As IO.DirectoryInfo
            Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
            For Each mDir2 In mDirInfo2.GetDirectories
                Dim a As New SMUI.Windows.Core.ItemInfoReader
                a.ReadItemInfo(mDir2.FullName, New Windows.Core.Objects.ItemCalculateType With {.InstallStatus = True}, xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
                If a.ErrorString <> "" Then
                    Dim m As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, a.ErrorString)
                    m.ShowDialog(Form1)
                Else
                    Select Case a.InstallStatus
                        Case Windows.Core.Objects.InstallStatus.FileCopied, Windows.Core.Objects.InstallStatus.FileNotCopied, Windows.Core.Objects.InstallStatus.FileReplaced, Windows.Core.Objects.InstallStatus.FileNotReplaced, Windows.Core.Objects.InstallStatus.NeedCopyFile
                            Form1.ListView2.Items.Add(mDir2.Name)
                            ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
                            当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = IO.Path.GetFileName(IO.Path.GetDirectoryName(mDir2.FullName))
                    End Select
                End If
            Next
        Next
        刷新项列表数据()
    End Sub

End Module
