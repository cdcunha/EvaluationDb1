(function () {
    'use strict';
    angular.module('db1.avaliacao.tecnica').controller('VacancyEditCtrl', VacancyEditCtrl);

    VacancyEditCtrl.$inject = ['$routeParams', 'VacancyFactory'];

    function VacancyEditCtrl($routeParams, VacancyFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.vacancy = {};

        activate();

        function activate() {
            getVacancy();
        }

        function getVacancy() {
            VacancyFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.vacancy = response;
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }
    };
})();