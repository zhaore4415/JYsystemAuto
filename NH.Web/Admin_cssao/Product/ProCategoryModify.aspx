<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProCategoryModify.aspx.cs"
    Inherits="NH.Web.adm.Product.ProCategoryModify" %>

<%@ Register Src="~/Admin_cssao/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="~/Admin_cssao/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                        <a href="<%=ListUrl %>">返回</a>-> 添加</h2>
                    <div class="widget-box">
                        <div class="widget-content nopadding">
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            上级分类：
                                        </td>
                                        <td class="td-2">
                                            <asp:DropDownList runat="server" ID="ddlCategory">
                                                <asp:ListItem Selected="True" Value="0">作为顶级分类</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            分类名称：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtName" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX tr-2">
                                        <td class="td-1">
                                            备注：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX tr-2" style="display: none">
                                        <td class="td-1">
                                            类别图标：
                                        </td>
                                        <td class="td-2">
                                            <asp:PlaceHolder runat="server" ID="phImg">
                                                <asp:Image runat="server" ID="img" /><br />
                                                <br />
                                            </asp:PlaceHolder>
                                            <asp:FileUpload runat="server" ID="file" />(点击重新上传图标)
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            显示顺序
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtSort" CssClass="txtCls"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            状态：
                                        </td>
                                        <td class="td-2">
                                            <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                                                <asp:ListItem Value="0">隐藏</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                        </td>
                                        <td>
                                            <div>
                                                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btn btn-inverse" OnClick="btnSubmit_Click" />
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
    <%--  <div class="box">
      
        <div class="youce">
            <div class="xinxi-3">
                <div class="dingdanliebiao">
                    <h1 class="liebiao">
                        <a href="<%=ListUrl %>">分类管理</a> -> 添加</h1>
                </div>
                <div class="accounting_con2" style="width: 1000; float: left; height: auto;">
                    <table width="100%" cellpadding="0" cellspacing="0" class="utable">
                        <tr>
                            <th>
                                上级分类：
                            </th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlCategory">
                                    <asp:ListItem Selected="True" Value="0">作为顶级分类</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                分类名称：
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtName" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                备注：
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <th>
                                类别图标：
                            </th>
                            <td>
                                <asp:PlaceHolder runat="server" ID="phImg">
                                    <asp:Image runat="server" ID="img" /><br />
                                    <br />
                                </asp:PlaceHolder>
                                <asp:FileUpload runat="server" ID="file" />(点击重新上传图标)
                            </td>
                        </tr>
                        <tr>
                            <th>
                                显示顺序
                            </th>
                            <td>
                                <asp:TextBox runat="server" ID="txtSort" CssClass="txtCls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th>
                                是否首页显示
                            </th>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rblIsHome" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                状态：
                            </th>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rblStatus" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                                    <asp:ListItem Value="0">隐藏</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>--%>
    </form>
</body>
</html>
