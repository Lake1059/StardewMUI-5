
Imports System.Xml
Imports DarkUI.Controls
Imports SMUI.GUI.Class1

Module 设置管理

    Sub 生成应用程序缓存文件夹()
        If My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Path1.应用程序设置文件路径)) = False Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Path1.应用程序设置文件路径))
        End If
        If My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Path1.更新安装程序文件路径)) = False Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Path1.更新安装程序文件路径))
        End If
        If My.Computer.FileSystem.DirectoryExists(Path1.应用程序插件数据路径) = False Then
            My.Computer.FileSystem.CreateDirectory(Path1.应用程序插件数据路径)
        End If
        If My.Computer.FileSystem.DirectoryExists(Path1.用于发行版的DLC路径) = False Then
            My.Computer.FileSystem.CreateDirectory(Path1.用于发行版的DLC路径)
        End If
    End Sub

    Public Sub 启动时加载用户设置()
        xml_Settings_Lock.LoadXml(My.Resources.SettingsEmpty)
        加载图标选择()
        生成应用程序缓存文件夹()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\steam_appid.txt") = True Then
            ST1.当前是否正在使用Steam版本 = True
        End If
        If My.Computer.FileSystem.FileExists(Path1.应用程序设置文件路径) = True Then
            加载XML设置数据()
            更新XML设置数据()
            If xml_Settings.SelectSingleNode("data/SaveInterfaceLayout").InnerText.ToLower = "true" Then
                Form1.Width = xml_Settings.SelectSingleNode("data/MainWindowWidth").InnerText
                Form1.Height = xml_Settings.SelectSingleNode("data/MainWindowHeight").InnerText
            End If
            If xml_Settings.SelectSingleNode("data/ItemsHeightAdd").InnerText <> "0" Then
                Dim int1 As Integer = xml_Settings.SelectSingleNode("data/ItemsHeightAdd").InnerText
                Form1.ListView1.StateImageList.ImageSize = New Size(3, 25 + int1)
                Form1.ListView2.StateImageList.ImageSize = New Size(3, 25 + int1)
                重新加载列表视图的彩图块()
            End If
            If xml_Settings.SelectSingleNode("data/CategoryPanelWidth").InnerText > 200 Then
                Form1.Panel9.Width = xml_Settings.SelectSingleNode("data/CategoryPanelWidth").InnerText
            End If
            If xml_Settings.SelectSingleNode("data/DetailsPanelWidth").InnerText > 250 Then
                Form1.Panel10.Width = xml_Settings.SelectSingleNode("data/DetailsPanelWidth").InnerText
            End If
            加载主窗口字体设置()
        Else
            xml_Settings.LoadXml(My.Resources.SettingsEmpty)
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN"
                    xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "Chinese"
                    xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText = 1
                    xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText = "Chinese"
                    xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText = 1
                    SMUI.Windows.Core.DYString.TranslateAllStringToChinese()
                Case "en-US"
                    xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English"
                    xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText = 2
                    xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText = "English"
                    xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText = 2
                Case Else
                    xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English"
                    xml_Settings.SelectSingleNode("data/DownloadSmuiUndateFrom").InnerText = 2
                    xml_Settings.SelectSingleNode("data/OnlineContentLanguage").InnerText = "English"
                    xml_Settings.SelectSingleNode("data/OnlineContentFrom").InnerText = 2
            End Select
            xml_Settings.Save(Path1.应用程序设置文件路径)
        End If

        If xml_Settings.SelectSingleNode("data/PrivacyChoice").InnerText = "" Then
            Form隐私选项.ShowDialog()
        End If

        If ST1.是否正在使用自定义语言包 = False Then
            Select Case xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText
                Case "Chinese"
                    xml_lang.LoadXml(My.Resources.English)
                Case Else
                    xml_lang.LoadXml(My.Resources.English)
                    加载界面的多语言()
            End Select
        End If
    End Sub

    Private Sub 加载XML设置数据()
        Dim xml_X As New XmlDocument
        xml_X.Load(Path1.应用程序设置文件路径)
        xml_Settings.LoadXml(My.Resources.SettingsEmpty)
        For Each 元素 As XmlElement In xml_X.DocumentElement.ChildNodes
            If xml_Settings.SelectSingleNode("data/" & 元素.Name) Is Nothing Then Continue For
            xml_Settings.SelectSingleNode("data/" & 元素.Name).InnerText = xml_X.SelectSingleNode("data/" & 元素.Name).InnerText
        Next
    End Sub

    Private Sub 更新XML设置数据()
        Dim xml_A As New XmlDocument
        xml_A.LoadXml(My.Resources.SettingsEmpty)
        For Each 元素 As XmlElement In xml_Settings_Lock.DocumentElement.ChildNodes
            If xml_Settings.SelectSingleNode("data/" & 元素.Name) IsNot Nothing Then
                xml_A.SelectSingleNode("data/" & 元素.Name).InnerText = xml_Settings.SelectSingleNode("data/" & 元素.Name).InnerText
            Else
                xml_A.SelectSingleNode("data/" & 元素.Name).InnerText = xml_Settings_Lock.SelectSingleNode("data/" & 元素.Name).InnerText
            End If
        Next
        xml_A.Save(Path1.应用程序设置文件路径)
    End Sub

    Public Sub 加载图标选择()
        If My.Computer.FileSystem.FileExists(Path1.应用程序用户数据路径 & "\app.png") = True Then
            Using fs As New IO.FileStream(Path1.应用程序用户数据路径 & "\app.png", IO.FileMode.Open, IO.FileAccess.Read)
                Dim img1 As Bitmap = Image.FromStream(fs)
                Form1.Icon = Icon.FromHandle(img1.GetHicon())
                fs.Close()
            End Using
        End If
    End Sub

    Public Sub 重新加载列表视图的彩图块()
        Form1.ImageList1.Images.Clear()
        Form1.ImageList1.Images.Add(My.Resources.白_1)
        Form1.ImageList1.Images.Add(My.Resources.红_1)
        Form1.ImageList1.Images.Add(My.Resources.橙_1)
        Form1.ImageList1.Images.Add(My.Resources.黄_1)
        Form1.ImageList1.Images.Add(My.Resources.绿_1)
        Form1.ImageList1.Images.Add(My.Resources.青_1)
        Form1.ImageList1.Images.Add(My.Resources.蓝_1)
        Form1.ImageList1.Images.Add(My.Resources.紫_1)
    End Sub

    Public Sub 加载主窗口字体设置()
        If xml_Settings.SelectSingleNode("data/FontName9pt").InnerText = "" Then Exit Sub
        If xml_Settings.SelectSingleNode("data/FontName9pt").InnerText = "Microsoft YaHei UI" Then Exit Sub
        Form1.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM1.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM2.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM3.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM4.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM5.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM6.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM7.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM8.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM9.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM10.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM11.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM12.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM13.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM内容中心.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM应用程序目录集.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM模组列表.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM游戏目录集.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)
        Form1.DCM链接汇总.Font = New Font(xml_Settings.SelectSingleNode("data/FontName9pt").InnerText, 9)

    End Sub



End Module
