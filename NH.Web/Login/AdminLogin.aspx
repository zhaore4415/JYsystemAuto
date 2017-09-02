<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="NH.Web.Login.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/AdminLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
            <div id="left">
                <div id="title"><img src="/images/login_03.gif" alt="" /></div>
                <div><img src="/images/login_09.jpg" alt="" /></div>
                <div id="l_co"><span>版本信息</span><label>后台管理信息系统 2011 V1.0</label></div>
            </div>
            <div id="middle">
                <div><img src="/images/login_05.gif" alt=""/></div>
                <div id="user_login">
                       <p>账<span style=" padding-left:14px"></span>号：<asp:TextBox ID="txtUsername" runat="server"/></p> 
                       <p>密<span style=" padding-left:14px"></span>码：<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></p> 
                       <p>验证码：<asp:TextBox ID="txtCode" runat="server" /><img id="validate" src="<%=NH.Web.Urls.VCode("adm") %>" alt="验证码" title="点击刷新验证码"/></p>
                       <p id="click"><asp:Button ID="btnLogin" runat="server" Text="登 录" OnClick="btnLogin_Click" />
                          <input type="reset" value="重 置" /> </p>
                </div>
                <div id="m_t"></div>
            </div>
            <div id="right"><img src="/images/login_11.gif" alt=""/></div>
    </div>
    </form>
</body>
</html>
