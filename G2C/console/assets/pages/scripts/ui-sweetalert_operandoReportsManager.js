function reloadSweetAlert(myObject) {
    $('.mt-sweetalert').each(function () {
        var sa_title = myObject.attr('data-title');
        var sa_message = myObject.attr('data-message');
        var sa_type = myObject.attr('data-type');
        var sa_allowOutsideClick = myObject.attr('data-allow-outside-click');
        var sa_showConfirmButton = myObject.attr('data-show-confirm-button');
        var sa_showCancelButton = myObject.attr('data-show-cancel-button');
        var sa_closeOnConfirm = myObject.attr('data-close-on-confirm');
        var sa_closeOnCancel = myObject.attr('data-close-on-cancel');
        var sa_confirmButtonText = myObject.attr('data-confirm-button-text');
        var sa_cancelButtonText = myObject.attr('data-cancel-button-text');
        var sa_popupTitleSuccess = myObject.attr('data-popup-title-success');
        var sa_popupMessageSuccess = myObject.attr('data-popup-message-success');
        var sa_popupTitleCancel = myObject.attr('data-popup-title-cancel');
        var sa_popupMessageCancel = myObject.attr('data-popup-message-cancel');
        var sa_confirmButtonClass = myObject.attr('data-confirm-button-class');
        var sa_cancelButtonClass = myObject.attr('data-cancel-button-class');
        var sa_dataId = myObject.attr('data-id');

        myObject.click(function () {
            //console.log(sa_btnClass);
            swal({
                title: sa_title,
                text: sa_message,
                type: sa_type,
                allowOutsideClick: sa_allowOutsideClick,
                showConfirmButton: sa_showConfirmButton,
                showCancelButton: sa_showCancelButton,
                confirmButtonClass: sa_confirmButtonClass,
                cancelButtonClass: sa_cancelButtonClass,
                closeOnConfirm: sa_closeOnConfirm,
                closeOnCancel: sa_closeOnCancel,
                confirmButtonText: sa_confirmButtonText,
                cancelButtonText: sa_cancelButtonText,
            },
            function (isConfirm) {
                if (isConfirm) {
                    swal(sa_popupTitleSuccess, sa_popupMessageSuccess, "success");
                    window.location.reload();
                } else {
                    swal(sa_popupTitleCancel, sa_popupMessageCancel, "error");
                }
            });
        });
    });

}


var SweetAlert = function () {

    return {
        //main function to initiate the module
        init: function () {
        	$('.mt-sweetalert').each(function(){
        		var sa_title = $(this).data('title');
        		var sa_message = $(this).data('message');
        		var sa_type = $(this).data('type');	
        		var sa_allowOutsideClick = $(this).data('allow-outside-click');
        		var sa_showConfirmButton = $(this).data('show-confirm-button');
        		var sa_showCancelButton = $(this).data('show-cancel-button');
        		var sa_closeOnConfirm = $(this).data('close-on-confirm');
        		var sa_closeOnCancel = $(this).data('close-on-cancel');
        		var sa_confirmButtonText = $(this).data('confirm-button-text');
        		var sa_cancelButtonText = $(this).data('cancel-button-text');
        		var sa_popupTitleSuccess = $(this).data('popup-title-success');
        		var sa_popupMessageSuccess = $(this).data('popup-message-success');
        		var sa_popupTitleCancel = $(this).data('popup-title-cancel');
        		var sa_popupMessageCancel = $(this).data('popup-message-cancel');
        		var sa_confirmButtonClass = $(this).data('confirm-button-class');
        		var sa_cancelButtonClass = $(this).data('cancel-button-class');
        	
        		$(this).click(function(){
        			//console.log(sa_btnClass);
        			swal({
					  title: sa_title,
					  text: sa_message,
					  type: sa_type,
					  allowOutsideClick: sa_allowOutsideClick,
					  showConfirmButton: sa_showConfirmButton,
					  showCancelButton: sa_showCancelButton,
					  confirmButtonClass: sa_confirmButtonClass,
					  cancelButtonClass: sa_cancelButtonClass,
					  closeOnConfirm: sa_closeOnConfirm,
					  closeOnCancel: sa_closeOnCancel,
					  confirmButtonText: sa_confirmButtonText,
					  cancelButtonText: sa_cancelButtonText,
					},
					function(isConfirm){
				        if (isConfirm){
				            swal(sa_popupTitleSuccess, sa_popupMessageSuccess, "success");
				            window.location.reload();
				        } else {
							swal(sa_popupTitleCancel, sa_popupMessageCancel, "error");
				        }
					});
        		});
        	});    

    	}
    }

}();

jQuery(document).ready(function() {
    SweetAlert.init();
});
