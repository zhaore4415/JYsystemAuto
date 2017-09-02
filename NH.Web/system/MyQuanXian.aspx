<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyQuanXian.aspx.cs" Inherits="NH.Web.adm.system.MyQuanXian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
        <div class="form-sub">
            <div class="a-1">
                <p>
                    我的权限</p>
            </div>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    操作权限：
                </th>
                <td>
                   
                    <asp:Literal runat="server" ID="ltrFunCode"></asp:Literal><asp:Label ID="Label1"
                        runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <%--  <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
                    <input type="button" class="btnSubmit" value="返回" onclick="javascript:window.location.href='<%=ListUrl %>'" />--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
