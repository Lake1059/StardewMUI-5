Imports System.Xml
Imports SMUI.GUI.Class1

Module Module1

    Public 导入导出密码本 As String() = {}

    Public Sub 添加导入导出密码到密码本中(key As String)
        For i = 0 To 导入导出密码本.Count - 1
            If 导入导出密码本(i) = key Then Exit Sub
        Next
        ReDim Preserve 导入导出密码本(导入导出密码本.Count)
        导入导出密码本(导入导出密码本.Count - 1) = key
    End Sub

    Public Sub 保存导入导出密码本()
        Dim a As String = ""
        For i = 0 To 导入导出密码本.Count - 1
            If a = "" Then
                a = 导入导出密码本(i)
            Else
                a &= "|crlf|" & 导入导出密码本(i)
            End If
        Next
        My.Computer.FileSystem.WriteAllText(Path1.应用程序用户数据路径 & "\Keys.dat", a, False)
    End Sub

    Public Sub 读取导入导出密码本()
        If My.Computer.FileSystem.FileExists(Path1.应用程序用户数据路径 & "\Keys.dat") = False Then Exit Sub
        导入导出密码本 = My.Computer.FileSystem.ReadAllText(Path1.应用程序用户数据路径 & "\Keys.dat").Split("|crlf|")
    End Sub


End Module
