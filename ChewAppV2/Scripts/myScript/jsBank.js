$(function () {
    $("#table").DataTable();
});


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

$("#SaveUserRecord").click(function () {
    if ($('#accountname').val() === "" || $('#cardnumber').val() === "" || $('#creditcard').val() === "" || $('#bankname').val() === '') {
        alert("You have not entered enough information!");
        return false;
    }

    var addbank = {};
    addbank.BankName = $('#framework').find(":selected").text();
    addbank.AccountName = $('#accountname').val();
    addbank.CardNumber = $('#cardnumber').val();
    addbank.CreditCard = $('#creditcard').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/InsertPayment',
        data: '{payment: ' + JSON.stringify(addbank) + '}',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
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
    })
});


