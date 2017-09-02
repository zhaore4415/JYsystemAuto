<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolutionList.aspx.cs" Inherits="NH.Web.adm.Article.SolutionList" %>

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
            <p>策划方案管理</p>
        </div>
        <div class="frmborder">
            关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="txtSmall"></asp:TextBox>
            <asp:DropDownList runat="server" ID="ddlCategory"></asp:DropDownList>
            <asp:Button runat="server" ID="btnSearch" Text="搜索" onclick="btnSearch_Click" CssClass="btnSmall" />
            <asp:Button runat="server" ID="btnDelete" Text="删除" onclick="btnDelete_Click" CssClass="btnSmall" />
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='SolutionAdd.aspx'" />
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="40"><input type="checkbox" id="chkAll" title="全选" /></td>
                        <td width="120">类别</td>
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
                        <a href="SolutionModify.aspx?id=<%#Eval("Id")%>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">删除</a>
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
