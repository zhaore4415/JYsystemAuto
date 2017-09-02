<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AUser.aspx.cs" Inherits="NH.Web.adm.Authority.AUser.AUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <div id="List">
        <form id="form1" runat="server">
        <div class="frmborder">
            <p>
                管理员管理</p>
        </div>
        <div class="frmborder">
            <asp:Button runat="server" ID="btnDelete" Text="删除" onclick="btnDelete_Click" CssClass="btnSmall"/>
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='<%=PagePreFix %>Add.aspx'" />
        </div>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="40">
                            <input type="checkbox" id="chkAll" title="全选" />
                        </td>
                        <td>
                            帐号
                        </td>
                        <td>
                            姓名
                        </td>
                        <td>
                            角色
                        </td>
                        <td>
                            上次登录时间
                        </td>
                        <td>
                            上次登录IP
                        </td>
                        <td>
                            状态
                        </td>
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
                        <%#Eval("LoginName")%>
                    </td>
                    <td>
                        <%#Eval("Realname")%>
                    </td>
                    <td>
                        <%# GetRoleName((int)Eval("Id"))%>
                    </td>
                    <td>
                        <%#Eval("LoginTime")%>
                    </td>
                    <td>
                        <%#Eval("LoginIP")%>
                    </td>
                    <td>
                        <%# NH.Web.adm.WebBase.ModelEnum.AUserStatusDesc((NH.Web.adm.WebBase.ModelEnum.AUserStatus)((int)Eval("Status"))) %>
                    </td>
                    <td>
                        <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">
                            删除</a>
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
