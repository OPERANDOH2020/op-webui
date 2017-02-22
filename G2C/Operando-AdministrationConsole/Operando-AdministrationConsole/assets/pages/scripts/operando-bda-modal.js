+function () {
    "use strict";

    var spinnerTemplate = '<i class="fa fa-spinner fa-spin" aria-hidden="true"></i>';

    var createAjaxModals = function() {
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
                    FormInputMask.init();
                    ComponentsBootstrapSelect.init();
                    $target.modal();
                });
            });
        });
    };

    $(createAjaxModals);
}();