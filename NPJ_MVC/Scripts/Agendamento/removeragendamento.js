$(document).ready(function () {
    $('[id*="btn-removeagendamento_').each(function () {
        $(this).on("click", function (e) {
            cliqueBotao($(this).attr("id").split("_")[1]);
            $(this).hide();
        });
    });      
    function cliqueBotao(idAgendamentoParam) {
        
        $.ajax({
            type: "POST",
            url: "/Agendamento/RemoverAgendamento",
            dataType: "text",
            data: { idAgendamento: idAgendamentoParam },
            cache: false,
            success: function (response) {
                alert("Agendamento removido com sucesso!");
                location.reload(true);
            },
            error: function (response) {
                alert("Error! Entre em contato com a Equipe de Suporte.");
                location.reload(true);
            }
        });
    }

});
