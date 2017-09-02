<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DengJi.aspx.cs" Inherits="NH.Web.adm.Authority.Staff.DengJi" %>

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
      
             
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="form-sub">
        <div class="frmborder">
            <span style="float: left; width: 15px; height: 47px"></span><span style="padding-right: 10px;
                padding-left: 10px; float: left; height: 47px; text-align: center;">考勤登记</span><span
                    style="float: left; width: 60px; height: 47px"></span>
        </div>
    </div>--%>
    <div class="table">
        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr style="background-image: url(../../images/bg_header.gif); background-repeat: repeat-x;
                height: 47px;">
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../../images/BanKuaiJianTou.gif" />
                    &nbsp;考勤管理&nbsp;>>&nbsp;考勤登记
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    查询：<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="100px"></asp:TextBox><asp:ImageButton
                        ID="ImageButton4" runat="server" ImageAlign="AbsMiddle" ImageUrl="../../images/Button/BtnSerch.jpg"
                        OnClick="ImageButton4_Click" />&nbsp;&nbsp; &nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/Button/BtnAdd.jpg"
                        ImageAlign="AbsMiddle" OnClick="ImageButton1_Click" />&nbsp; &nbsp;
                    <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btnSmall" />
                    <%--<asp:ImageButton ID="ImageButton3" runat="server" OnClientClick="javascript:return CheckDel();"
                        ImageUrl="../../images/Button/BtnDel.jpg" ImageAlign="AbsMiddle" OnClick="ImageButton3_Click" />--%>&nbsp;
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
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkAll" title="全选" />
                                    <%--<input id="CheckBoxAll" onclick="CheckAll()" type="checkbox" />--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                                </ItemTemplate>
                                <HeaderStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="申请人"></asp:BoundField>
                            <asp:BoundField DataField="ShenPiRen" HeaderText="审批人"></asp:BoundField>
                            <asp:BoundField DataField="ShenQingTime" HeaderText="申请时间"></asp:BoundField>
                            <asp:BoundField DataField="BackInfo" HeaderText="申请原因"></asp:BoundField>
                            <asp:BoundField DataField="StartTime" HeaderText="开始时间"></asp:BoundField>
                            <asp:BoundField DataField="EndTime" HeaderText="结束时间"></asp:BoundField>
                            <asp:BoundField DataField="StateNow" HeaderText="状态"></asp:BoundField>
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
                        ImageUrl="../../images/Button/Jump.jpg" OnClick="ButtonGo_Click" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <span style="color: #ff0033">*</span> <span style="color: #666600">
                        已经通过审批的登记不可以删除。</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
