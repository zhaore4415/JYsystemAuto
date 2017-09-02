<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs"
    Inherits="NH.Web.adm.Default" %>

<%@ Register Src="Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BK护肤品经营者系统</title>
    <%--    <link href="css/index.css" rel="stylesheet">--%>
    <script src="Script/jquery.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" />
    <%--<link rel="stylesheet" href="css/uniform.css" />--%>
    <%--<link rel="stylesheet" href="css/select2.css" />--%>
    <link rel="stylesheet" href="css/matrix-style.css" />
    <link rel="stylesheet" href="css/matrix-media.css" />
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<link href='http://fonts.useso.com/css?family=Open+Sans:400,700,800' rel='stylesheet'
        type='text/css'>--%>
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
            float: left;
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
        .td-2 .input-1
        {
            background-color: #FFF;
            border: #666 solid 1px;
            text-indent: 2px;
            float: left;
        }
        .td-2 .input-2
        {
            background-color: #FFF;
            border: #666 solid 1px;
            text-indent: 2px;
            float: left;
            margin-right: 20px;
        }
        .td-2 .searchbox
        {
            float: left;
            margin-right: 10px;
            width: 20%;
        }
        .td-3 p
        {
            float: left;
            margin-right: 10px;
        }
        .td-3  input[type="text"]
        {
            float: left;
        }
        .td-3 div
        {
            overflow: hidden;
        }
        .td-3 button
        {
            margin-left: 46px;
        }
        .tr-1
        {
            display: none;
        }
        .yonghu-3
        {
            width: 275px;
            height: 70px;
            clear: both;
            display: none;
            position: absolute;
            z-index: 1;
            background: #F0F0F0;
            top: 265px;
            border: 1px solid #999;
        }
        .yonghu-3 .xiugaiyonghuming #FilePic1
        {
            width: 200px;
        }
        .xiugaiyonghuming
        {
            margin-top: 5px;
            margin-left: 20px;
        }
        .btnbox
        {
            margin-left: 20px;
        }
        .xiugaimima{border-bottom:solid 1px #cbcbcb;}
.xiugaimima .top{ font-size:24px; line-height:64px; margin-left:62px;}
        
        .yonghumingbox
        {
            clear: both;
            margin-top: 20px;
            overflow: hidden;
            margin-bottom: 20px;
        }
        .yonghumingbox .touxiang
        {
            float: left;
            width: 140px;
            height: 160px;
            border: #999 1px solid;
            margin-right: 20px;
        }
        .yonghumingbox .yonghuming
        {
            float: left;
        }
        .yonghuming p
        {
            display: block;
        }
        .yonghuming-2 input[type="text"]
        {
            background-color: #FFF;
            border: #666 solid 1px;
            text-indent: 2px;
        }
        .yonghuming-2 div
        {
            margin-top: 10px;
        }
        .yonghuming-2 button
        {
            margin-right: 30px;
        }
        .yonghuming-2
        {
            display: none;
        }
        /*@media(max-width:768px){
	.top .fenxiaoguanli{ display:none;}
	}*/
    </style>
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
                        个人中心</h2>
                    <div class="hengxian">
                    </div>
                    <div class="yonghumingbox">
                        <div class="touxiang">
                            <asp:Image runat="server" ID="img" Width="140" />
                            <div style="clear: both">
                            </div>
                            <span class="xgyonghupic" style="display: block;">
                                <img class="xiugai" src="images/xiugai.png"></span>
                            <div class="yonghu-3">
                                <div class="xiugaiyonghuming">
                                    <asp:FileUpload ID="FilePic1" runat="server" />
                                </div>
                                <div class="btnbox">
                                    <asp:Button ID="btnImg" runat="server" Text="保存" OnClick="btnImg_Click" CssClass="btn btn-inverse"
                                        OnClientClick="return imgsubmit()" />
                                    <input class="btn-5 btn btn-inverse" type="button" value="取消">
                                </div>
                            </div>
                        </div>
                        <div class="yonghuming">
                            <p>
                                代理号：<%=SerialNumber %></p>
                            <p>
                                等级：<%=GetVipName(RoleType)%></p>
                            <p>
                                <asp:Label ID="lbName" runat="server" Text=""></asp:Label><span class="xgyonghu"><img
                                    src="images/xiugai.png"></span></p>
                                    <p><%if (NH.Web.UserBase.CurAdmin.VerifyStatus == 0)
                                         {%> <span style='color:Red'>未审核</span> >><a href='Member/CheckMember.aspx'>提交审核</a><% }
                                         else if (NH.Web.UserBase.CurAdmin.VerifyStatus == 1)
                                         {%><span style='color:Blue'>审核通过</span> >><a href='Member/CheckMember.aspx'>查看</a><%
                                         }
                                         else if (NH.Web.UserBase.CurAdmin.VerifyStatus == -1)
                                         {%><span style='color:Red'>审核未通过</span> >><a href='Member/CheckMember.aspx'>重新提交</a><%} %></p>
                        </div>
                        <div class="yonghuming-2" style="display: none">
                            <div class="xiugaiyonghuming">
                                <asp:TextBox runat="server" ID="txtLoginName"></asp:TextBox>
                            </div>
                            <div class="btnbox">
                                <asp:Button ID="btnName" runat="server" CssClass="btn btn-inverse" Text="保存" OnClick="btnName_Click"
                                    OnClientClick="return beforesubmit()" />
                                <input type="button" value="取消" class="btn-4 btn btn-inverse" />
                            </div>
                        </div>
                        <%-- <div class="yonghuming-2">
                            <input>
                            <div>
                                <button class="btn btn-inverse">
                                    &nbsp;&nbsp;保存&nbsp;&nbsp;</button>
                                <button class="btn btn-inverse">
                                    &nbsp;&nbsp;取消&nbsp;&nbsp;</button>
                            </div>
                        </div>--%>
                    </div>
                    <%--  <script>
                        $(".yonghuming img").click(function () {
                            $(".yonghuming").hide()
                            $(".yonghuming-2").show()
                        })
                        $(".yonghuming-2 button").click(function () {
                            $(".yonghuming-2").hide()
                            $(".yonghuming").show()
                        })
                    </script>--%>
                    <div class="widget-box">
                        <!--          <div class="widget-title"> <span class="icon"> <i class="icon-th"></i> </span>
            <h5>Static table</h5>
          </div>-->
                        <div class="widget-content nopadding">
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <%--<tr class="odd gradeX">
                                        <td class="td-1">
                                            积分管理
                                        </td>
                                        <td class="td-2">
                                            <p class="p-1">
                                                <%=model.JeFen%></p>
                                        </td>
                                    </tr>--%>
                                    <%--<tr class="odd gradeX">
                                        <td class="td-1">
                                            享受折扣
                                        </td>
                                        <td class="td-2">
                                            <%=model.ZheKou%>
                                            (0.85就是85% 的折扣，默认为1)
                                        </td>
                                    </tr>--%>
                                    <tr class="odd gradeX tr-2">
                                        <td class="td-1">
                                            原密码
                                        </td>
                                        <td class="td-2">
                                            *******<p class="a-1" href="">
                                                修改</p>
                                        </td>
                                    </tr>
                                    <tr id="tr-1" class="odd gradeX tr-1" style="display: none">
                                        <td class="td-1">
                                            修改密码
                                        </td>
                                        <td class="td-2 td-3">
                                            <div>
                                                <p>
                                                    原密码</p>
                                                <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div>
                                                <p>
                                                    新密码</p>
                                                <asp:TextBox runat="server" ID="txtPassword1" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnPwd" runat="server" Text="保存" CssClass="btn btn-inverse" OnClick="btnPwd_Click"
                                                    OnClientClick="return pwdsubmit()" />
                                                <input class="btn-2 btn btn-inverse" type="button" value="取消" />
                                            </div>
                                        </td>
                                    </tr>
                              
                                    <%--<tr class="odd gradeX">
                                        <td class="td-1">
                                            来源
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" CssClass="input-1" ID="txtzcSource"></asp:TextBox>
                                            <p class="p-2">
                                                淘宝/京东/线下</p>
                                        </td>
                                    </tr>--%>
                                       <tr class="odd gradeX">
                                        <td class="td-1">
                                            性别
                                        </td>
                                        <td class="td-2">
                                            <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" >
                                                <asp:ListItem Value="0">男</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="1">女</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            邮箱
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            手机号码
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                                        </td>
                                    </tr>
                                 <%--   <tr class="odd gradeX">
                                        <td class="td-1">
                                            QQ/微信
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtQQWeiXin"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            公司/店铺名
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtCompany"></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                    <tr class="odd gradeX">
                                        <td class="td-1">
                                            收货地址
                                        </td>
                                        <td class="td-2">
                                            <asp:DropDownList ID="ddlBranchOne" runat="server" Width="95px">
                                                <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiddenBranchOne" runat="server" Value="-1" />
                                            <asp:DropDownList ID="ddlBranchTwo" runat="server" Width="95px">
                                                <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiddenBranchTwo" runat="server" Value="-1" />
                                            <asp:DropDownList ID="ddlBranchThird" runat="server" Width="95px">
                                                <asp:ListItem Value="-1" Selected="True">请选择</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hiddenBranchThird" runat="server" Value="-1" />
                                            <asp:TextBox runat="server" ID="txtJiaTingAddress"></asp:TextBox>
                                            <%-- <div class="btn-group searchbox">
                                                <button data-toggle="dropdown" class="btn dropdown-toggle">
                                                    请选择<span class="caret"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li><a href="#">超级管理员</a></li>
                                                    <li><a href="#">一级会员</a></li>
                                                    <li><a href="#">二级会员</a></li>
                                                </ul>
                                            </div>
                                            <div class="btn-group searchbox">
                                                <button data-toggle="dropdown" class="btn dropdown-toggle">
                                                    请选择<span class="caret"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li><a href="#">超级管理员</a></li>
                                                    <li><a href="#">一级会员</a></li>
                                                    <li><a href="#">二级会员</a></li>
                                                </ul>
                                            </div>
                                            <div class="btn-group searchbox">
                                                <button data-toggle="dropdown" class="btn dropdown-toggle">
                                                    请选择<span class="caret"></span></button>
                                                <ul class="dropdown-menu">
                                                    <li><a href="#">超级管理员</a></li>
                                                    <li><a href="#">一级会员</a></li>
                                                    <li><a href="#">二级会员</a></li>
                                                </ul>
                                            </div>--%>
                                        </td>
                                    </tr>
                                     <tr class="odd gradeX">
                                        <td class="td-1">
                                            身份证号码
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtShenFengZheng"></asp:TextBox>
                                        </td>
                                    </tr>
                                      <tr class="odd gradeX">
                                        <td class="td-1">
                                            开户银行
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtOpenbank"></asp:TextBox>
                                        </td>
                                    </tr>
                                      <tr class="odd gradeX">
                                        <td class="td-1">
                                            银行卡号
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtOpenbankCard"></asp:TextBox>
                                        </td>
                                    </tr>
                                      <tr class="odd gradeX">
                                        <td class="td-1">
                                            开户城市
                                        </td>
                                        <td class="td-2">
                                            <asp:TextBox runat="server" ID="txtOpenCity"></asp:TextBox>
                                        </td>
                                    </tr>
                                      <tr class="odd gradeX">
                                        <td class="td-1">
                                            身份证
                                        </td>
                                        <td class="td-2">
                                            <asp:HyperLink ID="hlimg1" runat="server">正面</asp:HyperLink>
                                            <asp:HyperLink ID="hlimg2" runat="server">反面</asp:HyperLink>

                                        </td>
                                    </tr>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <%--<tr class="odd gradeX">
                                            <td class="td-1">
                                                生成推荐码
                                            </td>
                                            <td class="td-2">
                                                <asp:TextBox runat="server" CssClass="input-2" ID="txtTJCode" ></asp:TextBox><asp:Label
                                                    ID="lbstatus" runat="server" Text=""></asp:Label>
                                                <asp:Button ID="btnTJcode" runat="server" CssClass="btn btn-inverse btn-mini" Text="点击生成"
                                                    OnClick="btnTJcode_Click" />
                                            </td>
                                        </tr>--%>
                                        <tr class="odd gradeX">
                                            <td colspan="2">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-inverse" Text="保存" OnClick="btnSubmit_Click" />
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </form>
    <script src="../JS/jquery-1.2.1.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
          
            GetByJquery();
            $("#ddlBranchOne").change(function () { GetCity() });
            $("#ddlBranchTwo").change(function () { GetDistrict() });
        });

        function GetByJquery() {

            $("#ddlBranchOne").empty(); //清空省份SELECT控件

            $.getJSON("/Handler/GetBranchOne.ashx", function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchOne"));
                });
                   
                    $('#ddlBranchOne').val(<%=model.fk_id %>);
                GetCity();
            });

        }

        function GetCity() {

            $("#ddlBranchTwo").empty(); //清空城市SELECT控件
            var url = "/Handler/GetBranchTwo.ashx?id=" + $("#ddlBranchOne").val();
            $.getJSON(url, function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchTwo"));
                });
                 
                    $('#ddlBranchTwo').val(<%=model.sk_id %>);
                GetDistrict();
            });
        }

        function GetDistrict() {
            $("#ddlBranchThird").empty(); //清空市区SELECT控件
            var url = "/Handler/GetBranchThird.ashx?id=" + $("#ddlBranchTwo").val();

            $.getJSON(url, function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchThird"));
                });
               
                    $('#ddlBranchThird').val(<%=model.tk_id %>);
            });
        }

    </script>
    <script type="text/javascript">
        $(".td-2 .a-1").click(function () {
//            $(".tr-1").show()
            document.getElementById("tr-1").style.display = "table-row";
//            $(".tr-1").style.display = 'table-row';  
            $(".tr-2").hide()
        })
        $(".td-2 .btn-2").click(function () {
            $(".tr-2").show()
//            $(".tr-1").hide()
            document.getElementById("tr-1").style.display = "none";
        })
        $(".xgyonghu").click(function () {
            $(".yonghuming-2").show();
            $(".yonghuming").hide();
        })
        $(".xgyonghupic").click(function () {
            $(".yonghu-3").show();

        })
        $(".btn-4").click(function () {
            $(".yonghuming-2").hide();
            $(".yonghuming").show();
        })
        $(".btn-5").click(function () {
            $(".yonghu-3").hide();

        })
        function beforesubmit() {
            if ($("#txtLoginName").val() == "") { alert("用户名不能为空"); return false; }

            return true;
        }
        function pwdsubmit() {
            if ($("#txtOldPassword").val() == "" || $("#txtPassword1").val() == "") { alert("密码不能为空"); return false; }
            return true;
        }
    </script>
</body>
</html>
