jQuery(document).ready(function () {
    var index = 0;
    while (true) {
        index++;
        var id = `ComplianceReports${index}_psp`;
        if (document.getElementById(id) == null) {
            break;
        } else {
            var jId = `#${id}`;
            var url = $(jId).attr("ajaxurl");
            $(jId).load(url);
        }
    }
});