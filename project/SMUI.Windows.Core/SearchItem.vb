Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class SearchItem

    Public Property ST_NotCaseUpperAndLowerLetters As Boolean = False
    Public Property ST_NotCaseCHS_ENG_Symbol As Boolean = False
    Public Property ST_SingleCharacterFuzzySearch As Boolean = False

    ''' <summary>
    ''' Item full path!
    ''' </summary> 
    Public Results As String() = {}

    Public Enum SearchType
        ItemName = 1
        NameKey = 2
        AuthorKey = 3
        UniqueID = 4
        ContentPakForAndDependencies = 5
        IncludedFolders = 6
        NexusID = 7
    End Enum

    Public Function StartSearch(ByVal FolderOneLevelAboveCategoryLevel As String, ByVal SearchWhat As String, ByVal yourSearchType As SearchType) As String
        Try
            Dim mDir As IO.DirectoryInfo
            Dim mDirInfo As New IO.DirectoryInfo(FolderOneLevelAboveCategoryLevel)
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As IO.DirectoryInfo
                Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories

                    Select Case yourSearchType
                        Case SearchType.ItemName
                            If DetermineWhetherToAddToOutput(mDir2.Name, SearchWhat) = True Then
                                ReDim Preserve Results(Results.Count)
                                Results(Results.Count - 1) = mDir2.FullName
                            End If
                        Case SearchType.NameKey
                            Dim ManifestFile As New SearchFile
                            ManifestFile.SearchManifests(mDir2.FullName)
                            For i = 0 To ManifestFile.FileCollection.Count - 1
                                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                                If JsonData.item("Name") IsNot Nothing Then
                                    If DetermineWhetherToAddToOutput(JsonData.item("Name").ToString, SearchWhat) = True Then
                                        ReDim Preserve Results(Results.Count)
                                        Results(Results.Count - 1) = mDir2.FullName
                                        Exit For
                                    End If
                                End If
                            Next

                        Case SearchType.AuthorKey
                            Dim ManifestFile As New SearchFile
                            ManifestFile.SearchManifests(mDir2.FullName)
                            For i = 0 To ManifestFile.FileCollection.Count - 1
                                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                                If JsonData.item("Author") IsNot Nothing Then
                                    If DetermineWhetherToAddToOutput(JsonData.item("Author").ToString, SearchWhat) = True Then
                                        ReDim Preserve Results(Results.Count)
                                        Results(Results.Count - 1) = mDir2.FullName
                                        Exit For
                                    End If
                                End If
                            Next

                        Case SearchType.UniqueID
                            Dim ManifestFile As New SearchFile
                            ManifestFile.SearchManifests(mDir2.FullName)
                            For i = 0 To ManifestFile.FileCollection.Count - 1
                                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                                If JsonData.item("UniqueID") IsNot Nothing Then
                                    If DetermineWhetherToAddToOutput(JsonData.item("UniqueID").ToString, SearchWhat) = True Then
                                        ReDim Preserve Results(Results.Count)
                                        Results(Results.Count - 1) = mDir2.FullName
                                        Exit For
                                    End If
                                End If
                            Next

                        Case SearchType.ContentPakForAndDependencies
                            Dim a As New ItemInfoReader
                            a.ReadItemInfo(mDir2.FullName, New SMUI.Windows.Core.Objects.ItemCalculateType With {.ContentPackFor = True, .Dependencies = True})
                            For i = 0 To a.ContentPackFor.Count - 1
                                If DetermineWhetherToAddToOutput(a.ContentPackFor(i), SearchWhat) = True Then
                                    ReDim Preserve Results(Results.Count)
                                    Results(Results.Count - 1) = mDir2.FullName
                                    GoTo jx1
                                End If
                            Next
                            For i = 0 To a.Dependencies.Count - 1
                                If DetermineWhetherToAddToOutput(a.Dependencies(i), SearchWhat) = True Then
                                    ReDim Preserve Results(Results.Count)
                                    Results(Results.Count - 1) = mDir2.FullName
                                    GoTo jx1
                                End If
                            Next
jx1:
                        Case SearchType.IncludedFolders
                            Dim mDir3 As IO.DirectoryInfo
                            Dim mDirInfo3 As New IO.DirectoryInfo(mDir2.FullName)
                            For Each mDir3 In mDirInfo3.GetDirectories
                                If DetermineWhetherToAddToOutput(mDir3.Name, SearchWhat) = True Then
                                    ReDim Preserve Results(Results.Count)
                                    Results(Results.Count - 1) = mDir2.FullName
                                    Exit For
                                End If
                            Next

                        Case SearchType.NexusID
                            Dim a As New ItemInfoReader
                            a.ReadItemInfo(mDir2.FullName, New SMUI.Windows.Core.Objects.ItemCalculateType With {.UpdateKeys = True})
                            For i = 0 To a.NexusID.Count - 1
                                If DetermineWhetherToAddToOutput(a.NexusID(i), SearchWhat) = True Then
                                    ReDim Preserve Results(Results.Count)
                                    Results(Results.Count - 1) = mDir2.FullName
                                    Exit For
                                End If
                            Next

                    End Select

                Next
            Next
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try


    End Function

    Private Function DetermineWhetherToAddToOutput(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        If InStr(StringComparison, SearchWhat) > 0 Then
            Return True : Exit Function
        End If
        If ST_NotCaseUpperAndLowerLetters = True Then
            If CompareNotCaseUpperAndLowerLetters(StringComparison, SearchWhat) = True Then
                Return True : Exit Function
            End If
        End If
        If ST_NotCaseCHS_ENG_Symbol = True Then
            If CompareNotCaseCHS_ENG_Symbol(StringComparison, SearchWhat) = True Then
                Return True : Exit Function
            End If
        End If
        If ST_SingleCharacterFuzzySearch = True Then
            If CompareSingleCharacterFuzzySearch(StringComparison, SearchWhat) = True Then
                Return True : Exit Function
            End If
        End If
        Return False
    End Function

    Private Function CompareNotCaseUpperAndLowerLetters(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        If InStr(StringComparison.ToLower, SearchWhat.ToLower) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CompareNotCaseCHS_ENG_Symbol(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        Dim a As String = StringComparison.Replace("，", ",").Replace("。", ".")
        Dim b As String = SearchWhat.Replace("，", ",").Replace("。", ".")

        If InStr(a, b) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CompareSingleCharacterFuzzySearch(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        Dim a As String
        Dim b As Char()

        If ST_NotCaseUpperAndLowerLetters = True Then
            a = StringComparison.ToLower
            b = SearchWhat.ToLower.ToCharArray
        Else
            a = StringComparison
            b = SearchWhat.ToCharArray
        End If

        For i = 0 To b.Count - 1
            If InStr(a, b(i)) = 0 Then
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

End Class
