Imports System.IO
Imports System.Net
Imports Lake1059.GitAPI.GitApiObject
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
''' <summary>
''' 使用此类时请先将此类 New 到一个对象
''' </summary>
Public Class Release

    Public 发布标题 As String = ""
    Public 版本标签 As String = ""
    Public 预览版 As Boolean = False
    Public 发布描述 As String = ""
    Public 发布时间 As String = ""

    Public 发布者用户名 As String = ""
    ''' <summary>
    ''' 注意 GitHub 没有发布者昵称这个东西，Gitee 才有
    ''' </summary>
    Public 发布者昵称 As String = ""
    ''' <summary>
    ''' 此数组中的每个元素与“文件下载地址”数组中的元素对应
    ''' </summary>
    Public 文件名 As String() = {}
    ''' <summary>
    ''' 此数组中的每个元素与“文件名”数组中的元素对应
    ''' </summary>
    Public 文件下载地址 As String() = {}

    ''' <summary>
    ''' 如果发生错误会将错误描述返回至此字符串
    ''' </summary>
    Public ErrorString As String = ""

    ''' <summary>
    ''' 访问开源代码平台的网页API，并分析返回的 Json 以获取各项信息
    ''' </summary>
    ''' <param name="目标平台">选择 Gitee (码云) 和 GitHub</param>
    ''' <param name="存储库">使用仓库URL中的名称，而不是其他名称</param>
    ''' <returns>如果一切顺利会返回空字符串，否则返回错误描述，你也可以选择判断 ErrorString 字符串</returns>
    Public Function 获取仓库发布版信息(ByVal 目标平台 As 开源代码平台, ByVal 存储库 As String) As String
        Try
            Dim str1 As String = ""
            ErrorString = ""
            Select Case 目标平台
                Case 开源代码平台.Gitee
                    str1 = "https://gitee.com/api/v5/repos/" & 存储库 & "/releases/?direction=desc"
                Case 开源代码平台.GitHub
                    str1 = "https://api.github.com/repos/" & 存储库 & "/releases"
            End Select

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
            Dim 数据 As String = "{" & """" & "Data" & """" & ": " & strHTML & "}"

            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(数据), JObject)
            If JsonData.item("Data").Count Is Nothing Then
                If JsonData.item("Data").item("message") IsNot Nothing Then
                    ErrorString = JsonData.item("Data").item("message").ToString
                    Exit Try
                End If
            End If

            If JsonData.item("Data").Count >= 1 Then
                发布标题 = JsonData.item("Data")(0).item("name").ToString
                版本标签 = JsonData.item("Data")(0).item("tag_name").ToString
                预览版 = JsonData.item("Data")(0).item("prerelease").ToString
                发布描述 = JsonData.item("Data")(0).item("body").ToString
                发布时间 = JsonData.item("Data")(0).item("created_at").ToString

                发布者用户名 = JsonData.item("Data")(0).item("author").item("login").ToString
                If 目标平台 = 开源代码平台.Gitee Then
                    发布者昵称 = JsonData.item("Data")(0).item("author").item("name").ToString
                End If

                For i = 0 To JsonData.item("Data")(0).item("assets").Count - 1
                    If JsonData.item("Data")(0).item("assets").item(i)("name") IsNot Nothing Then
                        ReDim Preserve 文件名(文件名.Count)
                        文件名(文件名.Count - 1) = JsonData.item("Data")(0).item("assets").item(i)("name").ToString
                        ReDim Preserve 文件下载地址(文件下载地址.Count)
                        文件下载地址(文件下载地址.Count - 1) = JsonData.item("Data")(0).item("assets").item(i)("browser_download_url").ToString
                    End If
                Next
            Else
                ErrorString = "Server failed to return valid data."
                Exit Try
            End If
        Catch ex As Exception
            ErrorString = ex.Message
        End Try
        Return ErrorString

    End Function

    Public Sub 检查所有属性()
        Dim a As String = ""
        a &= "发布标题：" & 发布标题 & vbNewLine & vbNewLine
        a &= "版本标签：" & 版本标签 & vbNewLine & vbNewLine
        a &= "预览版：" & 预览版 & vbNewLine & vbNewLine
        a &= "发布描述：" & 发布描述 & vbNewLine & vbNewLine
        a &= "发布时间：" & 发布时间 & vbNewLine & vbNewLine

        a &= "发布者用户名：" & 发布者用户名 & vbNewLine & vbNewLine
        a &= "发布者昵称：" & 发布者昵称 & vbNewLine & vbNewLine

        a &= "文件名 数组中有 " & 文件名.Count & " 个元素：" & vbNewLine
        For i = 0 To 文件名.Count - 1
            a &= 文件名(i) & vbNewLine
        Next
        a &= vbNewLine

        a &= "文件下载地址 数组中有 " & 文件下载地址.Count & " 个元素：" & vbNewLine
        For i = 0 To 文件下载地址.Count - 1
            a &= 文件下载地址(i) & vbNewLine
        Next
        MsgBox(a)

    End Sub

End Class
