$(document).on('submit', '#frmAddEditEmployee', function (e) {
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
                        window.location.href = "/Masters/EmployeeList";
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

function bindEmpList() {

    if ($.fn.DataTable.isDataTable('#tblEmpList')) {
        $('#tblEmpList').DataTable().destroy();
    }
    $('#progress').show();
    $("#tblEmpList").DataTable({
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
            url: '/Masters/BindEmployeeList',
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
                'data': 'employeeName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'userName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'fatherName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'mobileNo',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'emailId',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'departmentName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'designationName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'fullAddress',
                'className': 'textleft'
            },
            {
                'sortable': false,
                'data': 'employeeId',
                'className': 'textleft',
                "render": function (data, type, row, meta) {
                    var renderBody = "";
                    renderBody = renderBody + '<div class="actionLink">';

                    renderBody = renderBody + '<a href="/Masters/AddEditEmployee?Id=' + data + '" target="_blank"><img src="../img/edit.png" alt=""></a>';

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
    window.location.href = "/Masters/EmployeeList";
});

$(document).on('click', '#btnAddNew', function (e) {
    AddEditEmp(0);
});


function AddEditEmp(id) {

    $('#progress').show();
    $.ajax({
        type: 'GET',
        url: '/Masters/AddEditEmployee',
        data: { Id: id },
        datatype: "content/html",
        success: function (data) {
            debugger;
            $('#addRole').empty().html(data);
            $.validator.unobtrusive.parse($("#frmAddEditEmployee"));
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
            url: '/Masters/DeleteEmployee',
            data: { EmployeeId: degId },
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
                    bindEmpList();
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