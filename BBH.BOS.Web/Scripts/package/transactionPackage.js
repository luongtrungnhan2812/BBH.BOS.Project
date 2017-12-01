$('#myTable > tbody  > tr').each(function () {
    $(this).click(function () {
        $("#packageId").val($(this).attr("data-id"));
        if ($(this).attr("class") != "selected") {
            $('#myTable > tbody  > tr').each(function () {
                $(this).removeClass("selected");
            });
            $(this).attr("class", "selected");
        }
    });
});
$('#btn_submit').on('click', function () {
    var ChosenPackageID = $('#myTable > tbody  > tr.selected').attr("data-id");
    var CheckValue = $("input[name='groupCheckPackage']:checked").attr("data-value");
    if (!$('#termsPackage').is(':checked')) {
        $("#termsPackage").parents("div.form-group").addClass('has-error');
        $("#termsPackage").parents("div.form-group").find('.help-block').text('Please checked term');
        return false;
    } else {
        $("#termsPackage").parents("div.form-group").removeClass('has-error');
        $("#termsPackage").parents("div.form-group").find('.help-block').text('');
        if (ChosenPackageID != undefined) {
            swal({
                title: "Are you sure?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-info",
                confirmButtonText: "Yes, buy it!",
                closeOnConfirm: false
            },
                function () {
                    $.ajax({
                        type: "POST",
                        async: true,
                        url: "/Package/InsertTransactionPackage",
                        data: { packageID: ChosenPackageID, coinID: CheckValue },
                        beforeSend: function () {

                        },
                        success: function (d) {
                            if (d == 'success') {
                                swal({
                                    title: 'Success!',
                                    text: 'Good job!',
                                    type: 'success'
                                });
                            }
                            else {
                                swal({
                                    title: 'Oops...!',
                                    text: 'Something went wrong !',
                                    type: 'error'
                                });
                            }
                        },
                        error: function (e) {

                        }
                    });
                });

        } else {
            swal('You must select package')
            return false;
        }
    }

});
function ShowTransactionPackageDetail(memberID, strTransactionCode) {
    $.ajax({
        type: "POST",
        async: true,
        url: "/Wallet/DetailTransactionPackage",
        data: { memberID: memberID, strTransactionCode: strTransactionCode },
        beforeSend: function () {
            $('#imgLoadingSearch').css("display", "")
        },
        success: function (d) {
            $('#imgLoadingSearch').css("display", "none")

            var json = JSON.parse(d);
            if (json !== "") {
                $("#txtTransactionID").val(json.TransactionCode);
                $("#txtPackageName").val(json.PackageName);
                $("#txtPackageValue").val(json.PackageValue);
                $("#txtAmount").val(json.CoinValue);
                $("#txtUnit").val(json.CoinName);
                $("#txtCreateDate").val(json.CreateDate);
                $("#txtExpiredDate").val(json.ExpireDate);
                $("#myModalDetailTransactionPackage").show();
                $("#over").show();
            }
        },
        error: function (e) {

        }
    });

}
function CloseTransactionPackageDetail() {
    debugger
    $("#myModalDetailTransactionPackage").hide();
    $("#over").hide();
}