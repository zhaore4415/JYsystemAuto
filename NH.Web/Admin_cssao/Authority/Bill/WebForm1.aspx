<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NH.Web.Authority.Bill.WebForm1" %>
<!DOCTYPE html>
<html>
<head>
    <title>Export测试</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="bootstrap/css/bootstrap.css">
    <link rel="stylesheet" href="bootstrap-table-export/css/bootstrap-table.css">
    <script src="js/jQuery-1.10.2.js"></script>
    <script src="bootstrap/js/bootstrap.js"></script>
    <script src="bootstrap-table-export/js/bootstrap-table.js"></script>
    <script src="bootstrap-table-export/js/bootstrap-table-export.js"></script>
    <script src="bootstrap-table-export/js/tableExport.js"></script>
  
</head>
<body>
    <div class="Container">
        <h1>Export</h1>
        <div id="toolbar">
            <select class="form-control">
                <option value="">Export Basic</option>
                <option value="all">Export All</option>
                <option value="selected">Export Selected</option>
            </select>
        </div>
        <!-- 
        
         data-toggle="table"
               data-show-export="true"
               data-pagination="true"
               data-click-to-select="true"
               data-toolbar="#toolbar"
               data-search="true"
               data-showRefresh="true"
               data-strictSearch="true"
               data-url="json/data1.json"
         -->
        <table id="table">
            <thead>
            <tr>
                <th  data-checkbox="true"></th>
                <th>序号</th>
                <th>名字</th>
                <th>金额</th>
            </tr>
            </thead>
        </table>
    </div>
<script>
    var $table = $('#table');
 
    
    $(function () {
    showTable("1","2017");//初始化
    
        $('#toolbar').find('select').change(function () {
            $table.bootstrapTable('refreshOptions', {
                exportDataType: $(this).val()
            });
        });
    })
    
     //初始化Table
    function showTable(dept_id,endTime){
      
    $table.bootstrapTable({
            url: 'json/data1.json',             //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            dataType: "json",
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: true,                        //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                    //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: {"dept_id":dept_id,"endTime":endTime},//传递参数（*）
            sidePagination: "client",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                      //初始化加载第一页，默认第一页
            pageSize: 8,                        //每页的记录行数（*）
            pageList: [8, 15, 30, 60],          //可供选择的每页的行数（*）
            search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showExport:true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
             
            columns: [{
                checkbox: true
            }, {
                field: 'id',
                title: '编号'
            }, {
                field: 'name',
                title: '名称'
            }, {
                field: 'price',
                title: '金额'
            }, {
                title: '操作',
                field: 'id',
                align: 'center',
                formatter:function(value,row,index){  
                     var e = '<a href="#" mce_href="#" onclick="edit(\''+ row.id + '\')">编辑</a> ';  
                     var d = '<a href="#" mce_href="#" onclick="del(\''+ row.id +'\')">删除</a> ';  
                     var g = '<a href="main.html" mce_href="#" target="_blank" onclick="detail(\''+ row.id +'\')">进入详情 </a> ';  
                     return g;  
                   } 
            } 
            ]
        });
     
    }
</script>


<script type="text/JavaScript">
     function detail(id){
    alert(id);
     }


</script>
</body>
</html>