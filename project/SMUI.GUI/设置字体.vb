Imports SMUI.GUI.Class1

Module 设置字体

    Public Sub 设置字体_默认()
        Dim x As String = 检查并返回当前可用子库路径()
        If x = "" Then Exit Sub
        If ST1.打开了分类的菜单还是项的菜单 = 1 Then
            For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Font"
                If My.Computer.FileSystem.FileExists(a) = True Then
                    My.Computer.FileSystem.DeleteFile(a)
                End If
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Regular)
            Next
        ElseIf ST1.打开了分类的菜单还是项的菜单 = 2 Then
            For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                Dim a As String = x & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text & "\Font"
                If My.Computer.FileSystem.FileExists(a) = True Then
                    My.Computer.FileSystem.DeleteFile(a)
                End If
                Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Regular)
            Next
        End If

    End Sub

    Public Sub 设置字体_粗体()
        Dim x As String = 检查并返回当前可用子库路径()
        If x = "" Then Exit Sub
        If ST1.打开了分类的菜单还是项的菜单 = 1 Then
            For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "BD", False)
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Bold)
            Next
        ElseIf ST1.打开了分类的菜单还是项的菜单 = 2 Then
            For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                Dim a As String = x & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "BD", False)
                Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Bold)
            Next
        End If

    End Sub

    Public Sub 设置字体_斜体()
        Dim x As String = 检查并返回当前可用子库路径()
        If x = "" Then Exit Sub
        If ST1.打开了分类的菜单还是项的菜单 = 1 Then
            For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "LC", False)
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Italic)
            Next
        ElseIf ST1.打开了分类的菜单还是项的菜单 = 2 Then
            For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                Dim a As String = x & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "LC", False)
                Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Italic)
            Next
        End If

    End Sub

    Public Sub 设置字体_下划线()
        Dim x As String = 检查并返回当前可用子库路径()
        If x = "" Then Exit Sub
        If ST1.打开了分类的菜单还是项的菜单 = 1 Then
            For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "UL", False)
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Underline)
            Next
        ElseIf ST1.打开了分类的菜单还是项的菜单 = 2 Then
            For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                Dim a As String = x & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "UL", False)
                Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Underline)
            Next
        End If
    End Sub

    Public Sub 设置字体_删除线()
        Dim x As String = 检查并返回当前可用子库路径()
        If x = "" Then Exit Sub
        If ST1.打开了分类的菜单还是项的菜单 = 1 Then
            For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                Dim a As String = x & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "SO", False)
                Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Strikeout)
            Next
        ElseIf ST1.打开了分类的菜单还是项的菜单 = 2 Then
            For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                Dim a As String = x & "\" & 当前项列表中项的分类集合(Form1.ListView2.SelectedIndices(i)) & "\" & Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Text & "\Font"
                My.Computer.FileSystem.WriteAllText(a, "SO", False)
                Form1.ListView2.Items.Item(Form1.ListView2.SelectedIndices(i)).Font = New Font(My.Settings.普通字体.Name, 9, FontStyle.Strikeout)
            Next
        End If

    End Sub
End Module
