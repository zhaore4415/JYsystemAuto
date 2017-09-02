$.extend($.fn, {
    jList: function (setting) {
        $.fn.jList.defaults = $.extend({}, $.fn.datagrid.defaults, { _renderTo: null, _btnSearch: '#btnSearch', _action: null, _customColumns: [], _show_custombtn: true, _operate: '', toolbar: '#toolbar', url: null, pagination: true, singleSelect: true, _getSearchKeys: function () { return func.getSearchKeys() }, loadFilter: function (data) { return func.loadFilter(data); }, onLoadError: function () { func.onLoadError(); } })
        var opts = $.extend({}, $.fn.jList.defaults, setting)
        var objToolbar = $(opts.toolbar);
        try {
            if (opts._customColumns.length == 0) {
                opts._customColumns = _custom_config_columns;
            }
        } catch (err) { }
        var customColCount = opts._customColumns.length;
        var btnSetColumn = $('#btnSetColumn');
        if (opts._show_custombtn) {
            if (!btnSetColumn[0]) {
                objToolbar.prepend('<span style="float: right;"><a id="btnSetColumn" class="easyui-linkbutton" iconcls="icon-gears" plain="true">设置</a></span>');
                $.parser.parse(objToolbar);
            }
        }
        var func = {
            getSearchKeys: function () {
                //获取查询参数及要查询的字段名
                var keys = {};
                var strKeys = ''; //搜索条件
                var strColumns = ''; //要查询的列名
                objToolbar.find('[compare]').each(function (i, n) {
                    var obj = $(this);
                    if (obj.hasClass('combo-value')) {
                        strKeys += obj.attr('name') + '#' + obj.val() + '#' + obj.parent().prev().attr('compare') + '|';
                    } else if (obj.attr('comboname') != undefined) {
                        strKeys += obj.attr('comboname') + '#' + obj.next().find('.combo-value').val() + '#' + obj.attr('compare') + '|';
                    } else {
                        strKeys += obj.attr('name') + '#' + obj.val() + '#' + obj.attr('compare') + '|';
                    }
                });
                if (strKeys != '') { strKeys = strKeys.substring(0, strKeys.length - 1) }
                keys["keys"] = strKeys;

                var columns = opts.columns;
                for (var i = 0; i < columns.length; i++) {
                    for (var j = 0; j < columns[i].length; j++) {
                        //opts.columns[i][j]._column==''表示不需要读取的列
                        if (columns[i][j]._column != '') {
                            //if (customColCount == 0 || $.inArray(columns[i][j].field, opts._customColumns) > -1) {
                            if (customColCount == 0 || $.inArray(columns[i][j].title, opts._customColumns) > -1) {
                                strColumns += (columns[i][j]._column ? columns[i][j]._column : columns[i][j].field) + ',';
                            }
                        }
                    }
                }
                if (strColumns != '') { strColumns = strColumns.substring(0, strColumns.length - 1) }
                keys["columns"] = strColumns;
                return keys;
            },
            getDisplayCols: function () {
                //筛选要显示的列
                var objTbColumns = [];
                var columns = opts.columns;
                for (var i = 0; i < columns.length; i++) {
                    var colArray = [];
                    for (var j = 0; j < columns[i].length; j++) {
                        //if (customColCount == 0 || $.inArray(columns[i][j].field, opts._customColumns) > -1) {
                        //if (customColCount == 0 || $.inArray(columns[i][j].title, opts._customColumns) > -1) {
                        if (customColCount == 0 || columns[i][j].title == '操作' || $.inArray(columns[i][j].title, opts._customColumns) > -1) {
                            colArray.push(columns[i][j])
                        }
                    }
                    objTbColumns.push(colArray);
                }
                return objTbColumns;
            },
            loadFilter: function (data) {
                switch (data.status) {
                    case 'nologin':
                        //showLoginWin();
                        return eval('({"total":"0",rows:[]})');
                        break;
                    case 'nopower':
                        return eval('({"total":"0",rows:[]})');
                        break;
                    default:
                        return data;
                        break;
                }
            },
            onLoadError: function () {
                $.messager.alert('出错', '加载失败！', 'error');
            },
            GetButtons: function (value, data) {
                if (opts._operate == '') { return ''; }
                var o = opts._operate.split(',');
                var html = '';
                for (var i = 0; i < o.length; i++) {
                    var text = o[i].split('[')[1].split(']')[0];
                    /*var img = '';
                    if (o[i].toLowerCase().indexOf('edit') >= 0) {
                        img = 'icon_edit.gif';
                    } else if (o[i].toLowerCase().indexOf('show') >= 0) {
                        img = 'icon_show.gif';
                    } else if (o[i].toLowerCase().indexOf('delete') >= 0) {
                        img = 'icon_delete.gif';
                    }*/
                    html += '<a href="#" onclick="javascript:' + o[i].split('[')[0] + '(' + data.id + ');return false;" title="' + text + '" class="operate">' + text + '</a>';
                }
                return html;
            },
            setCustomColumns: function (obj, columns) {
                opts.columns = obj.data('allCols');
                opts._customColumns = columns;
                $.fn.jList(opts);
            }
        }

        var objTbList = null
        if (opts._renderTo == null) {
            objTbList = $('<table id="tbdata"></table>')
            $('#subTab').find('div:eq(0)').append(objTbList)
        } else if (typeof opts._renderTo == 'string') {
            objTbList = $(opts._renderTo);
        } else {
            objTbList = opts._renderTo;
        }
        //记录所有可供选择的列
        objTbList.data('allCols', objTbList.data('allCols') || opts.columns);

        //获取数据的url地址
        if (opts._action != null) {
            opts.url = '/adm/ajax/List.ashx?action=' + opts._action;
        } else {
            opts.url = opts.url;
        }
        opts._renderTo = objTbList;
        opts.queryParams = opts._getSearchKeys();
        opts.columns = func.getDisplayCols();
        var lastColumn = opts.columns[opts.columns.length - 1][opts.columns[opts.columns.length - 1].length - 1];
        if (lastColumn.field == '操作' && lastColumn.formatter == undefined) {
            opts.columns[opts.columns.length - 1][opts.columns[opts.columns.length - 1].length - 1].formatter = func.GetButtons;
        }
        //调用easyui的绑定方法
        objTbList.datagrid(opts);
        //窗口大小改变时的事件
        $(window).resize(function () {
            objTbList.datagrid('resize');
        });
        //搜索按钮事件
        $(opts._btnSearch).click(function () {
            objTbList.datagrid('options').queryParams = opts._getSearchKeys();
            objTbList.datagrid('load');
        });
        return objTbList;
    }
});
//重新加载
function LoadDataGrid() {$('#btnSearch').click();}
//获取总记录数
function GetTotal() {
    var pager = $('#tbdata').datagrid('getPager');
    return pager.pagination('options').total;
}
function Delete2(action, id) {
    $.ajax({
        url: '/ajax/Delete.ashx?action=' + action,
        data: 'id=' + id,
        type: 'post',
        dataType: 'json',
        success: function (data) {
            if (data.status == "true") {
                alert('删除成功');LoadDataGrid();
            } else {
                alert(data.msg);
            }
        }, error: function () { alert('error') }
    })
}
function CloseSubTab(title) {$('#subTab').tabs('close', title)}
function addSubTab(title, url, isiframe) {
    var obj = $('#subTab');
    if (!obj.data('binded')) {
        obj.tabs({ fit: true, border: false, plain: true, height: 'auto' }).css('height', 'auto').data('binded', true);
    }
    if (obj.tabs('exists', title)) {
        obj.tabs('select', title); return;
    }
    if (isiframe == true) {
        var content = '<iframe frameborder="0" src="' + url + (url.indexOf('?') > -1 ? '&' : '?') + '_title=' + escape(title) + '" style="width:100%;height:570px;"></iframe>';
        obj.tabs('add', { title: title, content: content, closable: true });
    } else {
        obj.tabs('add', { title: title, url: url, closable: true });
    }
}
var dlgAdd;
function Add() {
    dlgAdd = $('#dlgAdd');
    dlgAdd.dialog('open');
}
