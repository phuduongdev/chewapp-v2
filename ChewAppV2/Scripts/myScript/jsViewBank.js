$(function () {

    $('.mailbox-messages input[type="checkbox"]').iCheck({
        checkboxClass: 'icheckbox_flat-blue',
        radioClass: 'iradio_flat-blue'
    });

    $('.mailbox-messages input[type="checkbox"]').on('ifChecked', function (event) {

        $("#delete").removeAttr("disabled", "disabled");
    });

    $('.mailbox-messages input[type="checkbox"]').on('ifUnchecked', function (event) {

        $("#delete").attr("disabled", "disabled");
    });

    //Enable check and uncheck all functionality
    $(".checkbox-toggle").click(function () {
        var clicks = $(this).data('clicks');
        if (clicks) {

            $(".mailbox-messages input[type='checkbox']").iCheck("uncheck");
            $(".fa", this).removeClass("fa-check-square-o").addClass('fa-square-o');
        } else {

            $(".mailbox-messages input[type='checkbox']").iCheck("check");
            $(".fa", this).removeClass("fa-square-o").addClass('fa-check-square-o');
        }
        $(this).data("clicks", !clicks);
    });

    $(".mailbox-star").click(function (e) {
        e.preventDefault();

        var $this = $(this).find("a > i");
        var glyph = $this.hasClass("glyphicon");
        var fa = $this.hasClass("fa");

        if (glyph) {
            $this.toggleClass("glyphicon-star");
            $this.toggleClass("glyphicon-star-empty");
        }

        if (fa) {
            $this.toggleClass("fa-star");
            $this.toggleClass("fa-star-o");
        }
    });

    $("#tableBank").DataTable({
        "ordering": true,
        columnDefs: [{
                orderable: false,
                targets: "view"
            },
            {
                "width": "10px",
                "targets": "view"
            }
        ],
        "order": [1, "asc"],
        "lengthMenu": [[50], [50]],
    });
    //$("#table_length").css("display", "none");
    $(".mailbox-controls").appendTo($(".dataTables_length"));
    $(".dataTables_length label").css("display", "none");
});

var table = document.getElementById("tableBank"), rIndex;

for (var i = 1; i < table.rows.length; i++) {
    table.rows[i].onclick = function () {
        rIndex = this.rowIndex;
        //console.log(rIndex);
        document.getElementById("id").value = this.cells[1].innerHTML;
        document.getElementById("bankAbbreviation").value = this.cells[3].innerHTML;
        document.getElementById("bankName").value = this.cells[4].innerHTML;
    }
}


$("#saveBank").click(function () {

    if ($("#bankName").val() === "") {
        swal({
            title: "Error",
            text: "You have not entered enough information.",
            icon: "error"
        });
        return false;
    }

    if ($("#bankAbbreviation").val() === "") {
        swal({
            title: "Error",
            text: "You have not entered enough information.",
            icon: "error"
        });
        return false;
    }

    var bank = {};
    bank.ID = $("#id").val();
    bank.Bank_Name = $("#bankName").val();
    bank.Bank_Abbreviation = $("#bankAbbreviation").val();

    $.ajax({
        type: "POST",
        url: "/Admin/SaveBank",
        data: "{bank: " + JSON.stringify(bank) + "}",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function(result) {
            if (result === true) {
                swal({
                    title: "Success",
                    text: "Successfully submitted! The form is valid.",
                    icon: "success",
                    button: false,
                    timer: 2000,
                });
                window.setTimeout(window.location.reload.bind(window.location), 2300);
                //$('#table').DataTable().ajax.reload();
            } else {
                swal({
                    text: "The option has already existed.",
                    icon: "warning",
                    button: true
                }).then((willDelete) => {
                    if (willDelete) {
                        $("#id").val("");
                        $("#bankName").val("");
                        $("#bankAbbreviation").val("");
                    }
                });
            }
        }
    });
});
