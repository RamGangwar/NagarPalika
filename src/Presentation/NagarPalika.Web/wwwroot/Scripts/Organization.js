function bindOrgList() {
    debugger;
    if ($.fn.DataTable.isDataTable('#tblOrgList')) {
        $('#tblOrgList').DataTable().destroy();
    }
    $('#progress').show();
    $("#tblOrgList").DataTable({
        searching: false,
        "order": [],
        info: true,
        "sDom": 'Rfrtlip',
        "oLanguage": {
            "sLengthMenu": "Page Size _MENU_ ",
            "sEmptyTable": "No matching found"
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
            url: '/Masters/BindOrganizationList',
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
                'data': 'orgName',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'orgCode',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'shortName',
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
                'data': 'mobileNo',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'email',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'gstNo',
                'className': 'textleft'
            },
            {
                'sortable': true,
                'data': 'districtName',
                'className': 'textleft'
            },
            {
                'sortable': false,
                'data': 'orgId',
                'className': 'textleft',
                "render": function (data, type, row, meta) {
                    var renderBody = "";
                    renderBody = renderBody + '<div class="actionLink">';

                    renderBody = renderBody + '<a href="/Masters/EditOrganization?OrganizationId=' + data + '"><img src="../img/edit.png" alt=""></a>';

                    renderBody = renderBody + '<a href="javascript:void(0)" data-OrgId ="' + data + '" class="btnDelOrg"><img src="../img/delete.png" alt=""></a>';

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

$(document).on('click', '.btnDelOrg', function () {
    swal({
        title: "Are you sure, You want to delete?",
        icon: "warning",
        buttons: ["No", "Yes"],//true,     
        dangerMode: true,
        closeOnClickOutside: false
    }).then(val => {
        if (!val) throw null;
        $('#progress').show();
        bindOrgList();
        //$.ajax({
        //    type: "POST",
        //    url: "/Quote/DeleteQuote",
        //    data: { Id: $(this).attr("data-QuoteId") },
        //    datatype: "json",
        //    success: function (response) {
        //        console.log(response);
        //        $('#progress').hide();
        //        if (response == "") {
        //            swal("There is some error please try later !", {
        //                icon: "error",
        //                closeOnClickOutside: false
        //            });
        //        }
        //        else {
        //            if (response.succeeded == true) {
        //                swal({
        //                    title: "Success",
        //                    text: response.message,
        //                    icon: "success",
        //                    closeOnClickOutside: false
        //                });
        //                BindQuoteList();
        //            } else {
        //                swal({
        //                    title: 'Error',
        //                    text: response.message,
        //                    icon: "error",
        //                    closeOnClickOutside: false
        //                });
        //            }
        //        }
        //    }
        //})
    })
})

$(document).on('submit', '#frmAddOrganization', function (e) {
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
                        window.location.href = "/Masters/OrganizationList";
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