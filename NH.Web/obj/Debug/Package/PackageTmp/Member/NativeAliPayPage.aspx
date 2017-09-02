<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NativeAliPayPage.aspx.cs"
    Inherits="WxPayAPI.NativeAliPayPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;image/gif;charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>支付宝支付-扫码支付</title>
    <script src="../Script/jquery-1.7.2.min.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        function showUnreadNews() {
            $(document).ready(function () {
                $.ajax({
                    type: "GET",
                    url: "../Handler/ResultOrderStatus.ashx?OrderSN=<%=Request.QueryString["OrderSN"] %>",
                    cache: false,
                    data: {

                },
                success: function (data) {
//                    alert(data);
                    if (data == 1) {
                   location.href = "Queryorder.aspx";
                    }
                }
            });
        });
        }
        setInterval('showUnreadNews()', 5000);
    </script>--%>
</head>
<body>
    <form id="formshaoma" runat="server">
    <div style="margin-left: 10px; color: #00CD00; font-size: 30px; font-weight: bolder;">
        扫码支付</div>
    <br />
    <asp:Image ID="Image1" runat="server" Style="width: 200px; height: 200px;" />
    <a href="Product.aspx?OrderSN=<%=Request.QueryString["OrderSN"] %>">返回产品列表</a>  |  <a href="Queryorder.aspx">返回订单列表</a>
    <%--<asp:Button ID="Button1" runat="server" Text="关闭窗口" OnClick="Button1_Click" />--%></form>
</body>
</html>
