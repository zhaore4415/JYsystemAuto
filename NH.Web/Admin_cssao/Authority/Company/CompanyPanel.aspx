<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyPanel.aspx.cs" Inherits="NH.Web.adm.Company.CompanyPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript%>
    <%=EasyUI_CssAndScript %>
    <style type="text/css">
        .dialog-button{ text-align:center;}
    </style>
    <script type="text/javascript">
//        var _t = null;
        function onSelectTab(title, index) {
            var url;
            switch (index) {
                case 1:
                    url = 'CompanyModify.aspx?id=<%=Id %>';
                    break;
                case 2:
                    url = 'CompanyLogo.aspx?id=<%=Id %>';
                    break;
            }
            if (url) {
                var tab = $('#tt').tabs('getTab', index);
                $('#tt').tabs('update', {
                    tab: tab,
                    options: {
                        content: '<iframe frameborder="0" src="' + url + '" style="width: 100%; height: 100%;"></iframe>'
                    }
                });
            }
            //_t = $('#tt').tabs('getTab', index).panel('options').tab; //li.tabs-selected
//            _t = $('#tt').tabs('getTab', index).panel('options')
        }
    </script>
</head>
<body>
    <div id="tt" class="easyui-tabs" fit="true" data-options="onSelect:onSelectTab">
        <!--<div style="padding: 10px;" cache="false" title="企业信息"><%--<iframe frameborder="0" src="PersonModify.aspx?id=<%=Id %>" style="width: 100%; height: 100%;"></iframe>--%></div>-->
        <%--<div style="padding: 10px;" cache="false" title="会员级别" href="CompanyLevelInfo.aspx?id=<%=Id %>"></div>--%>
        <%--<div style="padding: 10px;" cache="false" title="形象照片" <%=Request.QueryString["selected"]=="CompanyFace" ? "selected=\"true\"" : "" %> href="CompanyFace.aspx?id=<%=Id %>"></div>--%>
        <%--<div style="padding: 10px;" cache="false" title="企业相册" href="CompanyAlbum.aspx?id=<%=Id %>"></div>--%>
        <div style="padding: 10px;" cache="false" title="企业认证" <%=Request.QueryString["selected"]=="CompanyIdentityVerify" ? "selected=\"true\"" : "" %> href="CompanyIdentityVerify.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="企业信息"><%--<iframe frameborder="0" src="CompanyModify.aspx?id=<%=Id %>" style="width: 100%; height: 100%;"></iframe>--%></div>
        <div style="padding: 10px;" cache="false" title="企业LOGO"><%--<iframe frameborder="0" src="CompanyLogo.aspx?id=<%=Id %>" style="width: 100%; height: 100%;"></iframe>--%></div>
        <div style="padding: 10px;" cache="false" title="招聘信息" href="CompanyJobs.aspx?id=<%=Id %>"></div>
        <%--<div style="padding: 10px;" cache="false" title="浏览过的简历" href="CompanyViewHistory.aspx?id=<%=Id %>"></div>--%>
        <div style="padding: 10px;" cache="false" title="收到的简历" href="CompanyJobApply.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="接站管理" href="CompanyReceive.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="收到的报名" href="CompanyJobSignUp.aspx?id=<%=Id %>"></div>
        <div style="padding: 10px;" cache="false" title="负责人" href="Company2Service.aspx?id=<%=Id %>"></div>
        <%--<div style="padding: 10px;" cache="false" title="面试邀请" href="CompanyInterview.aspx?id=<%=Id %>"></div>--%>
        <%--<div style="padding: 10px;" cache="false" title="收藏夹" href="CompanyFavorite.aspx?id=<%=Id %>"></div>--%>
        <%--<div style="padding: 10px;" cache="false" title="推荐位置" href="CompanyTag.aspx?id=<%=Id %>"></div>--%>
        <%--<div style="padding: 10px;" cache="true" title="招聘伴侣" iconCls="icon-save" class="_iframe" _href="CompanyHelpmate.aspx?id=<%=Id %>"></div>--%>
    </div>
</body>
</html>
