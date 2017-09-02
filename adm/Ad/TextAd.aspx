<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextAd.aspx.cs" Inherits="NH.Web.adm.Ad.TextAd" %>

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
            <p>
                广告管理 -> <asp:Literal runat="server" ID="ltrTypeName"></asp:Literal></p>
        </div>
        <div class="frmborder">
            <asp:Button runat="server" ID="btnDelete" Text="删除" onclick="btnDelete_Click" CssClass="btnSmall"/>
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='<%=PagePreFix %>Add.aspx?<%=Request.QueryString.ToString() %>'" />
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="40">
                            <input type="checkbox" id="chkAll" title="全选" />
                        </td>
                        <td>标题</td>
                        <td>链接</td>
                        <td>开始时间</td>
                        <td>结束时间</td>
                        <td>添加时间</td>
                        <td>排序值</td>
                        <td>状态</td>
                        <td width="100">
                            操作
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td>
                        <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                    </td>
                    <td>
                        <%#Eval("Title")%>
                    </td>
                    <td>
                        <%#Eval("Url")%>
                    </td>
                    <td>
                        <%#Eval("StartDate","{0:yyyy-MM-dd}")%>
                    </td>
                    <td><%# Eval("EndDate", "{0:yyyy-MM-dd}")%></td>
                    <td><%# Eval("AddTime") %></td>
                    <td><%# Eval("Sort")%></td>
                    <td><%# (bool)Eval("IsShow") ? "开启" : "<font color='red'>关闭</font>"%></td>
                    <td>
                        <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>&cid=<%=Request.QueryString["cid"] %>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">
                            删除</a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
        <%=_pager%>
        </form>
    </div>
</body>
</html>
