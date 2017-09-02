<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipCompanyLevel.aspx.cs" Inherits="NH.Web.adm.Company.VipCompanyLevel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <style type="text/css">#rblLevels label{ margin-right:10px;}</style>
    <%--<%=JsTextBoxClass %>--%>
    <form id="formCompanyLevelInfo" runat="server" enableviewstate="false">
    <div>
        <div class="frmborder">
            <p>
                信息--<%=_levelinfo %></p>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>
                    选择等级：
                </th>
                <td>
                    <span id="rblLevels">
                    <asp:Repeater runat="server" ID="rptList">
                        <ItemTemplate>
                        <input type="radio" value="<%#Eval("Id") %>" name="rblLevels" id="rblLevels_<%#Container.ItemIndex %>" <%# (int)Eval("Id")==_levelId ? "checked=\"checked\"" : "" %> RefreshJobCount="<%#Eval("RefreshJobCount") %>" FixCount="<%#Eval("FixCount") %>" AlbumCount="<%#Eval("AlbumCount") %>" ExpireNum="<%#Eval("ExpireNum") %>" ExpireUnit="<%#Eval("ExpireUnit") %>" ExpireDate="<%#GetExpireDate((int)Eval("ExpireNum"),Eval("ExpireUnit").ToString()) %>" /><label for="rblLevels_<%#Container.ItemIndex %>"><%#Eval("LevelName") %></label>
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
                    <a id="btnYes" class="easyui-linkbutton" iconCls="icon-ok" onclick="javascript:ModifyLevel()">保存</a>
                </td>
            </tr>
        </table>
        <br />
        <div class="frmborder">
            <p>
                历史操作记录</p>
        </div>
        <asp:Repeater ID="rptLog" runat="server">
            <HeaderTemplate>
                <table id="tablist" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="th">
                        <td>等级</td>
                        <td>到期日期</td>
                        <td>操作时间</td>
                        <td>操作方式</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr">
                    <td>
                        <%#Eval("LevelName")%>
                    </td>
                    <td>
                        <%#Eval("ExpireDate","{0:yyyy-MM-dd}")%>
                    </td>
                    <td><%# Eval("AddTime") %></td>
                    <td><%# (int)Eval("AddType") == 1 ? "人工操作" : "自助开通" %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
    </form>

    <script type="text/javascript">
        $('[name=rblLevels]').click(function () {
            var levelId = $(this).val();
            if (levelId == 1) {
                $('#txtCompanyExpireDate').datebox('setValue', '');
            } else {
                //var date = $(this).attr('ExpireDate');
                //$('#txtCompanyExpireDate').datebox('setValue', date);
            }
        });
    </script>
    <script type="text/javascript">
        function ModifyLevel() {
            var levelId = $('[name=rblLevels]:checked').val();
            if (!levelId) return false;
            $.ajax({
                url: $('#formCompanyLevelInfo').attr('action'),
                data: { 'action': 'modify', 'LevelId': levelId, 'ExpireDate': $('[name=txtCompanyExpireDate]').val(), 'IsFix': $('#cbIsFix').is(':checked') },
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    switch (data.status) {
                        case "ok":
                            alert('保存成功');
                            $('#win').window('refresh', '<%=Request.RawUrl %>').data('refresh','1');
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
