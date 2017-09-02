<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="NH.Web.Controls.Calendar" %>

<div class="mainFamousLeft fl">
    <div class="mainFamousLeftTitle">
        <ul class="groupPage fr">
            <li><a class="a1" href="#">上一组</a></li>
            <li><a class="a2" href="#">下一组</a></li>
        </ul>
        <h2 class="font18 fontMic pL10 fLight fl">名企就业直通车</h2>
    </div>
    <ul class="mainFamousList" id="mainFamousList">
        <asp:Repeater runat="server" ID="rptList">
            <ItemTemplate>
        <li class="expired fl"><!--  过期样式  -->
            <div class="time fontMic"><%#Eval("enddate","{0:yyyy-MM-dd}") %><p>星期<%#Eval("enddate","{0:ddd}") %></p></div>
            <asp:Repeater runat="server" ID="rptReceives" DataSource='<%#GetReceives(Eval("enddate").ToString()) %>'>
            <ItemTemplate>
            <div class="comanyInfo mT15">
                <p class="img"><a href="<%# NH.Web.Urls.JobInfo((int)Eval("JobId")) + "&t=" + Eval("Id").ToString() %>"><img src="/Upload/CompanyLogo/<%#Eval("Logo") %>" alt="<%#Eval("CompanyName") %>"></a></p>
                <p>工资：<b><%#Eval("SalaryName")%></b></p>
                <p>地点：<%#Eval("Area") %></p>
                <p>本批报名：<b><%#Eval("SignUpCount")%>人</b></p>
                <p>总报名：<%#Eval("TotalSignUp")%>人</p>
            </div>
            </ItemTemplate>
            </asp:Repeater>
            <%--<div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises1.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>--%>
        </li>
            </ItemTemplate>
        </asp:Repeater>
        <%--<li class="expired fl"><!--  过期样式  -->
            <div class="time fontMic">2013-11-28<p>周三</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises1.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="ing fl"><!--  正在进行样式  -->
            <div class="time fontMic">2013-11-29<p>周四</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises6.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises7.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises8.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-11-30<p>周五</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises9.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises1.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-1<p>周六</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises6.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises7.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises8.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-2<p>周日</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-3<p>周一</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-4<p>周二</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-5<p>周三</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-5<p>周四</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-6<p>周五</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-7<p>周六</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>
        <li class="fl">
            <div class="time fontMic">2013-12-8<p>周日</p></div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises2.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises3.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises4.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
            <div class="comanyInfo mT15">
                <p class="img"><a href="#"><img src="images/famousEnterprises5.gif" alt="名企就业直通车"></a></p>
                <p>工资：<b>2200-3200元</b></p>
                <p>地点：中山</p>
                <p>本批报名：<b>238人</b></p>
                <p>总报名：1288人</p>
            </div>
        </li>--%>
    </ul>
</div>