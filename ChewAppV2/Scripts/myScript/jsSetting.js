$(function () {
    var table = $("#table").DataTable();

    $('#table tbody').on('click', 'tr', function () {

        $("#inputRadius").removeAttr('disabled');
        $("#inputMinimumServices").removeAttr('disabled');
        $("#inputMaxTimeLimit").removeAttr('disabled');
        $("#saveSetting").removeAttr('disabled');

        document.getElementById("inputID").value = this.cells[0].innerHTML;
        document.getElementById("inputRadius").value = this.cells[1].innerHTML;
        document.getElementById("inputMinimumServices").value = this.cells[2].innerHTML;
        document.getElementById("inputMaxTimeLimit").value = this.cells[3].innerHTML;
    });

    $('#reset').click(function () {
        $("#inputRadius").attr('disabled', 'disabled');
        $("#inputMinimumServices").attr('disabled', 'disabled');
        $("#inputMaxTimeLimit").attr('disabled', 'disabled');
        $("#saveSetting").attr('disabled', 'disabled');
        $("#inputRadius").val("");
        $("#inputMinimumServices").val("");
        $("#inputMaxTimeLimit").val("");
    });
    
    var trInstance = $('#table').find('tr');
    trInstance.click(function () {
        trInstance.find('td').removeClass('greenCSS');
        var instance = $(this);
        instance.find('td').addClass('greenCSS');
    });
});

$("#saveSetting").click(function () {
    var setting = {};

    if ($('#inputID').val() === '' ||
        $('#inputRadius').val() === '' ||
        $('#inputMinimumServices').val() === '' ||
        $('#inputMaxTimeLimit').val() === '') {
        alert("No data");
        return false;
    } 
    setting.ID = $('#inputID').val();
    setting.Radius = $('#inputRadius').val();
    setting.MinimumServiceFee = $('#inputMinimumServices').val();
    setting.MaxTimeLimit = $('#inputMaxTimeLimit').val();
    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateSetting',
        data: '{setting: ' + JSON.stringify(setting) + '}',
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