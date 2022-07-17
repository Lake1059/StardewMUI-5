Imports CefSharp
Imports CefSharp.WinForms
Imports SMUI.GUI.Class1

Public Class ChromiumBrowser
    Private Sub ChromiumBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        获得的HTML = ""

    End Sub

    Private Sub ChromiumBrowser_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ST1.用于内置谷歌浏览器_当前正在更新模组 = True Then
            Me.Timer1.Enabled = True
            Me.Text = "Chromium Embedded Framework - " & 获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.1")
        Else
            Me.Text = "Chromium Embedded Framework"
        End If
    End Sub

    Public 获得的HTML As String

    Private Sub ChromiumWebBrowser1_LoadingStateChanged(sender As Object, e As CefSharp.LoadingStateChangedEventArgs) Handles ChromiumWebBrowser1.LoadingStateChanged
        If e.IsLoading = False Then
            Dim task02 = e.Browser.GetSourceAsync()
            task02.ContinueWith(
                Function(t)
                    If Not t.IsFaulted Then
                        获得的HTML = t.Result
                    End If
                    Return Nothing
                End Function)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ST1.用于内置谷歌浏览器_当前正在更新模组 = False Then Exit Sub
        If 获得的HTML = "" Then Exit Sub

        If InStr(获得的HTML, "data-download-url=") < 1 Then
            ST1.用于内置谷歌浏览器_当前正在更新模组 = False
            MsgBox(获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.3"), MsgBoxStyle.Critical)
            Me.Text = "Chromium Embedded Framework - " & 获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.3")
            Form直接联网更新单个项.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S1")
            Exit Sub
        End If
        Dim 开头字符串 As String = "data-download-url=" & """"
        Dim 开头字符串之后开始的位置 As Integer = InStr(获得的HTML, 开头字符串) + Len(开头字符串)

        Dim key开头之后的位置 As Integer = InStr(开头字符串之后开始的位置, 获得的HTML, "?key=") + Len("?key=")
        Dim key结束的位置 As Integer = InStr(key开头之后的位置, 获得的HTML, "&")
        Dim key As String = Mid(获得的HTML, key开头之后的位置, key结束的位置 - key开头之后的位置)
        添加调试文本("key=" & key, Color1.蓝色)
        ST1.用于内置谷歌浏览器_获取到的key = key
        Dim expires开头之后的位置 As Integer = InStr(开头字符串之后开始的位置, 获得的HTML, "expires=") + Len("expires=")
        Dim expires结束的位置 As Integer = InStr(expires开头之后的位置, 获得的HTML, "&")
        Dim expires As String = Mid(获得的HTML, expires开头之后的位置, expires结束的位置 - expires开头之后的位置)
        添加调试文本("expires=" & expires, Color1.蓝色)
        ST1.用于内置谷歌浏览器_获取到的expires = expires
        If Form直接联网更新单个项.DarkButton1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/A6") Then
            Form直接联网更新单个项.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S3")
        End If
        Form直接联网更新单个项.BackgroundWorker2.RunWorkerAsync()
        ST1.用于内置谷歌浏览器_当前正在更新模组 = False
        Me.Timer1.Enabled = False
        Me.Close()
        Exit Sub



    End Sub


End Class