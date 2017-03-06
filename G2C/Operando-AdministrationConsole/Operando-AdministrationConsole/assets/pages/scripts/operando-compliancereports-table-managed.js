var ComplianceReportsTables = function () {

    var initTable = function (jId) {
        var table = $(jId);

        // begin first table
        table.dataTable({
            // Internationalisation. For more info refer to http://datatables.net/manual/i18n
            "language": {
                "aria": {
                    "sortAscending": ": activate to sort column ascending",
                    "sortDescending": ": activate to sort column descending"
                },
                "emptyTable": "No data available in table",
                "info": "Showing _START_ to _END_ of _TOTAL_ records",
                "infoEmpty": "No records found",
                "infoFiltered": "(filtered1 from _MAX_ total records)",
                "lengthMenu": "Show _MENU_",
                "search": "Search:",
                "zeroRecords": "No matching records found",
                "paginate": {
                    "previous": "Prev",
                    "next": "Next",
                    "last": "Last",
                    "first": "First"
                }
            },

            // Or you can use remote translation file
            //"language": {
            //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
            //},

            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

            "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.

            "responsive": true,

            /* Results in:
                <div>
                  {length}
                  {filter}
                  <div>
                    {table}
                  </div>
                  {information}
                  {pagination}
                </div>
            */
            "dom": '<lf<t>ip>',


            "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "pageLength": 5,
            "pagingType": "bootstrap_full_number",
            "columnDefs": [
                {  // set default column settings
                    'orderable': true,
                    'targets': [0]
                },
                {  // set default column settings
                    'orderable': false,
                    'targets': [3]
                },
                {
                    "searchable": true,
                    "targets": [0]
                },
                {
                    "searchable": false,
                    "targets": [3]
                },
                {
                    "className": "dt-right",
                    //"targets": [2]
                },
                {
                    "type": "string",
                    "targets": [0]
                }
            ],
            "order": [
                [0, "desc"]
            ] // set first column as a default sort by asc
        });

        //var tableWrapper = jQuery('#reports_osp_wrapper');
    }

    var loadTable = function(jId, url) {
        $(jId)
            .load(url,
                function() {
                    initTable(jId);
                });
    }

    // -------------------------------------------------------------------

    return {

        //main function to initiate the module
        init: function () {
            if (!jQuery().dataTable) {
                return;
            }

            jQuery(document).ready(function () {
                var index = 0;
                while (true) {
                    // table is 1 indexed
                    index++;
                    var id = `ComplianceReports${index}_psp`;
                    if (document.getElementById(id) == null) {
                        // this and subsequent tables do not exist
                        break;
                    } else {
                        var jId = `#${id}`;
                        var url = $(jId).attr("ajaxurl");
                        loadTable(jId, url);
                    }
                }
            });
        }

    };

}();

if (App.isAngularJsApp() === false) {
    jQuery(document).ready(function () {
        ComplianceReportsTables.init();
    });
}