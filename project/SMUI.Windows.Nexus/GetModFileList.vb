
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GetModFileList


    Public ST_ApiKey As String = ""
    Public ErrorString As String = ""

    Public uid As Long()
    Public file_id As Long()
    Public name As String()
    Public version As String()
    Public category_id As Integer()
    Public category_name As String()
    Public is_primary As String()
    Public size As Long()
    Public file_name As String()
    Public uploaded_timestamp As Long()
    Public uploaded_time As String()
    Public mod_version As String()
    Public external_virus_scan_url As String()
    Public description As String()
    Public size_kb As Long()
    Public changelog_html As String()
    Public content_preview_link As String()

    Public daily_limit As Integer
    Public daily_remaining As Integer
    Public hourly_limit As Integer
    Public hourly_remaining As Integer

    Public Function StartGet(GameName As String, ModID As Integer, ListFileType As NexusModsApiObject.FileType) As String
        Try
            Dim str1 As String = ""
            ErrorString = ""
            Select Case ListFileType
                Case NexusModsApiObject.FileType.mainFile
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main"
                Case NexusModsApiObject.FileType.optionalFile
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=optional"
                Case NexusModsApiObject.FileType.updateFile
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=update"
                Case NexusModsApiObject.FileType.old_versionFile
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=old_version"
                Case NexusModsApiObject.FileType.miscellaneousFile
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=miscellaneous"
                Case NexusModsApiObject.FileType.ALL
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json"
                Case NexusModsApiObject.FileType.main_optional_miscellaneous
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main,optional,miscellaneous"
                Case NexusModsApiObject.FileType.main_optional
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main,optional"
                Case NexusModsApiObject.FileType.main_optional_updateFile_miscellaneous
                    str1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files.json?category=main,optional,update,miscellaneous"
            End Select

            Dim uri As New Uri(str1)
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            myReq.ContinueTimeout = 1000
            myReq.UserAgent = NexusModsApiObject.GlobalUserAgent
            myReq.Method = "GET"
            myReq.KeepAlive = False
            myReq.Headers.Add("apikey", ST_ApiKey)
            Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
            Dim receviceStream As Stream = result.GetResponseStream()
            daily_limit = result.GetResponseHeader("x-rl-daily-limit")
            daily_remaining = result.GetResponseHeader("x-rl-daily-remaining")
            hourly_limit = result.GetResponseHeader("x-rl-hourly-limit")
            hourly_remaining = result.GetResponseHeader("x-rl-hourly-remaining")
            Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
            Dim strHTML As String = readerOfStream.ReadToEnd()
            readerOfStream.Close()
            receviceStream.Close()
            result.Close()

            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)
            If JsonData.item("message") IsNot Nothing Then
                ErrorString = JsonData.item("message").ToString
                Return ErrorString
                Exit Try
            End If

            Dim int1 As Integer = JsonData.item("files").Count - 1
            ReDim uid(int1)
            ReDim file_id(int1)
            ReDim name(int1)
            ReDim version(int1)
            ReDim category_id(int1)
            ReDim category_name(int1)
            ReDim is_primary(int1)
            ReDim size(int1)
            ReDim file_name(int1)
            ReDim uploaded_timestamp(int1)
            ReDim uploaded_time(int1)
            ReDim mod_version(int1)
            ReDim external_virus_scan_url(int1)
            ReDim description(int1)
            ReDim size_kb(int1)
            ReDim changelog_html(int1)
            ReDim content_preview_link(int1)

            For i = 0 To JsonData.item("files").Count - 1
                uid(i) = JsonData.item("files").item(i)("uid").ToString
                file_id(i) = JsonData.item("files").item(i)("file_id").ToString
                name(i) = JsonData.item("files").item(i)("name").ToString
                version(i) = JsonData.item("files").item(i)("version").ToString
                category_id(i) = JsonData.item("files").item(i)("category_id").ToString
                category_name(i) = JsonData.item("files").item(i)("category_name").ToString
                is_primary(i) = JsonData.item("files").item(i)("is_primary").ToString
                size(i) = JsonData.item("files").item(i)("size").ToString
                file_name(i) = JsonData.item("files").item(i)("file_name").ToString
                uploaded_timestamp(i) = JsonData.item("files").item(i)("uploaded_timestamp").ToString
                uploaded_time(i) = JsonData.item("files").item(i)("uploaded_time").ToString
                mod_version(i) = JsonData.item("files").item(i)("mod_version").ToString
                external_virus_scan_url(i) = JsonData.item("files").item(i)("external_virus_scan_url").ToString
                description(i) = JsonData.item("files").item(i)("description").ToString
                size_kb(i) = JsonData.item("files").item(i)("size_kb").ToString
                changelog_html(i) = JsonData.item("files").item(i)("changelog_html").ToString
                content_preview_link(i) = JsonData.item("files").item(i)("content_preview_link").ToString
            Next

            Return ""
        Catch ex As Exception
            ErrorString = ex.Message
            Return ex.Message
        End Try
    End Function



End Class
