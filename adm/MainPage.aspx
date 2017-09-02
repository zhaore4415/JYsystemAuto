<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="NH.Web.adm.MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="intro">
                
        <div class="frmborder" style=" padding:0px">
            <p class="title tab"><span>数据验证信息</span></p>
            <p>今日注册个人：<asp:Label runat="server" ID="lbNewPerson"></asp:Label>个 <a href="Person/PersonListForVerify.aspx">是否现在验证</a></p>
            <p>今日注册企业：<asp:Label runat="server" ID="lbNewCompany"></asp:Label>个 <a href="Company/CompanyListForVerify.aspx">是否现在验证</a></p>
        </div>
    </div>
    </form>
</body>
</html>
