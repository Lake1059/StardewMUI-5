Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI.GUI.Class1

Public Class Form依赖项表

    Sub 二级按钮鼠标移上事件(sender As Object, e As EventArgs) Handles Label依赖表项菜单.MouseEnter, Label3.MouseEnter, Label1.MouseEnter
        sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Sub 二级按钮鼠标移走事件(sender As Object, e As EventArgs) Handles Label依赖表项菜单.MouseLeave, Label3.MouseLeave, Label1.MouseLeave
        sender.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
    End Sub

    Private Sub Form依赖项表_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Text = 获取动态多语言文本("data/DependenciesListWindow/Title")
            Me.Label依赖表项菜单.Text = 获取动态多语言文本("data/DependenciesListWindow/A1")
            Me.Label3.Text = 获取动态多语言文本("data/DependenciesListWindow/A2")
            Me.Label3.Width = xml_lang.SelectSingleNode("data/DependenciesListWindow/A2").Attributes.GetNamedItem("width").InnerText
            Me.Label1.Text = 获取动态多语言文本("data/DependenciesListWindow/A3")
            Me.Label1.Width = xml_lang.SelectSingleNode("data/DependenciesListWindow/A3").Attributes.GetNamedItem("width").InnerText
            Me.复制此项的名称ToolStripMenuItem.Text = 获取动态多语言文本("data/DependenciesListWindow/A4")
            Me.复制整个列表ToolStripMenuItem.Text = 获取动态多语言文本("data/DependenciesListWindow/A5")
        End If
        Me.ListView1.ForeColor = Color1.白色
    End Sub

    Private Sub Form依赖项表_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        刷新前置表项()
    End Sub

    Public Sub 刷新前置表项()
        Me.ListView1.Items.Clear()
        For i = 0 To 当前项信息_内容包列表.Count - 1
            Me.ListView1.Items.Add(当前项信息_内容包列表(i))
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DependenciesListWindow/S1"))
        Next
        For i = 0 To 当前项信息_依赖项列表.Count - 1
            For i2 = 0 To 当前项信息_内容包列表.Count - 1
                If 当前项信息_依赖项列表(i).ToLower = 当前项信息_内容包列表(i2).ToLower Then GoTo jx1
            Next
            Me.ListView1.Items.Add(当前项信息_依赖项列表(i))
            If 当前项信息_依赖项必须性列表(i) = True Then
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DependenciesListWindow/S2"))
            Else
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DependenciesListWindow/S3"))
            End If
jx1:
        Next
        For i = 0 To Me.ListView1.Items.Count - 1
            Me.ListView1.Items.Item(i).SubItems.Add("")
        Next
        Me.Label2.Text = Me.ListView1.Items.Count
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        刷新前置表项()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        If Me.BackgroundWorker1.IsBusy Then Exit Sub
        For i = 0 To Me.ListView1.Items.Count - 1 '清除列表所有状态信息
            Me.ListView1.Items.Item(i).SubItems(2).Text = ""
        Next
        文件集合 = {}
        Me.Text = 获取动态多语言文本("data/DependenciesListWindow/S4")
        Application.DoEvents()
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Dim 文件集合 As String() = {}

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim a As New SMUI.Windows.Core.SearchFile
        a.SearchManifests(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods")
        文件集合 = a.FileCollection
        e.Result = a.ErrorString
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Result = "" Then
            Me.Text = 获取动态多语言文本("data/DependenciesListWindow/S5")
            Application.DoEvents()
            For i = 0 To 文件集合.Count - 1
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(My.Computer.FileSystem.ReadAllText(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & 文件集合(i))), JObject)
                If JsonData.item("UniqueID") IsNot Nothing Then
                    For i2 = 0 To Me.ListView1.Items.Count - 1 '循环前置列表中的所有项
                        If Me.ListView1.Items.Item(i2).Text.ToUpper.Replace(" ", "") = JsonData.item("UniqueID").ToString.ToUpper.Replace(" ", "") Then '如果当前项和处理后的前置对象文本相同
                            Me.ListView1.Items.Item(i2).SubItems(2).Text = 获取动态多语言文本("data/DependenciesListWindow/S6")
                            Me.ListView1.Items.Item(i2).ForeColor = Color1.绿色
                            Exit For
                        End If
                    Next
                End If
            Next

            For i = 0 To Me.ListView1.Items.Count - 1 '把没有文本的项写成未安装状态
                If Me.ListView1.Items.Item(i).SubItems(2).Text = "" Then
                    If Me.ListView1.Items.Item(i).SubItems(1).Text = 获取动态多语言文本("data/DependenciesListWindow/S3") Then
                        Me.ListView1.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DependenciesListWindow/S7")
                        Me.ListView1.Items.Item(i).ForeColor = Color1.白色
                    Else
                        Me.ListView1.Items.Item(i).SubItems(2).Text = 获取动态多语言文本("data/DependenciesListWindow/S7")
                        Me.ListView1.Items.Item(i).ForeColor = Color1.红色
                    End If
                End If
            Next
            Me.Text = 获取动态多语言文本("data/DependenciesListWindow/Title")
        Else
            MsgBox(e.Result, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub 复制此项的名称ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制此项的名称ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Clipboard.SetText(Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(0)).Text)
    End Sub

    Private Sub 复制整个列表ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制整个列表ToolStripMenuItem.Click
        Dim a As String = ""
        For i = 0 To Me.ListView1.Items.Count - 1
            If a = "" Then
                a = Me.ListView1.Items.Item(i).Text & " (" & Me.ListView1.Items.Item(i).SubItems(1).Text & ")"
                If Me.ListView1.Items.Item(i).SubItems(2).Text <> "" Then a &= Me.ListView1.Items.Item(i).SubItems(2).Text
            Else
                a &= vbNewLine & Me.ListView1.Items.Item(i).Text & " (" & Me.ListView1.Items.Item(i).SubItems(1).Text & ")"
                If Me.ListView1.Items.Item(i).SubItems(2).Text <> "" Then a &= Me.ListView1.Items.Item(i).SubItems(2).Text
            End If
        Next
        Clipboard.SetText(a)
    End Sub

    Private Sub Label依赖表项菜单_Click(sender As Object, e As EventArgs) Handles Label依赖表项菜单.Click

    End Sub

    Private Sub Label依赖表项菜单_MouseDown(sender As Object, e As MouseEventArgs) Handles Label依赖表项菜单.MouseDown
        Dim mouseX As Integer = MousePosition.X
        Dim mouseY As Integer = MousePosition.Y
        Me.DarkContextMenu2.Show(mouseX - e.X, mouseY + (Me.Label依赖表项菜单.Height - e.Y) + 1)
    End Sub
End Class