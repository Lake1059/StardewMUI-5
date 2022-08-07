
Imports System.Text
Imports System.Xml
Imports SMUI.GUI.Class1
Imports SMUI.Windows.PakManager

Public Class Form设置


    Sub 一级按钮鼠标移上事件(sender As Object, e As EventArgs) Handles Label9.MouseEnter, Label7.MouseEnter, Label确定.MouseEnter, Label应用.MouseEnter, Label4.MouseEnter, Label28.MouseEnter, Label24.MouseEnter, Label10.MouseEnter, Label取消.MouseEnter
        sender.BackColor = ColorTranslator.FromWin32(RGB(100, 100, 100))

    End Sub

    Sub 一级按钮鼠标移走事件(sender As Object, e As EventArgs) Handles Label9.MouseLeave, Label7.MouseLeave, Label确定.MouseLeave, Label应用.MouseLeave, Label4.MouseLeave, Label28.MouseLeave, Label24.MouseLeave, Label10.MouseLeave, Label取消.MouseLeave
        sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))

    End Sub

    Private Sub Form设置_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        挑选图标的绑定按钮事件()
        读取设置()
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Text = 获取动态多语言文本("data/SettingsWindow/Title")
            Me.Label2.Text = 获取动态多语言文本("data/SettingsWindow/A1")
            Me.Label取消.Text = 获取动态多语言文本("data/SettingsWindow/A2")
            Me.Label应用.Text = 获取动态多语言文本("data/SettingsWindow/A3")
            Me.Label确定.Text = 获取动态多语言文本("data/SettingsWindow/A4")
            Me.Label关键路径.Text = 获取动态多语言文本("data/SettingsWindow/A5")
            Me.Label5.Text = 获取动态多语言文本("data/SettingsWindow/A6")
            Me.Label6.Text = 获取动态多语言文本("data/SettingsWindow/A7")
            Me.Label19.Text = 获取动态多语言文本("data/SettingsWindow/A8")
            Me.Label可选路径.Text = 获取动态多语言文本("data/SettingsWindow/A9")
            Me.Label12.Text = 获取动态多语言文本("data/SettingsWindow/A10")
            Me.Label25.Text = 获取动态多语言文本("data/SettingsWindow/A14")
            Me.Label29.Text = 获取动态多语言文本("data/SettingsWindow/A15")
            Me.Label15.Text = 获取动态多语言文本("data/SettingsWindow/A16")
            Me.Label地区和语言.Text = 获取动态多语言文本("data/SettingsWindow/A17")
            Me.Label1.Text = 获取动态多语言文本("data/SettingsWindow/A18")
            Me.Label22.Text = 获取动态多语言文本("data/SettingsWindow/A19")
            Me.Label14.Text = 获取动态多语言文本("data/SettingsWindow/A20")
            Me.Label21.Text = 获取动态多语言文本("data/SettingsWindow/A21")
            Me.Label网络服务.Text = 获取动态多语言文本("data/SettingsWindow/A22")
            Me.Label8.Text = 获取动态多语言文本("data/SettingsWindow/A23")
            Me.DarkButton4.Text = 获取动态多语言文本("data/SettingsWindow/A23B1")
            Me.Label33.Text = 获取动态多语言文本("data/SettingsWindow/A24")
            Me.Label启动项.Text = 获取动态多语言文本("data/SettingsWindow/A25")
            Me.RadioButton8.Text = 获取动态多语言文本("data/SettingsWindow/A26")
            Me.RadioButton12.Text = 获取动态多语言文本("data/SettingsWindow/A27")
            Me.RadioButton13.Text = 获取动态多语言文本("data/SettingsWindow/A28")
            Me.Label功能.Text = 获取动态多语言文本("data/SettingsWindow/A29")
            Me.CheckBox8.Text = 获取动态多语言文本("data/SettingsWindow/A30")
            Me.CheckBox7.Text = 获取动态多语言文本("data/SettingsWindow/A31")
            Me.CheckBox5.Text = 获取动态多语言文本("data/SettingsWindow/A32")
            Me.CheckBox1.Text = 获取动态多语言文本("data/SettingsWindow/A33")
            Me.Label界面尺寸.Text = 获取动态多语言文本("data/SettingsWindow/A34")
            Me.Label13.Text = 获取动态多语言文本("data/SettingsWindow/A35")
            Me.Label20.Text = 获取动态多语言文本("data/SettingsWindow/A36")
            Me.Label字体样式.Text = 获取动态多语言文本("data/SettingsWindow/A37")
            Me.Label图标.Text = 获取动态多语言文本("data/SettingsWindow/A38")
            Me.Label32.Text = 获取动态多语言文本("data/SettingsWindow/A39")
            Me.CheckBox2.Text = 获取动态多语言文本("data/SettingsWindow/A40")
        End If

    End Sub

    Public Sub 切换选项卡控制颜色(sender As Object)
        Me.Label关键路径.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label可选路径.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label地区和语言.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label网络服务.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label启动项.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label功能.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label界面尺寸.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label字体样式.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Label图标.BackColor = ColorTranslator.FromWin32(RGB(41, 43, 47))
        Me.Panel关键路径.Visible = False
        Me.Panel可选路径.Visible = False
        Me.Panel地区和语言.Visible = False
        Me.Panel网络服务.Visible = False
        Me.Panel启动项.Visible = False
        Me.Panel功能.Visible = False
        Me.Panel界面尺寸.Visible = False
        Me.Panel字体样式.Visible = False
        Me.Panel图标.Visible = False
        sender.BackColor = ColorTranslator.FromWin32(RGB(70, 70, 70))
    End Sub

    Private Sub Label关键路径_Click(sender As Object, e As EventArgs) Handles Label关键路径.Click
        切换选项卡控制颜色(sender)
        Me.Panel关键路径.Visible = True
    End Sub

    Private Sub Label可选路径_Click(sender As Object, e As EventArgs) Handles Label可选路径.Click
        切换选项卡控制颜色(sender)
        Me.Panel可选路径.Visible = True
    End Sub

    Private Sub Label地区和语言_Click(sender As Object, e As EventArgs) Handles Label地区和语言.Click
        切换选项卡控制颜色(sender)
        Me.Panel地区和语言.Visible = True
    End Sub

    Private Sub Label网络服务_Click(sender As Object, e As EventArgs) Handles Label网络服务.Click
        切换选项卡控制颜色(sender)
        Me.Panel网络服务.Visible = True
    End Sub

    Private Sub Label启动项_Click(sender As Object, e As EventArgs) Handles Label启动项.Click
        切换选项卡控制颜色(sender)
        Me.Panel启动项.Visible = True
    End Sub

    Private Sub Label功能_Click(sender As Object, e As EventArgs) Handles Label功能.Click
        切换选项卡控制颜色(sender)
        Me.Panel功能.Visible = True
    End Sub

    Private Sub Label界面尺寸_Click(sender As Object, e As EventArgs) Handles Label界面尺寸.Click
        切换选项卡控制颜色(sender)
        Me.Panel界面尺寸.Visible = True
    End Sub

    Private Sub Label字体样式_Click(sender As Object, e As EventArgs) Handles Label字体样式.Click
        切换选项卡控制颜色(sender)
        Me.Panel字体样式.Visible = True
    End Sub

    Private Sub Label图标_Click(sender As Object, e As EventArgs) Handles Label图标.Click
        切换选项卡控制颜色(sender)
        Me.Panel图标.Visible = True
    End Sub

    Public Sub 读取设置()
        Me.TextBox星露谷游戏路径.Text = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText
        Me.TextBox模组数据仓库路径.Text = xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText
        Me.TextBox星露谷游戏备份路径.Text = xml_Settings.SelectSingleNode("data/StardewValleyGameBackUpPath").InnerText
        Me.TextBox6.Text = xml_Settings.SelectSingleNode("data/VisualStudioCodePath").InnerText
        Me.TextBox7.Text = xml_Settings.SelectSingleNode("data/VisualStudioPath").InnerText
        Me.TextBox13.Text = xml_Settings.SelectSingleNode("data/NotepadPath").InnerText
        Select Case xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText
            Case 1
                Me.RadioButton1.Checked = True
            Case 2
                Me.RadioButton2.Checked = True
        End Select
        Select Case xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText
            Case 1
                Me.RadioButton11.Checked = True
            Case 2
                Me.RadioButton10.Checked = True
        End Select
        Select Case xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText
            Case "Chinese"
                Me.RadioButton4.Checked = True
            Case "English"
                Me.RadioButton3.Checked = True
        End Select

        If ST1.是否正在使用自定义语言包 = False Then
            Select Case xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText
                Case "Chinese"
                    Me.RadioButton简体中文.Checked = True
                Case "English"
                    Me.RadioButton英语.Checked = True
            End Select
        Else
            Me.RadioButton简体中文.Enabled = False
            Me.RadioButton英语.Enabled = False
        End If

        Me.TextBox11.Text = xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText
        Me.TextBox9.Text = xml_Settings.SelectSingleNode("data/GitHubPersonalAccessTokens").InnerText
        Me.TextBox8.Text = xml_Settings.SelectSingleNode("data/GiteePersonalAccessTokens").InnerText
        Select Case xml_Settings.SelectSingleNode("data/StartOptions").InnerText
            Case 1
                Me.RadioButton8.Checked = True
            Case 2
                Me.RadioButton9.Checked = True
            Case 3
                Me.RadioButton12.Checked = True
            Case 4
                Me.RadioButton13.Checked = True
        End Select
        Me.TextBox10.Text = xml_Settings.SelectSingleNode("data/UserStartOptions").InnerText
        Me.CheckBox8.Checked = xml_Settings.SelectSingleNode("data/AutoCheckSMUIUpdates").InnerText
        Me.CheckBox7.Checked = xml_Settings.SelectSingleNode("data/AutoGetNews").InnerText
        Me.CheckBox6.Checked = xml_Settings.SelectSingleNode("data/StatisticsOnTheNmberOfParticipatingUsers").InnerText
        Me.CheckBox5.Checked = xml_Settings.SelectSingleNode("data/SaveInterfaceLayout").InnerText
        Me.CheckBox1.Checked = xml_Settings.SelectSingleNode("data/DragDropCompatibilityForAdministrator").InnerText
        Me.TrackBar1.Value = xml_Settings.SelectSingleNode("data/CategoryPanelWidth").InnerText
        Me.TrackBar2.Value = xml_Settings.SelectSingleNode("data/DetailsPanelWidth").InnerText

    End Sub

    Public Sub 保存设置()
        If xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText <> Me.TextBox星露谷游戏路径.Text Then
            是否改动了关键路径 = True
        End If
        xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText = Me.TextBox星露谷游戏路径.Text

        If xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText <> Me.TextBox模组数据仓库路径.Text Then
            是否改动了关键路径 = True
        End If
        xml_Settings.SelectSingleNode("data/ModRepositoryPath").InnerText = Me.TextBox模组数据仓库路径.Text

        xml_Settings.SelectSingleNode("data/StardewValleyGameBackUpPath").InnerText = Me.TextBox星露谷游戏备份路径.Text
        xml_Settings.SelectSingleNode("data/VisualStudioCodePath").InnerText = Me.TextBox6.Text
        xml_Settings.SelectSingleNode("data/VisualStudioPath").InnerText = Me.TextBox7.Text
        xml_Settings.SelectSingleNode("data/NotepadPath").InnerText = Me.TextBox13.Text
        If Me.RadioButton1.Checked = True Then
            xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText = 1
        Else
            xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText = 2
        End If
        If Me.RadioButton11.Checked = True Then
            xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText = 1
        Else
            xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText = 2
        End If
        If Me.RadioButton4.Checked = True Then
            xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText = "Chinese"
        Else
            xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText = "English"
        End If
        If ST1.是否正在使用自定义语言包 = False Then
            If Me.RadioButton简体中文.Checked = True Then
                xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "Chinese"
            Else
                xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English"
            End If
        End If
        xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText = Me.TextBox11.Text
        xml_Settings.SelectSingleNode("data/GitHubPersonalAccessTokens").InnerText = Me.TextBox9.Text
        xml_Settings.SelectSingleNode("data/GiteePersonalAccessTokens").InnerText = Me.TextBox8.Text
        If Me.RadioButton8.Checked = True Then
            xml_Settings.SelectSingleNode("data/StartOptions").InnerText = 1
        ElseIf Me.RadioButton9.Checked = True Then
            xml_Settings.SelectSingleNode("data/StartOptions").InnerText = 2
        ElseIf Me.RadioButton12.Checked = True Then
            xml_Settings.SelectSingleNode("data/StartOptions").InnerText = 3
        ElseIf Me.RadioButton13.Checked = True Then
            xml_Settings.SelectSingleNode("data/StartOptions").InnerText = 4
        End If
        xml_Settings.SelectSingleNode("data/UserStartOptions").InnerText = Me.TextBox10.Text
        xml_Settings.SelectSingleNode("data/AutoCheckSMUIUpdates").InnerText = Me.CheckBox8.Checked
        xml_Settings.SelectSingleNode("data/AutoGetNews").InnerText = Me.CheckBox7.Checked
        xml_Settings.SelectSingleNode("data/StatisticsOnTheNmberOfParticipatingUsers").InnerText = Me.CheckBox6.Checked
        xml_Settings.SelectSingleNode("data/SaveInterfaceLayout").InnerText = Me.CheckBox5.Checked
        xml_Settings.SelectSingleNode("data/DragDropCompatibilityForAdministrator").InnerText = Me.CheckBox1.Checked
        xml_Settings.SelectSingleNode("data/CategoryPanelWidth").InnerText = Me.TrackBar1.Value
        xml_Settings.SelectSingleNode("data/DetailsPanelWidth").InnerText = Me.TrackBar2.Value


        xml_Settings.SelectSingleNode("data/MainWindowWidth").InnerText = Form1.Width
        xml_Settings.SelectSingleNode("data/MainWindowHeight").InnerText = Form1.Height
        xml_Settings.Save(Path1.应用程序设置文件路径)
        刷新标题栏主信息显示()
        If Me.TextBox11.Text = "" Then Form1.Label7.Text = ""
    End Sub

    Dim 是否改动了关键路径 As Boolean = False

    Private Sub Label确定_Click(sender As Object, e As EventArgs) Handles Label确定.Click
        保存设置()
        If 是否改动了关键路径 = True Then
            扫描数据子库()
            清除分类列表()
            清除模组列表()
        End If
        Me.Close()
    End Sub

    Private Sub Label应用_Click(sender As Object, e As EventArgs) Handles Label应用.Click
        保存设置()
        If 是否改动了关键路径 = True Then
            扫描数据子库()
            清除分类列表()
            清除模组列表()
        End If
    End Sub

    Private Sub Label取消_Click(sender As Object, e As EventArgs) Handles Label取消.Click
        Me.Close()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim p1 As String() = {}
        ReDim Preserve p1(p1.Count)
        p1(p1.Count - 1) = 获取动态多语言文本("data/DynamicText/Settings.3")
        Dim MyReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 413150")
        If MyReg IsNot Nothing Then
            ReDim Preserve p1(p1.Count)
            p1(p1.Count - 1) = MyReg.GetValue("InstallLocation").ToString()
        End If
        Dim MyReg2 As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\GOG.com\Games\1453375253")
        If MyReg2 IsNot Nothing Then
            ReDim Preserve p1(p1.Count)
            p1(p1.Count - 1) = MyReg2.GetValue("PATH").ToString()
        End If
        Dim diskMayBe As String() = {"C", "D", "E", "F", "G", "H"} ', "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        For i = 0 To diskMayBe.Count - 1
            If My.Computer.FileSystem.FileExists(diskMayBe(i) & ":\Program Files\Steam\steamapps\common\Stardew Valley" & "\Stardew Valley.exe") = True Then
                If Array.IndexOf(p1, diskMayBe(i) & ":\Program Files\Steam\steamapps\common\Stardew Valley") = -1 Then
                    ReDim Preserve p1(p1.Count)
                    p1(p1.Count - 1) = diskMayBe(i) & ":\Program Files\Steam\steamapps\common\Stardew Valley"
                End If
            End If
            If My.Computer.FileSystem.FileExists(diskMayBe(i) & ":\Program Files (x86)\Steam\steamapps\common\Stardew Valley" & "\Stardew Valley.exe") = True Then
                If Array.IndexOf(p1, diskMayBe(i) & ":\Program Files (x86)\Steam\steamapps\common\Stardew Valley") = -1 Then
                    ReDim Preserve p1(p1.Count)
                    p1(p1.Count - 1) = diskMayBe(i) & ":\Program Files (x86)\Steam\steamapps\common\Stardew Valley"
                End If
            End If
            If My.Computer.FileSystem.FileExists(diskMayBe(i) & ":\Program Files\ModifiableWindowsApps\Stardew Valley" & "\Stardew Valley.exe") = True Then
                If Array.IndexOf(p1, diskMayBe(i) & ":\Program Files\ModifiableWindowsApps\Stardew Valley") = -1 Then
                    ReDim Preserve p1(p1.Count)
                    p1(p1.Count - 1) = diskMayBe(i) & ":\Program Files\ModifiableWindowsApps\Stardew Valley"
                End If
            End If
            If My.Computer.FileSystem.FileExists(diskMayBe(i) & ":\SteamLibrary\steamapps\common\Stardew Valley" & "\Stardew Valley.exe") = True Then
                If Array.IndexOf(p1, diskMayBe(i) & ":\SteamLibrary\steamapps\common\Stardew Valley") = -1 Then
                    ReDim Preserve p1(p1.Count)
                    p1(p1.Count - 1) = diskMayBe(i) & ":\SteamLibrary\steamapps\common\Stardew Valley"
                End If
            End If
        Next
R1:
        Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Settings.1"), p1, 获取动态多语言文本("data/DynamicText/Settings.2"), 100, 600)
        Dim b As Integer = a.ShowDialog(Me)
        Select Case b
            Case -1
                Exit Sub
            Case 0
                Dim x As New WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser With {
                    .Title = 获取动态多语言文本("data/DynamicText/Settings.1"),
                    .Multiselect = False
                }
                x.ShowDialog()
                If x.SelectedFolder = "" Then GoTo R1
                If My.Computer.FileSystem.FileExists(x.SelectedFolder & "\Stardew Valley.exe") = True Or My.Computer.FileSystem.FileExists(x.SelectedFolder & "\StardewValley.exe") = True Then
                    Me.TextBox星露谷游戏路径.Text = x.SelectedFolder
                Else
                    Dim c As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Settings.5"), 100, 500)
                    c.ShowDialog(Me)
                    GoTo R1
                End If
            Case Else
                Me.TextBox星露谷游戏路径.Text = p1(b)
        End Select
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim p1 As String = ""
        If My.Computer.FileSystem.FileExists("C:\Users\Public\1059 Studio\SMUI Client 4\Settings\UserSettings.xml") = True Then
            Dim x As New XmlDocument
            x.Load("C:\Users\Public\1059 Studio\SMUI Client 4\Settings\UserSettings.xml")
            p1 = x.SelectSingleNode("Data/LibraryPath").InnerText
        End If
        Dim a1 As String() = {}
        If p1 <> "" Then
            a1 = {获取动态多语言文本("data/DynamicText/Settings.8"), 获取动态多语言文本("data/DynamicText/Settings.9") & p1}
        Else
            a1 = {获取动态多语言文本("data/DynamicText/Settings.8")}
        End If
R1:
        Dim a As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Settings.6"), a1, 获取动态多语言文本("data/DynamicText/Settings.7").Replace("/crlf/", vbNewLine), 200, 600)
        Dim b As Integer = a.ShowDialog(Me)
        Select Case b
            Case -1
                Exit Sub
            Case 0
                Dim x As New WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser With {
                  .Title = 获取动态多语言文本("data/DynamicText/Settings.10"),
                  .Multiselect = False
                }
                x.ShowDialog()
                If x.SelectedFolder = "" Then GoTo R1
                Dim c As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Settings.11"), {获取动态多语言文本("data/DynamicText/Yes"), 获取动态多语言文本("data/DynamicText/No")}, x.SelectedFolder, 100, 500)
                Dim d As Integer = c.ShowDialog(Me)
                Select Case d
                    Case -1
                        Exit Sub
                    Case 0
                        If My.Computer.FileSystem.DirectoryExists(x.SelectedFolder & "\Default Sub Library") = False Then
                            My.Computer.FileSystem.CreateDirectory(x.SelectedFolder & "\Default Sub Library")
                        End If
                        If My.Computer.FileSystem.FileExists(x.SelectedFolder & "\OS") = False Then
                            My.Computer.FileSystem.WriteAllText(x.SelectedFolder & "\OS", My.Computer.Info.OSFullName, False, Encoding.UTF8)
                        End If
                        If My.Computer.FileSystem.FileExists(x.SelectedFolder & "\MANIFEST") = False Then
                            My.Computer.FileSystem.WriteAllText(x.SelectedFolder & "\MANIFEST", "This is your Mod Repository root path.", False, Encoding.UTF8)
                        End If
                        Me.TextBox模组数据仓库路径.Text = x.SelectedFolder
                    Case 1
                        GoTo R1
                End Select
            Case 1
                Me.TextBox模组数据仓库路径.Text = p1
        End Select
    End Sub

    Public Sub 挑选图标的绑定按钮事件()
        For Each a As Button In Me.Panel2.Controls
            Select Case a.Tag
                Case "1"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 1
                            Form1.Icon = My.Resources.ICO防风草
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO防风草.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "2"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 2
                            Form1.Icon = My.Resources.ICO陈年蓝月亮葡萄酒
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO陈年蓝月亮葡萄酒.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "3"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 3
                            Form1.Icon = My.Resources.ICO河豚
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO河豚.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "4"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 4
                            Form1.Icon = My.Resources.ICO金色椰子
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO金色椰子.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "5"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 5
                            Form1.Icon = My.Resources.ICO熔岩菇
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO熔岩菇.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "6"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 6
                            Form1.Icon = My.Resources.ICO神盾药剂
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO神盾药剂.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "7"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 7
                            Form1.Icon = My.Resources.ICO椰林飘香
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO椰林飘香.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "8"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 8
                            Form1.Icon = My.Resources.ICO野山葵
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO野山葵.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
                Case "9"
                    AddHandler a.Click,
                        Sub()
                            My.Settings.图标 = 9
                            Form1.Icon = My.Resources.ICO_HC_巧克力
                            Dim x As New IO.FileStream(Path1.应用程序用户数据路径 & "\ico.ico", IO.FileMode.Create)
                            My.Resources.ICO_HC_巧克力.Save(x)
                            x.Close()
                            挑选图标按钮确认执行()
                        End Sub
            End Select
        Next
    End Sub

    Public Sub 挑选图标按钮确认执行()
        My.Settings.Save()
        If My.Computer.FileSystem.FileExists(Path1.开始菜单快捷方式路径) = True Then 创建快捷方式(Application.ExecutablePath, Path1.应用程序用户数据路径 & "\ico.ico", Path1.开始菜单快捷方式路径)
        If My.Computer.FileSystem.FileExists(Path1.桌面快捷方式路径) = True Or Me.CheckBox2.Checked = True Then 创建快捷方式(Application.ExecutablePath, Path1.应用程序用户数据路径 & "\ico.ico", Path1.桌面快捷方式路径)
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        Dim a As New SMUI.Windows.Nexus.GetUserInfo With {
            .ST_ApiKey = Me.TextBox11.Text
        }
        Dim x As String = a.StartGet()
        If x <> "" Then
            Form1.Label7.Text = 获取动态多语言文本("data/DynamicText/LogInFailed")
            MsgBox(x, MsgBoxStyle.Critical)
        Else
            Dim c As String = ""
            c &= "User Name: " & a.name & vbNewLine
            c &= "User ID: " & a.user_id & vbNewLine
            c &= "User Email: " & a.email & vbNewLine
            c &= "Is Premium: " & a.is_premium & vbNewLine
            c &= "Is Supporter: " & a.is_supporter & vbNewLine
            c &= "Hour Limit: " & a.hourly_remaining & "/" & a.hourly_limit & vbNewLine
            c &= "Daily Limit: " & a.daily_remaining & "/" & a.daily_limit
            Form1.Label7.Text = 获取动态多语言文本("data/DynamicText/LoggedNexusWebApi") & vbNewLine & 获取动态多语言文本("data/DynamicText/UserName") & a.name
            Dim m As New SingleSelectionDialog("NEXUS WEB API", {"OK"}, c, 200)
            m.ShowDialog(Me)
        End If
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles DarkButton2.Click
        Select Case Me.TextBox11.PasswordChar
            Case "●"
                Me.TextBox11.PasswordChar = ""
            Case ""
                Me.TextBox11.PasswordChar = "●"
        End Select
    End Sub

    Private Sub DarkButton4_Click(sender As Object, e As EventArgs) Handles DarkButton4.Click
        If ST1.是否安装了谷歌浏览器组件 = True And ST1.用于内置谷歌浏览器_是否已经初始化 = False Then
            初始化谷歌浏览器组件() : ST1.用于内置谷歌浏览器_是否已经初始化 = True
        End If
        If ChromiumBrowser.Visible = False Then ChromiumBrowser.Show(Form1)
        If ChromiumBrowser.WindowState = FormWindowState.Minimized Then ChromiumBrowser.WindowState = FormWindowState.Normal
        ChromiumBrowser.ChromiumWebBrowser1.LoadUrl("https://users.nexusmods.com/auth/sign_in")
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim a As New WK.Libraries.BetterFolderBrowserNS.BetterFolderBrowser
        a.ShowDialog()
        If a.SelectedFolder = "" Then Exit Sub
        TextBox星露谷游戏备份路径.Text = a.SelectedFolder
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click
        Dim a As New OpenFileDialog With {
            .Filter = "Code.exe|Code.exe"
        }
        If My.Computer.FileSystem.DirectoryExists("C:\Users\" & Environment.UserName & "\AppData\Local\Programs\Microsoft VS Code") = True Then
            a.InitialDirectory = "C:\Users\" & Environment.UserName & "\AppData\Local\Programs\Microsoft VS Code"
        End If
        a.ShowDialog(Me)
        If a.FileName = "" Then Exit Sub
        TextBox6.Text = a.FileName

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click
        Dim a As New OpenFileDialog With {
            .Filter = "devenv.exe|devenv.exe"
        }
        If My.Computer.FileSystem.DirectoryExists("C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE") = True Then
            a.InitialDirectory = "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE"
        End If
        a.ShowDialog(Me)
        If a.FileName = "" Then Exit Sub
        TextBox7.Text = a.FileName

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim a As New OpenFileDialog With {
            .Filter = "notepad++.exe|notepad++.exe"
        }
        If My.Computer.FileSystem.DirectoryExists("C:\Program Files\Notepad++") = True Then
            a.InitialDirectory = "C:\Program Files\Notepad++"
        End If
        a.ShowDialog(Me)

        If a.FileName = "" Then Exit Sub
        TextBox13.Text = a.FileName
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://stardewmui.fandom.com/wiki/Third-party_language_file_publishing_page_address")
    End Sub
End Class