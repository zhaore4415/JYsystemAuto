(function ($) {
    $.fn.jAreaSelect = function (o) {
        var defaults = {
            emptyValue: '',
            emptyText: '请选择...',
            nolimitValue: '',
            nolimitText: '不限',
            defaultText: '请选择地区',
            shownolimit: false,
            select: 1,
            className: 'color_select',
            is_province: false, //是否可以选择省，
            onClose: function () { },
            onDelete: function () { }
        };
        o = $.extend({}, defaults, o);
        if (this)
            $(this).data('o', o);
        var formOpertater = {
            o: o,
            createDom: function (elem, mul_sig) {
                var elem_width, elem_height;
                elem_width = elem.outerWidth();
                elem_height = elem.outerHeight();
                elem.css({ 'opacity': '0' }).hide();
                elem.Obj.new_select = $('<div class="winselect ' + elem.attr('id') + '"><div class="clip"><ul class="select_result"></ul></div></div>').click(function () {
                    if (!elem.Obj.dialog1) {
                        formOpertater.createDialog1(elem);
                    } else {
                        elem.Obj.dialog1.dialog('open');
                    }
                });
                //创建默认选择的项
                var sel_result = elem.Obj.new_select.find('ul.select_result');
                elem.find('option[value!=""][selected]').each(function (index) {
                    var option = $(this);
                    var li_item = $('<li></li>').text(option.text()).click(function () { return false; });
                    $('<span></span>').click(function () {
                        li_item.remove(); if (sel_result.find('li').length == 0) { sel_result.append('<li>' + o.defaultText + '</li>') }
                        option.attr('selected', false);
                        if (o.onDelete) o.onDelete();
                        return false;
                    }).appendTo(li_item);
                    sel_result.append(li_item);
                });
                if (sel_result.find('li').length == 0) { sel_result.append('<li>' + o.defaultText + '</li>'); }
                elem.Obj.new_select.insertAfter(elem);

                elem.Obj.new_select.css({ 'width': elem.outerWidth() + 'px', 'margin-right': elem.css('margin-right'), 'margin-top': elem.css('margin-top'), 'margin-bottom': elem.css('margin-bottom'), 'margin-left': elem.css('margin-left') })
                elem.Obj.new_select.find('.clip').css({ 'width': elem.outerWidth() })
            }, createDialog1: function (elem) {
                elem.Obj.dialog1 = $('<div id="dlg-' + elem.attr('id') + '"></div>');

                elem.Obj.dialog1.append('<p class="subtitle clear">直辖市</p><ul class="zxs areaitems"></ul><div class="clear"></div>');
                elem.Obj.dialog1.append('<p class="subtitle clear">全部省份</p><ul class="wholeprovince areaitems"></ul><div class="clear"></div>');
                var objProv = elem.Obj.dialog1.find('ul.wholeprovince');
                var objZxs = elem.Obj.dialog1.find('ul.zxs');
                var child = elem.children();
                child.each(function (index, dom) {
                    var objA;
                    if ($(dom).is('option')) {
                        if ($(dom).attr('value') != "" && $(dom).text() != o.emptyText) {
                            objA = $('<a href="#" value="' + $(dom).attr('value') + '">' + $(dom).text() + '</a>');
                        } else { return; }
                    } else if ($(dom).is('optgroup')) {
                        objA = $('<a href="#" value="' + $(dom).children(':first').attr('value') + '">' + $(dom).children(':first').text() + '</a>');
                    }
                    objA.click(function () {
                        if ($(this).hasClass('disabled')) {
                            return false;
                        } else {
                            formOpertater.createDialog2(elem, $(this).attr('value'), $(this).text());
                        }
                    });

                    if ($.inArray($(dom).children(':first').attr('value'), jZxs) > -1) {//直辖市
                        $('<li></li>').append(objA).appendTo(objZxs);
                    } else {
                        $('<li></li>').append(objA).appendTo(objProv);
                    }
                });

                //if (elem.Obj.is_mult) {
                if (o.shownolimit) {
                    var nolimitLi = $('<li><input type="checkbox" id="' + elem.attr('id') + '-nolimit" class="nolimit" /><label for="' + elem.attr('id') + '-nolimit">不限地区</label></li>');
                    nolimitLi.find('input').click(function () {
                        if ($(this).is(":checked")) {
                            formOpertater.addSingle(elem, o.nolimitValue, null, o.nolimitText);
                        } else {
                            formOpertater.resetCls(elem);
                        }
                    });
                    nolimitLi.appendTo(objZxs);
                }

                //已选择的项
                var selc = $('<div class="selectedcontainer"><p><b>最多可以选择<span style="color:red"> ' + o.select + ' </span>项</b></p><ul></ul></div>');
                elem.Obj.dialog1.append(selc);
                elem.Obj.selected_container = selc;
                elem.Obj.ObjSelectedResult = selc.find('ul');

                $('body').append(elem.Obj.dialog1);
                elem.Obj.dialog1.dialog({
                    title: '选择地区',
                    dialogClass: 'dialog-select',
                    modal: true,
                    autoOpen: true,
                    resizable: false,
                    width: 570,
                    //height: 380,
                    buttons: [{
                        text: '确定',
                        click: function () {
                            var sel_result = elem.Obj.new_select.find('ul.select_result');
                            sel_result.html('');
                            elem.find('option[selected]').attr('selected', false);
                            elem.Obj.ObjSelectedResult.find('li').each(function (index) {
                                var val = $(this).attr('v2'); // ? $(this).attr('v2') : $(this).attr('v1');
                                if (!val) val = $(this).attr('v1');
                                var option = elem.find('option[value="' + val + '"]');
                                if (option[0]) {
                                    option.attr('selected', true);
                                    var li_item = $('<li></li>').text(val == o.nolimitValue ? o.nolimitText : option.text()).click(function () { return false; });
                                    $('<span></span>').click(function () {
                                        li_item.remove(); if (sel_result.find('li').length == 0) { sel_result.append('<li>' + o.defaultText + '</li>')}
                                        option.attr('selected', false);
                                        if (o.onDelete) o.onDelete();
                                        return false;
                                    }).appendTo(li_item);
                                    sel_result.append(li_item);
                                }
                            });
                            $(this).dialog('close');
                        }
                    }],
                    open: function (event, ui) {
                        formOpertater.resetCls(elem);
                        elem.find('option[value!=' + o.emptyValue + '][selected]').each(function (index) {
                            var option = $(this);
                            var v1, v2, t1, t2;
                            if (option.parent().is('optgroup')) {
                                if (option.attr('value') == option.parent().children(":first").attr('value')) {
                                    v1 = option.attr('value'); t1 = option.text();
                                } else {
                                    var parent = option.siblings(':first');
                                    v1 = parent.attr('value'); t1 = parent.text();
                                    v2 = option.attr('value'); t2 = option.text();
                                }
                            } else {
                                v1 = option.attr('value'); t1 = option.text();
                            }
                            var li_result = $('<li v1="' + v1 + '">' + (t1 + (t2 ? " - " + t2 : "")) + '<span></span></li>');
                            if (v2) {
                                li_result.attr('v2', v2);
                            } else {
                            }
                            li_result.find('span').click(function () {
                                formOpertater.removeSingle(elem, v1, v2);
                            });
                            elem.Obj.ObjSelectedResult.append(li_result);
                            formOpertater.setSelectedCls(elem, v1);
                        });
                        if (elem.Obj.new_select.find('ul.select_result').text() == o.nolimitText) {
                            $('#' + elem.attr('id') + '-nolimit').click().attr('checked', true);
                        };
                    },
                    close: function () {
                        if (o.onClose) o.onClose();
                    }
                });
            }, createDialog2: function (elem, value, text) {
                var dlgId = elem.attr('id') + '-sub-' + value;
                var dialog = $('#' + dlgId);
                if (dialog[0]) {
                    elem.Obj.dialog2 = dialog;
                    elem.Obj.dialog2_val = value;
                    dialog.dialog('open');
                    formOpertater.setSelectedCls(elem, null);
                } else {
                    dialog = $('<div id="' + dlgId + '"><div class="dialog-sub-body"><p><input type="' + elem.Obj.input_type + '" id="' + elem.attr('id') + '-chkAllCity-' + value + '" value="' + value + '" /><label for="' + elem.attr('id') + '-chkAllCity-' + value + '"><b>' + text + '</b></label></p><ul class="ulcities"></ul><div class="clear"></div></div></div>');
                    elem.Obj.dialog2 = dialog;
                    elem.Obj.dialog2_val = value;
                    var ul = dialog.find('ul');
                    $('option[value="' + value + '"]', elem).nextAll().each(function (index, obj) {
                        var li = $('<li></li>');
                        li.append('<input type="' + elem.Obj.input_type + '" id="' + elem.attr('id') + '-chk-city-' + $(obj).attr('value') + '" name="' + elem.attr('id') + '-chk-city" value="' + $(obj).attr('value') + '" /><label for="' + elem.attr('id') + '-chk-city-' + $(obj).attr('value') + '">' + $(obj).text() + '</label>');
                        ul.append(li);
                        li.find('input').click(function () {
                            if ($(this).is(":checked")) {
                                formOpertater.addSingle(elem, value, $(obj).attr('value'), text + ' - ' + $(this).next().text());
                            } else {
                                elem.Obj.ObjSelectedResult.find('[v2="' + $(obj).attr('value') + '"]').find('span').click();
                            }
                        });
                    });
                    dialog.find('#' + elem.attr('id') + '-chkAllCity-' + value).click(function () {
                        $objthis = $(this);
                        elem.Obj.ObjSelectedResult.find('li[v1=' + $objthis.val() + ']').remove();
                        if ($objthis.is(':checked')) {
                            if (elem.Obj.is_mult) {
                                ul.find('input').attr({ 'checked': true, 'disabled': true });
                            } else {
                                ul.find('input').attr({ 'checked': true });
                            }
                            formOpertater.addSingle(elem, value, null, text);
                        } else {
                            ul.find('input').attr({ 'checked': false, 'disabled': false });
                            formOpertater.removeSingle(elem, value);
                        }
                    });

                    $('body').append(dialog);
                    dialog.dialog({
                        title: '选择城市',
                        dialogClass: 'dialog-select',
                        modal: true,
                        resizable: false,
                        width: 550,
                        buttons: [{
                            text: '确定',
                            click: function () { $(this).dialog('close') }
                        }], open: function () {
                            //设置样式，选择项
                            elem.Obj.dialog2.find('input').attr({ 'checked': false, 'disabled': false });
                            elem.Obj.ObjSelectedResult.find('li[v1="' + elem.Obj.dialog2_val + '"]').each(function () {
                                if ($(this).attr('v2')) {
                                    elem.Obj.dialog2.find('input[value="' + $(this).attr('v2') + '"]').attr('checked', true);
                                } else {
                                    elem.Obj.dialog2.find('input[value="' + $(this).attr('v1') + '"]').attr('checked', true);
                                    if (elem.Obj.is_mult) {
                                        elem.Obj.dialog2.find('input:not(:checked)').attr({ 'disabled': true, 'checked': true });
                                    } else {
                                        //elem.Obj.dialog2.find('input:not(:checked)').attr({ 'checked': true });
                                    }
                                }
                            });
                            if (elem.Obj.is_mult && elem.Obj.ObjSelectedResult.find('li').length >= o.select) {
                                elem.Obj.dialog2.find('input:not(:checked)').attr('disabled', true);
                            }
                            if (!o.is_province) {
                                dialog.find('#' + elem.attr('id') + '-chkAllCity-' + value).attr('disabled', true);
                            }
                        }
                    });
                };
            }, setSelectedCls: function (elem, v1) {
                if (elem.Obj.is_mult) {
                    if (v1 != o.nolimitValue) {
                        if (elem.Obj.ObjSelectedResult.find('[v1=' + v1 + ']').length > 0) {
                            elem.Obj.dialog1.find('ul.wholeprovince a[value="' + v1 + '"]').addClass('selected');
                            elem.Obj.dialog1.find('ul.zxs a[value="' + v1 + '"]').addClass('selected');
                        } else {
                            elem.Obj.dialog1.find('ul.wholeprovince a[value="' + v1 + '"]').removeClass('selected');
                            elem.Obj.dialog1.find('ul.zxs a[value="' + v1 + '"]').removeClass('selected');
                        }
                    } else {
                        elem.Obj.dialog1.find('ul.wholeprovince a').removeClass('selected');
                        elem.Obj.dialog1.find('ul.zxs a').removeClass('selected');
                    }
                    if (v1 == o.nolimitValue || elem.Obj.ObjSelectedResult.find('li').length >= o.select) {
                        elem.Obj.dialog1.find('ul.wholeprovince a:not(".disabled,.selected")').addClass('disabled');
                        elem.Obj.dialog1.find('ul.zxs a:not(".disabled,.selected")').addClass('disabled');
                        if (elem.Obj.dialog2 && elem.Obj.dialog2.dialog("isOpen")) {
                            elem.Obj.dialog2.find('input:not(:checked)').attr('disabled', true);
                        }
                    } else {
                        elem.Obj.dialog1.find('ul.wholeprovince a.disabled').removeClass('disabled');
                        elem.Obj.dialog1.find('ul.zxs a.disabled').removeClass('disabled');
                        if (elem.Obj.dialog2 && elem.Obj.dialog2.dialog("isOpen")) {
                            elem.Obj.dialog2.find('input:not(:checked)').attr('disabled', false);
                        }
                    }
                } else {
                    elem.Obj.dialog1.find('ul.zxs a.selected,ul.wholeprovince a.selected').removeClass('selected');
                    elem.Obj.dialog1.find('ul.wholeprovince a[value="' + v1 + '"]').addClass('selected');
                    elem.Obj.dialog1.find('ul.zxs a[value="' + v1 + '"]').addClass('selected');
                }
                if (elem.Obj.ObjSelectedResult.find('li').length > 0) {
                    elem.Obj.selected_container.show();
                } else {
                    elem.Obj.selected_container.hide();
                }
            }, addSingle: function (elem, v1, v2, text) {
                var objhot;
                if (elem.Obj.is_mult) {
                    if (v2) {
                        if (elem.Obj.ObjSelectedResult.find('li[v2=' + v2 + ']').length > 0) {
                            return false; //已经存在
                        }
                    } else {
                        if (v1 != "") {
                            elem.Obj.ObjSelectedResult.find('li[v1=' + v1 + ']').remove();
                        } else {
                            elem.Obj.ObjSelectedResult.html('');
                        }
                    }
                } else {
                    elem.Obj.ObjSelectedResult.html('');
                }

                var li_result = $('<li v1="' + v1 + '">' + text + '<span></span></li>');
                if (v2) { li_result.attr('v2', v2); }
                li_result.find('span').click(function () {
                    formOpertater.removeSingle(elem, v1, v2);
                    if (text == o.nolimitText) {
                        $('#' + elem.attr('id') + '-nolimit').attr('checked', false);
                        elem.Obj.dialog1.find('ul.wholeprovince a').removeClass('disabled');
                        elem.Obj.dialog1.find('ul.zxs a').removeClass('disabled');
                    }
                });
                elem.Obj.ObjSelectedResult.append(li_result);
                formOpertater.setSelectedCls(elem, v1);
                if (!elem.Obj.is_mult && elem.Obj.dialog2 && elem.Obj.dialog2.dialog("isOpen")) {
                    elem.Obj.dialog2.find('input').attr('checked', false)
                    if (v2) {
                        elem.Obj.dialog2.find('input[value=' + v2 + ']').attr('checked', true);
                    } else if (v1) {
                        elem.Obj.dialog2.find('input[value=' + v1 + ']').attr('checked', true);
                    }
                }
            }, removeSingle: function (elem, v1, v2) {
                if (v2) {
                    elem.Obj.ObjSelectedResult.find('li[v2=' + v2 + ']').remove();
                    //if (elem.Obj.hot_ul) elem.Obj.hot_ul.find('input[value=' + v2 + ']').attr('checked', false);
                } else {
                    elem.Obj.ObjSelectedResult.find('li[v1=' + v1 + ']').remove();
                    //if (elem.Obj.hot_ul) elem.Obj.hot_ul.find('input[value=' + v1 + ']').attr('checked', false);
                }
                formOpertater.setSelectedCls(elem, v1);
            }, resetCls: function (elem) {
                elem.Obj.ObjSelectedResult.find('li').remove();
                elem.Obj.selected_container.hide()
                elem.Obj.dialog1.find('ul.wholeprovince a').removeClass('disabled').removeClass('selected');
                elem.Obj.dialog1.find('ul.zxs a').removeClass('disabled').removeClass('selected');
                //if (elem.Obj.hot_ul) { elem.Obj.hot_ul.find('input').attr({ 'checked': false, 'disabled': false }); }
            }
        }
        var $this = this;
        $this.Obj = {
            dialog1: null,
            dialog2: null,
            dialog2_val: null,
            new_select: null,
            nolimit_container: null,
            hot_container: null,
            hot_ul: null,
            selected_container: null,
            ObjSelectedResult: null,
            input_type: $this.attr('multiple') ? "checkbox" : "radio",
            is_mult: $this.attr('multiple') ? true : false
        };
        formOpertater.createDom($this);
    }
})(jQuery);
var jZxs = ["1001", "1002", "1003", "1004"];