﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRedirect.aspx.cs" Inherits="NH.Web.adm.template.LoginRedirect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript">        window.top.location.href = '<%=NH.Web.AUrls.AdminLogin(null)%>'</script>
    <div style=" text-align:center; height:200px;">请登录...</div>
</body>
</html>