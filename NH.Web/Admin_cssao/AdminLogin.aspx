<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminLogin.aspx.cs"
    Inherits="NH.Web.Admin_cssao.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>巴克后台管理专业版</title>
    <meta name="author" content="巴克后台管理专业版" />
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="/css/matrix-login.css" />
    <link href="/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<link href='http://fonts.useso.com/css?family=Open+Sans:400,700,800' rel='stylesheet'
        type='text/css'>--%>
    <style>
        .fenxiao
        {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 30%;
            margin-top: 20px;
        }
        .pull-right
        {
            margin-right: 20px;
        }
        .pull-left
        {
            margin-left: 20px;margin-left:200px
        }
    </style>
</head>
<body id="loginbox">
    <form id="form1" runat="server" class="form-vertical">
    <img class="fenxiao" src="/images/fenxiao.png">
    <div class="control-group">
        <div class="controls">
            <div class="main_input_box">
                <span class="add-on bg_lg"><i class="icon-user"></i></span>
                <asp:TextBox ID="txtUsername" runat="server" placeholder="账号" />
            </div>
        </div>
    </div>
    <div class="control-group">
        <div class="controls">
            <div class="main_input_box">
                <span class="add-on bg_ly"><i class="icon-lock"></i></span>
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                    placeholder="密码" />
            </div>
        </div>
    </div>
    <div class="form-actions">
        <span class="pull-left"><asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-success" Text="登录" /></span>
        <%--<span class="pull-left"><a href="Registered.aspx" class="flip-link btn btn-info" id="to-recover">
            &nbsp;&nbsp;注册&nbsp;&nbsp;</a></span>--%>
    </div>
   
    </form>
</body>
</html>
