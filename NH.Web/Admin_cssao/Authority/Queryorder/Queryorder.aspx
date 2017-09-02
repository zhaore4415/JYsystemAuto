<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Queryorder.aspx.cs" Inherits="NH.Web.adm.Authority.Queryorder.Queryorder" %>

<%@ Register Src="~/Admin_cssao/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="~/Admin_cssao/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>订单列表</title>
    <%=CssAndScript %>
    <link href="/css/css.css" rel="stylesheet" />
    <link href="/css/index.css" rel="stylesheet">
    <script src="/Scripts/bootstrap-table/bootstrap-table.js"></script>
    <link href="/Scripts/bootstrap-table/bootstrap-table.css" rel="stylesheet" />
    <script src="/Scripts/bootstrap-table/locale/bootstrap-table-zh-CN.js"></script>
    <script src="/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <script src="/Scripts/bootstrap-select/bootstrap-select.js"></script>
    <script src="/Scripts/Ewin.js"></script>

    <%--<link href="/Scripts/bootstrap-select/bootstrap-select.min.css" rel="stylesheet" />--%>
    <style>
        .Wdate {
            height: 32px;
        }

        label {
            height: 30px;
            line-height: 30px;
            text-align: right;
        }

        .col-sm-1 {
            padding-right: 5px;
            padding-left: 5px;
        }
    </style>
    <script type="text/javascript">

        $(function () {

            onloadgride();
            $("#btn_delete").click(function () {
                var ids = "";
                var rows = $("#listdg").bootstrapTable('getSelections');
                if (rows.length <= 0) {
                    alert('请选择有效数据');
                    //$('#modal').modal('hide');
                    return false;
                }
                else {
                    for (var i = 0; i < rows.length; i++) {
                        var row = rows[i];
                        ids += row.Id + ",";
                    }
                }

                Ewin.confirm({ message: "确认要删除选择的数据吗？" }).on(function (e) {
                    if (!e) {
                        return;
                    }
                    $.ajax({
                        type: "post",
                        url: "/Ajax/Queryorder/QueryorderAdd.ashx?action=delete",
                        data: { "ids": ids },
                        success: function (status) {
                            if (status == "1") {
                                alert('删除数据成功');
                                $("#listdg").bootstrapTable('refresh');
                            }
                        },
                        error: function () {
                            alert("删除失败");
                        },
                        complete: function () {

                        }

                    });
                });
            });
            var modal = $("#modal2");
            modal.on("show.bs.modal", function (e) {
                $(this).removeData("bs.modal");//加载前刷新
                // 这里的btn就是触发元素，即你点击的删除按钮
                //var btn = $(e.relatedTarget),
                //    id = btn.data("id");

                //alert(id);
                var ids = "";
                var rows = $("#listdg").bootstrapTable('getSelections');

                if (rows.length != 1) {
                    alert('请确保选择一条数据');
                    //$('#modal2').modal('hide');
                    return false;
                }

            });
            //modal数据只加载一次，如果要加载不同的数据，例如根据id查询不同物品的详细信息，modal的数据是不能更新的，即使传的id值不同。其实解决办法很简单，只需要在加载下次数据前，将之前的加载的数据清除即可。
            //modal.on("hidden.bs.modal", function () {
            //    $(this).removeData("bs.modal");
            //});

            $('#modal3').on('hidden.bs.modal', function () {
                window.location.href = 'Queryorder.aspx';
            });
            //$('#modal3').modal('hidden');
        });

        function onloadgride() {
            //1.初始化Table
            var oTable = new TableInit();
            oTable.Init();

            //2.初始化Button的点击事件
            var oButtonInit = new ButtonInit();
            oButtonInit.Init();
        }

        var TableInit = function () {
            var oTableInit = new Object();
            //初始化Table
            oTableInit.Init = function () {
                $('#listdg').bootstrapTable({
                    url: '/Ajax/Queryorder/QueryorderManage.ashx',        //请求后台的URL（*）
                    method: 'get',                      //请求方式（*）
                    toolbar: '#toolbar',                //工具按钮用哪个容器
                    striped: true,                      //是否显示行间隔色
                    pagination: true,                   //是否显示分页（*）

                    sortName: '[Id]',
                    sortOrder: 'desc',
                    singleSelect: false,
                    queryParams: oTableInit.queryParams,//传递参数（*）
                    sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
                    pageNumber: 1,                       //初始化加载第一页，默认第一页
                    pageSize: 10,                       //每页的记录行数（*）
                    pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
                    //showRefresh: true,                  //是否显示刷新按钮
                    search: false, //不显示 搜索框
                    showColumns: false, //不显示下拉框（选择显示的列）
                    minimumCountColumns: 2,             //最少允许的列数
                    height: 500,                //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
                    //uniqueId: "ID",                     //每一行的唯一标识，一般为主键列
                    columns: [{
                        checkbox: true
                    }, {
                        field: 'Id',
                        title: 'ID',
                        sortable: true
                    }, {
                        field: 'DeliveryTime',
                        title: '交易时间',
                        sortable: true
                    }, {
                        field: 'LoginName',
                        title: '会员'

                    }, {
                        field: 'OrderNumber',
                        title: '订单号',
                        sortable: true
                    }, {
                        field: 'Babynumber',
                        title: '商品数量',
                        sortable: true
                    }, {
                        field: 'Amount',
                        title: '金额',
                        sortable: true
                    }, {
                        field: 'Status',
                        title: '订单状态',
                        formatter: statusFormat
                    }],
                    onCheck: function (row) {

                        var ids = row.Id;

                        $("#btn_model").attr("href", "QueryorderModify.aspx?ids=" + ids);

                        return false;
                    },

                });
            };
            //订单状态，0未支付，1已支付，2已完成，3已取消，4已退款
            function statusFormat(val) {
                var strStatus = "";
                switch (val) {
                    case "0":
                        strStatus = "未支付";
                        break;
                    case "1":
                        strStatus = "已支付";
                        break;
                    case "2":
                        strStatus = "已完成";
                        break;
                    case "3":
                        strStatus = "已取消";
                        break;
                    case "4":
                        strStatus = "已退款";
                        break;
                    default:
                        strStatus = "未知";
                }
                return strStatus;
            }
            //得到查询的参数
            oTableInit.queryParams = function (params) {
                var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
                    limit: params.limit,   //页面大小
                    offset: params.offset,  //页码
                    sort: params.sort,
                    order: params.order,
                    U_ID: $("#hid_U_ID").val(),
                    name: $("#txt_Name").val(),
                    OrderNumber: $("#txt_OrderNumber").val(),
                    status: $("#selStatus").val(),
                    START_DATE: $('#txtSTART_DATE').val(),
                    END_DATE: $('#txtEND_DATE').val()
                };
                return temp;
            };
            return oTableInit;
        };


        var ButtonInit = function () {
            var oInit = new Object();
            var postdata = {};

            oInit.Init = function () {
                //初始化页面上面的按钮事件
                $("#btn_query").click(function () {
                    $("#listdg").bootstrapTable('refresh');
                });
            };

            return oInit;
        };
        ////Excel导入/上载
        //function onUpLoadExcel() {
        //    //$("#divExcel_upload").window("open");
        //    //$("#ibody_excel").attr("src", "ExcelUploadHandle.aspx");

        //    $("#modal3").modal({
        //        remote: "ExcelUploadHandle.aspx"
        //    });
        //}

        //下载系统Excel模板
        function onDownLoadMasterExcel() {
            location.href = "/Upload/excel_temps/Queryorder导入模板.xlsx";
        }
        //function aa() {
        //    showModalDialog('ExcelUploadHandle.aspx','', 'width=100,height=100,top=0,left=0,toolbar=no,menubar=no,scrollbars=yes, resizable=no,location=no, status=no');
        //}
    </script>
</head>
<body>

    <uc2:Head ID="Head1" runat="server" />
    <uc1:left ID="left1" runat="server" />

    <div id="content">
        <form id="form1" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <a href="/Member/Queryorder.aspx"><< 返回全部</a>  &nbsp;  &nbsp; &nbsp;会员 
                    <asp:Label ID="lb_Name" CssClass="control-label" runat="server" Text="" Font-Bold="true"></asp:Label>
                    订单列表：
                </div>
                <div class="panel-body">

                    <div class="form-group" style="margin-top: 15px">
                        <label class="control-label col-sm-1" for="txtSTART_DATE">开始日期：</label>
                        <div class="col-sm-1">
                            <input class="form-control Wdate " type="text" onclick="WdatePicker()" name="txtSTART_DATE" id="txtSTART_DATE"
                                runat="server" />
                        </div>
                        <label class="control-label col-sm-1" for="txtEND_DATE">结束日期：</label>
                        <div class="col-sm-1">
                            <input class="form-control Wdate" type="text" onclick="WdatePicker()" name="txtEND_DATE" id="txtEND_DATE"
                                runat="server" />
                        </div>

                        <label class="control-label col-sm-1" for="txt_Name">会员：</label>
                        <div class="col-sm-1">
                            <input type="text" class="form-control" id="txt_Name" runat="server">
                            <asp:HiddenField ID="hid_U_ID" runat="server" />
                        </div>
                        <label class="control-label col-sm-1" for="txt_OrderNumber">订单号：</label>
                        <div class="col-sm-1">
                            <input type="text" class="form-control" id="txt_OrderNumber">
                        </div>
                        <label class="control-label col-sm-1" for="txt_search_statu">状态：</label>
                        <div class="col-sm-1">
                            <select id="selStatus" class="form-control" runat="server">
                                <option value="" selected="selected">All</option>
                                <option value="0">未支付</option>
                                <option value="1">已支付</option>
                                <option value="2">已完成</option>
                                <option value="3">已取消</option>
                                <option value="4">已退款</option>
                            </select>

                        </div>
                        <div class="col-sm-1" style="text-align: left;">
                            <button type="button" style="margin-left: 50px" id="btn_query" class="btn btn-primary">查询</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>

        <div class="widget-box">
            <div class="widget-content nopadding table-responsive">
                   <div >

                    <button id="btn_delete" type="button" class="btn btn-info btn-xs">
                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>删除
                    </button>
                    <a href="QueryorderAdd.aspx" class="btn btn-info btn-xs" data-target="#modal" data-toggle="modal"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span>添加订单</a>
                    <%-- $("#myModal").modal({  
                            remote: "page.jsp"  
                        }); --%>
                    <a href="QueryorderModify.aspx" id="btn_model" class="btn btn-info btn-xs" data-target="#modal2" data-toggle="modal"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>修改订单</a>

                    <a id="A_downLoadMasterExcel" href="javascript:void(0)" class="btn btn-info btn-xs" onclick="onDownLoadMasterExcel();">EXCEL导入模板下载</a>

                    <a href="ExcelUploadHandle.aspx" class="btn btn-info btn-xs" data-target="#modal3" data-toggle="modal">EXCEL订单导入</a>

                <%--<a id="" href="javascript:void(0)" class="btn btn-info btn-xs" onclick="aa();">EXCEL订单导入</a>--%>

                    <!-- 模态框（添加订单） -->
                    <div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="modal">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                            </div>
                        </div>
                    </div>
                    <!-- 模态框（修改订单） -->
                    <div class="modal fade" id="modal2" tabindex="-2" role="dialog" aria-labelledby="modal">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                            </div>
                        </div>
                    </div>
                      <!-- 模态框（EXCEL订单导入） -->
                    <div class="modal fade" id="modal3" tabindex="-3" role="dialog" aria-labelledby="modal">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                            </div>
                        </div>
                    </div>
                    <!-- 模态框（EXCEL订单导入） -->
                    <%--<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                        &times;
                                    </button>
                                    <h4 class="modal-title" id="myModalLabel">EXCEL订单导入
                                    </h4>
                                </div>
                                <div class="modal-body">
                                    <table style="width: 100%;" cellpadding="5" cellspacing="5" class="border">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <form id="frmUpload" enctype="multipart/form-data">
                                                    <input name="fileExcel" id="fileExcel" type="file" />
                                                    <input type="hidden" id="uploadFilePath" name="uploadFilePath" value="Upload/excel_import_temporary" />
                                                </form>
                                                <span class="myform-star">请确保每行都存在序号！无序号的数据将跳过不执行！请使用Excel2007或以上版本！</span>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        关闭
                                    </button>
                                    <button type="button" class="btn btn-primary">
                                        提交
                                    </button>
                                </div>
                            </div>

                        </div>

                    </div>--%>



                </div>
                <table id="listdg" class="table table-bordered table-striped"></table>
             
            </div>
        </div>
    </div>


</body>
</html>
