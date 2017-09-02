var EasyMask = {
    init: function() {
        var $ = function(v) { return document.getElementById(v); };
        var k = function(i, v) { return $(i) ? $(i) : v ? document.createElement("div") : document.createElement("iframe"); };
        var a = arguments.length ? arguments[0] : new Object;
        var h = window.innerHeight || self.innerHeight || (document.documentElement && document.documentElement.clientHeight && document.documentElement.offsetHeight) || document.body.clientHeight;
        var w = window.innerWidth || self.innerWidth || (document.documentElement && document.documentElement.clientWidth && document.documentElement.offsetWidth) || document.body.clientWidth;
        var t = document.documentElement.scrollTop;
        var l = document.documentElement.scrollLeft;
        var o = a.opacity ? a.opacity : 5;
        var m = a.molor ? a.molor : 'black';
        var e = a.width ? a.width < 300 ? 300 : a.width : 300;
        var f = a.height ? a.height < 140 ? 140 : a.height : 140;
        var b = a.bgcolor ? a.bgcolor : "#7D0000";
        var c = k("resourceMasks", true);
        var z = k("resourceContents", true);
        //var s = k("resourceHideSelect", false);
        var g = k("resourceShadows", true);
        var top = (h - f) / 2 + t;
        var left = (w - e) / 2;
        c.id = "resourceMasks";
        c.onclick = EasyMask.close;
        c.style.cssText = "position:absolute;left:0;top:" + t + "px;width:" + w + "px;height:" + h + "px;background:" + m + ";z-index:999998;filter:alpha(opacity=" + o + "0);opacity:0." + o + ";";
        z.id = "resourceContents";
        z.style.cssText = 'background:#fff;border:1px solid ' + b + ';z-index:999999;position:absolute;width:' + e + 'px;height:' + f + 'px;top:' + top + 'px;left:' + left + 'px;';
        var i = '<div style="height:25px;background:' + b + ';color:#fff;font:bold 12px/25px Arial;text-indent:6px;overflow:hidden;padding-right:8px;position:relative;">' + (a.title ? a.title : "") + '<span style="position:absolute;right:0;top:0px;cursor:pointer;padding:0 6px 0 3px;" onmouseover="this.style.color=\'red\';" onmouseout="this.style.color=\'#fff\';" title="关闭" onclick="EasyMask.close()">X</span></div>';
        i += '<div style="padding:6px;position:relative;">' + (a.detail ? a.detail : "") + '</div>';
        z.innerHTML = i;
        //s.id = "resourceHideSelect";
        //s.style.cssText = "height:" + h + "px;width:" + w + "px;z-index:999997;position:absolute;top:0;left:0;background:#fff;border:0;filter:alpha(opacity=0);opacity:0;";
        g.id = "resourceShadows";
        g.style.cssText = 'background:#000;z-index:999996;position:absolute;width:' + e + 'px;height:' + f + 'px;top:' + (top + 6) + 'px;left:' + (left + 6) + 'px;filter:alpha(opacity=30);opacity:0.3;';
        EasyMask.app(c)(z)(g);
    },
    close: function() {
        EasyMask.del('resourceMasks', 'resourceContents', 'resourceHideSelect', 'resourceShadows');
    },
    app: function(v) {
        document.body.appendChild(v);
        return EasyMask.app;
    },
    del: function() {
        for (var i = 0; i < arguments.length; i++) {
            var id = document.getElementById(arguments[i]);
            id && id.parentNode.removeChild(id);
        }
    }
}