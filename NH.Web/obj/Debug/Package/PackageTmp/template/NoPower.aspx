<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoPower.aspx.cs" Inherits="NH.Web.adm.template.NoPower" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style=" color:Red; padding:50px; text-align:center; font-weight:bold; font-size:12px; margin:auto; width:300px; border:1px solid red;">抱歉！没有此页面的访问权限!(<%=Request.QueryString["pn"] %>)</div>
</body>
</html>
