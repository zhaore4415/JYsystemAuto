<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InnerUserInfo.ascx.cs" Inherits="NH.Web.Controls.InnerUserInfo" %>
<%if(!NH.Web.UserBase.IsLogin){%>
<div class="locationright">
<a class="a1 btn2 showprotocol" href="#"><span>注册</span></a><a class="a2 btn2" href="<%=NH.Web.Urls.UserLogin(Request.RawUrl) %>"><span>登录</span></a>
</div>
<%} %>
