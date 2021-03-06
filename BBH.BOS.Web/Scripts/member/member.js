﻿function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    return pattern.test(emailAddress);
};
function RemoveTagHtml(str) {
    return str.replace(/<\/?[^>]+(>|$)/g, "");
}
function checkspace(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode
    if (unicode == 32) {
        return false
    }
}
function str_replace(search, replace, str) {
    var ra = replace instanceof Array, sa = str instanceof Array, l = (search = [].concat(search)).length, replace = [].concat(replace), i = (str = [].concat(str)).length;
    while (j = 0, i--)
        while (str[i] = str[i].split(search[j]).join(ra ? replace[j] || "" : replace[0]), ++j < l);
    return sa ? str : str[0];
}

function remove_vietnamese_accents(str) {
    accents_arr = new Array(
        "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă",
        "ằ", "ắ", "ặ", "ẳ", "ẵ", "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề",
        "ế", "ệ", "ể", "ễ",
        "ì", "í", "ị", "ỉ", "ĩ",
        "ò", "ó", "ọ", "ỏ", "õ", "ô", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ",
        "ờ", "ớ", "ợ", "ở", "ỡ",
        "ù", "ú", "ụ", "ủ", "ũ", "ư", "ừ", "ứ", "ự", "ử", "ữ",
        "ỳ", "ý", "ỵ", "ỷ", "ỹ",
        "đ",
        "À", "Á", "Ạ", "Ả", "Ã", "Â", "Ầ", "Ấ", "Ậ", "Ẩ", "Ẫ", "Ă",
        "Ằ", "Ắ", "Ặ", "Ẳ", "Ẵ",
        "È", "É", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ề", "Ế", "Ệ", "Ể", "Ễ",
        "Ì", "Í", "Ị", "Ỉ", "Ĩ",
        "Ò", "Ó", "Ọ", "Ỏ", "Õ", "Ô", "Ồ", "Ố", "Ộ", "Ổ", "Ỗ", "Ơ",
        "Ờ", "Ớ", "Ợ", "Ở", "Ỡ",
        "Ù", "Ú", "Ụ", "Ủ", "Ũ", "Ư", "Ừ", "Ứ", "Ự", "Ử", "Ữ",
        "Ỳ", "Ý", "Ỵ", "Ỷ", "Ỹ",
        "Đ"
    );

    no_accents_arr = new Array(
        "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
        "a", "a", "a", "a", "a", "a",
        "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e",
        "i", "i", "i", "i", "i",
        "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o", "o",
        "o", "o", "o", "o", "o",
        "u", "u", "u", "u", "u", "u", "u", "u", "u", "u", "u",
        "y", "y", "y", "y", "y",
        "d",
        "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A", "A",
        "A", "A", "A", "A", "A",
        "E", "E", "E", "E", "E", "E", "E", "E", "E", "E", "E",
        "I", "I", "I", "I", "I",
        "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O", "O",
        "O", "O", "O", "O", "O",
        "U", "U", "U", "U", "U", "U", "U", "U", "U", "U", "U",
        "Y", "Y", "Y", "Y", "Y",
        "D"
    );

    return str_replace(accents_arr, no_accents_arr, str);
}
function isDoubleByte(str) {
    accents_arr = new Array(
        "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă",
        "ằ", "ắ", "ặ", "ẳ", "ẵ", "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề",
        "ế", "ệ", "ể", "ễ",
        "ì", "í", "ị", "ỉ", "ĩ",
        "ò", "ó", "ọ", "ỏ", "õ", "ô", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ",
        "ờ", "ớ", "ợ", "ở", "ỡ",
        "ù", "ú", "ụ", "ủ", "ũ", "ư", "ừ", "ứ", "ự", "ử", "ữ",
        "ỳ", "ý", "ỵ", "ỷ", "ỹ",
        "đ",
        "À", "Á", "Ạ", "Ả", "Ã", "Â", "Ầ", "Ấ", "Ậ", "Ẩ", "Ẫ", "Ă",
        "Ằ", "Ắ", "Ặ", "Ẳ", "Ẵ",
        "È", "É", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ề", "Ế", "Ệ", "Ể", "Ễ",
        "Ì", "Í", "Ị", "Ỉ", "Ĩ",
        "Ò", "Ó", "Ọ", "Ỏ", "Õ", "Ô", "Ồ", "Ố", "Ộ", "Ổ", "Ỗ", "Ơ",
        "Ờ", "Ớ", "Ợ", "Ở", "Ỡ",
        "Ù", "Ú", "Ụ", "Ủ", "Ũ", "Ư", "Ừ", "Ứ", "Ự", "Ử", "Ữ",
        "Ỳ", "Ý", "Ỵ", "Ỷ", "Ỹ",
        "Đ"
    );
    for (var i = 0, n = str.length; i < n; i++) {
        if (str.charCodeAt(i) > 255) { return true; }
    }
    for (var j = 0; j < accents_arr.length; j++) {
        if (str.indexOf(accents_arr[j]) != -1) {
            return true;
        }
    }
    if (!CheckSpecialCharacter(str)) {
        return true;
    }
    return false;
}

function isDoubleByteUserName(str) {
    accents_arr = new Array(
        "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă",
        "ằ", "ắ", "ặ", "ẳ", "ẵ", "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề",
        "ế", "ệ", "ể", "ễ",
        "ì", "í", "ị", "ỉ", "ĩ",
        "ò", "ó", "ọ", "ỏ", "õ", "ô", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ",
        "ờ", "ớ", "ợ", "ở", "ỡ",
        "ù", "ú", "ụ", "ủ", "ũ", "ư", "ừ", "ứ", "ự", "ử", "ữ",
        "ỳ", "ý", "ỵ", "ỷ", "ỹ",
        "đ",
        "À", "Á", "Ạ", "Ả", "Ã", "Â", "Ầ", "Ấ", "Ậ", "Ẩ", "Ẫ", "Ă",
        "Ằ", "Ắ", "Ặ", "Ẳ", "Ẵ",
        "È", "É", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ề", "Ế", "Ệ", "Ể", "Ễ",
        "Ì", "Í", "Ị", "Ỉ", "Ĩ",
        "Ò", "Ó", "Ọ", "Ỏ", "Õ", "Ô", "Ồ", "Ố", "Ộ", "Ổ", "Ỗ", "Ơ",
        "Ờ", "Ớ", "Ợ", "Ở", "Ỡ",
        "Ù", "Ú", "Ụ", "Ủ", "Ũ", "Ư", "Ừ", "Ứ", "Ự", "Ử", "Ữ",
        "Ỳ", "Ý", "Ỵ", "Ỷ", "Ỹ",
        "Đ"
    );
    for (var i = 0, n = str.length; i < n; i++) {
        if (str.charCodeAt(i) > 255) { return true; }
    }
    for (var j = 0; j < accents_arr.length; j++) {
        if (str.indexOf(accents_arr[j]) != -1) {
            return true;
        }
    }
    if (!CheckSpecialUserNameCharacter(str)) {
        return true;
    }
    return false;
}

function CheckPassword(str) {
    accents_arr = new Array(
        "à", "á", "ạ", "ả", "ã", "â", "ầ", "ấ", "ậ", "ẩ", "ẫ", "ă",
        "ằ", "ắ", "ặ", "ẳ", "ẵ", "è", "é", "ẹ", "ẻ", "ẽ", "ê", "ề",
        "ế", "ệ", "ể", "ễ",
        "ì", "í", "ị", "ỉ", "ĩ",
        "ò", "ó", "ọ", "ỏ", "õ", "ô", "ồ", "ố", "ộ", "ổ", "ỗ", "ơ",
        "ờ", "ớ", "ợ", "ở", "ỡ",
        "ù", "ú", "ụ", "ủ", "ũ", "ư", "ừ", "ứ", "ự", "ử", "ữ",
        "ỳ", "ý", "ỵ", "ỷ", "ỹ",
        "đ",
        "À", "Á", "Ạ", "Ả", "Ã", "Â", "Ầ", "Ấ", "Ậ", "Ẩ", "Ẫ", "Ă",
        "Ằ", "Ắ", "Ặ", "Ẳ", "Ẵ",
        "È", "É", "Ẹ", "Ẻ", "Ẽ", "Ê", "Ề", "Ế", "Ệ", "Ể", "Ễ",
        "Ì", "Í", "Ị", "Ỉ", "Ĩ",
        "Ò", "Ó", "Ọ", "Ỏ", "Õ", "Ô", "Ồ", "Ố", "Ộ", "Ổ", "Ỗ", "Ơ",
        "Ờ", "Ớ", "Ợ", "Ở", "Ỡ",
        "Ù", "Ú", "Ụ", "Ủ", "Ũ", "Ư", "Ừ", "Ứ", "Ự", "Ử", "Ữ",
        "Ỳ", "Ý", "Ỵ", "Ỷ", "Ỹ",
        "Đ"
    );
    //for (var i = 0, n = str.length; i < n; i++) {
    //    if (str.charCodeAt(i) > 255) { return true; }
    //}
    for (var j = 0; j < accents_arr.length; j++) {
        if (str.indexOf(accents_arr[j]) != -1) {
            return true;
        }
    }
    return false;
}

function CheckSpecialCharacter(value) {
    var checkReg = true;
    var count = 0;
    //value = remove_unicode(value);
    if (value != "") {
        var characterReg = new Array('@', '$', '%', '^', '&', '*', '(', ')', '{', '}', '#', '~', '|', '*', '!', '~', '-', '=', '+', ',', '/', '?', '\'', '\"', ';', ':', '[', ']', '\\', '_', '`', '>', '<', '`', '.');
        //var characterReg = '@$%^&*(){}#~|*';
        for (var i = 0; i < characterReg.length; i++) {
            if (parseInt(value.indexOf(characterReg[i])) > -1) {
                count++;
            }
        }
        if (count > 0) {
            checkReg = false;
        }
    }
    return checkReg;
}
function ResetField(id) {
    if (id == 1) {
        $('#lbPassword').text('');

    }
    if (id == 2) {
        $('#lbRePass').text('');

    }
}
function CheckSpecialUserNameCharacter(value) {
    var checkReg = true;
    var count = 0;
    //value = remove_unicode(value);
    if (value != "") {
        var characterReg = new Array('$', '%', '^', '&', '*', '(', ')', '{', '}', '#', '~', '|', '*', '!', '~', '-', '=', '+', ',', '/', '?', '\'', '\"', ';', ':', '[', ']', '\\', '`', '>', '<', '`');
        //var characterReg = '@$%^&*(){}#~|*';
        for (var i = 0; i < characterReg.length; i++) {
            if (parseInt(value.indexOf(characterReg[i])) > -1) {
                count++;
            }
        }
        if (count > 0) {
            checkReg = false;
        }
    }
    return checkReg;
}

function functionx(evt) {
    if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
        alert("Allow Only Numbers");
        return false;
    }
} function ResetForm(id, value) {
    $('#' + id).text('');
    $('#' + id).css('display', 'none');
}

//$('#txtE_Wallet').on("keypress", function (e) {
//    var lenght = $(this).val().length;

//    if (lenght > 15) {
//        e.preventDefault();
//    }
//});
function CloseModal() {
    $('#txtReEmail').text('');
    $('#txtReEmail').css('display','');
    //$('#standardModal').removeClass('show');
    //$('#standardModal').css("display", "none");
    //$('.modal-backdrop.fade.show').css('opacity', '0');
    //$('.modal-backdrop.fade.show').css('display', 'none');
}
function ClosePopupOrderNow(idPop) {
    if (typeof $("#" + idPop) != 'undefined' && $("#" + idPop).length > 0) {
        $("#" + idPop).modal('toggle');
    }

    // changes the iframe src to prevent playback or stop the video playback in our case
    $('.popupModalVideo #video-view .class-video iframe').each(function (index) {
        $(this).attr('src', $(this).attr('src'));
        return false;
    });
}
$(document).ready(function () {
    //Onload();
    //$('#txtE-mail').attr("readonly", true);

});

function Onload()
{
    var result = $('#hdResult').val();

    if (result == 'registerSuccess') {

        alertify.alert('<span>Register success,please go to mail actives account!!</span>');
        alertify.alert().setting('modal', true);
        //window.location.href = ('/login');
        $('#txtEmail').val('');
        $('#txtPassword').val('');
        //$('#txtRePassword').val('');
        $('#txtFullName').val('');
        //$('#txtMobile').val('');
    }
   
    else if (result == 'EmailExist') {
        $('#txtEmail').val($('#hdEmail').val());
        $('#txtPassword').val($('#hdPassword').val());
        //$('#txtRePassword').val($('#hdPassword').val());

        $('#txtFullName').val($('#hdFullName').val());
        //$('#txtMobile').val($('#hdMobile').val());

        $('#lbEmail').text('This email has used by another');
        $('#lbEmail').css('display', '');
    }
    else if (result == 'RegisterFaile') {
        alertify.error('Error Register. Please contact with administrator');
    }
    else if (result == 'errorCaptcha') {
        $('#txtEmail').val($('#hdEmail').val());
        $('#txtPassword').val($('#hdPassword').val());
        //$('#txtRePassword').val($('#hdPassword').val());

        $('#txtFullName').val($('#hdFullName').val());
        //$('#txtMobile').val($('#hdMobile').val());
        //alertify.error('Please confirm captcha !');
        $('#lbrecaptcha').text('Please confirm captcha !');
        $('#lbrecaptcha').css('display', '');
    }

    setTimeout(function () {
        $.ajax({
            type: "post",
            async: true,
            url: "/Register/SetTimeoutSession",
            success: function () {
            }
        })
    }, 10);
}
//function RegisterMember() {

//    var email = $('#txtEmail').val();
//    var password = $('#txtPassword').val();
//    //var repassword = $('#txtRePassword').val();
//    var fullName = $('#txtFullName').val();
//    //var mobile = $('#txtMobile').val();

//    var checkReg = true;
//    var checkPassword = CheckPassword(password);
//    //var checkRepassword = CheckPassword(repassword);
//    if (email == '') {
        
//        $('#lbEmail').text('Input email');
//        $('#lbEmail').css('display', '');
//        checkReg = false;
//    }
//    else {
//        if (!isValidEmailAddress(email)) {
//            $('#lbEmail').text('Invalid email address.');
//            $('#lbEmail').css('display', '');
          
//            checkReg = false;
//        }
//    }
   
//    if (password == '') {

//        $('#lbPass').text('Input Password');
//        $('#lbPass').css('display', '');
//        checkReg = false;
//    }
//    else if (password.length < 8) {

//        $('#lbPass').text('Your password must be more than 8 characters');
//        $('#lbPass').css('display', '');
//        checkReg = false;
//    }
//    if (fullName == '') {

//        $('#lbFullname').text('Input Fullname');
//        $('#lbFullname').css('display', '');
//        checkReg = false;
//    }
//    //else {
//    //    if (!checkPassword) {
//    //        $('#lbPass').text(' password not Invalid');
//    //        $('#lbPass').css('display', '');
//    //        checkReg = false;
//    //    }
//    //}
//    //if (repassword == '') {
        
//    //    $('#lbRePass').text('Please input Repassword');
//    //    $('#lbRePass').css('display', '');
//    //    checkReg = false;
//    //}
//    //else {
//    //    if (password != repassword) {
//    //        $('#lbRePass').text('RePassword not match');
//    //        $('#lbRePass').css('display', '');
//    //    }

//    //}
   
//    //if (mobile == '') {
//    //    $('#lbMobile').text('Please input mobile');
//    //    $('#lbMobile').css('display', '');
//    //    checkReg = false;
//    //}
//    //else {
//    //    if (mobile.length < 10 || mobile.length > 13) {
            
//    //        $('#lbMobile').text('mobile number faile ');
//    //        $('#lbMobile').css('display', '');
//    //        checkReg = false;
//    //    }
//    //}

//    if (!checkReg) {
//        return false;
//    }
//    else {
//        return true;
//        //$('#imgLoading').css("display", "");
//        //$.ajax({
//        //    type: "post",
//        //    url: "/Register/RegisterMember",
//        //    async: false,
//        //    data: { email: email, password: password, mobile: mobile, fullName: fullName },
//        //    beforeSend: function () {
//        //        $('#imgLoading').css("display", "");
//        //    },
//        //    success: function (d) {
//        //        //$('#imgLoading').css("display", "none");

//        //        if (d == 'registerSuccess') {
//        //            //alert(d);
//        //            //alertify.alert('Register Success, vui long vao email de kick hoat tai khoan');
//        //            //$('#pointID').text(0);
//        //            setTimeout(function () { window.location.href = ('/'); }, 1000);
//        //            $('#txtEmail').text('');
//        //            $('#txtPassword').text('');
//        //            $('#txtRePassword').text('');

//        //            $('#txtFullName').text('');
//        //            $('#txtMobile').text('');

//        //        }
//        //        else if (d == 'EmailExist') {

//        //            //alertify.alert('This email has used by another');
//        //            $('#lbEmail').text('This email has used by another');
//        //            $('#lbEmail').css('display', '');
//        //        }

//        //        else if (d == 'RegisterFaile') {

//        //            alertify.error('Error Register. Please contact with administrator');

//        //        }
//        //        //else if (d == 'RegisterFaile1') {
//        //        //    alertify.error('email chua dc kich hoat');

//        //        //}
//        //    },
//        //    error: function () {

//        //    }
//        //});
//    }
//}
function RegisterMember() {

   
    var email = "";
    var password = "";
    var fullname = "";
    var strCaptcha ="";

    var checkReg = true;
    var checkPassword = CheckPassword(password);
    var checkFullName = CheckSpecialUserNameCharacter(fullname);

    if (typeof $('#txtEmail') != 'undefined' && $('#txtEmail').length > 0)
    {
        email = $('#txtEmail').val();
    }

    if (email == '') {

        $('#lbEmail').text('Email required for registration.');
        $('#lbEmail').css('display', '');
        checkReg = false;
    }
    else if (!isValidEmailAddress(email)) {          
        $('#lbEmail').text('Invalid email format');
            $('#lbEmail').css('display', '');
            checkReg = false;        
    }

    else if (email.length > 50) {
        $('#lbEmail').text('The maximum length is 50 characters.');
        $('#lbEmail').css('display', '');
        bolCheckReg = false;
    }

    if (typeof $('#txtPassword') != 'undefined' && $('#txtPassword').length > 0) {
        password = $('#txtPassword').val();
    }

    if (password == '') {

        $('#lbPass').text('Password required for registration.');
        $('#lbPass').css('display', '');
        checkReg = false;
    }
    else if (password.length < 8) {

        $('#lbPass').text('Your password must be more than 8 characters');
        $('#lbPass').css('display', '');
        checkReg = false;
    }
    //else if (!CheckPassword(password)) {         
    //    $('#lbPass').text('Invalid password format');
    //        $('#lbPass').css('display', '');
    //        checkReg = false;        
    //}

    if (typeof $('#txtFullName') != 'undefined' && $('#txtFullName').length > 0) {
        fullname = $('#txtFullName').val();
    }

    if (fullname == '') {

        $('#lbFullname').text('Fullname required for registration.');
        $('#lbFullname').css('display', '');
        checkReg = false;
    }
    else if (!CheckSpecialUserNameCharacter(fullname))
    {
        $('#lbFullname').text('Invalid Fullname format');
        $('#lbFullname').css('display', '');
        checkReg = false;
    }

    if (typeof $('#g-recaptcha-response') != 'undefined' && $('#g-recaptcha-response').length > 0) {
        strCaptcha = $('#g-recaptcha-response').val();
    }

    if (strCaptcha == null || strCaptcha.trim().length == 0) {
        if (typeof $('#lbrecaptcha') != 'undefined' && $('#lbrecaptcha').length > 0) {
            $('#lbrecaptcha').text('The captcha field is required!');
            $('#lbrecaptcha').css('display', '');
        }
        checkReg = false;
    }

    if (!checkReg) {
        return false;
    }
    else {        
        var param = {};
        param.strEmail = email;
        param.strPassword = password;
        param.strFullName = fullname;
        param.strCaptcha = strCaptcha;

        $.ajax({
            type: "post",
            url: "/Register/RegisterMember",
            async: true,
            data: param,
            beforeSend: function () {
                showLoading();
            },
            success: function (d) {
                hideLoading();
                if (typeof d.intTypeError != 'undefined' && typeof d.result != 'undefined' && typeof d.email != 'undefined' && typeof d.password != 'undefined' && typeof d.fullname != 'undefined') {
                    RegisterMemberSuccess(d.intTypeError, d.result, d.email, d.password, d.fullname);
                }
            },
            error: function (msg) {
                swal('Error Register. Contact with administrator, Please!');
            }
        });
    }
}
function RegisterMemberSuccess(intTypeError, strResult, strEmail, strPassword, strFullName)
{
    if (intTypeError != 0)
    {
        if (intTypeError == 1)
        {
            if (typeof $('#lbEmail') != 'undefined' && $('#lbEmail').length > 0)
            {
                $('#lbEmail').text('Email required for registration.');
                $('#lbEmail').css('display', '');
            }
        }
        else if (intTypeError == 2)
        {
            if (typeof $('#lbEmail') != 'undefined' && $('#lbEmail').length > 0) {
                $('#lbEmail').text('The maximum length is 50 characters.');
                $('#lbEmail').css('display', '');
            }
        }
        else if (intTypeError == 3)
        {
            if (typeof $('#lbPass') != 'undefined' && $('lbPass').length > 0) {
                $('#lbPass').text('Password required for registration.');
                $('#lbPass').css('display', '');
            }
        }
        else if (intTypeError == 4) {
            if (typeof $('#lbPass') != 'undefined' && $('lbPass').length > 0) {
                $('#lbPass').text('The minimum length is 8 characters.');
                $('#lbPass').css('display', '');
            }
        }
        else if (intTypeError == 5) {
            if (typeof $('#lbFullname') != 'undefined' && $('lbFullname').length > 0) {
                $('#lbFullname').text('FullName required for registration.');
                $('#lbFullname').css('display', '');
            }
        }
        else if (intTypeError == 6) {
            if (typeof $('#lbrecaptcha') != 'undefined' && $('lbrecaptcha').length > 0) {
                $('#lbrecaptcha').text('The captcha field is required!.');
                $('#lbrecaptcha').css('display', '');
            }
        }
    }
    else
    {
        if (strResult == 'registerSuccess') {            
            swal('You have successfully registered',
                'please check your email ' + strEmail + '',
                'success'
            );
            ResetDataElement('', '','','');
        }

        else if (strResult == 'EmailExist') {     
            ResetDataElement($('#hdEmail').val(), $('#hdPassword').val(), $('#hdFullName').val(), '');
            swal('This ' + strEmail + ' already exists');          
            
        }
        else if (strResult == 'RegisterFaile') {
            swal('Error Register. Please contact with administrator');
            ResetDataElement('', '', '', '');
        }
        else if (strResult == 'errorCaptcha') {        
            ResetDataElement($('#hdEmail').val(), $('#hdPassword').val(), $('#hdFullName').val(), 'The captcha field is required!');
        }
    }
}
function ResetDataElement(strEmail, strPassword, strFullName, strConfirmCaptcha) {
    //reset email
    if (typeof $('#txtEmail') != 'undefined' && $('#txtEmail').length > 0) {
        $('#txtEmail').val(strEmail);
    }

    if (typeof $('#txtPassword') != 'undefined' && $('#txtPassword').length > 0) {
        $('#txtPassword').val(strPassword);
    }
    if (typeof $('#txtFullName') != 'undefined' && $('#txtFullName').length > 0) {
        $('#txtFullName').val(strFullName);
    }
    if (typeof $('#g-recaptcha-response') != 'undefined' && $('#g-recaptcha-response').length > 0) {
        $('#g-recaptcha-response').val(strConfirmCaptcha);
    }
    //reset captcha
    grecaptcha.reset();

    if (typeof $('#lbEmail') != 'undefined' && $('#lbEmail').length > 0) {
        $('#lbEmail').text('');
        $('#lbEmail').hide();
    }

    if (typeof $('#lbPass') != 'undefined' && $('#lbPass').length > 0) {
        $('#lbPass').text('');
        $('#lbPass').hide();
    }
    if (typeof $('#lbFullname') != 'undefined' && $('#lbFullname').length > 0) {
        $('#lbFullname').text('');
        $('#lbFullname').hide();
    }

    if (typeof $('#lbrecaptcha') != 'undefined' && $('#lbrecaptcha').length > 0) {
        $('#lbrecaptcha').text('');
        $('#lbrecaptcha').hide();
        //$('#lbrecaptcha').text(strConfirmCaptcha);
        //if (strConfirmCaptcha.length == 0) {
        //    $('#lbrecaptcha').hide();
        //}
    }
}

function UpdateMember()
{
    var checkReg = true;
    var memberID = $('#hdmemberID').val();
    var email = $('#txtE-mail').val();
    var fullName = $('#txtFullName').val();
    var mobile = $('#txtMobile').val();
    var avatar = $('#fileup').val();
    
    $('#txtE-mail').attr("readonly", true);

    
      
       if (fullName == '') {

        $('#lbFullname').text('Input fullname');
        $('#lbFullname').css('display', '');
        checkReg = false;
    }
    if (mobile == '') {
        $('#lbMobile').text('Please input mobile');
        $('#lbMobile').css('display', '');
        checkReg = false;
    }
    else {
        if (mobile.length < 10 || mobile.length > 13) {

            $('#lbMobile').text('mobile number faile ');
            $('#lbMobile').css('display', '');
            checkReg = false;
        }
    }

    if (!checkReg) {
        return false;
    }
    else {
        $('#imgLoading').css("display", "");
        $.ajax({
            type: "post",
            url: "/Member/UpdateMember",
            async: true,
            data: { memberID: memberID, email: email, fullName: fullName, mobile: mobile, avatar: avatar },
            beforeSend: function () {
                $('#imgLoading').css("display", "");
            },
            success: function (d) {
                $('#imgLoading').css("display", "none");
                if (d == 'UpdateSuccess') {
                    $('#txtEmail').val('');
                    $('#txtFullName').val('');
                     $('#txtMobile').val('');
                     $('#fileup').val('');

                     alertify.success('Update success');

                    setTimeout(function () { window.location.reload(); }, 3000);
                }

                else {

                    alertify.error('Update error. Please contact with administrator');

                }

            },
            error: function () {

            }
        });
    }
}
function ChangePassWord() {
    var checkReg = true;
    var password = $('#txtNewPass').val();
    var rePassword = $('#txtRePass').val();
    var checkpass = CheckPassword(password);

    if (password == '' || password.length < 8) {
        $('#lbPassword').text('Password at least 8 character');

        checkReg = false;
    }
    if (password != rePassword) {
        $('#lbRePass').text('Password confirm wrong');

        checkReg = false;
    }
    if (!checkReg) {
        return false;
    }
    else {
        $.ajax({
            type: "post",
            url: "/Member/UpdatePassMember",
            async: true,
            data: { password: password },
            beforeSend: function () {
                showLoading();
            },
            success: function (d) {
                hideLoading();
                if (d == 'UpdatePassSuccess') {
                    $('#txtNewPass').val('');
                    $('#txtRePass').val('');
                    swal('Update password success')

                    setTimeout(function () { window.location.reload(); }, 3000);
                }

                else {

                    alertify.error('Update error. Please contact with administrator');

                }

            },
            error: function () {

            }
        });
    }
}

function ForgotPassword()
{
    var checkEmail = true;
    var email = $('#txtReEmail').val();

    if (email == '')
    {
        checkEmail = false;
        $('#lbreEmail').text('Input Email!');
        $('#lbreEmail').css('display','');
    }
    //else
    //{
   else if (!isValidEmailAddress(email)) {
        
        $('#lbreEmail').text('Email Invalid.');
        $('#lbreEmail').css('display', '');
        checkEmail = false;
       
    }
    if (!checkEmail)
    {
        return false;
    }
    else {
        $.ajax({
            type: "post",
            url: "/Member/SendMailResetPassword",
            async: true,
            data: { email: email },
            beforeSend: function () {
                showLoading();
            },
            success: function (d) {
                hideLoading();
                if (d == 'ResetPassSuccess') {
                   
                    swal('<span>Reset Password success,go to mail get account!!</span>');
                    $('#txtReEmail').val('');
                    setTimeout(function () { window.location.reload("/login"); }, 5000);

                }
                else if (d == 'emtry')
                {
                    $('#lbreEmail').text('Input email!');
                    $('#lbreEmail').css('display', '');
                }
                else if (d== 'EmailNotExit')
                {
                    alertify.error("Email Not Register!");
                }
                else if (d == 'EmailNotActive')
                {
                    alertify.error("E-mail Not Actived");
                }
                else if (d =='ResetPassfaile'){
                    alertify.error('ResetPassWord error. Please contact with administrator');
                }
            },
            error: function () {

            }
        });
    }
}

//function showLoading() {
//    if (typeof $('#divLoading') != 'undefined' && $('#divLoading').length > 0) {
//        $('#divLoading').css("display", "block");
//    }
//}

//function hideLoading() {
//    if (typeof $('#divLoading') != 'undefined' && $('#divLoading').length > 0) {
//        $('#divLoading').css("display", "none");
//    }
//}
