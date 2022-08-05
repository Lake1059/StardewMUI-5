Imports SMUI.GUI.Class1

Public Class Form插件和扩展内容
    Private Sub Form插件和扩展内容_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        重置详细信息面板显示()

    End Sub

    Private Sub Form插件和扩展内容_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.ColumnHeader2.Width = 150
        Me.ColumnHeader3.Width = 200
        Me.ColumnHeader1.Width = Me.ListView1.Width - Me.ColumnHeader2.Width - Me.ColumnHeader3.Width - ST1.系统滚动条宽度 - 10
    End Sub

    Private Sub Form插件和扩展内容_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ListView1.Items.Clear()
        For i = 0 To 插件数据.插件文件列表.Count - 1
            If 插件数据.插件logo列表(i) Is Nothing Then
                Me.ImageList1.Images.Add(Me.PictureBox1.ErrorImage)
            Else
                Me.ImageList1.Images.Add(插件数据.插件logo列表(i))
            End If

            Me.ListView1.Items.Add(插件数据.插件程序集名称列表(i))
            Me.ListView1.Items.Item(i).StateImageIndex = i
            Me.ListView1.Items.Item(i).SubItems.Add(插件数据.插件版本号列表(i))
            Me.ListView1.Items.Item(i).SubItems.Add(插件数据.插件作者名称列表(i))

            If 插件数据.插件Entry加载状态(i) = False Then
                Me.ListView1.Items.Item(i).ForeColor = Color.Red
                Me.ListView1.Items.Item(i).Text &= " (Entry Error)"
            End If
        Next
    End Sub

    Sub 重置详细信息面板显示()
        Me.Label1.Text = ""
        Me.Label2.Text = ""
        Me.PictureBox1.Image = Nothing
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If Me.ListView1.SelectedItems.Count <> 1 Then
            重置详细信息面板显示()
        Else
            Me.PictureBox1.Image = 插件数据.插件logo列表(Me.ListView1.SelectedIndices(0))
            Me.Label2.Text = 插件数据.插件文件列表(Me.ListView1.SelectedIndices(0)) & " - " & 插件数据.插件处理器架构名称列表(Me.ListView1.SelectedIndices(0))
            Me.Label1.Text = 插件数据.插件简要描述列表(Me.ListView1.SelectedIndices(0))
        End If

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        e.Handled = True
    End Sub

    Private Sub ListView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListView1.KeyPress
        e.Handled = True
    End Sub
End Class