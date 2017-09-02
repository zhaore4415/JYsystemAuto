<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Head.ascx.cs" Inherits="NH.Web.Controls.Head" %>
<%--<div class="topbox">
    <img src="/images/fenxiaoguanlixitong.png">
    <div class="nav">
        <a href="/Member/Queryorder.aspx">首页</a> <a href="/Default.aspx" class="gerenzhongxin"><%=NH.Web.UserBase.CurAdmin.LoginName%> 个人中心</a>
        <a href="<%=NH.Web.Urls.LogOut("adm") %>">退出</a>
    </div>
</div>--%>
<div class="top">
        <img src="/images/fenxiao.png">
        <div>
            <a class="a-3" href="<%=NH.Web.Urls.LogOut("adm") %>">退出</a> <a class="a-2" href="/Default.aspx">
                <%=NH.Web.UserBase.CurAdmin.LoginName%> 个人中心</a> <a href="/Member/Queryorder.aspx">首页</a>
        </div>
    </div>