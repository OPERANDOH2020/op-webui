var ComplianceReportsBootstrapSelect = function () {

    var handleBootstrapSelect = function () {
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

        ComplianceReportsBootstrapSelect.init();

        //report tab

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#compliance-report-type-select :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        $('#ComplianceReports_psp > tbody  > tr').each(function () {
            var trovato = false;
            var ID = this.attributes['ID'].value.toString();
            $.each(opt, function (r, value) {
                if (ID.indexOf(opt[r]) >= 0) {
                    trovato = true;
                }
            });
            if (trovato) {
                this.classList.add('visible');
                this.classList.remove('hidden');
            }
            else {
                this.classList.add('hidden');
                this.classList.remove('visible');
            }

        });

        // on changing selected options recharge opt[]
        $("#compliance-report-type-select").change(function () {
            var opt = [];
            $('#compliance-report-type-select :selected').each(function (i, selected) {
                opt[i] = $(selected).text();
            });

            $('#ComplianceReports_psp > tbody  > tr').each(function () {
                var trovato = false;
                var ID = this.attributes['ID'].value.toString();
                $.each(opt, function (r, value) {
                    if (ID.indexOf(opt[r]) >= 0) {
                        trovato = true;
                    }
                });
                if (trovato) {
                    this.classList.add('visible');
                    this.classList.remove('hidden');
                }
                else {
                    this.classList.add('hidden');
                    this.classList.remove('visible');
                }

            });

        });

    });
}



