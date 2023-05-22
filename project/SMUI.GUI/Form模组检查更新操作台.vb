
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI.GUI.Class1
Imports SMUI.Windows.Core
Imports SMUI.Windows.SmapiWebAPI.Core
Imports SMUI.Windows.SmapiWebAPI.Objects
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports SMUI.Windows.PakManager
Imports Microsoft.VisualBasic.Devices
Imports System.Diagnostics.Eventing.Reader
Imports CefSharp.DevTools.Overlay

Public Class Form模组检查更新操作台

    Dim SMAPI返回数据动态表 As SmapiResponseOutputData



    Sub 一级按钮鼠标移上事件(sender As Object, e As EventArgs) Handles Label返回到步骤一.MouseEnter, Label45.MouseEnter, Label43.MouseEnter, Label41.MouseEnter, Label39.MouseEnter, Label22.MouseEnter
        sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Sub 一级按钮鼠标移走事件(sender As Object, e As EventArgs) Handles Label返回到步骤一.MouseLeave, Label45.MouseLeave, Label43.MouseLeave, Label41.MouseLeave, Label39.MouseLeave, Label22.MouseLeave
        sender.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
    End Sub

    Private Sub Form模组检查更新操作台_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Panel2.Dock = DockStyle.Fill
        Me.Panel2.BorderStyle = BorderStyle.None
        Me.Panel3.Dock = DockStyle.Fill
        Me.Panel3.BorderStyle = BorderStyle.None
        Me.Panel4.Dock = DockStyle.Fill
        Me.Panel4.BorderStyle = BorderStyle.None
        Me.Panel2.Visible = True
        Me.DarkComboBox1.SelectedIndex = 0
        Me.DarkTextBox1.Text = ST1.当前SMAPI版本号
        Me.DarkTextBox2.Text = ST1.当前星露谷版本号

        Me.RichTextBox1.AutoWordSelection = False
        Me.RichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(Me.RichTextBox1, 300)

        If DLC.CheckUpdatesExtension = True Then
            Me.Label41.Visible = True
            Me.Label40.Visible = True
            Me.Label43.Visible = True
            Me.Label42.Visible = True
            Me.Label3.Visible = True
        End If
        If DLC.CustomInputExtension = True Then
            Me.自由输入NEXUSIDToolStripMenuItem.Visible = True
        End If

        If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
            Me.管理员激活拖拽ToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub Form模组检查更新操作台_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form1.检查更新加入表中ToolStripMenuItem.Visible = False
        Form1.检查更新加入表中ToolStripMenuItem1.Visible = False
    End Sub

    Private Sub Form模组检查更新操作台_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Label10.Width += Label17.Width - 150
        调整列宽()
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/Title")
            Me.Label1.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A1")
            Me.Label1.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A1").Attributes.GetNamedItem("width").InnerText
            Me.Label2.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A2")
            Me.Label2.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A2").Attributes.GetNamedItem("width").InnerText
            Me.Label3.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A3")
            Me.Label3.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A3").Attributes.GetNamedItem("width").InnerText
            Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A4")
            Me.Label7.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A5")
            Me.CheckBox1.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A6")
            Me.CheckBox2.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A7")
            Me.CheckBox3.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A8")
            Me.CheckBox4.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A9")
            Me.CheckBox5.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A10")
            Me.CheckBox6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A11")
            Me.CheckBox7.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A12")
            Me.DarkButton2.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A13")
            Me.Label10.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A14")
            Me.Label13.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A15")
            Me.Label15.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A16")
            Me.Label17.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A17")
            Me.移除选中ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A19")
            Me.移除全部ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A20")
            Me.批量修改ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/
A21")
            Me.批量修改更新键ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A22")
            Me.批量修改本地版本ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A23")
            Me.批量修改运行态ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A24")

            Me.Label19.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A25")
            Me.Label22.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A26")
            Me.Label33.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A27")
            Me.LinkLabel1.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A28")
            Me.LinkLabel8.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A29")
            Me.LinkLabel3.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A30")
            Me.LinkLabel4.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A31")
            Me.LinkLabel5.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A32")
            Me.LinkLabel6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A33")
            Me.LinkLabel7.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A34")
            Me.LinkLabel9.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A35")
            Me.Label43.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A36")
            Me.Label43.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A36").Attributes.GetNamedItem("width").InnerText
            Me.Label41.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A37")
            Me.Label41.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A37").Attributes.GetNamedItem("width").InnerText
            Me.Label39.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A38")
            Me.Label39.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A38").Attributes.GetNamedItem("width").InnerText
            Me.Label返回到步骤一.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A39")
            Me.Label返回到步骤一.Width = xml_lang.SelectSingleNode("data/ModCheckUpdateManageWindow/A39").Attributes.GetNamedItem("width").InnerText
            Me.Label28.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A40")
            Me.Label26.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A41")
            Me.Label32.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A42")
            Me.Label29.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A43")
            Me.Label34.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A44")
            Me.选中所有可更新的项蓝色ToolStripMenuItem.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A45")
        End If
    End Sub

    Private Sub Form模组检查更新操作台_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.Label10.Width += Label17.Width - 150
        Me.RichTextBox1.Width = Me.RichTextBox1.Parent.Width + ST1.系统滚动条宽度
        Me.RichTextBox1.RightMargin = Me.RichTextBox1.Parent.Width - 12
        调整列宽()
    End Sub

    Sub 调整列宽()
        Me.ColumnHeader1.Width = Me.Label10.Width + 2
        Me.ColumnHeader2.Width = Me.Label13.Width + 1
        Me.ColumnHeader3.Width = Me.Label15.Width
        Me.ColumnHeader4.Width = Me.Label17.Width - ST1.系统滚动条宽度 - 15

        Me.ColumnHeader5.Width = Me.Label28.Width + 2
        Me.ColumnHeader6.Width = Me.Label26.Width + 1
        Me.ColumnHeader7.Width = Me.Label32.Width + 1
        Me.ColumnHeader8.Width = Me.Label29.Width
        Me.ColumnHeader9.Width = Me.Label34.Width - ST1.系统滚动条宽度 - 15

        Me.ColumnHeader10.Width = Me.Label53.Width + 2
        Me.ColumnHeader11.Width = Me.Label49.Width + 1
        Me.ColumnHeader12.Width = Me.Label55.Width
        Me.ColumnHeader13.Width = Me.Label48.Width - ST1.系统滚动条宽度 - 15

    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        e.Handled = True
    End Sub

    Dim 建议更新的版本地址 As String = ""


    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        If Me.ListView2.SelectedItems.Count <> 1 Then
            Me.ListBox1.Items.Clear()
            建议更新的版本地址 = ""
            Me.LinkLabel2.Text = "NEXUSMODS"
            Me.LinkLabel3.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A30")
            Me.LinkLabel7.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A34")
        Else
            For i = 0 To SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).id.Count - 1
                Me.ListBox1.Items.Add(SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).id(i))
            Next
            If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).nexusID <> "" Then
                Me.LinkLabel2.Text = "NEXUSMODS: " & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).nexusID
            Else
                Me.LinkLabel2.Text = "No NEXUSMODS"
            End If
            If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).gitHubRepo <> "" Then
                Me.LinkLabel3.Text = "GitHub: " & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).gitHubRepo
            Else
                Me.LinkLabel3.Text = "No GitHub"
            End If
            If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).compatibilitySummary <> "" Then
                Me.LinkLabel7.Text = Mid(SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).compatibilitySummary, 1, 20)
            Else
                Me.LinkLabel7.Text = "null"
            End If
        End If
    End Sub

    Private Sub ListView2_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView2.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView2.KeyPress
        e.Handled = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Me.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Process.Start(SMAPI返回数据动态表.suggestedUpdate_url(Me.ListView2.SelectedIndices(0)))
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If Me.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Process.Start(SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).nexusID)
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim 地址数组 As String() = {}
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).modDropID <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = "https://www.moddrop.com/stardew-valley/mods/" & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).modDropID
        End If
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).curseForgeKey <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = "https://www.curseforge.com/stardewvalley/mods/" & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).curseForgeKey
        End If
        If 地址数组.Count = 0 Then Exit Sub
        Dim a As New SingleSelectionDialog("", 地址数组, "Other", , 500)
        Dim b As Integer = a.ShowDialog(Me)
        Select Case b
            Case 0, 1
                Process.Start(地址数组(b))
        End Select
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).gitHubRepo <> "" Then
            Process.Start("https://github.com/" & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).gitHubRepo)
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim 地址数组 As String() = {}
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).customUrl <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).customUrl
        End If
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).customSourseUrl <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).customSourseUrl
        End If
        If 地址数组.Count = 0 Then Exit Sub
        Dim a As New SingleSelectionDialog("", 地址数组, "Custom", , 500)
        Dim b As Integer = a.ShowDialog(Me)
        Select Case b
            Case 0, 1
                Process.Start(地址数组(b))
        End Select
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).main_url <> "" Then
            Process.Start(SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).main_url)
        End If
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim 地址数组 As String() = {}
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).optional_url <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = "Optional: " & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).optional_url
        End If
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).unofficial_url <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = "Unofficial: " & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).unofficial_url
        End If
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).unofficialForBeta_url <> "" Then
            ReDim Preserve 地址数组(地址数组.Count)
            地址数组(地址数组.Count - 1) = "Unofficial For Beta: " & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).unofficialForBeta_url
        End If
        If 地址数组.Count = 0 Then Exit Sub
        Dim a As New SingleSelectionDialog("", 地址数组, "Other", , 750)
        Dim b As Integer = a.ShowDialog(Me)
        Select Case b
            Case 0, 1, 2
                Process.Start(地址数组(b))
        End Select
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).compatibilitySummary <> "" Then
            Dim a As New SingleSelectionDialog("", {"OK"}, SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).compatibilitySummary, , 750)
            a.ShowDialog(Me)
        End If
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim 描述 As String = ""
        If SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).betaCompatibilitySummary <> "" Then
            描述 &= "Beta: " & SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(0)).compatibilitySummary & vbNewLine & vbNewLine
        End If
        If 描述 = "" Then Exit Sub
        Dim a As New SingleSelectionDialog("", {"OK", "Copy"}, 描述, 200, 500)
        Dim b As Integer = a.ShowDialog(Me)
        Select Case b
            Case 1
                Clipboard.SetText(描述)
        End Select
    End Sub


    Sub 重置返回列表详细信息显示()
        Me.ListBox1.Items.Clear()

    End Sub


    Sub 隐藏所有选项卡界面()
        Me.Panel2.Visible = False
        Me.Panel3.Visible = False
        Me.Panel4.Visible = False
    End Sub

    Sub 重置主选项卡背景色()
        Me.Label1.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
        Me.Label2.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
        Me.Label3.BackColor = ColorTranslator.FromWin32(RGB(32, 34, 37))
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles DarkButton2.Click

        Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/S1")
        Application.DoEvents()
        System.Threading.Thread.Sleep(250)

        Dim b As New SmapiRequestInputData
        Initialize_SmapiRequestInputData(b)

        b.platform = Me.DarkComboBox1.Text
        b.apiVersion = Me.DarkTextBox1.Text
        b.gameVersion = Me.DarkTextBox2.Text
        b.includeExtendedMetadata = Me.CheckBox4.Checked

        For i = 0 To Me.ListView1.Items.Count - 1

            ReDim Preserve b.mods_updatekeys(b.mods_updatekeys.Count)
            b.mods_updatekeys(b.mods_updatekeys.Count - 1) = New UpdatekeysData

            Initialize_UpdatekeysData(b.mods_updatekeys(i))

            ReDim Preserve b.mods_id(b.mods_id.Count)
            b.mods_id(b.mods_id.Count - 1) = Me.ListView1.Items.Item(i).Text

            ReDim Preserve b.mods_updatekeys(i).Nexus(b.mods_updatekeys(i).Nexus.Count)
            b.mods_updatekeys(i).Nexus(b.mods_updatekeys(i).Nexus.Count - 1) = Me.ListView1.Items.Item(i).SubItems(1).Text

            ReDim Preserve b.installedversion(b.installedversion.Count)
            b.installedversion(b.installedversion.Count - 1) = Me.ListView1.Items.Item(i).SubItems(2).Text

            ReDim Preserve b.isBroken(b.isBroken.Count)
            b.isBroken(b.isBroken.Count - 1) = "false"

        Next

        Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/S2")
        Application.DoEvents()
        System.Threading.Thread.Sleep(250)

        Dim err1 As String = ""
        Dim k As String = GenerateRequestJsonData(b, err1)
        Dim x As New SMUI.Windows.SmapiWebAPI.GetModsUpdateData

        Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/S3")
        Application.DoEvents()
        System.Threading.Thread.Sleep(250)

        Dim rep1 As String = ""
        Dim err2 As String = x.StartGet(k, rep1)

        If err2 <> "" Then
            MsgBox(err2, MsgBoxStyle.Critical)
            Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A4")
            Exit Sub
        End If

        Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/S4")
        Application.DoEvents()
        System.Threading.Thread.Sleep(250)

        Dim res As SmapiResponseOutputData
        Dim err3 As String = ""
        res = ProcessSmapiResponse(rep1, err3)

        If err3 <> "" Then
            MsgBox(err3, MsgBoxStyle.Critical)
            Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A4")
            Exit Sub
        End If

        Me.Label6.Text = 获取动态多语言文本("data/ModCheckUpdateManageWindow/A4")
        Application.DoEvents()
        System.Threading.Thread.Sleep(250)

        SMAPI返回数据动态表 = res

        Me.ListView2.Items.Clear()
        添加调试文本("SMAPI server returned " & res.id.Count & " results.", Color.Aqua)

        For i = 0 To res.id.Count - 1
            Me.ListView2.Items.Add(res.metadata(i).name)
            Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(res.id(i))
            If res.suggestedUpdate_version(i) = "null" Then
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/ModCheckUpdateManageWindow/S5"))
            Else
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(res.suggestedUpdate_version(i))
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).ForeColor = Color1.蓝色
            End If

            If res.metadata(i).nexusID <> "" Then
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(res.metadata(i).nexusID)
            ElseIf res.metadata(i).gitHubRepo <> "" Then
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(res.metadata(i).gitHubRepo)
            Else
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/ModCheckUpdateManageWindow/S6"))
            End If

            Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems.Add(res.metadata(i).compatibilitySummary)
            If res.metadata(i).compatibilitySummary = "" And res.suggestedUpdate_version(i) = "null" And res.metadata(i).errors <> "[]" Then
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).ForeColor = Color1.红色
                Me.ListView2.Items(Me.ListView2.Items.Count - 1).SubItems(4).Text = res.metadata(i).errors
            End If
        Next

        Me.ColumnHeader9.Width = Me.Label34.Width - ST1.系统滚动条宽度 - 15
        Me.Panel2.Visible = False
        Me.Panel3.Visible = True
        重置主选项卡背景色()
        Me.Label2.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click
        Me.ListView2.Items.Clear()
        Me.Panel3.Visible = False
        Me.Panel2.Visible = True
        重置主选项卡背景色()
        Me.Label1.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Private Sub Label返回到步骤一_Click(sender As Object, e As EventArgs) Handles Label返回到步骤一.Click
        Me.Panel3.Visible = False
        Me.Panel2.Visible = True
        重置主选项卡背景色()
        Me.Label1.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox1.DrawItem
        e.Graphics.FillRectangle(New SolidBrush(e.BackColor), e.Bounds)
        If e.Index >= 0 Then
            Dim sStringFormat As New StringFormat With {
                .LineAlignment = StringAlignment.Center
            }
            e.Graphics.DrawString(Me.ListBox1.Items(e.Index).ToString(), e.Font, New SolidBrush(e.ForeColor), e.Bounds, sStringFormat)
        End If
        e.DrawFocusRectangle()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        隐藏所有选项卡界面()
        Me.Panel2.Visible = True
        重置主选项卡背景色()
        Me.Label1.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
        调整列宽()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        隐藏所有选项卡界面()
        Me.Panel3.Visible = True
        重置主选项卡背景色()
        Me.Label2.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
        调整列宽()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        隐藏所有选项卡界面()
        Me.Panel4.Visible = True
        重置主选项卡背景色()
        Me.Label3.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
        调整列宽()
    End Sub

    Private Sub 移除全部ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移除全部ToolStripMenuItem.Click
        Me.ListView1.Items.Clear()
    End Sub

    Private Sub 移除选中ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移除选中ToolStripMenuItem.Click
        Dim i As Integer = 0
        Do Until i = Me.ListView1.Items.Count
            If Me.ListView1.Items.Item(i).Selected = True Then
                Me.ListView1.Items.Item(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        If ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator Then
            Dim Folders As String() = e.Data.GetData(GetType(String()))
            For x = 0 To Folders.Count - 1
                Dim ManifestFile As New SearchFile
                ManifestFile.SearchManifests(Folders(x))
                For i = 0 To ManifestFile.FileCollection.Count - 1
                    Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(Folders(x), ManifestFile.FileCollection(i)))
                    Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                    If JsonData.item("UniqueID") IsNot Nothing Then
                        Me.ListView1.Items.Add(JsonData.item("UniqueID").ToString)
                        If JsonData.item("UpdateKeys") IsNot Nothing Then
                            For k = 0 To JsonData.item("UpdateKeys").Count - 1
                                If InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus") > 0 Then
                                    Dim str = SMUI.Windows.Core.SharedFunction.GetModUpdateID(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus")
                                    If IsNumeric(str) Then
                                        Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add(str)
                                    Else
                                        Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                                    End If
                                Else
                                    Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                                End If
                            Next
                        Else
                            Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                        End If
                        If JsonData.item("Verison") IsNot Nothing Then
                            Dim str1 As String = JsonData.item("Version").ToString
                            If InStr(str1, "MajorVersion") > 0 Then
                                str1 = SMUI.Windows.Core.ItemInfoReader.ReadSemanticVersion(str1)
                            End If
                            Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add(str1)
                        Else
                            Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                        End If
                        Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                    End If
                Next
            Next
        Else
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) = False Then Exit Sub
        Dim Folders As String() = e.Data.GetData(DataFormats.FileDrop)
        For x = 0 To Folders.Count - 1
            Dim ManifestFile As New SearchFile
            ManifestFile.SearchManifests(Folders(x))
            For i = 0 To ManifestFile.FileCollection.Count - 1
                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(Folders(x), ManifestFile.FileCollection(i)))
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                If JsonData.item("UniqueID") IsNot Nothing Then
                    Me.ListView1.Items.Add(JsonData.item("UniqueID").ToString)
                    If JsonData.item("UpdateKeys") IsNot Nothing Then
                        For k = 0 To JsonData.item("UpdateKeys").Count - 1
                            If InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus") > 0 Then
                                Dim str = SMUI.Windows.Core.SharedFunction.GetModUpdateID(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus")
                                If IsNumeric(str) Then
                                    Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add(str)
                                Else
                                    Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                                End If
                            Else
                                Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                            End If
                        Next
                    Else
                        Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                    End If
                    If JsonData.item("Version") IsNot Nothing Then
                        Dim str1 As String = JsonData.item("Version").ToString
                        If InStr(str1, "MajorVersion") > 0 Then
                            str1 = SMUI.Windows.Core.ItemInfoReader.ReadSemanticVersion(str1)
                        End If
                        Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add(str1)
                    Else
                        Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                    End If
                    Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("")
                End If
            Next
        Next
    End Sub



    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click
        For i = 0 To Me.ListView2.Items.Count - 1
            Me.ListView3.Items.Add(Me.ListView2.Items.Item(i).SubItems(1).Text)
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add(SMAPI返回数据动态表.metadata(i).nexusID)
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add("")
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add("")
        Next
        Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/ModCheckUpdateManageWindow/S11") & Me.ListView2.Items.Count)
        a.ShowDialog(Me)
    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click
        For i = 0 To Me.ListView2.SelectedItems.Count - 1
            Me.ListView3.Items.Add(Me.ListView2.Items.Item(Me.ListView2.SelectedIndices(i)).SubItems(1).Text)
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add(SMAPI返回数据动态表.metadata(Me.ListView2.SelectedIndices(i)).nexusID)
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add("")
            Me.ListView3.Items.Item(Me.ListView3.Items.Count - 1).SubItems.Add("")
        Next
        Dim a As New SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/ModCheckUpdateManageWindow/S11") & Me.ListView2.SelectedItems.Count)
        a.ShowDialog(Me)
    End Sub

    Private Sub 开始在当前子库中扫描ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 开始在当前子库中扫描ToolStripMenuItem.Click
        If Me.ListView3.Items.Count = 0 Then Exit Sub
        For i = 0 To Me.ListView3.Items.Count - 1
            Me.ListView3.Items.Item(i).SubItems(2).Text = ""
            Me.ListView3.Items.Item(i).SubItems(3).Text = ""
        Next
        Me.RichTextBox1.Text = ""
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(检查并返回当前所选子库路径(False))
        For Each mDir In mDirInfo.GetDirectories
            Dim mDir2 As IO.DirectoryInfo
            Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
            For Each mDir2 In mDirInfo2.GetDirectories
                Dim ManifestFile As New SearchFile
                ManifestFile.SearchManifests(mDir2.FullName)
                For i = 0 To ManifestFile.FileCollection.Count - 1
                    Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                    Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                    If JsonData.item("UniqueID") IsNot Nothing Then
                        For i3 = 0 To Me.ListView3.Items.Count - 1
                            If JsonData.item("UniqueID").ToString.ToLower.Replace(" ", "") = Me.ListView3.Items.Item(i3).Text.ToLower.Replace(" ", "") Then
                                If Me.ListView3.Items.Item(i3).SubItems(2).Text <> "" Then
                                    Me.ListView3.Items.Item(i3).ForeColor = Color1.黄色
                                    添加搜索情况分析文本(获取动态多语言文本("data/ModCheckUpdateManageWindow/S8") & Me.ListView3.Items.Item(i3).Text, Color1.黄色)
                                    添加搜索情况分析文本(获取动态多语言文本("data/ModCheckUpdateManageWindow/S8.1") & mDir.Name & "-->" & mDir2.Name, Color1.黄色)
                                Else
                                    添加搜索情况分析文本(获取动态多语言文本("data/ModCheckUpdateManageWindow/S7") & Me.ListView3.Items.Item(i3).Text, Color1.绿色)
                                    Me.ListView3.Items.Item(i3).SubItems(2).Text = mDir.Name
                                    Me.ListView3.Items.Item(i3).SubItems(3).Text = mDir2.Name
                                End If
                                Application.DoEvents()
                            End If
                        Next
                    End If
                Next
            Next
        Next
        Application.DoEvents()
        For i = 0 To Me.ListView3.Items.Count - 1
            If Me.ListView3.Items.Item(i).SubItems(2).Text = "" And Me.ListView3.Items.Item(i).SubItems(3).Text = "" Then
                Me.ListView3.Items.Item(i).ForeColor = Color1.橙色
                添加搜索情况分析文本(获取动态多语言文本("data/ModCheckUpdateManageWindow/S9") & Me.ListView3.Items.Item(i).Text, Color1.黄色)
            End If
        Next
        添加搜索情况分析文本(获取动态多语言文本("data/ModCheckUpdateManageWindow/S10"), Color1.黄色)
    End Sub

    Sub 添加搜索情况分析文本(ByVal 文本 As String, ByVal 颜色 As Color)
        If Me.RichTextBox1.Text = "" Then
            Me.RichTextBox1.AppendText(文本)
        Else
            Me.RichTextBox1.AppendText(vbNewLine & 文本)
        End If
        Me.RichTextBox1.Select(Me.RichTextBox1.TextLength - 文本.Length, 文本.Length)
        Me.RichTextBox1.SelectionColor = 颜色
    End Sub

    Private Sub 移除选中项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移除选中项ToolStripMenuItem.Click
        Dim i As Integer = 0
        Do Until i = Me.ListView3.Items.Count
            If Me.ListView3.Items.Item(i).Selected = True Then
                Me.ListView3.Items.Item(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Private Sub 移除全部项ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移除全部项ToolStripMenuItem.Click
        Me.ListView3.Items.Clear()
    End Sub

    Private Sub 直接运行项在线更新流程NEXUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 直接运行项在线更新流程NEXUSToolStripMenuItem.Click
        If Me.ListView3.SelectedItems.Count = 0 Then Exit Sub
        If Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text = "" Then Exit Sub
        If Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(2).Text = "" Then Exit Sub
        If Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(3).Text = "" Then Exit Sub
        Dim 新的更新窗口 As New Form直接联网更新单个项 With {
            .当前正在进行更新的单个项的N网ID = Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(1).Text,
            .当前正在进行直接更新的操作类型 = 在线更新操作类型.更新项,
            .当前正在进行更新的单个项路径 = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(2).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(3).Text
        }
        显示窗体(新的更新窗口, Me)
    End Sub

    Private Sub 自由输入NEXUSIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 自由输入NEXUSIDToolStripMenuItem.Click
        If Me.ListView3.SelectedItems.Count = 0 Then Exit Sub
        If Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(2).Text = "" Then Exit Sub
        If Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(3).Text = "" Then Exit Sub
        Dim m1 As New InputTextDialog("Lake1059.Plugin1.UnlockFreeInputID", 获取动态多语言文本("data/DynamicText/UpdateMod.1"))
        Dim m2 As String = m1.ShowDialog(Me)
        If m2 = "" Or m2 Is Nothing Then Exit Sub
        Dim 新的更新窗口 As New Form直接联网更新单个项 With {
            .当前正在进行更新的单个项的N网ID = m2,
            .当前正在进行直接更新的操作类型 = 在线更新操作类型.更新项,
            .当前正在进行更新的单个项路径 = 检查并返回当前所选子库路径(False) & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(2).Text & "\" & Me.ListView3.Items.Item(Me.ListView3.SelectedIndices(0)).SubItems(3).Text
        }
        显示窗体(新的更新窗口, Me)
    End Sub

    Private Sub 选中所有可更新的项蓝色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 选中所有可更新的项蓝色ToolStripMenuItem.Click
        For i = 0 To Me.ListView2.Items.Count - 1
            If Me.ListView2.Items.Item(i).ForeColor = Color1.蓝色 Then
                Me.ListView2.Items.Item(i).Selected = True
            Else
                Me.ListView2.Items.Item(i).Selected = False
            End If
        Next
    End Sub

    Private Sub 复制全部扫描日志纯文本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 复制全部扫描日志纯文本ToolStripMenuItem.Click
        Clipboard.SetText(Me.RichTextBox1.Text)
    End Sub

    Private Sub 管理员激活拖拽ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 管理员激活拖拽ToolStripMenuItem.Click
        FileDroper.Dispose()
        FileDroper = New WindowsMF.Class1.FileDropHandler(Me.ListView1)
    End Sub

    Private Sub Label45_MouseDown(sender As Object, e As MouseEventArgs) Handles Label45.MouseDown
        Dim mouseX As Integer = MousePosition.X
        Dim mouseY As Integer = MousePosition.Y
        Me.DarkContextMenu3.Show(mouseX - e.X + (Me.Label45.Width - Me.DarkContextMenu3.Width) + 1, mouseY + (Me.Label45.Height - e.Y) + 1)
    End Sub

    Private Sub 批量修改更新键ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量修改更新键ToolStripMenuItem.Click
        Dim a As New InputTextDialog("", "NEXUS ID")
        Dim b As String = a.ShowDialog(Me)
        If b = "" Then Exit Sub
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).SubItems(1).Text = b
        Next
    End Sub

    Private Sub 批量修改本地版本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量修改本地版本ToolStripMenuItem.Click
        Dim a As New InputTextDialog("", "Verison")
        Dim b As String = a.ShowDialog(Me)
        If b = "" Then Exit Sub
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).SubItems(2).Text = b
        Next
    End Sub

    Private Sub 批量修改运行态ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 批量修改运行态ToolStripMenuItem.Click
        Dim a As New InputTextDialog("", "true or false")
        Dim b As String = a.ShowDialog(Me)
        If b = "" Then Exit Sub
        For i = 0 To Me.ListView1.SelectedItems.Count - 1
            Me.ListView1.Items.Item(Me.ListView1.SelectedIndices(i)).SubItems(3).Text = b
        Next
    End Sub
End Class