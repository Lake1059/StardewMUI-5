Imports SMUI.GUI.Class1

Public Class Form插件和扩展内容
    Private Sub Form插件和扩展内容_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form插件和扩展内容_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Controls.Clear()
        For i = 0 To 插件数据.插件文件列表.Count - 1
            Dim p1 As New Panel With {.Dock = DockStyle.Top, .Height = 120}
            Dim img1 As New PictureBox With {.SizeMode = PictureBoxSizeMode.CenterImage, .Width = 100, .Height = 100, .Left = 10, .Top = 10, .BorderStyle = BorderStyle.FixedSingle, .Image = 插件数据.插件logo列表(i)}
            Dim L1 As New Label With {.Top = 8, .Left = 118, .AutoSize = True, .Font = New Font("Yu Gothic UI", 15, FontStyle.Bold), .ForeColor = Color1.橙色, .Text = 插件数据.插件程序集名称列表(i)}
            Dim L2 As New Label With {.Top = 40, .Left = 120, .AutoSize = True, .Font = New Font("Yu Gothic UI", 10.5, FontStyle.Bold), .ForeColor = Color1.白色, .Text = "Ver: " & 插件数据.插件版本号列表(i) & "   CPU: " & 插件数据.插件处理器架构名称列表(i).ToUpper & "   Author: " & 插件数据.插件作者名称列表(i) & vbNewLine & "File: " & 插件数据.插件文件列表(i)}
            Dim L3 As New Label With {.Top = 93, .Left = 120, .AutoSize = True, .Font = New Font("等线", 10.5, FontStyle.Bold), .ForeColor = Color1.白色, .Text = 插件数据.插件简要描述列表(i)}
            p1.Controls.Add(img1)
            p1.Controls.Add(L1)
            p1.Controls.Add(L2)
            p1.Controls.Add(L3)
            Me.Controls.Add(p1)
            p1.BringToFront()
        Next





    End Sub
End Class