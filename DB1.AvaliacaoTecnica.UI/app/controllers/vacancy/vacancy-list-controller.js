(function () {
    'use strict';
    angular.module('db1.avaliacao.tecnica').controller('VacancyListCtrl', VacancyListCtrl);

    VacancyListCtrl.$inject = ['VacancyFactory'];

    function VacancyListCtrl(VacancyFactory) {
        var vm = this;
        vm.vacancies = [];

        activate();

        function activate() {
            getVacancies();
        }

        function getVacancies() {
            VacancyFactory.get()
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.vacancies = response;
            }

            function fail(error) {
                var erros = error.data.errors;
                for (var i = 0; i < erros.length; ++i) {
                    toastr.error(erros[i].value, 'Falha na Requisição')
                }
            }
        }
    };
})();