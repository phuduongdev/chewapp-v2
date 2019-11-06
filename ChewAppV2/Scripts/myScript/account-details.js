function getEventTarget(e) {
    e = e || window.event;
    return e.target || e.srcElement;
}

$(function () {
    var ul = document.getElementById('dropdown');

    ul.onclick = function (event) {
        var target = getEventTarget(event);
        //alert(target.innerHTML);

        $('#text').val(target.innerHTML);

        $('#update').submit();

    };

    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    });

    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
        checkboxClass: 'icheckbox_minimal-red',
        radioClass: 'iradio_minimal-red'
    });

    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    });

    $('#datepicker').datepicker({
        autoclose: true
    });
});

$("#btnEdit").click(function () {

    $("#tableDetailAccount").css("display", "none");
    $("#editProfile").css("display", "block");
    $("#DetailBalance").css("display", "none");
    $("#btnEdit").css("display", "none");
    $(".Balance").css("background-color", "");

});

function Profile() {
    $("#tableDetailAccount").css("display", "block");
    $("#btnEdit").css("display", "block");
    $("#editProfile").css("display", "none");
    $("#DetailBalance").css("display", "none");
    $(".Balance").css("background-color", "");
}

function showBalane() {
    $("#tableDetailAccount").css("display", "none");
    $("#editProfile").css("display", "none");
    $("#btnEdit").css("display", "block");
    $("#DetailBalance").css("display", "block");
    $(".Balance").css("background-color", "rgba(255, 102, 0, 1)");
}

function CheckKeyword(e) {
    var keyword = null;
    if (window.event) {
        keyword = window.event.keyCode;
    } else {
        keyword = e.which; //NON IE;
    }

    if (keyword < 48 || keyword > 57) {
        if (keyword == 48 || keyword == 127) {
            return;
        }
        return false;
    }
}

function checkNumberAmount(a) {
    var patt1 = /^[-]?\d*\.?\d*$/g;

    var result = patt1.test(a);

    return result;
}

function calcTime() {

    var d = new Date();

    return d.toLocaleString('en-SG', { timeZone: 'Asia/Singapore' });

}

function tConvert(time) {

    time = time.toString().match(/^([01]\d|2[0-3])(:)([0-5]\d)(:[0-5]\d)?$/) || [time];

    if (time.length > 1) {
        time = time.slice(1);
        time[5] = +time[0] < 12 ? ' AM' : ' PM';
        time[0] = +time[0] % 12 || 12;
    }
    return time.join('');
} // convert 24h to 12h

$("#inputName").blur(function () {
    if ($("#inputName").val() === "") {
        $(".error1").text("Name can not be empty.");
        return false;
    } else {
        $(".error1").text("");
    }
});

$("#inputReferralCode").blur(function () {
    if ($("#inputReferralCode").val() === "") {
        $(".error4").text("Referral Code can not be empty.");
        return false;
    } else {
        $(".error4").text("");
    }
});

$("#inputAccountName").blur(function () {
    if ($("#inputAccountName").val() === "") {
        $(".error6").text("Account Name can not be empty.");
        return false;
    } else {
        $(".error6").text("");
    }
});

$("#inputAccountNumber").blur(function () {
    if ($("#inputAccountNumber").val() === "") {
        $(".error7").text("Account Number can not be empty.");
        return false;
    } else {
        $(".error7").text("");
    }
});

$("#inputPayNowNumber").blur(function () {
    if ($("#inputPayNowNumber").val() === "") {
        $(".error8").text("PayNow Number can not be empty.");
        return false;
    } else {
        $(".error8").text("");
    }
});

$("#saveAccountDetail").click(function () {

    $.ajax({
        type: "POST",
        url: "/Admin/ValidateEmail?emailAddress=" + $("#inputEmail").val(),
        success: function (list) {

            if (list == 1) {

                $(".error2").text("");

                $.ajax({
                    type: "POST",
                    url: "/Admin/CheckEmailExisted?email=" + $("#inputEmail").val() + "&id=" + $("#inputID").val(),
                    success: function (list) {

                        if (list == 1) {

                            $(".error2").text("Email already exists.");

                            return false;

                        } else {

                            $(".error2").text("");

                            $.ajax({
                                type: "POST",
                                url: "/Admin/ValidatePhone?phone=" + $("#inputMobile").val(),
                                success: function (list) {

                                    if (list == 1) {

                                        $(".error3").text("");

                                        $.ajax({
                                            type: "POST",
                                            url: "/Admin/CheckPhoneExisted?phone=" + $("#inputMobile").val() + "&id=" + $("#inputID").val(),
                                            success: function (list) {

                                                if (list == 1) {

                                                    $(".error3").text("Phone already exists.");

                                                    return false;

                                                } else {

                                                    $(".error3").text("");


                                                    if ($('#inputAccountName').val() != "" && $('#inputAccountNumber').val() != "" && $("#inputPayNowNumber").val() != "" && $('#selectBankName').val() == 0) {

                                                        $(".error9").text("Must choose a bank name.");

                                                        return false;

                                                    } else {

                                                        $(".error9").text("");

                                                    }

                                                    var data = new FormData();

                                                    data.append("ID", $("#inputID").val());
                                                    data.append("Name", $("#inputName").val());
                                                    data.append("Gender", $('input:radio[name="r2"]:checked').val());
                                                    data.append("Email", $("#inputEmail").val());
                                                    data.append("Mobile", $("#inputMobile").val());
                                                    data.append("ReferralCode", $("#inputReferralCode").val());
                                                    data.append("ReferredBy", $('#inputReferredBy').val());
                                                    data.append("Bank", $('#selectBankName').val());
                                                    data.append("AccountName", $('#inputAccountName').val());
                                                    data.append("AccountNumber", $('#inputAccountNumber').val());
                                                    data.append("PayNowNumber", $("#inputPayNowNumber").val());

                                                    $.ajax({
                                                        type: 'POST',
                                                        url: '/Admin/SaveAccounts',
                                                        data: data,
                                                        contentType: false,
                                                        processData: false,
                                                        success: function (result) {
                                                            if (result === true) {
                                                                swal({
                                                                    title: "Success",
                                                                    text: "Successfully submitted! The form is valid.",
                                                                    icon: "success",
                                                                    button: false,
                                                                    timer: 2000,
                                                                });
                                                                window.setTimeout(window.location.reload.bind(window.location), 2300);
                                                            }
                                                        }
                                                    });
                                                }
                                            }
                                        });

                                    } else {

                                        $(".error3").text("Phone numbers must start with 3, 8 or 9.");

                                        return false;
                                    }
                                }
                            });
                        }
                    }
                });

            } else {

                $(".error2").text("Email is malformed.");

                return false;
            }
        }
    });
});

$("#addBalance").click(function () {

    if ($("#datepicker").val() == "") {

        $(".balanError1").text("Do not empty.");

        if ($("#inputDescription").val() == "") {

            $(".balanError2").text("Do not empty.");

            if ($("#inputAmount").val() == "") {

                $(".balanError3").text("Do not empty.");

                return false;

            } else {

                $(".balanError3").text("");

                if (checkNumberAmount($("#inputAmount").val()) == false) {

                    $(".balanError3").text("Invalid format.");

                    return false;

                } else {

                    $(".balanError3").text("");

                }
            }

            return false;

        } else {

            $(".balanError2").text("");

            if ($("#inputAmount").val() == "") {

                $(".balanError3").text("Do not empty.");

                return false;

            } else {

                $(".balanError3").text("");

                if (checkNumberAmount($("#inputAmount").val()) == false) {

                    $(".balanError3").text("Invalid format.");

                    return false;

                } else {

                    $(".balanError3").text("");

                }
            }
        }

        return false;

    } else {

        $(".balanError1").text("");

        var formatDate = calcTime().split(', ')[0];

        var day = formatDate.split('/')[0];
        var month = formatDate.split('/')[1];
        var year = formatDate.split('/')[2];

        var date2 = new Date($("#datepicker").val());
        var date1 = new Date(month + "/" + day + "/" + year);

        if (date2 >= date1) {

            $(".balanError1").text("");

            if ($("#inputDescription").val() == "") {

                $(".balanError2").text("Do not empty.");

                if ($("#inputAmount").val() == "") {

                    $(".balanError3").text("Do not empty.");

                    return false;

                } else {

                    $(".balanError3").text("");

                    if (checkNumberAmount($("#inputAmount").val()) == false) {

                        $(".balanError3").text("Invalid format.");

                        return false;

                    } else {

                        $(".balanError3").text("");

                    }
                }

                return false;

            } else {

                $(".balanError2").text("");

                if ($("#inputAmount").val() == "") {

                    $(".balanError3").text("Do not empty.");

                    return false;

                } else {

                    $(".balanError3").text("");

                    if (checkNumberAmount($("#inputAmount").val()) == false) {

                        $(".balanError3").text("Invalid format.");

                        return false;

                    } else {

                        $(".balanError3").text("");

                    }
                }
            }

        } else if (date2 < date1) {

            $(".balanError1").text("Date incorrect.");

            if ($("#inputDescription").val() == "") {

                $(".balanError2").text("Do not empty.");

                if ($("#inputAmount").val() == "") {

                    $(".balanError3").text("Do not empty.");

                    return false;

                } else {

                    $(".balanError3").text("");

                    if (checkNumberAmount($("#inputAmount").val()) == false) {

                        $(".balanError3").text("Invalid format.");

                        return false;

                    } else {

                        $(".balanError3").text("");

                    }
                }

                return false;

            } else {

                $(".balanError2").text("");

                if ($("#inputAmount").val() == "") {

                    $(".balanError3").text("Do not empty.");

                    return false;

                } else {

                    $(".balanError3").text("");

                    if (checkNumberAmount($("#inputAmount").val()) == false) {

                        $(".balanError3").text("Invalid format.");

                        return false;

                    } else {

                        $(".balanError3").text("");

                    }
                }
            }

            return false;
        }
    }

    var formatDate = calcTime().split(', ')[0];

    var day = formatDate.split('/')[0];
    var month = formatDate.split('/')[1];
    var year = formatDate.split('/')[2];

    var datepicker = $("#datepicker").val();

    var date = datepicker + " " + calcTime().split(', ')[1];

    var data = new FormData();

    data.append("DateBalance", date);

    data.append("SoonChewID", $("#inputID").val());

    data.append("Description", $("#inputDescription").val());

    data.append("Amount", $("#inputAmount").val());

    $.ajax({

        type: 'POST',
        url: '/Admin/SaveBalances',
        data: data,
        contentType: false,
        processData: false,
        success: function (result) {
            if (result === true) {

                swal({
                    title: "Success",
                    text: "Successfully submitted! The form is valid.",
                    icon: "success",
                    button: false,
                    timer: 2000
                });

                window.setTimeout(window.location.reload.bind(window.location), 2300);
            }
        }
    });

});

function DeleteBalance(id, usID) {
    swal({
        title: "Are you sure?",
        text: "Are you sure you want to delete this Balance?",
        icon: "warning",
        dangerMode: true,
    })
        .then(willDelete => {

            if (willDelete) {

                $.ajax({
                    type: "POST",
                    url: "/Admin/DeleteBalance?idBalance=" + id + "&userID=" + usID,
                    success: function (list) {

                        if (list === 1) {

                            swal({

                                text: "Delete successfully!",
                                icon: "success",
                                button: false,
                                timer: 2000
                            });

                            window.setTimeout(window.location.reload.bind(window.location), 2300);
                        }
                    }
                });
            }
        });
};
