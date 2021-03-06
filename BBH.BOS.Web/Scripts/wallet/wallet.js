﻿function ShowTransactionWalletDetail(strTransactionId)
{
    $.ajax({
        type: "POST",
        async: true,
        url: "/Wallet/DetailWallet",
        data: { strTransactionId: strTransactionId },
        beforeSend: function () {
            $('#imgLoadingSearch').css("display", "")
        },
        success: function (d) {
            $('#imgLoadingSearch').css("display", "none")

            var json = JSON.parse(d);
            if (json !== "") {
                $("#txtTransactionID").val(json.TransactionID);
                $("#txtYourWalletAddress").val(json.WalletAddressID);
                $("#txtReceivedWalletAddress").val(json.WalletID);
                $("#txtBTC").val(json.ValueTransaction);
                $("#txtTransactionBitcoin").val(json.TransactionBitcoin);
                $("#txtCreateDate").val(json.CreateDate);
                $("#txtExpiredDate").val(json.ExpireDate);
                $("#myModalDetailWallet").addClass("show");
                $("#myModalDetailWallet").show();
                $("#over").show();
            }
        },
        error: function (e) {

        }
    });
    
}
function CloseModalTransactionWallet() {
    $("#myModalDetailWallet").removeClass("show");
    $("#myModalDetailWallet").hide();
    $("#over").hide();
}