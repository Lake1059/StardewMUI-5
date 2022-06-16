Imports SMUI.Windows.PakManager

Public Class Form导出

    Function 选择文件保存位置() As String
        Dim a As New SaveFileDialog
        Select Case Me.Text
            Case 获取动态多语言文本("data/DynamicText/ManageMod.28")
                a.Filter = "Sublibrary package file|*.smuispak"
                a.FileName = 检查并返回当前可用子库路径(False) & ".smuispak"
            Case 获取动态多语言文本("data/DynamicText/ManageMod.29")
                a.Filter = "Category package file|*.smuicpak"
                If Form1.ListView1.SelectedItems.Count > 1 Then
                    a.FileName = Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(0)).Text & " etc. " & Form1.ListView1.SelectedItems.Count & " categories.smuicpak"
                Else
                    a.FileName = Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(0)).Text & ".smuicpak"
                End If
            Case 获取动态多语言文本("data/DynamicText/ManageMod.30")
                a.Filter = "Item package file|*.smuimpak"
                If Form1.ListView2.SelectedItems.Count > 1 Then
                    a.FileName = Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).Text & " etc. " & Form1.ListView2.SelectedItems.Count & " items.smuimpak"
                Else
                    a.FileName = Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(0)).Text & ".smuimpak"
                End If
        End Select

        a.AddExtension = True
        Select Case a.ShowDialog()
            Case DialogResult.OK
                Me.DarkTextBox1.Text = a.FileName
                Return a.FileName
            Case Else
                Return ""
        End Select

    End Function

    Private Sub Form导出_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If 选择文件保存位置() = "" Then Me.Close()


    End Sub

    Private Sub DarkButton5_Click(sender As Object, e As EventArgs) Handles DarkButton5.Click
    End Sub
    Private Sub DarkButton6_Click(sender As Object, e As EventArgs) Handles DarkButton6.Click
        Select Case Me.DarkTextBox2.PasswordChar
            Case "●"
                Me.DarkTextBox2.PasswordChar = ""
            Case ""
                Me.DarkTextBox2.PasswordChar = "●"
        End Select
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles DarkButton2.Click
    End Sub
    Private Sub DarkButton2_MouseDown(sender As Object, e As MouseEventArgs) Handles DarkButton2.MouseDown
        If 导入导出密码本.Count = 0 Then Exit Sub
        Dim m As New DarkUI.Controls.DarkContextMenu With {.ShowImageMargin = False, .ShowCheckMargin = False}
        For i = 0 To 导入导出密码本.Count - 1
            AddHandler m.Items.Add(导入导出密码本(i)).Click,
                Sub(s1 As Object, e1 As EventArgs)
                    Me.DarkTextBox2.Text = s1.text
                End Sub
        Next
        Dim mouseX As Integer = MousePosition.X
        Dim mouseY As Integer = MousePosition.Y
        m.Show(mouseX - e.X, mouseY + (Me.DarkButton5.Height - e.Y) + 1)
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If My.Computer.FileSystem.FileExists(Me.DarkTextBox1.Text) = True Then
            Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, 获取动态多语言文本("data/DynamicText/ManageMod.31"),, 500)
            Dim a2 As Integer = a.ShowDialog(Me)

            Select Case a2
                Case -1, 1
                    Exit Sub
                Case 0
                    My.Computer.FileSystem.DeleteFile(Me.DarkTextBox1.Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            End Select
        End If

        Dim str As String = "@echo off" & vbNewLine
        str &= "title " & Me.Text & vbNewLine
        Dim 压缩程序路径 As String = """" & Application.StartupPath & "\7za64\7za.exe" & """"
        str &= 压缩程序路径 & " a " & """" & Me.DarkTextBox1.Text & """" & " "

        Select Case Me.Text
            Case 获取动态多语言文本("data/DynamicText/ManageMod.28")
                str &= """" & 检查并返回当前可用子库路径(False) & "\" & """" & " "
            Case 获取动态多语言文本("data/DynamicText/ManageMod.29")
                For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                    str &= """" & 检查并返回当前可用子库路径(False) & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\" & """" & " "
                Next
            Case 获取动态多语言文本("data/DynamicText/ManageMod.30")
                For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                    str &= """" & 检查并返回当前可用子库路径(False) & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text & "\" & """" & " "
                Next
        End Select

        If CheckBox1.Checked = True Then
            str &= "-p" & Me.DarkTextBox2.Text & " -mhe"

        End If
        If CheckBox1.Checked = True And CheckBox2.Checked = False Then
            str &= vbNewLine & "echo " & 获取动态多语言文本("data/DynamicText/ManageMod.32")
        End If
        If CheckBox2.Checked = False Then
            str &= vbNewLine & "pause"
        End If
        FileIO.FileSystem.WriteAllText(Path1.应用程序用户数据路径 & "\7za.bat", str, False, System.Text.Encoding.Default)
        Shell(Path1.应用程序用户数据路径 & "\7za.bat", AppWinStyle.NormalFocus)
        Me.Close()
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

    Private Sub Form导出_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Label1.Text = 获取动态多语言文本("data/ExportWindow/A1")
            Me.Label2.Text = 获取动态多语言文本("data/ExportWindow/A2")
            Me.DarkButton4.Text = 获取动态多语言文本("data/ExportWindow/A3")
            Me.CheckBox2.Text = 获取动态多语言文本("data/ExportWindow/A4")
            Me.CheckBox1.Text = 获取动态多语言文本("data/ExportWindow/A5")
            Me.DarkButton1.Text = 获取动态多语言文本("data/ExportWindow/A6")
            Me.CheckBox1.Left = Me.CheckBox2.Left
        End If
    End Sub
End Class