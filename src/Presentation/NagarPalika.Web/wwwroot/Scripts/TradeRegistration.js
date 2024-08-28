$(document).on('submit', '#frmAddEditTradeRegistration', function (e) {
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
                        window.location.href = "/TradeLicence/TradeRegistrationList";
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

function bindTradeRegistrationList() {

    if ($.fn.DataTable.isDataTable('#tblTradeRegistrationList')) {
        $('#tblTradeRegistrationList').DataTable().destroy();
    }
    $('#progress').show();
    $("#tblTradeRegistrationList").DataTable({
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
            url: '/TradeLicence/BindTradeRegistrationList',
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
            
            { 'sortable': true, 'data': 'zoneName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'wardName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'localityName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'tradeCategoryName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'tradeSubCategoryName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'tradeCode', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'applicationType', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'ownerName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'fatherName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'mobileNo', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'gender', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'tradeName', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'tradeAddress', 'className': 'textcenter small' },            
            {
                'sortable': true,
                'data': 'arvEffectedDate',
                'className': 'textcenter small',
                "render": function (data, type, row, meta) {
                    return moment(row.arvEffectedDate).format("DD/MM/YYYY");
                }
            },
            { 'sortable': true, 'data': 'arrear', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'arrearFrom', 'className': 'textcenter small' },
            { 'sortable': true, 'data': 'arrearTill', 'className': 'textcenter small' },
                       
            {
                'sortable': true,
                'data': 'createdOn',
                'className': 'textcenter small',
                "render": function (data, type, row, meta) {
                    return moment(row.createdOn).format("DD/MM/YYYY");
                }
            },
            {
                'sortable': true,
                'data': 'employeeName',
                'className': 'textcenter small'
            },
            {
                'sortable': false,
                'data': 'tradeRegistrationId',
                'className': 'textcenter ',
                "render": function (data, type, row, meta) {
                    var renderBody = "";
                    renderBody = renderBody + '<div class="actionLink">';

                    //renderBody = renderBody + '<a href="javascript:void(0)" data-bs-toggle="modal" data-bs-target="#addTradeRegistration" onclick="AddEditTradeRegistration(' + data + ')"><img src="../img/edit.png" alt=""></a>';
                    renderBody = renderBody + '<a href="/TradeLicence/AddEditTradeRegistration?Id=' + data + '" target="_blank"><img src="../img/edit.png" alt=""></a>';

                    renderBody = renderBody + '<a href="javascript:void(0)" onclick="DeleteTradeRegistration(' + data + ')" class="btnDelOrg"><img src="../img/delete.png" alt=""></a>';

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

function DeleteTradeRegistration(degId) {
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
            url: '/TradeLicence/DeleteTradeRegistration',
            data: { TradeRegistrationId: degId },
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
                    bindTradeRegistrationList();
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