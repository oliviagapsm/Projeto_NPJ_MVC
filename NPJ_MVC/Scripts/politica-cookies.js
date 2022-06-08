$(document).ready(function () {
    $(document).on("click", "#btnAceitarPoliticasCookies", function () {
        $.ajax({
            async: true,
            url: "/politicas/aceitarcookies",
            method: "post"
        });

        $("#cookiesPoliticas").hide();
    });
});