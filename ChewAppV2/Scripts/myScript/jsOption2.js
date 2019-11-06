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
});

$(function () {
    $("#table").DataTable({
        "ordering": true,
        columnDefs: [{
            orderable: false,
            targets: "view"
        },
        { "width": "10px", "targets": "view" },
        ],
        "order": [1, "asc"],
        "lengthMenu": [[50, -1], [50, "All"]],
    });
    //$("#table_length").css("display", "none");
    $(".mailbox-controls").appendTo($(".dataTables_length"));
    $(".dataTables_length label").css("display", "none");
});

var table = document.getElementById("table"), rIndex;
for (var i = 1; i < table.rows.length; i++) {
    table.rows[i].onclick = function () {
        rIndex = this.rowIndex;
        //console.log(rIndex);
        document.getElementById("id").value = this.cells[1].innerHTML;
        document.getElementById("optionname").value = this.cells[2].innerHTML;
    }
}



$("#saveOption").click(function () {

    if ($('#optionname').val() == '') {
        alert('You have not entered enough information');
        return false;
    }

    var option = {};
    option.ID = $('#id').val();
    option.Name = $('#optionname').val();


    $.ajax({
        type: 'POST',
        url: '/Admin/SaveOption2',
        data: '{op2: ' + JSON.stringify(option) + '}',
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                swal({
                    title: "Success",
                    text: "Successfully submitted! The form is valid.",
                    icon: "success",
                    button: false,
                    timer:2000,
                });
                window.setTimeout(window.location.reload.bind(window.location), 2300);
            } else {
                swal({
                    text: "The option has already existed.",
                    icon: "warning",
                    button: true,
                }).then((willDelete) => {
                    if (willDelete) {
                        $('#id').val("");
                        $('#optionname').val("");
                    }
                });
            }
        }
    });
});
