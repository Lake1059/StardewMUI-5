Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GetModFileDownloadURL

    Public ST_ApiKey As String = ""
    Public ErrorString As String = ""

    Public name As String()
    Public short_name As String()
    Public URI As String()

    Public daily_limit As Integer
    Public daily_remaining As Integer
    Public hourly_limit As Integer
    Public hourly_remaining As Integer

    Public Function StartGet(GameName As String, ModID As Integer, FileID As Integer, Optional key As String = "", Optional expires As String = "") As String
        Try
            ErrorString = ""
            Dim u1 As String
            If key <> "" And expires <> "" Then
                u1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files/" & FileID & "/download_link.json?key=" & key & "&expires=" & expires
            Else
                u1 = "https://api.nexusmods.com/v1/games/" & GameName & "/mods/" & ModID & "/files/" & FileID & "/download_link.json"
            End If
            Dim myURL As New Uri(u1)
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(myURL), HttpWebRequest)
            myReq.ContinueTimeout = 1000
            myReq.UserAgent = NexusModsApiObject.GlobalUserAgent
            'myReq.Accept = "html/text"
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
            ReDim short_name(i3)
            ReDim URI(i3)

            For i = 0 To i3
                name(i) = JsonData.item("Data").item(i)("name").ToString
                short_name(i) = JsonData.item("Data").item(i)("short_name").ToString
                URI(i) = JsonData.item("Data").item(i)("URI").ToString
            Next

            Return ""

        Catch ex As Exception
            ErrorString = ex.Message
            Return ex.Message
        End Try
    End Function




End Class
