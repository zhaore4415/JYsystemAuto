(function ($) {
    $.formSelect = {}; $.formSelect.defaults = { z_index: 50, protoObj: [], max_z_index: 100 }; $.fn.formSelect = function (o) {
        var defaults = { emptyText: '请选择...', colWidth: null, align: null, closeBtn: null, select: 3, cols: null, className: '', specificeZindex: null, provinceCreate: null, selectPosition: 0, withInner: null, onShow: function () { }, onClose: function () { }, onSelect: function () { } }; o = $.extend({}, defaults, o); $(this).data('o', o); formOpertater = { o: o, documentClick_alerdy: false, getCon: function (elem) {
            elem.Obj.vt_array = []; elem.Obj.vt_object = {}; var value_array = []; var text_array = []; var o_list = $('option', elem); for (var num = 0; num < o_list.length; num++) {
                if (o_list.eq(num).text() == o.emptyText) { o_list.eq(num).remove(); continue; }
                value_array.push(o_list.eq(num).attr('value')); text_array.push(o_list.eq(num).text());
            }
            elem.Obj.vt_array = elem.Obj.vt_array.concat([value_array]); elem.Obj.vt_array = elem.Obj.vt_array.concat([text_array]); if (this.o.withInner) { var child = elem.children(); elem.Obj.showNum = child.length; child.each(function (index, dom) { if ($(dom).is('option')) { elem.Obj.vt_object['options' + index] = $(dom); } else if ($(dom).is('optgroup')) { elem.Obj.vt_object['optgroup' + index] = { 'optgroup': $(dom), innerCols: o.withInner.innerCols, innerColWidth: o.withInner.innerColWidth }; } }) } else { var o_list = $('option', elem); elem.Obj.showNum = o_list.length; o_list.each(function (index, dom) { elem.Obj.vt_object['options' + index] = $(dom); }) } 
        }, createDom: function (elem, mul_sig) {
            var elem_width, elem_height; elem_width = elem.outerWidth(); elem_height = elem.outerHeight(); elem.css({ 'opacity': '0' }).hide(); if (o.provinceCreate) { elem.Obj.new_select = $(o.provinceCreate[0] + o.provinceCreate[2]); }
            if (!mul_sig && !o.provinceCreate) { elem.Obj.new_select = $('<div class="default_select ' + o.className + '"><div class=""><input type="text" readonly="readonly" class="' + elem.attr('id') + '" /></div></div>'); }
            elem.Obj.className = o.className; var zIndex = $.formSelect.defaults.z_index--; elem.Obj.zIndex = zIndex; elem.Obj.new_select.find('input').data('normal', elem); elem.Obj.new_select.css({ 'height': (elem_height + 3) + 'px', 'width': elem_width + 'px', 'margin-right': elem.css('margin-right'), 'margin-top': elem.css('margin-top'), 'margin-bottom': elem.css('margin-bottom'), 'margin-left': elem.css('margin-left'), 'z-index': !mul_sig ? zIndex : elem.Obj.new_select.css('z-index') }).find('input').css({ 'height': (elem_height + 3) + 'px', 'width': (elem_width - 28) + 'px', 'line-height': (elem_height) + 'px', 'border': 'none' }).keydown(function (event) {
                if (event.which == 8) {
                    if (event.returnValue) { event.returnValue = false; }
                    return false;
                } 
            }); if (o.specificeZindex) { elem.Obj.new_select.css({ 'z-index': elem.data('o').specificeZindex }); }
            if (elem.attr('multiple')) { elem.Obj.select = o.select; elem.Obj.sig_mul = 1; elem.Obj.general_sa = []; elem.Obj.general_rel = []; elem.Obj.new_select.find('div:first').addClass('multiple'); } else { elem.Obj.sig_mul = 0; elem.Obj.general_sa = ''; elem.Obj.general_rel = ''; elem.Obj.new_select.find('div:first').addClass('signal'); }
            o.cols = o.cols || 1; this.createDrop(elem); elem.Obj.deop_down.css('z-index', zIndex); elem.Obj.new_select.append(elem.Obj.deop_down); if (!mul_sig) { elem.Obj.new_select.insertAfter(elem); }
            if (o.align) { elem.Obj.deop_down.find('p').css({ 'text-align': o.align, 'padding-left': '10px' }); }
            if (o.cols == 1 && !o.colWidth) { elem.Obj.deop_down.find('p').css({ 'width': (elem_width - 8) + 'px' }); } else if (o.colWidth) { elem.Obj.deop_down.find('p').css({ 'width': (o.colWidth) + 'px' }); elem.Obj.deop_down.css({ 'width': [o.cols * (o.colWidth + 7 + parseInt(elem.Obj.deop_down.find('p').css('padding-left')))] + 'px' }); elem.Obj.deop_down.find('.drop_wrap_border').css({ 'width': [o.cols * (o.colWidth + 6 + parseInt(elem.Obj.deop_down.find('p').css('padding-left')))] + 'px' }); elem.Obj.deop_down.find('.drop_list').css({ 'width': [o.cols * (o.colWidth + 6 + parseInt(elem.Obj.deop_down.find('p').css('padding-left')))] + 'px', 'height': '29px' }); }
            elem.Obj.deop_down.find('.drop_list:last').css({ 'border-bottom-color': '#f7fafc' }); var form_hasContent = elem.Obj.deop_down.find('div.form_hasContent'); var drop_wrap_inner = form_hasContent.find('dl.drop_wrap_inner'); var drop_list_inner = form_hasContent.find('dd.drop_list_inner'); var innerP = drop_wrap_inner.find('p'); $.each(form_hasContent, function () { elem.Obj.deop_downInner.push($(this)); }); if (o.withInner && o.withInner.innerColWidth) { innerP.width(o.withInner.innerColWidth); drop_list_inner.width([o.withInner.innerCols * (o.withInner.innerColWidth + 6 + parseInt(innerP.css('padding-left')))]); drop_list_inner.height(29); }
            this.addEventFun({ elem: elem.Obj.deop_down.find('p.select_item'), type: 'mouseover', callBack: function () { $(this).addClass('hover'); } }); this.addEventFun({ elem: elem.Obj.deop_down.find('p.select_item'), type: 'mouseout', callBack: function () { $(this).removeClass('hover'); } }); this.addEventFun({ elem: elem.Obj.deop_down.find('p:not(".justHandle")'), type: 'click', callBack: this.menuListClick, mainElem: elem }); this.addEventFun({ elem: elem.Obj.deop_down.find('p.justHandle'), type: 'click', callBack: function () { $(this).next('.drop_wrap_inner').find('.height_illInfo').click(); } }); this.addEventFun({ elem: innerP, type: 'mouseover', callBack: function (event) { $(this).addClass('innerHover'); } }); this.addEventFun({ elem: innerP, type: 'mouseout', callBack: function (event) { $(this).removeClass('innerHover'); } }); var timeout = null; this.addEventFun({ elem: form_hasContent, type: 'mouseenter', callBack: function () {
                if (timeout) { window.clearTimeout(timeout); timeout = null; }
                form_hasContent.find('p.justHandle').removeClass('hoverInnerHandle'); form_hasContent.find('dl.drop_wrap_inner').hide()
                $(this).find('p.justHandle').addClass('hoverInnerHandle'); $(this).find('dl.drop_wrap_inner').show();
            } 
            }); this.addEventFun({ elem: form_hasContent, type: 'mouseleave', callBack: function () { var self = $(this); timeout = window.setTimeout(function () { self.find('p.justHandle').removeClass('hoverInnerHandle'); self.find('dl.drop_wrap_inner').hide(); }, 200); } }); this.addEventFun({ elem: elem.Obj.deop_down.find('.close_btn'), type: 'click', callBack: this.closeBtnClick, mainElem: elem }); this.addEventFun({ elem: elem.Obj.deop_down.find('.chongX'), type: 'click', callBack: this.resetBtnClick, mainElem: elem }); if (!mul_sig) { this.addEventFun({ elem: elem.Obj.new_select, type: 'click', callBack: this.inputClick, mainElem: elem }); }
            this.addEventFun({ elem: elem.Obj.deop_down, type: 'click', callBack: function (event) { event.stopPropagation(); return false; } }); if (!this.documentClick_alerdy) { this.addEventFun({ elem: $(document), type: 'click', callBack: this.documentClick }); } 
        }, addEventFun: function (event_obj) { event_obj.elem.each(function () { $(this).bind(event_obj.type, { elem: event_obj.mainElem }, event_obj.callBack) }) }, createDrop: function (elem) {
            if (o.provinceCreate) { elem.Obj.deop_down = $(o.provinceCreate[1]); return; }
            var depper_item_num = Math.ceil(elem.Obj.vt_array[0].length / o.cols); var content_list_str = ""; for (var x = 0; x < depper_item_num; x++) {
                content_list_str = content_list_str + '<div class="drop_list">'; for (var y = o.cols * x; y < (o.cols + o.cols * x); y++) { if (y < elem.Obj.vt_array[0].length) { content_list_str = content_list_str + '<p index="' + y + '">' + elem.Obj.vt_array[1][y] + '</p>'; } }
                content_list_str = content_list_str + '</div>';
            }
            var depper_item_num1 = Math.ceil(elem.Obj.showNum / o.cols); var content_list_str1 = ""; content_list_str1 += '<div class="drop_list">'; var colCounter = 0; var rowCounter = 1; var colIndexCounter = 0; $.each(elem.Obj.vt_object, function (key, value) { if (value.optgroup && value.optgroup.is('optgroup')) { elem.Obj.optgroupNum++; var optgroup = value.optgroup.find('option'); var optgroupExpectOnt = value.optgroup.find('option:gt(0)'); var inner_item_num = Math.ceil((optgroupExpectOnt.length) / value.innerCols); var innercolCounter = 0; var innerrowCounter = 1; content_list_str1 += '<div index="' + colIndexCounter + '" class="form_hasContent" style="z-index: ' + (elem.Obj.innerz_index--) + '"><p class="select_item justHandle"  style="z-index: ' + (elem.Obj.innerz_index--) + '">' + optgroup.eq(0).text() + '</p><dl class="drop_wrap_inner"  style="z-index: ' + (elem.Obj.innerz_index--) + ';display:none;"><dd class="drop_list_inner"><p rel="' + optgroup.eq(0).attr('value') + '" class="height_illInfo ' + optgroup.eq(0).attr('class') + '">' + optgroup.eq(0).text() + '</p></dd><dd class="drop_list_inner">'; $.each(optgroupExpectOnt, function (index, dom) { content_list_str1 += '<p rel="' + $(dom).attr('value') + '" index="' + colIndexCounter + '">' + $(dom).text() + '</p>'; innercolCounter++; colIndexCounter++; if (innercolCounter >= value.innerCols && innerrowCounter != inner_item_num) { content_list_str1 += '</dd><dd class="drop_list_inner">'; innerrowCounter++; innercolCounter = 0; return; } }); content_list_str1 += '</dd></dl></div>'; colCounter++; if (colCounter >= o.cols && rowCounter != depper_item_num1) { content_list_str1 += '</div><div class="drop_list">'; rowCounter++; colCounter = 0; return; } } else if (value.is('option')) { content_list_str1 += '<p rel="' + value.attr('value') + '" index="' + colIndexCounter + '" class="select_item">' + value.text() + '</p>'; colCounter++; colIndexCounter++; if (colCounter >= o.cols && rowCounter != depper_item_num1) { content_list_str1 += '</div><div class="drop_list">'; rowCounter++; colCounter = 0; return; } } }); content_list_str1 += '</div>'
            elem.Obj.choice_info = ''; elem.Obj.close_btn = ''; if (o.closeBtn) { elem.Obj.close_btn = '<div class="close_btn" title="关闭"></div>'; } else { elem.Obj.close_btn = ''; }
            if (o.closeBtn == null && elem.Obj.sig_mul == 1) { elem.Obj.choice_info = '<div class="choice_info">可选择<span>' + elem.Obj.select + '</span>项<b>，已选<span class="alerdy_select">0</span>项 <span class="chongX">重选</span></b></div>'; elem.Obj.close_btn = '<div class="close_btn" title="关闭"></div>'; }
            elem.Obj.deop_down = $('<div class="drop_wrap"><div class="drop_wrap_border"><div class="angle"></div><h6 class="m_clr1"></h6><div class="button_wrap" style="width:' + (o.closeBtn ? "55px" : "25px") + ';">' + elem.Obj.close_btn + '</div><div style="height:8px; float:none; overflow:hidden;" class="form_top_empty"></div>' + elem.Obj.choice_info + content_list_str1 + '<h6 class="m_clr1"></h6><div style="height:8px; float:none; clear:both; overflow:hidden;" class="form_bottom_empty"></div></div></div>');
        }, documentClick: function (event) {
            for (var j = 0; j < $.formSelect.defaults.protoObj.length; j++) { if ($.formSelect.defaults.protoObj[j].Obj.hide_show == 'show' && !$(event.target).is('option')) { formOpertater.hide($.formSelect.defaults.protoObj[j]); } }
            this.documentClick_alerdy = true; event.stopPropagation();
        }, closeBtnClick: function (event) { var elem = event.data.elem; formOpertater.hide(elem); }, resetBtnClick: function (event) {
            var elem = event.data.elem; elem.Obj.selected = 0; elem.Obj.general_sa = (elem.Obj.sig_mul == 1 ? [] : ''); elem.Obj.general_rel = (elem.Obj.sig_mul == 1 ? [] : ''); elem.Obj.deop_down.find('p').each(function () { if ($(this).hasClass('clicked')) { formOpertater.addEventFun({ elem: $(this), type: 'click', callBack: formOpertater.menuListClick, mainElem: elem }); } })
            elem.Obj.deop_down.find('p').removeClass('clicked').removeClass('memclciked').removeClass('innerClick').removeClass('innerMem'); elem.Obj.new_select.find('input').val(''); elem.Obj.deop_down.find('.alerdy_select').html('0'); elem.find('option').each(function () { $(this).removeAttr('selected'); }); elem.Obj.deop_down.find('b').hide();
        }, inputClick: function (event) {
            var elem = event.data.elem; if (elem.Obj.sig_mul == 1) {
                elem.Obj.deop_down.find('p').not('.justHandle').each(function () {
                    if ($(this).hasClass('clicked')) { elem.Obj.selected++; $(this).addClass('memclciked').removeClass('clicked'); formOpertater.addEventFun({ elem: $(this), type: 'click', callBack: formOpertater.menuListClick, mainElem: elem }); }
                    if ($(this).hasClass('innerClick')) { elem.Obj.selected++; $(this).addClass('innerMem').removeClass('innerClick'); $(this).parents('.form_hasContent').find('.justHandle').addClass('memclciked').removeClass('clicked'); formOpertater.addEventFun({ elem: $(this), type: 'click', callBack: formOpertater.menuListClick, mainElem: elem }); } 
                })
                elem.Obj.deop_down.find('.alerdy_select').html(elem.Obj.selected); elem.Obj.general_sa = []; elem.Obj.general_rel = [];
            } else { }
            for (var k = 0; k < $.formSelect.defaults.protoObj.length; k++) { if ($.formSelect.defaults.protoObj[k].Obj.hide_show == 'show' && $.formSelect.defaults.protoObj[k] != elem) { $(document).trigger('click'); } }
            elem.Obj.deop_down.each(function () { if (!$(this).is(':hidden')) { formOpertater.hide(elem); } else { formOpertater.show(elem, o); } }); event.stopPropagation();
        }, menuListClick: function (event) {
            var elem = event.data.elem; elem.Obj.selected = 0; $this.find('option').each(function () { $(this).removeAttr('selected'); })
            if (elem.Obj.sig_mul == 0) {
                elem.Obj.general_sa = $(this).text(); elem.Obj.general_rel = $(this).attr('rel'); elem.Obj.new_select.find('input').val(elem.Obj.general_sa); elem.Obj.deop_down.find('p').removeClass('clicked').removeClass('innerClick'); ; if ($(this).parents('dl.drop_wrap_inner').length > 0) { $(this).addClass('innerClick'); $(this).parents('div.form_hasContent').find('p.justHandle').addClass('clicked'); } else { $(this).addClass('clicked'); }
                formOpertater.setSelect(elem, $(this).attr('rel')); o.onSelect(); $(document).trigger('click');
            }
            if (elem.Obj.sig_mul == 1) {
                $(this).unbind('click'); elem.Obj.general_sa.push($(this).text()); elem.Obj.general_rel.push($(this).attr('rel')); elem.Obj.new_select.find('input').val(elem.Obj.general_sa); elem.Obj.deop_down.find('p').removeClass('memclciked').removeClass('innerMem'); if ($(this).parents('dl.drop_wrap_inner').length > 0) { $(this).addClass('innerClick'); $(this).parents('div.form_hasContent').find('p.justHandle').addClass('clicked'); } else { $(this).addClass('clicked'); }
                elem.Obj.deop_down.find('.alerdy_select').html(elem.Obj.general_sa.length); elem.Obj.deop_down.find('b').show(); formOpertater.setSelect(elem, $(this).attr('rel')); if (elem.Obj.general_sa.length >= elem.Obj.select) { $(document).trigger('click'); } 
            }
            event.stopPropagation();
        }, setSelect: function (elem, rel) {
            var option = elem.find('option'); if (elem.Obj.sig_mul == 0) { elem.find('option[value="' + rel + '"]').attr({ 'selected': 'selected' }); } else { $.each(elem.Obj.general_rel, function (k, v) { elem.find('option[value="' + v + '"]').attr({ 'selected': 'selected' }); }); }
            return; if (elem.Obj.sig_mul == 0) { for (var i = 0, len = option.length; i < len; i++) { if (option.eq(i).attr('value') == elem.Obj.general_rel) { option.eq(i).attr({ 'selected': 'selected' }) } } } else { for (var m = 0; m < elem.Obj.general_rel.length; m++) { for (var n = 0, len = option.length; n < len; n++) { if (elem.Obj.general_rel[m] == option.eq(n).attr('value')) { option.eq(n).attr({ 'selected': 'selected' }) } } } } 
        }, initialize: function (elem) {
            if (elem.Obj.sig_mul == 1) {
                elem.find('option').each(function (index) {
                    if ($(this).attr('selected')) {
                        elem.Obj.general_sa.push($(this).text()); elem.Obj.general_rel.push($(this).attr('rel'))
                        var toSelectp = elem.Obj.deop_down.find('p').not('.justHandle').eq(index); var toSelectparent = toSelectp.parents('.form_hasContent'); if (toSelectparent.length > 0) { toSelectp.addClass('innerMem'); toSelectparent.find('.justHandle').addClass('memclciked'); } else { toSelectp.addClass('memclciked'); }
                        elem.Obj.selected++;
                    }
                    elem.Obj.selected > 0 && elem.Obj.deop_down.find('b').show();
                })
                elem.Obj.new_select.find('input').val(elem.Obj.general_sa);
            } else {
                elem.find('option').each(function (index) {
                    if ($(this).attr('selected')) { if ($(this).text() != o.emptyText) { elem.Obj.general_sa = $(this).text(); elem.Obj.general_rel = $(this).attr('rel'); var toSelectp = elem.Obj.deop_down.find('p').not('.justHandle').eq(index); var toSelectparent = toSelectp.parents('.form_hasContent'); if (toSelectparent.length > 0) { toSelectp.addClass('innerClick'); toSelectparent.find('.justHandle').addClass('clicked'); } else { toSelectp.addClass('clicked'); } } }
                    elem.Obj.new_select.find('input').val(elem.Obj.general_sa);
                })
            } 
        }, show: function (elem, o) {
            if (elem.Obj.sig_mul == 0) { elem.Obj.new_select.find('div:first').addClass('sigfocus'); } else { elem.Obj.new_select.find('div:first').addClass('mulfocus'); }
            var winH = $(window).height(); var selectOffsetTop = elem.prev().length > 0 ? elem.prev().offset().top : elem.next().offset().top; var documentScrollTop = $(document).scrollTop(); var centerPos = documentScrollTop + winH / 2; if (o && o.selectPosition != 0) {
                elem.Obj.deop_down.find('.form_bottom_empty').hide(); elem.Obj.deop_down.find('.form_top_empty').show(); var choice = elem.Obj.deop_down.find('.choice_info'); if (choice) { choice.css({ 'border-bottom': '1px solid #c8d7e4' }); elem.Obj.deop_down.find('.form_top_empty').after(choice); }
                elem.Obj.deop_down.find('.drop_list:last').css({ 'border-bottom-color': '#f7fafc' }); elem.Obj.deop_down.css({ 'top': (elem.Obj.className ? 20 : 23) + 'px' })
                elem.Obj.deop_down.removeClass('showBelow'); elem.Obj.deop_down.find('.angle').css({ 'top': (-1) + 'px' });
            }
            else {
                if (selectOffsetTop < centerPos) {
                    elem.Obj.deop_down.find('.form_bottom_empty').hide(); elem.Obj.deop_down.find('.form_top_empty').show(); var choice = elem.Obj.deop_down.find('.choice_info'); if (choice) { choice.css({ 'border-bottom': '1px solid #c8d7e4' }); elem.Obj.deop_down.find('.form_top_empty').after(choice); }
                    elem.Obj.deop_down.find('.drop_list:last').css({ 'border-bottom-color': '#f7fafc' }); elem.Obj.deop_down.css({ 'top': (elem.Obj.className ? 20 : 23) + 'px' })
                    elem.Obj.deop_down.removeClass('showBelow'); elem.Obj.deop_down.find('.angle').css({ 'top': (-1) + 'px' });
                } else {
                    if (!elem.Obj.sig_mul) { elem.Obj.deop_down.find('.drop_list:last').css({ 'border-bottom-color': '#f7fafc' }); } else { elem.Obj.deop_down.find('.drop_list:last').css({ 'border-bottom-color': '#c8d7e4' }); }
                    elem.Obj.deop_down.find('.form_bottom_empty').show(); elem.Obj.deop_down.find('.form_top_empty').show(); if (!elem.Obj.close_btn) { }
                    var choice = elem.Obj.deop_down.find('.choice_info'); if (choice) { choice.css({ 'border-bottom': 'none' }); elem.Obj.deop_down.find('.form_bottom_empty').before(choice); }
                    elem.Obj.deop_down.css({ 'top': (-elem.Obj.deop_down.height() + 1) + 'px' })
                    elem.Obj.deop_down.addClass('showBelow'); elem.Obj.deop_down.find('.angle').css({ 'top': (elem.Obj.deop_down.height() - 9) + 'px' });
                } 
            }
            elem.Obj.deop_down.parent('.default_select ').css({ 'z-index': '' + ($.formSelect.defaults.max_z_index) + '' }); elem.Obj.deop_down.css({ 'z-index': '' + ($.formSelect.defaults.max_z_index) + '' }); elem.Obj.deop_down.show(); elem.Obj.hide_show = 'show'; if (elem.data('o').onShow) { elem.data('o').onShow(); } 
        }, hide: function (elem) {
            elem.Obj.new_select.find('div:first').removeClass('mulfocus'); elem.Obj.new_select.find('div:first').removeClass('sigfocus'); elem.Obj.hide_show = 'hide'; $.each(elem.Obj.deop_downInner, function (index, value) { value.find('dl.drop_wrap_inner').hide(); }); elem.Obj.deop_down.parent('.default_select ').css({ 'z-index': '' + (elem.Obj.zIndex) + '' })
            elem.Obj.deop_down.css({ 'z-index': '' + (elem.Obj.zIndex) + '' })
            elem.Obj.deop_down.hide(); if (elem.data('o').onClose) { elem.data('o').onClose(); } 
        } 
        }
        var $this = this; $this.data('Obj', { vt_array: [], vt_object: {}, deop_down: null, new_select: null, hide_show: 'hide', general_sa: null, sig_mul: null, choice_info: null, close_btn: '', select: null, selected: 0, zIndex: null, className: '', innermaxz_index: 13, innerz_index: 100, optgroupNum: 0, deop_downInner: [], reflash: function (elem) { elem.Obj = elem.data('Obj'); elem.Obj.new_select.find('.drop_wrap').remove(); formOpertater.getCon(elem); formOpertater.createDrop(elem); formOpertater.createDom(elem, true); formOpertater.initialize(elem); } }); $this.Obj = $this.data('Obj'); $.formSelect.defaults.protoObj.push($this); formOpertater.getCon($this); formOpertater.createDom($this); formOpertater.initialize($this);
    }
    $.fn.formFile = function (o) {
        var defaults = { type: ['jpg', 'gif', 'png', 'jpeg'], className: '', width: 152, onChange: function () { } }; o = $.extend({}, defaults, o); this.css({ 'opacity': '0', 'position': 'relative', 'z-index': '2', 'width': o.width }); this.parents('.elem_wrap').css({ 'position': 'relative' }); if ($.browser.mozilla) { o.width - 80 > 0 && this.attr('size', Math.ceil((o.width - 80) / 7)); }
        $this = this; replaceDiv = $('<div class="default_file ' + o.className + '" id="' + this.attr('id') + '_file"><span class="file_content"></span></div>')
        this.Obj = this.data('Obj'); var posit = function () { replaceDiv.css({ 'width': ($this.outerWidth()) + 'px', 'position': 'absolute', 'top': $this.position().top, 'left': $this.position().left, 'z-index': '1' }).click(function () { $this.trigger('click'); }); replaceDiv.find('.file_content').css({ 'width': (o.width - 60 - 4) + 'px', 'height': ($this.outerHeight()) + 'px', 'position': 'absolute', 'top': 0, 'left': 0, 'z-index': '2' }); }; posit(); replaceDiv.insertAfter(this); $this.bind('change', function () { var filename = $(this).val(); filename = filename.split('\\'); filename = filename[filename.length - 1]; $('#' + $(this).attr('id') + '_file').find('.file_content').html(filename); });
    };
})(jQuery);
; jQuery.cookie = function (key, value, options) {
    if (arguments.length > 1 && (value === null || typeof value !== "object")) {
        options = jQuery.extend({}, options); if (value === null) { options.expires = -1; }
        if (typeof options.expires === 'number') { var days = options.expires, t = options.expires = new Date(); t.setDate(t.getDate() + days); }
        return (document.cookie = [encodeURIComponent(key), '=', options.raw ? String(value) : encodeURIComponent(String(value)), options.expires ? '; expires=' + options.expires.toUTCString() : '', options.path ? '; path=' + options.path : '', options.domain ? '; domain=' + options.domain : '', options.secure ? '; secure' : ''].join(''));
    }
    options = value || {}; var result, decode = options.raw ? function (s) { return s; } : decodeURIComponent; return (result = new RegExp('(?:^|; )' + encodeURIComponent(key) + '=([^;]*)').exec(document.cookie)) ? decode(result[1]) : null;
};
; (function ($) {
    $.toJSON = function (o) {
        if (typeof (JSON) == 'object' && JSON.stringify)
            return JSON.stringify(o); var type = typeof (o); if (o === null)
            return "null"; if (type == "undefined")
            return undefined; if (type == "number" || type == "boolean")
            return o + ""; if (type == "string")
            return $.quoteString(o); if (type == 'object') {
            if (typeof o.toJSON == "function")
                return $.toJSON(o.toJSON()); if (o.constructor === Date) {
                var month = o.getUTCMonth() + 1; if (month < 10) month = '0' + month; var day = o.getUTCDate(); if (day < 10) day = '0' + day; var year = o.getUTCFullYear(); var hours = o.getUTCHours(); if (hours < 10) hours = '0' + hours; var minutes = o.getUTCMinutes(); if (minutes < 10) minutes = '0' + minutes; var seconds = o.getUTCSeconds(); if (seconds < 10) seconds = '0' + seconds; var milli = o.getUTCMilliseconds(); if (milli < 100) milli = '0' + milli; if (milli < 10) milli = '0' + milli; return '"' + year + '-' + month + '-' + day + 'T' +
hours + ':' + minutes + ':' + seconds + '.' + milli + 'Z"';
            }
            if (o.constructor === Array) {
                var ret = []; for (var i = 0; i < o.length; i++)
                    ret.push($.toJSON(o[i]) || "null"); return "[" + ret.join(",") + "]";
            }
            var pairs = []; for (var k in o) {
                var name; var type = typeof k; if (type == "number")
                    name = '"' + k + '"'; else if (type == "string")
                    name = $.quoteString(k); else
                    continue; if (typeof o[k] == "function")
                    continue; var val = $.toJSON(o[k]); pairs.push(name + ":" + val);
            }
            return "{" + pairs.join(", ") + "}";
        } 
    }; $.evalJSON = function (src) {
        if (typeof (JSON) == 'object' && JSON.parse)
            return JSON.parse(src); return eval("(" + src + ")");
    }; $.secureEvalJSON = function (src) {
        if (typeof (JSON) == 'object' && JSON.parse)
            return JSON.parse(src); var filtered = src; filtered = filtered.replace(/\\["\\\/bfnrtu]/g, '@'); filtered = filtered.replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']'); filtered = filtered.replace(/(?:^|:|,)(?:\s*\[)+/g, ''); if (/^[\],:{}\s]*$/.test(filtered))
            return eval("(" + src + ")"); else
            throw new SyntaxError("Error parsing JSON, source is not valid.");
    }; $.quoteString = function (string) {
        if (string.match(_escapeable)) {
            return '"' + string.replace(_escapeable, function (a)
            { var c = _meta[a]; if (typeof c === 'string') return c; c = a.charCodeAt(); return '\\u00' + Math.floor(c / 16).toString(16) + (c % 16).toString(16); }) + '"';
        }
        return '"' + string + '"';
    }; var _escapeable = /["\\\x00-\x1f\x7f-\x9f]/g; var _meta = { '\b': '\\b', '\t': '\\t', '\n': '\\n', '\f': '\\f', '\r': '\\r', '"': '\\"', '\\': '\\\\' };
})(jQuery);
; ; (function ($) {
    $.fn.niuAlert_isOpened = null; $.fn.niuAlert = function (options) {
        var defaults = { divId: "", content: "", width: 340, height: "auto", padding: "25px 25px 15px 25px", showButton: true, button: [{ type: "close", value: "知道了！"}], buttonAlign: "right", balckbg: true, drag: true, center: true, closeBtn: false, onClose: function () { } }; var options = $.extend(defaults, options, {}); if ($.fn.niuAlert_isOpened) { $.fn.niuAlert_isOpened.remove(); $.fn.niuAlert_isOpened = null; }
        var _interFace = $("<table cellpadding='0' cellspacing='0' id='outer_face'><tr><td></td><td></td><td></td></tr> <tr><td></td><td></td><td></td></tr> <tr><td></td><td></td><td></td></tr></table>"); _interFace.appendTo("body"); var _interFace = $("#outer_face"); _interFace.addClass("alert_table"); _interFace.find("tr:eq(0)").find("td:eq(0)").addClass("top_left"); _interFace.find("tr:eq(0)").find("td:eq(2)").addClass("top_right"); _interFace.find("tr:eq(2)").find("td:eq(0)").addClass("bottom_left"); _interFace.find("tr:eq(2)").find("td:eq(2)").addClass("bottom_right"); _interFace.find("tr:eq(0)").find("td:eq(1)").addClass("alert_border_tb"); _interFace.find("tr:eq(1)").find("td:eq(0)").addClass("alert_border_lr"); _interFace.find("tr:eq(1)").find("td:eq(2)").addClass("alert_border_lr"); _interFace.find("tr:eq(2)").find("td:eq(1)").addClass("alert_border_tb"); var the_wrap_of_content = _interFace.find("tr:eq(1)").find("td:eq(1)"); $("<div id='content_wrap_div'></div>").appendTo(the_wrap_of_content); if (options.width) { the_wrap_of_content.width(options.width); }
        if (options.height && typeof options.height == "number") { the_wrap_of_content.height(options.height); }
        if (options.height == "auto") { the_wrap_of_content[0].style.height = "auto"; }
        if (options.padding) { $("#content_wrap_div").css("padding", options.padding); }
        if (options.closeBtn) { $("<p id='niuAlter_close'></p>").appendTo($("#content_wrap_div")); $("#niuAlter_close").addClass("niuAlter_close").bind("click", function () { _interFace.close(true); }); }
        if (options.balckbg) { var balckbg = $("<div id='balckbg'></div>"); balckbg.appendTo(document.body); balckbg = $("#balckbg"); balckbg.css({ "width": $(document).width() + "px", "height": $(document).height() + "px", "position": "absolute", "top": "0px", "left": "0px", "opacity": 0.4, "background": "#000", "z-index": "999" }); }
        if (options.drag) { var drag_hand = $("<p></p>"); drag_hand.appendTo($("#content_wrap_div")).addClass("drag_hand_css"); drag_hand.width(options.width + 16) }
        if (options.divId)
            options.content = $("#" + options.divId).html(); if (options.content)
            $("#content_wrap_div").append("<div>" + options.content + "</div>"); if (options.showButton) {
            var niuAlert_button_div_warp = "<div id='niuAlert_button_div_warp' style='text-align:" + options.buttonAlign + "'>"; if (options.button) { for (var array_length = 0; array_length < options.button.length; array_length++) { niuAlert_button_div_warp += "<a href='#' id='niuAlert_" + array_length + "' class='niuAlert_align_" + options.button[array_length].align + "' _type='" + options.button[array_length].type + "'>" + options.button[array_length].value + "</a>"; } }
            niuAlert_button_div_warp += "</div>"
            $(niuAlert_button_div_warp).appendTo($("#content_wrap_div")); for (var i = 0; i < options.button.length; i++) { (function (i) { if ($("#niuAlert_" + i).attr("_type") == "close") { $("#niuAlert_" + i).click(function () { _interFace.close(true); return false; }); } else if (options.button[i].onclick) { $("#niuAlert_" + i).click(function () { options.button[i].onclick(); return false; }); } })(i); } 
        }
        options.height = _interFace.height(); var top = ($(window).height() - options.height) / 2 + $(window).scrollTop(); var left = ($(window).width() - options.width) / 2; if (options.center) { _interFace.css({ "top": top + "px", "left": left + "px" }); }
        $("<a href='#' onclick='return false;'></a>").appendTo($("#content_wrap_div")).focus(); var move = false; var orgainwidth = _interFace.width(); $(".drag_hand_css").mousedown(function (event) { move = true; var ol = _interFace.offset().left, ot = _interFace.offset().top; moveX = event.pageX - ol; moveY = event.pageY - ot; })
        $(document).mousemove(function (event) {
            if (move) {
                var x = event.pageX - moveX; var y = event.pageY - moveY; if (x <= 0) { x = 0; }
                if (y <= 0) { y = 0; }
                if (x >= $(document).width() - orgainwidth) { x = $(document).width() - orgainwidth }
                _interFace[0].style.left = x + "px"; _interFace[0].style.top = y + "px"; _interFace[0].style.margin = "auto";
            } 
        })
        $(document).mouseup(function (event) { orgainwidth = _interFace.width(); move = false; })
        _interFace.close = function () { _interFace.fadeOut(100, function () { _interFace.remove(); $.fn.niuAlert_isOpened = null; options.onClose(); }); if (options.balckbg) { $("#balckbg").fadeOut(100, function () { $("#balckbg").remove(); }); } }
        _interFace.show = function () { if (_interFace) { _interFace.fadeIn(); if (options.balckbg) { $("#balckbg").fadeIn(150); } } }
        $.fn.niuAlert_isOpened = _interFace; return _interFace;
    } 
})(jQuery)
; $.getIp = function (url, o) {
    o = jQuery.extend({ ip: '', callback: function (data) { }, cookieOption: { name: 'hg_getip', path: '/'} }, o); var ipInfo = (!o.ip) ? $.cookie(o.cookieOption.name) : null; try {
        if (ipInfo == null) {
            var saveCookie = function (data) {
                if (!o.ip)
                    $.cookie(o.cookieOption.name, $.toJSON(data), o.cookieOption); o.callback(data);
            }
            jQuery.getJSON(url + '?callback=?&' + Math.random(), { ip: o.ip }, saveCookie);
        } else { o.callback($.evalJSON(ipInfo)); } 
    }
    catch (e) { } 
}; $.getIp.search = function (searchStr, dropDownList) { dropDownList.find('option').each(function () { if ($(this).text().indexOf(searchStr) >= 0) { $(this).attr('selected', 'selected'); return false; } }); };
; (function ($) {
    $.fn.jCarouselLite = function (o) {
        o = $.extend({ btnPrev: null, btnNext: null, btnGo: null, mouseWheel: false, auto: null, speed: 200, easing: null, vertical: false, circular: true, visible: 1, start: 0, scroll: 1, beforeStart: null, afterEnd: null, wrap: null, clearIntervasl: true }, o || {}); var rotate_interval = null; return this.each(function () {
            var running = false, animCss = o.vertical ? "top" : "left", sizeCss = o.vertical ? "height" : "width"; var div = $(this), ul = $("ul", div), tLi = $("li", ul), tl = tLi.size(), v = o.visible; if (o.wrap) { tLi = $("div", ul), tl = tLi.size(), v = o.visible; }
            if (o.circular) { ul.prepend(tLi.slice(tl - v - 1 + 1).clone()).append(tLi.slice(0, v).clone()); o.start += v; }
            var li = $(o.wrap, ul), itemLength = li.size(), curr = o.start; div.css("visibility", "visible"); li.css({ overflow: "hidden" }); ul.css({ margin: "0", padding: "0", position: "relative", "list-style-type": "none", "z-index": "2" }); div.css({ overflow: "hidden", position: "relative", "z-index": "1", left: "0px" }); var liSize = o.vertical ? height(li) : width(li); var ulSize = liSize * itemLength; var divSize = liSize * v; li.css({ width: li.width(), height: li.height() }); ul.css(sizeCss, ulSize + "px").css(animCss, -(curr * liSize)); div.css(sizeCss, divSize + "px"); if (o.btnPrev)
                $(o.btnPrev).click(function () { return go(curr - o.scroll); }); if (o.btnNext)
                $(o.btnNext).click(function () { return go(curr + o.scroll); }); if (o.btnGo)
                $.each(o.btnGo, function (i, val) { $(val).click(function () { return go(o.circular ? o.visible + i : i); }); }); if (o.mouseWheel && div.mousewheel)
                div.mousewheel(function (e, d) { return d > 0 ? go(curr - o.scroll) : go(curr + o.scroll); }); if (o.auto)
                rotate_interval = setInterval(function () { go(curr + o.scroll); }, o.auto + o.speed); if (o.clearIntervasl) {
                $(o.clearIntervasl).bind('mouseenter', function () {
                    if (rotate_interval) {
                        clearInterval(rotate_interval)
                        rotate_interval = null;
                    } 
                }).bind('mouseleave', function () { rotate_interval = setInterval(function () { go(curr + o.scroll); }, o.auto + o.speed); })
            }
            function vis() { return li.slice(curr).slice(0, v); }; function go(to) {
                if (!running) {
                    if (o.beforeStart)
                        o.beforeStart.call(this, vis()); if (o.circular) { if (to <= o.start - v - 1) { ul.css(animCss, -((itemLength - (v * 2)) * liSize) + "px"); curr = to == o.start - v - 1 ? itemLength - (v * 2) - 1 : itemLength - (v * 2) - o.scroll; } else if (to >= itemLength - v + 1) { ul.css(animCss, -((v) * liSize) + "px"); curr = to == itemLength - v + 1 ? v + 1 : v + o.scroll; } else curr = to; } else { if (to < 0 || to > itemLength - v) return; else curr = to; }
                    running = true; ul.animate(animCss == "left" ? { left: -(curr * liSize)} : { top: -(curr * liSize) }, o.speed, o.easing, function () {
                        if (o.afterEnd)
                            o.afterEnd.call(this, vis()); running = false;
                    }); if (!o.circular) { $(o.btnPrev + "," + o.btnNext).removeClass("disabled"); $((curr - o.scroll < 0 && o.btnPrev) || (curr + o.scroll > itemLength - v && o.btnNext) || []).addClass("disabled"); } 
                }
                return false;
            };
        });
    }; function css(el, prop) { return parseInt($.css(el[0], prop)) || 0; }; function width(el) { return el[0].offsetWidth + css(el, 'marginLeft') + css(el, 'marginRight'); }; function height(el) { return el[0].offsetHeight + css(el, 'marginTop') + css(el, 'marginBottom'); };
})(jQuery);