Imports SMUI.Windows.PakManager

Module 配置队列

    Public 当前的安装命令是否书写正确 As Boolean = False
    Public 当前的项是否添加正确 As Boolean = False

    Public Sub 重置配置队列选择状态()
        Form1.ToolStripTextBox1.Text = ""
        Form1.ToolStripTextBox2.Text = ""
        Form1.RichTextBox3.Text = ""
        Form1.RichTextBox4.Text = ""
        Form1.ListView4.Items.Clear()
        Form1.Timer2.Enabled = False
    End Sub

    Public Sub 选中队列中的项时触发读取()
        If Form1.ListView3.SelectedItems.Count = 1 Then
            Dim 模组路径 As String = 检查并返回当前可用子库路径(False) & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).Text & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).SubItems(1).Text
            Form1.ToolStripTextBox1.Text = Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).SubItems(1).Text
            If My.Computer.FileSystem.FileExists(模组路径 & "\Version") = True Then
                Form1.ToolStripTextBox2.Text = My.Computer.FileSystem.ReadAllText(模组路径 & "\Version")
            Else
                Form1.ToolStripTextBox2.Text = ""
            End If
            If My.Computer.FileSystem.FileExists(模组路径 & "\Code") = True Then
                Form1.RichTextBox3.Text = My.Computer.FileSystem.ReadAllText(模组路径 & "\Code", System.Text.Encoding.UTF8)
            Else
                Form1.RichTextBox3.Text = ""
            End If
            设置富文本框行高(Form1.RichTextBox3, 300)
            设置富文本框行高(Form1.RichTextBox4, 300)
            重新扫描项的数据内容(模组路径)
            Form1.Timer2.Enabled = True
        Else
            重置配置队列选择状态()
        End If
    End Sub

    Public Sub 重新扫描项的数据内容(ByVal 模组路径 As String)
        Form1.ListView4.Items.Clear()
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(模组路径)
        For Each mDir In mDirInfo.GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config"
                Case Else
                    Form1.ListView4.Items.Add(mDir.Name)
                    Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DynamicText/Folder"))
                    If My.Computer.FileSystem.FileExists(mDir.FullName & "\manifest.json") = True Then
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 4
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.绿色
                    ElseIf mDir.Name = "assets" Then
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 2
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.橙色
                    ElseIf mDir.Name = "Content" Then
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 7
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.紫色
                    Else
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 0
                        Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.白色
                    End If
            End Select
        Next

        Dim 文件 As System.IO.FileInfo
        Dim 目录 As New System.IO.DirectoryInfo(模组路径)
        For Each 文件 In 目录.GetFiles("*.*")
            Select Case 文件.Name
                Case "README", "Version", "Code", "README.rtf", "Font"
                Case Else
                    Form1.ListView4.Items.Add(文件.Name)
                    Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).SubItems.Add(获取动态多语言文本("data/DynamicText/File"))
                    Select Case 文件.Name
                        '韩红无语.mp4，贤齐震惊.jpg，若瑄揉肩.gif
                        Case "manifest.json", "content.json", "config.json", "README", "Version", "Code", "README.rtf", "Font"
                            Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 1
                            Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.红色
                            Continue For
                    End Select
                    Select Case 文件.Extension.ToLower
                        Case ".zip", ".rar", ".7z"
                            Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 5
                            Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.青色
                            Continue For
                    End Select
                    Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).StateImageIndex = 7
                    Form1.ListView4.Items.Item(Form1.ListView4.Items.Count - 1).ForeColor = Color1.紫色
            End Select
        Next
    End Sub

    Sub 添加情况分析文本(ByVal 文本 As String, ByVal 颜色 As Color)
        If Form1.RichTextBox4.Text = "" Then
            Form1.RichTextBox4.AppendText(文本)
        Else
            Form1.RichTextBox4.AppendText(vbNewLine & 文本)
        End If
        Form1.RichTextBox4.Select(Form1.RichTextBox4.TextLength - 文本.Length, 文本.Length)
        Form1.RichTextBox4.SelectionColor = 颜色
    End Sub

    Function 保存到项() As Boolean
        If Form1.ListView3.SelectedItems.Count <> 1 Then Return False : Exit Function
        If 当前的安装命令是否书写正确 = False Then
            Dim msg As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Deploy.5"))
            msg.ShowDialog(Form1)
            Return False : Exit Function
        End If
        If 当前的项是否添加正确 = False Then
            Dim msg As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Deploy.6"))
            msg.ShowDialog(Form1)
            Return False : Exit Function
        End If

        Dim 模组路径 As String = 检查并返回当前可用子库路径(False) & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).Text & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).SubItems(1).Text
        Dim 分类名称 As String = Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).Text
        Dim 模组名称 As String = Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).SubItems(1).Text
        If 模组名称 <> Form1.ToolStripTextBox1.Text Then
            If My.Computer.FileSystem.DirectoryExists(模组路径) = False Then
                Dim msg As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Deploy.1"))
                msg.ShowDialog(Form1)
                Return False
                Exit Function
            End If
            If My.Computer.FileSystem.DirectoryExists(分类名称 & "\" & Form1.ToolStripTextBox1.Text) = True Then
                Dim msg As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Deploy.2"))
                msg.ShowDialog(Form1)
                Return False
                Exit Function
            End If
            My.Computer.FileSystem.RenameDirectory(模组路径, Form1.ToolStripTextBox1.Text)
            模组路径 = 检查并返回当前可用子库路径(False) & "\" & 分类名称 & "\" & Form1.ToolStripTextBox1.Text
        End If
        If Form1.ToolStripTextBox2.Text = "" Then
            If My.Computer.FileSystem.FileExists(模组路径 & "\Version") = True Then
                My.Computer.FileSystem.DeleteFile(模组路径 & "\Version")
            End If
        Else
            My.Computer.FileSystem.WriteAllText(模组路径 & "\Version", Form1.ToolStripTextBox2.Text, False)
        End If
        If Form1.RichTextBox3.Text = "" Then
            If My.Computer.FileSystem.FileExists(模组路径 & "\Code") = True Then
                My.Computer.FileSystem.DeleteFile(模组路径 & "\Code")
            End If
        Else
            Dim 数据 As String = Form1.RichTextBox3.Text.Replace(vbLf, vbCrLf)
            My.Computer.FileSystem.WriteAllText(模组路径 & "\Code", 数据, False, System.Text.Encoding.UTF8)
        End If
        Return True
    End Function

    Private Sub 插入文本(ByVal str As String)
        If Form1.RichTextBox3.SelectedText = Nothing Then
            Dim a As Integer = Form1.RichTextBox3.SelectionStart
            Form1.RichTextBox3.Text = Form1.RichTextBox3.Text.Insert(a, str)
            Form1.RichTextBox3.SelectionStart = a + str.Length + 1
        Else
            Form1.RichTextBox3.SelectedText = str
        End If
    End Sub

    Public Function 显示所有命令() As DarkUI.Controls.DarkContextMenu
        Dim a As New DarkUI.Controls.DarkContextMenu With {
            .ShowImageMargin = False,
            .DropShadowEnabled = False,
            .ShowCheckMargin = False
        }
        AddHandler a.Items.Add("CDCD").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CDMAD").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CDGCD").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CDGRF").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CDGCF").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CDF").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CDVD").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        a.Items.Add(New ToolStripSeparator)
        AddHandler a.Items.Add("RQ-D").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("RQ-D-IN").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("RQ-D-UN").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("RQ-F").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("RQ-F-IN").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("RQ-F-UN").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        a.Items.Add(New ToolStripSeparator)
        AddHandler a.Items.Add("CR-UN-OFF").Click,
            Sub(s, e)
                插入文本(s.Text)
            End Sub
        AddHandler a.Items.Add("CR-CG-DB").Click,
    Sub(s, e)
        插入文本(s.Text)
    End Sub
        a.Items.Add(New ToolStripSeparator)
        AddHandler a.Items.Add("SUB D-EX-IN").Click,
            Sub(s, e)
                插入文本(s.Text & vbNewLine & vbNewLine & "END SUB")
            End Sub
        Return a
    End Function

    Public Sub 自动生成命令()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As String = ""
        Dim 模组路径 As String = 检查并返回当前可用子库路径(False) & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).Text & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).SubItems(1).Text
        For i = 0 To Form1.ListView4.Items.Count - 1
            Select Case Form1.ListView4.Items.Item(i).SubItems(1).Text
                Case 获取动态多语言文本("data/DynamicText/Folder")
                    Select Case Form1.ListView4.Items.Item(i).Text
                        Case "Content"
                            If a = "" Then
                                a = "CDVD"
                            Else
                                a = a & vbNewLine & "CDVD"
                            End If
                        Case Else
                            If My.Computer.FileSystem.FileExists(模组路径 & "\" & Form1.ListView4.Items.Item(i).Text & "\manifest.json") = True Then
                                If a = "" Then
                                    a = "CDCD" & vbNewLine & Form1.ListView4.Items.Item(i).Text
                                Else
                                    a = a & vbNewLine & "CDCD" & vbNewLine & Form1.ListView4.Items.Item(i).Text
                                End If
                            End If
                    End Select
            End Select
        Next

        If a = "" Then
            Dim msg As New SingleSelectionDialog(获取动态多语言文本("data/DynamicText/Negative"), {获取动态多语言文本("data/DynamicText/OK")}, 获取动态多语言文本("data/DynamicText/Deploy.3"))
            msg.ShowDialog(Form1)
        Else
            Form1.RichTextBox3.Text = a
        End If

    End Sub

    Private Function 字符_行() As String
        Return 获取动态多语言文本("data/DynamicText/Line") & " "
    End Function

    Public Sub 定时检查安装命令和项数据()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        If Form1.RichTextBox3.Text = "" Then
            Form1.RichTextBox4.Text = ""
            Exit Sub
        End If
        Form1.RichTextBox4.Text = ""
        Dim 存在错误 As Boolean = False
        Dim 当前项路径 As String = 检查并返回当前可用子库路径(False) & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).Text & "\" & Form1.ListView3.Items.Item(Form1.ListView3.SelectedIndices(0)).SubItems(1).Text
        Dim line As String() = Replace(Form1.RichTextBox3.Text, vbLf, vbCrLf).Split(vbNewLine)
        '解决 .NET Framework 的祖传bug，分割字符串除了第一行外其他行的开头字符会多出来占位一个字的换行符
        For i = 0 To line.Count - 1
            If i = 0 Then
                line(i) = line(i)
            Else
                line(i) = Mid(line(i), 2)
            End If
        Next
        For i = 0 To line.Count - 1
            If Replace(line(i), " ", "") Is Nothing Then Continue For
            Select Case Replace(line(i), " ", "").ToUpper
                Case "CDCD", "CDCP"
                    If i = line.Count - 1 Then
                        添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.7"), Color1.红色)
                        存在错误 = True : Exit Select
                    End If
                    If line(i + 1).Replace(" ", "") = "" Or line(i + 1) = Nothing Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If My.Computer.FileSystem.DirectoryExists(当前项路径 & "\" & line(i + 1)) = False Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.9") & line(i + 1), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If My.Computer.FileSystem.FileExists(当前项路径 & "\" & line(i + 1) & "\manifest.json") = False Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.20"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    i += 1
                Case "CDGCD"
                    If i = line.Count - 1 Or i = line.Count - 2 Then
                        添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.7"), Color1.红色)
                        存在错误 = True : Exit Select
                    End If
                    If line(i + 1).Replace(" ", "") = "" Or line(i + 1) = Nothing Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If line(i + 2).Replace(" ", "") = "" Or line(i + 2) = Nothing Then
                        添加情况分析文本(字符_行() & i + 3 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If My.Computer.FileSystem.DirectoryExists(当前项路径 & "\" & line(i + 1)) = False Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.9") & line(i + 1), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    i += 2
                Case "CDMAD"
                    If i = line.Count - 1 Then
                        添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.7"), Color1.红色)
                        存在错误 = True : Exit Select
                    End If
                    If line(i + 1).Replace(" ", "") = "" Or line(i + 1) = Nothing Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If My.Computer.FileSystem.DirectoryExists(当前项路径 & "\" & line(i + 1)) = False Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.9") & line(i + 1), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    i += 1
                Case "CDGRF", "CDRF-SHA", "CDGCF", "CDRF-EXT", "CDF", "CDRF"
                    If i = line.Count - 1 Or i = line.Count - 2 Then
                        添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.7"), Color1.红色)
                        存在错误 = True : Exit Select
                    End If
                    If line(i + 1).Replace(" ", "") = "" Or line(i + 1) = Nothing Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If line(i + 2).Replace(" ", "") = "" Or line(i + 2) = Nothing Then
                        添加情况分析文本(字符_行() & i + 3 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    If My.Computer.FileSystem.FileExists(当前项路径 & "\" & line(i + 1)) = False Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.10") & line(i + 1), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    i += 2
                Case "RQ-D", "RQ-D-IN", "RQ-D-UN", "RQ-F", "RQ-F-IN", "RQ-F-UN", "RQFOLDER", "RQFOLDER-IN", "RQFOLDER-UN", "RQFILE", "RQFILE-IN", "RQFILE-UN"
                    If i = line.Count - 1 Or i = line.Count - 2 Then
                        添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.7"), Color1.红色)
                        存在错误 = True : Exit Select
                    End If
                    If line(i + 1).Replace(" ", "") = "" Or line(i + 1) = Nothing Then
                        添加情况分析文本(字符_行() & i + 2 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.8"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                    i += 1
                Case "CDVD"
                    If My.Computer.FileSystem.DirectoryExists(当前项路径 & "\" & "Content") = False Then
                        添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.11"), Color1.红色)
                        i += 1 : 存在错误 = True : Exit Select
                    End If
                Case "UN-OFF", "CR-UN-OFF"
                Case "SUBD-EX-IN"
                    For x1 = i + 1 To line.Count - 1
                        If Replace(line(x1), " ", "") IsNot Nothing Then
                            If Replace(line(x1), " ", "").ToUpper = "ENDSUB" Then
                                i = x1
                                Exit For
                            End If
                        End If
                        If x1 = line.Count - 1 Then
                            添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.12"), Color1.红色)
                            存在错误 = True : Exit For
                        End If
                    Next
                Case "ENDSUB"
                    存在错误 = True : 添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.13"), Color1.红色)
                Case Else
                    存在错误 = True : 添加情况分析文本(字符_行() & i + 1 & ": " & 获取动态多语言文本("data/DynamicText/Deploy.14") & line(i), Color1.红色)
            End Select
        Next
        If 存在错误 = True Then
            当前的安装命令是否书写正确 = False
        Else
            当前的安装命令是否书写正确 = True
        End If

        Dim 存在错误2 As Boolean = False
        For i = 0 To Form1.ListView4.Items.Count - 1
            Select Case Form1.ListView4.Items.Item(i).SubItems(1).Text
                Case 获取动态多语言文本("data/DynamicText/Folder")

                    Select Case Form1.ListView4.Items.Item(i).Text
                        Case "assets"
                            If My.Computer.FileSystem.FileExists(当前项路径 & "\assets\manifest.json") = False Then
                                存在错误2 = True : 添加情况分析文本(获取动态多语言文本("data/DynamicText/Deploy.15"), Color1.橙色)
                            Else
                                Continue For
                            End If
                        Case "Content"
                            添加情况分析文本(获取动态多语言文本("data/DynamicText/Deploy.16"), Color1.黄色)
                        Case Else
                            If My.Computer.FileSystem.FileExists(当前项路径 & "\" & Form1.ListView4.Items.Item(i).Text & "\manifest.json") = True Then
                                添加情况分析文本(Form1.ListView4.Items.Item(i).Text & 获取动态多语言文本("data/DynamicText/Deploy.17"), Color1.绿色)
                            Else
                                Continue For
                            End If
                    End Select
                Case 获取动态多语言文本("data/DynamicText/File")
                    Select Case Form1.ListView4.Items.Item(i).Text
                        Case "manifest.json", "content.json", "config.json", "README", "Version", "Code", "README.rtf", "Font"
                            存在错误2 = True : 添加情况分析文本(Form1.ListView4.Items.Item(i).Text & 获取动态多语言文本("data/DynamicText/Deploy.18"), Color1.红色)
                        Case Else
                            Select Case IO.Path.GetExtension(Form1.ListView4.Items.Item(i).Text).ToLower
                                Case ".zip", ".rar", ".7z"
                                    添加情况分析文本(Form1.ListView4.Items.Item(i).Text & 获取动态多语言文本("data/DynamicText/Deploy.19"), Color1.青色)
                                    Continue For
                            End Select
                    End Select
            End Select
        Next
        If 存在错误2 = True Then
            当前的项是否添加正确 = False
        Else
            当前的项是否添加正确 = True
        End If

    End Sub




End Module
