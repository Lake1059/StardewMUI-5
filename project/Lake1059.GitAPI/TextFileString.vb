Imports System.IO
Imports System.Net
Imports Lake1059.GitAPI.GitApiObject
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' 使用此类时请先将此类 New 到一个对象
''' </summary>
Public Class TextFileString

    Public 网页返回字符串 As String = ""
    ''' <summary>
    ''' 如果发生错误会将错误描述返回至此字符串
    ''' </summary>
    Public ErrorString As String = ""

    ''' <summary>
    ''' 获取纯文本文件内容
    ''' </summary>
    ''' <param name="目标平台"></param>
    ''' <param name="用户名和仓库名"></param>
    ''' <param name="分支"></param>
    ''' <param name="路径"></param>
    ''' <returns>如果一切顺利会返回空字符串，否则返回错误描述，你也可以选择判断 ErrorString 字符串</returns>
    Public Function 获取文本文件数据(ByVal 目标平台 As 开源代码平台, ByVal 用户名和仓库名 As String, ByVal 分支 As String, ByVal 路径 As String, Optional ByVal 令牌 As String = "", Optional ByVal 是否需要进行Json错误消息识别 As Boolean = False) As String
        Try
            Dim str1 As String = ""
            ErrorString = ""
            Select Case 目标平台
                Case 开源代码平台.Gitee
                    str1 = "https://gitee.com/" & 用户名和仓库名 & "/raw/" & 分支 & "/" & 路径
                Case 开源代码平台.GitHub
                    str1 = "https://raw.githubusercontent.com/" & 用户名和仓库名 & "/" & 分支 & "/" & 路径
            End Select
            If 令牌 <> "" Then
                Select Case 目标平台
                    Case 开源代码平台.Gitee
                        str1 &= "?access_token=" & 令牌
                    Case 开源代码平台.GitHub
                        str1 &= "?token=" & 令牌
                End Select
            End If
            Dim uri As New Uri(str1)
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            myReq.UserAgent = 自定义UserAgent
            'myReq.Accept = "text/html"
            myReq.Method = "GET"
            myReq.KeepAlive = False
            myReq.ContinueTimeout = 10000
            'If 目标平台 = 开源代码平台.GitHub Then
            '    myReq.Accept = "application/vnd.github.v3+json"
            '    myReq.ContentType = "application/json"
            'End If
            'myReq.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3")
            Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
            Dim receviceStream As Stream = result.GetResponseStream()
            Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
            Dim strHTML As String = readerOfStream.ReadToEnd()
            readerOfStream.Close()
            receviceStream.Close()
            result.Close()
            Dim 数据 As String = strHTML

            If 是否需要进行Json错误消息识别 = True Then
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
                If JsonData.item("message") IsNot Nothing Then
                    ErrorString = JsonData.item("message").ToString
                    Return ErrorString
                Else
                    网页返回字符串 = 数据
                End If
            Else
                网页返回字符串 = 数据
            End If

        Catch ex As Exception
            ErrorString = ex.Message
        End Try
        Return ErrorString

    End Function

End Class
