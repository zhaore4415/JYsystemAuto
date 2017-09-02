/********************************************
* 模块名称：Message
* 功能说明：消息对话框  ，提示信息，警告信息，错误信息等
* 创 建 人：滕零波
* 创建时间：2014-10-23
* 修 改 人：
* 修改时间：
* ******************************************/

//msg_number  消息编码
var path = "../../";
function msg_alert(msg_number)
{
    //title, msg, icon, fn
    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    $.ajax({
        type: "post",
        url: path+"Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = item.MESSAGE_TEXT;
                title = item.MESSAGE_TYPE_NAME+ "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT")
                {
                    icon = "warning";
                    
                }
                else if (msg_type == "NOTE")
                {
                    icon = "info";
                   
                }
                else if (msg_type == "ERROR")
                {
                    icon = "error";
                   
                }

                $.messager.defaults = { ok: 'OK', cancel: 'Cancel' };
                $.messager.alert(title, msg, icon);
                $("#open_load").window("close");
            });
        }
    });
}

//fn 点确定时要执行操作，函数名称
function msg_alert(msg_number,fn) {
    //title, msg, icon, fn
    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    $.ajax({
        type: "post",
        url: path+"Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = item.MESSAGE_TEXT;
                title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT") {
                    icon = "warning";

                }
                else if (msg_type == "NOTE") {
                    icon = "info";

                }
                else if (msg_type == "ERROR") {
                    icon = "error";

                }
                $.messager.defaults = { ok: 'OK', cancel: 'Cancel' };
                $.messager.alert(title, msg, icon, function () {
                    if (fn != undefined && fn != "") {
                        fn();
                    }
                });

                $("#open_load").window("close");
            });
        }
    });
}

//fn 点确定时要执行操作，函数名称,有占位付数字
function msg_alert_2(msg_number, fn,str1,str2) {
    //title, msg, icon, fn

    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    $.ajax({
        type: "post",
        url: path + "Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = (item.MESSAGE_TEXT);
                title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT") {
                    icon = "warning";

                }
                else if (msg_type == "NOTE") {
                    icon = "info";

                }
                else if (msg_type == "ERROR") {
                    icon = "error";

                }
                $.messager.defaults = { ok: 'OK', cancel: 'Cancel' };
                $.messager.alert(title, msg.format(str1, str2), icon, function () {
                    if (fn != undefined && fn != "") {
                        fn();
                    }
                });
                $("#open_load").window("close");
            });
        }
    });
}
//fn 点确定时要执行操作，函数名称,有占位付数字
function msg_alert_3(msg_number, fn, str1, str2,str3) {
    //title, msg, icon, fn
    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    $.ajax({
        type: "post",
        url: path + "Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = (item.MESSAGE_TEXT);
                title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT") {
                    icon = "warning";

                }
                else if (msg_type == "NOTE") {
                    icon = "info";

                }
                else if (msg_type == "ERROR") {
                    icon = "error";

                }
                $.messager.defaults = { ok: 'OK', cancel: 'Cancel' };
                $.messager.alert(title, msg.format(str1, str2,str3), icon, function () {
                    if (fn != undefined && fn != "") {
                        fn();
                    }
                });
                $("#open_load").window("close");
            });
        }
    });
}


//fn 点确定时要执行操作，函数名称,有占位付数字
function msg_alert_list(msg_number, fn, list) {
    //title, msg, icon, fn
    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    $.ajax({
        type: "post",
        url: path + "Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = (item.MESSAGE_TEXT);
                title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT") {
                    icon = "warning";

                }
                else if (msg_type == "NOTE") {
                    icon = "info";

                }
                else if (msg_type == "ERROR") {
                    icon = "error";

                }
                $.messager.defaults = { ok: 'OK', cancel: 'Cancel' };

                var msg_text = "";
                if (list.length == 1) {
                    msg_text = msg.format(list[0]);
                }
                else if (list.length == 2) {
                    msg_text = msg.format(list[0], list[1]);
                }
                else if (list.length == 3) {
                    msg_text = msg.format(list[0], list[1], list[2]);
                }
                else if (list.length == 4) {
                    msg_text = msg.format(list[0], list[1], list[2], list[3]);
                }
                else if (list.length == 5) {
                    msg_text = msg.format(list[0], list[1], list[2], list[3], list[4]);
                }

                $.messager.alert(title, msg_text, icon, function () {
                    if (fn != undefined && fn != "") {
                        fn();
                    }
                });
                $("#open_load").window("close");
            });
        }
    });
}

String.prototype.format = function () {
    if (arguments.length == 0) return this;
    for (var s = this, i = 0; i < arguments.length; i++)
        s = s.replace(new RegExp("\\{" + i + "\\}", "g"), arguments[i]);
    return s;
};
//msg_number,  消息编码 确认提示
//fn 点确定以后执行操作
function msg_confirm(msg_number,fn,n_fn) {
    //title, msg, icon, fn
    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    $.ajax({
        type: "post",
        url: path + "Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = item.MESSAGE_TEXT;
                title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT") {
                    icon = "warning";

                }
                else if (msg_type == "NOTE") {
                    icon = "info";

                }
                else if (msg_type == "ERROR") {
                    icon = "error";

                }
                $.messager.defaults = { ok: 'OK', cancel: 'Cancel' };
                $.messager.confirm(title, msg, function (r) {
                    if (r) {
                        fn();

                    }
                    else {
                        if (n_fn != undefined && n_fn!="") {
                            n_fn();
                        }
                        
                       
                    }
                   
                });

                $("#open_load").window("close");
            });
        }
    });

}


//fn 点确定以后执行操作 占位符
function msg_confirm(msg_number, fn, n_fn, str1, str2) {
    //title, msg, icon, fn
    $("#open_load").window("open");
    var msg_type = "";
    var title = "";
    var msg = "";
    var _ok = "是";
    var _cancel = "否";
    $.ajax({
    type: "post",
        url: path + "Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
            data: { "msg_number": msg_number },
                success: function (data) {
                    $.each(data, function (idx, item) {
                        msg_type = item.MESSAGE_TYPE;
                        msg = item.MESSAGE_TEXT;
                        title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                        //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                        if (msg_type == "HINT") {
                            icon = "warning";

                        }
                        else if (msg_type == "NOTE") {
                            icon = "info";

                        }
                        else if (msg_type == "ERROR") {
                            icon = "error";

                        }
                        $.messager.defaults = { ok: _ok, cancel: _cancel };
                        $.messager.confirm(title, msg.format(str1, str2), function (r) {
                            if (r) {
                                fn();

                            }
                            else {
                            if (n_fn != undefined && n_fn!="") {
                                n_fn();
                            }
                        
                       
                            }
                   
                            });
                    });
                    $("#open_load").window("close");
                }
                });

                }
//$.messager.confirm

//自定义按钮名字
function msg_confirm_2(msg_number, fn, n_fn,ok_txt,ca_txt,str1) {
    //title, msg, icon, fn
    var msg_type = "";
    var title = "";
    var msg = "";
    var _ok = "重试";
    var _cancel = "忽略";
    if (ok_txt != undefined && ok_txt != "") {
        _ok = ok_txt;
        _cancel = ca_txt;
    }
    $.ajax({
        type: "post",
        url: path + "Ajax/messages/Get_Messages_json.ashx?action=search",
        dataType: "json",
        data: { "msg_number": msg_number },
        success: function (data) {
            $.each(data, function (idx, item) {
                msg_type = item.MESSAGE_TYPE;
                msg = item.MESSAGE_TEXT;
                title = item.MESSAGE_TYPE_NAME + "-" + item.MESSAGE_NUMBER;
                //错误（ERROR）；（2）提示或警示（HINT）；（3）附注（NOTE）；（消息分类无需在代码中体现）
                if (msg_type == "HINT") {
                    icon = "warning";

                }
                else if (msg_type == "NOTE") {
                    icon = "info";

                }
                else if (msg_type == "ERROR") {
                    icon = "error";

                }
                $.messager.defaults = { ok: _ok, cancel: _cancel };
                $.messager.confirm(title, msg.format(str1), function (r) {
                    if (r) {
                        fn();

                    }
                    else {
                        if (n_fn != undefined && n_fn != "") {
                            n_fn();
                        }


                    }

                });
            });
        }
    });

}

//
//fn 点确定以后执行操作 占位符,数组
function msg_confirm_list(msg_number, fn, n_fn, list) {
    //title, msg, icon, fn
    debugger;
    var title = "";
    var msg = "";
    var _ok = "是";
    var _cancel = "否";

    if (msg_number == "3420") {
        msg = "订单Excel数据格式有误，请下载最新模板进行上传！";
        title = "提示" + "-" + "3420";
    }
    else if (msg_number == "3421") {
        msg = "上传文件中不存在任何数据行！";
        title = "提示" + "-" + "3421";
    }
    else if (msg_number == "3423") {
        msg = "导入结果：共处理{0}条数据，导入成功{1}条，导入失败{2}个！是否查看详细日志？！";
        title = "提示" + "-" + "3423";
    }
    else if (msg_number == "3531") {
        msg = "导入失败，是否查看错误日志？！";
        title = "提示" + "-" + "3531";
    }
    else if (msg_number == "3036") {
        msg = "操作失败！";
        title = "提示" + "-" + "3036";
    }
    else if (msg_number == "3401") {
        msg = "登录态失效，请重新登陆！";
        title = "提示" + "-" + "3401";
    }
    else if (msg_number == "3402") {
        msg = "参数错误！";
        title = "提示" + "-" + "3402";
    }
   
    //$.messager.defaults = { ok: _ok, cancel: _cancel };
    var msg_text = "";
    if (list.length == 1) {
        msg_text = msg.format(list[0]);
    }
    else if (list.length == 2) {
        msg_text = msg.format(list[0], list[1]);
    }
    else if (list.length == 3) {
        msg_text = msg.format(list[0], list[1], list[2]);
    }
    else if (list.length == 4) {
        msg_text = msg.format(list[0], list[1], list[2], list[3]);
    }
    else if (list.length == 5) {
        msg_text = msg.format(list[0], list[1], list[2], list[3], list[4]);
    }
    Ewin.confirm({ btnok: _ok, btncl: _cancel, title: title, message: msg_text }).on(function (e) {
        if (!e) {
            if (n_fn != undefined && n_fn != "") {
                n_fn();
            }
            return;
        }
        else {
            fn();
        }

    });
    //$.messager.confirm(title, msg_text, function (r) {
    //    if (r) {
    //        fn();

    //    }
    //    else {
    //        if (n_fn != undefined && n_fn != "") {
    //            n_fn();
    //        }


    //    }

    //});

}
