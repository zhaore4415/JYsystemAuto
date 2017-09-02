var $ = function(v) { return document.getElementById(v); };
var cursPos; // 窗口全局变量，保存目标 TextBox 的最后一次活动光标位置
var ddd = 0;
String.prototype.trim = function() { return this.replace(/(^\s*)|(\s*$)/g, ""); };
var editor = {
    Height: document.documentElement.clientHeight - 32,
    Width: document.documentElement.clientWidth - 2,
    EditId: null,
    switchMode: function(o) {
        var v = o.checked;
        var a = $('htmlEditorPanel');
        var b = $('sourceEditorPanel');
        a.style.display = v ? 'none' : 'block';
        b.style.display = v ? 'block' : 'none';
        var sourceEditor = $("sourceEditor");
        var f = window.frames["HtmlEditor"];
        var body = f.document.getElementsByTagName("BODY")[0];
        o.setAttribute('title', v ? '编辑模式' : '查看代码');
        v ? sourceEditor.value = body.innerHTML : body.innerHTML = sourceEditor.value;
    }, border: function() {
        var m = document.getElementById('navTitle').getElementsByTagName('div');
        for (var i = 0; i < m.length; i++) {
            var o = m[i];
            if (o.className == 'line') continue;
            o.onmouseover = function() { this.style.borderRight = "1px #ccc solid"; this.style.borderBottom = "1px #ccc solid"; this.style.borderTop = "1px #F3F8FC solid"; this.style.borderLeft = "1px #F3F8FC solid"; };
            o.onmouseout = function() { this.style.border = "none"; };
        }
    }, init: function() {
        editor.EditId = this.request('id');
        var f = window.frames["HtmlEditor"];
        f.document.designMode = "on";
        var fdoc = f.document;
        if (!document.all)
            f.document.execCommand("useCSS", false, true);
        var html = parent.document.getElementById(this.EditId).value;
        if (html) {
            fdoc.open();
            fdoc.write('<html><head></head><body>');
            fdoc.write(html);
            fdoc.write('</body></html>');
            fdoc.close();
        }
        setTimeout(function() { editor.load(editor.EditId); }, 0);
    }, request: function(name) {//获取页面ID参数
        var reg = new RegExp("(^|\\?|&)" + name + "=([^&]*)(\\s|&|$)", "i");
        if (reg.test(location.href))
            return unescape(RegExp.$2.replace(/\+/g, " "));
        return "";
    }, familyPicker: {
        families: ['宋体', '黑体', '楷体', '隶书', '幼圆', 'Arial', 'Arial Narrow', 'Arial Black', 'Comic Sans MS', 'Courier', 'System', 'New Roman', 'Times', 'Verdana'],
        insert: function(v) {
            //v.blur();
            editor.format('fontname', v.innerHTML);
            EasyMask.close();
        }, draw: function() {
            var s = [];
            for (var i = 0; i < this.families.length; i++) {
                s.push('<a style="font:14px\'');
                s.push(this.families[i]);
                s.push('\';display:block;text-decoration:none;color:' + (i % 2 == 0 ? '#000000' : '#7D0000') + ';padding:2px 2px 2px 2px;float:left;height:30px;line-height:30px;display:inline;margin:6px 6px 0 0" href="javascript:void(0)" onclick="editor.familyPicker.insert(this)">');
                s.push(this.families[i]);
                s.push("</a>");
            }
            EasyMask.init({ width: 350, height: 170, title: '请选择字体', detail: s.join(''), opacity: 3, molor: '#000', bgcolor: '#7D0000' });
        }
    }, fontSize: {
        draw: function() {
            var sizes = [[1, 'xx-small', '最小'], [2, 'x-small', '特小'], [3, 'small', '小'], [4, 'medium', '中'], [5, 'large', '大'], [6, 'x-large', '特大'], [7, 'xx-large', '最大']];
            var s = [];
            for (var i = 0; i < sizes.length; i++) {
                s.push('<a style="display:block;text-decoration:none;color:' + (i % 2 == 0 ? '#000000' : '#7D0000') + ';padding:2px 2px 2px 2px;float:left;height:100px;line-height:100px;display:inline;margin:6px 6px 0 0" href="javascript:void(0)" onclick="editor.fontSize.insert(' + sizes[i][0] + ')">');
                s.push('<font size="' + sizes[i][0] + '">' + sizes[i][2] + '</font>');
                s.push("</a>");
            }
            EasyMask.init({ width: 350, height: 170, title: '请选择字体', detail: s.join(''), opacity: 3, molor: '#000', bgcolor: '#7D0000' });
        }, insert: function(size) {
            editor.format('fontsize', size);
            EasyMask.close();
        }
    }, load: function(ContentID) {
        try {
            if (typeof (window.frames["HtmlEditor"]) == "object") {
                window.frames['HtmlEditor'].document.getElementsByTagName('BODY')[0].innerHTML = window.parent.document.getElementById(ContentID).value;
                setInterval(function() { editor.save(ContentID); }, 500);
            } else {
                setTimeout(function() { editor.load(ContentID) }, 200)
            }
        } catch (e) {
            //alert(e);
        }

    }, colorSelector: function(v) {
        var c = editor.colorPacker.draw();
        var s = [];
        s.push('<div style="width:198px;height:132px;overflow:hidden;float:left;display:inline;margin-right:6px">' + c + '</div>');
        s.push('<div style="float:left;width:100px;height:132px"><div id="colorPackerPreview" style="border:1px solid #7D0000;width:98px;height:97px;text-align:center;line-height:97px" rel="' + v + '"></div><div id="colorPackerSelected" style="border:1px solid #7D0000;width:98px;height:22px;text-align:center;line-height:22px;margin-top:9px;color:#7D0000"></div></div>');
        EasyMask.init({ width: 316, height: 170, title: v == 0 ? '请选择前景色' : '请选择背景色', detail: s.join(''), opacity: 3, molor: '#000', bgcolor: '#7D0000' });

    }, colorPacker: {
        colos: ['FF', 'CC', '99', '66', '33', '00'],
        // 呈现一行颜色
        drawRow: function(s, red, blue) {
            for (var i = 0; i < 6; ++i) {
                var c = '#' + red + this.colos[i] + blue;
                s.push('<div style="height:11px;width:11px;background:' + c + ';overflow:hidden;float:left;" onmouseover="editor.colorPacker.preview(\'' + c + '\');" onclick="editor.colorPacker.selected(\'' + c + '\');"><img src="images/place.gif" height="12" width="12" border="0"></div>');
            }
        },
        // 呈现六个颜色区之一
        drawBlock: function(s, blue) {
            for (var i = 0; i < 6; ++i)
                this.drawRow(s, this.colos[i], blue);
        },
        // 获取拾取器的HTML代码
        draw: function() {
            var s = [];
            for (var i = 0; i < 6; ++i) {
                s.push('<div style="width:66px;height:66px;overflow:hidden;float:left;margin:0">');
                this.drawBlock(s, this.colos[i]);
                s.push('</div>');
            }
            return s.join('');
        }, preview: function(v) {
            var o = $('colorPackerPreview');
            o.style.backgroundColor = v;
            var c = $('colorPackerSelected');
            c.innerHTML = v;
        }, selected: function(v) {
            var rel = $('colorPackerPreview').getAttribute('rel');
            editor.format(rel == 0 ? 'foreColor' : document.all ? 'backcolor' : 'hilitecolor', v);
            if (document.all) editor.format('Unselect');
            EasyMask.close();
        }
    }, save: function(ContentID) {
        var sourceEditor = $('sourceEditor');
        var panal = $('sourceEditorPanel');
        var f = window.frames['HtmlEditor'].document.getElementsByTagName('body')[0];
        var html = f.innerHTML;
        if (sourceEditor.value != html) {
            if (panal.style.display == "none")
                sourceEditor.value = html;
            else
                f.innerHTML = sourceEditor.value;
        }
        var source = parent.document.getElementById(ContentID);
        if (source && source.value != html)
            source.value = html;
    }, expand: function(v) {
        var s = [];
        var t = '';
        var p = '';
        switch (v) {
            case 'link':
                //                s.push('<div>请输入网址（例：http://www.nsid.com）</div><div><input type="text" id="linkUrl" value="http://" class="input" style="height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;" onfocus="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #359AFF;color:#359AFF;background:#DFEEFD;\'" onblur="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;\'"/></div>');
                //                s.push('<div style="text-align:right"><input type="button" value="确定" class="button" onclick="editor.result(\'link\')" /></div>');
                //                p = '插入超级链接';
                var u = window.prompt("请输入网址：(例：http://www.abc.com/)", "http://");
                if ((u != null) && (u != "http://"))
                    editor.format("CreateLink", u);
                break;
            case 'image':
                s.push('<div class="details"><div>请输入图片地址（例：http://www.nsid.cn/logo.gif）</div><div><input type="text" id="imageUrl" value="" class="input" style="height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;" onfocus="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #359AFF;color:#359AFF;background:#DFEEFD;\'" onblur="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;\'"/></div>');
                s.push('<div style="text-align:right"><input type="button" value="确定" class="button" onclick="editor.result(\'image\')"  /></div></div>');
                p = '插入网络图片';
                EasyMask.init({ width: 316, height: 100, title: p, detail: s.join(''), opacity: 3, molor: '#000', bgcolor: '#7D0000' })
                //                var u = prompt("请输入图片位置:", "http://");
                //                if ((u != null) && (u != "http://"))
                //                    editor.format("InsertImage", u);
                break;
            case 'table':
                p = '插入表格';
                s.push('<div class="details"><div>行：<input type="text" id="tableCell" value="3" class="table" style="height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;" onfocus="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #359AFF;color:#359AFF;background:#DFEEFD;\'" onblur="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;\'"/> <label id="tableCells">数字类型</label></div>');
                s.push('<div>列：<input type="text" id="tableRow" value="3" class="table" style="height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;" onfocus="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #359AFF;color:#359AFF;background:#DFEEFD;\'" onblur="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;\'"/> <label id="tableRows">数字类型</label></div>');
                s.push('<div>宽：<input type="text" id="tableWidth" value="300" class="table" style="height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;" onfocus="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #359AFF;color:#359AFF;background:#DFEEFD;\'" onblur="this.style.cssText=\'height:18px;padding-top:3px;border:1px solid #ccc;color:#ccc;background:#fff;\'"/> <label id="tableWidths">数字类型</label></div>');
                s.push('<div style="text-align:right"><input type="button" value="确定" class="button" onclick="editor.result(\'table\')"  /></div></div>');
                EasyMask.init({ width: 316, height: 170, title: p, detail: s.join(''), opacity: 3, molor: '#000', bgcolor: '#7D0000' })
                break;
            case 'uploadfile':
                p = '上传本地文件';
                break;
            case 'uploadimage':
                s.push("<iframe src=\"file.html\" frameborder=\"no\" scrolling=\"no\" style=\"height:130px;width:100%!important;_width:338px;overflow:hidde;\"></iframe>");
                p = '上传本地图片';
                EasyMask.init({ width: 350, height: 170, title: p, detail: s.join(''), opacity: 3, molor: '#000', bgcolor: '#7D0000' });
                break;
        }

    }, result: function(v) {
        switch (v) {
            case 'link':
                var o = $('linkUrl').value.trim();
                if (o != "") editor.format("CreateLink", o);
                break;
            case 'image':
                var o = $('imageUrl').value.trim();
                if (o != "") editor.format("InsertImage", o);
                break;
            case 'table':
                var tableCell = $('tableCell');
                var tableRow = $('tableRow');
                var tableWidth = $('tableWidth');
                var r = /^[+-]?\d+(\.\d+)?$/;
                if (!r.test(tableCell.value)) {
                    $('tableCells').style.color = 'red';
                    return;
                } else {
                    $('tableCells').style.color = '#ccc';
                }
                if (!r.test(tableRow.value)) {
                    $('tableRows').style.color = 'red';
                    return;
                } else {
                    $('tableRows').style.color = '#ccc';
                }
                if (!r.test(tableWidth.value)) {
                    $('tableWidths').style.color = 'red';
                    return;
                } else {
                    $('tableWidths').style.color = '#ccc';
                }
                var s = editor.createTable(tableCell.value, tableRow.value, tableWidth.value);
                try {
                    editor.insertHTML(s);
                } catch (e) {
                    EasyMask.close();
                }
                break;
        }
        EasyMask.close();
    }, format: function(cmd, arg) {
        // 获取编辑区页面（嵌入帧iframe）
        var f = window.frames["HtmlEditor"];
        f.focus();
        // 带参数执行和不带参数两种方式
        if (arg) {
            f.document.execCommand(cmd, false, arg);
        } else {
            if (document.all) {
                f.document.execCommand(cmd)
            } else {
                f.document.execCommand(cmd, false, false);
            }
        }
    }, removeFormat: function() {
        editor.format("removeFormat");
    }, createTable: function(rows, cols, width) {
        var s = [];
        s.push('<table border="1" width="'); s.push(width); s.push('">');
        for (var r = 0; r < rows; r++) {
            s.push('<tr>');
            for (var c = 0; c < cols; c++)
                s.push('<td>&nbsp;</td>');
            s.push('</tr>');
        }
        s.push('</table>');
        return s.join('');
    }, insertHTML: function(html) {
        var f = window.frames["HtmlEditor"];
        f.focus();
        if (document.all) {
            f.document.selection.createRange().pasteHTML(html);
        } else {
            // Firefox的插入方式要复杂得多
            var selection = f.window.getSelection();
            var range;
            range = selection ? selection.getRangeAt(0) : editor.document.createRange();
            var fragment = f.document.createDocumentFragment();
            var div = f.document.createElement('div');
            div.innerHTML = html;
            while (div.firstChild)
                fragment.appendChild(div.firstChild);
            selection.removeAllRanges();
            range.deleteContents();
            var node = range.startContainer;
            var pos = range.startOffset;
            switch (node.nodeType) {
                case 3:
                    if (fragment.nodeType == 3) {
                        node.insertData(pos, fragment.data);
                        range.setEnd(node, pos + fragment.length);
                        range.setStart(node, pos + fragment.length);
                    } else {
                        node = node.splitText(pos);
                        node.parentNode.insertBefore(fragment, node);
                        range.setEnd(node, pos + fragment.length);
                        range.setStart(node, pos + fragment.length);
                    }
                    break;
                case 1:
                    node = node.childNodes[pos];
                    node.parentNode.insertBefore(fragment, node);
                    range.setEnd(node, pos + fragment.length);
                    range.setStart(node, pos + fragment.length);
                    break;
            }
            selection.addRange(range);
        }
    }, uploadImage: function(v) {
        EasyMask.close();
        editor.format("InsertImage", v);
    }
}