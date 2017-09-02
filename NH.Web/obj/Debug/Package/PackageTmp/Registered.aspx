<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Registered.aspx.cs"
    Inherits="NH.Web.Cssao.Registered" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="css/uniform.css" />
    <link rel="stylesheet" href="css/select2.css" />
    <link rel="stylesheet" href="css/matrix-style.css" />
    <link rel="stylesheet" href="css/matrix-media.css" />
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href='http://fonts.useso.com/css?family=Open+Sans:400,700,800' rel='stylesheet'
        type='text/css' />
    <style>
        #tablezc td
        {
            width: 50%;
        }
        
        #tablezc .odd input
        {
            background-color: #FFF;
            border: 1px solid #666;
            text-indent: 5px;
            display: block;
            margin-left: auto;
            margin-right: auto;
            height: 20px;
            padding: 0px;
            margin-bottom: 0px;
            font-size: 12px;
            line-height: 20px;
        }
        #tablezc .odd select
        {
            background-color: #FFF;
            border: 1px solid #666;
            text-indent: 5px;
            display: block;
            margin-left: auto;
            margin-right: auto;
            height: 20px;
            padding: 0px;
            margin-bottom: 0px;
            font-size: 12px;
            line-height: 20px;
            display: inline-block;
            text-align: center;
            vertical-align: middle;
        }
        body *
        {
            background-color: rgba(0,0,0,0);
        }
        #tablezc .btn-group
        {
            margin-left: 10px;
            margin-right: 10px;
        }
        .box
        {
            overflow: hidden;
            margin-left: auto;
            margin-right: auto;
        }
        #tablezc button
        {
            margin-left: auto;
            margin-right: auto;
        }
        .top
        {
            width: 100%;
            text-align: center;
            font-size: 30px;
            line-height: 50px;
            color: #FFF;
            margin-top: 20px;
        }
        #tablezc .btn-large
        {
            display: block;
            margin-left: auto;
            margin-right: auto;
        }
        .fanhui
        {
            float: left;
            color: #FFF;
            font-size: 20px;
            margin-top: 20px;
            margin-left: 10px;
        }
        #lbListType
        {
            width: 80%;
            max-width: 80%;
        }
        #lbListType td
        {
            width: 10%;
        }
        #lbListType input[type=radio]
        {
            width: 25px;
            float: left;
            height: 15px;
        }
        #lbListType label
        {
            width: 35px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <a class="fanhui" href="AdminLogin.aspx"><< 返回</a>
    <div class="top">
        代理商申请</div>
    <div class="row-fluid">
        <div class="span12">
            <div class="widget-box">
                <div class="widget-content nopadding">
                    <table class="table table-bordered table-striped" id="tablezc">
                        <tbody>
                            <tr class="odd gradeX">
                                <td class="progress-striped">
                                    <input placeholder="*用户名" id="zcUserName" name="zcUserName" />
                                </td>
                                <td>
                                    <input placeholder="*手机号" id="zcPhone" name="zcPhone" />
                                </td>
                            </tr>
                            <tr class="odd gradeX">
                                <td>
                                    <input placeholder="*密码" type="password" id="zcPassWord" name="zcPassWord" />
                                </td>
                                <td>
                                    <input placeholder="邮箱" id="zcEmail" name="zcEmail" />
                                    <%--<input placeholder="QQ/微信" id="zcQQWinXin" name="zcQQWinXin" />--%>
                                </td>
                            </tr>
                            <tr class="odd gradeX">
                                <td>
                                    <input placeholder="*确认密码" id="zcRPassWord" name="zcRPassWord" type="password" />
                                </td>
                                <td>
                                    <%--<input placeholder="公司/店铺名" id="zcCompany" name="zcCompany" />--%>
                                  
                                </td>
                            </tr>
                            <tr class="odd gradeX">
                                <td>  <asp:DropDownList ID="ddlBranchOne" runat="server" Width="95px">
                                        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hiddenBranchTwo" runat="server" Value="-1" />
                                    <asp:DropDownList ID="ddlBranchTwo" runat="server" Width="95px">
                                        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hiddenBranchOne" runat="server" Value="-1" />
                                    <asp:DropDownList ID="ddlBranchThird" runat="server" Width="95px">
                                        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hiddenBranchThird" runat="server" Value="-1" />
                                    <%--<input placeholder="淘宝/京东/线下" id="zcSource" name="zcSource" />--%>
                                </td>
                                <td>
                                    <input id="zcJiaTingAddress" name="zcJiaTingAddress" placeholder="详细地址" />
                                </td>
                            </tr>
                            <tr class="odd gradeX">
                                <td>
                                    <asp:RadioButtonList ID="lbListType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">微商</asp:ListItem>
                                        <asp:ListItem Value="2">淘宝</asp:ListItem>
                                        <asp:ListItem Value="3">商户</asp:ListItem>
                                        <asp:ListItem Value="4">个体</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <input id="TJCode" name="TJCode" placeholder="*推荐码，没有请致电我们索要！" />
                                </td>
                            </tr>
                            <tr class=" gradeX">
                                <td colspan="2">
                                    <asp:Button runat="server" ID="btnSubmit" Text=" 提交 " OnClick="btnSubmit_Click" CssClass="btn btn-inverse btn-large"
                                        OnClientClick="return beforesubmit()" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
    <!--Footer-part-->
    <!--end-Footer-part-->
    <script src="js/jquery.min.js"></script>
    <script src="js/jquery.ui.custom.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.uniform.js"></script>
    <script src="js/select2.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/matrix.js"></script>
    <script src="js/matrix.tables.js"></script>
    <script src="JS/jquery-1.2.1.js" type="text/javascript"></script>
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
        function beforesubmit() {
            if ($.trim($('#zcUserName').val()) == "") { alert('请填写用户名'); $("#zcUserName").focus(); return false; };
            if ($.trim($('#zcPassWord').val()) == "") { alert('请填写密码'); $("#zcPassWord").focus(); return false; };
            if ($.trim($('#zcRPassWord').val()) == "") { alert('请重新输入密码'); $("#zcRPassWord").focus(); return false; };
            if ($.trim($('#zcRPassWord').val()) != $.trim($('#zcPassWord').val())) { alert('两次输入的密码不一致'); return false; };
            if ($.trim($('#TJCode').val()) == "") { alert('请填写推荐码，如果没有请致电我们索要！'); $("#TJCode").focus(); return false; };
            //            if (isNaN($("#zcSerialNumber").val())) { alert("推荐人ID只能为数字！"); $("#zcSerialNumber").focus(); return false; }
            if ($.trim($('#zcPhone').val()) == "") { alert('请填写手机号码'); $("#zcPhone").focus(); return false; };
            if (!$("#zcPhone").val().match(/^1[3|4|5|7|8][0-9]\d{8}$|^\d{8}$/)) { alert("手机号码格式不正确！"); $("#zcPhone").focus(); return false; }

            return true;
        }

    </script>
</body>
</html>
