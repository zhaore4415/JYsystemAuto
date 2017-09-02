<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryorderAll.aspx.cs"
    Inherits="NH.Web.adm.Member.QueryorderAll" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单列表</title>
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
        .span12 .dingdan-1
        {
            font-size: 16px;
            margin-left: 20px;
        }
        .span12 .dingdan-2
        {
            font-size: 16px;
        }
        .gradeX td
        {
            text-align: center;
        }
        .table-striped th
        {
            font-size: 14px;
        }
        .span12 .searchbox
        {
            float: right;
        }
        .span12 .input-1
        {
            width: 180px;
            height: 25px;
            background-color: #FFF;
            border: 1px solid #CCC;
            border-right: none;
            float: left;
            text-indent: 5px;
        }
        .span12 .input-2
        {
            width: 25px;
            height: 29px;
            background-color: #FFF;
            border: 1px solid #CCC;
            border-left: none;
            float: left;
            background-image: url(../../images/fangdajing.png);
            background-repeat: no-repeat;
            background-position: center center;
        }
        
        .dingdanliebiao span
        {
            padding-bottom: 10px;
            display: block;
        }
        .current
        {
            font-weight: bold;
            color: #28b779;
        }
    </style>
    <link href="../css/index.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <uc2:Head ID="Head1" runat="server" />
    <uc1:left ID="left1" runat="server" />
    <div id="content">
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div class="dingdanliebiao">
                        <h1 class="liebiao">
                            订单列表(全部)</h1>
                        <span><a href="QueryorderAll.aspx" class="<%=Request.Path.ToLower().Contains("/queryorderall.aspx") ? "current" : ""%>">
                            产品购买订单</a> | <a href="QueryorderfxAll.aspx" class="<%=Request.Path.ToLower().Contains("/Queryorderfxall.aspx") ? "current" : ""%>">
                                积分兑换订单</a></span>
                    </div>
                    <div class="searchbox">
                        关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="input-text" placeholder="输入订单号"></asp:TextBox>
                        <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" CssClass="btn btn-inverse btn-mini" />
                    </div>
                    <div class="widget-box">
                        <div class="widget-content nopadding table-responsive">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <strong>用户名</strong>
                                                </th>
                                                <th>
                                                    <strong>订单号</strong>
                                                </th>
                                                <th>
                                                    <strong>订购数量</strong>
                                                </th>
                                                <th>
                                                    <strong>金额</strong>
                                                </th>
                                                <th>
                                                    <strong>状态</strong>
                                                </th>
                                                <th>
                                                    <strong>时间</strong>
                                                </th>
                                                <%--  <th>
                                                    点击支付
                                                </th>
                                                <th>
                                                    <strong>操作</strong>
                                                </th>--%>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td>
                                                <%#Eval("LoginName")%>
                                            </td>
                                            <td>
                                                <%#Eval("OrderNumber")%>
                                            </td>
                                            <td>
                                                <%#Eval("Babynumber")%>
                                            </td>
                                            <td>
                                                <%#Eval("Amount")%>
                                            </td>
                                            <td>
                                                <%# Eval("Status").ToString() == "0" ? "<font color='Red'>未支付</font>" : "已支付 | <a href='QueryouderModify.aspx?OrderSN=" + Eval("OrderNumber") + "&Uid=" + Eval("U_ID") + "&class=" + Eval("Type") + "'>查看订单</a>"%>
                                            </td>
                                            <td>
                                                <%#Eval("AddTime")%>
                                            </td>
                                            <%--  <td>
                                                <%# Eval("Status").ToString() == "1" ? "已支付" : "<a href='PayDetail.aspx?OrderSN=" + Eval("OrderNumber") + "'>支付</a>"%>
                                            </td>
                                            <td>
                                                <%# Eval("Status").ToString() == "1" ? "<a href='QueryouderModify.aspx?OrderSN=" + Eval("OrderNumber") + "&class=" + Eval("Type") + "'>查看订单</a>" : "<a href='PayDetail.aspx?OrderSN=" + Eval("OrderNumber") + "'>继续支付</a>"%>|
                                                <%# Eval("Status").ToString() == "1" ? "已支付" : "<a href='../Handler/OrderCancel.ashx?OrderSN=" + Eval("OrderNumber") + "'>取消订单</a>"%>
                                            </td>--%>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="12">
                                            <%=_pager %>
                                        </td>
                                    </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
