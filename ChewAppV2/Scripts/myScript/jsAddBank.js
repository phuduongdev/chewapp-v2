var table = document.getElementById("table"), rIndex;
for (var i = 1; i < table.rows.length; i++) {
    table.rows[i].onclick = function () {
        rIndex = this.rowIndex;
        console.log(rIndex);
        document.getElementById("id").value = this.cells[0].innerHTML;
        document.getElementById("bankname").value = this.cells[1].innerHTML;
    }
}
$(function () {
    $("#table").DataTable();
});

$("#SaveUserRecord").click(function () {

    if ($('#bankname').val() === '') {
        alert('You have not entered enough information');
        return false;
    }

    var addbank = {};
    addbank.ID = $('#id').val();
    addbank.BankName = $('#bankname').val();

    $.ajax({
        type: 'POST',
        url: '/Admin/UpdateAndInsertBank',
        data: '{bank: ' + JSON.stringify(addbank) + '}',
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
    });
});

function checkKey() {
    if (48 <= window.event.keyCode && window.event.keyCode <= 57) {
        window.event.keyCode = 0;
        swal({
            title: "Error",
            text: "Only characters are allowed.",
            icon: "error",
            button: false,
            timer: 2000,
        });
    }
        
 }

