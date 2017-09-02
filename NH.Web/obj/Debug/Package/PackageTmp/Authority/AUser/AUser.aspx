<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AUser.aspx.cs" Inherits="NH.Web.adm.Authority.AUser.AUser" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
  <%--  <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/css/bootstrap-responsive.min.css" />
    <link rel="stylesheet" href="/css/uniform.css" />
    <link rel="stylesheet" href="/css/select2.css" />
    <link rel="stylesheet" href="/css/matrix-style.css" />
    <link rel="stylesheet" href="/css/matrix-media.css" />
    <link href="/font-awesome/css/font-awesome.css" rel="stylesheet" />--%>
    <%--<link href='http://fonts.useso.com/css?family=Open+Sans:400,700,800' rel='stylesheet'
        type='text/css'>--%>
    <link href="../../css/index.css" rel="stylesheet">
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
    <uc2:Head ID="Head1" runat="server" />
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
                        会员管理</h2>
                    <div class="searchbox">
                        <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btn btn-inverse btn-mini" />
                        <input type="button" value="添加" class="btn btn-inverse btn-mini" onclick="window.location.href='<%=PagePreFix %>Add.aspx'" />
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
                                                    <strong>帐号</strong>
                                                </th>
                                                <th>
                                                    <strong>姓名</strong>
                                                </th>
                                                <th>
                                                    <strong>角色</strong>
                                                </th>
                                                <th>
                                                    <strong>上次登录时间</strong>
                                                </th>
                                                <th>
                                                    <strong>上次登录IP</strong>
                                                </th>
                                                <th>
                                                    <strong>是否付了定金</strong>
                                                </th>
                                                <th>
                                                    <strong>身份</strong>
                                                </th>
                                                <th>
                                                    <strong>审核</strong>
                                                </th>
                                                <th>
                                                    <strong>状态</strong>
                                                </th>
                                                <th>
                                                    <strong>操作</strong>
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
                                                <%#Eval("LoginName")%>
                                            </td>
                                            <td>
                                                <%#Eval("Realname")%>
                                            </td>
                                            <td>
                                                <%#  GetVipName((int)Eval("RoleType"))%>
                                            </td>
                                            <td>
                                                <%#Eval("LoginTime")%>
                                            </td>
                                            <td>
                                                <%#Eval("LoginIP")%>
                                            </td>
                                            <td>
                                                <%#  GetIsPayment((int)Eval("IsPayment"))%>
                                            </td>
                                             <td>
                                                <%#  GetShenFenType((int)Eval("IsCheckType"))%>
                                            </td>
                                             <td>
                                                <%# NH.Web.adm.WebBase.ModelEnum.VerifyStatusDescc((NH.Web.adm.WebBase.ModelEnum.VerifyStatus)((int)Eval("VerifyStatus")), (int)Eval("Id"))%>
                                            </td>
                                            <td>
                                                <%# NH.Web.adm.WebBase.ModelEnum.AUserStatusDesc((NH.Web.adm.WebBase.ModelEnum.AUserStatus)((int)Eval("Status"))) %>
                                            </td>

                                            <td>
                                                <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">
                                                    删除</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td colspan="10">
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
    <%--  <script src="js/jquery.min.js"></script>
    <script src="js/jquery.ui.custom.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.uniform.js"></script>
    <script src="js/select2.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script src="js/matrix.js"></script>
    <script src="js/matrix.tables.js"></script>--%>
</body>
</html>
