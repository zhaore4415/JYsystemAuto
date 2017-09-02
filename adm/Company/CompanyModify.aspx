<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyModify.aspx.cs" Inherits="NH.Web.adm.Company.CompanyModify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%=CssAndScript %>
    <%=EasyUI_CssAndScript %>
    <link href="/Scripts/jquery-ui-1.8.23/themes/start/jquery-ui-1.8.23.custom.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/common.css" rel="stylesheet" type="text/css" />    
    <script src="/Scripts/jquery-ui-1.8.23/js/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <script src="/Scripts/jAreaSelect.js" type="text/javascript"></script>
    <script src="/Scripts/jJobSelect.js" type="text/javascript"></script>
    <script src="/Scripts/Common.js" type="text/javascript"></script>
    <script src="/Scripts/jquery-ui-1.8.23/locale/jquery.ui.datepicker-zh-CN.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="/Scripts/jquery.form.js"></script>--%>
    <script type="text/javascript">
        $(document).ajaxStart(function () {

        }).ajaxSend(function (e, jqxhr, settings) {
            if (/(\?|&)ajax=/.test(settings.url) == false) {
                if (settings.url.indexOf('?') == -1) {
                    settings.url += '?ajax=1';
                } else {
                    settings.url += '&ajax=1';
                }
            };
        });
        $.ajaxSetup({ type: 'post', dataType: 'json' });
    </script>
</head>
<body>
    <form id="formEdit" runat="server" enableviewstate="false">
        <%--<div class="frmborder">
            <p>企业管理 -> 编辑资料</p>
        </div>--%>
        <div class="tbitem">
        <p class="title tab"><span>基本信息</span></p>
        <table cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>会员帐号：</th>
                <td><asp:Label runat="server" ID="lbLoginName"></asp:Label></td>
                <th>企业名称：</th>
                <td>
                    <asp:TextBox runat="server" ID="txtCompanyName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>联系人：</th>
                <td><asp:TextBox runat="server" ID="txtContact"></asp:TextBox></td>
                <th>所在城市：</th>
                <td>
                    <select id="ddlArea" name="ddlArea" class="hideselect" style=" width:158px;">
                        <option value="">选择城市</option>
                        <asp:Literal ID="ltrArea" runat="server"></asp:Literal>
                    </select>
                </td>
            </tr>
            <tr>
                <th>Email：</th>
                <td><asp:TextBox runat="server" ID="txtEmail"></asp:TextBox></td>
                <th>QQ：</th>
                <td><asp:TextBox runat="server" ID="txtQQ"></asp:TextBox></td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td><asp:TextBox runat="server" ID="txtPhone"></asp:TextBox></td>
                <th>其它电话：</th>
                <td><asp:TextBox runat="server" ID="txtOtherPhone"></asp:TextBox></td>
            </tr>
            <tr>
                <th>详细地址：</th>
                <td colspan="3"><asp:TextBox runat="server" ID="txtAddress"></asp:TextBox></td>
                <%--<th>企业网址：</th>
                <td><asp:TextBox runat="server" ID="txtHomePage"></asp:TextBox></td>--%>
            </tr>
            <%--<tr>
                <th>营业面积：</th>
                <td><asp:TextBox runat="server" ID="txtSpace"></asp:TextBox></td>
                <th>员工数量：</th>
                <td><asp:TextBox runat="server" ID="txtEmployeeQty"></asp:TextBox></td>
            </tr>
            <tr>
                <th>相机型号及数量：</th>
                <td><asp:TextBox runat="server" ID="txtCamera"></asp:TextBox></td>
                <th>影棚数量：</th>
                <td><asp:TextBox runat="server" ID="txtStudio"></asp:TextBox></td>
            </tr>--%>
            <tr>
                <th>企业简介：</th>
                <td colspan="3"><asp:TextBox runat="server" ID="txtDescription" Rows="5" Columns="80" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
        </table>
        </div>
        
        <div class="tbitem">
        <p class="title tab"><span>操作</span></p>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>审核状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbVerifyStatus"></asp:Label>
                    <a id="btnVerifyYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_verifyStatus == 1 ? "disabled='true'" : ""%> onclick="Verify(1)">审核通过</a>
                    <a id="btnVerifyNo" class="easyui-linkbutton" iconCls="icon-no" <%=_verifyStatus == -1 ? "disabled='true'" : ""%> onclick="Verify(-1)">审核不通过</a>
                </td>
                <th>登录状态：</th>
                <td>
                    <asp:Label runat="server" ID="lbStatus"></asp:Label>
                    <a id="btnLoginYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_loginStatus == 1 ? "disabled='true'" : ""%> onclick="ChangeLoginStatus(1)">启用</a>
                    <a id="btnLoginNo" class="easyui-linkbutton" iconCls="icon-no" <%=_loginStatus == 0 ? "disabled='true'" : ""%> onclick="ChangeLoginStatus(0)">禁用</a>
                </td>
            </tr>
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
            <tr>
                <th>企业名称：</th>
                <td>
                    <asp:Label runat="server" ID="lbCompanyName_new"></asp:Label>
                </td>
                <th>联系人：</th>
                <td>
                    <asp:Label runat="server" ID="lbContact_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Email：</th>
                <td>
                    <asp:Label runat="server" ID="lbEmail_new"></asp:Label>
                </td>
                <th>QQ：</th>
                <td>
                    <asp:Label runat="server" ID="lbQQ_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>联系电话：</th>
                <td>
                    <asp:Label runat="server" ID="lbPhone_new"></asp:Label>
                </td>
                <th>其它电话：</th>
                <td>
                    <asp:Label runat="server" ID="lbOtherPhone_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>详细地址：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbAddress_new"></asp:Label>
                </td>
                <%--<th>企业网址：</th>
                <td>
                    <asp:Label runat="server" ID="lbHomepage_new"></asp:Label>
                </td>--%>
            </tr>
            <%--<tr>
                <th>营业面积：</th>
                <td>
                    <asp:Label runat="server" ID="lbSpace_new"></asp:Label>
                </td>
                <th>员工数量：</th>
                <td>
                    <asp:Label runat="server" ID="lbEmployeeQty_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>相机型号及数量：</th>
                <td>
                    <asp:Label runat="server" ID="lbCamera_new"></asp:Label>
                </td>
                <th>影棚数量：</th>
                <td>
                    <asp:Label runat="server" ID="lbStudio_new"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <th>企业简介：</th>
                <td colspan="3">
                    <asp:Label runat="server" ID="lbDescription_new"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <a id="btnVerifyNewYes" class="easyui-linkbutton" iconCls="icon-ok" <%=_newinfoVerifyStatus == 1 ? "disabled='true'" : ""%> onclick="VerifyNewInfo(1)">通过</a>
                    <a id="btnVerifyNewNo" class="easyui-linkbutton" iconCls="icon-no" <%=_newinfoVerifyStatus == -1 ? "disabled='true'" : ""%> onclick="VerifyNewInfo(-1)">不通过</a>
                </td>
            </tr>
        </table>
        </div>
        </asp:PlaceHolder>
    <div id="Add">
    </div>
    </form>
    <%--<script type="text/javascript">var areas = <asp:Literal ID="ltrAreaJsObject" runat="server"></asp:Literal>;</script>--%>
    <%--<script type="text/javascript">
        $('#ddlAreaProvince').formSelect({
            //emptyText : '请选择省份...',
            cols: 4,
            colWidth: 80,
            onSelect: function () {
                $('#ddlAreaCity').children().remove();
                $.each(areas[$('#ddlAreaProvince').val()], function (key, value) {
                    $('#ddlAreaCity').append($('<option value="' + key + '">' + value + '</option>'));
                });

                //调用内部函数刷新
                $('#ddlAreaProvince').data('Obj').reflash($('#ddlAreaCity'));
            },
            onShow: function () {
                $('#ddlAreaProvince').trigger('focusListener');
            },
            onClose: function () {
                $('#ddlAreaProvince').trigger('blurListener');
            }

        });

        $('#ddlAreaCity').formSelect({
            emptyText: '请选择城市...',
            cols: 3,
            colWidth: 80
        });
    </script>--%>
    <script type="text/javascript">
        $('#ddlArea').jAreaSelect();
    </script>
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

        function ChangeLoginStatus(status) {
            if (!confirm("确定要更改为" + (status == 1 ? "【启用】" : "【禁用】") + "吗？")) { return false; }
            $.ajax({
                url: $('#formEdit').attr('action') + '&ajax=1',
                data: { 'action': 'ChangeLoginStatus', 'status': status },
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
                                $('#lbStatus').text('启用');
                            } else {
                                $('#btnLoginYes').linkbutton('enable');
                                $('#btnLoginNo').linkbutton('disable');
                                $('#lbStatus').text('禁用');
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
