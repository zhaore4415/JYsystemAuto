function Search() {
    var url = $("#form1").attr("action");
    var searchform = $(document.createElement("form"));
    searchform.attr({ "id": "searchform", "name": "searchform", "action": url });
    $('.searchkey').each(function () {
        searchform.append('<input type="hidden" name="' + $(this).attr('name') + '" value="' + $(this).val() + '" />');
    });
    searchform.appendTo($('body'));
    searchform.submit();
}