$(function () {

    $('#fromDate').datepicker({
        autoclose: true
    });
    $('#toDate').datepicker({
        autoclose: true
    });

    $("#tblOrder").DataTable({
        "ordering": true,
        columnDefs: [
            {
                orderable: false,
                targets: "no-sort"
            },
            {
                orderable: false,
                targets: "none-sort"
            }
        ],
        "order": [[0, 'desc']],
        "lengthMenu": [[50], [50]],
    });
    $("#tblOrder_filter").css("display", "none");
    $("#tblOrder_length").css("display", "none");
});


$("#SearchOrder").click(function () {

    if ($('#fromDate').val() != "" && $('#toDate').val() == "") {
        alert("Date to null. Select date to.");
        return false;
    } else if ($('#fromDate').val() == "" && $('#toDate').val() != "") {
        alert("Date from null. Select date from.");
        return false;
    }

    var fDate, tDate;
    fDate = Date.parse($('#fromDate').val());
    tDate = Date.parse($('#toDate').val());

    if ((fDate > tDate)) {
        alert("Date to invalid.");
        return false;
    }


    var kcName = $("#searchKC").val();
    var scName = $("#searchSC").val();
    var dateFrom = $('#fromDate').val();
    var dateTo = $('#toDate').val();


    $.ajax({
        type: 'post',
        url: "/Admin/SearchOrder?df=" + dateFrom + "&dt=" + dateTo + "&kcName=" + kcName + "&scName=" + scName,
        contentType: "html",
        success: function (result) {
            $("#table-search").html(result);
        }
    });
});
