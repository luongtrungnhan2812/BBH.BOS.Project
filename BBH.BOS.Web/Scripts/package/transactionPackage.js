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
//$('#btn_submit').on('click', function () {
//    //var CurrentPackageID = $('#myTable > tbody  > tr.checked').attr("data-id");
//    var ChosenPackageID = $('#myTable > tbody  > tr.selected').attr("data-id");
//    //if (CurrentPackageID >= ChosenPackageID)
//    //{
//    //    alert(CurrentPackageID);
//    //}
//    if (ChosenPackageID != '')
//    {
//        $.ajax({
//            type: "POST",
//            async: true,
//            url: "/Package/InsertTransactionPackage",
//            data: { packageID: ChosenPackageID},
//            beforeSend: function () {

//            },
//            success: function (d) {
//                if (d == 'success') {

//                    noty({ text: "Update Success", layout: "bottomRight", type: "information" });
//                    //setTimeout(function () { window.location.reload(); }, 2000);
//                    //alert(d);
//                }
//            },
//            error: function (e) {

//            }
//        });
//    }
//});
$('#btn_submit').on('click', function () {
    if (!$('#termsPackage').is(':checked')) {
        $("#termsPackage").parents("div.form-group").addClass('has-error');
        $("#termsPackage").parents("div.form-group").find('.help-block').text('Please checked term');
        return false;
    } else {
        $("#termsPackage").parents("div.form-group").removeClass('has-error');
        $("#termsPackage").parents("div.form-group").find('.help-block').text('');
        //if (packageIdPick > packageId) {
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
                    data: { packageID: ChosenPackageID },
                    beforeSend: function () {

                    },
                    success: function (d) {
                        if (d == 'success') {

                            noty({ text: "Update Success", layout: "bottomRight", type: "information" });
                            //setTimeout(function () { window.location.reload(); }, 2000);
                            //alert(d);
                        }
                    },
                    error: function (e) {

                    }
                });
            });

        //} else {
        //    swal('You select invalid package')
        //    return false;
        //}
    }

});