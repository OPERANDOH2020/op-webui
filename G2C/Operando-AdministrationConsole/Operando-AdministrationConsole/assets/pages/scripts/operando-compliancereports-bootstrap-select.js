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

function setTrovato(idTabella, opt)
{
    $('#' + idTabella + ' > tbody  > tr').each(function () {
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

}

function setSelect(idSelect, idTabella, opt)
{
    $("#"+idSelect).change(function () {
        var opt = [];
        $('#'+idSelect+' :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        $('#'+idTabella+' > tbody  > tr').each(function () {
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
}

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {

        ComplianceReportsBootstrapSelect.init();

        //report tab

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#compliance-report-type-select :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        setTrovato('ComplianceReports_psp', opt);
        setTrovato('ComplianceReports_psp2', opt);

        /*$('#ComplianceReports_psp > tbody  > tr').each(function () {
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

        });*/

        setSelect('compliance-report-type-select', 'ComplianceReports_psp', opt);
        setSelect('compliance-report-type-select2', 'ComplianceReports_psp2', opt);

        // on changing selected options recharge opt[]
        /*$("#compliance-report-type-select").change(function () {
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

        });*/

    });
}



