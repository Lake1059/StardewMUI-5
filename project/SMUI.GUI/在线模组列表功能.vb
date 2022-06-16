Module 在线模组列表功能

    Public 模组分类数组 As String() = {}

    Sub 初始化模组分类数组()
        ReDim 模组分类数组(30)
        模组分类数组(12) = "Audio"
        模组分类数组(17) = "Buildings"
        模组分类数组(5) = "Characters"
        模组分类数组(24) = "New Characters"
        模组分类数组(11) = "Cheats"
        模组分类数组(13) = "Clothing"
        模组分类数组(22) = "Crafting"
        模组分类数组(14) = "Crops"
        模组分类数组(20) = "Dialogue"
        模组分类数组(18) = "Events"
        模组分类数组(27) = "Expansions"
        模组分类数组(26) = "Fishing"
        模组分类数组(23) = "Furniture"
        模组分类数组(3) = "Gameplay Mechanics"
        模组分类数组(19) = "Interiors"
        模组分类数组(15) = "Items"
        模组分类数组(7) = "Livestock and Animals"
        模组分类数组(16) = "Locations"
        模组分类数组(21) = "Maps"
        模组分类数组(2) = "Miscellaneous"
        模组分类数组(9) = "Modding Tools"
        模组分类数组(8) = "Pets / Horses"
        模组分类数组(4) = "Player"
        模组分类数组(6) = "Portraits"
        模组分类数组(10) = "User Interface"
        模组分类数组(25) = "Visuals and Graphics"
        For i = 0 To 模组分类数组.Count - 1
            If 模组分类数组(i) = "" Then 模组分类数组(i) = "Unknow"
        Next
    End Sub

    Sub 获取模组列表并显示(基于面板 As Panel, 类型 As SMUI.Windows.Nexus.NexusModsApiObject.ListModType)
        基于面板.Controls.Clear()
        GC.Collect()
        基于面板.Visible = False
        Dim a As New SMUI.Windows.Nexus.GetModList With {
            .ST_ApiKey = xml_Settings.SelectSingleNode("data/NEXUSMODSPersonalAPIKey").InnerText
        }
        If a.StartGet("stardewvalley", 类型) <> "" Then
            MsgBox(a.ErrorString, MsgBoxStyle.Critical)
            Exit Sub
        End If

        'Me.Label8.Text = a.当前小时剩余可请求次数 & "/" & a.当前小时可请求次数总量 & "   " & a.今日剩余可请求次数 & "/" & a.今日可请求次数总量 & "   "
        For i = 0 To a.name.Count - 1
            Dim 独立容器 As New Panel With {.Dock = DockStyle.Top, .Padding = New Padding(10), .Height = 126 + 20}

            Dim 图片框 As New PictureBox With {.ImageLocation = a.picture_url(i), .SizeMode = PictureBoxSizeMode.Zoom, .Width = 224 - 1, .Dock = DockStyle.Left, .BorderStyle = BorderStyle.FixedSingle}
            Dim 标题文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 30, .Font = New Font("等线", 14, FontStyle.Bold), .LinkColor = ColorTranslator.FromWin32(RGB(225, 225, 225)), .LinkBehavior = LinkBehavior.HoverUnderline, .TabStop = False}
            Dim 作者文字 As New LinkLabel With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 25, .Font = New Font("等线", 12, FontStyle.Bold), .TextAlign = ContentAlignment.TopLeft, .LinkColor = Color.Silver, .LinkBehavior = LinkBehavior.HoverUnderline, .TabStop = False}
            Dim 状态文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 30, .TextAlign = ContentAlignment.BottomLeft, .Font = New Font("Yu Gothic", 11.25, FontStyle.Bold), .ForeColor = ColorTranslator.FromWin32(RGB(218, 142, 53))}
            Dim 简介文字 As New Label With {.AutoSize = False, .Dock = DockStyle.Fill, .Font = New Font("Microsoft YaHei UI", 10), .TextAlign = ContentAlignment.BottomLeft, .ForeColor = Color.Gray, .AutoEllipsis = True}

            Select Case a.status(i)
                Case "not_published"
                    标题文字.Text = 获取动态多语言文本("data/DynamicText/not_published")
                Case "removed"
                    标题文字.Text = 获取动态多语言文本("data/DynamicText/removed")
                Case "hidden"
                    标题文字.Text = 获取动态多语言文本("data/DynamicText/hidden")
                Case "published"
                    标题文字.Text = a.name(i)
                Case Else
                    标题文字.Text = a.status(i)
            End Select
            作者文字.Text = a.author(i) & " (" & a.uploaded_by(i) & ")"
            状态文字.Text = "Ver " & a.version(i) & " | " & a.updated_time(i) & " | ID " & a.mod_id(i) & " | E " & a.endorsement_count(i)
            If a.category_id(i) <> 0 Then 状态文字.Text &= " | " & 模组分类数组(a.category_id(i))
            简介文字.Text = a.summary(i).Replace("<br />", vbNewLine)

            Dim 分隔间距 As New Label With {.AutoSize = False, .Dock = DockStyle.Left, .Width = 5}
            独立容器.Controls.Add(图片框)
            独立容器.Controls.Add(分隔间距)
            独立容器.Controls.Add(标题文字)
            独立容器.Controls.Add(作者文字)
            独立容器.Controls.Add(状态文字)
            独立容器.Controls.Add(简介文字)

            Dim str1 As String = "https://www.nexusmods.com/stardewvalley/mods/" & a.mod_id(i)
            AddHandler 标题文字.LinkClicked,
                Sub(s1, e1)
                    Process.Start(str1)
                End Sub
            Dim str2 As String = a.uploaded_users_profile_url(i)
            AddHandler 作者文字.LinkClicked,
                Sub(s1, e1)
                    Process.Start(str2)
                End Sub

            分隔间距.SendToBack()
            图片框.SendToBack()
            作者文字.BringToFront()
            状态文字.BringToFront()
            简介文字.BringToFront()
            基于面板.Controls.Add(独立容器)
            独立容器.BringToFront()
        Next
        Dim c1 As New Label With {.AutoSize = False, .Dock = DockStyle.Top, .Height = 5}
        基于面板.Controls.Add(c1)
        c1.BringToFront()
        基于面板.Visible = True
    End Sub



End Module
