Imports CefSharp
Imports CefSharp.WinForms
Imports SMUI.GUI.Class1

Public Class ChromiumBrowser
    Private Sub ChromiumBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        获得的HTML = ""
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.挂起任务继续操作ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M1")
            Me.NEXUS账户页ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M2")
            Me.刷新ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M3")
            Me.返回ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M4")
            Me.前进ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M5")
            Me.停止ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M6")
            Me.转到地址ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/M7")
            调整地址栏宽度()
            Me.重置直接更新项流程状态ToolStripMenuItem.Text = 获取动态多语言文本("data/ChromiumWindow/A1")
        End If

    End Sub

    Sub 调整地址栏宽度()
        Me.ToolStripTextBox1.Width = Me.DarkMenuStrip1.Width - Me.挂起任务继续操作ToolStripMenuItem.Width - Me.NEXUS账户页ToolStripMenuItem.Width - Me.刷新ToolStripMenuItem.Width - Me.返回ToolStripMenuItem.Width - Me.前进ToolStripMenuItem.Width - Me.停止ToolStripMenuItem.Width - Me.转到地址ToolStripMenuItem.Width - 10
    End Sub

    Private Sub ChromiumBrowser_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        调整地址栏宽度()
    End Sub

    Private Sub ChromiumBrowser_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ST1.用于内置谷歌浏览器_当前正在更新模组 = True Then
            Me.Text = "Chromium Embedded Framework - " & 获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.1")
        Else
            Me.Text = "Chromium Embedded Framework"
        End If
    End Sub

    Public 获得的HTML As String = ""

    Private Sub ChromiumWebBrowser1_LoadingStateChanged(sender As Object, e As CefSharp.LoadingStateChangedEventArgs) Handles ChromiumWebBrowser1.LoadingStateChanged
        更新地址栏(Me.ChromiumWebBrowser1.Address)
        If e.IsLoading = False And ST1.用于内置谷歌浏览器_当前正在更新模组 = True Then
            Dim task02 = e.Browser.GetSourceAsync()
            task02.ContinueWith(
                Function(t)
                    If Not t.IsFaulted Then
                        获得的HTML = t.Result
                        启动计算("")
                    End If
                    Return Nothing
                End Function)
        End If
    End Sub

    Private Delegate Sub str_Delegate(str As String)
    Private Sub 更新地址栏(str As String)

        If InvokeRequired Then
            Invoke(New str_Delegate(AddressOf 更新地址栏), str)
            Return
        End If
        Me.ToolStripTextBox1.Text = str
    End Sub

    Private Sub 启动计算(str As String)
        If InvokeRequired Then
            Invoke(New str_Delegate(AddressOf 启动计算), str)
            Return
        End If
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ST1.用于内置谷歌浏览器_当前正在更新模组 = False Then
            Me.Timer1.Enabled = False : Exit Sub
        End If
        If 获得的HTML = "" Then Exit Sub
        If InStr(获得的HTML, "data-download-url=") < 1 Then
            ST1.用于内置谷歌浏览器_当前正在更新模组 = False
            Me.Text = "Chromium Embedded Framework - " & 获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.3")
            MsgBox(获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.3"), MsgBoxStyle.Critical)
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

    Private Sub NEXUS账户页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NEXUS账户页ToolStripMenuItem.Click
        Me.ChromiumWebBrowser1.LoadUrl("https://users.nexusmods.com/auth/sign_in")
        获得的HTML = ""
    End Sub

    Private Sub 刷新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 刷新ToolStripMenuItem.Click
        Me.ChromiumWebBrowser1.Reload()
        获得的HTML = ""
        If ST1.用于内置谷歌浏览器_当前正在更新模组 = True Then
            Me.Text = "Chromium Embedded Framework - " & 获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.1")
        Else
            Me.Text = "Chromium Embedded Framework"
        End If
    End Sub

    Private Sub 返回ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 返回ToolStripMenuItem.Click
        Me.ChromiumWebBrowser1.Back
    End Sub

    Private Sub 前进ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 前进ToolStripMenuItem.Click
        Me.ChromiumWebBrowser1.Forward
    End Sub

    Private Sub 停止ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 停止ToolStripMenuItem.Click
        Me.ChromiumWebBrowser1.Stop
    End Sub

    Private Sub 转到地址ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 转到地址ToolStripMenuItem.Click
        Me.ChromiumWebBrowser1.LoadUrl(Me.ToolStripTextBox1.Text)
    End Sub

    Private Sub 重置直接更新项流程状态ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 重置直接更新项流程状态ToolStripMenuItem.Click
        If Form直接联网更新单个项.Visible = True Then
            获得的HTML = ""
            ST1.用于内置谷歌浏览器_当前正在更新模组 = True
            Me.Text = "Chromium Embedded Framework - " & 获取动态多语言文本("data/DirectOnlineUpdateWindow/Chromium.4")
        End If

    End Sub


End Class