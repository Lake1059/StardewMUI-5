Imports SMUI.GUI.Class1

Module 设置颜色
    Public Sub 设置分类颜色_白色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            If My.Computer.FileSystem.FileExists(a) = True Then
                My.Computer.FileSystem.DeleteFile(a)
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.白色
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 0
            End If
        Next
    End Sub

    Public Sub 设置分类颜色_红色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "RED", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.红色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 1
        Next
    End Sub

    Public Sub 设置分类颜色_橙色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "ORANGE", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.橙色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 2
        Next
    End Sub

    Public Sub 设置分类颜色_黄色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "YELLOW", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.黄色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 3
        Next
    End Sub

    Public Sub 设置分类颜色_绿色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "GREEN", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.绿色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 4
        Next
    End Sub

    Public Sub 设置分类颜色_青色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "AQUA", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.青色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 5
        Next
    End Sub

    Public Sub 设置分类颜色_蓝色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "BLUE", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.蓝色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 6
        Next
    End Sub

    Public Sub 设置分类颜色_紫色()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim x As String = 检查并返回当前所选子库路径()
            If x = "" Then Exit Sub
            Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Color"
            My.Computer.FileSystem.WriteAllText(a, "PURPLE", False)
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).ForeColor = Color1.紫色
            Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).StateImageIndex = 7
        Next
    End Sub
End Module
