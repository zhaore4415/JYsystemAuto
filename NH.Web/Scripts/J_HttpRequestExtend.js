/********************************************
* 模块名称：J_HttpRequestExtend
* 功能说明：HTTP请求扩展
* 创 建 人：黎天山
* 创建时间：2017-4-26
* 修 改 人：
* 修改时间：
* ******************************************/
(function ($) {
    function onResultCallback(res,obj)
    { 
        // Success, Error, Warn, LoginLose
        if (res.Status == "Success") {
            isEdit = false;  //置为未编辑

            if (obj.onSuccessCallback != undefined && typeof obj.onSuccessCallback == 'function') {
                obj.onSuccessCallback(res);
            }
            else {
                if (res.ResultNumber)
                    msg_alert(res.ResultNumber, function () {
                        //主要用于检测编辑保存框架的保存成功回调 
                        if (onSuccessSaveEditCallback != undefined && typeof onSuccessSaveEditCallback == 'function') {
                            onSuccessSaveEditCallback();
                        }

                        //外部定义 选择弹窗确定按钮后的回调
                        if (obj.onSuccessOkCallback != undefined && typeof obj.onSuccessOkCallback == 'function') {
                            obj.onSuccessOkCallback(res);
                        } 
                    });
            }
        }
        else if (res.Status == "Error") {
            if (obj.onErrorCallback != undefined && typeof obj.onErrorCallback == 'function') {
                obj.onErrorCallback(res);
            }
            else {
                if (res.ResultNumber)
                    msg_alert(res.ResultNumber);
            }
        }
        else if (res.Status == "LoginLose") {
            //登录态失效，请重新登陆！
            msg_alert(res.ResultNumber, function () {
                //退出登录
                top.location.href = '/Admin/Relogin.aspx';
            });
        }
        else {
            if (obj.onOtherCallback != undefined && typeof obj.onOtherCallback == 'function') {
                obj.onOtherCallback(res);
            }
            else {
                if (res.ResultNumber)
                    msg_alert(res.ResultNumber);
            }
        }
    }


    /** 
        obj为一个json对象：
                url：必须   post地址
                data：必须  发送数据 
                onSuccessCallback：处理成功回调
                onSuccessOkCallback：弹出成功消息后点击确定后回调方法
                onErrorCallback：处理失败回调
                onOtherCallback：其它结果回调
    **/
    $.fn.HttpPostSend = function (obj) {
        try { 
          
            $.ajax({
                type: "post",
                url: obj.url,
                dataType: "json",
                data: obj.data,
                success: function (res) {
                    onResultCallback(res, obj);
                    $("#open_load").window("close");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    msg_alert("数据校验错误");
                    //$("#open_load").window("close");
                }
            });

        }
        catch (e) {
            alert("数据校验错误！");
            //$("#open_load").window("close");
        }
    }

    /**
        obj为一个json对象：
                url：必须   post地址
                data：必须  发送数据
                datagridId:  需要自动刷新的控件id
                onSuccessCallback：处理成功回调
                onErrorCallback：处理失败回调
                onOtherCallback：其它结果回调
    **/
    $.fn.HttpPostRemove = function (obj) {
        try {  
            msg_confirm(3032, function ()
            {
                $("#open_load").window("open");
                $.ajax({
                    type: "post",
                    url: obj.url, 
                    dataType: "json",
                    data: obj.data,
                    success: function (res) {
                        if (res.Status == "Success") {
                            if (obj.datagridId != undefined) {
                                $(obj.datagridId).datagrid("reload");
                            }
                        }
                        

                        onResultCallback(res, obj);
                        $("#open_load").window("close");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $("#open_load").window("close");
                        msg_alert(3031);
                    }
                });  
            }, function ()
            {
                $("#open_load").window("close");
            });
        }
        catch (e) {
            msg_alert(3031);
            $("#open_load").window("close");
        }
    }


    /**
        controls：三个数组  0-普通文本框   1-普通combobox  2-普通combogrid
        numbers 三个数组  消息与controls顺序对应 

        返回：true   验证通过
    **/
    $.fn.SendValidate = function(controls,numbers)
    { 
        //isValid-校验是否通过
        var isValid = true;
        for(var i=0;i<controls.length;i++)
        {
            if (isValid) {
                for (var j = 0; j < controls[i].length; j++) {
                    var validVal = "";
                    var control = $(controls[i][j]);
                    if (i == 0)
                        validVal = control.val();
                    else if (i == 1)
                        validVal = control.combobox("getValue");
                    else if (i == 2) {
                        if (control.combogrid("grid").datagrid("getSelected")) {
                            validVal = "Y";
                        }
                    }

                    if (validVal == "") {
                        msg_alert(numbers[i][j]);
                        isValid = false;
                        break;
                    }
                }
            }
            else
                break;
        } 
        return isValid;
    }
})(jQuery)
