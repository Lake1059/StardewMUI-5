Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Windows.Forms

Public Class ModsGlobalCheck

    Public Structure Data_NoContentPackType
        Public UniqueID As String
        Public TargetUniqueID As String
    End Structure
    Public Structure Data_NoDependencyType
        Public UniqueID As String
        Public TargetUniqueID As String
    End Structure
    Public Structure Data_DependencyVersionLowType
        Public UniqueID As String
        Public TargetUniqueID As String
        Public MinimumVersion As String
    End Structure
    Public Structure Data_NeedUpdateSmapiType
        Public Name As String
        Public UniqueID As String
        Public MinimumApiVersion As String
    End Structure
    Public Structure Data_MultiLevelFolderType
        Public Name As String
        Public UniqueID As String
        Public Path As String
    End Structure

    Public Data_Name As String() = {}
    Public Data_UniqueID As String() = {}
    Public Data_UniqueIDVerison As String() = {}
    Public Data_UniqueIDMinimumApiVersion As String() = {}

    Public Data_NoContentPackMods As Data_NoContentPackType() = {}
    Public Data_NoDependencyMods As Data_NoDependencyType() = {}
    Public Data_DependencyVersionLowMods As Data_DependencyVersionLowType() = {}
    Public Data_NeedUpdateSmapiMods As Data_NeedUpdateSmapiType() = {}
    Public Data_MultiLevelFolderMods As Data_MultiLevelFolderType() = {}
    Public Data_NoUniqueIDMods As String() = {}
    Public Data_MeaninglessFolder As String() = {}
    Public Data_MeaninglessFile As String() = {}

    Public Enum RealTimeOutputType
        MultiLine = 0
        Line = 1
    End Enum

    Public SetRealTimeOutputType As RealTimeOutputType = RealTimeOutputType.MultiLine

    Public Function StartCheck(ModsFolder As String, Optional ByRef RealTimeOutput As String = "", Optional SmapiVerison As String = "", Optional SystemPathConnector As String = "\") As String
        Try
            RealTimeOutput = ""
            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Scanning manifest files. . ." & vbNewLine
            Else
                RealTimeOutput = "Scanning manifest files. . ."
            End If
            Application.DoEvents()
            Dim a1 As New SearchFile
            a1.SearchManifests(ModsFolder, True)
            If a1.ErrorString <> "" Then
                RealTimeOutput = a1.ErrorString
                Return a1.ErrorString
                Exit Function
            End If

            Dim ManifestsList As String() = a1.FileCollection

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Reading manifest data. . ." & vbNewLine
            Else
                RealTimeOutput = "Reading manifest data. . ."
            End If
            Application.DoEvents()
            For i = 0 To ManifestsList.Count - 1
                Dim a As String = ReadAllText(CombinePath(ModsFolder, ManifestsList(i)))
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                If JsonData.item("Name") IsNot Nothing Then
                    ReDim Preserve Data_Name(Data_Name.Count)
                    Data_Name(Data_Name.Count - 1) = JsonData.item("Name").ToString
                Else
                    Continue For
                End If
                If JsonData.item("UniqueID") IsNot Nothing Then
                    ReDim Preserve Data_UniqueID(Data_UniqueID.Count)
                    Data_UniqueID(Data_UniqueID.Count - 1) = JsonData.item("UniqueID").ToString
                Else
                    ReDim Preserve Data_NoUniqueIDMods(Data_NoUniqueIDMods.Count)
                    Data_NoUniqueIDMods(Data_NoUniqueIDMods.Count - 1) = ManifestsList(i)
                End If
                If JsonData.item("Version") IsNot Nothing Then
                    ReDim Preserve Data_UniqueIDVerison(Data_UniqueIDVerison.Count)
                    Data_UniqueIDVerison(Data_UniqueIDVerison.Count - 1) = JsonData.item("Version").ToString
                Else
                    ReDim Preserve Data_UniqueIDVerison(Data_UniqueIDVerison.Count)
                    Data_UniqueIDVerison(Data_UniqueIDVerison.Count - 1) = ""
                End If
                If JsonData.item("MinimumApiVersion") IsNot Nothing Then
                    ReDim Preserve Data_UniqueIDMinimumApiVersion(Data_UniqueIDMinimumApiVersion.Count)
                    Data_UniqueIDMinimumApiVersion(Data_UniqueIDMinimumApiVersion.Count - 1) = JsonData.item("MinimumApiVersion").ToString
                Else
                    ReDim Preserve Data_UniqueIDMinimumApiVersion(Data_UniqueIDMinimumApiVersion.Count)
                    Data_UniqueIDMinimumApiVersion(Data_UniqueIDMinimumApiVersion.Count - 1) = ""
                End If
                If ManifestsList(i).Split(SystemPathConnector).Count > 3 Then
                    Dim x1 As New Data_MultiLevelFolderType With {
                        .Name = Data_Name(i),
                        .UniqueID = Data_UniqueID(i),
                        .Path = IO.Path.GetDirectoryName(ManifestsList(i))
                    }
                    ReDim Preserve Data_MultiLevelFolderMods(Data_MultiLevelFolderMods.Count)
                    Data_MultiLevelFolderMods(Data_MultiLevelFolderMods.Count - 1) = x1
                End If
            Next


            If SmapiVerison <> "" Then
                If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                    RealTimeOutput &= "Comparing SMAPI versions. . ." & vbNewLine
                Else
                    RealTimeOutput = "Comparing SMAPI versions. . ."
                End If
                Application.DoEvents()
                For i = 0 To Data_UniqueID.Count - 1
                    If Data_UniqueIDMinimumApiVersion(i) <> "" Then
                        If SharedFunction.CompareVersion(Data_UniqueIDMinimumApiVersion(i), SmapiVerison) > 0 Then
                            Dim x1 As New Data_NeedUpdateSmapiType With {
                                .Name = Data_Name(i),
                                .UniqueID = Data_UniqueID(i),
                                .MinimumApiVersion = Data_UniqueIDMinimumApiVersion(i)
                             }
                            ReDim Preserve Data_NeedUpdateSmapiMods(Data_NeedUpdateSmapiMods.Count)
                            Data_NeedUpdateSmapiMods(Data_NeedUpdateSmapiMods.Count - 1) = x1
                        End If
                    End If
                Next
            End If

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Checking dependencies. . ." & vbNewLine
            Else
                RealTimeOutput = "Checking dependencies. . ."
            End If
            Application.DoEvents()
            For i = 0 To ManifestsList.Count - 1
                Dim a As String = ReadAllText(CombinePath(ModsFolder, ManifestsList(i)))
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                If JsonData.item("Name") Is Nothing Then Continue For
                If JsonData.item("UniqueID") Is Nothing Then Continue For
                If JsonData.item("ContentPackFor") Is Nothing Then GoTo jx1
                If JsonData.item("ContentPackFor").item("UniqueID") Is Nothing Then GoTo jx1
                Dim ContentPackString As String = JsonData.item("ContentPackFor").item("UniqueID").ToString
                For i3 = 0 To Data_UniqueID.Count - 1
                    If Data_UniqueID(i3).ToLower = ContentPackString.ToLower Then GoTo jx1
                Next
                Dim x1 As New Data_NoContentPackType With {
                    .UniqueID = JsonData.item("UniqueID").ToString,
                    .TargetUniqueID = ContentPackString
                }
                ReDim Preserve Data_NoContentPackMods(Data_NoContentPackMods.Count)
                Data_NoContentPackMods(Data_NoContentPackMods.Count - 1) = x1
jx1:
                If JsonData.item("Dependencies") Is Nothing Then Continue For
                For i5 = 0 To JsonData.item("Dependencies").Count - 1
                    If JsonData.item("Dependencies").item(i5)("UniqueID") Is Nothing Then GoTo jx2
                    If JsonData.item("Dependencies").item(i5)("IsRequired") IsNot Nothing Then
                        Select Case Replace(JsonData.item("Dependencies").item(i5)("IsRequired").ToString.ToLower, " ", "")
                            Case "false"
                                Continue For
                        End Select
                    End If
                    Dim DependenciesString As String = JsonData.item("Dependencies").item(i5)("UniqueID").ToString
                    For i7 = 0 To Data_UniqueID.Count - 1
                        If Data_UniqueID(i7).ToLower = DependenciesString.ToLower Then
                            If JsonData.item("Dependencies").item(i5)("MinimumVersion") IsNot Nothing Then
                                Dim DependenciesMinimumVersionString As String = JsonData.item("Dependencies").item(i5)("MinimumVersion").ToString
                                If SharedFunction.CompareVersion(Data_UniqueIDVerison(i7), DependenciesMinimumVersionString) < 0 Then
                                    Dim v1 As New Data_DependencyVersionLowType With {
                                        .UniqueID = JsonData.item("Dependencies").item(i5)("UniqueID").ToString,
                                        .TargetUniqueID = DependenciesString,
                                        .MinimumVersion = DependenciesMinimumVersionString
                                    }
                                    ReDim Preserve Data_DependencyVersionLowMods(Data_DependencyVersionLowMods.Count)
                                    Data_DependencyVersionLowMods(Data_DependencyVersionLowMods.Count - 1) = v1
                                End If
                            Else
                                GoTo jx3
                            End If
                            GoTo jx3
                        End If
                    Next
                    Dim x2 As New Data_NoDependencyType With {
                        .UniqueID = JsonData.item("UniqueID").ToString,
                        .TargetUniqueID = DependenciesString
                    }
                    ReDim Preserve Data_NoDependencyMods(Data_NoDependencyMods.Count)
                    Data_NoDependencyMods(Data_NoDependencyMods.Count - 1) = x2
jx3:
                Next
jx2:
            Next

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Scanning meaningless folders. . ." & vbNewLine
            Else
                RealTimeOutput = "Scanning meaningless folders. . ."
            End If
            Application.DoEvents()
            Dim p1 As String() = SharedFunction.SearchFolderWithoutSub(ModsFolder)
            Dim p1s1 As Boolean()
            ReDim p1s1(p1.Count - 1)
            For i = 0 To ManifestsList.Count - 1
                For i3 = 0 To p1.Count - 1
                    If InStr(ManifestsList(i3), p1(i3)) = 1 And ManifestsList(i3) <> p1(i3) Then
                        p1s1(i3) = True
                        GoTo jx5
                    End If
                Next
jx5:
            Next
            For i = 0 To p1s1.Count - 1
                If p1s1(i) = False Then
                    ReDim Preserve Data_MeaninglessFolder(Data_MeaninglessFolder.Count)
                    Data_MeaninglessFolder(Data_MeaninglessFolder.Count - 1) = p1(i)
                End If
            Next

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Scanning meaningless files. . ." & vbNewLine
            Else
                RealTimeOutput = "Scanning meaningless files. . ."
            End If
            Application.DoEvents()
            Dim sf1 As New SearchFile
            sf1.SearchFiles(ModsFolder, False)
            If sf1.ErrorString <> "" Then
                If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                    RealTimeOutput &= "An error occurred while scanning meaningless files: " & sf1.ErrorString & vbNewLine
                Else
                    RealTimeOutput = "An error occurred while scanning meaningless files: " & sf1.ErrorString
                End If
                Application.DoEvents()
                GoTo ed1
            End If
            For i = 0 To sf1.FileCollection.Count - 1
                ReDim Preserve Data_MeaninglessFile(Data_MeaninglessFile.Count)
                Data_MeaninglessFile(Data_MeaninglessFile.Count - 1) = sf1.FileCollection(i)
            Next
ed1:
            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Done."
            Else
                RealTimeOutput = "Done."
            End If
            Application.DoEvents()
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function






End Class
