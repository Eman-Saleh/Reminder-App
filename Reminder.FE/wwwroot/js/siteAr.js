

$(document).ready(function () {
    $("input[type=text],input[type=textarea]").attr('spellcheck', false);
    $("input[type=text],input[type=textarea]").attr('autocomplete', "off");
    $("input[type=text],input[type=textarea]").attr('autocorrect', "off");
    $("input[type=text],input[type=textarea]").attr('autocapitalize', "off");
    //$('.Datemask').inputmask('99/99/9999');

    //var ctx = document.getElementById('myChart')
    $("select").select2();
    $("select#culture").select2('destroy');
    $('select#edit_customleave_select_to').select2('destroy');

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
            dateFormat: 'dd-mm-yyyy'
        });
        $(dateField).prop("readonly", true);

    }
    var t = $('#exampleDesc').DataTable({
        "searching": false,
        "paging": false,
        "ordering": false,
        "info": false,
        "language": {



            "sEmptyTable": "لا توجد بيانات متاحة في الجدول",

        },

    });

    //var t2 = $('#example:not(.dtr-inline)').DataTable({
    //    "searching": false,
    //    "paging": false,
    //    "ordering": false,
    //    "info": false,
    //    "language": {



    //        "sEmptyTable": "ليست هناك بيانات متاحة في الجدول",

    //    },




    //});

    $("#listv").click(function () {
        $('#listTable').removeClass("d-none");
        $('#gridT').hide();


    });
    $("#gridv").click(function () {

        $('#listTable').addClass("d-none");
        $('#gridT').show();


    });
    addDatePicker('.DateTime_Picker', 'bottom center');
    $('#exampletask:not(.dtr-inline)').DataTable(

        {

            "language": {



                "sEmptyTable": "لا توجد بيانات متاحة في الجدول",
                "sLoadingRecords": "جارٍ التحميل...",
                "sProcessing": "جارٍ التحميل...",
                "sLengthMenu": "أظهر _MENU_ مدخلات",
                "sZeroRecords": "لم يعثر على أية سجلات",
                "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
                "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجل",
                "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
                "sSearch": "ابحث:",
                "oPaginate": {
                    "sFirst": "الأول",
                    "sPrevious": "السابق",
                    "sNext": "التالي",
                    "sLast": "الأخير"
                },
                "oAria": {
                    "sSortAscending": ": تفعيل لترتيب العمود تصاعدياً",
                    "sSortDescending": ": تفعيل لترتيب العمود تنازلياً"
                },
                "select": {
                    "rows": {
                        "_": "%d قيمة محددة",
                        "0": "",
                        "1": "1 قيمة محددة"
                    }
                },
                "buttons": {
                    "print": "طباعة",
                    "colvis": "الأعمدة الظاهرة",
                    "copy": "نسخ إلى الحافظة",
                    "copyTitle": "نسخ",
                    "copyKeys": "زر <i>ctrl</i> أو <i>\u2318</i> + <i>C</i> من الجدول<br>ليتم نسخها إلى الحافظة<br><br>للإلغاء اضغط على الرسالة أو اضغط على زر الخروج.",
                    "copySuccess": {
                        "_": "%d قيمة نسخت",
                        "pageLength": {
                            "1": "1 قيمة نسخت"
                        },
                        "-1": "اظهار الكل",
                        "_": "إظهار %d أسطر"
                    }
                },
            },
        });
    $('#exampletaskLog:not(.dtr-inline)').DataTable(

        {
            "ordering": false,

            "language": {



                "sEmptyTable": "لا توجد بيانات متاحة في الجدول",
                "sLoadingRecords": "جارٍ التحميل...",
                "sProcessing": "جارٍ التحميل...",
                "sLengthMenu": "أظهر _MENU_ مدخلات",
                "sZeroRecords": "لم يعثر على أية سجلات",
                "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
                "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجل",
                "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
                "sSearch": "ابحث:",
                "oPaginate": {
                    "sFirst": "الأول",
                    "sPrevious": "السابق",
                    "sNext": "التالي",
                    "sLast": "الأخير"
                },
                "oAria": {
                    "sSortAscending": ": تفعيل لترتيب العمود تصاعدياً",
                    "sSortDescending": ": تفعيل لترتيب العمود تنازلياً"
                },
                "select": {
                    "rows": {
                        "_": "%d قيمة محددة",
                        "0": "",
                        "1": "1 قيمة محددة"
                    }
                },
                "buttons": {
                    "print": "طباعة",
                    "colvis": "الأعمدة الظاهرة",
                    "copy": "نسخ إلى الحافظة",
                    "copyTitle": "نسخ",
                    "copyKeys": "زر <i>ctrl</i> أو <i>\u2318</i> + <i>C</i> من الجدول<br>ليتم نسخها إلى الحافظة<br><br>للإلغاء اضغط على الرسالة أو اضغط على زر الخروج.",
                    "copySuccess": {
                        "_": "%d قيمة نسخت",
                        "pageLength": {
                            "1": "1 قيمة نسخت"
                        },
                        "-1": "اظهار الكل",
                        "_": "إظهار %d أسطر"
                    }
                },
            }
        });

    var table = $('#example2:not(.dtr-inline)').DataTable(

        {

            "language": {



                "sEmptyTable": "لا توجد بيانات متاحة في الجدول",
                "sLoadingRecords": "جارٍ التحميل...",
                "sProcessing": "جارٍ التحميل...",
                "sLengthMenu": "أظهر _MENU_ مدخلات",
                "sZeroRecords": "لم يعثر على أية سجلات",
                "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
                "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجل",
                "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
                "sSearch": "ابحث:",
                "oPaginate": {
                    "sFirst": "الأول",
                    "sPrevious": "السابق",
                    "sNext": "التالي",
                    "sLast": "الأخير"
                },
                "oAria": {
                    "sSortAscending": ": تفعيل لترتيب العمود تصاعدياً",
                    "sSortDescending": ": تفعيل لترتيب العمود تنازلياً"
                },
                "select": {
                    "rows": {
                        "_": "%d قيمة محددة",
                        "0": "",
                        "1": "1 قيمة محددة"
                    }
                },
                "buttons": {
                    "print": "طباعة",
                    "colvis": "الأعمدة الظاهرة",
                    "copy": "نسخ إلى الحافظة",
                    "copyTitle": "نسخ",
                    "copyKeys": "زر <i>ctrl</i> أو <i>\u2318</i> + <i>C</i> من الجدول<br>ليتم نسخها إلى الحافظة<br><br>للإلغاء اضغط على الرسالة أو اضغط على زر الخروج.",
                    "copySuccess": {
                        "_": "%d قيمة نسخت",
                        "pageLength": {
                            "1": "1 قيمة نسخت"
                        },
                        "-1": "اظهار الكل",
                        "_": "إظهار %d أسطر"
                    }
                },
            },
            scrollY: 300,
            scrollCollapse: true,
            paging: true,
            info: true,
            searching: true,
            mark: true,
            select: {
                style: 'os',
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
                Text:'طباعه اكسل',
                exportOptions: {
                    columns: [1, 2, 3, 4, 5, 6]
                }

            }
        ],
        "language": {



            "sEmptyTable": "لا توجد بيانات متاحة في الجدول",
            "sLoadingRecords": "جارٍ التحميل...",
            "sProcessing": "جارٍ التحميل...",
            "sLengthMenu": "أظهر _MENU_ مدخلات",
            "sZeroRecords": "لم يعثر على أية سجلات",
            "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
            "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجل",
            "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
            "sSearch": "ابحث:",
            "oPaginate": {
                "sFirst": "الأول",
                "sPrevious": "السابق",
                "sNext": "التالي",
                "sLast": "الأخير"
            },
            "oAria": {
                "sSortAscending": ": تفعيل لترتيب العمود تصاعدياً",
                "sSortDescending": ": تفعيل لترتيب العمود تنازلياً"
            },
            "select": {
                "rows": {
                    "_": "%d قيمة محددة",
                    "0": "",
                    "1": "1 قيمة محددة"
                }
            },
            "buttons": {
                "print": "طباعة",
                "colvis": "الأعمدة الظاهرة",
                "copy": "نسخ إلى الحافظة",
                "copyTitle": "نسخ",
                "copyKeys": "زر <i>ctrl</i> أو <i>\u2318</i> + <i>C</i> من الجدول<br>ليتم نسخها إلى الحافظة<br><br>للإلغاء اضغط على الرسالة أو اضغط على زر الخروج.",
                "copySuccess": {
                    "_": "%d قيمة نسخت",
                    "pageLength": {
                        "1": "1 قيمة نسخت"
                    },
                    "-1": "اظهار الكل",
                    "_": "إظهار %d أسطر"
                }
            },
        },

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

