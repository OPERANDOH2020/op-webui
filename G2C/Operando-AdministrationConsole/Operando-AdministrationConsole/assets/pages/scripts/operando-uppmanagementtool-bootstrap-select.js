var UppManagementToolBootstrapSelect = function () {

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


function setTrovato(idTabella, opt) {
    $('#' + idTabella + ' > tbody  > tr').each(function () {
        var trovato = false;
        if (this.attributes['ID'] == undefined) // aggiungere in tutti i bootstrap select per gestire quando non c'è l'attributo "ID"
            return;
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

function setSelect(idSelect, idTabella, opt) {
    $("#" + idSelect).change(function () {
        var opt = [];
        $('#' + idSelect + ' :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

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

    });
}


if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {

        UppManagementToolBootstrapSelect.init();

        //report tab

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#UppManagementTool-type-select1 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });
        $('#UppManagementTool-type-select2 :selected').each(function (i, selected) { opt[i] = $(selected).text(); });

        setTrovato('UppManagementTool1_psp', opt);
        setTrovato('UppManagementTool2_psp', opt);

        setSelect('UppManagementTool-type-select1', 'UppManagementTool1_psp', opt);
        setSelect('UppManagementTool-type-select1', 'UppManagementTool2_psp', opt);


    });
}


