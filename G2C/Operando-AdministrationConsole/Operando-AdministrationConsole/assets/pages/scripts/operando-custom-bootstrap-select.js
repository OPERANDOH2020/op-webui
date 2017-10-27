var ComponentsBootstrapSelect = function () {

    var handleBootstrapSelect = function() {
        $('.bs-select').selectpicker({
            iconBase: 'fa',
            tickIcon: 'fa-check',
            actionsBox: true
        });
    }

    return {
        //main function to initiate the module
        init: function () {      
            handleBootstrapSelect();
        }
    };

}();






if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {
        ComponentsBootstrapSelect.init();

        filterLogs();

        $("#user-log-type-select").change(function () {
            filterLogs();
        });

    });

function filterLogs() {
    // opt[] is the array containing the list of selected options
    var opt = [];
    $('#user-log-type-select :selected').each(function (i, selected) {
        opt[i] = $(selected).text();
    });

    var showAllowedLogs = false;
    var showDeniedLogs = false;

    $.each(opt, function (i, value) {
        if (opt[i] === "Allowed") {
            showAllowedLogs = true;
        }
        if (opt[i] === "Denied") {
            showDeniedLogs = true;
        }
    });

    // rows may have both classes, so should be visible if either is selected
    $('tr.granted').removeClass('visible').addClass('hidden');
    $('tr.denied').removeClass('visible').addClass('hidden');

    if (showAllowedLogs) {
        $('tr.granted').addClass('visible').removeClass('hidden');
    }

    if (showDeniedLogs) {
        $('tr.denied').addClass('visible').removeClass('hidden');
    }
}

}