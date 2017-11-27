function LockAndUnlockPackage(packageID, isActive) {
    var confirmMessage = confirm('Are you sure lock this package?');
    if (!confirmMessage) {
        return false;
    }
    else {

        $.ajax({
            type: "post",
            async: true,
            url: "/Package/LockAndUnlockPackage",
            data: { packageID: packageID, isActive: isActive },
            beforeSend: function () {

            },
            success: function (d) {
                if (d == 'success') {
                    noty({ text: "Update Success", layout: "bottomRight", type: "information" });
                    setTimeout(function () { window.location.reload(); }, 2000);
                }
            },
            error: function (e) {

            }
        });
    }
}