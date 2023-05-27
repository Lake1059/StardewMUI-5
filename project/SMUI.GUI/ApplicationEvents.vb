Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices
Imports SMUI.GUI.Class1

Namespace My

    ' 以下事件可用于 MyApplication: 
    ' Startup:应用程序启动时在创建启动窗体之前引发。
    ' Shutdown:在关闭所有应用程序窗体后引发。如果应用程序非正常终止，则不会引发此事件。
    ' UnhandledException:在应用程序遇到未经处理的异常时引发。
    ' StartupNextInstance:在启动单实例应用程序且应用程序已处于活动状态时引发。 
    ' NetworkAvailabilityChanged:在连接或断开网络连接时引发。
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            'If e.CommandLine.Count > 0 Then
            '    Dim a As String = "接收到的命令行"
            '    For i = 0 To e.CommandLine.Count - 1
            '        a &= vbNewLine & e.CommandLine(i)
            '    Next
            '    MsgBox(a)
            'End If

        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            'If e.CommandLine.Count > 0 Then
            '    Dim a As String = "接收到的命令行"
            '    For i = 0 To e.CommandLine.Count - 1
            '        a &= vbNewLine & e.CommandLine(i)
            '    Next
            '    MsgBox(a)
            'End If
        End Sub
    End Class
End Namespace
