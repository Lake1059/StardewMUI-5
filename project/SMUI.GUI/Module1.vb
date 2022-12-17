Imports System.Xml
Imports Microsoft.Win32
Imports SMUI.GUI.Class1

Module Module1

    Public Sub 谷歌浏览器组件版本提醒()
        If ST1.当前是否正在使用Steam版本 = True Then Exit Sub
        If xml_Settings.SelectSingleNode("data/ChromiumEmbeddedFrameworkVersionTag").InnerText <> "A2" Then
            Dim dig As New SMUI.Windows.PakManager.SingleSelectionDialog("", {获取动态多语言文本("data/DynamicText/OK"), 获取动态多语言文本("data/DynamicText/neverRemindAgain")， "前往蓝奏云", "Go to Google Drive"}, 获取动态多语言文本("data/DynamicText/ChromiumVersionWarn").Replace("{1}", "107.1.90"), 150, 500)
            Dim digback As Integer = dig.ShowDialog(Form1)
            If digback = 1 Then
                xml_Settings.SelectSingleNode("data/ChromiumEmbeddedFrameworkVersionTag").InnerText = "A2"
            End If
            If digback = 2 Then
                Process.Start("https://lake1059.lanzouv.com/b0daefzoh")
            End If
            If digback = 3 Then
                Process.Start("https://drive.google.com/drive/folders/1UDZoHUOibIeFACRkn0ZI_DzaT_Zb4sA2?usp=sharing")
            End If
        End If
    End Sub

    Public Sub 初始化谷歌浏览器组件()
        Try
            Dim _settings As New CefSharp.WinForms.CefSettings With {
                    .PersistSessionCookies = True,
                    .CachePath = Path1.应用程序用户数据路径 & "\WebCache"
                }
            CefSharp.Cef.Initialize(_settings)
            添加调试文本(获取动态多语言文本("data/DynamicText/Other.1"), Color1.蓝色)
        Catch ex As Exception
            添加调试文本(获取动态多语言文本("data/DynamicText/Other.2") & vbNewLine & ex.Message, Color1.黄色)
        End Try
    End Sub


End Module
