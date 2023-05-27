Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form批量创建
    Private Sub Form批量创建_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Text = 获取动态多语言文本("data/BulkCreateItemWindow/Title")
            Me.RadioButton1.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A1")
            Me.RadioButton2.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A2")
            Me.DarkButton1.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A3")
            Me.Label1.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A6")
            Me.Label2.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A4")
            Me.Label3.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A5")

            Me.打开文件夹ToolStripMenuItem.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A7")
            Me.删除ToolStripMenuItem.Text = 获取动态多语言文本("data/BulkCreateItemWindow/A8")

            Me.Label3.Left = Me.DarkComboBox1.Left + Me.DarkComboBox1.Width - Me.Label3.Width

        End If


    End Sub

    Private Sub Form批量创建_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim s1 As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText & "\" & xml_Settings.SelectSingleNode("data/LastUsedSubLibraryName").InnerText)
        For i = 0 To s1.Count - 1
            Me.DarkComboBox1.Items.Add(s1(i))
        Next

        Dim s2 As String() = SMUI.Windows.Core.SharedFunction.SearchFolderWithoutSub(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods")
        '这里已经有斜杠了，下边的拼接不要加
        Dim str2 As String = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\"
        For i = 0 To s2.Count - 1
            Select Case s2(i)
                Case "ConsoleCommands", "ErrorHandler", "SaveBackup"
                    Continue For
            End Select

            Me.ListView1.Items.Add(s2(i))
            If My.Computer.FileSystem.FileExists(str2 & s2(i) & "\manifest.json") = True Then
                Dim b As String = ""
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(My.Computer.FileSystem.ReadAllText(str2 & s2(i) & "\manifest.json")), JObject)
                If JsonData.item("EntryDll") IsNot Nothing Then
                    b &= "EntryDll - "
                Else
                    b &= "Content Pak - "
                End If
                If JsonData.item("Version") IsNot Nothing Then
                    b &= "v" & JsonData.item("Version").ToString
                Else
                    b &= "unknow"
                End If
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(b)
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/BulkCreateItemWindow/DS.8"))
            Else
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/BulkCreateItemWindow/DS.7"))
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/BulkCreateItemWindow/DS.9"))
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).ForeColor = Color1.红色
            End If
        Next



    End Sub

    Private Sub Form批量创建_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.ColumnHeader1.Width = Me.ListView1.Width - Me.ColumnHeader2.Width - Me.ColumnHeader3.Width - 30
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        '检查选没选操作类型
        If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False Then
            Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/BulkCreateItemWindow/DS.4"), 100, 500)
            a.ShowDialog(Me) : Exit Sub
        End If
        '检查是不是选了创建一个项但没填项名称
        If Me.RadioButton2.Checked = True And Me.DarkTextBox1.Text = "" Then
            Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/BulkCreateItemWindow/DS.2"), 100, 500)
            a.ShowDialog(Me) : Exit Sub
        End If
        '检查选没选分类
        If Me.DarkComboBox1.Text = "" Then
            Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/BulkCreateItemWindow/DS.5"), 100, 500)
            a.ShowDialog(Me) : Exit Sub
        End If

        Dim d1 As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/Cancel")}, 获取动态多语言文本("data/BulkCreateItemWindow/DS.1"), 100, 500)
        Dim back1 As Integer = d1.ShowDialog(Me)
        If back1 <> 0 Then Exit Sub

        If Me.RadioButton1.Checked = True Then
            开始批量创建项()
            Form调试.Focus()
        End If
        If Me.RadioButton2.Checked = True Then
            开始创建一个项()
            Form调试.Focus()
        End If


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        e.Handled = True
    End Sub

    Sub 开始批量创建项()
        要批量创建项的路径数据列表 = {}
        自动创建项的目标分类 = Me.DarkComboBox1.Text
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            ReDim Preserve 要批量创建项的路径数据列表(要批量创建项的路径数据列表.Count)
            要批量创建项的路径数据列表(要批量创建项的路径数据列表.Count - 1) = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & Me.ListView1.Items(Me.ListView1.SelectedIndices(i)).Text
        Next
        安装卸载后台统一执行操作(后台操作类型.批量创建项)
    End Sub

    Sub 开始创建一个项()
        要创建一个项的路径数据列表 = {}
        自动创建项的目标分类 = Me.DarkComboBox1.Text
        要创建一个项的项名称 = Me.DarkTextBox1.Text
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            ReDim Preserve 要创建一个项的路径数据列表(要创建一个项的路径数据列表.Count)
            要创建一个项的路径数据列表(要创建一个项的路径数据列表.Count - 1) = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & Me.ListView1.Items(Me.ListView1.SelectedIndices(i)).Text
        Next
        安装卸载后台统一执行操作(后台操作类型.创建一个项)
    End Sub

    Private Sub 打开文件夹ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开文件夹ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Process.Start(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & Me.ListView1.Items(Me.ListView1.SelectedIndices(0)).Text)
    End Sub

    Private Sub 删除ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 删除ToolStripMenuItem.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Dim i As Integer = 0
        Do Until i = Me.ListView1.Items.Count
            My.Computer.FileSystem.DeleteDirectory(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\Mods\" & Me.ListView1.Items(Me.ListView1.SelectedIndices(i)).Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Me.ListView1.Items.Item(i).Remove()
            i -= 1
        Loop



    End Sub
End Class