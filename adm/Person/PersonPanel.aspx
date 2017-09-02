<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonPanel.aspx.cs" Inherits="NH.Web.adm.Person.PersonPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript%>
    <%=EasyUI_CssAndScript %>
    <%--<script type="text/javascript">
        var _test = null;
        function SelectTab(title, index) {
            var tab = $('#tt').tabs('getSelected');
            _test = tab;
            alert('|' + _test[0].dataset.options + '|');
        }
    </script>--%>
    <script type="text/javascript">
        function onSelectTab(title, index) {
            if (index == 0) {
                var tab = $('#tt').tabs('getTab', index);
                $('#tt').tabs('update', {
                    tab: tab,
                    options: {
                        content: '<iframe frameborder="0" src="PersonModify.aspx?id=<%=Id %>" style="width: 100%; height: 100%;"></iframe>'
                    }
                });
            }
        }
    </script>
    <style type="text/css">
        .dialog-button{ text-align:center;}
    </style>
</head>
<body>
    <div id="tt" class="easyui-tabs" fit="true" data-options="onSelect:onSelectTab">
        <div style="padding: 10px;" cache="false" title="简历信息"><%--<iframe frameborder="0" src="PersonModify.aspx?id=<%=Id %>" style="width: 100%; height: 100%;"></iframe>--%></div>
        <div style="padding: 10px;" cache="false" title="形象照片" href="PersonFace.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="个人相册" href="PersonAlbum.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="个人作品" href="PersonWorks.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="实名认证" <%=Request.QueryString["selected"]=="PersonIdentityVerify" ? "selected=\"true\"" : "" %> href="PersonIdentityVerify.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="收藏夹" href="PersonFavorites.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="应聘信息" href="PersonJobApply.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="置顶" href="PersonRefresh.aspx?id=<%=Id %>"></div>
    </div>
</body>
</html>
