$(document).ready(function () {

    //Mínimo de 8 chars
    var bad = /(?=.{8,}).*/;
    //Letras + minimo de 8 chars
    var good = /^(?=\S*?[a-z])(?=\S*?[0-9])\S{8,}$/;
    //Deve conter pelo menos uma letra em caixa alta, uma letra em caixa baixa e (um numero OU um char especial).
    var better = /^(?=\S*?[A-Z])(?=\S*?[a-z])((?=\S*?[0-9])|(?=\S*?[^\w\*]))\S{8,}$/;
     //Deve conter pelo menos uma letra em caixa alta, uma letra em caixa baixa e (um numero E um char especial).
    var best = /^(?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9])(?=\S*?[^\w\*])\S{8,}$/;

    $('#passwordcadastro').on('keyup', function () {
        var password = $(this);
        var pass = password.val();
        var passLabel = $('[for="password"]');
        var stength = 'Weak';
        var pclass = 'danger';
        if (best.test(pass) == true) {
            stength = 'Muito forte';
            pclass = 'success';
        } else if (better.test(pass) == true) {
            stength = 'Forte';
            pclass = 'warning';
        } else if (good.test(pass) == true) {
            stength = 'Quase forte';
            pclass = 'warning';
        } else if (bad.test(pass) == true) {
            stength = 'Fraca';
        } else {
            stength = 'Muito fraca';
        }

        var popover = password.attr('data-content', stength).data('bs.popover');
        popover.setContent();
        popover.$tip.addClass(popover.options.placement).removeClass('danger success info warning primary').addClass(pclass);

    });

    $('input[data-toggle="popover"]').popover({
        placement: 'top',
        trigger: 'focus'
    });

})