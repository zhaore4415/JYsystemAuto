<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductOne.aspx.cs" Inherits="NH.Web.adm.Member.ProductOne" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品表列</title>
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
        .dingdanliebiao
        {
            width: 300px;
            float: left;
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
    <script type="text/javascript">
       
        /*商品数量+1*/
        function numAdd(num) {
            $('[name=chkItem]').end().find('[value=' + num + ']').attr('checked', true);
            var num_add = parseInt($("#quantity" + num + "").val()) + 1;

            if ($("#quantity" + num + "").val() == "") {
                num_add = 1;
            }
            $("#quantity" + num + "").val(num_add);

            var total = parseFloat($("#price" + num + "").html()) * parseInt($("#quantity" + num + "").val());
            var jifen = parseFloat($("#jifen" + num + "").html()) * parseInt($("#quantity" + num + "").val());
            //            $("#totalPrice" + num + "").val(total);
            $("#totalPrice" + num + "").val(total);
            $("#KeJiFen" + num + "").val(jifen);
//            StatSum("totalPrice", "spAAPrice");
            SumList();
        }
        /*商品数量-1*/
        function numDec(num) {
            $('[name=chkItem]').end().find('[value=' + num + ']').attr('checked', true);
            var num_dec = parseInt($("#quantity" + num + "").val()) - 1;

            if (num_dec < 1) {
                //购买数量必须大于或等于1
                alert("数量不能小于 1");
            } else {
                $("#quantity" + num + "").val(num_dec);

                var total = parseFloat($("#price" + num + "").html()) * parseInt($("#quantity" + num + "").val());
                var jifen = parseFloat($("#jifen" + num + "").html()) * parseInt($("#quantity" + num + "").val());

                $("#totalPrice" + num + "").val(total);
                $("#KeJiFen" + num + "").val(jifen);
               
                //                StatSum("totalPrice", "spAAPrice");
                SumList();
            }
        }
        $(function () {
            if ($('[name=chkItem]:checked').length == 0) {
                var total = 0;

                $("#spAAPrice").html(total.toFixed(2));
            }
            $('#chkAll').click(function () {
                $('[name=chkItem]').attr('checked', $(this).attr('checked') ? true : false);
                var total = 0;
                $("input[name=chkItem]").each(function () {
                    if ($(this).attr("checked")) {
                        total += parseFloat($("#totalPrice" + $(this).val()).val());

                        $("#spAAPrice").html(total.toFixed(2));
                        //                      
                    }
                    else {
                        total = 0;

                        $("#spAAPrice").html(total.toFixed(2));
                    }

                });
            });

            $("input[name='chkItem']:checkbox").click(function () {

                SumList();

            });

        })
        function SumList() {
            var total = 0;
            $("input[name=chkItem]").each(function () {
                if ($(this).attr("checked")) {
                    total += parseFloat($("#totalPrice" + $(this).val()).val());

                    $("#spAAPrice").html(total.toFixed(2));
                    //                      
                }
                else {
                    if ($('[name=chkItem]:checked').length == 0) {
                        total = 0;

                        $("#spAAPrice").html(total.toFixed(2));
                    }
                }

            });
        }
//        function StatSum(lblId, spId) {
//            var sum = 0;

//            $("input[id^='" + lblId + "']").each(function () {
//                var r = /^-?\d+$/; //正整数 
//                if ($(this).val() != '' && !r.test($(this).val())) {
//                    $(this).val();  //正则表达式不匹配置空 
//                    sum += parseInt($(this).val());
//                }
//                else if ($(this).val() != '') {
//                    sum += parseInt($(this).val());
//                }

//                $("#" + spId).text(sum);
//            });
//        }



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
                        下单列表</h2>
                    <div class="searchbox">
                        关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="input-text" placeholder="输入商家ID"></asp:TextBox>
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
                                                    <input type="checkbox" id="chkAll" title="全选" />
                                                </th>
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
                                                    <strong>总价</strong>
                                                </th>
                                                <th>
                                                    <strong>积分</strong>
                                                </th>
                                                <th>
                                                    <strong>共积分</strong>
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
                                                <%#Eval("ID")%>
                                            </td>
                                            <td>
                                                <%#Eval("Name")%>
                                            </td>
                                            <td>
                                                <%#Eval("CategoryName")%>
                                            </td>
                                            <td>
                                                <span onclick="numDec(<%#Eval("ID")%>)" class="minus"></span>
                                                <input type="text" id="quantity<%#Eval("ID")%>" value="1" name="quantity<%#Eval("ID")%>"
                                                    class="txtCls" /><span class="plus " onclick="numAdd(<%#Eval("ID")%>)"></span>
                                            </td>
                                            <td>
                                                <span id="price<%#Eval("ID")%>">
                                                    <%#Eval("ChuShou")%></span>元
                                            </td>
                                            <td>
                                                <input id="totalPrice<%#Eval("ID")%>" type="text" name="totalPrice<%#Eval("ID")%>"
                                                    value="<%#Eval("ChuShou")%>" readonly="readonly" class="txtCls"></input><span>元</span>
                                            </td>
                                            <td>
                                                <span id="jifen<%#Eval("ID")%>">
                                                    <%#Eval("KeJiFen")%></span>
                                            </td>
                                            <td>
                                                <input id="KeJiFen<%#Eval("ID")%>" type="text" name="KeJiFen<%#Eval("ID")%>" value="<%#Eval("KeJiFen")%>"
                                                    readonly="readonly" class="txtCls"></input>
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
                        <div class="tijiaodingdan">
                            <p>
                                <a href="PayDetail.aspx?ispayment=<%=ispayment %>&OrderSN=<%=otherSN %>">>>购物车</a>
                                总计：¥<span id="spAAPrice"></span>元</p>
                            <asp:Label ID="lblOpenId" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Label ID="lbotherSN" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Button runat="server" ID="btnSubmit" Text="提交订单" CssClass="btn btn-inverse"
                                OnClick="btnSubmit_Click" OnClientClick="return beforesubmit()" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
