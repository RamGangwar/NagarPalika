$(document).ready(function () {

    $(".hamburger").click(function (event) {
        $('.mainCon').toggleClass('active');
        $(this).toggleClass('active');
        setTimeout(function () {
            $('.dataTables_scrollHeadInner').toggleClass('scrollHeadInner_dataTables');
            $(this).toggleClass('scrollHeadInner_dataTables');
        }, 100);

    });

    $('.checkInpt').each(function () {
        $(this).wrap("<span class='checkWrapper'></span>");
        $(this).after("<i class='bg'></i>");
    });

    $('.radioInpt').each(function () {
        $(this).wrap("<span class='radioWrapper'></span>");
        $(this).after("<i class='bg'></i>");
    });

    $('.show-password').click(function () {
        $(this).toggleClass('active');
        var input = $(this).prev();
        input.attr('type', input.attr('type') === 'password' ? 'text' : 'password');
    });

    $(".showPopup").click(function () {
        var popupId = $(this).attr("data-");
        $('body').addClass('active');
        $(".overlay").hide(0);
        $(popupId).fadeIn('300');
    });

    $(".newPopup").click(function () {
        $('#success').show();
        $('#updated').hide();
    });
    $(".sucessPopup").click(function () {
        $('#success').hide();
        $('#updated').show();
    });


    $(".closePopup, .close").click(function () {
        $(".overlay").hide(0);
        $('body').removeClass('active');
    });

    $("input[name=account]:radio").click(function () {
        if ($('input[name=account]:checked').val() == "Username") {
            $('#acctype').text('Username');

        } else if ($('input[name=account]:checked').val() == "Email") {
            $('#acctype').text('Email');

        }
    });

    $('#select_all').on('click', function () {
        if (this.checked) {
            $('.checkbox').each(function () {
                this.checked = true;
            });
        } else {
            $('.checkbox').each(function () {
                this.checked = false;
            });
        }
    });

    $('.checkbox').on('click', function () {
        if ($('.checkbox:checked').length == $('.checkbox').length) {
            $('#select_all').prop('checked', true);
        } else {
            $('#select_all').prop('checked', false);
        }
    });


    $('#select_all2').on('click', function () {
        if (this.checked) {
            $('.checkbox2').each(function () {
                this.checked = true;
            });
        } else {
            $('.checkbox2').each(function () {
                this.checked = false;
            });
        }
    });

    $('.checkbox2').on('click', function () {
        if ($('.checkbox2:checked').length == $('.checkbox2').length) {
            $('#select_all2').prop('checked', true);
        } else {
            $('#select_all2').prop('checked', false);
        }
    });

    $(".showMenu").click(function () {
        $(".subMenu").slideUp(300);
        if ($(this).parent("li").hasClass("active")) {
            $("li").removeClass("active");
            $(this).next(".subMenu").slideUp(300);
        }
        else {
            $("li").removeClass("active");
            $(this).parent("li").addClass("active");
            $(this).next(".subMenu").slideDown(300);
        }
    });

    $(".showSubMenu").click(function () {
        $(".innerMenu").slideUp(300);
        if ($(this).parent("li").hasClass("inerActive")) {
            $("li").removeClass("inerActive");
            $(this).next(".innerMenu").slideUp(300);
        }
        else {
            $("li").removeClass("inerActive");
            $(this).parent("li").addClass("inerActive");
            $(this).next(".innerMenu").slideDown(300);
        }
    });



    $(".aslQ .firstCol").click(function () {
        $(this).toggleClass('active');
        $(this).parent('.aslQ').next('.aslA').slideToggle('300');
    });

    $(".showSubASL").click(function () {
        $(this).toggleClass('active');
        $(this).parent('.aslSubBox').next('.aslSubInner').slideToggle('300');
    });



    $(".filterLink").click(function () {
        $('.filterBox').toggleClass('active');
    });

    $(".showVerification").click(function () {
        $('#verificationBox').slideDown('300');
    });

    $(".showAccount").click(function (event) {
        event.stopPropagation();
        $('.accountPopup').slideToggle('300');
    });
    $(".accountPopup").click(function (event) {
        event.stopPropagation();
    });
    $("body").click(function () {
        $('.accountPopup').hide(0);
    });

    $('.upload_attch_file').change(function (e) {
        $('.browseMessageShow').html(e.target.files[0].name);
    });

    $(".showOneInstaller").click(function () {
        $('#installerType').hide(0);
        $('#oneInstaller').show(0);
    });
    $(".showMultipleInstaller").click(function () {
        $('#installerType').hide(0);
        $('#multipleInstallers').show(0);
    });
    $(".showOrder").click(function () {
        $('#oneInstaller').hide(0);
        $('#multipleInstallers').hide(0);
        $('#orderSequence').show(0);
    });



    //$(".showoccupiedUnit").click(function () {
    //    if ($(this).val() == "Occupied Unit") { //$(this).is(":checked")) {
    //        $(".occupiedUnitBox").slideDown(300);
    //    } else {
    //        $(".occupiedUnitBox").slideUp(200);
    //    }
    //});

    $(".showCarpet").click(function () {
        if ($(this).is(":checked")) {
            $("#carpetBox").slideDown(300);
        } else {
            $("#carpetBox").slideUp(200);
        }
    });

    $(".showVinyl").click(function () {
        if ($(this).is(":checked")) {
            $("#vinylBox").slideDown(300);
        } else {
            $("#vinylBox").slideUp(200);
        }
    });

    $(".showPlank").click(function () {
        if ($(this).is(":checked")) {
            $("#plankBox").slideDown(300);
        } else {
            $("#plankBox").slideUp(200);
        }
    });

    //$(".showpadOption").click(function () {
    //    if ($(this).val() == "IsCptRepairPatch") { //.is(":checked")) {
    //        $("#padOption").slideDown(0);
    //        $("#padOptionWrrnty").slideUp(0);
    //    }
    //    else if ($(this).val() == "IsCptWarranty") {
    //        $("#padOption").slideUp(0);
    //        $("#padOptionWrrnty").slideDown(0);
    //    } else {
    //        $("#padOption").slideUp(0);
    //        $("#padOptionWrrnty").slideUp(0);
    //    }
    //});

    $(".showUsualselecton").click(function () {
        if ($(this).val() == "IsCptTransLikeNewTransitions") {//.is(":checked")) {
            $("#usualselecton").slideDown(0);
        } else {
            $("#usualselecton").slideUp(0);
        }
    });

    //$(".VnylShowpadOption").click(function () {
    //    if ($(this).val() == "IsVnylRepairPatch") { //.is(":checked")) {
    //        $("#divVnylBaseOption").slideDown(0);
    //        $("#divVnylWrrntyOption").slideUp(0);

    //    } else {
    //        $("#divVnylBaseOption").slideUp(0);
    //        $("#divVnylWrrntyOption").slideDown(0);

    //    }
    //});

    //$(".PlnkShowpadOption").click(function () {
    //    if ($(this).val() == "IsPlnkRepairPatch") { //.is(":checked")) {
    //        $("#divPlnkBaseOption").slideDown(0);
    //        $("#divPlnkWrrntyOption").slideUp(0);

    //    } else {
    //        $("#divPlnkBaseOption").slideUp(0);
    //        $("#divPlnkWrrntyOption").slideDown(0);

    //    }
    //});

    $(".showBIVinyl").click(function () {
        if ($(this).val() == "IsVnylBaseNewBase") {//.is(":checked")) {
            $(".BIVinyl").slideDown(0);
        } else {
            $(".BIVinyl").slideUp(0);
        }
    });

    $(".showBIPlank").click(function () {
        if ($(this).val() == "IsPlnkBaseNewBase") { //.is(":checked")) {
            $(".BIPlank").slideDown(0);
        } else {
            $(".BIPlank").slideUp(0);
        }
    });

    $(".unitTab li a").click(function (event) {
        event.preventDefault();
        $(this).parent().addClass("active");
        $(this).parent().siblings().removeClass("active");
        //var tab = $(this).attr("data-");
        //$(".installBox").not(tab).hide(0);
        //$(tab).show(0);
    });

    setTimeout(function () {
        $(".addTableBox").on('click', '.hd', function () {
            $(this).toggleClass('active');
            $(this).parent('.addTableBox').next('.addTableOuter').slideToggle('100');
            $('.defaultdatatableheader').DataTable({
                searching: false,
                "order": [],
                info: false,
                "sDom": 'Rfrtlip',
                "oLanguage": {
                    "sLengthMenu": "Page Size _MENU_ ",
                },
                orderMulti: false,
                "ordering": false,
                destroy: true,
                lengthChange: true,
                pageLength: 10,
                scrollY: 350,
                scrollX: true,
                scroller: true,
                "bInfo": false,
                lengthMenu: [[10, 20, 50, 1000], [10, 20, 50, "All"]]
            });
        });
    }, 5000);

    //setTimeout(function () {
    //    $(".totlnote").click(function () {
    //        $(this).parent(".addTableBox").next(".addnoteTble").slideToggle();
    //    });
    //}, 3000);

    setTimeout(function () {
        $(".showhidetable").on('click', '.hd', function () {
            $(this).toggleClass('active');
            $(this).parents('.showhidetable').next('.addTableOuter').slideToggle('100');
            $('.defaultdatatableheader').DataTable({
                searching: false,
                "order": [],
                info: false,
                "sDom": 'Rfrtlip',
                "oLanguage": {
                    "sLengthMenu": "Page Size _MENU_ ",
                },
                orderMulti: false,
                "ordering": false,
                destroy: true,
                lengthChange: true,
                pageLength: 10,
                scrollY: 350,
                scrollX: true,
                scroller: true,
                "bInfo": false,
                lengthMenu: [[10, 20, 50, 1000], [10, 20, 50, "All"]]
            });
        });
    }, 5000);

    // After page referece menu heilighted
    var url = window.location.pathname,
        urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
    $('.lftMenu a').each(function () {
        if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
            $(this).addClass('active-2');
        }
    });

});


