Public Class Objects
    Public Structure SmapiRequestInputData
        Public apiVersion As String
        Public gameVersion As String
        ''' <summary>
        ''' Android,Linux,Mac,Windows
        ''' </summary>
        Public platform As String
        Public includeExtendedMetadata As String

        ''' <summary>
        ''' UniqueID
        ''' </summary>
        Public mods_id As String()
        Public mods_updatekeys As UpdatekeysData()
        Public installedversion As String()
        Public isBroken As String()
    End Structure

    Public Structure UpdatekeysData
        Public Nexus As String()
        Public Moddrop As String()
        Public Github As String()
        Public CurseForge As String()
        Public Chucklefish As String()
    End Structure

    Public Structure SmapiResponseOutputData
        ''' <summary>
        ''' UniqueID
        ''' </summary>
        Public id As String()
        Public suggestedUpdate_version As String()
        Public suggestedUpdate_url As String()
        Public metadata As Metadata()
        Public errors As String()
    End Structure

    Public Structure Metadata
        ''' <summary>
        ''' UniqueID
        ''' </summary>
        Public id As String()
        Public name As String
        Public nexusID As String
        Public chucklefishID As String
        Public curseForgeID As String
        Public curseForgeKey As String
        Public modDropID As String
        Public gitHubRepo As String
        Public customSourseUrl As String
        Public customUrl As String

        Public main_version As String
        Public main_url As String
        Public optional_version As String
        Public optional_url As String
        Public unofficial_version As String
        Public unofficial_url As String
        Public unofficialForBeta_version As String
        Public unofficialForBeta_url As String

        Public hasBetaInfo As String
        Public compatibilityStatus As String
        Public compatibilitySummary As String
        Public brokeIn As String

        Public betaCompatibilityStatus As String
        Public betaCompatibilitySummary As String
        Public betaBrokeIn As String

        Public errors As String
    End Structure


    Public Shared Sub Initialize_SmapiRequestInputData(ByRef data As SmapiRequestInputData)
        data.apiVersion = ""
        data.gameVersion = ""
        data.platform = ""
        data.includeExtendedMetadata = True
        data.mods_id = {}
        data.mods_updatekeys = {}
        data.installedversion = {}
        data.isBroken = {}
    End Sub

    Public Shared Sub Initialize_UpdatekeysData(ByRef data As UpdatekeysData)
        data.Nexus = {}
        data.Moddrop = {}
        data.Github = {}
        data.CurseForge = {}
        data.Chucklefish = {}
    End Sub

    Public Shared Sub Initialize_SmapiResponseOutputData(ByRef data As SmapiResponseOutputData)
        data.id = {}
        data.suggestedUpdate_version = {}
        data.suggestedUpdate_url = {}
        data.metadata = {}
        data.errors = {}
    End Sub

    Public Shared Sub Initialize_Metadata(ByRef data As Metadata)
        data.id = {}
        data.name = ""
        data.nexusID = ""
        data.chucklefishID = ""
        data.curseForgeID = ""
        data.curseForgeKey = ""
        data.modDropID = ""
        data.gitHubRepo = ""
        data.customSourseUrl = ""
        data.customUrl = ""
        data.main_version = ""
        data.main_url = ""
        data.optional_version = ""
        data.optional_url = ""
        data.unofficial_version = ""
        data.unofficial_url = ""
        data.unofficialForBeta_version = ""
        data.unofficialForBeta_url = ""
        data.hasBetaInfo = ""
        data.compatibilityStatus = ""
        data.compatibilitySummary = ""
        data.brokeIn = ""
        data.betaCompatibilityStatus = ""
        data.betaCompatibilitySummary = ""
        data.betaBrokeIn = ""
        data.errors = ""
    End Sub

End Class
