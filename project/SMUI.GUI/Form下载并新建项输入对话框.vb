Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form下载并新建项输入对话框
    Private Sub Form下载并新建项输入对话框_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a1 As String = Me.DarkComboBox1.Text
        Me.DarkComboBox1.Items.Clear()
        Dim k1 As String = 检查并返回当前可用子库路径(False)
        If k1 = "" Then
            Me.Close()
            Exit Sub
        End If
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Text = 获取动态多语言文本("data/DownloadAndCreateItemWindow/Title")
            Me.Label1.Text = 获取动态多语言文本("data/DownloadAndCreateItemWindow/A1")
            Me.Label3.Text = 获取动态多语言文本("data/DownloadAndCreateItemWindow/A2")
            Me.Label2.Text = 获取动态多语言文本("data/DownloadAndCreateItemWindow/A3")
            Me.DarkButton1.Text = 获取动态多语言文本("data/DownloadAndCreateItemWindow/A4")
        End If

        Dim s1 As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(k1)
        For i = 0 To s1.Count - 1
            Me.DarkComboBox1.Items.Add(s1(i))
        Next
        If My.Computer.FileSystem.DirectoryExists(k1 & "\" & a1) = True Then
            Me.DarkComboBox1.Text = a1
        Else
            Me.DarkComboBox1.Text = ""
        End If
        Me.DarkComboBox1.DropDownHeight = s1.Count * Me.DarkComboBox1.ItemHeight
    End Sub

    Private Sub Form下载并新建项输入对话框_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.DarkComboBox1.Refresh()
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If My.Computer.FileSystem.DirectoryExists(检查并返回当前选择分类路径(False) & "\" & Me.DarkTextBox1.Text) = True Then
            Dim b As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/ManageMod.6"),, 500)
            b.ShowDialog(Me)
            Exit Sub
        End If
        If IsNumeric(Me.DarkTextBox2.Text) = False Then Exit Sub
        If Me.DarkComboBox1.Text = "" Then Exit Sub

        ST1.当前正在进行新建项的项名称 = Me.DarkTextBox1.Text
        ST1.当前正在进行新建项的目标分类 = Me.DarkComboBox1.Text
        ST1.当前正在进行直接更新的操作类型 = 在线更新操作类型.新建项
        ST1.当前正在进行更新的单个项的N网ID = Me.DarkTextBox2.Text
        Me.Close()
        显示模式窗体(Form直接联网更新单个项, Form1)

    End Sub


End Class