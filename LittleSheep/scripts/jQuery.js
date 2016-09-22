jQuery(document).ready(function () {
    jQuery('.toggle-nav, header nav a').click(function (e) {
        jQuery('.toggle-nav').toggleClass('active');
        jQuery('.active').toggleClass('active');
    });
});