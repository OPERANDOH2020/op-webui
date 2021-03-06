var TableDatatablesManaged = function () {

    var initTable1 = function () {

        var table = $('#data_access_log');

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
                    "previous":"Prev",
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
            //"dom": '<lf<t>ip>',
            

            "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "pageLength": 5,            
            "pagingType": "bootstrap_full_number",
            "columnDefs": [
                //{  
                //    'orderable': true,
                //    'targets': [0]
                //},
                //{  // set default column settings
                //    'orderable': false,
                //    'targets': [4]
                //},
                //{
                //    "searchable": true,
                //    "targets": [0]
                //},
                {
                    "type": "date",
                    "targets": [1]
                },
                {
                    
                    "className": "dt-center", 
                    "targets": [0]
                },
                {
                    "searchable": false,
                    'orderable': false,
                    "className": "dt-center",
                    "targets": [5]
                }
            ],
            "order": [
                [1, "desc"]
            ] // set first column as a default sort by asc
        });

        var tableWrapper = jQuery('#data_access_log_wrapper');
    }

    var initTable2 = function () {

        var table = $('#notifications_list');

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
            //"dom": '<lf<t>ip>',


            "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "pageLength": 5,
            "pagingType": "bootstrap_full_number",
            "columnDefs": [
                //{  
                //    'orderable': true,
                //    'targets': [0]
                //},
                //{  // set default column settings
                //    'orderable': false,
                //    'targets': [4]
                //},
                //{
                //    "searchable": true,
                //    "targets": [0]
                //},
                {
                    "type": "date",
                    "targets": [2]
                },
                {

                    "className": "dt-center",
                    "targets": [0]
                //},
                //{
                //    "searchable": false,
                //    'orderable': false,
                //    "className": "dt-center",
                //    "targets": [5]
                }
            ],
            "order": [
                [2, "desc"]
            ] // set first column as a default sort by asc
        });

        var tableWrapper = jQuery('#notifications_list_wrapper');
    }


    return {

        //main function to initiate the module
        init: function () {
            if (!jQuery().dataTable) {
                return;
            }

            initTable1();
            initTable2();
        }

    };

}();

if (App.isAngularJsApp() === false) { 
    jQuery(document).ready(function() {
        TableDatatablesManaged.init();
    });
}