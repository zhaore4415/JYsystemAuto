<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.ascx.cs" Inherits="NH.Web.Controls.UserInfo" %>
<div class="navuserinfo">
    <%if(!NH.Web.UserBase.IsLogin){%>
    <%}else if(NH.Web.UserBase.IsCompanyLogin){ %>
    <div class="locjobapply"><a href="<%=NH.Web.Urls.JobApply_C() %>">应聘简历</a><span class="num <%=_jobapplyCount > 9 ? " num2" : "num1" %>"><%=_jobapplyCount %></span></div>
    <div class="lochandle">
        <div class="subcontent">
            <ul>
                <li class="icon1"><a href="<%=NH.Web.Urls.Default_C() %>">管理中心</a></li>
                <li class="icon2"><a href="<%=NH.Web.Urls.JobTop() %>">置顶机会</a></li>
                <li class="icon3"><a href="<%=NH.Web.Urls.ChangePassword_C() %>">修改密码</a></li>
                <li class="icon4"><a href="<%=NH.Web.Urls.LogOut("company") %>">退出</a></li>
            </ul>
        </div>
    </div>
    <div class="locwelcome">欢迎您，<%=!string.IsNullOrEmpty(NH.Web.UserBase.CurCompany.CompanyName) ? NH.Web.UserBase.CurCompany.CompanyName : NH.Web.UserBase.Current.LoginName %></div>
    <%}else{%>
    <div class="locjobapply"><a href="<%=NH.Web.Urls.JobApply_P() %>">面试邀请<span class="num <%=_interviewCount > 9 ? " num2" : "num1" %>"><%=_interviewCount %></span></a></div>
    <div class="lochandle">
        <div class="subcontent">
            <ul>
                <li class="icon1 icon1_hover"><a href="<%=NH.Web.Urls.Default_P() %>">管理中心</a></li>
                <li class="icon2 icon2_hover"><a href="<%=NH.Web.Urls.PersonRefresh() %>">置顶机会</a></li>
                <li class="icon3 icon3_hover"><a href="<%=NH.Web.Urls.ChangePassword_P() %>">修改密码</a></li>
                <li class="icon4 icon4_hover"><a href="<%=NH.Web.Urls.LogOut("per") %>">退出</a></li>
            </ul>
        </div>
    </div>
    <div class="locwelcome">欢迎您，<%=!string.IsNullOrEmpty(NH.Web.UserBase.CurMember.Realname) ? NH.Web.UserBase.CurMember.Realname : NH.Web.UserBase.Current.LoginName %></div>
    <%} %>
</div>
<script type="text/javascript">
    $('.lochandle').hover(function () {
        $(this).addClass('lochandle_hover');
    }, function () {
        $(this).removeClass('lochandle_hover');
    }).trigger('mouseover');
    setTimeout(function () { $('.lochandle').trigger('mouseout') }, 1)
</script>