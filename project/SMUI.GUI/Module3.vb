Imports SMUI.GUI.Class1

Module Module3

    Public FileDroper As WindowsMF.Class1.FileDropHandler


    Class SYS1
        Public Shared Sub 检查用户身份组()
            Dim current As Security.Principal.WindowsIdentity = Security.Principal.WindowsIdentity.GetCurrent()
            Dim windowsPrincipal As New Security.Principal.WindowsPrincipal(current)
            If windowsPrincipal.IsInRole(Security.Principal.WindowsBuiltInRole.Administrator) = True Then
                Form1.Text &= " [Administrator]"
                '作为焦点诱饵，反正可以随时切换
                FileDroper = New WindowsMF.Class1.FileDropHandler(Form1.ButtonF)
                ST1.当前用户身份组 = Security.Principal.WindowsBuiltInRole.Administrator
                Form1.ToolStripSeparator5.Visible = True
                Form1.激活拖拽ToolStripMenuItem.Visible = True
                Form1.激活拖拽ToolStripMenuItem1.Visible = True
                Form1.ToolStripSeparator31.Visible = True
                Form1.激活项数据内容表的拖拽ToolStripMenuItem.Visible = True
            End If
            If windowsPrincipal.IsInRole(Security.Principal.WindowsBuiltInRole.PowerUser) = True Then
                Form1.Text &= " [PowerUser]"
            End If
            If windowsPrincipal.IsInRole(Security.Principal.WindowsBuiltInRole.Guest) = True Then
                Form1.Text &= " [Guest]"
            End If
        End Sub

    End Class

End Module
