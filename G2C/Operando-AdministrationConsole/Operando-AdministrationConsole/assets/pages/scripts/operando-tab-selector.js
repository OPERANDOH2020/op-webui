function showTabHideOthers(prefix, tabNumber) {
    $('div[id^=' + prefix + ']').hide();
    $('#' + prefix + tabNumber).show();
}