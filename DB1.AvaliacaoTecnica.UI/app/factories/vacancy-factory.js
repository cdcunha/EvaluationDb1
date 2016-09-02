(function () {
    'use strict';

    var SETTINGS = { 'SERVICE_URL': 'http://localhost:5322/' };

    angular.module('db1.avaliacao.tecnica').factory('VacancyFactory', VacancyFactory);

    //VacancyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VacancyFactory($http, $rootScope) {
        return {
            get: get,
            getById: getById,
            post: post
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/vacancies', $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/vacancies/' + id, $rootScope.header);
        }

        function post(vacancy) {
            console.log(vacancy);
            return $http.post(SETTINGS.SERVICE_URL + 'api/vacancies', vacancy, $rootScope.header);
        }
    }
})();