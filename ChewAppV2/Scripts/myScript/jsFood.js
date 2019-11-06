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

$("#btnSave").click(function () {

    var totalFiles = document.getElementById("FileUpload1").files.length;

    if (totalFiles === 0) {
        swal({
            title: "Error",
            text: "You have not selected a Photo!",
            icon: "error",
        });

        return false;
    }
    else {
        if ($('#inputFoodName').val() === "") {
            swal({
                title: "Error",
                text: "You have not entered Food Name!",
                icon: "error",
            });
            return false;

        }
        else {

            if ($('#inputPrice').val() === "") {
                swal({
                    title: "Error",
                    text: "You have not entered Price!",
                    icon: "error",
                });
                return false;

            } else {

                var formData = new FormData();

                for (var i = 0; i < totalFiles; i++) {
                    var file = document.getElementById("FileUpload1").files[i];

                    formData.append(file.name, file);
                }

                var countries = [];
                $.each($("#framework option:selected"), function () {
                    countries.push($(this).val());
                });

                var countries2 = [];
                $.each($("#framework2 option:selected"), function () {
                    countries2.push($(this).val());
                });

                var e = document.getElementById("framework1");
                var strCategoryID = e.options[e.selectedIndex].value;
                var strCategoryName = e.options[e.selectedIndex].text;

                var foodName = $('#inputFoodName').val();
                var foodPrice = $('#inputPrice').val();
                var foodID = $('#foodID').val();

                formData.append('ID', foodID);
                formData.append('Name', foodName);
                formData.append('Price', foodPrice);
                formData.append('Option1', countries.join(", "));
                formData.append('Option2', countries2.join(", "));
                formData.append('FoodCategoryTbl_ID', strCategoryID);
                formData.append('FoodCategoryTbl_Name', strCategoryName);

                $.ajax({
                    type: "POST",
                    url: '/Admin/SaveFood',
                    data: formData,
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
                        } else {
                            swal({
                                text: "The food has already existed.",
                                icon: "warning",
                                button: true,
                            }).then((willDelete) => {
                                if (willDelete) {
                                    //$('#FileUpload1').val("");
                                    $('#foodID').val("");
                                    $('#inputFoodName').val("");
                                    //$('#inputPrice').val("");
                                }
                            });
                        }
                    },
                });
            }
        }
    }
});

$(function () {
    $("#table").DataTable({
        "ordering": true,
        "lengthMenu": [[50], [50]],
        columnDefs: [
            {
                orderable: false,
                targets: "no-sort"
            },
            {
                orderable: false,
                targets: "no-sort-image"
            }
        ],
        "order": [1, "asc"],

        "initComplete": function () {

            var column = this.api().column(6);

            var select = $('<select class="filter form-control select2" style="width:auto; margin-left:10px; height: 30px;padding: 0px 12px;"><option value="">All</option></select>')
              .appendTo('#selectTriggerFilter')
              .on('change', function () {
                  var val = $(this).val();
                  column.search(val).draw()
              });

            var offices = [];
            column.data().toArray().forEach(function (s) {
                s = s.split(',');
                s.forEach(function (d) {
                    if (!~offices.indexOf(d)) {
                        offices.push(d)
                        select.append('<option value="' + d + '">' + d + '</option>');
                    }
                })
            })
        }
    });

    //$("#table_length").css("display", "none");

    $(".mailbox-controls").appendTo($(".dataTables_length"));

    $(".dataTables_length label").css("display", "none");
});

function fileValidation() {
    var fileInput = document.getElementById('FileUpload1');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.gif)$/i;
    if (!allowedExtensions.exec(filePath)) {
        swal("Eror!", "Please upload file having extensions .jpeg/.jpg/.png/.gif only.", "error");
        fileInput.value = '';
        return false;
    }
}

