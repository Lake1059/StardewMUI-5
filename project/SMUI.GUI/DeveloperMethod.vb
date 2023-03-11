Imports SMUI.GUI.Class1

Public Class DeveloperMethod

    Public Shared Sub RegisterPluginLogo(assemblyName As String, img As Image)
        Dim a As Integer = Array.IndexOf(插件数据.插件程序集名称列表, assemblyName)
        If a < 0 Then Exit Sub
        插件数据.插件logo列表(a) = img
    End Sub

    Public Shared Sub RegisterPluginDescription(assemblyName As String, text As String)
        Dim a As Integer = Array.IndexOf(插件数据.插件程序集名称列表, assemblyName)
        If a < 0 Then Exit Sub
        插件数据.插件简要描述列表(a) = text
    End Sub

    Public Class GetSettings
        Public Shared Function GetStardewValleyGamePath() As String
            Return xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText
        End Function

        Public Shared Function GetModRepositoryPath() As String
            Return xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText
        End Function

        Public Shared Function GetCurrentSubLibrary() As String
            Return 检查并返回当前所选子库路径(False)
        End Function

        Public Shared Function GetInterfaceLanguage() As String
            Return xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText
        End Function

        Public Shared Function IsUsingCustomLanguage() As Boolean
            Return ST1.是否正在使用自定义语言包
        End Function


    End Class

    Public Class GetStates

        Public Shared Function GetCurrentUserIdentityGroup() As Security.Principal.WindowsBuiltInRole
            Return ST1.当前用户身份组
        End Function

    End Class

    Public Class GetData
        Public Shared Function GetCategoryList() As String()
            Dim a As String() = {}
            For i = 0 To Form1.ListView1.Items.Count - 1
                ReDim Preserve a(a.Count)
                a(a.Count - 1) = Form1.ListView1.Items.Item(i).Text
            Next
            Return a
        End Function

        Public Shared Function GetItemList() As String()
            Dim a As String() = {}
            For i = 0 To Form1.ListView2.Items.Count - 1
                ReDim Preserve a(a.Count)
                a(a.Count - 1) = Form1.ListView2.Items.Item(i).Text
            Next
            Return a
        End Function

        Public Shared Function FindCategoryInList(yourCategoryText As String) As Boolean
            If Form1.ListView1.Items.Find(yourCategoryText, False).Count <> 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Shared Function GetItemListBelongCategory() As String()
            Return 当前项列表中项的分类集合
        End Function

        Public Shared Function GetCurrentSelectCategory() As String()
            If Form1.ListView1.SelectedItems.Count = 0 Then
                Return {} : Exit Function
            End If
            Dim a As String() = {}
            For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                ReDim Preserve a(a.Count)
                a(a.Count - 1) = Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text
            Next
            Return a
        End Function

        Public Shared Function GetCurrentSelectCategoryCount() As Integer
            Return Form1.ListView1.SelectedItems.Count
        End Function

        Public Shared Function GetCurrentSelectItem() As String()
            If Form1.ListView2.SelectedItems.Count = 0 Then
                Return {} : Exit Function
            End If
            Dim a As String() = {}
            For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                ReDim Preserve a(a.Count)
                a(a.Count - 1) = Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text
            Next
            Return a
        End Function

        Public Shared Function GetCurrentSelectItemCount() As Integer
            Return Form1.ListView2.SelectedItems.Count
        End Function

    End Class

    Public Class AddMenuItem

        Public Shared Sub AddItemToCategoryMenu(yourToolStripMenuItem As ToolStripMenuItem)
            Form1.ToolStripSeparator26.Visible = True
            Form1.DCM1.Items.Add(yourToolStripMenuItem)
        End Sub

        Public Shared Sub AddItemToSubLibraryMenu(yourToolStripMenuItem As ToolStripMenuItem)
            Form1.ToolStripSeparator35.Visible = True
            Form1.DCM2.Items.Add(yourToolStripMenuItem)
        End Sub

        Public Shared Sub AddItemToItemMenu(yourToolStripMenuItem As ToolStripMenuItem)
            Form1.ToolStripSeparator15.Visible = True
            Form1.DCM6.Items.Add(yourToolStripMenuItem)
        End Sub



    End Class

    Public Class UserSkin

        Public Shared Function GetStartPanelCenterPanelSize() As Size
            Return Form1.Panel4.Size
        End Function

        Public Shared Sub AddImageToStartPanelCenterPanel(img As Image, Optional laypout As ImageLayout = ImageLayout.None)
            If DLC解锁状态.DLC2 = False Then Exit Sub
            Form1.Panel4.BackgroundImage = img
            Form1.Panel4.BackgroundImageLayout = laypout
        End Sub

        Public Shared Function GetManagePanelCategoryListviewSize() As Size
            Return Form1.ListView1.Size
        End Function

        Public Shared Sub AddImageToManagePanelCategoryListview(img As Image)
            If DLC解锁状态.DLC2 = False Then Exit Sub
            Form1.ListView1.BackgroundImage = img
        End Sub

        Public Shared Function GetManagePanelItemListviewSize() As Size
            Return Form1.ListView2.Size
        End Function

        Public Shared Sub AddImageToManagePanelItemListview(img As Image)
            If DLC解锁状态.DLC2 = False Then Exit Sub
            Form1.ListView2.BackgroundImage = img
        End Sub

    End Class

    Public Class CreatorFreePanel

        Public Shared Sub AddPanel(yourpanel As Panel)
            yourpanel.Dock = DockStyle.Top
            Form1.Panel创作者自由面板.Controls.Add(yourpanel)
        End Sub


    End Class

End Class