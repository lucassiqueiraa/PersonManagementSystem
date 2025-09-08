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
})(jQuery);