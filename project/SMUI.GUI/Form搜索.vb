Imports System.ComponentModel
Imports SMUI.GUI.Class1

Public Class Form搜索

    Dim 搜索历史 As String() = {}
    Dim 搜索结果 As String() = {}
    Dim 搜索类型 As SMUI.Windows.Core.SearchItem.SearchType

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        If Me.RadioButton1.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.ItemName
        ElseIf Me.RadioButton2.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.NameKey
        ElseIf Me.RadioButton3.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.AuthorKey
        ElseIf Me.RadioButton4.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.UniqueID
        ElseIf Me.RadioButton5.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.ContentPakForAndDependencies
        ElseIf Me.RadioButton6.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.IncludedFolders
        ElseIf Me.RadioButton7.Checked = True Then
            搜索类型 = SMUI.Windows.Core.SearchItem.SearchType.NexusID
        End If
        清除模组列表()
        Me.Text = 获取动态多语言文本("data/SearchWindow/Search.1")
        Application.DoEvents()
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim a As New SMUI.Windows.Core.SearchItem
        If Me.CheckBox1.Checked = True Then a.ST_NotCaseUpperAndLowerLetters = True
        If Me.CheckBox2.Checked = True Then a.ST_NotCaseCHS_ENG_Symbol = True
        If Me.CheckBox3.Checked = True Then a.ST_SingleCharacterFuzzySearch = True
        Dim stra As String = a.StartSearch(检查并返回当前所选子库路径(False), Me.DarkTextBox1.Text, 搜索类型)
        搜索结果 = a.Results
        e.Result = stra
        ReDim Preserve 搜索历史(搜索历史.Count)
        搜索历史(搜索历史.Count - 1) = Me.DarkTextBox1.Text
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Result <> "" Then
            MsgBox(e.Result, MsgBoxStyle.Critical)
            Exit Sub
        End If
        Me.Text = 获取动态多语言文本("data/SearchWindow/Search.2")
        Application.DoEvents()
        For i = 0 To 搜索结果.Count - 1
            Form1.ListView2.Items.Add(IO.Path.GetFileName(搜索结果(i)))
            ReDim Preserve 当前项列表中项的分类集合(当前项列表中项的分类集合.Count)
            当前项列表中项的分类集合(当前项列表中项的分类集合.Count - 1) = IO.Path.GetFileName(IO.Path.GetDirectoryName(搜索结果(i)))
        Next
        Me.Text = 获取动态多语言文本("data/SearchWindow/Search.3")
        刷新项列表数据()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles DarkButton2.Click

    End Sub

    Dim a As New DarkUI.Controls.DarkContextMenu With {
        .ShowImageMargin = False,
        .DropShadowEnabled = False,
        .ShowCheckMargin = False
    }

    Private Sub DarkButton2_MouseDown(sender As Object, e As MouseEventArgs) Handles DarkButton2.MouseDown
        a.Items.Clear()
        For i = 0 To 搜索历史.Count - 1
            AddHandler a.Items.Add(搜索历史(i)).Click,
                Sub(s1, e1)
                    Me.DarkTextBox1.Text = s1.Text
                End Sub
        Next
        a.Show(MousePosition)

    End Sub

    Private Sub DarkButton3_Click(sender As Object, e As EventArgs) Handles DarkButton3.Click
        搜索历史 = {}
    End Sub

    Private Sub Form搜索_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form搜索_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Text = 获取动态多语言文本("data/SearchWindow/Search.Title")
            Me.DarkLabel1.Text = 获取动态多语言文本("data/SearchWindow/Search.4")
            Me.RadioButton1.Text = 获取动态多语言文本("data/SearchWindow/Search.5")
            Me.RadioButton2.Text = 获取动态多语言文本("data/SearchWindow/Search.6")
            Me.RadioButton3.Text = 获取动态多语言文本("data/SearchWindow/Search.7")
            Me.RadioButton4.Text = 获取动态多语言文本("data/SearchWindow/Search.8")
            Me.RadioButton5.Text = 获取动态多语言文本("data/SearchWindow/Search.9")
            Me.RadioButton6.Text = 获取动态多语言文本("data/SearchWindow/Search.10")
            Me.RadioButton7.Text = 获取动态多语言文本("data/SearchWindow/Search.11")
            Me.DarkLabel2.Text = 获取动态多语言文本("data/SearchWindow/Search.12")
            Me.CheckBox1.Text = 获取动态多语言文本("data/SearchWindow/Search.13")
            Me.CheckBox2.Text = 获取动态多语言文本("data/SearchWindow/Search.14")
            Me.CheckBox3.Text = 获取动态多语言文本("data/SearchWindow/Search.15")
        End If
    End Sub
End Class