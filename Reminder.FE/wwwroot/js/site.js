

$(document).ready(function () {
       $("body").on('click', '#toggleNewPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $("#NewPassword");
        //const type = input.getAttribute('type') === 'password' ? 'text' : 'password';
        //password.setAttribute('type', type);
        if (input.attr("type") === "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }

    });
    $("body").on('click', '#togglePassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $("#Password");
        //const type = input.getAttribute('type') === 'password' ? 'text' : 'password';
        //password.setAttribute('type', type);
        if (input.attr("type") === "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }

    });
    $("body").on('click', '#toggleConfirmPassword', function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $("#ConfirmPassword");
        //const type = input.getAttribute('type') === 'password' ? 'text' : 'password';
        //password.setAttribute('type', type);
        if (input.attr("type") === "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }

    });
    function addDatePicker(dateField, FieldDateposition) {
        FieldDateposition = typeof FieldDateposition !== 'undefined' ? FieldDateposition : 'top center';

        $(dateField).datepicker({
            language: 'en',
            position: FieldDateposition,
            dateFormat: 'dd/mm/yyyy'
        });
        //$(dateField).prop("readonly", true);

    }
   
    $("#listv").click(function () {
        $('#listTable').removeClass("d-none");
        $('#gridT').hide();


    });
    $("#gridv").click(function () {

        $('#listTable').addClass("d-none");
        $('#gridT').show();


    });
    addDatePicker('.DateTime_Picker', 'bottom center');
    $('#table:not(.dtr-inline)').DataTable();
    var table = $('#example2:not(.dtr-inline)').DataTable({
        scrollY: 300,
        scrollCollapse: true,
        paging: true,
        info: true,
        searching: true,
        mark: true,
        select: {
            style: 'multi',

            selector: 'td:first-child'
        },
        columnDefs: [{
            targets: 0,
            width: 20,
            orderable: false,
            className: 'select-checkbox'
        },
        {
            targets: 1,
            //render: function (data, type, row) {
            //    return type === 'display' && data.length > 10 ?
            //        '<span data-toggle="tooltip" data-html="true" data-placement="right" title="' +
            //        data.replace(/"/g, "&quot;") + '">' +
            //        data.substr(0, 10) + '...</span>' : data;
            //}
        }
        ],
        order: [
            [1, 'desc']
        ]
    });
    $('#table2:not(.dtr-inline)').DataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'excel',
                exportOptions: {
                    columns: [1, 2, 3, 4,5,6]
                }

            }
        ]
    });

    $('#example2:not(.dtr - inline)').on('draw.dt', function () {
        $('[data-toggle="tooltip"]').tooltip();
    });

    $('#checkBox').on('click', function () {
        if ($('#checkBox').is(':checked')) {
            table.rows().select();
        }
        else {
            table.rows().deselect();
        }
    });
    //Toggle the side navigation
    $("#sidebarToggle, #sidebarToggleTop").on('click', function (e) {
        $("body").toggleClass("sidebar-toggled");
        $(".sidebar").toggleClass("toggled");
        if ($(".sidebar").hasClass("toggled")) {
            $('.sidebar .collapse').collapse('hide');
        };
    });

    // Close any open menu accordions when window is resized below 768px
    $(window).resize(function () {
        if ($(window).width() < 768) {
            $('.sidebar .collapse').collapse('hide');
        };

        // Toggle the side navigation when window is resized below 480px
        if ($(window).width() < 480 && !$(".sidebar").hasClass("toggled")) {
            $("body").addClass("sidebar-toggled");
            $(".sidebar").addClass("toggled");
            $('.sidebar .collapse').collapse('hide');
        };
    });

    // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
    $('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function (e) {
        if ($(window).width() > 768) {
            var e0 = e.originalEvent,
                delta = e0.wheelDelta || -e0.detail;
            this.scrollTop += (delta < 0 ? 1 : -1) * 30;
            e.preventDefault();
        }
    });

    // Scroll to top button appear
    $(document).on('scroll', function () {
        var scrollDistance = $(this).scrollTop();
        if (scrollDistance > 100) {
            $('.scroll-to-top').fadeIn();
        } else {
            $('.scroll-to-top').fadeOut();
        }
    });

    // Smooth scrolling using jQuery easing
    $(document).on('click', 'a.scroll-to-top', function (e) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: ($($anchor.attr('href')).offset().top)
        }, 1000, 'easeInOutExpo');
        e.preventDefault();
    });
});