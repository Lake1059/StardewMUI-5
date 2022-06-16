Imports System.Drawing
Imports System.Windows.Forms

Public Class Form输入对话框

    Public 输入的内容 As String = ""
    Public 是否点击了确定 As Boolean = False


    Private Sub Form输入对话框_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub 按钮鼠标移上事件(sender As Object, e As EventArgs) Handles Label确定.MouseEnter, Label取消.MouseEnter
        sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
    End Sub

    Public Sub 按钮鼠标移走事件(sender As Object, e As EventArgs) Handles Label确定.MouseLeave, Label取消.MouseLeave
        sender.BackColor = ColorTranslator.FromWin32(RGB(50, 50, 50))
    End Sub

    Private Sub Label确定_Click(sender As Object, e As EventArgs) Handles Label确定.Click
        输入的内容 = Me.TextBox1.Text
        是否点击了确定 = True
        Me.Close()
    End Sub

    Private Sub Label取消_Click(sender As Object, e As EventArgs) Handles Label取消.Click
        是否点击了确定 = False
        输入的内容 = ""
        Me.Close()
    End Sub

    Private Sub Form输入对话框_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If 是否点击了确定 = False Then 输入的内容 = ""
    End Sub
End Class