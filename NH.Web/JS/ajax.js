// JScript 文件
var Http =
{
    XMLHttpRequest: function () {
        try {
            var oRequest = new XMLHttpRequest();
            return oRequest;
        } catch (ex) {
            var arrSignatures = ["MSXML2.XMLHTTP.5.0", "MSXML2.XMLHTTP.4.0",
                                     "MSXML2.XMLHTTP.3.0", "MSXML2.XMLHTTP",
                                     "Microsoft.XMLHTTP"];

            for (var i = 0; i < arrSignatures.length; i++) {
                try {

                    var oRequest = new ActiveXObject(arrSignatures[i]);

                    return oRequest;

                } catch (oError) {
                    //ignore
                }
            }
        }
        throw new Error("MSXML is not installed on your system.");
    },

    Get: function (sURL, fnCallback, fnLoading) {
        var oRequest = new Http.XMLHttpRequest();
        oRequest.open("get", sURL, true);
        oRequest.onreadystatechange = function () {
            if (oRequest.readyState == 4) {
                if (fnCallback) fnCallback(oRequest.responseText);
            } else if (fnLoading)  //call loading function...
            {
                if (fnLoading) fnLoading();
            }
        }
        oRequest.send(null);

    }
}
    
 
