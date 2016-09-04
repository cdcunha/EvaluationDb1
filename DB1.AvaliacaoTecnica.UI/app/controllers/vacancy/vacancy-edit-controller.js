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
                var erros = error.data.errors;
                for (var i = 0; i < erros.length; ++i) {
                    toastr.error(erros[i].value, 'Falha na Requisição')
                }
            }
        }
    };
})();