<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryouderModify.aspx.cs"
    Inherits="NH.Web.adm.Member.QueryouderModify" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单详情</title>
    <%=CssAndScript %>
    <link href="../css/index.css" rel="stylesheet">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="/css/uniform.css" />
    <link rel="stylesheet" href="/css/select2.css" />
    <link rel="stylesheet" href="/css/matrix-style.css" />
    <link rel="stylesheet" href="/css/matrix-media.css" />
    <link href='http://fonts.useso.com/css?family=Open+Sans:400,700,800' rel='stylesheet'
        type='text/css'>
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
        .span12 .dingdan-1
        {
            font-size: 16px;
            margin-left: 20px;
        }
        .span12 .dingdan-2
        {
            font-size: 16px;
        }
        .table-striped th
        {
            font-size: 14px;
        }
        .table.td
        {
            text-align: center;
        }
        .td-1
        {
            width: 20%;
        }
        .td-1 p
        {
            text-align: right;
            margin: 0;
        }
        .td-2 *
        {
            text-align: left;
        }
        .td-2 span
        {
            float: left;
            background-color: #FFF;
        }
        .td-2 .dropdown-toggle
        {
            display: block;
            float: left;
        }
        .table-2
        {
            width: 30%;
        }
        .td-3 p
        {
            text-align: right;
            margin: 0;
        }
        .td-4 p
        {
            text-align: right;
            margin: 0;
        }
        .td-4 .btn-group
        {
            float: right;
            display: block;
            text-align: right;
        }
        .td-2 .btn-group
        {
            float: left;
            margin-right: 10px;
        }
        .gradeX td
        {
            text-align: center;
        }
    </style>
    <script src="../Script/jquery.min.js" type="text/javascript"></script>
    <script src="../JS/jquery-1.2.1.js" type="text/javascript"></script>
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
                   
                    $('#ddlBranchOne').val(<%=model.fk_id %>);
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
                 
                    $('#ddlBranchTwo').val(<%=model.sk_id %>);
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
               
                    $('#ddlBranchThird').val(<%=model.tk_id %>);
            });
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
                    <a href="#" onclick="history.back(-1)" class="fanhui">返回</a>
                    <div class="widget-box">
                        <div class="widget-content nopadding">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-bordered table-striped">
                                        <tr>
                                            <th>
                                                <strong>ID</strong>
                                            </th>
                                            <th>
                                                <strong>产品</strong>
                                            </th>
                                            <th>
                                                <strong>分类名称</strong>
                                            </th>
                                            <th>
                                                <strong>数量</strong>
                                            </th>
                                            <th>
                                                <strong>单价</strong>
                                            </th>
                                            <th>
                                                <strong>积分</strong>
                                            </th>
                                            <th>
                                                <strong>状态</strong>
                                            </th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="odd gradeX">
                                        <td>
                                            <%#Eval("ID")%>
                                        </td>
                                        <td>
                                            <%#Eval("PName")%>
                                        </td>
                                        <td>
                                            <%# CategoryName((int)Eval("CategoryID"))%>
                                        </td>
                                        <td>
                                            <%#Eval("Num")%>
                                        </td>
                                        <td>
                                            <span id="price<%#Eval("ID")%>">
                                                <%#Eval("ChuShou")%></span>元
                                        </td>
                                        <td>
                                            <span id="jifen<%#Eval("ID")%>">
                                                <%#Eval("KeJiFen")%></span>
                                        </td>
                                        <td>
                                            已完成
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget-box">
                            <div class="widget-content nopadding">
                                <table class="table table-bordered table-striped">
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td class="td-1">
                                                <p>
                                                    收件人</p>
                                            </td>
                                            <td class="td-2">
                                                <asp:Label ID="txtName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">
                                                <p>
                                                    联系电话</p>
                                            </td>
                                            <td class="td-2">
                                                <asp:Label ID="txtPhone" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">
                                                <p>
                                                    地址</p>
                                            </td>
                                            <td class="td-2">
                                                <div class="btn-group">
                                                    <asp:DropDownList ID="ddlBranchOne" runat="server" Width="95px">
                                                        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hiddenBranchOne" runat="server" Value="-1" />
                                                </div>
                                                <div class="btn-group">
                                                    <asp:DropDownList ID="ddlBranchTwo" runat="server" Width="95px">
                                                        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hiddenBranchTwo" runat="server" Value="-1" />
                                                </div>
                                                <div class="btn-group">
                                                    <asp:DropDownList ID="ddlBranchThird" runat="server" Width="95px">
                                                        <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hiddenBranchThird" runat="server" Value="-1" />
                                                </div>
                                                <asp:Label runat="server" ID="txtJiaTingAddress"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">
                                                <p>
                                                    备注</p>
                                            </td>
                                            <td class="td-2">
                                                <asp:Label runat="server" ID="txtDetail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="odd gradeX">
                                            <td class="td-1">
                                            </td>
                                            <td class="td-2">
                                                <table class="table table-bordered table-striped table-2">
                                                    <tbody>
                                                        <tr class="odd gradeX">
                                                            <td class="td-3">
                                                                <p>
                                                                    数量</p>
                                                            </td>
                                                            <td class="td-4">
                                                                <p>
                                                                    <asp:Label runat="server" ID="txtBabynumber"></asp:Label></p>
                                                            </td>
                                                        </tr>
                                                        <tr class="odd gradeX">
                                                            <td class="td-3">
                                                                <p>
                                                                    支付金额</p>
                                                            </td>
                                                            <td class="td-4">
                                                                <p>
                                                                    <asp:Label runat="server" ID="txtAmount"></asp:Label>元</p>
                                                            </td>
                                                        </tr>
                                                        <tr class="odd gradeX">
                                                            <td class="td-3">
                                                                <p>
                                                                    总共积分</p>
                                                            </td>
                                                            <td class="td-4">
                                                                <p>
                                                                    <asp:Label runat="server" ID="txtKeJiFen"></asp:Label></p>
                                                            </td>
                                                        </tr>
                                                        <tr class="odd gradeX">
                                                            <td class="td-3">
                                                                <p>
                                                                    付款方式</p>
                                                            </td>
                                                            <td class="td-4">
                                                                <p>
                                                                    <asp:RadioButtonList runat="server" ID="RbnPay" RepeatDirection="Horizontal" Enabled="false">
                                                                        <asp:ListItem Value="0" Selected="True">微信支付</asp:ListItem>
                                                                        <asp:ListItem Value="1">支付宝</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
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
    </div>
    </form>
</body>
</html>
