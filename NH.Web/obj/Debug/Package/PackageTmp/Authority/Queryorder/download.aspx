<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="NH.Web.Member.Authority.Queryorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>.myform-star {
    color: Red;
    margin: 0px 5px 0px 5px;
}</style>
</head>
<body>
    <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
        <h4 class="modal-title" id="exampleModalLabel">订单批量上传</h4>
    </div>
    
        <div class="modal-body" style="height: 250px">

            <table style="width: 100%;" cellpadding="5" cellspacing="5" class="border">
                <tr>
                    <td colspan="2" align="center">
                        <form action="../../Ajax/file/Upload_File_json.ashx" method="post" id="frmUpload" enctype="multipart/form-data">
                            <input name="fileExcel" id="fileExcel" type="file" />
                            <input type="hidden" id="uploadFilePath" name="uploadFilePath" value="Uploads/excel_import_temporary" />
                        </form>
                        <span class="myform-star">请确保每行都存在序号！无序号的数据将跳过不执行！请使用Excel2007或以上版本！</span>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" align="center">
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                            <button type="submit" class="btn btn-primary">确认</button>
                        </div>
                        <%--<a href="#" class="easyui-linkbutton" onclick="onUploadExcelHandle();" data-options="iconCls:'icon-save',plain:false">确 定</a>--%>
                        <%--<a href="#" class="easyui-linkbutton" onclick="onClose();" data-options="iconCls:'icon-undo',plain:false">取 消</a>--%>
                    </td>
                </tr>
            </table>
        </div>

  
   
</body>
</html>
