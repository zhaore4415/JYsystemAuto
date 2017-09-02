<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginHead.ascx.cs" Inherits="NH.Web.Controls.LoginHead" %>

<header>
    <div class="container">
        <div class="row clearfix">
            <div class="col-md-12 column">
                <nav class="navbar navbar-default" role="navigation">
                    <div class="navbar-header">

                        <a class="navbar-brand" href="/index.aspx">BUCCKER</a>
                    </div>

                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                        <%if (NH.Web.UserBase.IsLogin)
                            {%> <span><a href="/index.aspx">首页</a>  | <a class="a-2" href="../Member/MemberIndex.aspx">
                           <%=NH.Web.UserBase.Current.LoginName%> 个人中心</a> |  <a class="a-3" href="<%=NH.Web.Urls.LogOut("") %>">退出</a> </span><%}
    else
    { %>
                        <span><a href="/index.aspx">登录</a></span><%} %>
                       
                    </div>

                </nav>

            </div>
        </div>
    </div>
</header>
