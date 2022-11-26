Imports System.Reflection
Imports Microsoft.WindowsAPICodePack.Shell
Imports SMUI.GUI.Class1

Module 插件管理程序

    Public Class DLC解锁状态
        Public Shared 插件1 As Boolean = False
        Public Shared 插件2 As Boolean = False
        Public Shared 插件3 As Boolean = False
        Public Shared 插件4 As Boolean = False
    End Class

    Public Class 插件数据
        Public Shared 插件文件列表 As String() = {}
        Public Shared 插件程序集名称列表 As String() = {}
        Public Shared 插件处理器架构名称列表 As String() = {}
        Public Shared 插件作者名称列表 As String() = {}
        Public Shared 插件版本号列表 As String() = {}
        Public Shared 插件logo列表 As Image() = {}
        Public Shared 插件简要描述列表 As String() = {}
        Public Shared 插件Entry加载状态 As Boolean() = {}
    End Class

    Public Sub 加载插件(插件路径 As String)

        Dim 程序集 As Assembly = Assembly.LoadFile(插件路径)
        Dim 系统接口程序 As ShellFile = ShellFile.FromFilePath(插件路径)

        Dim 这是DLC As Boolean = False

        Select Case 程序集.GetName.Name
            Case "Lake1059.Plugin1.UnlockFreeInputID"
                DLC解锁状态.插件1 = True
                这是DLC = True
                GoTo DLC_Unlock
            Case "Lake1059.Plugin2.CustomSkinLoader"
                DLC解锁状态.插件2 = True
                这是DLC = True
                GoTo DLC_Unlock
            Case "Lake1059.Plugin3.UnlockAutoDownloadAndAutoDeployNewItem"
                DLC解锁状态.插件3 = True
                这是DLC = True
                GoTo DLC_Unlock
            Case "Lake1059.Plugin4.FoundItemsInSmapiReturnResults"
                DLC解锁状态.插件4 = True
                这是DLC = True
                GoTo DLC_Unlock
        End Select


        ReDim Preserve 插件数据.插件文件列表(插件数据.插件文件列表.Count)
        插件数据.插件文件列表(插件数据.插件文件列表.Count - 1) = IO.Path.GetFileName(插件路径)

        ReDim Preserve 插件数据.插件程序集名称列表(插件数据.插件程序集名称列表.Count)
        插件数据.插件程序集名称列表(插件数据.插件程序集名称列表.Count - 1) = 程序集.GetName.Name

        ReDim Preserve 插件数据.插件处理器架构名称列表(插件数据.插件处理器架构名称列表.Count)
        插件数据.插件处理器架构名称列表(插件数据.插件处理器架构名称列表.Count - 1) = 程序集.GetName.ProcessorArchitecture.ToString

        ReDim Preserve 插件数据.插件作者名称列表(插件数据.插件作者名称列表.Count)
        插件数据.插件作者名称列表(插件数据.插件作者名称列表.Count - 1) = 系统接口程序.Properties.System.Company.Value

        ReDim Preserve 插件数据.插件版本号列表(插件数据.插件版本号列表.Count)
        插件数据.插件版本号列表(插件数据.插件版本号列表.Count - 1) = 系统接口程序.Properties.System.FileVersion.Value

        ReDim Preserve 插件数据.插件logo列表(插件数据.插件logo列表.Count)
        插件数据.插件logo列表(插件数据.插件logo列表.Count - 1) = Nothing

        ReDim Preserve 插件数据.插件简要描述列表(插件数据.插件简要描述列表.Count)
        插件数据.插件简要描述列表(插件数据.插件简要描述列表.Count - 1) = ""

DLC_Unlock:
        Try
            Dim 获取类型 As Type = 程序集.GetType(程序集.GetName.Name & ".Entry")
            Dim 创建实例 As Object = Activator.CreateInstance(获取类型)
            Dim 实现方法 As MethodInfo = 获取类型.GetMethod("Entry")
            实现方法.Invoke(创建实例, New Object() {})

            If 这是DLC = False Then
                ReDim Preserve 插件数据.插件Entry加载状态(插件数据.插件Entry加载状态.Count)
                插件数据.插件Entry加载状态(插件数据.插件Entry加载状态.Count - 1) = True
            End If
        Catch ex As Exception
            添加调试文本("[" & ex.Source & "] " & ex.Message & ": " & ex.TargetSite.Name, Color1.红色)
            If 这是DLC = False Then
                ReDim Preserve 插件数据.插件Entry加载状态(插件数据.插件Entry加载状态.Count)
                插件数据.插件Entry加载状态(插件数据.插件Entry加载状态.Count - 1) = False
            End If
            If Form调试.Visible = True Then
                Form调试.Focus()
            Else
                显示窗体(Form调试, Form1)
            End If
        End Try

    End Sub

    ''' <summary>
    ''' 不准再次调用，否则去世
    ''' </summary>
    Public Sub 扫描插件并加载()
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\PluginExample.dll") = True Then
            加载插件(Application.StartupPath & "\PluginExample.dll")
        End If
        Dim mFileInfo As System.IO.FileInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(Path1.应用程序插件数据路径)
        For Each mFileInfo In mDirInfo.GetFiles("*.*")
            If InStrRev(mFileInfo.Name, ".smui.dll") > 0 Then
                加载插件(mFileInfo.FullName)
            End If
        Next

    End Sub

    Public Sub 加载自定义语言文件()
        If My.Computer.FileSystem.FileExists(Path1.应用程序用户数据路径 & "\CustomLanguage.xml") = True Then
            xml_lang.Load(Path1.应用程序用户数据路径 & "\CustomLanguage.xml")
            加载界面的多语言()
            ST1.是否正在使用自定义语言包 = True
        End If
    End Sub


End Module
