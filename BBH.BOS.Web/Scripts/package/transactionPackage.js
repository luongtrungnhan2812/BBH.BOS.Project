$('#myTable > tbody  > tr').each(function () {
    $(this).click(function () {
        $("#packageId").val($(this).attr("data-id"));
        if ($(this).attr("class") != "selected")
        {
            $('#myTable > tbody  > tr').each(function () {
                $(this).removeClass("selected");
            });
            $(this).attr("class", "selected");
        }
    });
});
$('#btn_submit').on('click', function () {
    //var CurrentPackageID = $('#myTable > tbody  > tr.checked').attr("data-id");
    var ChosenPackageID = $('#myTable > tbody  > tr.selected').attr("data-id");
    //if (CurrentPackageID >= ChosenPackageID)
    //{
    //    alert(CurrentPackageID);
    //}
    if (ChosenPackageID != '')
    {
        $.ajax({
            type: "POST",
            async: true,
            url: "/Package/InsertTransactionPackage",
            data: { packageID: ChosenPackageID},
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
});