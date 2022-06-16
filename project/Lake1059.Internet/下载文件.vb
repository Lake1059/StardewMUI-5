Public Class 下载文件
	''' <summary>
	''' 请使用异步调用此方法
	''' </summary>
	Public Shared Function DownloadFile(URL As String, FileName As String, ByRef 已下载字节量 As Long, ByRef 总字节量 As Long, ByRef 是否终止下载 As Boolean) As String
		Try
			Dim Myrq As System.Net.HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create(URL), System.Net.HttpWebRequest)
			Myrq.ContinueTimeout = 10000
			Dim myrp As System.Net.HttpWebResponse = DirectCast(Myrq.GetResponse(), System.Net.HttpWebResponse)
			Dim totalBytes As Long = myrp.ContentLength

			Dim st As System.IO.Stream = myrp.GetResponseStream()
			Dim so As System.IO.Stream = New System.IO.FileStream(FileName, System.IO.FileMode.Create)
			Dim totalDownloadedByte As Long = 0
			Dim by As Byte() = New Byte(1023) {}
			Dim osize As Integer = st.Read(by, 0, by.Length)
			While osize > 0
				If 是否终止下载 = True Then
					Exit While
				End If
				totalDownloadedByte = osize + totalDownloadedByte
				so.Write(by, 0, osize)
				osize = st.Read(by, 0, by.Length)
				已下载字节量 = totalDownloadedByte
				总字节量 = totalBytes
			End While
			so.Close()
			st.Close()
			Return ""
		Catch ex As System.Exception
			Return ex.Message
		End Try
	End Function


End Class
