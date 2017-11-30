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
                                //text: 'Buy success!',
                                type: 'success'
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