<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" EnableEventValidation="false"
    Inherits="NH.Web.adm.Authority.Company.Company" %>

<%@ Register Src="/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>巴克后台管理专业版</title>
    <%=CssAndScript %>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <style>
        body
        {
            background: #2971b2 url(/images/bj_2.gif) no-repeat;
        }
    </style>
    <script src="/js/jquery-1.2.1.js" type="text/javascript"></script>
    <script src="/Script/OpenWindow.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            GetByJquery();
            $("#ddlBranchOne").change(function () { GetCity() });
         
            //            $("#ddlBranchTwo").change(function () { GetDistrict() });
        });

        function GetByJquery() {

            $("#ddlBranchOne").empty(); //清空省份SELECT控件

            $.getJSON("/Handler/GetBranchOne.ashx", function (data) {
//                alert(data);
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["id"])
                    .text(item["name"])
                    .appendTo($("#ddlBranchOne"));
                });
                     <%if(Request.QueryString["shen"]!="") {%>
                    $('#ddlBranchOne').val(<%=Request.QueryString["shen"] %>);<%} %>
//                alert($("#ddlBranchOne").val());
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
//                GetDistrict();
            });
        }

        function GetDistrict() {
            $("#ddlDistrict").empty(); //清空市区SELECT控件
            var url = "/ajax/GetDistrictList/" + $("#ddlCity").val();

            $.getJSON(url, function (data) {
                $.each(data, function (i, item) {
                    $("<option></option>")
                    .val(item["DistrictID"])
                    .text(item["DistrictName"])
                    .appendTo($("#ddlDistrict"));
                });
            });
        }

    </script>
  
</head>
<body>
    <form id="form1" runat="server">
    <uc1:left ID="left1" runat="server" />
    <div id="right">
        <uc2:Head ID="Head1" runat="server" />
        <div class="content4">
            <div class="content4_left">
                <div class="daohang4">
                    <a href="/Default.aspx">首页</a> > <a href="Company.aspx">省市管理</a></div>
                <div class="administration">
                    <div class="administration_tit">
                        <div class="administration_tit2">
                            <div style="float: left; width: 655px;">
                                <p style="width: 655px; float: left;">
                                  
                                    <asp:DropDownList ID="ddlBranchOne" runat="server" Width="107px" CssClass="adm_select">
                                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hiddenBranchOne" runat="server" Value="-1" />
                                    <%--<asp:Label ID="Label2" runat="server" Text="II级机构"></asp:Label>--%>&nbsp;
                                    <asp:DropDownList ID="ddlBranchTwo" runat="server" Width="105px" CssClass="adm_select">
                                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="hiddenBranchTwo" runat="server" Value="-1" />
                                    <asp:TextBox runat="server" ID="txtKey" CssClass="administration_inpu"></asp:TextBox>
                                    <asp:Button runat="server" ID="btnSearch" Text="" OnClick="btnSearch_Click" CssClass="administration_but" /></p>
                            </div>
                            <span style="float: right; width: 300px;">
                                <input name="" type="button" class="administration_but3" onclick="javascript:openwindow('<%=PagePreFix %>Add.aspx','',790,230);" />
                                <asp:Button runat="server" ID="btnDelete" Text="" OnClick="btnDelete_Click" CssClass="administration_but6" /></span>
                        </div>
                    </div>
                    <div class="administration_con">
                        <div class="administration_con2" >
                            <asp:Repeater ID="rptList" runat="server">
                                <HeaderTemplate><div style="float: left;">
                                    <table width="1080px" border="1" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="150" align="center" valign="middle" bgcolor="#f7f7f7">
                                                <input type="checkbox" id="chkAll" title="全选" />
                                            </td>
                                            <td width="150" align="center" valign="middle" bgcolor="#f7f7f7">
                                                <strong>#NO</strong>
                                            </td>
                                            <td width="150" align="center" valign="middle" bgcolor="#f7f7f7">
                                                <strong>省</strong>
                                            </td>
                                            <td width="150" align="center" valign="middle" bgcolor="#f7f7f7">
                                                <strong>市</strong>
                                            </td>
                                            <td width="150" align="center" valign="middle" bgcolor="#f7f7f7">
                                                <strong>区</strong>
                                            </td>
                                            <td width="250" align="center" valign="middle" bgcolor="#f7f7f7">
                                                操作
                                            </td>
                                        </tr></table></div>
                                 <div style="float: left; height: 350px; overflow-y: scroll; overflow-x: hidden;">
                                    <table border="1" cellspacing="0" cellpadding="0" width="1080px" style="border-top: 0;">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td width="150" align="center" valign="middle">
                                            <input type="checkbox" name="chkItem" value="<%#Eval("tk_id")%>" />
                                        </td>
                                        <td width="150" align="center" valign="middle">
                                            <%#Eval("tk_id")%>
                                        </td>
                                        <td width="150" align="center" valign="middle">
                                            <%# GetSubShen(Eval("sk_id").ToString())%>
                                        </td>
                                        <td width="150" align="center" valign="middle">
                                            <%# GetSubShi(Eval("sk_id").ToString())%>
                                        </td>
                                        <td width="150" align="center" valign="middle">
                                            <%# Eval("third_kind_name")%>
                                        </td>
                                        <td width="250" align="center" valign="middle">
                                            <%--<a onclick="javascript:openwindow('<%=PagePreFix %>View.aspx?id=<%#Eval("tk_id")%>','',790,500);" target="_blank">查看</a>
                                            | --%><a onclick="javascript:openwindow('<%=PagePreFix %>Modify.aspx?fk_id=<%#Eval("fk_id")%>&sk_id=<%#Eval("sk_id")%>&tk_id=<%#Eval("tk_id")%>','',790,230);"
                                                target="_blank">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("tk_id")%>)">
                                                    删除</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table></div></FooterTemplate>
                            </asp:Repeater>
                           
                        </div> <%=_pager %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
