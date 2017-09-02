<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AUserAdd.aspx.cs"
    Inherits="NH.Web.adm.Authority.AUser.AUserAdd" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="/css/uniform.css" />
    <link rel="stylesheet" href="/css/select2.css" />
    <link rel="stylesheet" href="/css/matrix-style.css" />
    <link rel="stylesheet" href="/css/matrix-media.css" />
    <link href="/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<link href='http://fonts.useso.com/css?family=Open+Sans:400,700,800' rel='stylesheet'
        type='text/css'>--%>
    <style>
        .top
        {
            height: 80px;
            width: 100%;
            background-color: rgb(33,38,45);
        }
        .top img
        {
            float: left;
            margin-top: 30px;
            margin-left: 10px;
            width: 13%;
        }
        .top a
        {
            font-size: 20px;
            line-height: 80px;
            color: #FFF;
            float: right;
        }
        .top .a-3
        {
            margin-right: 10px;
        }
        .top .a-2
        {
            margin-left: 10px;
            margin-right: 30px;
        }
        .span12 h2
        {
            font-weight: normal;
            float: left;
        }
        .span12 .hengxian
        {
            height: 2px;
            background-color: #666;
            clear: both;
        }
        .span12 .dingdan-1
        {
            font-size: 16px;
            margin-left: 20px;
        }
        .span12 .dingdan-2
        {
            font-size: 16px;
        }
        .gradeX .td-1
        {
            text-align: center;
            width: 20%;
        }
        .td-2 .p-1
        {
            float: right;
            margin: 0;
        }
        .td-2 .p-2
        {
            float: left;
            margin: 0;
            margin-left: 5px;
        }
        .td-2 .a-1
        {
            float: right;
            margin: 0;
        }
        .td-2 .a-1:hover
        {
            cursor: pointer;
        }
        .td-2 input[type="text"]
        {
            background-color: #FFF;
            border: #666 solid 1px;
            text-indent: 2px;
        }
        .td-2 button
        {
            background-color: #FFF;
            border: #666 solid 1px;
        }
        .td-3 div
        {
            float: left;
            margin-right: 10px;
        }
        .td-4 p
        {
            float: left;
            margin: 0;
        }
        .td-4 input[type="text"]
        {
            float: left;
        }
        /*@media(max-width:768px){
	.top .fenxiaoguanli{ display:none;}
	}*/
    </style>
    <%-- <script src="/Script/jquery.min.js"></script>--%>
    <script src="/JS/jquery-1.2.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
         
            GetByJquery();
            $("#ddlBranchOne").change(function () { GetCity() });
            $("#ddlBranchTwo").change(function () { GetDistrict() });
        });

        function GetByJquery() {

            $("#ddlBranchOne").empty(); //清空省份SELECT控件

            $.getJSON("/Handler/GetBranchOne.ashx", function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchOne"));
                });
                     <%if(Request.QueryString["shen"]!="") {%>
                    $('#ddlBranchOne').val(<%=Request.QueryString["shen"] %>);<%} %>
//                alert($("#ddlBranchOne").val());
                GetCity();
            });

        }

        function GetCity() {

            $("#ddlBranchTwo").empty(); //清空城市SELECT控件
            var url = "/Handler/GetBranchTwo.ashx?id=" + $("#ddlBranchOne").val();
            $.getJSON(url, function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchTwo"));
                });
                GetDistrict();
            });
        }

        function GetDistrict() {
            $("#ddlBranchThird").empty(); //清空市区SELECT控件
            var url = "/Handler/GetBranchThird.ashx?id=" + $("#ddlBranchTwo").val();

            $.getJSON(url, function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchThird"));
                });
            });
        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[name=rblRoleType]').click(function () {
                if ($('[name=rblRoleType]:checked').val() == "0") {
                    $('#RolesList').show();
                } else {
                    $('#RolesList').hide();
                }
            }).filter(':checked').click();
        });
    </script>
    <script language="javascript" type="text/javascript" src="../../My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        function beforesubmit() {
            if ($.trim($('#txtJeFen').val()) == "") { alert('请填写积分'); $("#txtJeFen").focus(); return false; };
            if (isNaN($("#txtJeFen").val())) { alert("积分只能为数字！"); $("#txtJeFen").focus(); return false; }

            if (isNaN($("#txtZheKou").val())) { alert("折扣只能为数字！"); $("#txtZheKou").focus(); return false; }
            if (isNaN($("#txtTJZheKou").val())) { alert("折扣只能为数字！"); $("#txtTJZheKou").focus(); return false; }
            return true;
        }

    </script>
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
                                        <td class="td-1">
                                            用户账号
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtLoginName" AutoCompleteType="Disabled"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            用户密码
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtPassword1"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX tr-2">
                                        <td class="td-1">
                                            姓名
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtRealname"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            积分
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtJeFen"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            角色
                                        </td>
                                        <td class="td-2">
                                            <div class="btn-group">
                                                <asp:RadioButtonList runat="server" ID="rblRoleType" RepeatDirection="Horizontal"
                                                    RepeatLayout="Flow">
                                                    <asp:ListItem Value="1">超级管理员</asp:ListItem>
                                                    <asp:ListItem Value="2" Selected="True">一级会员</asp:ListItem>
                                                    <asp:ListItem Value="3">二级会员</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            性别
                                        </td>
                                        <td class="td-2">
                                            <div class="btn-group">
                                                <asp:DropDownList runat="server" ID="Sex">
                                                    <asp:ListItem Value="0" Selected="True">男</asp:ListItem>
                                                    <asp:ListItem Value="1">女</asp:ListItem>
                                                </asp:DropDownList>
                                                <%--   <button data-toggle="dropdown" class="btn dropdown-toggle">
                                                    请选择<span class="caret"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li><a href="#">男</a></li>
                                                    <li><a href="#">女</a></li>
                                                </ul>--%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            出生日期
                                        </td>
                                        <td class="td-2">
                                            <input class="Wdate" type="text" onclick="WdatePicker()" name="Wdate" />
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            邮箱
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            手机号码
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtShouJi" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            详细地址
                                        </td>
                                        <td class="td-2 td-3">
                                            <asp:DropDownList ID="ddlBranchOne" runat="server" Width="95px">
                                                <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiddenBranchOne" runat="server" Value="-1" />
                                            <asp:DropDownList ID="ddlBranchTwo" runat="server" Width="95px">
                                                <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiddenBranchTwo" runat="server" Value="-1" />
                                            <asp:DropDownList ID="ddlBranchThird" runat="server" Width="95px">
                                                <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiddenBranchThird" runat="server" Value="-1" />
                                            <asp:TextBox ID="txtJiaTingAddress" runat="server" Width="350px" CssClass="txtCls"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            淘宝/京东/线下
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="zcSource"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            QQ/微信
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="zcQQWinXin"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            公司/店铺名
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="zcCompany"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            备注
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtNotes" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            享受折扣
                                        </td>
                                        <td class="td-2 td-4">
                                            <asp:TextBox runat="server" ID="txtZheKou"></asp:TextBox>
                                            <p>
                                                &nbsp;&nbsp;* 0.85就是85% 的折扣，默认为1</p>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            推广折扣
                                        </td>
                                        <td class="td-2 td-4">
                                            <asp:TextBox runat="server" ID="txtTJZheKou"></asp:TextBox><p>
                                                &nbsp;&nbsp;* 0.85就是85% 的折扣，默认为1，下级代理的折扣</p>
                                        </td>
                                    </tr>
                                       <tr class="odd gradeX">
                                        <td class="td-1">
                                            身份
                                        </td>
                                        <td class="td-2 td-4">
                                            <asp:RadioButtonList ID="lbListType" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Selected="True">微商</asp:ListItem>
                                                <asp:ListItem Value="2">淘宝</asp:ListItem>
                                                <asp:ListItem Value="3">商户</asp:ListItem>
                                                <asp:ListItem Value="4">个体</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            是否付了定金
                                        </td>
                                        <td class="td-2 td-4">
                                            <asp:RadioButtonList runat="server" ID="RbnIsPayment" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Selected="True">未付</asp:ListItem>
                                                <asp:ListItem Value="1">已付</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                     <tr class="odd gradeX">
                                        <td class="td-1">
                                            审核
                                        </td>
                                        <td class="td-2 td-4">
                                            <asp:RadioButtonList runat="server" ID="RbnVerifyStatus" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0" Selected="True">未审核</asp:ListItem>
                                                <asp:ListItem Value="1" >通过</asp:ListItem>
                                                 <asp:ListItem Value="-1" >未通过</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            状态
                                        </td>
                                        <td class="td-2 td-4">
                                            <asp:RadioButtonList runat="server" ID="RbnStatus" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0">禁用</asp:ListItem>
                                                <asp:ListItem Value="1" Selected="True">正常</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn btn-inverse" OnClick="btnSubmit_Click"
                                                    OnClientClick="return beforesubmit()" />
                                                <input type="button" class="btn btn-inverse" value="返回" onclick="javascript:window.location.href='<%=ListUrl %>'" />
                                            </div>
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
    </form>
    <%-- <script src="js/jquery.min.js"></script>
    <script src="js/jquery.ui.custom.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.uniform.js"></script>
    <script src="js/select2.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/matrix.js"></script>
    <script src="js/matrix.tables.js"></script>--%>
</body>
</html>
