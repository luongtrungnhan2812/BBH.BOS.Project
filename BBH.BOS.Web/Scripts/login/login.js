function isValidEmailAddress(emailAddress) {
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
function ResetField(id) {
    if (id == 1) {
        $('#lbPassword').text('');

    }
    if (id == 2) {
        $('#lbRePass').text('');

    }
}

function ResetForm(id) {
    switch (id) {
        case 1:
            {
                $('#lbEmail').text('');
                break;
            }
        case 2:
            {
                $('#lbE_Wallet').text('');
                break;
            }
        case 3:
            {
                $('#lbPass').text('');
                break;
            }
    }
}
$(document).ready(function () {
    //var result = $('#hdResult').val();
    //if (result == 'loginSuccess')
    //{
    //    window.location.href = '/';
    //}
    //else if (result == 'loginfaile')
    //{
    //    alertify.error("Email or password is wrongly");
    //}
    //else if (result == 'captchafaile')
    //{
    //    alertify.error('Please confirm captcha !');
    //}
    OnLoad();
    
    
});
function OnLoad() {
    var userName = $("#hdUsername").val();
    var passWord = $("#hdPassword").val();
    var result = $("#hdResult").val();
    if (userName != "-1" && passWord != "-1") {
        $("#txtEmail").val(userName);
        $("#txtPassword").val(passWord);
        if (result != "-1")
        {
            if (result == "loginSuccess")
            {
                $('#hdUsername').val('');
                $('#hdPassword').val('');
                window.location.href = '/Home';
            }
            else if (result =='loginfaile')
            {
                alertify.error("email or password not Invalid ");
          }
            else if (result =='captchafaile') {
                $('#lbrecaptcha').text('Please confirm captcha !');
                $('#lbrecaptcha').css('display', '');
            }
        }
      
    }
}
function LoginMember() {
    //var language = $('#hdLanguage').val();
    //var urlRedirect = $('#hdRedirect').val();
    var email = $('#txtEmail').val();
    var password = $('#txtPassword').val();
    var checkReg = true;
    var checkPassword = CheckPassword(password);
    if (email == '') {
        checkReg = false;
        $('#lbEmail').text('Please input email');
        $('#lbEmail').css('display', '');
    }
    else {
        if (!isValidEmailAddress(email)) {
            checkReg = false;
            $('#lbEmail').text('Email is not correct format');
            $('#lbEmail').css('display', '');
        }
    }
   
    if (password == '') {
        checkReg = false;
        $('#lbPass').text('Please input password');
        $('#lbPass').css('display', '');
    }
    if (!checkReg) {
        return false;
    }
    else {
        return true;
        //$('#imgLoading').css("display", "");
        //$.ajax({
        //    type: "post",
        //    url: "/Login/MemberLogin",
        //    async: true,
        //    data: { email: email, password: password },
        //    beforeSend: function () {
        //        $('#imgLoading').css("display", "");
        //    },
        //    success: function (d) {
        //        $('#imgLoading').css("display", "none");
        //        if (d == 'loginfaile') {
        //            //if (language == 'EN') {
        //            alertify.error("Email or password is wrongly");
        //            //  noty({ text: "Please input keyword search", layout: "bottomRight", type: "error" });
        //            //}
        //            //else
        //            //{
        //            //    alertify.error("Email hoặc mật khẩu không đúng");
        //            //}
        //        }
        //        else if (d == 'loginSuccess') {
        //            window.location.href = '/play-game';
        //        }
        //    },
        //    error: function () {

        //    }
        //});
    }
}
function LogoutMember()
{
    $.ajax({
            type: "post",
            url: "/Login/LogoutMember",
            async: true,
            data: {},
            beforeSend: function () {
                //$('#imgLoading').css("display", "");
            },
            success: function (d) {
                window.location.href = '/login';
            },
            error: function () {

            }
        });
}
//function EnterLogin(event, value) {
//    var urlRedirect = $('#hdRedirect').val();
//    if (event.which == 13 || event.keyCode == 13) {
//        var email = $('#txtEmail').val();
//        //var ewallet = $('#txtE_Wallet').val();
//        var password = $('#txtPassword').val();
//        var checkReg = true;
//        var checkPassword = CheckPassword(password);
//        if (email == '') {
//            checkReg = false;
//            if (language == 'EN') {
//                $('#lbEmail').text('Please input email');
//            }
//            else {
//                $('#lbEmail').text('Vui lòng nhập email');
//            }
//        }
//        else {
//            if (!isValidEmailAddress(email)) {
//                checkReg = false;
//                if (language == 'EN') {
//                    $('#lbEmail').text('Email is not correct format');
//                }
//                else {
//                    $('#lbEmail').text('Email không hợp lệ');
//                }
//            }
//        }
//        //if(ewallet=='')
//        //{
//        //    checkReg = false;
//        //    $('#lbE_Wallet').text('Vui lòng nhập E-wallet');
//        //}
//        if (password == '') {
//            checkReg = false;
//            if (language == 'EN') {
//                $('#lbPass').text('Please input password');
//            }
//            else {
//                $('#lbPass').text('Vui lòng nhập mật khẩu');
//            }
//        }
//        if (!checkReg) {
//            return false;
//        }
//        else {
//            $('#imgLoading').css("display", "");
//            $.ajax({
//                type: "post",
//                url: "/Login/MemberLogin",
//                async: true,
//                data: { email: email, password: password },
//                beforeSend: function () {
//                    $('#imgLoading').css("display", "");
//                },
//                success: function (d) {
//                    $('#imgLoading').css("display", "none");
//                    if (d == 'loginfaile') {
//                        //if (language == 'EN') {
//                        alertify.error("Email or password is wrongly");
//                        //}
//                        //else {
//                        //    alertify.error("Email hoặc mật khẩu không đúng");
//                        //}
//                    }
//                    else if (d == 'loginSuccess') {
//                        if (urlRedirect == '' || urlRedirect == '/') {
//                            urlRedirect = "/play-game";
//                        }
//                        window.location.href = urlRedirect;
//                    }
//                },
//                error: function () {

//                }
//            });
//        }
//    }
//}