<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NH.Web.adm.Article.News" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新鹏都装饰后台管理专业版</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            background: #2971b2 url(/images/bj_2.gif) no-repeat;
        }
    </style>
</head>
<body>
    <uc1:left ID="left1" runat="server" />
    <div id="right">
        <uc2:Head ID="Head1" runat="server" />
        <div class="content">
            <div class="content_left">
                <div class="news">
                    <div class="news_tit">
                        <s>新闻公告</s>GENGDUOGONGNENG</div>
                    <div class="news_con">
                        <ul>
                            <asp:Repeater ID="rptList2" runat="server">
                                <ItemTemplate>
                                    <li><a href="<%#NH.Web.Urls.NewsDetails(Eval("Id").ToString()) %>">
                                        <%#Eval("Title")%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="clear">
                        </div>
                        <%=_pager %>
                    </div>
                </div>
            </div>
            <div class="content_right">
            </div>
        </div>
    </div>
</body>
</html>
