function showLoading() {
    if (typeof $('#divLoading') != 'undefined' && $('#divLoading').length > 0) {
        $('#divLoading').css("display", "block");
    }
}

function hideLoading() {
    if (typeof $('#divLoading') != 'undefined' && $('#divLoading').length > 0) {
        $('#divLoading').css("display", "none");
    }
}
