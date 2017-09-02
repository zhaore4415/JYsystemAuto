<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="NH.Web.adm.Article.NewsDetails" %>

<%@ Register Src="../Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
    <form id="form1" runat="server">
    <uc1:left ID="left1" runat="server" />
    <div id="right">
        <uc2:Head ID="Head1" runat="server" />
        <div class="content">
            <div class="content_left">
                <div class="daohang">
                    <a href="/Default.aspx">首页</a> > <a href="<%=NH.Web.Urls.News() %>">新闻中心</a></div>
                <div class="news1_con">
                    <dl>
                        <dt><span><strong><%=model.Title %></strong><br />
                            标签：理士电池,理士官网,深圳网站建设</span><p>
                                <%=model.UpdateTime.Value.ToString("yyyy-MM-dd")%></p>
                        </dt>
                        <dd>
                            <%=model.Description %></dd>
                    </dl>
                    <ul>
                        <li><span>上一篇：<%=_prev %></span><p>
                            <span>下一篇：<%=_next %></span></p>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="content_right">
            </div>
        </div>
    </div>
    <%-- <div class="mainGroup">
    	<div class="group">
        	<div class="leftSideMain mt50">
            	<div class="leftSideBox">
                	<h3><%=categoryModel.Name %></h3>
                    <ul class="leftSideCo">
                        <asp:Repeater runat="server" ID="rptList1"><ItemTemplate>
                    	<li><a <%#(int)Eval("Id") == id ? "class='current'" : "" %> href="<%#NH.Web.Urls.News((int)Eval("Id")) %>"><%#Eval("Name") %></a></li>
                         </ItemTemplate></asp:Repeater>
                    </ul>
                </div>
                <div class="leftContact mt10">
                	<uc1:ContactMenu ID="ContactMenu" runat="server" /> 
                </div>
            </div>
            <div class="rightSide mt50">
            	<div class="crumbsTemp">
                	<h3><%=categoryModel.Name %></h3>
                    <div class="crumbsTempRight"><p><a href="<%=NH.Web.Urls.Index() %>">首页</a><span>&gt;</span><a href="<%=NH.Web.Urls.News_Pid(categoryModel.Id) %>"><%=categoryModel.Name %></a><span>&gt;</span><%=_categorypath %></p></div>
                </div>
                <h1 class="newsH1"><%=model.Title %></h1>
                <div class="content">
                     <%=model.Description %>
                </div>
                
                <div class="relation">
                	<h3>相关新闻</h3>
                </div>
                <ul class="newsList">
                    <%BindRlt(rptRandom, 8); %>
                    <asp:Repeater runat="server" ID="rptRandom"><ItemTemplate>
                    	<li><span><%#Eval("ShowTime", "{0:yyyy-MM-dd}")%></span><a href="<%#NH.Web.Urls.NewsDetails(Eval("Id").ToString()) %>"><%#Eval("Title") %></a></li>
                    </ItemTemplate></asp:Repeater>
                </ul>
            </div>
        </div>
    </div>--%>
    </form>
</body>
</html>
