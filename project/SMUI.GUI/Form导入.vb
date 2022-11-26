Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form导入

    Private Sub Form导入_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
            Me.激活拖拽ToolStripMenuItem.Visible = True
        End If


    End Sub

    Private Sub Form导入_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.ColumnHeader1.Width = Me.ListView1.Width - 30
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
            Dim files As String() = e.Data.GetData(GetType(String()))
            For x = 0 To files.Count - 1
                Select Case Me.Text
                    Case 获取动态多语言文本("data/DynamicText/ManageMod.25")
                        If IO.Path.GetExtension(files(x)).ToLower <> ".smuispak" Then Continue For
                    Case 获取动态多语言文本("data/DynamicText/ManageMod.26")
                        If IO.Path.GetExtension(files(x)).ToLower <> ".smuicpak" Then Continue For
                    Case 获取动态多语言文本("data/DynamicText/ManageMod.27")
                        If IO.Path.GetExtension(files(x)).ToLower <> ".smuimpak" Then Continue For
                End Select
                For i = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items.Item(i).Text = files(x) Then
                        GoTo jx1
                    End If
                Next
                Me.ListView1.Items.Add(files(x))
jx1:
            Next
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
            Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
            For x = 0 To files.Count - 1
                Select Case Me.Text
                    Case 获取动态多语言文本("data/DynamicText/ManageMod.25")
                        If IO.Path.GetExtension(files(x)).ToLower <> ".smuispak" Then Continue For
                    Case 获取动态多语言文本("data/DynamicText/ManageMod.26")
                        If IO.Path.GetExtension(files(x)).ToLower <> ".smuicpak" Then Continue For
                    Case 获取动态多语言文本("data/DynamicText/ManageMod.27")
                        If IO.Path.GetExtension(files(x)).ToLower <> ".smuimpak" Then Continue For
                End Select
                For i = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items.Item(i).Text = files(x) Then
                        GoTo jx1
                    End If
                Next
                Me.ListView1.Items.Add(files(x))
jx1:
            Next
        End If
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles DarkButton2.Click
        Dim a As New OpenFileDialog
        Select Case Me.Text
            Case 获取动态多语言文本("data/DynamicText/ManageMod.25")
                a.Filter = "Sublibrary package file|*.smuispak"
            Case 获取动态多语言文本("data/DynamicText/ManageMod.26")
                a.Filter = "Category package file|*.smuicpak"
            Case 获取动态多语言文本("data/DynamicText/ManageMod.27")
                a.Filter = "Item package file|*.smuimpak"
        End Select
        a.Multiselect = True
        a.ShowDialog()
        If a.FileName = "" Then Exit Sub
        For i3 = 0 To a.FileNames.Count - 1
            For i = 0 To Me.ListView1.Items.Count - 1
                If Me.ListView1.Items.Item(i).Text = a.FileNames(i3) Then
                    GoTo jx1
                End If
            Next
            Me.ListView1.Items.Add(a.FileNames(i3))
jx1:
        Next
    End Sub

    Private Sub DarkButton3_Click(sender As Object, e As EventArgs) Handles DarkButton3.Click
        Dim i As Integer = 0
        Do Until i = Me.ListView1.Items.Count
            If Me.ListView1.Items.Item(i).Selected = True Then
                Me.ListView1.Items.Item(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Private Sub DarkButton4_Click(sender As Object, e As EventArgs) Handles DarkButton4.Click
        If My.Computer.FileSystem.FileExists(Path1.应用程序用户数据路径 & "\Keys.dat") = False Then
            Dim a As New SingleSelectionDialog("", {"OK"}, "No file.")
            a.ShowDialog()
        Else
            My.Computer.FileSystem.DeleteFile(Path1.应用程序用户数据路径 & "\Keys.dat", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            导入导出密码本 = {}
            Dim a As New SingleSelectionDialog("", {"OK"}, "Deleted.")
            a.ShowDialog()
        End If
    End Sub

    Private Sub DarkButton6_Click(sender As Object, e As EventArgs) Handles DarkButton6.Click
        Select Case Me.DarkTextBox1.PasswordChar
            Case "●"
                Me.DarkTextBox1.PasswordChar = ""
            Case ""
                Me.DarkTextBox1.PasswordChar = "●"
        End Select
    End Sub

    Private Sub DarkButton5_Click(sender As Object, e As EventArgs) Handles DarkButton5.Click

    End Sub
    Private Sub DarkButton5_MouseDown(sender As Object, e As MouseEventArgs) Handles DarkButton5.MouseDown
        If 导入导出密码本.Count = 0 Then Exit Sub
        Dim m As New DarkUI.Controls.DarkContextMenu With {.ShowImageMargin = False, .ShowCheckMargin = False}
        For i = 0 To 导入导出密码本.Count - 1
            AddHandler m.Items.Add(导入导出密码本(i)).Click,
                Sub(s1 As Object, e1 As EventArgs)
                    Me.DarkTextBox1.Text = s1.text
                End Sub
        Next
        Dim mouseX As Integer = MousePosition.X
        Dim mouseY As Integer = MousePosition.Y
        m.Show(mouseX - e.X, mouseY + (Me.DarkButton5.Height - e.Y) + 1)
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        Dim str As String = "@echo off" & vbNewLine
        str &= "title " & Me.Text & vbNewLine
        Dim 压缩程序路径 As String = """" & Application.StartupPath & "\7za64\7za.exe" & """"

        Select Case Me.Text
            Case 获取动态多语言文本("data/DynamicText/ManageMod.25")
                For i = 0 To Me.ListView1.Items.Count - 1
                    str &= vbNewLine & 压缩程序路径 & " x " & """" & Me.ListView1.Items.Item(i).Text & """" & " -o" & """" & 检查并返回当前模组数据仓库路径(False) & """"
                    If CheckBox1.Checked = True Then
                        添加导入导出密码到密码本中(Me.DarkTextBox1.Text)
                        str &= " -p" & Me.DarkTextBox1.Text & " -y"
                    End If
                Next
            Case 获取动态多语言文本("data/DynamicText/ManageMod.26")
                For i = 0 To Me.ListView1.Items.Count - 1
                    str &= vbNewLine & 压缩程序路径 & " x " & """" & Me.ListView1.Items.Item(i).Text & """" & " -o" & """" & 检查并返回当前所选子库路径(False) & """"
                    If CheckBox1.Checked = True Then
                        添加导入导出密码到密码本中(Me.DarkTextBox1.Text)
                        str &= " -p" & Me.DarkTextBox1.Text & " -y"
                    End If
                Next
            Case 获取动态多语言文本("data/DynamicText/ManageMod.27")
                For i = 0 To Me.ListView1.Items.Count - 1
                    str &= vbNewLine & 压缩程序路径 & " x " & """" & Me.ListView1.Items.Item(i).Text & """" & " -o" & """" & 检查并返回当前所选子库路径(False) & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(0)).Text & """"
                    If CheckBox1.Checked = True Then
                        添加导入导出密码到密码本中(Me.DarkTextBox1.Text)
                        str &= " -p" & Me.DarkTextBox1.Text & " -y"
                    End If
                Next
        End Select

        If CheckBox2.Checked = False Then
            str &= vbNewLine & "pause"
        End If
        FileIO.FileSystem.WriteAllText(Path1.应用程序用户数据路径 & "\7za.bat", str, False, System.Text.Encoding.Default)
        Shell(Path1.应用程序用户数据路径 & "\7za.bat", AppWinStyle.NormalFocus)
        Me.ListView1.Items.Clear()
    End Sub

    Private Sub 激活拖拽ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 激活拖拽ToolStripMenuItem.Click
        FileDroper.Dispose()
        FileDroper = New WindowsMF.Class1.FileDropHandler(Me.ListView1)
    End Sub

    Private Sub Form导入_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.DarkButton2.Text = 获取动态多语言文本("data/ImportWindow/A1")
            Me.DarkButton3.Text = 获取动态多语言文本("data/ImportWindow/A2")
            Me.DarkButton4.Text = 获取动态多语言文本("data/ImportWindow/A3")
            Me.CheckBox2.Text = 获取动态多语言文本("data/ImportWindow/A4")
            Me.CheckBox1.Text = 获取动态多语言文本("data/ImportWindow/A5")
            Me.DarkButton1.Text = 获取动态多语言文本("data/ImportWindow/A6")
            Me.CheckBox1.Left = Me.CheckBox2.Left
        End If


    End Sub
End Class