
Imports System.Xml

Module 设置管理
    Public Sub 启动时加载用户设置()
        xml_Settings_Lock.LoadXml(My.Resources.SettingsEmpty)
        加载图标选择()
        If My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Path1.应用程序设置文件路径)) = False Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Path1.应用程序设置文件路径))
        End If
        If My.Computer.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(Path1.更新安装程序文件路径)) = False Then
            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(Path1.更新安装程序文件路径))
        End If
        If My.Computer.FileSystem.DirectoryExists(Path1.应用程序插件数据路径) = False Then
            My.Computer.FileSystem.CreateDirectory(Path1.应用程序插件数据路径)
        End If
        If My.Computer.FileSystem.FileExists(Path1.应用程序设置文件路径) = True Then
            加载XML设置数据()
            更新XML设置数据()
            If xml_Settings.SelectSingleNode("data/SaveInterfaceLayout").InnerText.ToLower = "true" Then
                Form1.Width = xml_Settings.SelectSingleNode("data/MainWindowWidth").InnerText
                Form1.Height = xml_Settings.SelectSingleNode("data/MainWindowHeight").InnerText
            End If
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
        If ST1.是否正在使用自定义语言包 = True Then Exit Sub
        Select Case xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText
            Case "Chinese"
                xml_lang.LoadXml(My.Resources.English)
            Case "English"
                xml_lang.LoadXml(My.Resources.English)
                加载界面的多语言()
            Case Else
                xml_lang.LoadXml(My.Resources.English)
                加载界面的多语言()
        End Select

    End Sub

    Private Sub 加载XML设置数据()
        Dim xml_X As New XmlDocument
        xml_X.Load(Path1.应用程序设置文件路径)
        xml_Settings.LoadXml(My.Resources.SettingsEmpty)
        For Each 元素 As XmlElement In xml_X.DocumentElement.ChildNodes
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
        Select Case My.Settings.图标
            Case 1
                Form1.Icon = My.Resources.ICO防风草
            Case 2
                Form1.Icon = My.Resources.ICO陈年蓝月亮葡萄酒
            Case 3
                Form1.Icon = My.Resources.ICO河豚
            Case 4
                Form1.Icon = My.Resources.ICO金色椰子
            Case 5
                Form1.Icon = My.Resources.ICO熔岩菇
            Case 6
                Form1.Icon = My.Resources.ICO神盾药剂
            Case 7
                Form1.Icon = My.Resources.ICO椰林飘香
            Case 8
                Form1.Icon = My.Resources.ICO野山葵
            Case 9
                Form1.Icon = My.Resources.ICO_HC_巧克力
        End Select
    End Sub
End Module
