(function () {
    'use strict';
    angular.module('db1.avaliacao.tecnica').controller('TechnologyCtrl', TechnologyCtrl);

    TechnologyCtrl.$inject = ['TechnologyFactory'];

    function TechnologyCtrl(TechnologyFactory) {
        var vm = this;
        vm.technologies = [];
        vm.technology = {
            id: 0,
            title: ''
        };
        vm.saveTechnology = saveTechnology;
        vm.loadTechnology = loadTechnology;
        vm.cancel = cancel;
        vm.removeTechnology = removeTechnology;

        activate();

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
        }

        function saveTechnology() {
            if (vm.technology.id == 0) {
                addTechnology();
            } else {
                updateTechnology();
            }
        }

        function addTechnology() {
            TechnologyFactory.post(vm.technology)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.technologies.push(response);
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
            clearTechnology();
        }

        function updateTechnology() {
            TechnologyFactory.put(vm.technology)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Tecnologia <strong>' + response.title + '</strong> alterada com sucesso', 'Sucesso');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
            clearTechnology();
        }

        function removeTechnology(technology) {
            loadTechnology(technology);
            TechnologyFactory.remove(vm.technology)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Tecnologia <strong>' + response.title + '</strong> removida com sucesso', 'Sucesso');
                var index = vm.technologies.indexOf(technology);
                vm.technologies.splice(index, 1);
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }

            clearTechnology();
        }

        function loadTechnology(technology) {
            vm.technology = technology;
        }

        function cancel() {
            clearTechnology();
        }

        function clearTechnology() {
            vm.technology = {
                id: 0,
                title: ''
            };
        }
    };
})();