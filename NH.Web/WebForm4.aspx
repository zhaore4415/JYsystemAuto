<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="NH.Web.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript" src="Script/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Script/jquery.zclip.min.js"></script>
    <div class="copybox clearfix">
        <div class="copybox-n1 clearfix">
            <div style="width: 232px; float: left; height: 36px; overflow: hidden; zoom: 1">
                <input type="text" id="mytxt1" value="点击右侧复制按钮复制" class="n1input">
            </div>
            <div style="width: 48px; height: 36px; position: absolute; margin-left: 232px; *margin-left: 0px;
                _margin-left: 0">
                <button id="copy_input1" class="n1-btn">
                    复制</button>
            </div>
        </div>
        <div class="copybox-n2 clearfix">
            <div style="width: 232px; float: left; height: 36px; overflow: hidden; zoom: 1">
                <input type="text" id="mytxt2" value="点击右侧复制按钮复制" class="n1input">
            </div>
            <div style="width: 48px; height: 36px; position: absolute; margin-left: 232px; *margin-left: 0px;
                _margin-left: 0">
                <button id="copy_input2" class="n1-btn">
                    复制</button>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {

            $('#copy_input1').zclip({
                path: 'js/ZeroClipboard.swf',
                copy: function () { return $('#mytxt1').val(); },
                afterCopy: function () { alert("复制成功"); }
            });

            $('#copy_input2').zclip({
                path: 'js/ZeroClipboard.swf',
                copy: function () { return $('#mytxt2').val(); },
                afterCopy: function () { alert("复制成功"); }
            });
        });
    </script>
    </form>
</body>
</html>
