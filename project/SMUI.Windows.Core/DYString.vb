Public Class DYString

    Public Shared Property CanNotFoundFolderInMods = "Cannot find the folder that already exists in Mods: "
    Public Shared Property RequiredFolderNotExist As String = "The required folder does not exist: "
    Public Shared Property RequiredFileNotExist As String = "The required file does not exist: "
    Public Shared Property DefinedNoUninstall As String = "Defined can not uninstall: "
    Public Shared Property DefinedFolderExclude As String = "Defined folder exclude: "
    Public Shared Property SUBWithOutEndSub As String = "SUB without END SUB."


    Public Shared Sub TranslateAllStringToChinese()
        CanNotFoundFolderInMods = "无法找到在 Mods 中的文件夹："
        RequiredFolderNotExist = "定义的必须文件夹不存在："
        RequiredFileNotExist = "定义的必须文件不存在："
        DefinedNoUninstall = "已定义为不能卸载："
        DefinedFolderExclude = "检测到定义的排斥文件夹存在："
        SUBWithOutEndSub = "SUB 命令没有 END SUB"
    End Sub



End Class

