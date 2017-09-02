<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdType.aspx.cs" Inherits="NH.Web.adm.Ad.AdType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=ListScript%>
</head>
<body>
    <div id="List">
        <form id="form1" runat="server">
        <div class="frmborder">
            <p>
                广告类型管理</p>
        </div>
        <%--<div class="frmborder">
        </div>--%>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="60">
                            ID
                        </td>
                        <td>
                            广告位名称
                        </td>
                        <td>描述</td>
                        <td width="150">广告位显示数量</td>
                        <td width="100">
                            操作
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td>
                        <%#Eval("Id")%>
                    </td>
                    <td>
                        <%#Eval("TypeName")%>
                    </td>
                    <td><%# Eval("Remark") %></td>
                    <td><%# Eval("ShowCount")%></td>
                    <td>
                        <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>">编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        <%=_pager %>
        </form>
    </div>
</body>
</html>
