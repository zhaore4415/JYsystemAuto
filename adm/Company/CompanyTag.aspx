<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyTag.aspx.cs" Inherits="NH.Web.adm.Company.CompanyTag" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="easyui-accordion">
        <div title="紧急招聘" data-options="iconCls:'icon-<%=_status1 == 1 ? "ok" : "no" %>'" style="padding: 10px;">
            <form id="formTag_JinJi" action="CompanyTag.aspx?id=<%=Id %>" method="post" enctype="multipart/form-data">
            <table cellpadding="0" cellspacing="0" class="utable">
                <tr>
                    <th>推荐：</th>
                    <td><input type="checkbox" id="cbTag1" name="cbTag1" value="1" <%=_status1 > 0 ? "checked=\"checked\"" : "" %> /><label for="cbTag1">紧急招聘</label></td>
                </tr>
                <tr>
                    <th>图片：</th>
                    <td>
                        <%if(_TagImg1 != null) {%><div><img src="<%=_TagImg1 %>" />　<a href="#" onclick="$('#file1').show();return false">重新上传</a></div><%} %>
                        <input type="file" id="file1" name="file1" <%if(_TagImg1 != null) {%>style="display:none"<%} %> />
                    </td>
                </tr>
                <tr>
                    <th>开放时间：</th>
                    <td><input type="text" id="txtStartDate1" name="txtStartDate1" class="easyui-datebox" value="<%=_startdate1 %>" />至<input type="text" id="txtEndDate1" name="txtEndDate1" class="easyui-datebox" value="<%=_enddate1 %>" /></td>
                </tr>
                <tr>
                    <th></th>
                    <td><a id="btnJinJi" class="easyui-linkbutton" iconCls="icon-save" <%=_status1 == 0 ? "disabled=\"true\"" : "" %> onclick="$('#formTag_JinJi').submit()">保存</a><input type="hidden" id="action_1" name="action" value="JinJi" /><input type="hidden" name="TagId" value="<%=_TagId1 %>" /></td>
                </tr>
            </table>
            </form>  
        </div>
        <div title="VIP招聘" data-options="iconCls:'icon-<%=_status2 == 1 ? "ok" : "no" %>'" style="padding: 10px;">
            <form id="formTag_VIP" action="CompanyTag.aspx?id=<%=Id %>" method="post" enctype="multipart/form-data">
            <table cellpadding="0" cellspacing="0" class="utable">
                <tr>
                    <th>推荐：</th>
                    <td><input type="checkbox" id="cbTag2" name="cbTag2" value="1" <%=_status2 > 0 ? "checked=\"checked\"" : "" %> /><label for="cbTag2">VIP招聘</label></td>
                </tr>
                <tr>
                    <th>图片：</th>
                    <td>
                        <%if(_TagImg2 != null) {%><div><img src="<%=_TagImg2 %>" />　<a href="#" onclick="$('#file2').show();return false">重新上传</a></div><%} %>
                        <input type="file" id="file2" name="file2" <%if(_TagImg2 != null) {%>style="display:none"<%} %> />
                    </td>
                </tr>
                <tr>
                    <th>开放时间：</th>
                    <td><input type="text" id="txtStartDate2" name="txtStartDate2" class="easyui-datebox" value="<%=_startdate2 %>" />至<input type="text" id="txtEndDate2" name="txtEndDate2" class="easyui-datebox" value="<%=_enddate2 %>" /></td>
                </tr>
                <tr>
                    <th></th>
                    <td><a id="btnVIP" class="easyui-linkbutton" iconCls="icon-save" <%=_status2 == 0 ? "disabled=\"true\"" : "" %> onclick="$('#formTag_VIP').submit()">保存</a><input type="hidden" id="action_2" name="action" value="VIP" /><input type="hidden" name="TagId" value="<%=_TagId2 %>" /></td>
                </tr>
            </table>
            </form>
        </div>
        <div title="品牌招聘" data-options="iconCls:'icon-<%=_status3 == 1 ? "ok" : "no" %>'" style="padding: 10px;">
            <form id="formTag_PinPai" action="CompanyTag.aspx?id=<%=Id %>" method="post" enctype="multipart/form-data">
            <table cellpadding="0" cellspacing="0" class="utable">
                <tr>
                    <th>推荐：</th>
                    <td><input type="checkbox" id="cbTag3" name="cbTag3" value="1" <%=_status3 > 0 ? "checked=\"checked\"" : "" %> /><label for="cbTag3">品牌招聘</label></td>
                </tr>
                <tr>
                    <th>图片：</th>
                    <td>
                        <%if(_TagImg3 != null) {%><div><img src="<%=_TagImg3 %>" />　<a href="#" onclick="$('#file3').show();return false">重新上传</a></div><%} %>
                        <input type="file" id="file3" name="file3" <%if(_TagImg3 != null) {%>style="display:none"<%} %> />
                    </td>
                </tr>
                <tr>
                    <th>开放时间：</th>
                    <td><input type="text" id="txtStartDate3" name="txtStartDate3" class="easyui-datebox" value="<%=_startdate3 %>" />至<input type="text" id="txtEndDate3" name="txtEndDate3" class="easyui-datebox" value="<%=_enddate3 %>" /></td>
                </tr>
                <tr>
                    <th></th>
                    <td><a id="btnPinPai" class="easyui-linkbutton" iconCls="icon-save" <%=_status3 == 0 ? "disabled=\"true\"" : "" %> onclick="$('#formTag_PinPai').submit()">保存</a><input type="hidden" id="action_3" name="action" value="PinPai" /><input type="hidden" name="TagId" value="<%=_TagId3 %>" /></td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            <%if(_status1 == 0){%>
            $('#cbTag1').click(function(){
                if($(this).is(':checked')){$('#btnJinJi').linkbutton('enable');}else{$('#btnJinJi').linkbutton('disable');}
            });
            <%} %>
            <%if(_status2 == 0){%>
            $('#cbTag2').click(function(){
                if($(this).is(':checked')){$('#btnVIP').linkbutton('enable');}else{$('#btnVIP').linkbutton('disable');}
            });
            <%} %>
            <%if(_status3 == 0){%>
            $('#cbTag3').click(function(){
                if($(this).is(':checked')){$('#btnPinPai').linkbutton('enable');}else{$('#btnPinPai').linkbutton('disable');}
            });
            <%} %>
            $('#formTag_JinJi,#formTag_VIP,#formTag_PinPai').form({
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
                            var tab = $('#tt').tabs('getSelected');  // get selected panel
                            tab.panel('refresh', '<%=Request.RawUrl %>');
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

</body>
</html>
