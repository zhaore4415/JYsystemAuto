<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="NH.Web.adm.Product.Product" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%=CssAndScript %>
    <script src="../Script/overlib.js" type="text/javascript"></script>
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
    <link href="../css/index.css" rel="stylesheet">
    <script type="text/javascript">
        $(document).ready(function () {
            $('[name^=txtSort_]').change(function () {
                $('[name=chkItem][value=' + $(this).attr('name').replace('txtSort_', '') + ']').attr('checked', true);
            });
            $('#btnUpdateSort').click(function () {
                if ($('[name=chkItem]:checked').length == 0) { alert('请选择要修改排序的项'); return false; }
            });

            $('[name^=txtHomeSort_]').change(function () {
                $('[name=chkItem][value=' + $(this).attr('name').replace('txtHomeSort_', '') + ']').attr('checked', true);
            });
            $('#btnUpdateSort').click(function () {
                if ($('[name=chkItem]:checked').length == 0) { alert('请选择要修改排序的项'); return false; }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:Head ID="Head2" runat="server" />
    <uc1:left ID="left1" runat="server" />
    <div id="content">
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <h2>
                        产品管理</h2>
                    <div class="searchbox">
                        产品快速通道：<asp:DropDownList runat="server" ID="ddlCategory">
                            <asp:ListItem Value="0">选择分类</asp:ListItem>
                        </asp:DropDownList>
                        关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="input-text"></asp:TextBox>
                        <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" CssClass="btn btn-inverse btn-mini" />
                        <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" CssClass="btn btn-inverse btn-mini" />
                        <input type="button" value="添加" class="btn btn-inverse btn-mini" onclick="window.location.href=<%=PagePreFix %>Add.aspx" />
                    </div>
                    <div class="widget-box">
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
                                                    产品名称
                                                </th>
                                                <th>
                                                    产品型号
                                                </th>
                                                <th>
                                                    出售价
                                                </th>
                                                <th>
                                                    积分单价
                                                </th>
                                                <th>
                                                    分类名称
                                                </th>
                                                <th>
                                                    图片
                                                </th>
                                                <th>
                                                    当前库存
                                                </th>
                                                <th>
                                                    添加时间
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
                                                <%#Eval("Name")%>
                                            </td>
                                            <td>
                                                <%#Eval("Model")%>
                                            </td>
                                            <td>
                                                <%#Eval("ChuShou")%>
                                            </td>
                                            <td>
                                                <%#Eval("JiFenPrice")%>
                                            </td>
                                            <td>
                                                <%#Eval("CategoryName")%>
                                            </td>
                                            <td>
                                                <a href="#" onmouseover="return overlib('<IMG SRC=/Upload/ProductImg/<%# Eval("Pic") %> width=200>', CAPTION, '<%# Eval("Pic") %>',FGCOLOR, '#fcfcfc', BGCOLOR, '#0080C0', CAPCOLOR, '#ffffff', BORDER, 2, CLOSETEXT, 'Close');"
                                                    onmouseout="nd();">
                                                    <img src='/Upload/ProductImg/<%# Eval("Pic") %>' width="100" /></a>
                                            </td>
                                            <td>
                                                <%# Eval("NowKuCun")%>
                                            </td>
                                            <td>
                                                <%# Eval("AddTime")%>
                                            </td>
                                            <td>
                                                <a href="ProductModify.aspx?id=<%#Eval("Id")%>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">
                                                    删除</a>
                                            </td>
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
    <div id="overDiv" style="z-index: 1000; visibility: hidden; position: absolute">
    </div>
</body>
</html>
