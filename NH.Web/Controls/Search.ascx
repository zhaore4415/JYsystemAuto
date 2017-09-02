<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="NH.Web.Controls.Search" %>
<div class="search pL10 pT15 pR10 pB15 mT20">
    <form id="searchform" action="">
    <select id="ddlJobCategory_search" name="cid" class="hideselect" style=" width:150px;">
        <option value="">选择职位</option>
        <asp:Literal runat="server" ID="ltrJobCategory_search"></asp:Literal>
    </select>
    <select id="ddlJobAddress_search" name="area" class="hideselect" style=" width:120px; margin-left:5px;">
        <option value="">选择地区</option>
        <asp:Literal ID="ltrJobAddress_search" runat="server"></asp:Literal>
    </select>
    <select id="ddlPublishDate" name="date" class="hideselect" style=" width:120px; margin-left:5px;">
        <option value="">发布时间</option>
        <option value="1" <%=Request.QueryString["date"]=="1" ? "selected=\"selected\"" : "" %>>今天</option>
        <option value="3" <%=Request.QueryString["date"]=="3" ? "selected=\"selected\"" : "" %>>最近3天</option>
        <option value="7" <%=Request.QueryString["date"]=="7" ? "selected=\"selected\"" : "" %>>最近1周</option>
        <option value="30" <%=Request.QueryString["date"]=="30" ? "selected=\"selected\"" : "" %>>最近1月</option>
    </select>
    <select id="ddlSalary" name="salary" class="hideselect" style="width:110px; margin-left:10px;">
        <option value="">薪资水平</option>
        <asp:Literal ID="ltrSalary" runat="server"></asp:Literal>
    </select>
    <div class="input key mL10 fl"><input type="text" id="txtKey" name="key" class="key" title="输入关键词，如：普工，文员" value="<%=NH.Web.Site.HtmlEncode((Request.QueryString["key"]+"").Trim()) %>" /></div>
    <div class="bt fr"><input type="submit" id="btnSearchJob" class="btnsearchjob" value="搜工作" onclick="$('#searchform').attr('action','<%=NH.Web.Urls.JobList() %>')" /></div>
    </form>
</div>
<div class="searchBar"></div>

<script type="text/javascript">
    $(document).ready(function () {
        $("#ddlJobCategory_search").jJobSelect();
        $("#ddlJobAddress_search").jAreaSelect({
            is_province: true,
            nolimitText: '不限地区',
            shownolimit: true
        });

        $("#ddlPublishDate").formSelect({
            className: 'color_select',
            colWidth: 100,
            cols: 2,
            onShow: function () {
                $('#ddlPublishDate').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlPublishDate').trigger('blurListener');
            }
        });

        $("#ddlSalary").formSelect({
            className: 'color_select',
            colWidth: 100,
            cols: 3,
            onShow: function () {
                $('#ddlSalary').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlSalary').trigger('blurListener');
            }
        });
    });
</script>
<script type="text/javascript">    if ($('#txtKey').val() == $('#txtKey').attr('title')) { $('#txtKey').val(''); }; $('#txtKey').watermark('watermark');</script>
<%--<script src="/Scripts/jquery.tinywatermark-3.1.0.min.js" type="text/javascript"></script>
<script type="text/javascript">    if ($('#txtKey').val() == $('#txtKey').attr('title')) { $('#txtKey').val(''); }; $('#txtKey').watermark('watermark');</script>--%>
<%--<div class="search">
    <div class="sicon"></div>
    <div class="searchform">
        <form id="searchform" action="">
        <select id="ddlJobCategory" name="cid" style=" width:160px;">
            <option value="">选择职位</option>
            <asp:Literal runat="server" ID="ltrJobCategor"></asp:Literal>
        </select>
        <select id="ddlJobAddress" name="area" style=" width:160px; margin-left:10px;">
            <option value="">选择地区</option>
            <asp:Literal ID="ltrJobAddress" runat="server"></asp:Literal>
        </select>
        <input type="text" id="txtKey" name="key" class="key" title="请输入城市、企业、人名搜索" value="<%=NH.Web.Site.HtmlEncode((Request.QueryString["key"]+"").Trim()) %>" />
        <input type="submit" id="btnSearchPerson" class="btnsearchperson" value="" onclick="$('#searchform').attr('action','<%=Request.Url.LocalPath.ToLower().Contains("/perlist2.aspx") ? NH.Web.Urls.PerList2() : NH.Web.Urls.PerList() %>')" />
        <input type="submit" id="btnSearchJob" class="btnsearchjob" value="" onclick="$('#searchform').attr('action','<%=NH.Web.Urls.JobList() %>')" />
        </form>
    </div>
    <div class="sarea">
        <asp:Repeater runat="server" ID="rptList">
            <ItemTemplate><a href="<%#Eval("Url") %>" target="_blank"><%#Eval("KeyName").ToString().Trim()%></a></ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<script type="text/javascript">
    $("#ddlJobCategory").jJobSelect({
        select: 1
    });
    $("#ddlJobAddress").jAreaSelect({
        select: 1,
        nolimitText: '不限地区',
        shownolimit: false,
        is_province:true
    });
</script>
<script src="/Scripts/jquery.tinywatermark-3.1.0.min.js" type="text/javascript"></script>
<script type="text/javascript">    if ($('#txtKey').val() == $('#txtKey').attr('title')) {$('#txtKey').val(''); }; $('#txtKey').watermark('watermark');</script>
--%>