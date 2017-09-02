<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyLevel.aspx.cs" Inherits="NH.Web.adm.CompanyLevel.CompanyLevel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
<div id="List">
    <form id="form1" runat="server">
    <div class="frmborder">
        <p>
            VIP等级管理</p>
    </div>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                <tr class="th">
                    <td>ID</td>
                    <td>
                        等级名称
                    </td>
                    <td>价格</td>
                    <td width="100">
                        操作
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="tr">
                <td><%#Eval("Id") %></td>
                <td><%#Eval("LevelName")%></td>
                <td><%#Eval("Price")%></td>
                <td>
                    <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>">编辑</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table></FooterTemplate>
    </asp:Repeater>
    </form>
</div>

</body>
</html>
