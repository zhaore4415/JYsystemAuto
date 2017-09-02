<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelUploadHandle.aspx.cs" Inherits="NH.Web.Authority.Queryorder.ExcelUploadHandle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
 
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <script src="/Scripts/jquery.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="/css/matrix-style.css" />
    <link rel="stylesheet" href="/css/matrix-media.css" />
    <link href="/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="/Scripts/Ewin.js"></script>
    <link href="/Scripts/bootstrap-select/bootstrap-select.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.8.2.min.js"></script>
    <script src="/Scripts/JMessage.js?var=201707"></script>
    <script src="/Scripts/jquery.form.js" type="text/javascript"></script>
    <script src="/Scripts/J_HttpRequestExtend.js?var=2017" type="text/javascript"></script>
    <script type="text/javascript">
        
        //确定上载Excel
        function onUploadExcelHandle() {

            var fileVal = $("#fileExcel").val();
            try {
                //校验文件格式
                var seat = fileVal.lastIndexOf(".");
                var filestr = "";
                //返回位于String对象中指定位置的子字符串并转换为小写.
                var extension = fileVal.substring(seat).toLowerCase();
                if (extension != "") {
                    var allowed = [".xls", ".xlsx"];
                    for (var i = 0; i < allowed.length; i++) {
                        if (allowed[i] == extension) {
                            filestr = "true";
                        }
                    }
                    if (filestr == "") {
                        //msg_alert_2("3089", "", extension);
                        alert("不支持" + extension + "格式！")
                        return false;
                    }
                }

                var tempPath = "";
                //先将客户端Excel文件上传到服务器临时目录---ajaxSubmit方式注意jquery的版本
                $("#frmUpload").ajaxSubmit({
                    success: function (data) {
                     
                        if (data == "0") {
                            //$.messager.alert("文件上传服务器临时目录失败！");
                            alert("文件上传服务器临时目录失败");

                            return;
                        }
                        else {
                            //文件上传成功  开始操作
                            tempPath = data;

                            $.ajax({
                                type: "post",
                                url: '/Ajax/excel/Upload_Electronic_sheet_json.ashx',
                                dataType: "json",
                                data: { "filepath": tempPath },
                                success: function (res) {

                                    msg_confirm_list(res.ResultNumber, function () {
                                        window.open(res.Attribute4, '上传日志', 'width=' + (window.screen.availWidth - 10) + ',height=' + (window.screen.availHeight - 30) + ',top=0,left=0,toolbar=no,menubar=no,scrollbars=yes, resizable=no,location=no, status=no')

                                    }, function () {

                                    }, [res.Attribute1, res.Attribute2, res.Attribute3]);
                                    debugger;
                                    if (parseInt(res.Attribute2) > 0) {
                                        //成功数量大于0  则刷新父层列表
                                        //window.parent.$("#listdg").datagrid("reload");
                                        $("#listdg").bootstrapTable('refresh');
                                        //window.location.href = 'Queryorder.aspx';
                                        //$('#modal3').modal('hide');
                                        //$('#modal').modal('hide');
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    msg_alert("数据校验错误");
                                    //$("#open_load").window("close");
                                }
                            });


                        }
                    },
                    async: false,
                    error: function (error) {
                        alert("操作失败！");  //操作失败
                        console.log(error);
                    },

                    url: '/Ajax/file/Upload_File_json.ashx', /*设置post提交到的页面*/
                    type: "post", /*设置表单以post方法提交*/
                    dataType: "text/json" /*设置返回值类型为文本*/
                });
            } catch (e) {
                alert("操作失败！" + e);  //操作失败
                console.log(e);
            }

        }

        function onClose() {
            //window.parent.$('#divExcel_upload').window('close');
            //window.parent.$('#ibody_excel').attr('src', "");
        }


    </script>
</head>
<body>

    <div class="panel panel-default">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><%--<span aria-hidden="true">×</span>--%></button>
            <h4 class="modal-title" id="exampleModalLabel">订单批量导入</h4>
        </div>

        <div class="modal-body">
            <div class="form-horizontal" role="form">
                <div class="form-group">

                    <label for="inputfile" class="col-sm-2 control-label">文件输入</label>
                    <div class="col-sm-10">
                        <form id="frmUpload" enctype="multipart/form-data">
                            <input name="fileExcel" id="fileExcel" type="file" />
                            <input type="hidden" id="uploadFilePath" name="uploadFilePath" value="Upload/excel_import_temporary" />
                        </form>
                    </div>
                    <p class="help-block">请确保每行都存在序号！无序号的数据将跳过不执行！请使用Excel2007或以上版本！。</p>

                </div>

                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            关闭
                        </button>

                        <a id="ibtnSave" class="btn btn-default" clientidmode="Static" href="javascript:void(0)" onclick="onUploadExcelHandle();">提交</a>

                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
