
Public Class Entry

    Public Sub Entry()
        SMUI.GUI.DeveloperMethod.RegisterPluginLogo("PluginExample", My.Resources.image1)
        SMUI.GUI.DeveloperMethod.RegisterPluginDescription("PluginExample", "For testing only, it will not affect your experience.")
        'AddHandler SMUI.GUI.DeveloperEvent.StartLoadedEvent, AddressOf 软件加载完毕事件
    End Sub

    Public Sub 软件加载完毕事件()
        Dim a As New FormMain
        a.ShowDialog()
    End Sub

End Class
