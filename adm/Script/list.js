
function Delete() {
    if (!isDeletePower) {alert('没有删除权限！');return false;};
    if ($('[name=chkItem]:checked').length == 0) { alert('请选择要删除的项'); return false; }
    return confirm('确定要删除选择的项吗？')
}
function DeleteOne(id) {
    $('[name=chkItem]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnDelete').click();
    return false;
}
$(function () {
    if (!isDeletePower) { $('#btnDelete').attr('disabled', 'disabled') };
    $('#btnDelete').click(function () { return Delete(); });
    $('#tablist tr.tr').hover(function () { $(this).addClass('highlight') }, function () { $(this).removeClass('highlight'); });
    $('#chkAll').click(function () { $('[name=chkItem]').attr('checked', $(this).attr('checked') ? true : false); });
})