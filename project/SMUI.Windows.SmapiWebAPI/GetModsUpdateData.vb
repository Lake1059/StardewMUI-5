Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class GetModsUpdateData

    Public ErrorString As String = ""

    Public Function StartGet(yourPostJsonText As String, ByRef ReceiveDataObject As String) As String
        Try
            Dim uri As New Uri("https://smapi.io/api/v3.0/mods")
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            myReq.ContinueTimeout = 1000
            myReq.UserAgent = "WEB API"
            myReq.Method = "POST"
            myReq.ContentType = "application/json"
            myReq.MediaType = "application/json"
            myReq.KeepAlive = False
            Dim postData = System.Text.Encoding.UTF8.GetBytes(yourPostJsonText)
            myReq.ContentLength = postData.Length
            myReq.GetRequestStream().Write(postData, 0, postData.Length)
            Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
            Dim receviceStream As Stream = result.GetResponseStream()
            Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
            Dim strHTML As String = readerOfStream.ReadToEnd()
            readerOfStream.Close()
            receviceStream.Close()
            result.Close()
            'strHTML = "{" & """" & "data" & """" & ":" & strHTML & "}"
            'Dim JsonData As Object = CType(JsonConvert.DeserializeObject(strHTML), JObject)
            'If JsonData.item("data").item("message") IsNot Nothing Then
            '    ErrorString = JsonData.item("message").ToString
            '    Return ErrorString
            '    Exit Try
            'End If
            ReceiveDataObject = strHTML
            Return ""
        Catch ex As Exception
            ErrorString = ex.Message
            Return ex.Message
        End Try
    End Function





End Class
