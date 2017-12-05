function ShowpopupEditpackageCoin(packageID, coinID, packageValue)
{
    var hdPackageID = packageID;
    var hdCoinID = coinID;
  
    $('#hdPackageID').val(packageID);
    $('#hdCoinID').val(coinID);
    $('#cbPackage option[value=' + packageID + ']').attr('selected', true);
    $('#cbPackage').trigger('chosen:updated')
    $('#cbCoin option[value=' + coinID + ']').attr('selected', true);
    $('#cbCoin').trigger('chosen:updated')
    $('#txtPackageValue').val(packageValue);

    //$('#cbPackage option[value=' + packageID + ']').attr('disabled', true);
    //$('#cbPackage').trigger('chosen:updated')
    //$('#cbCoin option[value=' + coinID + ']').attr('disabled', true);
    //$('#cbCoin').trigger('chosen:updated')

    $('#cbPackage').attr("disabled", true);
    $('#cbCoin').attr("disabled", true);

    setTimeout(function () {
        $('#cbPackage').chosen({
            width: '200px'
        },500);
    }, 500);
    setTimeout(function () {
        $('#cbCoin').chosen({
            width: '200px'
        });
    }, 500);
}
function ShowPopupInsert(packageID, coinID)
{
    $('#hdPackageID').val(0);
    $('#hdCoinID').val(0);
    $('#cbPackage option[value=' + packageID + ']').attr('selected', true);
    $('#cbPackage').trigger('chosen:updated')
    $('#cbCoin option[value=' + coinID + ']').attr('selected', true);
    $('#cbCoin').trigger('chosen:updated')

    //$('#cbPackage option[value=0]').attr('selected', true);
    //$('#cbPackage').trigger('chosen:updated')
    //$('#cbCoin option[value=0]').attr('selected', true);
    //$('#cbPackage').trigger('chosen:updated')

    $('#txtPackageValue').val('');
    //var hdPackageID = packageID;
    //var hdCoinID = coinID;

    //$('#hdPackageID').val('');
    //$('#hdCoinID').val('');
    //$('#cbPackage option[value=0]').attr('selected', true);
    //$('#cbPackage').trigger('chosen:updated')
    //$('#cbCoin option[value=0]').attr('selected', true);
    //$('#cbCoin').trigger('chosen:updated')
    //$('#txtPackageValue').val('');

}
function ConfirmPackage_Coin(packageID,coinID, isDelete) {
    var textMessage = '';
    textMessage = 'Are you sure delete this package_Coin?';
  
    var confirmMessage = confirm(textMessage);
    if (!confirmMessage) {
        return false;
    }
    else {
        $('#imgLoading_' + packageID).css("display", "");
        $.ajax({
            type: "post",
            async: false,
            url: "/Package_Coin/UpdateIsDeletePackageCoin",
            data: { packageID: packageID,coinID:coinID, isDelete: isDelete },
            beforeSend: function () {
                $('#imgLoading_' + packageID).css("display", "");
            },
            success: function (d) {
                $('#imgLoading_' + packageID).css("display", "none");
                if (d == 'success') {
                    noty({ text: "Update Success", layout: "bottomRight", type: "information" });

                    setTimeout(function () { window.location.reload(); }, 2000);
                }
                else if (d == 'PackageCoinIDExist')
                {
                    noty({ text: "Package_Coin Exist", layout: "bottomRight", type: "error" });
                }
                else {

                    noty({ text: "Update Error. Please contact admin", layout: "bottomRight", type: "error" });
                }
            },
            error: function (e) {

            }
        });
    }
}
function ResetForm(id, value) {
    $('#' + id).text('');
    $('#' + id).css('display', 'none');
}
//function functionx(evt) {
//    if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
//        alert("Allow Only Numbers");
//        return false;
//    }
//}
//$(document).ready(function () {
 
//    var packageID = $('#hdPackageID').val();
//    var coinID = $('#hdCoinID').val();
//    var packageValue = $('#txtPackageValue').val();

//    //var packageID = hdPackageID;
//    //var coinID = hdCoinID;

//    if (packageID > 0 && coinID > 0) {
//        $('#cbPackage').attr("disabled", true);
//        $('#cbCoin').attr("disabled", true);
//    }
//    else /*if (packageID == 0 && coinID == 0*/{
//        $('#cbPackage').attr("disabled", false);
//        $('#cbCoin').attr("disabled", false);
//    }
//});
function close()
{
    $('#hdPackageID').val('');
    $('#hdCoinID').val('');

    $('#cbPackage option[value=0]').attr('selected', true);
    $('#cbCoin option[value=0]').attr('selected', true);
    $('#txtPackageValue').val('');
}
function SavePackageCoin() {
    var checkReg = true;
    var hdPackageID = $('#hdPackageID').val();
    var hdCoinID = $('#hdCoinID').val();

    var packageID = $('#cbPackage').val();
    var coinID = $('#cbCoin').val();
  
    var packageValue = $('#txtPackageValue').val();

    if (packageID == 0) {
        $('#lbErrorPackage').text('Please select function');
        $('#lbErrorPackage').css('display', '');
        checkReg = false;
    }

    if (coinID == 0) {
        $('#lbErrorCoinID').text('Please input id coin ');
        $('#lbErrorCoinID').css('display', '');
        checkReg = false;
    }

    if (packageValue == '') {
        $('#lbErrorPackageValue').text('Please input packagecoin name');
        $('#lbErrorPackageValue').css('display', '');
        checkReg = false;
    }

    if (!checkReg) {
        return false;
    }
    else {
        $('#imgLoading').css("display", "");
        $.ajax({
            type: "post",
            async: true,
            url: "/Package_Coin/SavePackageCoin",
            data: { hdPackageID: hdPackageID, hdCoinID: hdCoinID, packageID: packageID, coinID: coinID, packageValue: packageValue },
            beforeSend: function () {
                $('#imgLoading').css("display", "");
            },
            success: function (d) {
                $('#imgLoading').css("display", "none");
                if (d == 'Updatesuccess') {
                    noty({ text: "Update success", layout: "bottomRight", type: "information" });
                    setTimeout(function () { window.location.reload(); }, 1000);
                }
               
                else if (d == 'Updatefaile') {
                    alertify.error('Updatefaile');
                }
                else if (d == 'PackageCoinIDExist') {
                    noty({ text: "Package_Coin Exist", layout: "bottomRight", type: "error" });
                }
                else if (d == 'error') {
                    alertify.error('error! please contact admin');
                }

            },
            error: function (e) {

            }
        });
    }
}

