function ShowpopupEditpackageCoin(packageID, coinID, packageValue)
{
    $('#hdPackageID').val(packageID);
    $('#hdCoinID').va(coinID);
    $('#cbPackage option[value=' + packageID + ']').attr('selected', true);
    $('#cbPackage').trigger('chosen:updated')
    //$('#cbCoin option[value' + coinID + ']').attr('selected', true);
    //$('#cbCoin').trigger('chosen:updated')
    $('#txtPackageValue').val(packageValue);

    setTimeout(function () {
        $('#cbPackage').chosen({
            width: '200px'
        });
    }, 500);
    //setTimeout(function () {
    //    $('#cbCoin').chosen({
    //        width: '200px'
    //    });
    //}, 500);
}

//function ConfirmPackageCoin(packageID, isDelete) {
//    var textMessage = '';
//    textMessage = 'Are you sure delete this package?';
  
//    var confirmMessage = confirm(textMessage);
//    if (!confirmMessage) {
//        return false;
//    }
//    else {
//        $('#imgLoading_' + packageID).css("display", "");
//        $.ajax({
//            type: "post",
//            async: false,
//            url: "/Package/UpdateIsDeletePackage",
//            data: { packageID: packageID, isDelete: isDelete },
//            beforeSend: function () {
//                $('#imgLoading_' + packageID).css("display", "");
//            },
//            success: function (d) {
//                $('#imgLoading_' + packageID).css("display", "none");
//                if (d == 'success') {
//                    noty({ text: "Update Success", layout: "bottomRight", type: "information" });

//                    setTimeout(function () { window.location.reload(); }, 2000);
//                }
//                else {

//                    noty({ text: "Update Error. Please contact admin", layout: "bottomRight", type: "error" });
//                }
//            },
//            error: function (e) {

//            }
//        });
//    }
//}
