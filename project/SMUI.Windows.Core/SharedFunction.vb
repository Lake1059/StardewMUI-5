Public Class SharedFunction
    Private Shared Function GetStringFromHash(hash As Byte()) As String
        Dim result As New Text.StringBuilder()
        For i As Integer = 0 To hash.Length - 1
            result.Append(hash(i).ToString("X2"))
        Next
        Return result.ToString()
    End Function

    Public Shared Function FileEncryptSHA256(ByVal file_name As String)
        Dim sha256 As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
        Dim hashValue() As Byte
        Dim fStream As IO.FileStream = System.IO.File.OpenRead(file_name)
        fStream.Position = 0
        hashValue = sha256.ComputeHash(fStream)
        Dim hash = GetStringFromHash(hashValue)
        fStream.Close()
        Return hash
    End Function

    Public Shared Function GetModUpdateID(ByVal OneLineText As String, ByVal FindID As String) As String
        Dim x0, x1, x2, x3
        If InStr(OneLineText, "@") > 0 Then
            x0 = Mid(OneLineText, 1, InStr(OneLineText, "@") - 1)
        Else
            x0 = OneLineText
        End If
        x1 = InStr(x0.ToLower, FindID.ToLower) + Len(FindID.ToLower)
        x2 = Mid(x0.ToLower, x1)
        x3 = Replace(x2, " ", "")
        x3 = Replace(x3, ":", "")
        Return x3
    End Function

    Public Shared Function GetModUpdatePlatformAddress(ByVal OneLineText As String, ByVal PlatformName As String) As String
        Dim a As String = OneLineText.ToLower
        Dim b As Integer = InStr(a, PlatformName.ToLower)
        If b > 0 Then
            Dim c As Integer = InStr(b + Len(PlatformName), a, ":")
            If c <= 0 Then Return "" : Exit Function
            Return Mid(OneLineText, c + 1)
        Else
            Return ""
        End If
    End Function

    Public Shared Function CompareVersion(Version1 As String, Version2 As String) As Long
        Dim i As Long, iUbound As Long, iCha As Long
        Dim arrVer1() As String, arrVer2() As String
        arrVer1 = Split(Version1, ".")
        arrVer2 = Split(Version2, ".")
        If (UBound(arrVer1) > UBound(arrVer2)) Then
            iUbound = UBound(arrVer2)
        Else
            iUbound = UBound(arrVer1)
        End If
        For i = LBound(arrVer1) To iUbound
            If InStr(arrVer1(i), "beta") > 0 And InStr(arrVer2(i), "beta") <= 0 Then
                Return -1
                Exit Function
            End If
            If InStr(arrVer1(i), "beta") <= 0 And InStr(arrVer2(i), "beta") > 0 Then
                Return 1
                Exit Function
            End If
            iCha = Val(arrVer1(i)) - Val(arrVer2(i))
            If iCha > 0 Then
                Return 1
                Exit Function
            ElseIf iCha < 0 Then
                Return -1
                Exit Function
            End If
        Next
        Return UBound(arrVer1) - UBound(arrVer2)
        Exit Function
    End Function

    ''' <summary>
    ''' 只返回此目录下的文件夹名称
    ''' </summary>
    ''' <param name="Path"></param>
    ''' <returns></returns>
    Public Shared Function SearchFolderWithoutSub(Path As String) As String()
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(Path)
        Dim a As String() = {}
        For Each mDir In mDirInfo.GetDirectories
            ReDim Preserve a(a.Length)
            a(a.Length - 1) = mDir.Name
        Next
        Return a
    End Function


End Class
