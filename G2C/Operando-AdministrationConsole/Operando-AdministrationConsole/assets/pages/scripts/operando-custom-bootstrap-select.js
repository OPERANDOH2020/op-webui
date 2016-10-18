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

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#user-log-type-select :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        var allowed = false;
        var denied = false;
        
        $.each(opt, function (i, value) {
            if (opt[i] == "Allowed")
                allowed = true;
            if (opt[i] == "Denied")
                denied == true;
        });

        if (allowed) {
            $('tr.INFO').addClass('visible').removeClass('hidden');
        }
        else $('tr.INFO').removeClass('visible').addClass('hidden');

        if (denied) {
            $('tr.WARN').addClass('visible').removeClass('hidden');
        }
        else $('tr.WARN').removeClass('visible').addClass('hidden');

        // on changing selected options recharge opt[]
        $("#user-log-type-select").change(function () {
            var opt = [];
            $('#user-log-type-select :selected').each(function (i, selected) {
                opt[i] = $(selected).text();
            });

            allowed = false;
            denied = false;

            $.each(opt, function (i, value) {
                if (opt[i] == "Allowed")
                    allowed = true;
                if (opt[i] == "Denied")
                    denied == true;
            });

            if (allowed) {
                $('tr.INFO').addClass('visible').removeClass('hidden');
            }
            else $('tr.INFO').removeClass('visible').addClass('hidden');

            if (denied) {
                $('tr.WARN').addClass('visible').removeClass('hidden');
            }
            else $('tr.WARN').removeClass('visible').addClass('hidden');

        });

    });
}