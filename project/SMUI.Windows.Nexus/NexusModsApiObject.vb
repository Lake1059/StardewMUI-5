Public Class NexusModsApiObject
    Public Enum FileType
        mainFile = 1
        optionalFile = 2
        updateFile = 3
        old_versionFile = 4
        miscellaneousFile = 5
        ALL = 0
        main_optional = 11
        main_optional_miscellaneous = 12
        main_optional_updateFile_miscellaneous = 13
    End Enum

    Public Enum ListModType
        TheLatest10ModsReleased = 1
        TheLatest10ModsUpdated = 2
        The10EveryTimeHotMods = 3
    End Enum

    Public Enum ListIDType
        The10UpdatedOnToday = 1
        The10UpdatedThisWeek = 2
        The10UpdatedThisMonth = 3
    End Enum

    Public Shared Property GlobalUserAgent As String = "NEXUS API (Windows NT; WOW64) from SMUI.Windows.Nexus by 1059 Stutudio"

End Class