
Imports System.Xml
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
    End Sub

    Public Sub 启动时加载用户设置()
        xml_Settings_Lock.LoadXml(My.Resources.SettingsEmpty)
        加载图标选择()
        生成应用程序缓存文件夹()
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
        Select Case My.Settings.图标
            Case 1
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.防风草, Bitmap).GetHicon())
            Case 2
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_2, Bitmap).GetHicon())
            Case 3
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_3, Bitmap).GetHicon())
            Case 4
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_4, Bitmap).GetHicon())
            Case 5
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_5, Bitmap).GetHicon())
            Case 6
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_6, Bitmap).GetHicon())
            Case 7
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_7, Bitmap).GetHicon())
            Case 8
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_8, Bitmap).GetHicon())
            Case 9
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_9, Bitmap).GetHicon())
            Case 10
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_10, Bitmap).GetHicon())
            Case 11
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_11, Bitmap).GetHicon())
            Case 12
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_12, Bitmap).GetHicon())
            Case 13
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_13, Bitmap).GetHicon())
            Case 14
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_14, Bitmap).GetHicon())
            Case 15
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_15, Bitmap).GetHicon())
            Case 16
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_16, Bitmap).GetHicon())
            Case 17
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_17, Bitmap).GetHicon())
            Case 18
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_18, Bitmap).GetHicon())
            Case 19
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_19, Bitmap).GetHicon())
            Case 20
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_20, Bitmap).GetHicon())
            Case 21
                Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.HC_巧克力, Bitmap).GetHicon())
            Case 22
                'Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_22, Bitmap).GetHicon())
            Case 23
                'Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.EXEICO_23, Bitmap).GetHicon())
            Case 24
                'Form1.Icon = Icon.FromHandle(DirectCast(My.Resources.MyPic48, Bitmap).GetHicon())
        End Select
    End Sub
End Module
