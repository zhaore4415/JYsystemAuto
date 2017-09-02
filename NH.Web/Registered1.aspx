<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Registered1.aspx.cs"
    Inherits="NH.Web.Cssao.Registered1" %>

<%@ Register Src="Controls/LoginHead.ascx" TagName="LoginHead" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/matrix-style.css" />
    <link rel="stylesheet" href="css/matrix-media.css" />
    <link href="css/Style.css" rel="stylesheet" />
    <style>


        .widget-content {
            width: 50%;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:LoginHead ID="LoginHead1" runat="server" />
        <section>
            <div class="container row-fluid">

                <div class="widget-box">
                    <div class="widget-content nopadding">
                        <div class="form-group text-center">
                            <h2>会员注册</h2>
                        </div>
                        <div class="form-group">
                            <label for="txtPhone">
                                手机号：
                            </label>

                            <input placeholder="*手机号" id="txtPhone" name="Phone" class="form-control" />

                        </div>
                        <div class="form-group">
                            <label for="txtPassword">
                                密码：
                            </label>

                            <input placeholder="*密码" id="txtPassword" type="password" name="Password" class="form-control" />

                        </div>
                        <div class="form-group">
                            <label for="txtRPassword">
                                确认密码：
                            </label>

                            <input placeholder="*确认密码" id="txtRPassword" type="password"  name="RPassword" class="form-control" />

                        </div>
                        <div class="form-group">
                            <label for="txtCode">
                                手机验证码：
                            </label><div>
                            <span style="float:left">
                            <input placeholder="*验证码" id="txtCode" name="Code" class="form-control" /></span> &nbsp;<asp:Button ID="bt_Send" runat="server" Text="发送验证码" CssClass="btn btn-default" />
                            </div>
                        </div>


                        <div class="form-group">

                            <asp:Button runat="server" ID="btnSubmit" Text=" 提交 " OnClick="btnSubmit_Click" CssClass="btn btn-primary"
                                OnClientClick="return beforesubmit()" />

                        </div>
                    </div>
                </div>

            </div>
        </section>
    </form>
    <!--Footer-part-->
    <!--end-Footer-part-->
<%--    <script src="js/jquery.min.js"></script>
    <
    <script src="js/bootstrap.min.js"></script>

    <script src="js/select2.min.js"></script>


    <script src="JS/jquery-1.2.1.js" type="text/javascript"></script>--%>


    <script type="text/javascript">
        function beforesubmit() {
            if ($.trim($('#txtPhone').val()) == "") { alert('请填写手机'); $("#txtPhone").focus(); return false; };
            if ($.trim($('#txtPassword').val()) == "") { alert('请填写密码'); $("#txtPassword").focus(); return false; };
            if ($.trim($('#txtRPassword').val()) == "") { alert('请重新输入密码'); $("#txtRPassword").focus(); return false; };
            if ($.trim($('#txtPassword').val()) != $.trim($('#txtRPassword').val())) { alert('两次输入的密码不一致'); return false; };
            if ($.trim($('#txtCode').val()) == "") { alert('请填写验证码！'); $("#txtCode").focus(); return false; };
            //            if (isNaN($("#zcSerialNumber").val())) { alert("推荐人ID只能为数字！"); $("#zcSerialNumber").focus(); return false; }

            if (!$("#txtPhone").val().match(/^1[3|4|5|7|8][0-9]\d{8}$|^\d{8}$/)) { alert("手机号码格式不正确！"); $("#txtPhone").focus(); return false; }

            return true;
        }

    </script>
</body>
</html>
