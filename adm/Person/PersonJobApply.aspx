<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonJobApply.aspx.cs" Inherits="NH.Web.adm.Person.PersonJobApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td width="25%">企业名称</td>
                        <td width="25%">职位名称</td>
                        <td width="25%">应聘时间</td>
                        <td width="25%">状态</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td><a href='<%# NH.Web.Urls.CompanyInfo((int)Eval("CompanyID")) %>' target="_blank"><%# Eval("CompanyName")%></a></td>
                    <td><a href='<%# NH.Web.Urls.JobInfo((int)Eval("JobID")) %>' target="_blank"><%# Eval("JobCategoryName")%></a></td>
                    <td><%# Eval("AddTime")%></td>
                    <td><%# (bool)Eval("ReadStatus") ? "已阅" : "未阅" %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
</body>
</html>
