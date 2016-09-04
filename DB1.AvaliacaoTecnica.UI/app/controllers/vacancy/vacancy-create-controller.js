(function () {
    'use strict';
    angular.module('db1.avaliacao.tecnica').controller('VacancyCreateCtrl', VacancyCreateCtrl);

    VacancyCreateCtrl.$inject = ['$scope', '$location', 'VacancyFactory'];

    function VacancyCreateCtrl($scope, $location, VacancyFactory) {
        var vm = this;
        vm.vacancies = [];
        vm.vacancy = {
            description: '',
            price: 0,
            image: '',
            quantityOnHand: 0
        };
        vm.croppedImage = '';
        vm.save = save;

        /*activate();

        function activate() {
            getTechnologies();
        }

        function getTechnologies() {
            TechnologyFactory.get()
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.technologies = response;
            }

            function fail(error) {
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else
                    toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }*/

        function save() {
            VacancyFactory.post(vm.vacancy)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Vaga <strong>' + response.description + '</strong> cadastrada com sucesso', 'Vaga Cadastrada');
                $location.path('/vacancies');
            }

            function fail(error) {
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else {
                    var erros = error.data.errors;
                    for (var i = 0; i < erros.length; ++i) {
                        toastr.error(erros[i].value, 'Falha na Requisição')
                    }
                }   
            }
        }

        /*var handleFileSelect = function (evt) {
            var file = evt.currentTarget.files[0];
            var reader = new FileReader();
            reader.onload = function (evt) {
                $scope.$apply(function ($scope) {
                    vm.vacancy.image = evt.target.result;
                });
            };
            reader.readAsDataURL(file);
        };
        angular.element(document.querySelector('#file')).on('change', handleFileSelect);
        */
    };
})();