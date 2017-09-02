<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShenPi.aspx.cs" Inherits="NH.Web.adm.Authority.Staff.ShenPi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        function CheckAll() {
            if (a == 1) {
                for (var i = 0; i < window.document.form1.elements.length; i++) {
                    var e = form1.elements[i];
                    e.checked = false;
                }
                a = 0;
            }
            else {
                for (var i = 0; i < window.document.form1.elements.length; i++) {
                    var e = form1.elements[i];
                    e.checked = true;
                }
                a = 1;
            }
        }
        function CheckDel() {
            var number = 0;
            for (var i = 0; i < window.document.form1.elements.length; i++) {
                var e = form1.elements[i];
                if (e.Name != "CheckBoxAll") {
                    if (e.checked == true) {
                        number = number + 1;
                    }
                }
            }
            if (number == 0) {
                alert("请选择需要审批的项！");
                return false;
            }
            if (window.confirm("你确认将选中项设置为未通过吗？")) {
                return true;
            }
            else {
                return false;
            }
        }
        function CheckDel1() {
            var number = 0;
            for (var i = 0; i < window.document.form1.elements.length; i++) {
                var e = form1.elements[i];
                if (e.Name != "CheckBoxAll") {
                    if (e.checked == true) {
                        number = number + 1;
                    }
                }
            }
            if (number == 0) {
                alert("请选择需要审批的项！");
                return false;
            }
            if (window.confirm("你确认将选中项设置为通过吗？")) {
                return true;
            }
            else {
                return false;
            }
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
                    &nbsp;<img src="../../images/BanKuaiJianTou.gif" />
                    考勤管理&nbsp;>>&nbsp;考勤审批
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    查询：<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="100px"></asp:TextBox><asp:ImageButton
                        ID="ImageButton4" runat="server" ImageAlign="AbsMiddle" ImageUrl="../../images/Button/BtnSerch.jpg"
                        OnClick="ImageButton4_Click" />&nbsp;&nbsp; &nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="javascript:return CheckDel1();"
                        ImageUrl="../../images/Button/ShenPiOK.jpg" ImageAlign="AbsMiddle" OnClick="ImageButton1_Click" />&nbsp;
                    &nbsp;
                    <asp:ImageButton ID="ImageButton3" runat="server" OnClientClick="javascript:return CheckDel();"
                        ImageUrl="../../images/Button/ShenPiNo.jpg" ImageAlign="AbsMiddle" OnClick="ImageButton3_Click" />&nbsp;
                    &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../images/Button/BtnReport.jpg"
                        ImageAlign="AbsMiddle" OnClick="ImageButton2_Click" />
                    <img src="../../images/Button/JianGe.jpg" /><img class="HerCss" onclick="javascript:window.history.go(-1)"
                        src="../../images/Button/BtnExit.jpg" />&nbsp;
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
                                <ItemTemplate>
                                    <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'
                                        Visible="False"></asp:Label><asp:CheckBox ID="CheckSelect" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Width="20px" />
                                <HeaderTemplate>
                                    <input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />
                                </HeaderTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="申请人"></asp:BoundField>
                            <asp:BoundField DataField="ShenPiRen" HeaderText="审批人"></asp:BoundField>
                            <asp:BoundField DataField="ShenQingTime" HeaderText="申请时间"></asp:BoundField>
                            <asp:BoundField DataField="BackInfo" HeaderText="申请原因"></asp:BoundField>
                            <asp:BoundField DataField="StartTime" HeaderText="开始时间"></asp:BoundField>
                            <asp:BoundField DataField="EndTime" HeaderText="结束时间"></asp:BoundField>
                            <asp:BoundField DataField="StateNow" HeaderText="状态"></asp:BoundField>
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
                        ImageUrl="../../images/Button/Jump.jpg" OnClick="ButtonGo_Click" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
