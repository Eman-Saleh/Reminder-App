
function showSuccessToast(message, optionaltimeOut) {
    //optionaltimeOut = optionaltimeOut || 2000;
    var optionaltimeOut = typeof optionaltimeOut !== 'undefined' ? optionaltimeOut : 3000;
    toastr.options.timeOut = optionaltimeOut;
    toastr.options.fadeOut = optionaltimeOut;
    toastr.options.positionClass = 'toast-top-center';
    toastr.options.closeHtml='<button type="button">&times;</button>',
    toastr.success(message);   
}

function showWarningToast(message, optionaltimeOut) {
    var optionaltimeOut = typeof optionaltimeOut !== 'undefined' ? optionaltimeOut : 3000;
    toastr.options.timeOut = optionaltimeOut;
    toastr.options.fadeOut = optionaltimeOut;
    toastr.options.positionClass = 'toast-top-center'
    toastr.warning(message);
  
}

function showInfoToast(message, optionaltimeOut) {
    var optionaltimeOut = typeof optionaltimeOut !== 'undefined' ? optionaltimeOut : 3000;
    toastr.options.timeOut = optionaltimeOut;
    toastr.options.fadeOut = optionaltimeOut;
    toastr.options.positionClass = 'toast-top-center'
    toastr.info(message);

}

function showErrorToast(message, optionaltimeOut) {
    //optionaltimeOut = optionaltimeOut || 3000;
    var optionaltimeOut = typeof optionaltimeOut !== 'undefined' ? optionaltimeOut : 3000;
    toastr.options.timeOut = optionaltimeOut;
    toastr.options.fadeOut = optionaltimeOut;
    toastr.options.positionClass = 'toast-top-center'
    toastr.error(message);    
}