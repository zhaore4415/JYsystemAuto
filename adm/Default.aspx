<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NH.Web.adm.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理</title>
    <base target="main" />
    <%=CssAndScript %>
    <script type="text/javascript">
        $(function () {
            $("#left p").eq(0).addClass("first");
            $("#left p.first").next("div").slideDown("slow");

            var contentDiv = $("#content");
            var menuDiv = $('#leftmenu');
            function auto() {
                contentDiv.height($(window).height() - $("#header").height() - 5).width($(window).width() - 200);
                menuDiv.height($(window).height() - $("#header").height() - 5);
            }
            $(window).resize(function () {
                auto();
            }).resize();
            $("#left p").click(function () {
                if ($(this).nextAll("div").css("display") != "block") {
                    $("#left p").nextAll("div").slideUp("fast");
                    $(this).next("div").slideDown("fast");
                }
            })

            function DateTime() {
                var date = new Date();
                var day = date.toLocaleDateString();
                var time = date.toLocaleTimeString();
                $("#datetime").html(day + " " + time);
                setTimeout(DateTime, 1000);
            }
            DateTime()

            //document.title = $.browser.version;
        })
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            GetMsg();
        });
        function GetMsg() {
            $.ajax({
                url: 'default.aspx?action=GetMsg',
                cache: false,
                dataType: 'json',
                success: function (data) {
                    $('#pvn').text('(' + data.pnv + ')');
                    $('#cvn').text('(' + data.cnv + ')');
                }, complete: function () { setTimeout(function () { GetMsg(); }, 60000); }
            })
        }
    </script>
</head>
<body style="background: #EEF2FB; overflow: hidden">
    <div id="DivShow" style="width: 100%; position: absolute; z-index: 9999; background-color: #000;
        top: 0; left: 0; display: none; text-align: center">
    </div>
    <div id="manage">
        <div id="header">
            <div id="logo">
            </div>
            <div id="close">
                <a href="<%=NH.Web.Urls.LogOut("adm") %>" target="_self" onclick="return confirm('确定要退出吗？')"><img src="images/out.gif" alt="退出" /></a></div>
            <div id="title">
                <span><a href="<%=NH.Web.Urls.Default() %>" target="_blank">网站首页</a></span><span>管理员：<%=NH.Web.UserBase.CurAdmin.LoginName%></span> <span>IP：<%=Request.UserHostAddress%></span>
                <span>当前时间：<i id="datetime"><%=DateTime.Now.ToString()%></i></span>
            </div>
        </div>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td id="left" style="padding-left: 2px;">
                    <div id="leftmenu" style=" overflow-y:auto; width:200px;">
                    <p class="first">
                        系统配置</p>
                    <div class="list">
                        <span></span>
                        <a href="system/SiteInfo.aspx">网站设置</a>
                        <a href="system/EmailConfig.aspx">发件邮箱设置</a>
                        <a href="system/SmsConfig.aspx">短信接口设置</a>
                        <a href="system/RegProtocol.aspx">注册协议</a>
                        <a href="system/ChangePwd.aspx">修改密码</a>
                        <a href="CompanyLevel/CompanyLevel.aspx">VIP等级管理</a>
                        <span></span>
                        </div>
                    <p>
                        管理员管理</p>
                    <div class="list">
                        <a href="Authority/AUser/AUser.aspx">管理员管理</a>
                        <a href="Authority/Fun/Fun.aspx">功能码管理</a>
                        <a href="Authority/Fun/FunGroup.aspx">功能码分组管理</a>
                        <a href="Authority/Role/Role.aspx">角色管理</a>
                        <span></span>
                    </div>
                    <p>
                        人才管理</p>
                    <div class="list">
                        <a href="Person/PersonList.aspx">人才列表</a>
                        <a href="Person/PersonListForVerify.aspx">待审核人才<b id="pvn"></b></a>
                        <a href="Person/PersonReg.aspx">添加人才</a>
                        <%--<a href="Person/PersonAlbumForVerify.aspx">相册审核</a>
                        <a href="Person/PersonWorksForVerify.aspx">作品审核</a>
                        <a href="Person/PersonWorksForCommend.aspx">推荐作品</a>
                        <a href="Person/PersonFaceForVerify.aspx">头像审核</a>
                        <a href="Person/PersonIdentityVerifyList.aspx">实名认证审核</a>--%>
                        <span></span>
                    </div>
                    <p>
                        企业管理</p>
                    <div class="list">
                        <a href="Company/CompanyList.aspx">企业列表</a>
                        <a href="Company/CompanyListForVerify.aspx">待审核企业<b id="cvn"></b></a>
                        <a href="Company/VipCompany.aspx">VIP企业管理</a>
                        <a href="ReceiveRecord/ReceiveRecord.aspx">接站查询</a>
                        <a href="Payment/PayList.aspx">在线支付管理</a>
                        <a href="Company/CompanyReg.aspx">添加企业</a>
                        <%--<a href="Company/CompanyFaceForVerify.aspx">形象照片审核</a>
                        <a href="Company/CompanyIdentityVerifyList.aspx">实名认证审核</a>
                        <a href="Company/CompanyAlbumForVerify.aspx">企业相册审核</a>
                        <a href="Company/CompanyJobsForVerify.aspx">招聘信息审核</a>
                        <a href="JobCategory/JobCategory.aspx">职位类别管理</a>--%>
                        <span></span>
                    </div>
                    <p>
                        广告管理</p>
                    <div class="list">
                        <asp:Repeater runat="server" ID="rptAdType">
                        <ItemTemplate><a href="Ad/Ad.aspx?cid=<%#Eval("Id")%>"><%#Eval("TypeName")%></a></ItemTemplate>
                        </asp:Repeater>
                        <a href="Ad/VipAd.aspx?cid=11">首页+内页-VIP招聘广告</a>
                        <a href="Ad/TextAd.aspx?cid=12">首页滚动文字广告</a>
                        <a href="Ad/TextAd.aspx?cid=1">登录页滚动文字广告</a>
                        <a href="Ad/JobSuperFix.aspx?cid=14">超级招聘信息固顶</a>
                        <a href="Ad/AdType.aspx">广告类型管理</a>
                        <span></span>
                    </div>
                    <p>
                        联系方式管理</p>
                    <div class="list">
                        <a href="OnlineService/Contact.aspx">联系方式</a>
                        <a href="OnlineService/OnlineService.aspx">在线QQ客服管理</a>
                        <a href="Bank/Bank.aspx">汇款账号管理</a>
                        <span></span>
                    </div>
                    <p>
                        信息管理</p>
                    <div class="list">
                        <a href="Article/SysNews.aspx?type=1">系统消息(个人)</a>
                        <a href="Article/SysNews.aspx?type=2">系统消息(企业)</a>
                        <a href="Article/ArticleCategory.aspx">文章分类管理</a>
                        <a href="Article/Article.aspx">文章管理</a>
                        <%--<a href="Article/HrCategory.aspx">Hr工具分类管理</a>
                        <a href="Article/HrList.aspx">Hr工具管理</a>
                        <a href="Article/SolutionCategory.aspx">策划方案分类管理</a>
                        <a href="Article/SolutionList.aspx">策划方案管理</a>--%>
                        <a href="SearchKey/SearchKey.aspx">顶部搜索关键词管理</a>
                        <a href="SearchKey/HotKey.aspx">热门关键词管理</a>
                        <a href="Suggest/Suggest.aspx">意见与建议管理</a>
                        <a href="FriendLink/FriendLink.aspx">友情链接管理</a>
                        <span></span>
                        <a style="height:5px; background-image:url(images/menu_topimg.gif); background-repeat:no-repeat"></a>
                    </div>
                    </div>
                </td>
                <td style="width: 5px;">
                </td>
                <td valign="top">
                    <div id="content">
                        <iframe id="main" name="main" style="overflow-y: auto" frameborder="0" src="MainPage.aspx"
                            width="100%" height="98%"></iframe>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</body>
</html>
