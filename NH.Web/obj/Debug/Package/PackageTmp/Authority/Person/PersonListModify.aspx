<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonListModify.aspx.cs"
    Inherits="NH.Web.adm.Person.PersonModify" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>推荐库修改</title>
    <%=CssAndScript %>
    <link href="/css/css.css" rel="stylesheet" />

    <style>
        .span12 h2 {
            font-weight: normal;
            float: left;
        }

        .span12 .hengxian {
            height: 2px;
            background-color: #666;
            clear: both;
        }

        .span12 .dingdan-1 {
            font-size: 16px;
            margin-left: 20px;
        }

        .span12 .dingdan-2 {
            font-size: 16px;
        }

        /*@media(max-width:768px){
	.top .fenxiaoguanli{ display:none;}
	}*/
    </style>

</head>
<body>

    <form id="form1" runat="server">
        <uc2:Head ID="Head1" runat="server" />
        <uc1:left ID="left1" runat="server" />
        <div id="content">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span12">
                        <h2>
                            <a href="<%=ListUrl %>">返回</a>-> 添加</h2>
                        <div class="widget-box">
                            <div class="widget-content nopadding">
                                <table class="table table-bordered table-striped">
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td class="td-1">用户名
                                            </td>
                                            <td class="td-2">
                                                <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">性别
                                            </td>
                                            <td class="td-2">
                                                <div class="btn-group">
                                                    <asp:RadioButtonList runat="server" ID="rblSex" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                                        CssClass="noinputbg">
                                                        <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                                        <asp:ListItem Value="0">女</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>
                                        </tr>

                                        <tr class="odd gradeX">
                                            <td class="td-1">手机号码
                                            </td>
                                            <td class="td-2">
                                                <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">QQ号
                                            </td>
                                            <td class="td-2">
                                                <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">Email
                                            </td>
                                            <td class="td-2">
                                                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">联系地址
                                            </td>
                                            <td class="td-2">
                                                <asp:TextBox runat="server" ID="txtAddress" Width="350px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">相关信息
                                            </td>
                                            <td class="td-2">有多少下级层级： 
                                                <asp:Label ID="lbDepth" runat="server" Text=""></asp:Label><br />
                                                有多少下级数量： 
                                                <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">各级会员
                                            </td>
                                            <td class="td-2">
                                                <div style="float: left; width: 160px; height: 400px; margin-top: 10px;">

                                                    <%--<asp:ListBox runat="server" ID="ListBoxUserName" Width="150" Height="350" SelectionMode="Multiple"></asp:ListBox>--%><asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10" ShowLines="True">
                                                        <HoverNodeStyle Font-Underline="False" />
                                                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                                                        <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                                                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                                                    </asp:TreeView>
                                                </div>



                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <%--<asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click"
                                                    OnClientClick="return beforsubmit();" />--%>
                                                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn btn-inverse" OnClick="btnSubmit_Click"
                                                    OnClientClick="return beforesubmit()" />
                                                <input type="button" class="btn btn-inverse" value="返回" onclick="javascript:window.location.href='<%=ListUrl %>    '" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="table-add">
            <div class="frmborder">
                <p>
                    客户管理 -> 添加客户
                </p>
            </div>
            <div class="tbitem">
                <table width="100%" cellpadding="0" cellspacing="0" class="utable">
                    <tr>
                        <th>来源：
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtSource"></asp:TextBox>
                        </td>
                        <th>微信号
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtText1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <span class="red">*</span>用户名：
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
                        </td>
                        <th>
                            <span class="red">*</span>性别：
                        </th>
                        <td>
                            <asp:RadioButtonList runat="server" ID="rblSex" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                CssClass="noinputbg">
                                <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                <asp:ListItem Value="0">女</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <span class="red">*</span>手机号码：
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                        </td>
                        <th>QQ号：
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtQQ"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>Email：
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        </td>
                        <th>联系地址：
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>居住环境
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtEnvironment"></asp:TextBox>
                        </td>
                        <th></th>
                        <td></td>
                    </tr>

                </table>
            </div>
            <div class="tbitem">
                <table width="100%" cellpadding="0" cellspacing="0" class="utable">
                    <tr>
                        <th></th>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click"
                                OnClientClick="return beforsubmit();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>--%>
    </form>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('#txtBirthday').datebox({});
        });
    </script>--%>
    <%-- <script type="text/javascript">
        $("#<%=this.ddlMarriage.ClientID %>").formSelect({
            colWidth: 100,
            cols: 2,
            onShow: function () {
                $('#<%=this.ddlMarriage.ClientID %>').trigger('focusListener');
            },
            onClose: function () {
                $('#<%=this.ddlMarriage.ClientID %>').trigger('blurListener');
            }
        });
    </script>--%>
    <%-- <script type="text/javascript">var areas = <asp:Literal ID="ltrAreaJsObject" runat="server"></asp:Literal>;</script>--%>
</body>
</html>
