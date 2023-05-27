Imports System.IO
Imports System.Net
Imports Lake1059.GitAPI.GitApiObject
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

''' <summary>
''' 使用此类时请先将此类 New 到一个对象
''' </summary>
Public Class Branches

    Public 分支 As String() = {}
    Public 受保护的 As Boolean() = {}

    ''' <summary>
    ''' 如果发生错误会将错误描述返回至此字符串
    ''' </summary>
    Public ErrorString As String = ""

    ''' <summary>
    ''' 访问开源代码平台仓库分支，并分析返回的 Json 以获取各项信息
    ''' </summary>
    ''' <param name="目标平台">选择 Gitee (码云) 和 GitHub</param>
    ''' <param name="存储库">使用URL中的名称，而不是其他名称</param>
    ''' <returns>如果一切顺利会返回空字符串，否则返回错误描述，你也可以选择判断 ErrorString 字符串</returns>
    Public Function 获取仓库分支集合(ByVal 目标平台 As 开源代码平台, ByVal 存储库 As String, Optional ByVal 令牌 As String = "") As String
        Try
            Dim str1 As String = ""
            ErrorString = ""
            Select Case 目标平台
                Case 开源代码平台.Gitee
                    str1 = "https://gitee.com/api/v5/repos/" & 存储库 & "/branches"
                Case 开源代码平台.GitHub
                    str1 = "https://api.github.com/repos/" & 存储库 & "/branches"
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
            'myReq.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3")
            Dim result As HttpWebResponse = DirectCast(myReq.GetResponse(), HttpWebResponse)
            Dim receviceStream As Stream = result.GetResponseStream()
            Dim readerOfStream As New StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"))
            Dim strHTML As String = readerOfStream.ReadToEnd()
            readerOfStream.Close()
            receviceStream.Close()
            result.Close()
            Dim 数据 As String = strHTML
            数据 = "{" & """" & "Data" & """" & ":" & 数据
            数据 &= "}"

            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
            If JsonData.item("Data").Count Is Nothing Then
                If JsonData.item("Data").item("message") IsNot Nothing Then
                    ErrorString = JsonData.item("Data").item("message").ToString
                    Exit Try
                End If
            End If


            For i = 0 To JsonData.item("Data").count - 1
                ReDim Preserve 分支(分支.Count)
                分支(分支.Count - 1) = JsonData.item("Data").item(i)("name").ToString
                ReDim Preserve 受保护的(受保护的.Count)
                受保护的(受保护的.Count - 1) = JsonData.item("Data").item(i)("protected").ToString
            Next

        Catch ex As Exception
            ErrorString = ex.Message
        End Try
        Return ErrorString

    End Function

    Public Sub 检查所有属性()
        Dim a As String = ""

        a &= "分支 数组中有 " & 分支.Count & " 个元素：" & vbNewLine
        For i = 0 To 分支.Count - 1
            a &= 分支(i) & vbNewLine
        Next
        a &= vbNewLine

        a &= "受保护的 数组中有 " & 受保护的.Count & " 个元素：" & vbNewLine
        For i = 0 To 受保护的.Count - 1
            a &= 受保护的(i) & vbNewLine
        Next
        MsgBox(a)

    End Sub




End Class
