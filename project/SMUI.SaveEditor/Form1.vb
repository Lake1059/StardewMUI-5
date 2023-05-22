Imports System.Xml

Public Class Form1

    ReadOnly wsh As New IWshRuntimeLibrary.IWshShell_Class
    Public 桌面路径 As String = wsh.SpecialFolders.Item("Desktop")
    Public 存档路径 As String = wsh.SpecialFolders.Item("AppData") & "\StardewValley\Saves"

    Private ReadOnly xmldoc1 As New XmlDocument
    Private ReadOnly xmldoc2 As New XmlDocument

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(wsh.SpecialFolders.Item("AppData") & "\1059 Studio\SMUI Client 5 Cache\SaveEditorUserItem") = False Then
            My.Computer.FileSystem.CreateDirectory(wsh.SpecialFolders.Item("AppData") & "\1059 Studio\SMUI Client 5 Cache\SaveEditorUserItem")
        Else
            Dim 文件 As System.IO.FileInfo
            Dim 目录 As New System.IO.DirectoryInfo(wsh.SpecialFolders.Item("AppData") & "\1059 Studio\SMUI Client 5 Cache\SaveEditorUserItem")
            For Each 文件 In 目录.GetFiles("*.*")
                Me.ListView1.Items.Add(IO.Path.GetFileNameWithoutExtension(文件.Name))
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(2)
                Dim line As String() = My.Computer.FileSystem.ReadAllText(文件.FullName).Split(vbNewLine)
                For i = 0 To line.Count - 1
                    If i > 0 Then
                        line(i) = Mid(line(i), 2)
                    End If
                Next
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(line(0))
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(line(1))
            Next
        End If

        For i = 0 To Me.ListView1.Items.Count - 1
            If Me.ListView1.Items.Item(i).SubItems.Count = 3 Then
                Me.ListView1.Items.Item(i).SubItems.Add("")
            End If
        Next
        扫描存档ToolStripMenuItem.PerformClick()
    End Sub

    Private Sub 扫描存档ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 扫描存档ToolStripMenuItem.Click
        Me.ContextMenuStrip1.Items.Clear()
        选择存档ToolStripMenuItem.Text = "选择存档"
        For i = 0 To Me.ListView1.Items.Count - 1
            Me.ListView1.Items.Item(i).SubItems(3).Text = ""
        Next
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(存档路径)
        For Each mDir In mDirInfo.GetDirectories
            Dim a As New ToolStripMenuItem With {
                .Text = mDir.Name
            }
            Me.ContextMenuStrip1.Items.Add(a)
            AddHandler a.Click,
                Sub(s1, e1)
                    选择存档ToolStripMenuItem.Text = s1.Text
                    扫描存档()
                End Sub
        Next
    End Sub

    Sub 扫描存档()
        If My.Computer.FileSystem.DirectoryExists(存档路径 & "\" & 选择存档ToolStripMenuItem.Text) = False Then
            For i = 0 To Me.ListView1.Items.Count - 1
                Me.ListView1.Items.Item(i).SubItems(3).Text = ""
            Next
            Exit Sub
        End If
        xmldoc1.Load(存档路径 & "\" & 选择存档ToolStripMenuItem.Text & "\" & "SaveGameInfo")
        xmldoc2.Load(存档路径 & "\" & 选择存档ToolStripMenuItem.Text & "\" & 选择存档ToolStripMenuItem.Text)
        For i = 0 To Me.ListView1.Items.Count - 1

            Select Case Me.ListView1.Items.Item(i).SubItems(1).Text
                Case "SaveGameInfo"
                    If xmldoc1.SelectSingleNode(Me.ListView1.Items.Item(i).SubItems(2).Text) Is Nothing Then
                        Me.ListView1.Items.Item(i).SubItems(3).Text = "找不到此节点 not found"
                        Continue For
                    End If
                    Me.ListView1.Items.Item(i).SubItems(3).Text = xmldoc1.SelectSingleNode(Me.ListView1.Items.Item(i).SubItems(2).Text).InnerText
                Case "[game]"
                    If xmldoc2.SelectSingleNode(Me.ListView1.Items.Item(i).SubItems(2).Text) Is Nothing Then
                        Me.ListView1.Items.Item(i).SubItems(3).Text = "找不到此节点 not found"
                        Continue For
                    End If
                    Me.ListView1.Items.Item(i).SubItems(3).Text = xmldoc2.SelectSingleNode(Me.ListView1.Items.Item(i).SubItems(2).Text).InnerText
            End Select
        Next
        GC.Collect()
    End Sub

    Private Sub 选择存档ToolStripMenuItem_MouseDown(sender As Object, e As MouseEventArgs) Handles 选择存档ToolStripMenuItem.MouseDown
        Me.ContextMenuStrip1.Show(MousePosition.X - e.X, MousePosition.Y - e.Y + 31)
    End Sub

    Private Sub 修改值ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 修改值ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Select Case Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(1).Text
            Case "SaveGameInfo"
                If xmldoc1.SelectSingleNode(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(2).Text) Is Nothing Then Exit Sub
            Case "[game]"
                If xmldoc2.SelectSingleNode(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(2).Text) Is Nothing Then Exit Sub
        End Select

        Dim a As New SMUI.Windows.PakManager.InputTextDialog("", "New value", Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(3).Text)
        Dim s1 As String = a.ShowDialog(Me)

        If s1 <> "" Then
            Select Case Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(1).Text
                Case "SaveGameInfo"
                    xmldoc1.SelectSingleNode(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(2).Text).InnerText = s1
                Case "[game]"
                    xmldoc2.SelectSingleNode(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(2).Text).InnerText = s1
            End Select
            Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(3).Text = s1
        End If
    End Sub

    Private Sub 复制XML节点路径ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制XML节点路径ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Clipboard.SetText(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).SubItems(2).Text)
    End Sub

    Private Sub 保存存档ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 保存存档ToolStripMenuItem.Click
        If My.Computer.FileSystem.DirectoryExists(存档路径 & "\" & 选择存档ToolStripMenuItem.Text) = True Then
            xmldoc1.Save(存档路径 & "\" & 选择存档ToolStripMenuItem.Text & "\" & "SaveGameInfo")
            xmldoc2.Save(存档路径 & "\" & 选择存档ToolStripMenuItem.Text & "\" & 选择存档ToolStripMenuItem.Text)
            MsgBox("Saved: " & 选择存档ToolStripMenuItem.Text)
        Else
            MsgBox("存档文件夹不存在，无法保存" & vbNewLine & vbNewLine & "Save folder does not exist, cannot save.", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        修改值ToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
