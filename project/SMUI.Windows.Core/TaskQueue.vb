
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class TaskQueue

    Public Sub New()
        InitializeDictionary()
    End Sub

    Public ItemPath As String
    Public GamePath As String
    Public GameBackupPath As String

    Public Task_Code As Objects.CDTask()
    Public Task_Parameter1 As String()
    Public Task_Parameter2 As String()
    Public Code_LineMark As Integer()

    Public Sub Reset()
        Task_Code = Array.Empty(Of Objects.CDTask)()
        Task_Parameter1 = Array.Empty(Of String)()
        Task_Parameter2 = Array.Empty(Of String)()
        Code_LineMark = Array.Empty(Of Integer)()
    End Sub

    Public MatchDictionary As New Dictionary(Of String, OperationDelegate)()
    Delegate Sub OperationDelegate()

    Public Sub InitializeDictionary()
        MatchDictionary.Add("CDCD", AddressOf MatchOn_CDCD)
        MatchDictionary.Add("CDCP", AddressOf MatchOn_CDCD)
        MatchDictionary.Add("CDGCD", AddressOf MatchOn_CDGCD)
        MatchDictionary.Add("CDMAD", AddressOf MatchOn_CDMAD)
        MatchDictionary.Add("CDGRF", AddressOf MatchOn_CDGRF)
        MatchDictionary.Add("CDGCF", AddressOf MatchOn_CDGCF)
        MatchDictionary.Add("CDGCF-SHA", AddressOf MatchOn_CDGCF_SHA)
        MatchDictionary.Add("CDF", AddressOf MatchOn_CDF)
        MatchDictionary.Add("CDVD", AddressOf MatchOn_CDVD)
        MatchDictionary.Add("CDCC", AddressOf MatchOn_CDVD)
        MatchDictionary.Add("RQ-D", AddressOf MatchOn_RQ_D)
        MatchDictionary.Add("RQ-D-IN", AddressOf MatchOn_RQ_D_IN)
        MatchDictionary.Add("RQ-D-UN", AddressOf MatchOn_RQ_D_UN)
        MatchDictionary.Add("RQ-F", AddressOf MatchOn_RQ_F)
        MatchDictionary.Add("RQ-F-IN", AddressOf MatchOn_RQ_F_IN)
        MatchDictionary.Add("RQ-F-UN", AddressOf MatchOn_RQ_F_UN)
        MatchDictionary.Add("CR-UN-OFF", AddressOf MatchOn_CR_UN_OFF)
        MatchDictionary.Add("CR-UN-CANCEL", AddressOf MatchOn_CR_UN_CANCEL)
        MatchDictionary.Add("CR-CG-DB", AddressOf MatchOn_CR_CG_DB)
        MatchDictionary.Add("CR-APP-SHELL-IN", AddressOf MatchOn_CR_APP_SHELL_IN)
        MatchDictionary.Add("CR-APP-SHELL-P-IN", AddressOf MatchOn_CR_APP_SHELL_P_IN)
        MatchDictionary.Add("CR-APP-SHELL-UN", AddressOf MatchOn_CR_APP_SHELL_UN)
        MatchDictionary.Add("CR-APP-SHELL-P-UN", AddressOf MatchOn_CR_APP_SHELL_P_UN)
    End Sub

    Sub MatchOn_CDCD()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDCD
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_CDGCD()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDGCD
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub
    Sub MatchOn_CDMAD()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDMAD
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_CDGRF()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDGRF
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub
    Sub MatchOn_CDGCF()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDGCF
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub
    Sub MatchOn_CDGCF_SHA()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDGCF_SHA
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub
    Sub MatchOn_CDF()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDF
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub
    Sub MatchOn_CDVD()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDVD
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = ""
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
    End Sub
    Sub MatchOn_RQ_D()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.RQ_D
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_RQ_D_IN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.RQ_D_IN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_RQ_D_UN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.RQ_D_UN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_RQ_F()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.RQ_F
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_RQ_F_IN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.RQ_F_IN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_RQ_F_UN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.RQ_F_UN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_CR_UN_OFF()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_UN_OFF
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = ""
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
    End Sub
    Sub MatchOn_CR_UN_CANCEL()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_UN_CANCEL
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = ""
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
    End Sub
    Sub MatchOn_CR_CG_DB()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_CG_DB
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = ""
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
    End Sub
    Sub MatchOn_CR_APP_SHELL_IN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_APP_SHELL_IN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_CR_APP_SHELL_P_IN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_APP_SHELL_P_IN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub
    Sub MatchOn_CR_APP_SHELL_UN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_APP_SHELL_UN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = ""
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 1
    End Sub
    Sub MatchOn_CR_APP_SHELL_P_UN()
        ReDim Preserve Task_Code(Task_Code.Length)
        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CR_APP_SHELL_P_UN
        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1)
        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
        Task_Parameter2(Task_Parameter2.Length - 1) = D_LineData(D_Index + 2)
        ReDim Preserve Code_LineMark(Code_LineMark.Length)
        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
        D_Index += 2
    End Sub

    Public D_Index As Integer = 0
    Public D_LineData As String() = {}

    Public Function LoadCode() As String
        Try
            If DirectoryExists(ItemPath) = False Then
                Return DYString.SMUICOREERROR & DYString.ItemPathDoesNotExist & ItemPath : Exit Function
            End If
            If FileExists(CombinePath(ItemPath, "Code")) = False Then
                Return DYString.SMUICOREERROR & DYString.ThisItemDonotHaveCodeFile & ItemPath : Exit Function
            End If

            Reset()
            D_LineData = ReadAllText(CombinePath(ItemPath, "Code")).Split(vbCrLf)
            '解决 .NET Framework 的祖传bug，拆分字符串除了第一行之外其他的行的第一个字符会莫名其妙多出来换行符，如果是 .NET5 请将此移除
            For i = 0 To D_LineData.Count - 1
                If i = 0 Then
                    D_LineData(i) = D_LineData(i)
                Else
                    D_LineData(i) = Mid(D_LineData(i), 2)
                End If
            Next

            For D_Index = 0 To D_LineData.Length - 1
                Dim data1 As String = Replace(D_LineData(D_Index), " ", "")
                If data1 Is Nothing Then Continue For
                data1 = data1.ToUpper
                If MatchDictionary.ContainsKey(data1) Then
                    Dim operation As OperationDelegate = MatchDictionary(Replace(D_LineData(D_Index), " ", "").ToUpper)
                    operation.Invoke()
                    Continue For
                End If
                Select Case data1
                    Case "SUBD-EX-IN"
                        ReDim Preserve Task_Code(Task_Code.Length)
                        Task_Code(Task_Code.Length - 1) = Objects.CDTask.SUB_D_EX_IN
                        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
                        Dim x1 As Integer = D_Index + 1
                        For x1 = D_Index + 1 To D_LineData.Length - 1
                            If Replace(D_LineData(x1), " ", "") Is Nothing Then Continue For
                            If Replace(D_LineData(x1), " ", "").ToUpper = "ENDSUB" Then
                                D_Index = x1
                                Exit For
                            Else
                                If Task_Parameter1(Task_Parameter1.Length - 1) = "" Then
                                    Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(x1)
                                Else
                                    Task_Parameter1(Task_Parameter1.Length - 1) = Task_Parameter1(Task_Parameter1.Length - 1) & "|" & D_LineData(x1)
                                End If
                            End If
                            If x1 = D_LineData.Length - 1 And Replace(D_LineData(x1), " ", "").ToUpper <> "ENDSUB" Then
                                ReDim Preserve Code_LineMark(Code_LineMark.Length)
                                Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
                                Return DYString.SUBWithOutEndSub
                                Exit Function
                            End If
                        Next
                        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
                        Task_Parameter2(Task_Parameter2.Length - 1) = ""
                        ReDim Preserve Code_LineMark(Code_LineMark.Length)
                        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
                        D_Index = x1
                    Case data1.Contains("CDGCF-SHA-")
                        ReDim Preserve Task_Code(Task_Code.Length)
                        Task_Code(Task_Code.Length - 1) = Objects.CDTask.CDGCF_SHA_BYTE
                        ReDim Preserve Task_Parameter1(Task_Parameter1.Length)
                        Task_Parameter1(Task_Parameter1.Length - 1) = D_LineData(D_Index + 1) & "|" & D_LineData(D_Index + 2)
                        ReDim Preserve Task_Parameter2(Task_Parameter2.Length)
                        Task_Parameter2(Task_Parameter2.Length - 1) = Mid(data1, Len("CDGCF-SHA-") + 1)
                        ReDim Preserve Code_LineMark(Code_LineMark.Length)
                        Code_LineMark(Code_LineMark.Length - 1) = D_Index + 1
                        D_Index += 2
                End Select
            Next
            Return ""
        Catch ex As Exception
            Reset()
            Return ex.Message
        End Try
    End Function



    Private CRCGDB As Boolean = False

    Public Function PerformInstall(ByVal TaskIndex As Integer) As String
        Try
            Select Case Task_Code(TaskIndex)
                Case Objects.CDTask.CR_CG_DB
                    CRCGDB = True
                Case Objects.CDTask.CDCD
                    CopyDirectory(CombinePath(ItemPath, Task_Parameter1(TaskIndex)), CombinePath(CombinePath(GamePath, "Mods"), Task_Parameter1(TaskIndex)), True)
                    If CRCGDB = False Then
                        Dim a1 As String = CombinePath(CombinePath(CombinePath(ItemPath, ".config"), Task_Parameter1(TaskIndex)), "config.json")
                        Dim a2 As String = CombinePath(CombinePath(CombinePath(GamePath, "Mods"), Task_Parameter1(TaskIndex)), "config.json")
                        If FileExists(a1) = True Then
                            CopyFile(a1, a2, True)
                        End If
                    End If
                Case Objects.CDTask.CDGCD
                    CopyDirectory(CombinePath(ItemPath, Task_Parameter1(TaskIndex)), CombinePath(GamePath, Task_Parameter2(TaskIndex)), True)
                Case Objects.CDTask.CDMAD
                    If DirectoryExists(CombinePath(CombinePath(GamePath, "Mods"), Task_Parameter1(TaskIndex))) = False Then
                        Return DYString.CanNotFoundFolderInMods & "\" & Task_Parameter1(TaskIndex)
                        Exit Function
                    Else
                        CopyDirectory(CombinePath(ItemPath, Task_Parameter1(TaskIndex)), CombinePath(CombinePath(GamePath, "Mods"), Task_Parameter1(TaskIndex)), True)
                    End If
                Case Objects.CDTask.CDGRF
                    CopyFile(CombinePath(ItemPath, Task_Parameter1(TaskIndex)), CombinePath(GamePath, Task_Parameter2(TaskIndex)), True)
                Case Objects.CDTask.CDGCF, Objects.CDTask.CDGCF_SHA
                    CopyFile(CombinePath(ItemPath, Task_Parameter1(TaskIndex)), CombinePath(GamePath, Task_Parameter2(TaskIndex)), True)
                Case Objects.CDTask.CDGCF_SHA_BYTE
                    Dim a1 As String() = Task_Parameter1(TaskIndex).Split("|")
                    CopyFile(CombinePath(ItemPath, a1(0)), CombinePath(GamePath, a1(1)), True)
                Case Objects.CDTask.CDF
                    CopyFile(CombinePath(ItemPath, Task_Parameter1(TaskIndex)), CombinePath(GamePath, Task_Parameter2(TaskIndex)), True)
                Case Objects.CDTask.CDVD
                    CopyDirectory(CombinePath(ItemPath, "Content"), CombinePath(GamePath, "Content"), True)
                Case Objects.CDTask.RQ_D, Objects.CDTask.RQ_D_IN
                    If DirectoryExists(CombinePath(GamePath, Task_Parameter1(TaskIndex))) = False Then
                        Return DYString.RequiredFolderNotExist & Task_Parameter1(TaskIndex)
                        Exit Function
                    End If
                Case Objects.CDTask.RQ_F, Objects.CDTask.RQ_F_IN
                    If FileExists(CombinePath(GamePath, Task_Parameter1(TaskIndex))) = False Then
                        Return DYString.RequiredFileNotExist & Task_Parameter1(TaskIndex)
                        Exit Function
                    End If
                Case Objects.CDTask.SUB_D_EX_IN
                    Dim x1 As String() = Task_Parameter1(TaskIndex).Split("|")
                    For y = 0 To x1.Length - 1
                        If DirectoryExists(CombinePath(CombinePath(GamePath, "Mods"), x1(y))) = True Then
                            Return DYString.DefinedFolderExclude & x1(y)
                            Exit Function
                        End If
                    Next

            End Select

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    Public Function PerformUnInstall(ByVal TaskIndex As Integer) As String
        Try
            Select Case Task_Code(TaskIndex)
                Case Objects.CDTask.CR_CG_DB
                    CRCGDB = True
                Case Objects.CDTask.CDCD
                    If CRCGDB = False Then
                        Dim a1 As String = CombinePath(CombinePath(CombinePath(ItemPath, ".config"), Task_Parameter1(TaskIndex)), "config.json")
                        Dim a2 As String = CombinePath(CombinePath(CombinePath(GamePath, "Mods"), Task_Parameter1(TaskIndex)), "config.json")
                        If FileExists(a2) = True Then
                            CopyFile(a2, a1, True)
                        End If
                    End If
                    DeleteDirectory(CombinePath(CombinePath(GamePath, "Mods"), Task_Parameter1(TaskIndex)), FileIO.DeleteDirectoryOption.DeleteAllContents)

                Case Objects.CDTask.CDGCD
                    DeleteDirectory(CombinePath(GamePath, Task_Parameter2(TaskIndex)), FileIO.DeleteDirectoryOption.DeleteAllContents)
                Case Objects.CDTask.CDMAD

                Case Objects.CDTask.CDGRF
                    If FileExists(CombinePath(GameBackupPath, Task_Parameter2(TaskIndex))) = True Then
                        CopyFile(CombinePath(GameBackupPath, Task_Parameter2(TaskIndex)), CombinePath(GamePath, Task_Parameter2(TaskIndex)), True)
                    Else
                        DeleteFile(CombinePath(GamePath, Task_Parameter2(TaskIndex)))
                    End If
                Case Objects.CDTask.CDGCF, Objects.CDTask.CDGCF_SHA
                    DeleteFile(CombinePath(GamePath, Task_Parameter2(TaskIndex)))
                Case Objects.CDTask.CDGCF_SHA_BYTE
                    Dim a1 As String() = Task_Parameter1(TaskIndex).Split("|")
                    DeleteFile(CombinePath(GamePath, a1(1)))
                Case Objects.CDTask.CDF
                    If FileExists(CombinePath(GameBackupPath, Task_Parameter2(TaskIndex))) = True Then
                        CopyFile(CombinePath(GameBackupPath, Task_Parameter2(TaskIndex)), CombinePath(GamePath, Task_Parameter2(TaskIndex)), True)
                    Else
                        DeleteFile(CombinePath(GamePath, Task_Parameter2(TaskIndex)))
                    End If
                Case Objects.CDTask.CDVD
                    Dim a As String = IO.Path.GetFileName(ItemPath)
                    Dim b As String = IO.Path.GetFileName(IO.Path.GetDirectoryName(ItemPath))
                    UninstallCDVD(CombinePath(ItemPath, "Content"), b, a)
                Case Objects.CDTask.RQ_D, Objects.CDTask.RQ_D_UN
                    If DirectoryExists(CombinePath(GamePath, Task_Parameter1(TaskIndex))) = False Then
                        Return DYString.RequiredFolderNotExist & Task_Parameter1(TaskIndex)
                        Exit Function
                    End If
                Case Objects.CDTask.RQ_F, Objects.CDTask.RQ_F_UN
                    If FileExists(CombinePath(GamePath, Task_Parameter1(TaskIndex))) = False Then
                        Return DYString.RequiredFileNotExist & Task_Parameter1(TaskIndex)
                        Exit Function
                    End If
                Case Objects.CDTask.CR_UN_OFF
                    Return DYString.DefinedNoUninstall & IO.Path.GetFileName(ItemPath)
                    Exit Function
            End Select

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function


    Private Sub UninstallCDVD(ByVal PathInLibrary As String, ByVal CategoryInLibrary As String, ByVal NameInLibrary As String)
        If DirectoryExists(PathInLibrary) = True Then
            'Dim mFile As System.IO.FileInfo
            'Dim mSubDirectory As System.IO.DirectoryInfo
            Dim mDirectory As New System.IO.DirectoryInfo(PathInLibrary)

            For Each sFile In mDirectory.GetFiles("*.*")
                On Error GoTo jx1
                Dim a As String = Mid(Replace(PathInLibrary, ItemPath, ""), 2)
                If FileExists(CombinePath(CombinePath(GameBackupPath, a), sFile.Name)) = True Then
                    CopyFile(CombinePath(CombinePath(GameBackupPath, a), sFile.Name), CombinePath(CombinePath(GamePath, a), sFile.Name), True)
                Else
                    DeleteFile(CombinePath(CombinePath(GamePath, a), sFile.Name))
                End If
jx1:
            Next
            For Each sSubDirectory In mDirectory.GetDirectories
                UninstallCDVD(sSubDirectory.FullName, CategoryInLibrary, NameInLibrary)
            Next
        End If
    End Sub




End Class
