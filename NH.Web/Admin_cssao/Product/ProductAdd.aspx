<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="NH.Web.adm.Product.ProductAdd"
    ValidateRequest="false" %>

<%@ Register Src="~/Admin_cssao/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="~/Admin_cssao/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $('#solution > li > ul > li').filter(':has(:checked)').addClass('selected').end().each(function () {
                var li = $(this);
                li.find('input:checkbox').click(function () {
                    if ($(this).is(':checked')) { li.addClass('selected') } else { li.removeClass('selected') }
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnAddFile').click(function () {
                $(this).before($('#temp').clone().removeAttr('id'));
            });
        });
        $(document).ready(function () {
            $('#btnAddFile2').click(function () {
                $(this).before($('#temp2').clone().removeAttr('id'));
            });
        });

        function count() {
            $('#imgcount').val($('[name=filepic]').length);


            return true;
        }
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
                        <a href="<%=ListUrl %>">返回</a>-> 添加</h2>
                    <div class="widget-box">
                        <div class="widget-content nopadding">
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            产品分类：
                                        </td>
                                        <td class="td-2">
                                            <asp:DropDownList runat="server" ID="ddlCategory">
                                                <asp:ListItem Selected="True" Value="0">选择分类</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lbpid" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            产品名称：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtName" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            产品ID(条形码)：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtBarcode" ></asp:TextBox>
                                            <asp:Button ID="bnBarcode" runat="server" Text="生成条形码" OnClick="bnBarcode_Click"
                                                CssClass="btn-inverse" />
                                        </td>
                                    </tr>
                                       <tr class="odd gradeX">
                                         <td class="td-1">
                                            产品型号
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtModel"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            成本价：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtChengBen" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            出售价：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtChuShou" runat="server" >0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            可积分：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtKeJiFen" runat="server" >0</asp:TextBox>*当购买了产品
                                            所产生的积分-分销系统产品下单管理
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            积分单价：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtJiFenPrice" runat="server" >0</asp:TextBox>
                                            *用于分销系统的积分兑换功能
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            入库总量：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtRuKuSum" runat="server" >0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            出库总量：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtChuKuSum" runat="server" >0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            当前库存：
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox ID="txtNowKuCun" runat="server" >0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            图片：
                                        </td>
                                        <td class="td-2">
                                            <asp:FileUpload runat="server" ID="file" />图片大小 158*105最佳,或者等比例
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            商品描述：
                                        </td>
                                        <td class="td-2">
                                            <CKEditor:CKEditorControl ID="ckContent" runat="server" BasePath="../_ckeditor"></CKEditor:CKEditorControl>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <th>
                                            是否VIP产品：
                                        </th>
                                        <td>
                                            <asp:RadioButtonList runat="server" ID="rblIsVip" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">是</asp:ListItem>
                                                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
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

    </form>
</body>
</html>
