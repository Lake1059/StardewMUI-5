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

        'Dim NotInstalledFolder As Boolean
        'Dim NotCopiedFolder As Boolean
        'Dim NotReplacedFile As Boolean
        'Dim NotCopiedFile As Boolean

    End Structure

    Public Enum CDTask
        CDCD = 1
        CDGCD = 2
        CDMAD = 3
        CDGRF = 4
        CDGCF = 5
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

        SUB_D_EX_IN = 51
    End Enum
End Class
