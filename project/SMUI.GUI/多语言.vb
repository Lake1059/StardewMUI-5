Imports SMUI.GUI.Class1

Module 多语言

    Public Sub 加载界面的多语言()
        Form1.Label起始页面.Text = xml_lang.SelectSingleNode("data/MainWindow/TitlePanel.1").InnerText
        Form1.Label管理模组.Text = xml_lang.SelectSingleNode("data/MainWindow/TitlePanel.2").InnerText
        Form1.Label配置队列.Text = xml_lang.SelectSingleNode("data/MainWindow/TitlePanel.3").InnerText
        Form1.Label起始页面.Width = xml_lang.SelectSingleNode("data/MainWindow/TitleMainPanelButtonEachWidth").InnerText
        Form1.Label管理模组.Width = xml_lang.SelectSingleNode("data/MainWindow/TitleMainPanelButtonEachWidth").InnerText
        Form1.Label配置队列.Width = xml_lang.SelectSingleNode("data/MainWindow/TitleMainPanelButtonEachWidth").InnerText
        Form1.Panel主选项卡.Width = xml_lang.SelectSingleNode("data/MainWindow/TitleMainPanelButtonEachWidth").InnerText * 3 + 2
        Form1.Label主动态标记.Width = Form1.Panel主选项卡.Width
        Form1.Label内容中心.Text = xml_lang.SelectSingleNode("data/MainWindow/TitlePanel.4").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label设置选项.Text = xml_lang.SelectSingleNode("data/MainWindow/TitlePanel.5").InnerText.Replace("/crlf/", vbNewLine)

        Form1.Label检查模组安装情况.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.1").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label传统管理方式.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.2").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label存档编辑器.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.3").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label模组更新检查器.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.4").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label插件和扩展内容.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.5").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label新闻公告.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.6").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label模组列表.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.7").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label下载模组.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.8").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label主题内容.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.9").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label创作者自由面板.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.10").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label参与翻译SMUI.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.11").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label立即检查更新.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.12").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label关于和许可协议.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.13").InnerText.Replace("/crlf/", vbNewLine)
        Form1.Label查看更新历史.Text = xml_lang.SelectSingleNode("data/MainWindow/StartPanel.14").InnerText.Replace("/crlf/", vbNewLine)

        Form1.右键再次调出此菜单ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ModListMenu.1").InnerText
        Form1.清除内容ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ModListMenu.2").InnerText
        Form1.最新的10个模组ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ModListMenu.3").InnerText
        Form1.最近更新的10个模组ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ModListMenu.4").InnerText
        Form1.有史以来最热门的10个模组ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ModListMenu.5").InnerText

        Form1.产品简体中文维基ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.1").InnerText
        Form1.产品GitHub仓库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.2").InnerText
        Form1.链接汇总ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.3").InnerText
        Form1.应用程序目录集ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.4").InnerText
        Form1.星露谷目录集ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.5").InnerText
        Form1.星露谷Steam商店页面ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.6").InnerText
        Form1.SMAPI官网ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.7").InnerText
        Form1.模组数据表ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.8").InnerText
        Form1.日志分析器ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.9").InnerText
        Form1.农场布局规划器ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.10").InnerText
        Form1.存档预测器ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.11").InnerText
        Form1.存档进度检查器ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.12").InnerText
        Form1.软件安装目录ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.13").InnerText
        Form1.用户配置数据文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.14").InnerText
        Form1.插件目录ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.15").InnerText
        Form1.下载更新目录ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.16").InnerText
        Form1.当前星露谷游戏目录ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.17").InnerText
        Form1.星露谷Mods文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.18").InnerText
        Form1.星露谷Content文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.19").InnerText
        Form1.星露谷存档文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.20").InnerText
        Form1.SMAPI日志文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.21").InnerText
        Form1.谷歌浏览器缓存目录ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.22").InnerText
        Form1.存储管理ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ContentCenter.23").InnerText

        Form1.Label子库分类菜单.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.1").InnerText
        Form1.刷新分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.2").InnerText
        Form1.数据子库操作ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.3").InnerText
        Form1.切换数据子库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.4").InnerText
        Form1.刷新子库列表ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.5").InnerText
        Form1.新建数据子库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.6").InnerText
        Form1.导入数据子库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.7").InnerText
        Form1.导出数据子库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.8").InnerText
        Form1.删除数据子库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.9").InnerText
        Form1.新建分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.10").InnerText
        Form1.转移分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.11").InnerText
        Form1.删除分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.12").InnerText
        Form1.导入分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.13").InnerText
        Form1.导出分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.14").InnerText
        Form1.清除Config缓存ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ClearConfigCache").InnerText
        Form1.打开选择分类的文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.15").InnerText
        Form1.重命名分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.16").InnerText
        Form1.设置颜色ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.17").InnerText
        Form1.设置字体ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.18").InnerText
        Form1.查看选中分类的属性ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.19").InnerText
        Form1.激活拖拽ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.20").InnerText

        Form1.标准字体ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/FontMenu.1").InnerText
        Form1.粗体ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/FontMenu.2").InnerText
        Form1.斜体ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/FontMenu.3").InnerText
        Form1.下划线ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/FontMenu.4").InnerText
        Form1.删除线ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/FontMenu.5").InnerText

        Form1.Label项菜单.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.21").InnerText
        Form1.Label项菜单.Width = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.21").Attributes.GetNamedItem("width").InnerText
        Form1.新建项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.25").InnerText
        Form1.下载并新建项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.25_1").InnerText
        Form1.移动项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.26").InnerText
        Form1.删除项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.27").InnerText
        Form1.导入项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.28").InnerText
        Form1.导出项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.29").InnerText
        Form1.批量创建ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.30").InnerText
        Form1.本地更新ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.31").InnerText
        Form1.从Mods中覆盖到仓库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.32").InnerText
        Form1.从Mods中替换到仓库ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.33").InnerText
        Form1.设置字体ToolStripMenuItem1.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.18").InnerText
        Form1.切换显示所属分类ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.34").InnerText

        Form1.Label刷新.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.22").InnerText
        Form1.Label刷新.Width = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.22").Attributes.GetNamedItem("width").InnerText
        Form1.Label搜索.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.23").InnerText
        Form1.Label搜索.Width = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.23").Attributes.GetNamedItem("width").InnerText
        Form1.Label筛选.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.24").InnerText
        Form1.Label筛选.Width = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.24").Attributes.GetNamedItem("width").InnerText
        Form1.Label调试.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.47").InnerText
        Form1.Label调试.Width = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.47").Attributes.GetNamedItem("width").InnerText

        Form1.全选ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.36").InnerText
        Form1.反选ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.37").InnerText
        Form1.选择当前列表已安装ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.38").InnerText
        Form1.选择当前列表未安装ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.39").InnerText
        Form1.选择当前列表本地更新可用ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.40").InnerText
        Form1.选择当前列表已有新的ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.41").InnerText
        Form1.选择当前列表在线更新可用ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.42").InnerText
        Form1.扫描当前子库已安装ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.43").InnerText
        Form1.扫描当前子库未安装ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.44").InnerText
        Form1.扫描当前子库文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.45").InnerText
        Form1.扫描当前子库文件ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.46").InnerText

        Form1.安装ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.65").InnerText
        Form1.卸载ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.66").InnerText
        Form1.配置部署ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.67").InnerText
        Form1.打开选中项的文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.68").InnerText
        Form1.编辑器ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.69").InnerText
        Form1.重命名项ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.70").InnerText
        Form1.用VisualStudioCode打开ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.71").InnerText
        Form1.用VisualStudio打开ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.72").InnerText
        Form1.用Notepad打开ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.73").InnerText
        Form1.可视化清单编辑器ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.74").InnerText
        Form1.简单编辑ConfigToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.75").InnerText
        Form1.清除Config缓存ToolStripMenuItem1.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.76").InnerText
        Form1.属性ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.77").InnerText
        Form1.激活拖拽ToolStripMenuItem1.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.78").InnerText

        Form1.Label描述菜单.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.48").InnerText
        Form1.新建RTF文档ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.49").InnerText
        Form1.在写字板中编辑RTFToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.50").InnerText
        Form1.保存到TXT纯文本ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.51").InnerText
        Form1.保存到RTF富文本ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.52").InnerText
        Form1.切换滚动条显示ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.53").InnerText
        Form1.设置选中内容的字体ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.54").InnerText
        Form1.设置选中内容的颜色ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.55").InnerText
        Form1.清除选择内容的格式ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.56").InnerText

        Form1.Label37.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.57").InnerText
        Form1.Label40.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.58").InnerText

        Form1.Label预览图菜单.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.59").InnerText
        Form1.文件夹ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.60").InnerText
        Form1.复制ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.61").InnerText
        Form1.删除此图ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.62").InnerText
        Form1.删除所有图ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.63").InnerText
        Form1.缩放处理ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/ManagePanel.64").InnerText

        Form1.ToolStripLabel1.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.1").InnerText
        Form1.ToolStripLabel2.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.2").InnerText
        Form1.Label保存并从队列中移除.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.3").InnerText
        Form1.Label保存并从队列中移除.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.3").Attributes.GetNamedItem("width").InnerText
        Form1.Label仅保存.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.4").InnerText
        Form1.Label仅保存.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.4").Attributes.GetNamedItem("width").InnerText
        Form1.Label56.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.5").InnerText
        Form1.Label移除配置队列里的全部项.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.6").InnerText
        Form1.Label移除配置队列里的全部项.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.6").Attributes.GetNamedItem("width").InnerText
        Form1.Label移除配置队列中的项.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.7").InnerText
        Form1.Label移除配置队列中的项.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.7").Attributes.GetNamedItem("width").InnerText
        Form1.Label58.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.8").InnerText
        Form1.Label添加文件夹.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.9").InnerText
        Form1.Label添加文件夹.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.9").Attributes.GetNamedItem("width").InnerText
        Form1.Label添加文件.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.10").InnerText
        Form1.Label添加文件.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.10").Attributes.GetNamedItem("width").InnerText
        Form1.Label刷新项的数据内容.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.11").InnerText
        Form1.Label刷新项的数据内容.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.11").Attributes.GetNamedItem("width").InnerText
        Form1.插入名称ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.12").InnerText
        Form1.复制名称ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.13").InnerText
        Form1.重命名ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.14").InnerText
        Form1.上移ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.15").InnerText
        Form1.下移ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.16").InnerText
        Form1.提取压缩包ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.17").InnerText
        Form1.拿出内容ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.18").InnerText
        Form1.内容套层ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.19").InnerText
        Form1.删除ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.20").InnerText
        Form1.Label61.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.21").InnerText
        Form1.Label全部复制.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.22").InnerText
        Form1.Label全部复制.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.22").Attributes.GetNamedItem("width").InnerText
        Form1.Label64.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.23").InnerText
        Form1.Label自动完成.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.24").InnerText
        Form1.Label自动完成.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.24").Attributes.GetNamedItem("width").InnerText
        Form1.Label所有命令.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.25").InnerText
        Form1.Label所有命令.Width = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.25").Attributes.GetNamedItem("width").InnerText
        Form1.激活项数据内容表的拖拽ToolStripMenuItem.Text = xml_lang.SelectSingleNode("data/MainWindow/DeployPanel.26").InnerText

    End Sub

End Module
