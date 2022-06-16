Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class WebBrowser_Window

    <DllImport("KERNEL32.DLL", EntryPoint:="SetProcessWorkingSetSize", SetLastError:=True, CallingConvention:=CallingConvention.StdCall)>
    Friend Shared Function SetProcessWorkingSetSize(pProcess As IntPtr, dwMinimumWorkingSetSize As Integer, dwMaximumWorkingSetSize As Integer) As Boolean
    End Function

    <DllImport("KERNEL32.DLL", EntryPoint:="GetCurrentProcess", SetLastError:=True, CallingConvention:=CallingConvention.StdCall)>
    Friend Shared Function GetCurrentProcess() As IntPtr
    End Function

    Private Sub WebBrowser_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub WebBrowser1_NewWindow(sender As Object, e As CancelEventArgs) Handles WebBrowser1.NewWindow
        e.Cancel = True
    End Sub

    Private Sub WebBrowser_Window_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub WebBrowser_Window_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim pHandle As IntPtr = GetCurrentProcess()
        SetProcessWorkingSetSize(pHandle, -1, -1)
        GC.Collect(1, GCCollectionMode.Forced, False, False)
        GC.Collect(1, GCCollectionMode.Forced, False, True)
    End Sub

    Private Sub WebBrowser_Window_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.WebBrowser1.Navigate("about:blank")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

        If ST1.用于内置IE浏览器_当前正在更新模组 = True Then
            Dim HTMLData As String = Me.WebBrowser1.Document.Body.InnerHtml
            If InStr(HTMLData, "data-download-url=") < 1 Then
                ST1.用于内置IE浏览器_当前正在更新模组 = False
                MsgBox(获取动态多语言文本("data/DirectOnlineUpdateWindow/IE1"), MsgBoxStyle.Critical)
                Form直接联网更新单个项.Label1.Text = 获取动态多语言文本("data/DirectOnlineUpdateWindow/S1")
                Exit Sub
            End If
            Dim 开头字符串 As String = "data-download-url=" & """"
            Dim 开头字符串之后开始的位置 As Integer = InStr(HTMLData, 开头字符串) + Len(开头字符串)

            Dim key开头之后的位置 As Integer = InStr(开头字符串之后开始的位置, HTMLData, "?key=") + Len("?key=")
            Dim key结束的位置 As Integer = InStr(key开头之后的位置, HTMLData, "&")
            Dim key As String = Mid(HTMLData, key开头之后的位置, key结束的位置 - key开头之后的位置)
            添加调试文本("key=" & key, Color1.蓝色)
            ST1.用于内置IE浏览器_获取到的key = key
            Dim expires开头之后的位置 As Integer = InStr(开头字符串之后开始的位置, HTMLData, "expires=") + Len("expires=")
            Dim expires结束的位置 As Integer = InStr(expires开头之后的位置, HTMLData, "&")
            Dim expires As String = Mid(HTMLData, expires开头之后的位置, expires结束的位置 - expires开头之后的位置)
            添加调试文本("expires=" & expires, Color1.蓝色)
            ST1.用于内置IE浏览器_获取到的expires = expires
            Form直接联网更新单个项.BackgroundWorker2.RunWorkerAsync()
            ST1.用于内置IE浏览器_当前正在更新模组 = False
            Me.Close()
            Exit Sub
        End If

        On Error Resume Next

        '将所有的链接的目标，指向本窗体
        For Each archor As HtmlElement In Me.WebBrowser1.Document.Links
            archor.SetAttribute("target", "_self")
        Next

        '将所有的FORM的提交目标，指向本窗体
        For Each form As HtmlElement In Me.WebBrowser1.Document.Forms
            form.SetAttribute("target", "_self")
        Next
    End Sub
End Class