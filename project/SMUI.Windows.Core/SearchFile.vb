Public Class SearchFile
    Public FileCollection As String()
    Public ErrorString As String

    Dim _DirectoryToScan As String
    Dim _ScanSubDirectories As Boolean
    Dim _ExtensionName As String

    Public Sub SearchFiles(DirectoryToScan As String, ScanSubDirectories As Boolean, Optional ExtensionName As String = "*.*")
        ErrorString = ""
        FileCollection = Array.Empty(Of String)()
        Try
            _DirectoryToScan = DirectoryToScan
            _ScanSubDirectories = ScanSubDirectories
            _ExtensionName = ExtensionName
            GetAllFiles(DirectoryToScan)
        Catch ex As Exception
            ErrorString = ex.Message
        End Try
    End Sub

    Public Sub SearchManifests(DirectoryToScan As String, Optional ScanSubDirectories As Boolean = True)
        ErrorString = ""
        FileCollection = Array.Empty(Of String)()
        Try
            _DirectoryToScan = DirectoryToScan
            _ScanSubDirectories = ScanSubDirectories
            GetAllManifestFiles(DirectoryToScan)
        Catch ex As Exception
            ErrorString = ex.Message
        End Try
    End Sub

    Private Sub GetAllFiles(strDirect As String)
        Dim mFileInfo As System.IO.FileInfo
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
        For Each mFileInfo In mDirInfo.GetFiles(_ExtensionName)
            Dim a As String = mFileInfo.FullName
            ReDim Preserve FileCollection(FileCollection.Length)
            FileCollection(FileCollection.Length - 1) = Mid(Replace(mFileInfo.FullName, _DirectoryToScan, ""), 2)
        Next
        If _ScanSubDirectories = True Then
            For Each mDir In mDirInfo.GetDirectories
                GetAllFiles(mDir.FullName)
            Next
        End If
    End Sub

    Private Sub GetAllManifestFiles(ByVal strDirect As String)
        Dim mFileInfo As System.IO.FileInfo
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
        For Each mFileInfo In mDirInfo.GetFiles("manifest.json")
            Dim a As String = mFileInfo.FullName
            ReDim Preserve FileCollection(FileCollection.Length)
            FileCollection(FileCollection.Length - 1) = Mid(Replace(mFileInfo.FullName, _DirectoryToScan, ""), 2)
            Exit Sub
        Next
        If _ScanSubDirectories = True Then
            For Each mDir In mDirInfo.GetDirectories
                GetAllManifestFiles(mDir.FullName)
            Next
        End If
    End Sub




End Class
