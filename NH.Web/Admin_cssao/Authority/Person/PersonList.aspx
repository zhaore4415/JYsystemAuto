<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="NH.Web.adm.Person.PersonList" %>

<%@ Register Src="~/Admin_cssao/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="~/Admin_cssao/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>推荐库管理</title>
    <%=CssAndScript %>
    <link href="/css/css.css" rel="stylesheet" />
    <link href="/css/index.css" rel="stylesheet">
    <style>
        .gradeX td {
            text-align: center;
        }
    </style>
    <script>

        $(function () {
            $('#modal-container-350023').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget) // 触发事件的按钮  
                var recipient = button.data('whatever') // 解析出whatever内容  
                var modal = $(this)  //获得模态框本身
                //modal.find('.modal-title').text('Message To ' + recipient)  //更改将title的text
                modal.find('.modal-body').html(recipient);
                //居中代码
                $(this).css('display', 'block');
                var modalHeight = $(window).height() / 2 - $('#modal-container-350023 .modal-dialog').height() / 2;
                $(this).find('.modal-dialog').css({
                    'margin-top': modalHeight
                });
            });
            //$(".panel-heading").click(function (e) {
            //    /*切换折叠指示图标*/
            //    $(this).find("span").toggleClass("glyphicon-chevron-down");
            //    $(this).find("span").toggleClass("glyphicon-chevron-up");
            //});

        });

        //function changeFeedback(id) {
        //    //$(this).click(function () {
        //    //    //alert($(this).val());
        //    //        //$(this).find("span").toggleClass("glyphicon-chevron-down");
        //    //        ////alert(id);
        //    //        ////alert(this);
        //    //        //$(this).find("span").toggleClass("glyphicon-chevron-up");

        //    //});

        //    //var str = document.getElementById(id).className;
        //    //var tag = str.substring(25, str.length);
        //    //if (tag == "right") {
        //    //    document.getElementById(id).className = "glyphicon glyphicon-menu-down";
        //    //} else {
        //    //    document.getElementById(id).className = "glyphicon glyphicon-menu-right";
        //    //}
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:Head ID="Head1" runat="server" />
        <uc1:left ID="left1" runat="server" />
        <div id="content">
            <div class="container-fluid">
                <div class="row-fluid">
                    <div class="span12">
                        <h2>被推荐人列表</h2>
                        <div class="searchbox">
                            关键字：<asp:TextBox runat="server" ID="txtKey" CssClass="input-text" placeholder="手机号"></asp:TextBox>
                            <asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" CssClass="btn btn-inverse btn-mini" />
                        </div>

                        <div class="widget-box">
                            <div class="widget-content nopadding table-responsive">
                                <asp:Repeater ID="rptList" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-striped">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <input type="checkbox" id="chkAll" title="全选" />
                                                    </th>
                                                    <th width="80">
                                                        <strong>标识ID</strong>
                                                    </th>
                                                    <th>用户名
                                                    </th>
                                                    <th>所有层级
                                                    </th>
                                                    <th>上级经营者</th>
                                                    <th>下级经营者</th>
                                                    <th>经营者级别</th>
                                                    <th>手机
                                                    </th>

                                                     <th>订单列表
                                                    </th>
                                                    <th>添加时间
                                                    </th>
                                                    <th>状态
                                                    </th>
                                                    <th width="100">操作
                                                    </th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tbody>
                                            <tr class="odd gradeX">
                                                <td>
                                                    <input type="checkbox" name="chkItem" value="<%#Eval("Id")%>" />
                                                </td>
                                                <td>
                                                    <%#Eval("ID")%>
                                                </td>

                                                <td>
                                                    <%#Eval("LoginName")%>
                                                </td>
                                                <td>
                                                    <%#Eval("Depth")%>
                                                </td>
                                                <td><%# getParent((int)Eval("ParentID")) %></td>
                                                <td>
                                                    <a id="modal-350023" href="#modal-container-350023" role="button" class="btn" data-toggle="modal" data-whatever="<%# getChild((int)Eval("Id")) %>">下级经营者</a>
                                                   
                                                </td>
                                                <td>顶起
                                                </td>
                                                <td>
                                                    <%#Eval("Phone")%>
                                                </td>

                                                 <td>
                                                 <a href="/Authority/Queryorder/Queryorder.aspx?u_id=<%#Eval("ID")%>" title="订单信息"><span class="glyphicon glyphicon-th-list"></span> </a> 
                                                </td>
                                                <td>
                                                    <%#Eval("AddTime")%>
                                                </td>
                                                <td>
                                                    <%# NH.Web.adm.WebBase.ModelEnum.AUserStatusDesc((NH.Web.adm.WebBase.ModelEnum.AUserStatus)((int)Eval("Status"))) %>
                                                </td>
                                                <td>
                                                    <a href="<%=PagePreFix %>Modify.aspx?id=<%#Eval("Id")%>">编辑</a> | <a href="#" onclick="javascript:return DeleteOne(<%#Eval("Id")%>)">删除</a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <tr>
                                            <td colspan="12">
                                                <%=_pager %>
                                            </td>
                                        </tr>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="tijiaodingdan">
                                <%-- 总计：<span id="spAAPrice"></span> 积分</p>
                            <asp:Label ID="lblOpenId" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lbotherSN" runat="server" Text="" Visible="false"></asp:Label>--%>
                                <%--<asp:Button runat="server" ID="btnSubmit" Text="兑换" CssClass="btn btn-inverse" OnClick="btnSubmit_Click"
                                    OnClientClick="return beforesubmit()" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <div class="modal fade" id="modal-container-350023" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title" id="myModalLabel">下级经营者
                    </h4>
                </div>
                <div class="modal-body" id="bodyNames">
                    内容...，内容...
                            内容...内容...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <%--<button type="button" class="btn btn-primary">保存</button>--%>
                </div>
            </div>

        </div>

    </div>
</body>
</html>
