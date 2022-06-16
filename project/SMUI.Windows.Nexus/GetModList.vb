Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GetModList


    Public ST_ApiKey As String = ""
    Public ErrorString As String = ""

    Public name As String()
    Public summary As String()
    Public description As String()
    Public picture_url As String()
    Public uid As Long()
    Public mod_id As Long()
    Public game_id As String()
    Public allow_rating As Boolean()
    Public domain_name As String()
    Public category_id As Integer()
    Public version As String()
    Public endorsement_count As Long()
    Public created_timestamp As String()
    Public created_time As String()
    Public updated_timestamp As String()
    Public updated_time As String()
    Public author As String()
    Public uploaded_by As String()
    Public uploaded_users_profile_url As String()
    Public contains_adult_content As Boolean()
    Public status As String()
    Public available As Boolean()

    Public daily_limit As Integer
    Public daily_remaining As Integer
    Public hourly_limit As Integer
    Public hourly_remaining As Integer

    Public Function StartGet(ByVal gameName As String, ByVal yourListType As NexusModsApiObject.ListModType) As String
        Try
            Dim str1 As String = ""
            ErrorString = ""
            Select Case yourListType
                Case NexusModsApiObject.ListModType.TheLatest10ModsReleased
                    str1 = "https://api.nexusmods.com/v1/games/" & gameName & "/mods/latest_added.json"
                Case NexusModsApiObject.ListModType.TheLatest10ModsUpdated
                    str1 = "https://api.nexusmods.com/v1/games/" & gameName & "/mods/latest_updated.json"
                Case NexusModsApiObject.ListModType.The10EveryTimeHotMods
                    str1 = "https://api.nexusmods.com/v1/games/" & gameName & "/mods/trending.json"
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
            strHTML = "{" & """" & "Data" & """" & ":" & strHTML
            strHTML &= "}"

            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)

            If JsonData.item("Data").Count Is Nothing Then
                If JsonData.item("Data").item("message") IsNot Nothing Then
                    ErrorString = JsonData.item("Data").item("message").ToString
                    Return ErrorString
                    Exit Try
                End If
            End If

            Dim i3 As Integer = JsonData.item("Data").Count - 1
            ReDim name(i3)
            ReDim summary(i3)
            ReDim description(i3)
            ReDim picture_url(i3)
            ReDim uid(i3)
            ReDim mod_id(i3)
            ReDim game_id(i3)
            ReDim allow_rating(i3)
            ReDim domain_name(i3)
            ReDim category_id(i3)
            ReDim version(i3)
            ReDim endorsement_count(i3)
            ReDim created_timestamp(i3)
            ReDim created_time(i3)
            ReDim updated_timestamp(i3)
            ReDim updated_time(i3)
            ReDim author(i3)
            ReDim uploaded_by(i3)
            ReDim uploaded_users_profile_url(i3)
            ReDim contains_adult_content(i3)
            ReDim status(i3)
            ReDim available(i3)

            For i = 0 To i3
                If JsonData.item("Data").item(i)("name") Is Nothing Then
                    name(i) = ""
                Else
                    name(i) = JsonData.item("Data").item(i)("name").ToString
                End If
                If JsonData.item("Data").item(i)("summary") Is Nothing Then
                    summary(i) = ""
                Else
                    summary(i) = JsonData.item("Data").item(i)("summary").ToString
                End If
                If JsonData.item("Data").item(i)("description") Is Nothing Then
                    description(i) = ""
                Else
                    description(i) = JsonData.item("Data").item(i)("description").ToString
                End If
                If JsonData.item("Data").item(i)("picture_url") Is Nothing Then
                    picture_url(i) = ""
                Else
                    picture_url(i) = JsonData.item("Data").item(i)("picture_url").ToString
                End If
jx1:
                uid(i) = JsonData.item("Data").item(i)("uid").ToString
                mod_id(i) = JsonData.item("Data").item(i)("mod_id").ToString
                game_id(i) = JsonData.item("Data").item(i)("game_id").ToString
                allow_rating(i) = JsonData.item("Data").item(i)("allow_rating").ToString
                domain_name(i) = JsonData.item("Data").item(i)("domain_name").ToString
                category_id(i) = JsonData.item("Data").item(i)("category_id").ToString
                version(i) = JsonData.item("Data").item(i)("version").ToString
                endorsement_count(i) = JsonData.item("Data").item(i)("endorsement_count").ToString
                created_timestamp(i) = JsonData.item("Data").item(i)("created_timestamp").ToString
                created_time(i) = JsonData.item("Data").item(i)("created_time").ToString
                updated_timestamp(i) = JsonData.item("Data").item(i)("updated_timestamp").ToString
                updated_time(i) = JsonData.item("Data").item(i)("updated_time").ToString
                author(i) = JsonData.item("Data").item(i)("author").ToString
                uploaded_by(i) = JsonData.item("Data").item(i)("uploaded_by").ToString
                uploaded_users_profile_url(i) = JsonData.item("Data").item(i)("uploaded_users_profile_url").ToString
                contains_adult_content(i) = JsonData.item("Data").item(i)("contains_adult_content").ToString
                status(i) = JsonData.item("Data").item(i)("status").ToString
                available(i) = JsonData.item("Data").item(i)("available").ToString

            Next

            Return ""
        Catch ex As Exception
            ErrorString = ex.Message
            Return ex.Message
        End Try
    End Function


End Class
