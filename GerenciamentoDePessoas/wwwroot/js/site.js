jQuery.noConflict();
(function ($) {
    $(document).ready(function () {
        $('.tabela-pessoas').DataTable(
            {
                language: {
                    url: 'https://cdn.datatables.net/plug-ins/2.3.3/i18n/pt-PT.json',
                }
            }
        );
    });

    $(document).ready(function () {
        $('#buscarTotalPessoas').click(function () {
            $('#resultado').text('');

            $.ajax({
                method: "GET",
                url: "/Pessoa/Total",
                dataType: "text",
                success: function (data) {
                    $('#resultado').text(`Total de pessoas: ${data}`);
                },
                error: function (xhr, status, error) {
                    console.error(`Erro na requisição: ${status} - ${error}`);
                    $('#resultado').text('Ocorreu um erro ao buscar o total de pessoas.');
                }
            })
        })
    });

    $(document).ready(function () {
        $('#botaoBusca').click(function () {
            var termo = $('#termoBusca').val();
            if (!termo) {
                alert('Por favor, insira um termo de busca.');
                return;
            }

            $.ajax({
                method: "GET",
                url: "/Pessoa/BuscarPessoasNome",
                data: { termo: termo }, //Query string
                success: function (data) {
                    $('#resultadoPessoa').empty();
                    if (data.length === 0) {
                        $('#resultadoPessoa').append('<li class="list-group-item">Nenhum resultado encontrado.</li>');
                    } else {
                        data.forEach(function (pessoa) {
                            //$('#resultadoPessoa').append('<li class="list-group-item">' + pessoa + '</li>')
                            $('#resultadoPessoa').append('<li class="list-group-item">' + pessoa + '</li>')
                        });
                    }
                },
                error: function () {
                    alert('Ocorreu um erro ao buscar as pessoas.');
                }

            })
        })
    });
})(jQuery);

