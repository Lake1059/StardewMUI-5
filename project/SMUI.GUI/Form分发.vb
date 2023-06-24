Imports System.Security.Cryptography
Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form分发
    Private Sub Form分发_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(Path1.分发预设目录) = False Then
            My.Computer.FileSystem.CreateDirectory(Path1.分发预设目录)
        End If
    End Sub

    Private Sub Form分发_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form分发_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ListView1.Width = Me.Panel2.Width + ST1.系统滚动条宽度
        Me.ListView1.Columns.Item(0).Width = Me.ListView1.Width - 5 - ST1.系统滚动条宽度
        Me.ListView2.Width = Me.Panel4.Width + ST1.系统滚动条宽度
        Me.ListView2.Columns.Item(0).Width = Me.ListView2.Width - 5 - ST1.系统滚动条宽度
        Me.ListView3.Width = Me.Panel5.Width + ST1.系统滚动条宽度
        Me.ListView3.Columns.Item(0).Width = Me.ListView3.Width - 5 - ST1.系统滚动条宽度
        刷新预设ToolStripMenuItem.PerformClick()


    End Sub

    Private Sub Form分发_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.ListView3.Width = Me.Panel5.Width + ST1.系统滚动条宽度
            Me.ListView3.Columns.Item(0).Width = Me.ListView3.Width - 5 - ST1.系统滚动条宽度
        End If
    End Sub

    Private Sub Label预设菜单_Click(sender As Object, e As EventArgs) Handles Label预设菜单.Click

    End Sub

    Private Sub Label预设菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label预设菜单.MouseDown
        Dim mouseX As Integer = MousePosition.X
        Dim mouseY As Integer = MousePosition.Y
        If Me.DCM1.Width >= Me.Panel3.Width Then
            Me.DCM1.Show(mouseX - e.X - 1, mouseY + (Me.DCM1.Height - e.Y) + 1)
        Else
            Me.DCM1.Show(mouseX - e.X + (Me.Label预设菜单.Width - Me.DCM1.Width) + 1, mouseY + (Me.Label预设菜单.Height - e.Y) + 1)
        End If
    End Sub

    Private Sub 刷新预设ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新预设ToolStripMenuItem.Click
        Me.ListView1.Items.Clear()
        Me.ListView2.Items.Clear()
        Me.ListView3.Items.Clear()
        Dim a As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(Path1.分发预设目录)
        For i = 0 To a.Count - 1
            Me.ListView1.Items.Add(a(i))
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub 新增预设ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 新增预设ToolStripMenuItem.Click
        Dim a As New InputTextDialog("", 获取动态多语言文本("data/DistributionManagerWindow/S1"))
        Dim b As String = ""
R1:     b = a.ShowDialog(Me)
        If b = "" Then Exit Sub
        If My.Computer.FileSystem.DirectoryExists(Path1.分发预设目录 & "\" & b) Then
            Dim c As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DistributionManagerWindow/S2"),, 500)
            GoTo R1
        End If
        My.Computer.FileSystem.CreateDirectory(Path1.分发预设目录 & "\" & b)
        Me.ListView1.Items.Add(b)
    End Sub

    Private Sub 重命名预设ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重命名预设ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As New InputTextDialog("", 获取动态多语言文本("data/DistributionManagerWindow/S3") & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text, Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text)
        Dim b As String = ""
R1:     b = a.ShowDialog(Me)
        If b = "" Then Exit Sub
        If My.Computer.FileSystem.DirectoryExists(Path1.分发预设目录 & "\" & b) Then
            Dim c As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DistributionManagerWindow/S2"),, 500)
            GoTo R1
        End If
        My.Computer.FileSystem.RenameDirectory(Path1.分发预设目录 & "\" & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text, b)
        Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text = b
    End Sub

    Private Sub 删除预设ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除预设ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count = 0 Then Exit Sub
        Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DistributionManagerWindow/S4"),, 500)
        Dim b As Integer = a.ShowDialog(Me)
        If b <> 0 Then Exit Sub
        Dim i As Integer = 0
        Do Until i = Me.ListView1.Items.Count
            If Me.ListView1.Items.Item(i).Selected = True Then
                My.Computer.FileSystem.DeleteDirectory(Path1.分发预设目录 & "\" & Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Private Sub 克隆预设ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 克隆预设ToolStripMenuItem.Click

    End Sub

    Private Sub 运行预设ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 运行预设ToolStripMenuItem.Click

    End Sub
End Class