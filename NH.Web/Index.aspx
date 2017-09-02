<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="NH.Web.Index" %>

<%@ Register Src="Controls/LoginHead.ascx" TagName="LoginHead" TagPrefix="uc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BK护肤品经营者系统
    </title>
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/matrix-style.css" />
    <link rel="stylesheet" href="css/matrix-media.css" />

    <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="css/Style.css" rel="stylesheet" />
    <script>
        function Login() {
            var LoginName = $("#txtLoginName").val();
            var Password = $("#txtPassword").val();
            var Cookic = $("#Cookic").val();

            if (LoginName == "") {
                alert("请输入会员名");
                return false;
            }
            if (Password == "") {
                alert("请输入密码");
                return false;
            }
            $.ajax({
                type: "post",
                url: "/Ajax/Before/login.ashx",
                data: { "LoginName": LoginName, "Password": Password, "Cookic": Cookic },
                success: function (status) {
                    if (status == "1") {
                        alert('登录成功');
                        window.location.href = 'Member/MemberIndex.aspx';
                    }
                    else if (status == "2") {
                        alert('用户名不存在');
                    }
                    else if (status == "3") {
                        alert('密码错误');
                    }
                    else if (status == "4") {
                        alert('该用户已禁用');
                    }
                    else if (status == "0") {
                        alert('登录失败！');
                    }
                },
                error: function () {
                    alert("登录失败！");
                }

            });
        }
    </script>
</head>
<body>

    <uc1:LoginHead ID="LoginHead1" runat="server" />
    <section>
        <div class="container mt50">
            <div class="widget-box">
                <div class="col-md-6 column widget-content col-center-block">


                    <div class="form-group text-center">
                        <h2>登录</h2>
                    </div>
                    <div class="form-group">
                        <label for="txtLoginName">用户名：</label><input type="text" class="form-control" id="txtLoginName" name="LoginName" required />
                    </div>

                    <div class="form-group">
                        <label for="txtPassword">密码：</label><input type="password" class="form-control" id="txtPassword" name="Password" required />
                    </div>
                    <div class="form-group">
                        <input id="Cookic" type="checkbox" name="Cookic" />自动登录
                    </div>
                    <button type="submit" class="btn btn-primary" onclick="Login()">登录</button>
                    <button type="button" class="btn btn-default ml100" onclick="javascript:window.location.href='Registered1.aspx'">注册</button>

                </div>
            </div>
        </div>
    </section>
    <footer></footer>

</body>
</html>
