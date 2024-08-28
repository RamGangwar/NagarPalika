$(document).on('submit', '#frmAddEditTradeDocument', function (e) {
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
                        window.location.href = "/TradeLicence/TradeDocumentList";
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

function bindTradeDocumentList() {

    if ($.fn.DataTable.isDataTable('#tblTradeDocumentList')) {
        $('#tblTradeDocumentList').DataTable().destroy();
    }
    $('#progress').show();
    $("#tblTradeDocumentList").DataTable({
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
            url: '/TradeLicence/BindTradeDocumentList',
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
                'data': 'tradeDocumentName',
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
                'data': 'tradeDocumentId',
                'className': 'textleft',
                "render": function (data, type, row, meta) {
                    var renderBody = "";
                    renderBody = renderBody + '<div class="actionLink">';

                    renderBody = renderBody + '<a href="javascript:void(0)" data-bs-toggle="modal" data-bs-target="#addTradeDocument" onclick="AddEditTradeDocument(' + data + ')"><img src="../img/edit.png" alt=""></a>';

                    renderBody = renderBody + '<a href="javascript:void(0)" onclick="DeleteTradeDocument(' + data + ')" class="btnDelOrg"><img src="../img/delete.png" alt=""></a>';

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
    window.location.href = "/TradeLicence/TradeDocumentList";
});

$(document).on('click', '#btnAddNew', function (e) {
    AddEditTradeDocument(0);
});


function AddEditTradeDocument(id) {
    debugger;
    $('#progress').show();
    $.ajax({
        type: 'GET',
        url: '/TradeLicence/AddEditTradeDocument',
        data: { Id: id },
        datatype: "content/html",
        success: function (data) {
            debugger;
            $('#addTradeDocument').empty().html(data);
            $.validator.unobtrusive.parse($("#frmAddEditTradeDocument"));
            $('#addTradeDocument').show();
            $('#addTradeDocument').addClass("modal fade show");
            $('#progress').hide();
        },
        error: function () {
            $('#progress').hide();
        }

    });
}

function DeleteTradeDocument(degId) {
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
            url: '/TradeLicence/DeleteTradeDocument',
            data: { TradeDocumentId: degId },
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
                    bindTradeDocumentList();
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