Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GetUserInfo


    Public ST_ApiKey As String = ""
    Public ErrorString As String = ""

    Public user_id As String
    Public key As String
    Public name As String
    Public is_premium As String
    Public is_supporter As String
    Public email As String
    ''' <summary>
    ''' User Image URL
    ''' </summary>
    Public profile_url As String

    Public daily_limit As Integer
    Public daily_remaining As Integer
    Public hourly_limit As Integer
    Public hourly_remaining As Integer


    Public Function StartGet() As String
        Try
            Dim uri As New Uri("https://api.nexusmods.com/v1/users/validate.json")
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            myReq.ContinueTimeout = 1000
            myReq.UserAgent = NexusModsApiObject.GlobalUserAgent
            'myReq.Accept = "text/html"
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

            user_id = JsonData.item("user_id").ToString
            key = JsonData.item("key").ToString
            name = JsonData.item("name").ToString
            is_premium = JsonData.item("is_premium").ToString
            is_supporter = JsonData.item("is_supporter").ToString
            email = JsonData.item("email").ToString
            profile_url = JsonData.item("profile_url").ToString

            Return ""
        Catch ex As Exception
            ErrorString = ex.Message
            Return ex.Message
        End Try
    End Function
End Class
