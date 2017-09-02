<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillManage.aspx.cs" Inherits="NH.Web.adm.Authority.Bill.BillManage" %>

<%@ Register Src="~/Admin_cssao/Controls/left.ascx" TagName="left" TagPrefix="uc1" %>
<%@ Register Src="~/Admin_cssao/Controls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>账单列表</title>
    <%=CssAndScript %>

    <link href="/css/css.css" rel="stylesheet" />
    <link href="/css/index.css" rel="stylesheet">
    <script src="/Scripts/bootstrap-table/bootstrap-table.js"></script>
    <link href="/Scripts/bootstrap-table/bootstrap-table.css" rel="stylesheet" />
    <script src="/Scripts/bootstrap-table/extensions/export/bootstrap-table-export.min.js"></script>
    <script src="/Scripts/bootstrap-table/extensions/export/tableExport.js"></script>
    <script src="/Scripts/bootstrap-table/locale/bootstrap-table-zh-CN.js"></script>
    <script src="/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>
    <style>
        .Wdate {
            height: 32px;
        }
    </style>
    <script type="text/javascript">

        $(function () {

            onloadgride();
            //$('#toolbar').find('select').change(function () {
            //    $table.bootstrapTable('refreshOptions', {
            //        exportDataType: $(this).val()
            //    });
            //});
     

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
                    url: '/Ajax/Bill/BillManage.ashx',        //请求后台的URL（*）
                    method: 'get',                      //请求方式（*）
                    toolbar: '#toolbar',                //工具按钮用哪个容器
                    striped: true,                      //是否显示行间隔色
                    pagination: true,                   //是否显示分页（*）
                    showExport: true,                     //是否显示导出
                    exportDataType: "all",              //basic', 'all', 'selected'.
                    exportTypes: ['excel'],
                    sortName: '[u_Id]',
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
                        field: 'U_ID',
                        title: 'ID',
                        align: 'right',
                        width:'120',
                        hidden: true
                    }, {
                        field: 'LoginName',
                        title: '会员',
                        width: '120',
                        sortable: true
                    }, {
                        field: 'Ordernumber',
                        title: '单量',
                        width: '120',
                        sortable: true
                    }, {
                        field: 'OrderAmount',
                        title: '订单金额',
                        width: '120',
                        sortable: true
                    }, {
                        field: 'U_ID',
                        title: '一级会员提成',
                        width: '120',
                        formatter: oneAmountFormat
                    }, {
                        field: 'U_ID',
                        title: '二级会员提成',
                        width: '120',
                        formatter: twoAmountFormat
                    }, {
                        field: 'U_ID',
                        title: '总提成',
                        width: '120',
                        formatter: onePlustwoAmountFormat
                    }]
                });
            };
            //一级会员提成
            function oneAmountFormat(val) {
                var U_ID = val;
                var sum = "";

                $.ajax({
                    type: "post",
                    url: "/Ajax/Queryorder/QueryorderAmount.ashx?action=oneAmount",
                    async: false,//同步  默认true=异步
                    data: {
                        "U_ID": U_ID,
                        "START_DATE": $('#txtSTART_DATE').val(),
                        "END_DATE": $('#txtEND_DATE').val()
                    },
                    success: function (data) {
                        sum = data;
                    },
                    error: function () {
                        sum = "";
                    }
                });
                return sum;
            }

            //二级会员提成
            function twoAmountFormat(val) {
                var U_ID = val;
                var sum = "";

                $.ajax({
                    type: "post",
                    url: "/Ajax/Queryorder/QueryorderAmount.ashx?action=twoAmount",
                    async: false,
                    data: {
                        "U_ID": U_ID,
                        "START_DATE": $('#txtSTART_DATE').val(),
                        "END_DATE": $('#txtEND_DATE').val()
                    },
                    success: function (data) {
                        sum = data;
                    },
                    error: function () {
                        sum = "";
                    }
                });
                return sum;
            }
            //一级会员提成  加  二级会员提成
            function onePlustwoAmountFormat(val) {

                var U_ID = val;
                var sum = "";

                $.ajax({
                    type: "post",
                    url: "/Ajax/Queryorder/QueryorderAmount.ashx?action=twoPlustwoAmount",
                    async: false,
                    data: {
                        "U_ID": U_ID,
                        "START_DATE": $('#txtSTART_DATE').val(),
                        "END_DATE": $('#txtEND_DATE').val()
                    },
                    success: function (data) {
                        sum = data;
                    },
                    error: function () {
                        sum = "";
                    }
                });
                return sum;
            }

            //得到查询的参数
            oTableInit.queryParams = function (params) {
                var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
                    limit: params.limit,   //页面大小
                    offset: params.offset,  //页码
                    sort: params.sort,
                    order: params.order,
                    name: $("#txt_Name").val(),
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



    </script>
</head>
<body>

    <uc2:Head ID="Head1" runat="server" />
    <uc1:left ID="left1" runat="server" />
    <div id="content">

        <div class="panel panel-default">
            <div class="panel-heading">查询条件</div>
            <div class="panel-body">
                <form id="formSearch" class="form-horizontal">
                    <div class="form-group" style="margin-top: 15px">
                        <label class="control-label col-sm-1" for="txtSTART_DATE">开始日期</label>
                        <div class="col-sm-1">
                            <input class="form-control Wdate " type="text" onclick="WdatePicker()" name="txtSTART_DATE" id="txtSTART_DATE"
                                runat="server" />
                        </div>
                        <label class="control-label col-sm-1" for="txtEND_DATE">结束日期</label>
                        <div class="col-sm-1">
                            <input class="form-control Wdate" type="text" onclick="WdatePicker()" name="txtEND_DATE" id="txtEND_DATE"
                                runat="server" />
                        </div>

                        <label class="control-label col-sm-1" for="txt_Name">会员：</label>
                        <div class="col-sm-1">
                            <input type="text" class="form-control" id="txt_Name" runat="server">
                            <%--<asp:HiddenField ID="hid_ID" runat="server" />--%>
                        </div>

                        <div class="col-sm-2" style="text-align: left;">
                            <button type="button" style="margin-left: 50px" id="btn_query" class="btn btn-primary">查询</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="widget-box">
            <div class="widget-content nopadding table-responsive">
                <table id="listdg" class="table table-bordered table-striped"></table>
                <div style="text-align: center">
                    <!-- 按钮触发模态框 -->
                    <%--<asp:Button ID="btn_Excel" runat="server" Text="EXCEL导出账单" class="btn btn-info btn-xs" />--%>
                    <%--<button class="btn btn-info btn-xs"  type="button"  id="btn_Excel">
                        EXCEL导出账单
                    </button>--%>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
