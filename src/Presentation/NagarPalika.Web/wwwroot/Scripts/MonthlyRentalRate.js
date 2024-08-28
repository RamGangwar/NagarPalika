$(document).on('submit', '#frmAddEditMonthlyRentalRate', function (e) {
    debugger;
    e.preventDefault();
    if ($(this).valid()) {

        $('#progress').show();
        $.ajax({
            type: $(this).attr("method"),
            url: $(this).attr("action"),
            data: $(this).serialize(),
            datatype: "json",
            async: false,
            success: function (response) {

                if (response == null) {
                    $('#progress').hide();
                    swal("Error", "There is some error please try later!", "error");
                }
                else if (response.succeeded == true) {
                    $('#progress').hide();
                    swal({
                        title: "Success",
                        icon: "success",
                        text: response.message,
                        type: 'success',
                        button: "OK",
                        closeOnClickOutside: false
                    }).then(function () {
                        window.location.href = "/BillingMaster/MonthlyRentalRateList";
                    });

                } else if (response.succeeded == false) {
                    $('#progress').hide();
                    swal("Error!", response.message, "error");
                } else {
                    $('#progress').hide();
                    swal({
                        title: "Error!",
                        icon: "error",
                        text: "Please try again.",
                        type: "error',",
                    }).then(function () {

                    });
                }
            }
        });
    }
});

function bindMonthlyRentalRateList() {

    if ($.fn.DataTable.isDataTable('#tblMonthlyRentalRateList')) {
        $('#tblMonthlyRentalRateList').DataTable().destroy();
    }
    $('#progress').show();
    $("#tblMonthlyRentalRateList").DataTable({
        searching: false,
        "order": [],
        info: true,
        "sDom": 'Rfrtlip',
        "oLanguage": {
            "sLengthMenu": "Page Size _MENU_ ",
            "sEmptyTable": "No record found"
        },
        serverSide: true,
        processing: true,
        orderMulti: false,
        destroy: true,
        lengthChange: true,
        pageLength: 10,
        scrollY: 300,
        scrollX: true,
        scroller: true,
        "bInfo": false,
        autoWidth: false,
        lengthMenu: [[10, 20, 50, 1000], [10, 20, 50, "All"]],
        ajax: {
            url: '/BillingMaster/BindMonthlyRentalRateList',
            method: 'Post',
            type: 'Json',
            dataSrc: function (response) {
                debugger;
                $('#progress').hide();
                return response.data;

            }
        },

        "order": [],
        columns: [
            {
                'sortable': true,
                'data': 'wardName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'localityName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'roadWidthTypeName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'constructionTypeName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'constructedAreaRate',
                'className': 'textright'
            },
            {
                'sortable': true,
                'data': 'emptyAreaRate',
                'className': 'textright'
            },
            {
                'sortable': true,
                'data': 'createdOn',
                'className': 'textleft',
                "render": function (data, type, row, meta) {
                    return moment(row.createdOn).format("DD/MM/YYYY");
                }
            },
            {
                'sortable': true,
                'data': 'employeeName',
                'className': 'textleft'
            },
            {
                'sortable': false,
                'data': 'monthlyRentalRateId',
                'className': 'textleft',
                "render": function (data, type, row, meta) {
                    var renderBody = "";
                    renderBody = renderBody + '<div class="actionLink">';

                    renderBody = renderBody + '<a href="/BillingMaster/AddEditMonthlyRentalRate?Id=' + data + '" target="_blank"><img src="../img/edit.png" alt=""></a>';

                    renderBody = renderBody + '<a href="javascript:void(0)" onclick="DeleteEmp(' + data + ')" class="btnDelOrg"><img src="../img/delete.png" alt=""></a>';

                    renderBody = renderBody + '</div>';
                    return renderBody;
                }
            },

        ],
        "drawCallback": function (settings) {
            $('#progress').hide();
        },
    });

}
$(document).on('click', '.popupclose', function (e) {
    window.location.href = "/BillingMaster/MonthlyRentalRateList";
});

$(document).on('click', '#btnAddNew', function (e) {
    AddEditEmp(0);
});


function AddEditEmp(id) {

    $('#progress').show();
    $.ajax({
        type: 'GET',
        url: '/BillingMaster/AddEditMonthlyRentalRate',
        data: { Id: id },
        datatype: "content/html",
        success: function (data) {
            debugger;
            $('#addRole').empty().html(data);
            $.validator.unobtrusive.parse($("#frmAddEditMonthlyRentalRate"));
            $('#addRole').show();
            $('#addRole').addClass("modal fade show");
            $('#progress').hide();
        },
        error: function () {
            $('#progress').hide();
        }

    });
}

function DeleteEmp(degId) {
    swal({
        title: "Are you sure, You want to delete?",
        icon: "warning",
        buttons: ["No", "Yes"],//true,     
        dangerMode: true,
        closeOnClickOutside: false,
    }).then(val => {
        debugger;
        if (!val) throw null;
        $('#progress').show();
        $.ajax({
            type: 'POST',
            url: '/BillingMaster/DeleteMonthlyRentalRate',
            data: { MonthlyRentalRateId: degId },
            datatype: "json",
            success: function (response) {
                if (response.succeeded) {
                    swal({
                        title: "Success",
                        icon: "success",
                        text: response.message,
                        type: 'success',
                        closeOnClickOutside: false
                    });
                    $('#progress').hide();
                    bindMonthlyRentalRateList();
                }
                else {
                    $('#progress').hide();
                    swal("Error!", "Please try again", "error");
                }
            },
            error: function () {
                $('#progress').hide();
            }
        });
    });
    //$(".swal-button--confirm").addClass("okButtonBlue");
    //$(".swal-button--cancel").parent('div').css('float', 'right');
}