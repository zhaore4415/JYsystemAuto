<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="NH.Web.adm.t" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="Style/Style.css" rel="stylesheet" type="text/css" />
    <link href="Script/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <script src="Script/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Script/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var objTab = null;
        function addTab(title, url) {
            if (objTab.tabs('exists', title)) {
                objTab.tabs('select', title);
            } else {
                if (objTab.tabs('tabs').length > 11) {
                    alert('请勿同时打开太多页面!'); return;
                }
                //var content = '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
                objTab.tabs('add', {
                    title: title,
                    content: createFrame(url),
                    closable: true
                });
            }
        }
        function showContext(e, title) {
            $('#tabContextMenu').menu('show', {
                left: e.pageX - 2,
                top: e.pageY - 2
            }).data('title', title)
            e.preventDefault();
        }
        function closeCurrent() {
            var title = $('#tabContextMenu').data('title');
            objTab.tabs('close', title);
        }
        function closeOther() {
            var title = $('#tabContextMenu').data('title');
            var tabs = objTab.tabs('tabs');
            for (var i = 0; i < tabs.length; i++) {
                var t = tabs[i].panel('options').title;
                if (t != title) {
                    objTab.tabs('close', t);
                    i--;
                }
            }
        }

        function createFrame(url) {
            var s = '<iframe frameborder="0" src="' + url + '" style="width:100%;height:100%;"></iframe>';
            return s;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            objTab = $('#tt');
            $('#menu a').click(function () {
                var obj = $(this)
                addTab(obj.text(), obj.attr('href'));
                return false;
            });

            $('#tt').tabs({
                fit: true,
                border: false,
                plain: true,
                onContextMenu: showContext
            }).tabs('add', {
                title: '首页',
                content: 'welcome',
                closable: false
            })
        })
    </script>
</head>
<body class="easyui-layout" style="text-align: left">
    <div region="north" border="false" style="background: #d2e0f2;">
        <div id="header-inner">
            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                <tr>
                    <td rowspan="2" style="width: 20px;">
                    </td>
                    <td style="height: 50px; font-weight: bold; font-size: 20px; color: #15428B;">
                        后台管理    <%=NH.Web.UserBase.CurAdmin.LoginName %>
                    </td>
                    <td style="padding-right: 50px; text-align: right;">
                        <a href="/LoginOut.aspx" onclick="return confirm('确定要退出？')">退出</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div region="west" border="true" split="true" title="菜单" style="width: 200px; padding: 5px;">
        <ul id="menu" class="easyui-tree" animate="true">
            <li><span>管理员管理</span>
                <ul>
                    <li><a href="Authority/AUser/AUser.aspx">管理员帐号</a></li>
                    <li><a href="Authority/Fun/Fun.aspx">功能码管理</a></li>
                    <li><a href="Authority/Fun/FunGroup.aspx">功能码分组管理</a></li>
                    <li><a href="Authority/Role/Role.aspx">角色管理</a></li>
                    <li><a href="Authority/ChangePwd.aspx">修改密码</a></li>
                </ul>
            </li>
            <li><span>人才管理</span>
                <ul>
                    <li><a href="/MemberMg/MemberList.aspx">会员管理</a></li>
                    <li><a href="/MemberMg/SendMessage.aspx">发送消息</a></li>
                    <li><a href="/MemberMg/MessagesList.aspx">消息列表</a></li>
                </ul>
            </li>
        </ul>
    </div>
    <div region="center" border="true">
        <div id="tt"></div>
    </div>
    <div id="tabContextMenu" class="easyui-menu" style="width: 120px;">
        <div iconCls="icon-cancel" onclick="closeCurrent()">关闭</div>
        <div iconCls="icon-cancel" onclick="closeOther()">关闭其它</div>
    </div>
</body>
</html>
