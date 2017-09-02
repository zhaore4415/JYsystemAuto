﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fun.aspx.cs" Inherits="NH.Web.adm.Authority.Fun.Fun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
</head>
<body>
    <form id="form1" runat="server">
    <div class="form-sub">
        <div class="a-1">
            功能码管理
        </div>
        <div class="a-2">
            <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btnSmall" />
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='<%=PagePreFix %>Add.aspx'" />
        </div>
    </div>
    <div class="table">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="1" width="100%">
                    <tr class="th">
                        <td width="40">
                            <input type="checkbox" id="chkAll" title="全选" />
                        </td>
                        <td>
                            功能名称
                        </td>
                        <td>
                            所属功能组
                        </td>
                        <td>
                            功能码
                        </td>
                        <td>
                            操作类型
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
                        <%#Eval("Name")%>
                    </td>
                    <td>
                        <%#Eval("GroupName")%>
                    </td>
                    <td>
                        <%#Eval("Code")%>
                    </td>
                    <td>
                        <%# NH.Web.adm.WebBase.ModelEnum.FunTypeDesc((NH.Web.adm.WebBase.ModelEnum.FunType)Eval("FunType"))%>
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
    </div>
    </form>
</body>
</html>
