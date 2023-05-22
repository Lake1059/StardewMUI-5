Imports SMUI.GUI.Class1

Public Class Form隐私选项
    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        If Me.RadioButton1.Checked = True Then
            xml_Settings.SelectSingleNode("data/PrivacyChoice").InnerText = "1"
            Me.Close()
        ElseIf Me.RadioButton2.Checked = True Then
            xml_Settings.SelectSingleNode("data/PrivacyChoice").InnerText = "2"
            Me.Close()
        ElseIf Me.RadioButton3.Checked = True Then
            xml_Settings.SelectSingleNode("data/PrivacyChoice").InnerText = "3"
            Me.Close()
        End If
    End Sub

    Private Sub Form隐私选项_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If xml_Settings.SelectSingleNode("data/InterfaceLanguage").InnerText = "English" Or ST1.是否正在使用自定义语言包 = True Then
            Me.Label1.Text = 获取动态多语言文本("data/PrivacyChoiceWindow/A1")
            Me.RadioButton1.Text = 获取动态多语言文本("data/PrivacyChoiceWindow/A2")
            Me.RadioButton2.Text = 获取动态多语言文本("data/PrivacyChoiceWindow/A3")
            Me.RadioButton3.Text = 获取动态多语言文本("data/PrivacyChoiceWindow/A4")
            Me.DarkButton1.Text = 获取动态多语言文本("data/PrivacyChoiceWindow/A5")
        End If
        Me.Icon = Form1.Icon


    End Sub


    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        点击选项时执行()
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        点击选项时执行()
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        点击选项时执行()
    End Sub

    Sub 点击选项时执行()
        Me.DarkButton1.Enabled = True

    End Sub
End Class