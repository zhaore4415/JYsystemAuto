
function Delete() {
    if (!isDeletePower) { alert('没有删除权限！'); return false; };
    if ($('[name=chkItem]:checked').length == 0) { alert('请选择要删除的项'); return false; }
    if (!confirm('确定要删除选择的项吗？')) { return false; }
    return true;
}
function Deletefapiao() {

    if ($('[name=chkItemfapiao]:checked').length == 0) { alert('请选择要删除的项'); return false; }
    if (!confirm('确定要删除选择的项吗？')) { return false; }
    return true;
}
function Deleteshouju() {

    if ($('[name=chkItemshouju]:checked').length == 0) { alert('请选择要删除的项'); return false; }
    if (!confirm('确定要删除选择的项吗？')) { return false; }
    return true;
}
function Deletewaichuzhen() {

    if ($('[name=chkItemwaichuzhen]:checked').length == 0) { alert('请选择要删除的项'); return false; }
    if (!confirm('确定要删除选择的项吗？')) { return false; }
    return true;
}
function Deletebank() {

    if ($('[name=chkItembank]:checked').length == 0) { alert('请选择要删除的项'); return false; }
    if (!confirm('确定要删除选择的项吗？')) { return false; }
    return true;
}
function Recovery() {
    if (!isRecoveryPower) { alert('没有删除权限！'); return false; };
    if ($('[name=chkItem]:checked').length == 0) { alert('请选择要恢复的项'); return false; }
    if (!confirm('确定要恢复选择的项吗？')) { return false; }
    return true;
}
function Export() {
    if (!isExportPower) { alert('没有删除权限！'); return false; };
    if ($('[name=chkItem]:checked').length == 0) { alert('请选择要恢复的项'); return false; }
    if (!confirm('确定要导出选择的项吗？')) { return false; }
    return true;
}
function DeleteOne(id) {
    $('[name=chkItem]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnDelete').click();
    return false;
}
function DeleteOnefapiao(id) {
    $('[name=chkItemfapiao]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnFaPiaoDelete').click();
    return false;
}
function DeleteOneshouju(id) {
    $('[name=chkItemshouju]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnShouJuDelete').click();
    return false;
}
function DeleteOnewaichuzhen(id) {
    $('[name=chkItemwaichuzhen]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnWaiChuZhenDelete').click();
    return false;
}
function DeleteOnebank(id) {
    $('[name=chkItembank]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnBankDelete').click();
    return false;
}
function RecoveryOne(id) {
    $('[name=chkItem]').attr('checked', false).end().find('[value=' + id + ']').attr('checked', true);
    $('#btnRecovery').click();
    return false;
}
$(function () {
    if (!isDeletePower) { $('#btnDelete').attr('disabled', 'disabled') };
    if (!isRecoveryPower) { $('#btnRecovery').attr('disabled', 'disabled') };
    if (!isExportPower) { $('#btnExport').attr('disabled', 'disabled') };
    $('#btnDelete').click(function () { return Delete(); });
    $('#btnFaPiaoDelete').click(function () { return Deletefapiao(); });
    $('#btnShouJuDelete').click(function () { return Deleteshouju(); });
    $('#btnWaiChuZhenDelete').click(function () { return Deletewaichuzhen(); });
    $('#btnBankDelete').click(function () { return Deletebank(); });
    $('#btnRecovery').click(function () { return Recovery(); });
    $('#btnExport').click(function () { return Export(); });
    $('#tablist tr.tr').hover(function () { $(this).addClass('highlight') }, function () { $(this).removeClass('highlight'); });
    $('#chkAll').click(function () { $('[name=chkItem]').attr('checked', $(this).attr('checked') ? true : false); });
    $('#chkAllfapiao').click(function () { $('[name=chkItemfapiao]').attr('checked', $(this).attr('checked') ? true : false); });
    $('#chkAllshouju').click(function () { $('[name=chkItemshouju]').attr('checked', $(this).attr('checked') ? true : false); });
    $('#chkAllwaichuzhen').click(function () { $('[name=chkItemwaichuzhen]').attr('checked', $(this).attr('checked') ? true : false); });
    $('#chkAllbank').click(function () { $('[name=chkItembank]').attr('checked', $(this).attr('checked') ? true : false); });
    $('#chkAll_b').click(function () { $('#chkAll,[name=chkItem]').attr('checked', true); });
    $('#chkUnchk').click(function () { $('#chkAll,[name=chkItem]').attr('checked', false); });
})