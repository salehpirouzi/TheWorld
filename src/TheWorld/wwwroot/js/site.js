(function () {
    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $('#sidebarToggle i.fa');

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-double-left");
            $icon.addClass("fa-angle-double-right");
        } else {
            $icon.removeClass("fa-angle-double-right");
            $icon.addClass("fa-angle-double-left");
        }
    });

})();