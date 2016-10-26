var ComponentsBootstrapSelect = function () {

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
        ComponentsBootstrapSelect.init();

        //report tab

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#report-ospsoption-select :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        $('#reports_psp > tbody  > tr').each(function () {
            var trovato = false;
            var ID = this.attributes['ID'].value.toString();
            $.each(opt, function (r, value) {
                if (ID.indexOf(opt[r]) >= 0)
                {
                    trovato = true;
                }
            });
            if (trovato)
            {
                this.classList.add('visible');
                this.classList.remove('hidden');
            }
            else {
                this.classList.add('hidden');
                this.classList.remove('visible');
            }
            
        });


        // on changing selected options recharge opt[]
        $("#report-ospsoption-select").change(function () {
            var opt = [];
            $('#report-ospsoption-select :selected').each(function (i, selected) {
                opt[i] = $(selected).text();
            });

            $('#reports_psp > tbody  > tr').each(function () {
                var trovato = false;
                var ID = this.attributes['ID'].value.toString();
                $.each(opt, function (r, value) {
                    if (ID.indexOf(opt[r]) >= 0)
                    {
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


        //results tab

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#result-ospsoption-select :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        $('#reports_results_psp > tbody  > tr').each(function () {
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
        $("#result-ospsoption-select").change(function () {
            var opt = [];
            $('#result-ospsoption-select :selected').each(function (i, selected) {
                opt[i] = $(selected).text();
            });

            $('#reports_results_psp > tbody  > tr').each(function () {
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

        //schedule tab

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#schedule-ospsoption-select :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        $('#schedule_report_psp > tbody  > tr').each(function () {
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
        $("#schedule-ospsoption-select").change(function () {
            var opt = [];
            $('#schedule-ospsoption-select :selected').each(function (i, selected) {
                opt[i] = $(selected).text();
            });

            $('#schedule_report_psp > tbody  > tr').each(function () {
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

        // ddl report in schedule

        // opt[] is the array containing the list of selected options
        var opt = [];
        $('#report_scheduleList :selected').each(function (i, selected) {
            opt[i] = $(selected).text();
        });

        $('#schedule_report > tbody  > tr').each(function () {
            var trovato = false;
            var ID = this.attributes['ID'].value.toString();
            $.each(opt, function (r, value) {
                if (ID.indexOf(opt[r].replace("'", "_").replace(" ", "_")) >= 0) {
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
        $("#report_scheduleList").change(function () {
            var opt = [];
            $('#report_scheduleList :selected').each(function (i, selected) {
                opt[i] = $(selected).text();
            });

            $('#schedule_report > tbody  > tr').each(function () {
                var trovato = false;
                var ID = this.attributes['ID'].value.toString();
                $.each(opt, function (r, value) {
                    if (ID.indexOf(opt[r].replace("'", "_").replace(" ", "_")) >= 0) {
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


