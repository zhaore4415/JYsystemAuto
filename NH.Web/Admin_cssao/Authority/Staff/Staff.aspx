<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="NH.Web.adm.Authority.Staff.Staff" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>    <script language="javascript" type="text/javascript" src="../../My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="form-sub">
        <div class="a-1">
            考勤管理
        </div>
        <div class="frmborder">
            关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="txtSmall"></asp:TextBox>
            <input class="Wdate" type="text" onclick="WdatePicker()" name="Wdate" id="Wdate"
                        runat="server" />
            <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" CssClass="btnSmall" />
            <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btnSmall" />
            <input type="button" value="添加" class="btnSmall" onclick="window.location.href='<%=PagePreFix %>Add.aspx'" />
        </div>
    </div>
    <div class="table">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="1" width="100%">
                    <tr class="th">
                        <td width="40">
                            <input type="checkbox" id="chkAll" title="全选" />
                        </td>
                        <td>
                            姓名
                        </td>
                        <td>
                            工号
                        </td>
                        <td>
                            日期
                        </td>
                        <td>
                            上午打卡时间
                        </td>
                        <td>
                            下午打卡时间
                        </td>
                        <td>
                            是否迟到
                        </td>
                        <td>
                            是否早退
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
                        <%#Eval("Realname")%>
                    </td>
                    <td>
                        <%#Eval("WorkNumber")%>
                    </td>
                    <td>
                        <%#Eval("TodayDate")%>
                    </td>
                    <td>
                        <%#Eval("Data1")%>
                    </td>
                    <td>
                        <%#Eval("Data2")%>
                    </td>
                    <td>
                        <%# (int)Eval("DataType1") == 1 ? "<font color='red'>迟到</font>" : "正常"%>
                    </td>
                    <td>
                        <%# (int)Eval("DataType2") == 1 ? "<font color='red'>早退</font>" : "正常"%>
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
