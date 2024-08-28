$(document).on('submit', '#frmAddEditRoadWidthType', function (e) {
    debugger;
    e.preventDefault();
    if ($(this).valid()) {

        $('#progress').show();
        var formData = new FormData(this);

        $.ajax({
            type: $(this).attr("method"),
            url: $(this).attr("action"),
            data: formData,
            contentType: false,
            processData: false,
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
                        window.location.href = "/BillingMaster/RoadWidthTypeList";
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

function bindRoadWidthTypeList() {

    if ($.fn.DataTable.isDataTable('#tblRoadWidthTypeList')) {
        $('#tblRoadWidthTypeList').DataTable().destroy();
    }
    $('#progress').show();
    $("#tblRoadWidthTypeList").DataTable({
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
            url: '/BillingMaster/BindRoadWidthTypeList',
            method: 'Post',
            type: 'Json',
            dataSrc: function (response) {
                //$('#spnTotalAddressType').empty().html(response.recordsTotal);
                $('#progress').hide();
                return response.data;

            }
        },

        "order": [],
        columns: [
            
            {
                'sortable': true,
                'data': 'roadWidthTypeName',
                'className': 'textleft'
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
                'data': 'roadWidthTypeId',
                'className': 'textleft',
                "render": function (data, type, row, meta) {
                    var renderBody = "";
                    renderBody = renderBody + '<div class="actionLink">';

                    renderBody = renderBody + '<a href="javascript:void(0)" data-bs-toggle="modal" data-bs-target="#addRoadWidthType" onclick="AddEditRoadWidthType(' + data + ')"><img src="../img/edit.png" alt=""></a>';

                    renderBody = renderBody + '<a href="javascript:void(0)" onclick="DeleteRoadWidthType(' + data + ')" class="btnDelOrg"><img src="../img/delete.png" alt=""></a>';

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
    window.location.href = "/BillingMaster/RoadWidthTypeList";
});

$(document).on('click', '#btnAddNew', function (e) {
    AddEditRoadWidthType(0);
});


function AddEditRoadWidthType(id) {
    debugger;
    $('#progress').show();
    $.ajax({
        type: 'GET',
        url: '/BillingMaster/AddEditRoadWidthType',
        data: { Id: id },
        datatype: "content/html",
        success: function (data) {
            debugger;
            $('#addRoadWidthType').empty().html(data);
            $.validator.unobtrusive.parse($("#frmAddEditRoadWidthType"));
            $('#addRoadWidthType').show();
            $('#addRoadWidthType').addClass("modal fade show");
            $('#progress').hide();
        },
        error: function () {
            $('#progress').hide();
        }

    });
}

function DeleteRoadWidthType(degId) {
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
            url: '/BillingMaster/DeleteRoadWidthType',
            data: { RoadWidthTypeId: degId },
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
                    bindRoadWidthTypeList();
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