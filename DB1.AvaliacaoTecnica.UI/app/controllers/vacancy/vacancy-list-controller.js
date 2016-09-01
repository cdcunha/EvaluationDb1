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
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }
    };
})();