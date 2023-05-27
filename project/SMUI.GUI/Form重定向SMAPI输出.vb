Imports System.ComponentModel
Imports System.IO
Imports SMUI.GUI.Class1

Public Class Form重定向SMAPI输出


    ReadOnly process As New Process()
    ReadOnly ConsoleRichTextBox As New RichTextBox

    Private Sub Form重定向SMAPI输出_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = Form1.Font
        ConsoleRichTextBox.AutoWordSelection = False
        ConsoleRichTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        设置富文本框行高(ConsoleRichTextBox, 300)
        Me.Controls.Add(ConsoleRichTextBox)
        ConsoleRichTextBox.BorderStyle = BorderStyle.None
        ConsoleRichTextBox.Top = 3 : ConsoleRichTextBox.Left = 0
        ConsoleRichTextBox.Width = Me.Panel1.Width : ConsoleRichTextBox.Height = Me.Panel1.Top - 6
        ConsoleRichTextBox.Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
        ConsoleRichTextBox.BackColor = ConsoleRichTextBox.Parent.BackColor
        ConsoleRichTextBox.ForeColor = SystemColors.Control
        ConsoleRichTextBox.Font = Me.Font
    End Sub

    Private Sub Form重定向SMAPI输出_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        process.StartInfo.FileName = xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText & "\StardewModdingAPI.exe"
        process.StartInfo.Arguments = Nothing
        process.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText)
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.UseShellExecute = False
        process.StartInfo.CreateNoWindow = True
        process.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        process.Start()
        Me.BackgroundWorker1.RunWorkerAsync()
        Me.BackgroundWorker2.RunWorkerAsync()
    End Sub

    Private Sub Form重定向SMAPI输出_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.ToolStripTextBox1.Width = Me.Panel1.Width - 200
    End Sub

    Private Sub Form重定向SMAPI输出_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        On Error Resume Next
        process.CloseMainWindow()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim output As StreamReader = process.StandardOutput
        While Not output.EndOfStream
            Dim line As String = process.StandardOutput.ReadLine()
            Me.BackgroundWorker1.ReportProgress(1, line & vbCrLf)
        End While
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ConsoleRichTextBox.AppendText(e.UserState)
        Dim startIndex As Integer = ConsoleRichTextBox.GetFirstCharIndexFromLine(ConsoleRichTextBox.Lines.Length - 1)
        Dim length As Integer = ConsoleRichTextBox.Lines(ConsoleRichTextBox.Lines.Length - 1).Length
        ConsoleRichTextBox.Select(startIndex, length)
        ConsoleRichTextBox.SelectionColor = Me.ConsoleRichTextBox.ForeColor
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim output As StreamReader = process.StandardError
        While Not output.EndOfStream
            Dim line As String = output.ReadLine()
            Me.BackgroundWorker2.ReportProgress(1, line & vbCrLf)
        End While
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ConsoleRichTextBox.AppendText(e.UserState)
        Dim startIndex As Integer = ConsoleRichTextBox.GetFirstCharIndexFromLine(ConsoleRichTextBox.Lines.Length - 1)
        Dim length As Integer = ConsoleRichTextBox.Lines(ConsoleRichTextBox.Lines.Length - 1).Length
        ConsoleRichTextBox.Select(startIndex, length)
        ConsoleRichTextBox.SelectionColor = Color.OrangeRed
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork

    End Sub

    Private Sub BackgroundWorker3_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

    End Sub

    Private Sub ToolStripTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox1.KeyDown
        If e.KeyCode = 13 Then
            Me.Button1.PerformClick()
            Application.DoEvents()
            Me.ToolStripTextBox1.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        process.StandardInput.WriteLine(Me.ToolStripTextBox1.Text)
        ConsoleRichTextBox.AppendText(Me.ToolStripTextBox1.Text)
        Dim startIndex As Integer = ConsoleRichTextBox.GetFirstCharIndexFromLine(ConsoleRichTextBox.Lines.Length - 1)
        Dim length As Integer = ConsoleRichTextBox.Lines(ConsoleRichTextBox.Lines.Length - 1).Length
        ConsoleRichTextBox.Select(startIndex, length)
        ConsoleRichTextBox.SelectionColor = SystemColors.Highlight
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class