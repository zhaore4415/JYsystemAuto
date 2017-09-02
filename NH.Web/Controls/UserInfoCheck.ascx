<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfoCheck.ascx.cs" Inherits="NH.Web.Controls.UserInfoCheck" %>

<%if((NH.Web.UserBase.IsPersonLogin && !NH.Web.UserBase.CurMember.IsBaseInfoOk) || NH.Web.UserBase.IsCompanyLogin && !NH.Web.UserBase.CurCompany.IsBaseInfoOk){ %>
    <script type="text/javascript">
        $(document).ready(function () {
            jConfirm('您在注册过程中发生异常，请参考以下原因：', '1、您还没有完善企业或个人资料；<br/>2、您的资料因过于简单或不符合要求等被管理员删除；', function (r) {
                if (r) window.location.href = '<%=NH.Web.UserBase.IsPersonLogin ? NH.Web.Urls.PersonReg2() : NH.Web.Urls.CompanyReg2() %>';
            });
            
        });
    </script>
<%} %>