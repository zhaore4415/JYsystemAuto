<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="return_url.aspx.cs" Inherits="NH.Web.alipaydirect.return_url" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>页面跳转同步通知页面</title>
    <script language="javascript" type="text/javascript">
        var i = 3;
        var intervalid;
        intervalid = setInterval("fun()", 1000);
        function fun() {
            if (i == 0) {
                window.location.href = "http://fx.buccker.net/Member/Queryorder.aspx";
                clearInterval(intervalid);
            }
            document.getElementById("mes").innerHTML = i;
            i--;
        } 
</script> 
  <%--<script type="text/javascript">
        function showUnreadNews() {
            $(document).ready(function () {
                $.ajax({
                    type: "GET",
                    url: "../Handler/ResultOrderStatus.ashx?OrderSN=<%=Request.QueryString["out_trade_no"] %>",
                    cache: false,
                    data: {

                },
                success: function (data) {

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
    <form id="form1" runat="server">
    <p>将在 <span id="mes">3</span> 秒钟后返回订单页面</p> 
    </form>
</body>
</html>