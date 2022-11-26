Imports Microsoft.Win32

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim key As RegistryKey

            key = Registry.ClassesRoot.CreateSubKey(".smuispak")
            key.SetValue("", "Lake1059.SMUI.smuispak")
            key.SetValue("Content Type", "application/smuispak")
            key = Registry.ClassesRoot.CreateSubKey("Lake1059.SMUI.smuispak")
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN", "zh-TW", "zh-HK", "zh"
                    key.SetValue("", "SMUI 数据子库打包文件")
                Case "ru_RU"
                    key.SetValue("", "Файл пакета подбиблиотеки данных SMUI")
                Case "ja_JP"
                    key.SetValue("", "SMUI データ サブライブラリ パッケージ ファイル")
                Case Else
                    key.SetValue("", "SMUI Sub-library Package File")
            End Select
            Dim keySub As RegistryKey = key.CreateSubKey("DefaultIcon")
            keySub.SetValue("", Application.StartupPath & "\img\子库打包.ico")
            keySub = key.CreateSubKey("shell")
            keySub = keySub.CreateSubKey("open")
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN", "zh-TW", "zh-HK", "zh"
                    keySub.SetValue("", "在 SMUI 中导入数据子库")
                Case Else
                    keySub.SetValue("", "Import Sub-library in SMUI")
            End Select
            keySub = keySub.CreateSubKey("command")
            'keySub.SetValue("", """" & "C:\Visual Basic\StardewMUI 5\SMUI.GUI\bin\Debug\SMUI.GUI.exe" & """" & " " & """" & "%1" & """")
            keySub.SetValue("", """" & Application.StartupPath & "\SMUI.GUI.exe" & """" & " " & """" & "%1" & """")



            key = Registry.ClassesRoot.CreateSubKey(".smuicpak")
            key.SetValue("", "Lake1059.SMUI.smuicpak")
            key.SetValue("Content Type", "application/smuicpak")
            key = Registry.ClassesRoot.CreateSubKey("Lake1059.SMUI.smuicpak")
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN", "zh-TW", "zh-HK", "zh"
                    key.SetValue("", "SMUI 分类数据打包文件")
                Case "ru_RU"
                    key.SetValue("", "Файл пакета данных категории SMUI")
                Case "ja_JP"
                    key.SetValue("", "SMUI 分類パケット ファイル")
                Case Else
                    key.SetValue("", "SMUI category data package file")
            End Select
            Dim keySub2 As RegistryKey = key.CreateSubKey("DefaultIcon")
            keySub2.SetValue("", Application.StartupPath & "\img\分类打包.ico")
            keySub2 = key.CreateSubKey("shell")
            keySub2 = keySub2.CreateSubKey("open")
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN", "zh-TW", "zh-HK", "zh"
                    keySub2.SetValue("", "在 SMUI 中导入分类")
                Case Else
                    keySub2.SetValue("", "Import Category in SMUI")
            End Select
            keySub2 = keySub2.CreateSubKey("command")
            'keySub2.SetValue("", """" & "C:\Visual Basic\StardewMUI 5\SMUI.GUI\bin\Debug\SMUI.GUI.exe" & """" & " " & """" & "%1" & """")
            keySub2.SetValue("", """" & Application.StartupPath & "\SMUI.GUI.exe" & """" & " " & """" & "%1" & """")



            key = Registry.ClassesRoot.CreateSubKey(".smuimpak")
            key.SetValue("", "Lake1059.SMUI.smuimpak")
            key.SetValue("Content Type", "application/smuimpak")
            key = Registry.ClassesRoot.CreateSubKey("Lake1059.SMUI.smuimpak")
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN", "zh-TW", "zh-HK", "zh"
                    key.SetValue("", "SMUI 项数据打包文件")
                Case "ru_RU"
                    key.SetValue("", "Файл пакета данных элемента SMUI")
                Case "ja_JP"
                    key.SetValue("", "SMUI アイテム データ パッケージ ファイル")
                Case Else
                    key.SetValue("", "SMUI item data package file")
            End Select
            Dim keySub3 As RegistryKey = key.CreateSubKey("DefaultIcon")
            keySub3.SetValue("", Application.StartupPath & "\img\项打包.ico")
            keySub3 = key.CreateSubKey("shell")
            keySub3 = keySub3.CreateSubKey("open")
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN", "zh-TW", "zh-HK", "zh"
                    keySub3.SetValue("", "在 SMUI 中导入项")
                Case Else
                    keySub3.SetValue("", "Import Item in SMUI")
            End Select
            keySub3 = keySub3.CreateSubKey("command")
            'keySub3.SetValue("", """" & "C:\Visual Basic\StardewMUI 5\SMUI.GUI\bin\Debug\SMUI.GUI.exe" & """" & " " & """" & "%1" & """")
            keySub3.SetValue("", """" & Application.StartupPath & "\SMUI.GUI.exe" & """" & " " & """" & "%1" & """")

            MsgBox("Done")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Registry.ClassesRoot.DeleteSubKeyTree(".smuispak", False)
            Registry.ClassesRoot.DeleteSubKeyTree(".smuicpak", False)
            Registry.ClassesRoot.DeleteSubKeyTree(".smuimpak", False)

            Registry.ClassesRoot.DeleteSubKeyTree("Lake1059.SMUI.smuispak", False)
            Registry.ClassesRoot.DeleteSubKeyTree("Lake1059.SMUI.smuicpak", False)
            Registry.ClassesRoot.DeleteSubKeyTree("Lake1059.SMUI.smuimpak", False)

            MsgBox("Done")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
