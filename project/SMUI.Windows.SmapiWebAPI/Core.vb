
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports SMUI.Windows.SmapiWebAPI.Objects

Public Class Core

    Shared Function GenerateJsonFieldText(FieldName As String, FieldData As String) As String
        Return """" & FieldName & """" & ": " & """" & FieldData & """" & ","
    End Function

    Shared Function GenerateJsonFieldText(FieldName As String, FieldData As Boolean) As String
        Return """" & FieldName & """" & ": " & FieldData.ToString.ToLower & ","
    End Function

    ''' <summary>
    ''' 生成 JSON 数据
    ''' </summary>
    ''' <param name="InputData">输入数据</param>
    ''' <param name="ErrorString">用一个字符串对象接收错误信息</param>
    ''' <returns>准备发送至 smapi.io/api 接口的 JSON 数据</returns>
    Public Shared Function GenerateRequestJsonData(InputData As SmapiRequestInputData, ByRef ErrorString As String) As String
        If InputData.mods_id.Length = 0 Then
            ErrorString = "no mod data"
            Return ""
            Exit Function
        End If

        Dim JsonData As String = "{"

        If InputData.apiVersion <> "" Then JsonData &= GenerateJsonFieldText("apiVersion", InputData.apiVersion)
        If InputData.gameVersion <> "" Then JsonData &= GenerateJsonFieldText("gameVersion", InputData.gameVersion)
        If InputData.platform <> "" Then JsonData &= GenerateJsonFieldText("platform", InputData.platform)
        If InputData.includeExtendedMetadata.ToLower = "true" Then JsonData &= GenerateJsonFieldText("includeExtendedMetadata", InputData.includeExtendedMetadata)

        JsonData &= """" & "mods" & """" & ":" & "["
        For i = 0 To InputData.mods_id.Length - 1
            JsonData &= "{"
            JsonData &= GenerateJsonFieldText("id", InputData.mods_id(i))
            Dim a1 As String = ""
            For i2 = 0 To InputData.mods_updatekeys(i).Nexus.Length - 1
                If InputData.mods_updatekeys(i).Nexus(i2) = "" Then Continue For
                If a1 <> "" Then a1 &= ","
                a1 &= """" & "Nexus:" & InputData.mods_updatekeys(i).Nexus(i2) & """"
            Next
            For i2 = 0 To InputData.mods_updatekeys(i).Moddrop.Length - 1
                If InputData.mods_updatekeys(i).Moddrop(i2) = "" Then Continue For
                If a1 <> "" Then a1 &= ","
                a1 &= """" & "Moddrop:" & InputData.mods_updatekeys(i).Moddrop(i2) & """"
            Next
            For i2 = 0 To InputData.mods_updatekeys(i).Github.Length - 1
                If InputData.mods_updatekeys(i).Github(i2) = "" Then Continue For
                If a1 <> "" Then a1 &= ","
                a1 &= """" & "Github:" & InputData.mods_updatekeys(i).Github(i2) & """"
            Next
            For i2 = 0 To InputData.mods_updatekeys(i).CurseForge.Length - 1
                If InputData.mods_updatekeys(i).CurseForge(i2) = "" Then Continue For
                If a1 <> "" Then a1 &= ","
                a1 &= """" & "CurseForge:" & InputData.mods_updatekeys(i).CurseForge(i2) & """"
            Next
            For i2 = 0 To InputData.mods_updatekeys(i).Chucklefish.Length - 1
                If InputData.mods_updatekeys(i).Chucklefish(i2) = "" Then Continue For
                If a1 <> "" Then a1 &= ","
                a1 &= """" & "Chucklefish:" & InputData.mods_updatekeys(i).Chucklefish(i2) & """"
            Next
            If a1 <> "" Then JsonData &= """" & "updatekeys" & """" & ":[" & a1 & "],"
            If InputData.installedversion(i) <> "" Then JsonData &= GenerateJsonFieldText("installedversion", InputData.installedversion(i))
            If InputData.isBroken(i) = "True" Then JsonData &= GenerateJsonFieldText("isBroken", InputData.isBroken(i))
            JsonData &= "},"
        Next
        JsonData &= "]}"
        Return JsonData
    End Function




    ''' <summary>
    ''' 处理服务器发来的数据，将其转换为 .NET 对象
    ''' </summary>
    ''' <param name="ResponseJson">smapi.io 接口返回的 JSON 文本数据</param>
    ''' <param name="ErrorString">用一个字符串对象接收错误信息</param>
    ''' <returns>输出类型为 SmapiResponseOutputData 的数据，这些数据已经处理好可直接使用</returns>
    Public Shared Function ProcessSmapiResponse(ResponseJson As String, ByRef ErrorString As String) As SmapiResponseOutputData
        If ResponseJson = "" Then
            ErrorString = "no json data"
            Return Nothing
            Exit Function
        End If

        Dim OutputData As New SmapiResponseOutputData
        Initialize_SmapiResponseOutputData(OutputData)
        ResponseJson = "{" & """" & "data" & """" & ":" & ResponseJson & "}"
        Dim JsonData As Object = CType(JsonConvert.DeserializeObject(ResponseJson), JObject)

        For i = 0 To JsonData.item("data").count - 1
            AddElment(OutputData.id, JsonData.item("data")(i).item("id").ToString)
            If JsonData.item("data")(i).item("suggestedUpdate") IsNot Nothing Then
                AddElment(OutputData.suggestedUpdate_version, JsonData.item("data")(i).item("suggestedUpdate").item("version").ToString)
                AddElment(OutputData.suggestedUpdate_url, JsonData.item("data")(i).item("suggestedUpdate").item("url").ToString)
            Else
                AddElment(OutputData.suggestedUpdate_version, "null")
                AddElment(OutputData.suggestedUpdate_url, "null")
            End If
            If JsonData.item("data")(i).item("errors") IsNot Nothing Then
                AddElment(OutputData.errors, JsonData.item("data")(i).item("errors").ToString)
            Else
                AddElment(OutputData.errors, "")
            End If
            If JsonData.item("data")(i).item("metadata") IsNot Nothing Then
                ReDim Preserve OutputData.metadata(OutputData.metadata.Count)
                OutputData.metadata(OutputData.metadata.Count - 1) = New Metadata
                Initialize_Metadata(OutputData.metadata(i))

                For i2 = 0 To JsonData.item("data")(i).item("metadata").item("id").count - 1
                    AddElment(OutputData.metadata(i).id, JsonData.item("data")(i).item("metadata").item("id")(i2).ToString)
                Next
                If JsonData.item("data")(i).item("metadata").item("nexusID") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).name, JsonData.item("data")(i).item("metadata").item("name").ToString)
                Else
                    AddValue(OutputData.metadata(i).name, "")
                End If
                If JsonData.item("data")(i).item("metadata").item("nexusID") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).nexusID, JsonData.item("data")(i).item("metadata").item("nexusID").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("chucklefishID") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).chucklefishID, JsonData.item("data")(i).item("metadata").item("chucklefishID").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("curseForgeID") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).curseForgeID, JsonData.item("data")(i).item("metadata").item("curseForgeID").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("curseForgeKey") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).curseForgeKey, JsonData.item("data")(i).item("metadata").item("curseForgeKey").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("modDropID") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).modDropID, JsonData.item("data")(i).item("metadata").item("modDropID").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("gitHubRepo") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).gitHubRepo, JsonData.item("data")(i).item("metadata").item("gitHubRepo").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("customSourseUrl") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).customSourseUrl, JsonData.item("data")(i).item("metadata").item("customSourseUrl").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("customUrl") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).customUrl, JsonData.item("data")(i).item("metadata").item("customUrl").ToString)
                End If

                If JsonData.item("data")(i).item("metadata").item("main") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).main_version, JsonData.item("data")(i).item("metadata").item("main").item("version").ToString)
                    AddValue(OutputData.metadata(i).main_url, JsonData.item("data")(i).item("metadata").item("main").item("url").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("optional") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).optional_version, JsonData.item("data")(i).item("metadata").item("optional").item("version"))
                    AddValue(OutputData.metadata(i).optional_url, JsonData.item("data")(i).item("metadata").item("optional").item("url"))
                End If
                If JsonData.item("data")(i).item("metadata").item("unofficial") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).unofficial_version, JsonData.item("data")(i).item("metadata").item("unofficial").item("version").ToString)
                    AddValue(OutputData.metadata(i).unofficial_url, JsonData.item("data")(i).item("metadata").item("unofficial").item("url").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("unofficialForBeta") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).unofficialForBeta_version, JsonData.item("data")(i).item("metadata").item("unofficialForBeta").item("version").ToString)
                    AddValue(OutputData.metadata(i).unofficialForBeta_url, JsonData.item("data")(i).item("metadata").item("unofficialForBeta").item("url").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("hasBetaInfo") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).hasBetaInfo, JsonData.item("data")(i).item("metadata").item("hasBetaInfo").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("compatibilityStatus") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).compatibilityStatus, JsonData.item("data")(i).item("metadata").item("compatibilityStatus").ToString)
                    AddValue(OutputData.metadata(i).compatibilitySummary, JsonData.item("data")(i).item("metadata").item("compatibilitySummary").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("brokeIn") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).brokeIn, JsonData.item("data")(i).item("metadata").item("brokeIn").ToString)
                End If
                If JsonData.item("data")(i).item("metadata").item("betaCompatibilityStatus") IsNot Nothing Then
                    AddValue(OutputData.metadata(i).betaCompatibilityStatus, JsonData.item("data")(i).item("metadata").item("betaCompatibilityStatus").ToString)
                    AddValue(OutputData.metadata(i).betaCompatibilitySummary, JsonData.item("data")(i).item("metadata").item("betaCompatibilitySummary").ToString)
                    AddValue(OutputData.metadata(i).betaBrokeIn, JsonData.item("data")(i).item("metadata").item("betaBrokeIn").ToString)
                End If
                AddValue(OutputData.metadata(i).errors, JsonData.item("data")(i).item("errors").ToString)
            End If
        Next

        Return OutputData
    End Function

    Shared Sub AddElment(ByRef obj As String(), data As String)
        ReDim Preserve obj(obj.Length)
        obj(obj.Length - 1) = data
    End Sub

    Shared Sub AddValue(ByRef obj As String, data As Object)
        If data Is Nothing Then
            obj = ""
        Else
            obj = data.ToString
        End If
    End Sub

    Shared Sub AddValue(ByRef obj As Integer, data As Object)
        If data Is Nothing Then
            obj = 0
        Else
            obj = data.ToString
        End If
    End Sub

    Shared Sub AddValue(ByRef obj As Boolean, data As Object)
        If data Is Nothing Then
            obj = 0
        Else
            obj = data.ToString
        End If
    End Sub




End Class
