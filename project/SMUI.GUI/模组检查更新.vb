Module 模组检查更新

    Public Sub 模组检查更新_添加一个分类的数据到列表中(分类的完整路径 As String)
        Dim p As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(分类的完整路径)
        For i = 0 To p.Count - 1
            模组检查更新_添加一个项的数据到列表中(分类的完整路径 & "\" & p(i))
        Next
    End Sub

    Public Sub 模组检查更新_添加一个项的数据到列表中(项的完整路径 As String)
        Dim a As New SMUI.Windows.Core.ItemInfoReader
        Dim b As New SMUI.Windows.Core.Objects.ItemCalculateType With {
            .UniqueID = True,
            .UpdateKeys = True,
            .Version = True
        }
        a.ReadItemInfo(项的完整路径, b)
        For i = 0 To a.UniqueID.Count - 1
            Form模组检查更新操作台.ListView1.Items.Add(a.UniqueID(i))
            Form模组检查更新操作台.ListView1.Items(Form模组检查更新操作台.ListView1.Items.Count - 1).SubItems.Add(a.NexusID.FirstOrDefault)
            Form模组检查更新操作台.ListView1.Items(Form模组检查更新操作台.ListView1.Items.Count - 1).SubItems.Add(a.Version.FirstOrDefault)
            Form模组检查更新操作台.ListView1.Items(Form模组检查更新操作台.ListView1.Items.Count - 1).SubItems.Add("")
        Next

    End Sub

    Public Sub 模组检查更新_扫描当前子库查找所有项(UniqueID表 As String(), 模组名称表 As String())

    End Sub




End Module
