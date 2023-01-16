$(document).ready(function () {

  

    $('a.link-custom').on('click', function (e) {
        sessionStorage.setItem('lastTab', $(this).attr('href'));
    });



    var lastTab = sessionStorage.getItem('lastTab');
    if (lastTab) {

        $('[href="' + lastTab + '"]').addClass('active');
        $('[href="' + lastTab + '"]').siblings().removeClass('active');



    }

    $("[data-bs-toggle=tooltip").tooltip()

    //$('#example').DataTable();
});