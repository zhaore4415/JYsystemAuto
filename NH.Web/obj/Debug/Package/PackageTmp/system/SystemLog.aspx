<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemLog.aspx.cs" Inherits="NH.Web.adm.system.SystemLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统日志</title>
    <%=CssAndScript %>
    <script language="JavaScript">
        var a;
        function CheckValuePiece() {
            if (window.document.form1.GoPage.value == "") {
                alert("请输入跳转的页码！");
                window.document.form1.GoPage.focus();
                return false;
            }
            return true;
        }

        function CheckModify() {
            var Modifynumber = 0;
            for (var i = 0; i < window.document.form1.elements.length; i++) {
                var e = form1.elements[i];
                if (e.Name != "CheckBoxAll") {
                    if (e.checked == true) {
                        Modifynumber = Modifynumber + 1;
                    }
                }
            }
            if (Modifynumber == 0) {
                alert("请至少选择一项！");
                return false;
            }
            if (Modifynumber > 1) {
                alert("只允许选择一项！");
                return false;
            }

            return true;
        }
             
             
             
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="table">
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    系统管理&nbsp;>>&nbsp;系统日志管理
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    用户：<asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="60px"></asp:TextBox>
                    内容：
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="100px"></asp:TextBox><asp:ImageButton
                        ID="ImageButton4" runat="server" ImageAlign="AbsMiddle" ImageUrl="../../images/Button/BtnSerch.jpg"
                        OnClick="ImageButton4_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btnSmall" />&nbsp;
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageAlign="AbsMiddle" ImageUrl="../../images/Button/BtnReport.jpg"
                        OnClick="ImageButton2_Click" /><img src="../../images/Button/JianGe.jpg" /><img class="HerCss"
                            onclick="javascript:window.history.go(-1)" src="../../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="GVData" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="GVData_RowDataBound" PageSize="15"
                        Width="100%">
                        <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        <PagerStyle BackColor="LightSteelBlue" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#006599" Font-Size="12px" ForeColor="White" Height="20px" />
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkAll" title="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                                </ItemTemplate>
                                <HeaderStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="用户名">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TimeStr" HeaderText="日志时间">
                                <ItemStyle Width="130px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DoSomething" HeaderText="日志内容"></asp:BoundField>
                            <asp:BoundField DataField="IpStr" HeaderText="IP地址"></asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    操作
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">删除</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" Height="25px" />
                        <EmptyDataTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" style="border-right: black 1px; border-top: black 1px; border-left: black 1px;
                                        border-bottom: black 1px; background-color: whitesmoke;">
                                        该列表中暂时无数据！
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="border-top: #000000 1px solid; border-bottom: #000000 1px solid">
                    <asp:ImageButton ID="BtnFirst" runat="server" CommandName="First" ImageUrl="../../images/Button/First.jpg"
                        OnClick="PagerButtonClick" />
                    <asp:ImageButton ID="BtnPre" runat="server" CommandName="Pre" ImageUrl="../../images/Button/Pre.jpg"
                        OnClick="PagerButtonClick" />
                    <asp:ImageButton ID="BtnNext" runat="server" CommandName="Next" ImageUrl="../../images/Button/Next.jpg"
                        OnClick="PagerButtonClick" />
                    <asp:ImageButton ID="BtnLast" runat="server" CommandName="Last" ImageUrl="../../images/Button/Last.jpg"
                        OnClick="PagerButtonClick" />
                    &nbsp;第<asp:Label ID="LabCurrentPage" runat="server" Text="Label"></asp:Label>页&nbsp;
                    共<asp:Label ID="LabPageSum" runat="server" Text="Label"></asp:Label>页&nbsp;
                    <asp:TextBox ID="TxtPageSize" runat="server" CssClass="TextBoxCssUnder2" Height="20px"
                        Width="35px">15</asp:TextBox>
                    行每页 &nbsp; 转到第<asp:TextBox ID="GoPage" runat="server" CssClass="TextBoxCssUnder2"
                        Height="20px" Width="33px"></asp:TextBox>
                    页&nbsp;
                    <asp:ImageButton ID="ButtonGo" runat="server" OnClientClick="javascript:return CheckValuePiece();"
                        ImageUrl="../images/Button/Jump.jpg" OnClick="ButtonGo_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
