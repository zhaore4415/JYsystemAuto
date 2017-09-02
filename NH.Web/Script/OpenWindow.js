function openwindowa(headurl, url, name, iWidth, iHeight) {

    var Rates1 = $('#txtRates1').val();
    var Rates2 = $('#txtRates2').val();
    var Rates3 = $('#txtRates3').val();
    var Rates4 = $('#txtRates4').val();
    var Rates5 = $('#txtRates5').val();
    var Rates6 = $('#txtRates6').val();
    var Rates7 = $('#txtRates7').val();

    var url = 'Rates1=' + Rates1 + '&Rates2=' + Rates2 + '&Rates3=' + Rates3 + '&Rates4=' + Rates4 + '&Rates5=' + Rates5 + '&Rates6=' + Rates6;

    var name;                           //网页名称，可为空;
    var iWidth;                          //弹出窗口的宽度;
    var iHeight;                        //弹出窗口的高度;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
    window.open(headurl + url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
}

function openwindow(url, name, iWidth, iHeight) {
    var url;                                 //转向网页的地址;
    var name;                           //网页名称，可为空;
    var iWidth;                          //弹出窗口的宽度;
    var iHeight;                        //弹出窗口的高度;
    var iTop = (window.screen.availHeight - 30 - iHeight) / 2;       //获得窗口的垂直位置;
    var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;           //获得窗口的水平位置;
    window.open(url, name, 'height=' + iHeight + ',,innerHeight=' + iHeight + ',width=' + iWidth + ',innerWidth=' + iWidth + ',top=' + iTop + ',left=' + iLeft + ',toolbar=no,menubar=no,scrollbars=auto,resizeable=no,location=no,status=no');
}