$(function () {
    $("#tblAccounts").DataTable({
        "ordering": true,
        "lengthMenu": [[50], [50]],
        columnDefs: [
            {
                orderable: false,
                targets: "no-sort"
            },
            {
                orderable: false,
                targets: "none-sort"
            },
            //{
            //    "width": "15%",
            //    "targets": "name"
            //},
            //{
            //    "width": "10px",
            //    "targets": "email"
            //},
        ],
        "order": [0, "desc"]
    });

    $("#tblAccounts_filter").css("display", "none");

    $("#tblAccounts_length").css("display", "none");

    $("#SearchAccounts").click(function () {

        var strSearchText = $("#searchText").val();
        var strGender = $("#gender").val();
        var strStatus = $("#status").val();

        $.ajax({
            url: "/Admin/SearchAccounts",
            type: 'POST',
            dataType: "html",
            data: {
                strSearchText: strSearchText,
                strGender: strGender,
                strStatus: strStatus
            },
        }).done(function (result) {
            $("#table-search").html(result);
        });
    });

});

function RemoveAccount(IdUser) {

    var url1 = '/Admin/GetOrderByUserID?IdUser=' + IdUser;

    $.ajax({
        type: 'GET',
        url: url1,
        dataType: 'json',
        success: function (data1) {

            if (data1 === "1") {

                swal("Error", "Can't delete this account because user having their history.", "error");

            } else {

                swal({
                    title: "Are you sure?",
                    text: "Are you sure you want to delete this Account?",
                    icon: "warning",
                    dangerMode: true
                })
                    .then(willDelete => {

                        if (willDelete) {

                            $.ajax({
                                type: "POST",
                                url: "/Admin/DeleteUserRecord?UserID=" + IdUser,
                                success: function (list) {

                                    if (list === 1) {

                                        swal({
                                            title: "Success",
                                            text: "Delete Account Successfully.",
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
            }
        }
    });
}
