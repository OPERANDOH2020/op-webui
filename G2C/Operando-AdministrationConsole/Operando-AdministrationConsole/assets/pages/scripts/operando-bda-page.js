+function () {
    "use strict";

    var spinnerTemplate = '<i class="fa fa-spinner fa-spin" aria-hidden="true"></i>';

    var bindAjaxModals = function() {
        $("[data-toggle='modal-ajax']").each(function (idx, element) {
            var $element = $(element),
                url = $element.data("source"),
                $target = $("<div class='modal fade' tabindex='-1' aria-hidden='true'></div>");

            $("body").append($target);

            var applySpinnerToElement = function() {
                var originalHtml = $element.html();
                $element.html(spinnerTemplate);
                $target.unbind('show.bs.modal');
                $target.on('show.bs.modal', function () {
                    $element.html(originalHtml);
                })
            };

            $element.click(function () {
                applySpinnerToElement();
                
                $target.load(url, function () {
                    ComponentsBootstrapSelect.init();
                    $target.modal();
                });
            });
        });
    };

    var bindViewSchedules = function () {
        $("[data-toggle='tab-then-show-row']").click(function (e) {
            e.preventDefault();

            var $element = $(this),
                tab_id = $element.data("tab-id"),
                row_id = $element.data("row-id"),
                $tab = $('[data-toggle="tab"][href="' + tab_id + '"]'),
                $row = $(row_id);

            $tab.tab('show')
            $row.collapse('show');
        });
    };

    $(bindAjaxModals);
    $(bindViewSchedules);
}();