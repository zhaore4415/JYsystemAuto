<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyJobModify.aspx.cs" Inherits="NH.Web.adm.Company.CompanyJobModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript%>
    <style type="text/css">
        select{ width:220px;}
    </style>
    <script src="../Script/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../Script/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('#txtExpireDate').datebox();

            $("#ddlJobCategory").formSelect({
                colWidth: 120,
                cols: 3,
                select: 3,
                onShow: function () {
                    $('#ddlJobCategory').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlJobCategory').trigger('blurListener');
                }
            });

            $("#ddlSalary").formSelect({
                colWidth: 100,
                cols: 3,
                onShow: function () {
                    $('#ddlSalary').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlSalary').trigger('blurListener');
                }
            });

            $("#ddlDegree").formSelect({
                colWidth: 100,
                cols: 2,
                onShow: function () {
                    $('#ddlDegree').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlDegree').trigger('blurListener');
                }
            });

            $("#ddlJobType").formSelect({
                colWidth: 70,
                cols: 3,
                select: 3,
                onShow: function () {
                    $('#ddlJobType').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlJobType').trigger('blurListener');
                }
            });

            $("#ddlExperience").formSelect({
                colWidth: 100,
                cols: 2,
                onShow: function () {
                    $('#ddlExperience').trigger('focusListener');
                },
                onClose: function () {
                    $('#ddlExperience').trigger('blurListener');
                }
            });

            $("#<%=ddlSex.ClientID %>").formSelect({
                colWidth: 100,
                cols: 2,
                onShow: function () {
                    $('#<%=ddlSex.ClientID %>').trigger('focusListener');
                },
                onClose: function () {
                    $('#<%=ddlSex.ClientID %>').trigger('blurListener');
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(window).scroll(function () {
            window.parent.fixbug();
        });
    </script>
</head>
<body>
    <form id="formEdit" runat="server" enableviewstate="false">
    <div id="Add">
        <%--<div class="frmborder">
            <p>招聘信息</p>
        </div>--%>
        <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>招聘标题：</th>
                <td><asp:TextBox runat="server" ID="txtJobTitle"></asp:TextBox></td>
            </tr>
            <tr>
                <th>招聘职位：</th>
                <td>                
                    <select id="ddlJobCategory" name="ddlJobCategory">
                        <option value="">请选择...</option>
                        <asp:Literal runat="server" ID="ltrJobCategory"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>薪酬：</th>
                <td>
                    <select id="ddlSalary" name="ddlSalary">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrSalary" runat="server"></asp:Literal>
                    </select>
                    <asp:CheckBox runat="server" ID="cbCommission" Text="加提成" />
                </td>
            </tr>
            <tr>
                <th>工作方式：</th>
                <td>
                    <select id="ddlJobType" name="ddlJobType" multiple="multiple">
                        <asp:Literal ID="ltrJobType" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>教育程度：</th>
                <td>
                    <select id="ddlDegree" name="ddlDegree" multiple="multiple">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrDegree" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>工作经验：</th>
                <td>
                    <select id="ddlExperience" name="ddlExperience">
                        <option value="">请选择..</option>
                        <asp:Literal ID="ltrExperience" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>性别要求：</th>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSex">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                        <asp:ListItem Value="-1" Selected="True">不限</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <th>是否报销车费：</th>
                <td>
                    <asp:RadioButtonList runat="server" ID="IsCarfare" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">报销</asp:ListItem>
                        <asp:ListItem Value="0">不报销</asp:ListItem>
                        <asp:ListItem Value="-1">面议</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>--%>
            <%--<tr>
                <th>是否提供食宿：</th>
                <td>
                    <asp:RadioButtonList runat="server" ID="IsHousing" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">报销</asp:ListItem>
                        <asp:ListItem Value="0">不报销</asp:ListItem>
                        <asp:ListItem Value="-1">面议</asp:ListItem>
                    </asp:RadioButtonList> 
                </td>
            </tr>--%>
            <tr>
                <th>人员工作时间：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtWorkTime"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>招聘人数：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtQty"></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
                <th>有效期：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtExpireDate"></asp:TextBox>
                </td>
            </tr>--%>
            <%--<tr>
                <th>招聘内容：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtDescription" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <th>拿多少钱：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtSalaryDesc" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>干什么活：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtWorkContent" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>有什么要求：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtRequirements" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>吃住情况：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtRoomAndFood" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>有什么福利：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtWelfare" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>操作</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <asp:PlaceHolder runat="server" ID="phHide">
            <tr>
                <th>审核状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbVerifyStatus"></asp:Label>
                    <a id="btnVerifyYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_verifyStatus == 1 ? "disabled='true'" : ""%> onclick="Verify(1)">审核通过</a>
                    <a id="btnVerifyNo" class="easyui-linkbutton" iconCls="icon-no" <%=_verifyStatus == -1 ? "disabled='true'" : ""%> onclick="Verify(-1)">审核不通过</a>
                </td>
                <th>发布状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbStatus"></asp:Label>
                    <a id="btnLoginYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_status == 1 ? "disabled='true'" : ""%> onclick="ChangeStatus(1)">发布</a>
                    <a id="btnLoginNo" class="easyui-linkbutton" iconCls="icon-no" <%=_status == 0 ? "disabled='true'" : ""%> onclick="ChangeStatus(0)">隐藏</a>
                </td>
            </tr>
            </asp:PlaceHolder>
            <tr>
                <th>保存：</th>
                <td>
                    <input type="hidden" id="action" name="action" />
                    <a class="easyui-linkbutton" iconCls="icon-save" onclick="$('#action').val('modify');$('#formEdit').submit()">保存资料</a>
                </td>
                <th></th>
                <td>
                </td>
            </tr>
        </table>
        </div>
        
        <asp:PlaceHolder runat="server" ID="phNewInfo1">
        <div class="tbitem">
        <p class="title tab"><span>资料更新审核</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <%--<tr>
                <th>招聘内容：</th>
                <td>
                    <asp:Label runat="server" ID="lbDescription_new"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <th>招聘标题：</th>
                <td>
                    <asp:Label runat="server" ID="lbJobTitle_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>拿多少钱：</th>
                <td>
                    <asp:Label runat="server" ID="lbSalaryDesc_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>干什么活：</th>
                <td>
                    <asp:Label runat="server" ID="lbWorkContent_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>吃住情况：</th>
                <td>
                    <asp:Label runat="server" ID="lbRequirements_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>有什么福利：</th>
                <td>
                    <asp:Label runat="server" ID="lbRoomAndFood_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>招聘内容：</th>
                <td>
                    <asp:Label runat="server" ID="lbWelfare_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <a id="btnVerifyNewYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_newinfoVerifyStatus == 1 ? "disabled='true'" : ""%> onclick="VerifyNewInfo(1)">通过</a>
                    <a id="btnVerifyNewNo" class="easyui-linkbutton" iconCls="icon-no" <%=_newinfoVerifyStatus == -1 ? "disabled='true'" : ""%> onclick="VerifyNewInfo(-1)">不通过</a>
                </td>
            </tr>
        </table>
        </div>
        </asp:PlaceHolder>
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#formEdit').form({
                onSubmit: function () {
                    // do some check  
                    // return false to prevent submit;  
                },
                success: function (data) {
                    try {
                        data = eval('(' + data + ')');
                    } catch (err) {
                        alert('发生错误');
                        return;
                    }
                    switch (data.status) {
                        case "ok":
                            alert('保存成功');
                            window.parent.CloseAndReload();
                            break;
                        case "error":
                            alert(data.msg);
                            break;
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                    }
                }
            });
        })
    </script>
    <script type="text/javascript">
        function Verify(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'verify', 'status': status },
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    switch (data.status) {
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                        case "error":
                            alert(data.msg);
                            break;
                        case "ok":
                            alert('操作成功');
                            if (status == 1) {
                                $('#btnVerifyYes').linkbutton('disable');
                                $('#btnVerifyNo').linkbutton('enable');
                                $('#lbVerifyStatus').text('审核通过');
                            } else {
                                $('#btnVerifyYes').linkbutton('enable');
                                $('#btnVerifyNo').linkbutton('disable');
                                $('#lbVerifyStatus').text('审核不通过');
                            }
                            break;

                    }
                }
            })
        }
    </script>
    <script type="text/javascript">

        function ChangeStatus(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【发布状态】" : "【隐藏状态】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'ChangeStatus', 'status': status },
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    switch (data.status) {
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                        case "error":
                            alert(data.msg);
                            break;
                        case "ok":
                            alert('操作成功');
                            if (status == 1) {
                                $('#btnLoginYes').linkbutton('disable');
                                $('#btnLoginNo').linkbutton('enable');
                                $('#lbStatus').text('已发布');
                            } else {
                                $('#btnLoginYes').linkbutton('enable');
                                $('#btnLoginNo').linkbutton('disable');
                                $('#lbStatus').text('已隐藏');
                            }
                            break;

                    }
                }
            })
        }
    </script>
    <script type="text/javascript">
        function VerifyNewInfo(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【审核通过】" : "【审核不通过】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'VerifyNewInfo', 'status': status },
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    switch (data.status) {
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                        case "error":
                            alert(data.msg);
                            break;
                        case "ok":
                            alert('操作成功');
                            window.location.href = window.location.href
                            if (status == 1) {
                                $('#btnVerifyNewYes').linkbutton('disable');
                                $('#btnVerifyNewNo').linkbutton('enable');
                            } else {
                                $('#btnVerifyNewYes').linkbutton('enable');
                                $('#btnShowNo').linkbutton('disable');
                            }
                            break;

                    }
                }
            })
        }
    </script>
</body>
</html>
