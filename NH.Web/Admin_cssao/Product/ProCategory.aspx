<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProCategory.aspx.cs" Inherits="NH.Web.adm.Product.ProCategory" %>

<%@ Register Src="~/Admin_cssao/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="~/Admin_cssao/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分类管理</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:Head ID="Head2" runat="server" />
    <uc1:left ID="left1" runat="server" />
    <div id="content">
        <!--  <div id="content-header">
    <div id="breadcrumb"> <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i> Home</a> <a href="#" class="current">Tables</a> </div>
    <h1>Tables</h1>
  </div>-->
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <h2>
                        产品类别管理</h2>
                    <div class="searchbox">
                        <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btn btn-inverse btn-mini" />
                        <input type="button" value="添加" class="btn btn-inverse btn-mini" onclick="window.location.href=<%=PagePreFix %>Add.aspx" />
                    </div>
                    <div class="widget-box">
                        <!--          <div class="widget-title"> <span class="icon"> <i class="icon-th"></i> </span>
            <h5>Static table</h5>
          </div>-->
                        <div class="widget-content nopadding table-responsive">
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <input type="checkbox" id="chkAll" title="全选" />
                                                </th>
                                                <th>
                                                    分类名称
                                                </th>
                                                <th>
                                                    排序
                                                </th>
                                                <th>
                                                    是否显示
                                                </th>
                                                <th>
                                                    操作
                                                </th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td>
                                                <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                                            </td>
                                            <td>
                                                <%# Eval("Name") %>
                                            </td>
                                            <td>
                                                <%# Eval("Sort") %>
                                            </td>
                                            <td>
                                                <%# (bool)Eval("IsShow") ? "显示" : "<font color='red'>关闭</font>"%>
                                            </td>
                                            <td>
                                                <a href="ProCategoryModify.aspx?id=<%#Eval("ID")%>&Depth=<%#Eval("Depth")%>">编辑</a>
                                                | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">删除</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <%--  <%=_pager %>--%>
    </form>
</body>
</html>
