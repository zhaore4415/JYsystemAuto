<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="NH.Web.adm.ChangePwd" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>巴克后台管理专业版</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            background: #2971b2 url(/images/bj_2.gif) no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:left ID="left1" runat="server" />
    <div id="right">
        <uc2:Head ID="Head1" runat="server" />
        <div class="content2">
            <div class="content2_left">
                <div class="daohang2">
                    <a href="/Default.aspx">首页</a> > <a href="ChangePwd.aspx">密码修改</a></div>
                <div class="password">
                    <div class="password_con">
                        <dl>
                            <dt>密码修改</dt>
                            <dd>
                                <p>
                                    原密码：</p>
                                <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" CssClass="password_inp"></asp:TextBox></dd>
                            <dd>
                                <p>
                                    新密码：</p>
                                <asp:TextBox runat="server" ID="txtPassword1" TextMode="Password" CssClass="password_inp"></asp:TextBox></dd>
                            <dd>
                                <p>
                                    确认新密码：</p>
                                <asp:TextBox runat="server" ID="txtPassword2" TextMode="Password" CssClass="password_inp"></asp:TextBox></dd>
                            <dd>
                                <p>
                                    &nbsp;</p>
                                <asp:Button ID="btnSubmit" runat="server" Text="" CssClass="password_but" onclick="btnSubmit_Click" /></dd>
                        </dl>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div id="Add">
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    旧密码：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    新密码：
                </th>
                <td>
                    
                    <asp:TextBox runat="server" ID="txtPassword1" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    新密码：
                </th>
                <td>
                    
                    <asp:TextBox runat="server" ID="txtPassword2" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="修改" CssClass="btnSubmit" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>--%>
    </form>
</body>
</html>
