var ComplianceReportsBootstrapSelect = function () {

    var handleBootstrapSelect = function (id) {
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
        $('#compliance-report-type-select1 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });
        $('#compliance-report-type-select2 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });
        $('#compliance-report-type-select3 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });
        $('#compliance-report-type-select4 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });
        $('#compliance-report-type-select5 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });

        setTrovato('ComplianceReports1_psp', opt);
        setTrovato('ComplianceReports2_psp', opt);
        setTrovato('ComplianceReports3_psp', opt);
        setTrovato('ComplianceReports4_psp', opt);
        setTrovato('ComplianceReports5_psp', opt);

        setSelect('compliance-report-type-select1', 'ComplianceReports1_psp', opt);
        setSelect('compliance-report-type-select2', 'ComplianceReports2_psp', opt);
        setSelect('compliance-report-type-select3', 'ComplianceReports3_psp', opt);
        setSelect('compliance-report-type-select4', 'ComplianceReports4_psp', opt);
        setSelect('compliance-report-type-select5', 'ComplianceReports5_psp', opt);

      });
}



