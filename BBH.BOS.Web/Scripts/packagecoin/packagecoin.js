function ShowpopupEditpackageCoin(packageID, coinID, packageValue)
{
    $('#hdPackageID').val(packageID);
    $('#hdCoinID').va(coinID);
    $('#cbPackage option[value=' + packageID + ']').attr('selected', true);
    $('#cbPackage').trigger('chosen:updated')
    $('#cbCoin option[value' + coinID + ']').attr('selected', true);
    $('#cbCoin').trigger('chosen:updated')

    $('#txtPackageValue').val(packageValue);

    setTimeout(function () {
        $('#cbPackage').chosen({
            width: '200px'
        });
    }, 500);
    setTimeout(function () {
        $('#cbCoin').chosen({
            width: '200px'
        });
    }, 500);
}

function ConfirmPackageCoin(packageID, isDelete) {
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
            data: { packageID: packageID, isDelete: isDelete },
            beforeSend: function () {
                $('#imgLoading_' + packageID).css("display", "");
            },
            success: function (d) {
                $('#imgLoading_' + packageID).css("display", "none");
                if (d == 'success') {
                    noty({ text: "Update Success", layout: "bottomRight", type: "information" });

                    setTimeout(function () { window.location.reload(); }, 2000);
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

function SavePackage() {
    var checkReg = true;
    var packageID = $('#cbPackage').val();
    var coinID = $('#cbCoin').val();
    var packageValue = $('#txtPackageValue').val();


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
            url: "/Package_Coin/SavePackage",
            data: { packageID: packageID, packageName: packageName },
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
                else if (d == 'error') {
                    alertify.error('error! please contact admin');
                }

            },
            error: function (e) {

            }
        });
    }
}
