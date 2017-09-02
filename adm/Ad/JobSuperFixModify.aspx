<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobSuperFixModify.aspx.cs" Inherits="NH.Web.adm.Ad.JobSuperFixModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Add">
    <div class="frmborder">
            <p>广告管理 -> <a href="<%=ListUrl %>?cid=<%=Request.QueryString["cid"] %>"><asp:Literal runat="server" ID="ltrTypeName"></asp:Literal></a> -> 修改</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>所属类型：</th>
                <td>
                    <asp:Literal runat="server" ID="ltrTypeName2"></asp:Literal>
                    (<asp:Literal runat="server" ID="ltrDesc"></asp:Literal>)
                </td>
            </tr>
            <tr>
                <th>
                    企业名称：
                </th>
                <td>
                    <asp:Label runat="server" ID="lbCompanyName"></asp:Label>
                </td> 
            </tr>
            <tr>
                <th>招聘职位：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobName"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>
                    展示时间：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="easyui-datebox"></asp:TextBox>至<asp:TextBox runat="server" ID="txtEndDate" CssClass="easyui-datebox"></asp:TextBox>(时间留空表示无时间限制)
                </td>
            </tr>
            <tr>
                <th>
                    备注：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    状态：
                </th>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" 
                        RepeatDirection="Horizontal" >
                        <asp:ListItem Value="1" Selected="True">发布</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
