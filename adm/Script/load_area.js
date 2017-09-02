function LoadArea(objProvinceID, objCityID, objAreaID, proviceID, cityID, areaID) {
    LoadSubArea(0, objProvinceID, proviceID); //加载省
    var objProvince = $('#' + objProvinceID);
    var objCity = $('#' + objCityID);
    var objArea = $('#' + objAreaID);
    objProvince.change(function () {
        if (!objCityID) return;
        objCity.find('option[value!=0]').remove();
        objArea.find('option[value!=0]').remove();
        var val = $(this).val();
        if (val != '0' && objCityID) {
            LoadSubArea(val, objCityID, cityID); //加载市        
        }
    }).change();

    objCity.change(function () {
        if (!objAreaID) return;
        objArea.find('option[value!=0]').remove();
        var val = $(this).val();
        if (val != '0') {
            LoadSubArea(objCity.val(), objAreaID, areaID); //加载区        
        }
    }).change();

    function LoadSubArea(parentValue, subObjID, subValue) {
        $.ajax({
            url: '/Common/Ajax.ashx?action=GetSubAreaOpts&pid=' + parentValue + "&sid=" + subValue,
            cache: true,
            async: false,
            success: function (data) {
                var obj = $('#' + subObjID);
                obj.append(data);
            }
        })
    }
}
