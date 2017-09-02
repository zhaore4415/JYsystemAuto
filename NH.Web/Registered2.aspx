<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Registered2.aspx.cs"
    Inherits="NH.Web.Cssao.Registered2" %>

<%@ Register Src="Controls/LoginHead.ascx" TagName="LoginHead" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>完善资料</title>
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
                            <h2>会员注册（完善资料）</h2>
                        </div>
                        <div class="form-group">
                            <label for="txtLoginName">
                                姓名：
                            </label>

                            <input placeholder="*用户名" id="txtLoginName" name="LoginName" class="form-control" runat="server" />

                        </div>
                        <div class="form-group">
                            <label for="txtPhone">
                                手机号：
                            </label>

                            <input placeholder="手机号" id="txtPhone" name="Phone" class="form-control" readonly="readonly" runat="server" />

                        </div>
                        <div class="form-group">
                            <label for="txtPassword">
                                密码：
                            </label>

                            <input placeholder="密码" id="txtPassword" type="password" name="Password" class="form-control" runat="server" />
                            <%--<input type="hidden"   id="hidPassword" name="hidPassword" value="<%=NH.Web.UserBase.Current.Password%>" />--%>
                        </div>
                        <div class="form-group">
                            <label for="txtSex">
                                性别：
                            </label>
                            <input type="radio" runat="server" id="txtSex1" name="Sex" checked value="1"/>男
                            <input type="radio" runat="server" id="txtSex2" name="Sex" alue="0"/>女

                        </div>
                        <div class="form-group">
                            <label for="txtEmail">
                                邮箱：
                            </label>

                            <input placeholder="邮箱" id="txtEmail" name="Email" class="form-control" runat="server" />
                            <%--<input placeholder="QQ/微信" id="zcQQWinXin" name="zcQQWinXin" />--%>
                        </div>


                        <div class="form-group">
                            <label for="txtEmail">
                                收货地址：
                            </label>

                            <input id="txtAddress" name="Address" placeholder="收货地址" class="form-control" runat="server" />

                        </div>
                        <div class="form-group">
                            <label for="txtIdNumber">
                                身份证号码：
                            </label>

                            <input id="txtIdNumber" name="IdNumber" placeholder="身份证号码" class="form-control" runat="server" />

                        </div>
                        <div class="form-group">
                            <label for="txtIdNumber">
                                身份证上传( 正面)：
                            </label>
                            <input type="file" id="inputfile1">

                            <br />
                            <label for="txtIdNumber">
                                身份证上传(反面)：
                            </label>
                            <input type="file" id="inputfile2">
                        </div>
                        <div class="form-group">
                            <label for="txtOpenbank">
                                开户银行
                            </label>
                            <input id="txtOpenbank" name="Openbank" placeholder="开户银行" class="form-control" runat="server"/>

                        </div>
                        <div class="form-group">
                            <label for="txtOpenbankCard">
                                银行卡号
                            </label>
                            <input id="txtOpenbankCard" name="OpenbankCard" placeholder="银行卡号" class="form-control" runat="server"/>

                        </div>
                        <div class="form-group">
                            <label for="txtOpenCity">
                                开户银行地址
                            </label>
                            <input id="txtOpenCity" name="OpenCity" placeholder="开户城市" class="form-control" runat="server"/>

                        </div>
                        <div class="form-group">

                            <asp:Button runat="server" ID="btnSubmit" Text=" 保存 " OnClick="btnSubmit_Click" CssClass="btn btn-primary"
                                OnClientClick="return beforesubmit()" /><asp:Button ID="bn_JumpOver" runat="server" Text="跳过" CssClass="btn btn-default ml100" />

                        </div>

                    </div>
                </div>

            </div>
        </section>
    </form>
    <!--Footer-part-->
    <!--end-Footer-part-->

    <script type="text/javascript">
        function beforesubmit() {
            if ($.trim($('#txtLoginName').val()) == "") { alert('请填写用户名'); $("#txtLoginName").focus(); return false; };
            if ($.trim($('#txtPassword').val()) == "") { alert('请填写密码'); $("#txtPassword").focus(); return false; };

            return true;
        }

    </script>
</body>
</html>
