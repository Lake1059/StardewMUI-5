Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI.Windows.Core.SharedFunction
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports Newtonsoft

Public Class ItemInfoReader

    Public InstallStatus As Objects.InstallStatus = Objects.InstallStatus.Unknow

    Public Name As String() = Array.Empty(Of String)()
    Public Author As String() = Array.Empty(Of String)()
    Public Version As String() = Array.Empty(Of String)()

    Public InstalledVersion As String() = Array.Empty(Of String)()
    Public MinimumApiVersion As String() = Array.Empty(Of String)()
    Public Description As String() = Array.Empty(Of String)()
    Public UniqueID As String() = Array.Empty(Of String)()
    Public NexusID As String() = Array.Empty(Of String)()
    Public ChuckleFishID As String() = Array.Empty(Of String)()
    Public GitHub As String() = Array.Empty(Of String)()
    Public ModDrop As String() = Array.Empty(Of String)()

    Public ContentPackFor As String() = Array.Empty(Of String)()
    Public ContentPackForMinimumVersion As String() = Array.Empty(Of String)()
    Public Dependencies As String() = Array.Empty(Of String)()
    Public DependenciesIsRequired As Boolean() = Array.Empty(Of Boolean)()
    Public DependenciesMinimumVersion As String() = Array.Empty(Of String)()

    Public NotInstalledFolders As String() = Array.Empty(Of String)()
    Public NotCopiedFolders As String() = Array.Empty(Of String)()
    Public NotReplacedFiles As String() = Array.Empty(Of String)()
    Public NotCopiedFiles As String() = Array.Empty(Of String)()

    Public ErrorString As String = ""

    Public Sub Reset()
        InstallStatus = Objects.InstallStatus.Unknow
        Name = Array.Empty(Of String)()
        Author = Array.Empty(Of String)()
        Version = Array.Empty(Of String)()
        InstalledVersion = Array.Empty(Of String)()
        MinimumApiVersion = Array.Empty(Of String)()
        Description = Array.Empty(Of String)()
        UniqueID = Array.Empty(Of String)()
        NexusID = Array.Empty(Of String)()
        ChuckleFishID = Array.Empty(Of String)()
        GitHub = Array.Empty(Of String)()
        ModDrop = Array.Empty(Of String)()
        ContentPackFor = Array.Empty(Of String)()
        ContentPackForMinimumVersion = Array.Empty(Of String)()
        Dependencies = Array.Empty(Of String)()
        DependenciesIsRequired = Array.Empty(Of Boolean)()
        DependenciesMinimumVersion = Array.Empty(Of String)()
        NotInstalledFolders = Array.Empty(Of String)()
        NotCopiedFolders = Array.Empty(Of String)()
        NotReplacedFiles = Array.Empty(Of String)()
        NotCopiedFiles = Array.Empty(Of String)()
        ErrorString = ""
    End Sub

    Public Sub ReadItemInfo(ItemPath As String, CalculateType As Objects.ItemCalculateType, Optional GamePath As String = "")
        ErrorString = ""
        If DirectoryExists(ItemPath) = False Then
            ErrorString = "[SMUI CORE ERROR] Item path not exist: " & ItemPath : Exit Sub
        End If
        If FileExists(CombinePath(ItemPath, "Code")) = False Then
            ErrorString = "[SMUI CORE ERROR] Item not deployed. (No Code file)" : Exit Sub
        End If
        If CalculateType.InstallStatus = True Or CalculateType.InstalledVersion = True Or CalculateType.All = True Then
            If GamePath = "" Then
                ErrorString = "[SMUI CORE ERROR] This operation needs to set the game path." : Exit Sub
            End If
            If DirectoryExists(GamePath) = False Then
                ErrorString = "[SMUI CORE ERROR] Game path not exist." : Exit Sub
            End If
        End If

        If CalculateType.All = True Then
            CalculateType.InstallStatus = True
            CalculateType.Name = True
            CalculateType.Author = True
            CalculateType.Version = True
            CalculateType.InstalledVersion = True
            CalculateType.MinimumApiVersion = True
            CalculateType.Description = True
            CalculateType.UniqueID = True
            CalculateType.UpdateKeys = True
            CalculateType.ContentPackFor = True
            CalculateType.Dependencies = True
        End If

        Try
            Dim line As String() = ReadAllText(CombinePath(ItemPath, "Code")).Split(vbCrLf)
            '解决 .NET Framework 的祖传bug，拆分字符串除了第一行之外其他的行的第一个字符会莫名其妙多出来换行符
            '.NET 5 及以上没有这个bug，如果是用 .NET 5 及以上框架编译记得把这段 For 删掉
            For i = 0 To line.Count - 1
                If i = 0 Then
                    line(i) = line(i)
                Else
                    line(i) = Mid(line(i), 2)
                End If
            Next

            For i = 0 To line.Length - 1
                If Replace(line(i), " ", "") Is Nothing Then Continue For
                Select Case Replace(line(i), " ", "").ToUpper
                    Case "CDCD", "CDCP"
                        If i = line.Length - 1 Then
                            Continue For
                        End If
                        Dim x As String = line(i + 1)

                        i += 1

                        If CalculateType.InstallStatus = True Then
                            If DirectoryExists(CombinePath(CombinePath(GamePath, "Mods"), x)) = True Then
                                Select Case InstallStatus
                                    Case Objects.InstallStatus.Incomplete
                                        GoTo PR1
                                    Case Objects.InstallStatus.UnInstalled
                                        InstallStatus = Objects.InstallStatus.Incomplete
                                    Case Else
                                        InstallStatus = Objects.InstallStatus.Installed
                                End Select
                            Else
                                Select Case InstallStatus
                                    Case Objects.InstallStatus.Incomplete
                                        Exit Select
                                    Case Objects.InstallStatus.Installed
                                        InstallStatus = Objects.InstallStatus.Incomplete
                                    Case Else
                                        InstallStatus = Objects.InstallStatus.UnInstalled
                                End Select
                                ReDim Preserve NotInstalledFolders(NotInstalledFolders.Length)
                                NotInstalledFolders(NotInstalledFolders.Length - 1) = x
                            End If
                        End If
PR1:
                        Dim ManifestFile As New SearchFile
                        ManifestFile.SearchManifests(CombinePath(ItemPath, x))
                        If ManifestFile.ErrorString <> "" Then
                            ErrorString = ManifestFile.ErrorString : Exit Sub
                        End If
                        For ManifestFileList = 0 To ManifestFile.FileCollection.Length - 1
                            Dim a As String = ReadAllText(CombinePath(CombinePath(ItemPath, x), ManifestFile.FileCollection(ManifestFileList)))
                            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)

                            If CalculateType.Name = True Then
                                If JsonData.item("Name") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Name").ToString
                                    For y = 0 To Name.Length - 1
                                        If Replace(Name(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineName
                                    Next
                                    ReDim Preserve Name(Name.Length)
                                    Name(Name.Length - 1) = str1
                                Else
                                    Continue For
                                End If
                            End If
LineName:
                            If CalculateType.Author = True Then
                                If JsonData.item("Author") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Author").ToString
                                    For y = 0 To Author.Length - 1
                                        If Replace(Author(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineAuthor
                                    Next
                                    ReDim Preserve Author(Author.Length)
                                    Author(Author.Length - 1) = str1
                                End If
                            End If
LineAuthor:
                            If CalculateType.Version = True Then
                                If JsonData.item("Version") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Version").ToString
                                    If str1 = "" Then GoTo LineVersion
                                    For y = 0 To Version.Length - 1
                                        If Replace(Version(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineVersion
                                    Next
                                    ReDim Preserve Version(Version.Length)
                                    Version(Version.Length - 1) = str1
                                End If
                            End If
LineVersion:
                            If CalculateType.InstalledVersion = True Then
                                Dim p1 As String = CombinePath(GamePath, "Mods")
                                Dim p2 As String = CombinePath(p1, x)
                                Dim p3 As String = CombinePath(p2, ManifestFile.FileCollection(ManifestFileList))
                                If FileExists(p3) = True Then
                                    Dim b As String = ReadAllText(p3)
                                    Dim JsonData2 As Object = CType(JsonConvert.DeserializeObject(b), JObject)
                                    Dim str1 As String = JsonData2.item("Version").ToString
                                    If str1 = "" Then GoTo LineInstalledVersion
                                    For y = 0 To InstalledVersion.Length - 1
                                        If Replace(InstalledVersion(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineInstalledVersion
                                    Next
                                    ReDim Preserve InstalledVersion(InstalledVersion.Length)
                                    InstalledVersion(InstalledVersion.Length - 1) = str1
                                End If
                            End If
LineInstalledVersion:
                            If CalculateType.MinimumApiVersion = True Then
                                If JsonData.item("MinimumApiVersion") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("MinimumApiVersion").ToString
                                    For y = 0 To MinimumApiVersion.Length - 1
                                        If Replace(MinimumApiVersion(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineMinimumApiVersion
                                    Next
                                    ReDim Preserve MinimumApiVersion(MinimumApiVersion.Length)
                                    MinimumApiVersion(MinimumApiVersion.Length - 1) = str1
                                End If
                            End If
LineMinimumApiVersion:
                            If CalculateType.Description = True Then
                                If JsonData.item("Description") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("Description").ToString
                                    '一般用不着，除非哪个家伙闲得蛋疼
                                    'For y = 0 To Description.Length - 1
                                    '    If Replace(Description(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineDescription
                                    'Next
                                    ReDim Preserve Description(Description.Length)
                                    Description(Description.Length - 1) = str1
                                End If
                            End If
LineDescription:
                            If CalculateType.UniqueID = True Then
                                If JsonData.item("UniqueID") IsNot Nothing Then
                                    Dim str1 As String = JsonData.item("UniqueID").ToString
                                    For y = 0 To UniqueID.Length - 1
                                        If Replace(UniqueID(y), " ", "").ToLower = Replace(str1, " ", "").ToLower Then GoTo LineUniqueID
                                    Next
                                    ReDim Preserve UniqueID(UniqueID.Length)
                                    UniqueID(UniqueID.Length - 1) = str1
                                End If
                            End If
LineUniqueID:
                            If CalculateType.UpdateKeys = True Then
                                If JsonData.item("UpdateKeys") Is Nothing Then GoTo LineUpdateKeys
                                For k = 0 To JsonData.item("UpdateKeys").Count - 1
                                    If InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus") > 0 Then
                                        Dim str = GetModUpdateID(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "nexus")
                                        If IsNumeric(str) Then
                                            If str < 0 Then GoTo UpdateKeysNext
                                            For y = 0 To NexusID.Length - 1
                                                If Replace(NexusID(y), " ", "").ToLower = Replace(str, " ", "").ToLower Then GoTo UpdateKeysNext
                                            Next
                                            ReDim Preserve NexusID(NexusID.Length)
                                            NexusID(NexusID.Length - 1) = str
                                        End If
                                    ElseIf InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "moddrop") > 0 Then
                                        Dim str = GetModUpdatePlatformAddress(JsonData.item("UpdateKeys").item(k).ToString, "moddrop")
                                        If str <> "" Then
                                            ReDim Preserve ModDrop(ModDrop.Length)
                                            ModDrop(ModDrop.Length - 1) = str
                                        End If
                                    ElseIf InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "github") > 0 Then
                                        Dim str = GetModUpdatePlatformAddress(JsonData.item("UpdateKeys").item(k).ToString, "github")
                                        If str <> "" Then
                                            ReDim Preserve GitHub(GitHub.Length)
                                            GitHub(GitHub.Length - 1) = str
                                        End If
                                    ElseIf InStr(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "chucklefish") > 0 Then
                                        Dim str = GetModUpdateID(JsonData.item("UpdateKeys").item(k).ToString.ToLower, "chucklefish")
                                        If IsNumeric(str) Then
                                            ReDim Preserve ChuckleFishID(ChuckleFishID.Length)
                                            ChuckleFishID(ChuckleFishID.Length - 1) = str
                                        End If
                                    End If
UpdateKeysNext:
                                Next
                            End If
LineUpdateKeys:
                            If CalculateType.ContentPackFor = True Then
                                If JsonData.item("ContentPackFor") Is Nothing Then GoTo LineContentPackFor
                                If JsonData.item("ContentPackFor").item("UniqueID") Is Nothing Then GoTo LineContentPackFor
                                Dim ContentPackString As String = JsonData.item("ContentPackFor").item("UniqueID").ToString
                                For i3 = 0 To ContentPackFor.Length - 1
                                    If ContentPackFor(i3).ToLower = ContentPackString.ToLower Then GoTo LineContentPackFor
                                Next
                                ReDim Preserve ContentPackFor(ContentPackFor.Length)
                                ContentPackFor(ContentPackFor.Length - 1) = ContentPackString
                                If JsonData.item("ContentPackFor").item("MinimumVersion") Is Nothing Then
                                    ReDim Preserve ContentPackForMinimumVersion(ContentPackForMinimumVersion.Length)
                                    ContentPackForMinimumVersion(ContentPackForMinimumVersion.Length - 1) = ""
                                Else
                                    ReDim Preserve ContentPackForMinimumVersion(ContentPackForMinimumVersion.Length)
                                    ContentPackForMinimumVersion(ContentPackForMinimumVersion.Length - 1) = JsonData.item("ContentPackFor").item("MinimumVersion").ToString
                                End If
                            End If
LineContentPackFor:
                            If CalculateType.Dependencies = True Then
                                If JsonData.item("Dependencies") Is Nothing Then GoTo LineDependencies
                                For int2 = 0 To JsonData.item("Dependencies").Count - 1
                                    If JsonData.item("Dependencies").item(int2)("UniqueID") Is Nothing Then Exit For
                                    Dim DependenciesString As String = JsonData.item("Dependencies").item(int2)("UniqueID").ToString
                                    For i3 = 0 To Dependencies.Length - 1
                                        If Dependencies(i3).ToLower = DependenciesString.ToLower Then GoTo CN1
                                    Next
                                    ReDim Preserve Dependencies(Dependencies.Length)
                                    Dependencies(Dependencies.Length - 1) = DependenciesString
                                    If JsonData.item("Dependencies").item(int2)("IsRequired") IsNot Nothing Then
                                        Select Case Replace(JsonData.item("Dependencies").item(int2)("IsRequired").ToString.ToLower, " ", "")
                                            Case "true"
                                                ReDim Preserve DependenciesIsRequired(DependenciesIsRequired.Length)
                                                DependenciesIsRequired(DependenciesIsRequired.Length - 1) = True
                                            Case "false"
                                                ReDim Preserve DependenciesIsRequired(DependenciesIsRequired.Length)
                                                DependenciesIsRequired(DependenciesIsRequired.Length - 1) = False
                                            Case Else
                                                ReDim Preserve DependenciesIsRequired(DependenciesIsRequired.Length)
                                                DependenciesIsRequired(DependenciesIsRequired.Length - 1) = True
                                        End Select
                                    Else
                                        ReDim Preserve DependenciesIsRequired(DependenciesIsRequired.Length)
                                        DependenciesIsRequired(DependenciesIsRequired.Length - 1) = True
                                    End If
CN1:
                                Next
                            End If
LineDependencies:
                        Next
LineEnd:
                    Case "CDGCD"
                        If CalculateType.InstallStatus = True Then
                            If i = line.Length - 1 Or i = line.Length - 2 Then Continue For
                            Dim x1 As String = line(i + 1)
                            Dim x2 As String = line(i + 2)
                            i += 2
                            Select Case InstallStatus
                                Case 1, 2, 3
                                Case -1
                                    If DirectoryExists(CombinePath(GamePath, x2)) = True Then
                                        InstallStatus = Objects.InstallStatus.FolderCopied
                                    Else
                                        InstallStatus = Objects.InstallStatus.FolderNotCopied
                                        ReDim Preserve NotCopiedFolders(NotCopiedFolders.Length)
                                        NotCopiedFolders(NotCopiedFolders.Length - 1) = x2
                                    End If
                            End Select
                        End If

                    Case "CDMAD"
                        If CalculateType.InstallStatus = True Then
                            Select Case InstallStatus
                                Case 1, 2, 3
                                Case -1
                                    InstallStatus = Objects.InstallStatus.AdditionalContent
                            End Select
                        End If

                    Case "CDGRF"
                        If CalculateType.InstallStatus = True Then
                            If i = line.Length - 1 Or i = line.Length - 2 Then Continue For
                            Dim x1 As String = line(i + 1)
                            Dim x2 As String = line(i + 2)
                            i += 2
                            If FileExists(CombinePath(ItemPath, x1)) = False Then
                                InstallStatus = Objects.InstallStatus.FileNotReplaced
                                Continue For
                            End If
                            If FileExists(CombinePath(GamePath, x2)) = False Then
                                InstallStatus = Objects.InstallStatus.FileNotReplaced
                                Continue For
                            End If
                            Dim a1 As String = FileEncryptSHA256(CombinePath(ItemPath, x1))
                            Dim a2 As String = FileEncryptSHA256(CombinePath(GamePath, x2))
                            Select Case InstallStatus
                                Case -1
                                    If a1.ToLower = a2.ToLower Then
                                        InstallStatus = Objects.InstallStatus.FileReplaced
                                    Else
                                        InstallStatus = Objects.InstallStatus.FileNotReplaced
                                        ReDim Preserve NotReplacedFiles(NotReplacedFiles.Length)
                                        NotReplacedFiles(NotReplacedFiles.Length - 1) = x2
                                    End If
                            End Select
                        End If

                    Case "CDGCF"
                        If CalculateType.InstallStatus = True Then
                            If i = line.Length - 1 Or i = line.Length - 2 Then Continue For
                            Dim x1 As String = line(i + 1)
                            Dim x2 As String = line(i + 2)
                            i += 2
                            Select Case InstallStatus
                                Case 1, 2, 3
                                Case -1
                                    If FileExists(CombinePath(GamePath, x2)) = True Then
                                        InstallStatus = Objects.InstallStatus.FileCopied
                                    Else
                                        InstallStatus = Objects.InstallStatus.FileNotCopied
                                        ReDim Preserve NotCopiedFiles(NotCopiedFiles.Length)
                                        NotCopiedFiles(NotCopiedFiles.Length - 1) = x2
                                    End If
                            End Select
                        End If

                    Case "CDF"
                        If CalculateType.InstallStatus = True Then
                            If i = line.Length - 1 Or i = line.Length - 2 Then Continue For
                            Dim x1 As String = line(i + 1)
                            Dim x2 As String = line(i + 2)
                            i += 2
                            If InstallStatus = -1 Then
                                InstallStatus = Objects.InstallStatus.NeedCopyFile
                            End If
                        End If

                    Case "CDVD", "CDCC"
                        Select Case InstallStatus
                            Case 1, 2, 3
                            Case -1
                                InstallStatus = Objects.InstallStatus.CoverContent
                        End Select

                End Select
            Next

            If CalculateType.Dependencies = True Then
                Dim _Dependencies As String() = Array.Empty(Of String)()
                Dim _DependenciesIsRequired As Boolean() = Array.Empty(Of Boolean)()


                For i = 0 To Dependencies.Length - 1
                    For i3 = 0 To UniqueID.Length - 1
                        If Dependencies(i).ToLower = UniqueID(i3).ToLower Then
                            GoTo A1
                        End If
                    Next
                    ReDim Preserve _Dependencies(_Dependencies.Length)
                    _Dependencies(_Dependencies.Length - 1) = Dependencies(i)
                    ReDim Preserve _DependenciesIsRequired(_DependenciesIsRequired.Length)
                    _DependenciesIsRequired(_DependenciesIsRequired.Length - 1) = DependenciesIsRequired(i)
A1:
                Next
                Dependencies = _Dependencies
                DependenciesIsRequired = _DependenciesIsRequired
            End If

            If CalculateType.ContentPackFor = True Then
                Dim _ContentPackFor As String() = Array.Empty(Of String)()
                For i = 0 To ContentPackFor.Length - 1
                    For i3 = 0 To UniqueID.Length - 1
                        If ContentPackFor(i).ToLower = UniqueID(i3).ToLower Then
                            GoTo A2
                        End If
                    Next
                    ReDim Preserve _ContentPackFor(_ContentPackFor.Length)
                    _ContentPackFor(_ContentPackFor.Length - 1) = ContentPackFor(i)
A2:
                Next
                ContentPackFor = _ContentPackFor
            End If

            ErrorString = ""
        Catch ex As Exception
            ErrorString = ex.Message
        End Try
    End Sub

    Public Shared Function ReadSemanticVersion(ByVal JsonTextInVersion As String, Optional ByRef ErrorString As String = "") As String
        Try
            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(JsonTextInVersion), JObject)
            If JsonData.item("MajorVersion") IsNot Nothing Then
                Dim MajorVersion As String = JsonData.item("MajorVersion").ToString
                Dim MinorVersion As String = ""
                Dim PatchVersion As String = ""
                Dim Build As String = ""
                If JsonData.item("MinorVersion") IsNot Nothing Then
                    MinorVersion = JsonData.item("MinorVersion").ToString
                End If
                If JsonData.item("PatchVersion") IsNot Nothing Then
                    PatchVersion = JsonData.item("PatchVersion").ToString
                End If
                If JsonData.item("Build") IsNot Nothing Then
                    Build = JsonData.item("Build").ToString
                End If
                Dim str2 As String = MajorVersion
                If MinorVersion <> "" Then
                    str2 &= "." & MinorVersion
                Else
                    Return str2 : Exit Function
                End If
                If PatchVersion <> "" Then
                    str2 &= "." & PatchVersion
                Else
                    Return str2 : Exit Function
                End If
                If Build <> "" Then
                    str2 &= "." & Build
                End If
                Return str2
            Else
                Return ""
            End If
        Catch ex As Exception
            ErrorString = ex.Message
            Return ""
        End Try
    End Function

End Class
