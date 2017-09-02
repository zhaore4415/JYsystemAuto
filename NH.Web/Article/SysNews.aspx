<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysNews.aspx.cs" Inherits="NH.Web.adm.Article.SysNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <div id="List">
        <form id="form1" runat="server">
        <div class="frmborder">
            <p>系统消息管理(<%=_type %>)</p>
        </div>
        <div class="frmborder">
            关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="txtSmall"></asp:TextBox>
            <asp:Button runat="server" ID="btnSearch" Text="搜索" onclick="btnSearch_Click" CssClass="btnSmall" />
            <asp:Button runat="server" ID="btnDelete" Text="删除" onclick="btnDelete_Click" CssClass="btnSmall" />
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='SysNewsAdd.aspx?type=<%=Request.QueryString["type"] %>'" />
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="40"><input type="checkbox" id="chkAll" title="全选" /></td>
                        <td width="120">新闻类别</td>
                        <td>标题</td>
                        <td width="150">添加时间</td>
                        <td width="100">操作</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td>
                        <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                    </td>
                    <td>
                        <%#Eval("CategoryName")%>
                    </td>
                    <td>
                        <%#Eval("Title")%>
                    </td>
                    <td>
                        <%# Eval("AddTime")%>
                    </td>
                    <td>
                        <a href="SysNewsModify.aspx?id=<%#Eval("Id")%>&type=<%=Request.QueryString["type"] %>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">删除</a>
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
