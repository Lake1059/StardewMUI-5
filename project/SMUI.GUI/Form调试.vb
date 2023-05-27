Imports SMUI.GUI.Class1

Public Class Form调试
    Private Sub Form调试_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        设置富文本框行高(Me.RichTextBox1, 300)
        Me.RichTextBox1.AutoWordSelection = False
        Me.RichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        Me.RichTextBox1.Width = Me.Width + ST1.系统滚动条宽度
    End Sub

    Private Sub Form调试_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.RichTextBox1.Width = Me.Width - ST1.系统滚动条宽度 - 3
        Me.RichTextBox1.Height = Me.Height - 50
        Me.RichTextBox1.RightMargin = Me.RichTextBox1.Width - ST1.系统滚动条宽度 - 20
    End Sub

    Private Sub Form调试_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = 46 Then Me.RichTextBox1.Text = "Press Delete key to clear all text."
    End Sub
End Class