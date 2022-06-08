$(document).ready(function () {

    $("#nomeDependente").hide();
    $("#dtNascimentoDependente").hide();
    $("#labelNomeDependente").hide();
    $("#labelDtNascimentoDependente").hide();

    $("#icDependente").click(function () {

        var icDependente = $(this)[0].checked;

        if (icDependente)
        {
            $("#nomeDependente").show();
            $("#dtNascimentoDependente").val('').show();

            $("#dtNascimentoDependente").datepicker({
                weekStart: 0,
                maxViewMode: 2,
                language: "pt-BR",
                multidate: false,
                autoclose: true,
                todayHighlight: true
            });

            $("#labelNomeDependente").show();
            $("#labelDtNascimentoDependente").show();
        }
        else
        {
            $("#nomeDependente").hide();
            $("#dtNascimentoDependente").hide();
            $("#labelNomeDependente").hide();
            $("#labelDtNascimentoDependente").hide();
        }
    });

    $('#submitForm').on('click', function (e) {

        var chkicDependente = $("#icDependente")[0].checked;
        var nmPessoaAgendadaDependente = $('#nomeDependente').val();
        var dtNascimentoDependente = $('#dtNascimentoDependente').val();
        var idPaciente = $('#idPaciente').val();
        var idDisponibilidadeHorario = $('#idDisponibilidadeHorario').val();

        if (chkicDependente == true) {

            var validaCampo = true;
            var data = new Date();
            var dia = data.getDate();
            var ano = data.getFullYear();
            var mes = data.getMonth() + 1;

            if (dia < 10)
            {
                dia = "0" + dia;
            }

            if (mes < 10)
            {
                mes = "0" + mes;
            }

            var dataFormatada = dia + "/" + mes + "/" + ano;

            console.log(dataFormatada);
            console.log(dtNascimentoDependente);

            if (nmPessoaAgendadaDependente == "")
            {
                console.log('caiu no primeiro if');

                ValidarCampos('nomeDependente');

                validaCampo = false;
            }
            if (dtNascimentoDependente == "")
            {
                console.log('caiu no segundo if');

                ValidarCampos('dtNascimentoDependente');

                validaCampo = false;
            }

            if (new Date(dtNascimentoDependente).getTime() > new Date(dataFormatada).getTime())
            {
                console.log('caiu no terceiro if');

                Swal.fire({
                    text: 'A data de nascimento do Dependente não pode ser maior que a data atual.',
                    icon: 'warning',
                    confirmButtonColor: '#780f69'
                });

                validaCampo = false;
            }
            if (validaCampo == false)
            {
                return validaCampo;
            }

        }

        VerificarAgendamento(idDisponibilidadeHorario, idPaciente, chkicDependente, nmPessoaAgendadaDependente, dtNascimentoDependente);

    });
});

function ValidarCampos(idCampo) {

    document.getElementById(idCampo).style.borderColor = "red";
    document.getElementById(idCampo).placeholder = "Campo obrigatório. Por favor, preencha este campo.";
}

function VerificarAgendamento(idDisponibilidadeHorario, idPaciente, icDependente, nmPessoaDependente, dtNascimentoDependente) {
    $.ajax({
        cache: false,
        url: "/Administrador/VerificarRegrasdeAgendamento",
        type: 'GET',
        data: {
            idDisponibilidadeHorario: idDisponibilidadeHorario,
            idPaciente: idPaciente,
            icDependente: icDependente,
            nmPessoaDependente: nmPessoaDependente,
            dtNascimentoDependente: dtNascimentoDependente
        },

        success: function (result) {
            if (result.podeAgendar == false) {
                Swal.fire({
                    title: 'Deseja prosseguir?',
                    html: result.mensagem,
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#780f69',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Continuar'
                }).then((result) => {
                    if (result.value) {
                        $("#idFormularioAgendamentoPaciente").submit();
                    }
                });
            } else {
                $("#idFormularioAgendamentoPaciente").submit();
            }
        },
        error: function (result) {
            alert('Ocorreu algum erro ao confirmar o agendamento. Contate a equipe de suporte.');
        }
    });
}