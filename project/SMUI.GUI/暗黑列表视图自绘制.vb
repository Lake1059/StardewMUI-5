Imports SMUI.GUI.Class1

Public Class 暗黑列表视图自绘制

    Public Shared Sub 绑定绘制项事件(哪个列表视图控件 As ListView, e As DrawListViewItemEventArgs)
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), ColorTranslator.FromWin32(RGB(75, 75, 75)), 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, 文本绘制区, 哪个列表视图控件.Items(e.ItemIndex).ForeColor, 项背景色, TextFormatFlags.Default)
    End Sub


    Public Shared Sub 绑定绘制项事件(哪个列表视图控件 As ListView, e As DrawListViewSubItemEventArgs)
        e.DrawDefault = False
        If Not e.Bounds.IntersectsWith(哪个列表视图控件.ClientRectangle) Then Exit Sub
        Dim 项背景色 As Color = If(哪个列表视图控件.SelectedIndices.Contains(e.ItemIndex), ColorTranslator.FromWin32(RGB(75, 75, 75)), 哪个列表视图控件.BackColor)
        e.Graphics.FillRectangle(New SolidBrush(项背景色), e.Bounds)
        Dim 文本高度修正 As Integer = (e.Bounds.Height - TextRenderer.MeasureText(e.Item.Text, e.Item.Font).Height) \ 2
        Dim 文本绘制区 As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 文本高度修正, e.Bounds.Width - 5, e.Bounds.Height)
        TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, 文本绘制区, 哪个列表视图控件.Items(e.ItemIndex).ForeColor, 项背景色, TextFormatFlags.Default)
    End Sub

End Class
