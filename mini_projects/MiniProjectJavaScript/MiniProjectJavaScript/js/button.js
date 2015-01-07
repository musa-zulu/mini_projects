$(document).ready(function () {
    $("button.ajax").click(function (e) {
        e.preventDefault();
        $("#ajaxTest").load("ajaxTest.html #ajaxContent, #buttons");
    });
});

