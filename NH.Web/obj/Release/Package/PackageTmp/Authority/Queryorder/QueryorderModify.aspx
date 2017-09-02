<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryorderModify.aspx.cs" Inherits="NH.Web.Authority.Queryorder.QueryorderModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<link href="/css/css.css" rel="stylesheet" />--%>
    <style>
        .Wdate {
            height: 32px;
        }
    </style>
    <%--<script src="/My97DatePickerBeta/My97DatePicker/WdatePicker.js"></script>--%>
    <script type="text/javascript">

        $(function () {
           
        })
        function onCheckData() {

            var LoginName = $("#txtLoginName").val();
            var OrderNumber = $("#txtOrderNumber").val();

            var Products = $("#txtProducts").val();
            var Babynumbers = $("#txtBabynumbers").val();
            var Amounts = $("#txtAmounts").val();


            if (LoginName == "") {
                alert("请输入会员名");
                return false;
            }
            if (OrderNumber == "") {
                alert("请输入订单号");
                return false;
            }

            if (Products == "") {
                alert("请输入商品名称，用“,” 逗号隔开，如“手机,电脑,充电器”");
                return false;
            }
            if (Babynumbers == "") {
                alert("请输入单个商品数量用“,” 逗号隔开，如“1,2,5”");
                return false;
            }
            if (Amounts == "") {
                alert("请输入每个商品金额，用“,” 逗号隔开，如“10.20,100,51.50”");
                return false;
            }

            $.ajax({
                type: "post",
                url: "../../Ajax/Queryorder/QueryorderAdd.ashx?action=search",
                dataType: "json",
                data: { "LoginName": LoginName },
                success: function (msg) {
                    if (msg == "0") {
                        alert("不存在该会员，请先添推荐库管理里增加会员！");

                        return;
                    }

                    else if (msg == "1") {

                        onSave();
                    }

                }

            });
        }
        function onSave() {
            var Id = $("#hid_ID").val();
            var LoginName = $("#txtLoginName").val();
            var OrderNumber = $("#txtOrderNumber").val();

            var Products = $("#txtProducts").val();
            var Babynumbers = $("#txtBabynumbers").val();
            var Amounts = $("#txtAmounts").val();

            var item = {
                Id: Id,
                LoginName: LoginName,
                OrderNumber: OrderNumber,
                Products: Products,
                Babynumbers: Babynumbers,
                Amounts: Amounts,
                DeliveryTime: $("#txtDeliveryTime").val()

            };
            $.ajax({
                type: "post",
                url: "../../Ajax/Queryorder/QueryorderAdd.ashx?action=update",
                dataType: "json",
                data: { "myjson": JSON.stringify(item) },
                success: function (msg) {
                    if (msg == "0") {
                        alert("提交失败");

                        return;
                    }

                    else if (msg == "1") {

                        if (msg != "-1") {
                            alert("提交成功");
                            $("#listdg").bootstrapTable('refresh');
                            $('#modal2').modal('hide');
                            //window.location.href = "Queryorder.aspx";
                        }
                    }

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {


                }
            });
        }

    </script>
</head>
<body>

    <div class="panel panel-default">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal2" aria-label="Close"><span aria-hidden="true">×</span></button>
            <h4 class="modal-title" id="exampleModalLabel">修改订单</h4>
        </div>

        <div class="modal-body">

            <div class="form-horizontal" role="form">
             
                <div class="form-group">
                  <input type="hidden" id="hid_ID" runat="server" clientidmode="Static" />
                    <label for="txtLoginName" class="col-sm-2 control-label"><span class="myform-star">*</span>会员</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="txtLoginName" placeholder="请输入会员名" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtOrderNumber" class="col-sm-2 control-label"><span class="myform-star">*</span>订单号</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="txtOrderNumber" placeholder="请输入订单号" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtProducts" class="col-sm-2 control-label"><span class="myform-star">*</span>商品内容</label>
                    <div class="col-sm-10">

                        <input type="text" class="form-control" id="txtProducts" placeholder="请输入商品名称，用“,” 逗号隔开，如“手机,电脑,充电器”" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtBabynumbers" class="col-sm-2 control-label"><span class="myform-star">*</span>商品数量</label>
                    <div class="col-sm-10">

                        <input type="text" class="form-control" id="txtBabynumbers" placeholder="请输入单个商品数量用“,” 逗号隔开，如“1,2,5”" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAmounts" class="col-sm-2 control-label"><span class="myform-star">*</span>商品金额</label>
                    <div class="col-sm-10">

                        <input type="text" class="form-control" id="txtAmounts" placeholder="请输入每个商品金额，用“,” 逗号隔开，如“10.20,100,51.50”" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtDeliveryTime" class="control-label col-sm-2">付款时间</label>
                    <div class="col-sm-8">
                        <input class="form-control Wdate" type="text" onclick="WdatePicker()" name="txtDeliveryTime" id="txtDeliveryTime"
                            runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <a id="ibtnSave" class="btn btn-default" clientidmode="Static" href="javascript:void(0)" onclick="onCheckData()">提交</a>
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            关闭
                        </button>
                        <%--<button type="submit" class="btn btn-default" onclick="onCheckData()">提交</button>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
