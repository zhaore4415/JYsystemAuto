<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyLogo.aspx.cs" Inherits="NH.Web.adm.Company.CompanyLogo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%=CssAndScript %>
    <script type="text/javascript" src="/Scripts/jquery.form.js"></script>
</head>
<body>
    <form id="formCompanyLogo" runat="server">
    <div>
        <table width="100%" cellpadding="0" cellspacing="0" class="utable">
            <tr>
                <th>企业LOGO：</th>
                <td>
                    <asp:PlaceHolder runat="server" ID="phImg"><asp:Image runat="server" ID="img" /><br /><br /></asp:PlaceHolder>
                    <asp:FileUpload runat="server" ID="fileLogo" />(点击上传图片)
                </td>
            </tr>
            <tr>
                <th></th>
                <td><asp:Button runat="server" ID="btnSubmit" Text="保存" onclick="btnSubmit_Click" CssClass="btnSubmit" /></td>
            </tr>
        </table>
        
    </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            var form = $('#<%=formCompanyLogo.ClientID %>');
            form.ajaxForm({
                beforeSubmit: function () {
                    alert('submit');
                    return true;
                    //return beforsubmit();
                    //return form.validate().form();
                },dataType:'json'
                , success: function (data) {
                    switch (data.status) {
                        case 'ok':
                            alert('添加成功');
                            window.location.href = window.location.href;
                            break;
                        case 'error':
                            alert(data.msg);
                            break;
                        case "nologin":
                            alert('请登录');
                            break;
                    }
                },
                error: function () { alert('发生错误'); }
            });
        });
    </script>
</body>
</html>
