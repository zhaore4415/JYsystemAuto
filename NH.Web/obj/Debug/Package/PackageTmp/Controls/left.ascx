<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left.ascx.cs" Inherits="NH.Web.Controls.left" %>
<asp:Panel ID="Panel1" runat="server">
    <div id="sidebar">
        <a href="#" class="visible-phone"><i class="icon icon-th"></i>&nbsp;菜单</a>
        <ul>


            <%--<li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/member/jifendetail") ? "active" : ""%>">
                <a href="/Member/JiFenList.aspx" title="积分兑换"><i class="icon icon-fullscreen"></i><span>积分兑换</span></a></li>--%>
            <li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/authority/person/personlist") ? "active" : ""%>">
                <a href="/Authority/Person/PersonList.aspx" title="推荐库管理"><i class="icon icon-fullscreen"></i><span>推荐库管理</span></a></li>

            <li class="<%=Request.Path.ToLower().Contains("/queryorder") ? "active" : ""%>"><a
                href="/Authority/Queryorder/Queryorder.aspx" title="订单信息"><i class="icon icon-home"></i><span>订单信息</span></a>
            </li>
            <li class="<%=Request.Path.ToLower().Contains("/billmanage") || Request.Path.ToLower().Contains("/authority/bill/billmanage") ? "active" : ""%>">
                <a href="/authority/bill/billmanage.aspx" title="账单管理"><i class="icon icon-fullscreen"></i><span>账单管理</span></a></li>
            <li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/member/jifendetail") ? "active" : ""%>">
                <a href="/Member/JiFenList.aspx" title="退换货管理"><i class="icon icon-fullscreen"></i><span>退换货管理</span></a></li>
        </ul>
    </div>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server">
    <div id="sidebar">
        <a href="#" class="visible-phone"><i class="icon icon-th"></i>&nbsp;菜单</a>
        <ul>


            <%--<li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/member/jifendetail") ? "active" : ""%>">
                <a href="/Member/JiFenList.aspx" title="积分兑换"><i class="icon icon-fullscreen"></i><span>积分兑换</span></a></li>--%>
            <%--<li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/member/jifendetail") ? "active" : ""%>">
                <a href="/Member/JiFenList.aspx" title="佣金计算管理"><i class="icon icon-fullscreen"></i><span>佣金计算管理</span></a></li>--%>
            <li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/authority/person/personlist") ? "active" : ""%>">
                <a href="/Authority/Person/PersonList.aspx" title="推荐库管理"><i class="icon icon-fullscreen"></i><span>推荐库管理</span></a></li>

            <li class="<%=Request.Path.ToLower().Contains("/queryorder.aspx") ||Request.Path.ToLower().Contains("/queryorderfx.aspx")? "active" : ""%>"><a
                href="/Authority/Queryorder/Queryorder.aspx" title="订单信息"><i class="icon icon-home"></i><span>订单信息</span></a>
            </li>
            <li class="<%=Request.Path.ToLower().Contains("/billmanage") || Request.Path.ToLower().Contains("/authority/bill/billmanage") ? "active" : ""%>">
                <a href="/authority/bill/billmanage.aspx" title="账单管理"><i class="icon icon-fullscreen"></i><span>账单管理</span></a></li>
            <li class="<%=Request.Path.ToLower().Contains("/jifenlist") || Request.Path.ToLower().Contains("/member/jifendetail") ? "active" : ""%>">
                <a href="/Member/JiFenList.aspx" title="退换货管理"><i class="icon icon-fullscreen"></i><span>退换货管理</span></a></li>
            <li class="<%=Request.Path.ToLower().Contains("/auser") ? "active" : ""%>"><a href="/Authority/AUser/AUser.aspx"
                title="管理级别管理"><i class="icon icon-th-list"></i><span>管理级别管理</span></a></li>
          
        </ul>
    </div>
</asp:Panel>
