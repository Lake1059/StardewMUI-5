Imports SMUI.GUI.Class1

Public Class Form全局检查模组安装情况
    Private Sub Form全局检查模组安装情况_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form全局检查模组安装情况_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        Dim m1 As New SMUI.Windows.Core.ModsGlobalCheck With {
            .SetRealTimeOutputType = Windows.Core.ModsGlobalCheck.RealTimeOutputType.Line
        }
        Dim e1 As String = m1.StartCheck(xml_Settings.SelectSingleNode("data/StardewValleyGamePath").InnerText, Me.Label1.Text, ST1.当前SMAPI版本号, "\")
        If e1 <> "" Then
            MsgBox(e1, MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.ListView1.Items.Clear()

        Me.ListView1.Items.Add(获取动态多语言文本(“data/GlobalModsInstallationCheckWindow/L1”))
        Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(0)
        Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
        Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
        Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")

        Me.ListView1.Items.Item(0).SubItems(1).Text = m1.Data_UniqueID.Count

        For i = 0 To m1.Data_NoContentPackMods.Count - 1
            Me.ListView1.Items.Add(m1.Data_NoContentPackMods(i).UniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(1)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_NoContentPackMods(i).TargetUniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
        Next

        For i = 0 To m1.Data_NoDependencyMods.Count - 1
            Me.ListView1.Items.Add(m1.Data_NoDependencyMods(i).UniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(2)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_NoDependencyMods(i).TargetUniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
        Next

        For i = 0 To m1.Data_DependencyVersionLowMods.Count - 1
            Me.ListView1.Items.Add(m1.Data_DependencyVersionLowMods(i).UniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(4)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_DependencyVersionLowMods(i).TargetUniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_DependencyVersionLowMods(i).MinimumVersion)
        Next

        For i = 0 To m1.Data_NeedUpdateSmapiMods.Count - 1
            Me.ListView1.Items.Add(m1.Data_NeedUpdateSmapiMods(i).UniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(5)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_NeedUpdateSmapiMods(i).Name)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_NeedUpdateSmapiMods(i).MinimumApiVersion)
        Next

        For i = 0 To m1.Data_MultiLevelFolderMods.Count - 1
            Me.ListView1.Items.Add(m1.Data_MultiLevelFolderMods(i).UniqueID)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(6)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_MultiLevelFolderMods(i).Name)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_MultiLevelFolderMods(i).Path)
        Next

        For i = 0 To m1.Data_NoUniqueIDMods.Count - 1
            Me.ListView1.Items.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).Group = Me.ListView1.Groups(7)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("")
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(m1.Data_NoUniqueIDMods(i))
        Next


    End Sub
End Class