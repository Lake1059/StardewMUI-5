Imports System.IO

Public Class Form存储管理

    Public Shared Function GetDirectoryLength(dirPath As String) As Long
        If Not Directory.Exists(dirPath) Then
            Return 0
        End If
        Dim len As Long = 0
        Dim di As New DirectoryInfo(dirPath)
        For Each fi As FileInfo In di.GetFiles()
            len += fi.Length
        Next
        Dim dis As DirectoryInfo() = di.GetDirectories()
        If dis.Length > 0 Then
            For i As Integer = 0 To dis.Length - 1
                len += GetDirectoryLength(dis(i).FullName)
            Next
        End If
        Return len
    End Function

    Public Shared Function 转换字节数显示(字节数 As Long) As String
        Dim a As Long = 字节数 / 1024
        If a < 1024 Then
            Return a & "KB"
        Else
            Return Format(a / 1024, "0.0") & "MB"
        End If
    End Function


    Private Sub Form存储管理_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form存储管理_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
End Class