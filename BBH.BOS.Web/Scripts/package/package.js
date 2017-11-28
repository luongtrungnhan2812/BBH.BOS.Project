function ConfirmPackage(packageID, isDelete) {
    var textMessage = '';
    //if (isDelete == 1) {
        textMessage = 'Are you sure delete this package?';
    //}
    //else if (isDelete == 0) {
    //    textMessage = 'Are you sure delete this package?';
    //}
    var confirmMessage = confirm(textMessage);
    if (!confirmMessage) {
        return false;
    }
    else {
        $('#imgLoading_' + packageID).css("display", "");
        $.ajax({
            type: "post",
            async: false,
            url: "/Package/UpdateIsDeletePackage",
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

function ShowPopUpEditPackage(packageID, packageName) {
    $('#hdPackageID').val(packageID);
    $('#txtPackageName').val(packageName);
}
function ResetForm(id, value) {
    $('#' + id).text('');
    $('#' + id).css('display', 'none');
}
function SavePackage() {
    var checkReg = true;
    var packageID = $('#hdPackageID').val();
    var packageName = $('#txtPackageName').val();
    

    if (packageName == '') {
        $('#lbErrorPackageName').text('Please input package name');
        $('#lbErrorPackageName').css('display', '');
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
            url: "/Package/SavePackage",
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
                else if (d == 'PackageNameExist') {
                    //alertify. alert("UserName Exit!!");
                   
                    $('#lbErrorPackageName').text('PackageName Exit!!');
                    $('#lbErrorPackageName').css("display", "");
                    window.scrollTo(100, 100);

                }
                else if (d == 'Updatefaile')
                {
                    alertify.error('Updatefaile');
                }
                else if (d == 'error')
                {
                    alertify.error('error! please contact admin');
                }
               
            },
            error: function (e) {

            }
        });
    }
}
