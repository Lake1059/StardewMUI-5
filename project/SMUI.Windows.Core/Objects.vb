
Public Class Objects
    Public Enum InstallStatus
        Unknow = -1
        NotDeployed = 0
        Installed = 1
        UnInstalled = 2
        Incomplete = 3
        FolderCopied = 5
        FolderNotCopied = 6
        AdditionalContent = 10
        FileReplaced = 20
        FileNotReplaced = 21
        FileCopied = 30
        FileNotCopied = 31
        FileCopiedAndSHAVerified = 32
        FileCopiedAndSHAFailed = 33
        NeedCopyFile = 35
        CoverContent = 40
    End Enum

    Public Structure ItemCalculateType
        Dim All As Boolean

        Dim InstallStatus As Boolean
        Dim Name As Boolean
        Dim Author As Boolean
        Dim Version As Boolean
        Dim InstalledVersion As Boolean
        Dim MinimumApiVersion As Boolean
        Dim Description As Boolean
        Dim UniqueID As Boolean
        Dim UpdateKeys As Boolean
        Dim ContentPackFor As Boolean
        Dim Dependencies As Boolean

    End Structure

    Public Enum CDTask
        CDCD = 1
        CDGCD = 2
        CDMAD = 3
        CDGRF = 4
        CDGCF = 5
        CDGCF_SHA = 7
        CDGCF_SHA_BYTE = 8
        CDF = 6
        CDVD = 10

        RQ_D = 11
        RQ_D_IN = 12
        RQ_D_UN = 13
        RQ_F = 14
        RQ_F_IN = 15
        RQ_F_UN = 16

        CR_UN_OFF = 31
        CR_CG_DB = 32
        CR_UN_CANCEL = 33

        CR_APP_SHELL_IN = 40
        CR_APP_SHELL_UN = 41
        CR_APP_SHELL_P_IN = 42
        CR_APP_SHELL_P_UN = 43

        SUB_D_EX_IN = 51

    End Enum

End Class
