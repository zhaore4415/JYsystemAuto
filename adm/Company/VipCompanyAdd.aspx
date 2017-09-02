<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipCompanyAdd.aspx.cs" Inherits="NH.Web.adm.Company.VipCompanyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">#rblLevels label{ margin-right:10px;}</style>
    <form id="formAddVipCompany" runat="server" enableviewstate="false">
    <div>
        <div class="frmborder">
            <p>
                添加VIP企业</p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>企业：</th>
                <td>
                    <input type="text" id="txtQueryKey" class="txtSmall" />查询条件：<input type="radio" id="keytype1" name="keytype" checked="checked" value="1" /><label for="keytype1">企业ID</label><input type="radio" id="keytype2"  name="keytype" value="2" /><label for="keytype2">企业名称</label><input type="radio" id="keytype3" name="keytype" value="3" /><label for="keytype3">企业登录名</label><input type="button" onclick="QueryCompany();" class="btnSmall" value="查询" /><span id="cinfo" class="red" style=" display:block;"></span><input type="hidden" id="cid" name="cid" />
                </td>
            </tr>
            <tr>
                <th>
                    选择等级：
                </th>
                <td>
                    <span id="rblLevels">
                    <asp:Repeater runat="server" ID="rptList">
                        <ItemTemplate>
                        <input type="radio" value="<%#Eval("Id") %>" name="rblLevels" id="rblLevels_<%#Container.ItemIndex %>" RefreshJobCount="<%#Eval("RefreshJobCount") %>"  FixCount="<%#Eval("FixCount") %>" AlbumCount="<%#Eval("AlbumCount") %>" ExpireNum="<%#Eval("ExpireNum") %>" ExpireUnit="<%#Eval("ExpireUnit") %>" ExpireDate="<%#GetExpireDate((int)Eval("ExpireNum"),Eval("ExpireUnit").ToString()) %>" /><label for="rblLevels_<%#Container.ItemIndex %>"><%#Eval("LevelName") %></label>
                        </ItemTemplate>
                    </asp:Repeater>
                    </span>
                </td>
            </tr>
            <tr>
                <th>
                    到期日期：
                </th>
                <td>
                    <asp:TextBox runat="server" ID="txtCompanyExpireDate" CssClass="easyui-datebox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                </th>
                <td>
                    <a id="btnAddVIP" class="easyui-linkbutton" iconCls="icon-ok" disabled="true" onclick="javascript:AddVipCompany()">保存</a>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        $('[name=rblLevels]').click(function () {
            var levelId = $(this).val();
            if (levelId == 1) {
                $('#txtCompanyExpireDate').datebox('setValue', '');
            } else {
                var date = $(this).attr('ExpireDate');
                $('#txtCompanyExpireDate').datebox('setValue', date);
            }
        });
    </script>
    <script type="text/javascript">
        function QueryCompany() {
            var key = $.trim($('#txtQueryKey').val());
            if (key == "") { return; }
            var keytype = $('[name=keytype]:checked').val();
            if (keytype == "1" && isNaN(key)) {alert("企业ID只能是数字");return;}

            var objinfo = $('#cinfo'),objcid=$('#cid');
            objinfo.text('正在查询...');
            objcid.val('');
            $('#btnAddVIP').linkbutton('disable');
            $.ajax({
                url: 'VipCompanyAdd.aspx?action=query',
                data: { "key": key, "keytype": $('[name=keytype]:checked').val() },
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    switch (data.status) {
                        case "ok":
                            if (data.data) {
                                objinfo.text('企业名称：' + data.data.cname + '，登录名：' + data.data.loginname);
                                if (data.data.isvipok == "True") { alert('此企业已是VIP会员'); return; }
                                objcid.val(data.data.CompanyId);
                                $('#btnAddVIP').linkbutton('enable');
                                $('#win').data('refresh', '1');
                            }
                            break;
                        case "error":
                            objinfo.text(data.msg);
                            //alert(data.msg);
                            break;
                        case "nologin":
                            alert('请先登录');
                            break;
                        case "nopower":
                            alert('没有此操作的权限');
                            break;
                    }
                }, error: function () {
                    objinfo.text('发生错误！');
                    alert('发生错误！');
                }
            });
        }
    </script>
    <script type="text/javascript">
        function AddVipCompany() {
            var cid = $('#cid').val();
            var levelId = $('[name=rblLevels]:checked').val();
            var expiredate = $('[name=txtCompanyExpireDate]').val();
            if (cid == "") {alert("请指定要添加的企业");return false;};
            if (!levelId) { alert("请选择会员等级"); return false };
            if (expiredate == "") { alert("请填写到期日期"); return false; }
            $.ajax({
                url: $('#formAddVipCompany').attr('action'),
                data: { 'action': 'add','CompanyId':cid, 'LevelId': levelId, 'ExpireDate': expiredate, 'IsFix': $('#cbIsFix').is(':checked') },
                type: 'post',
                dataType: 'json',
                success: function (data) {
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
            return false;
        }
    </script>
</body>
</html>
