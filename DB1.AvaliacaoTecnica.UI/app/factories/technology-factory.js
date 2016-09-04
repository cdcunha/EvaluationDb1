(function () {
    'use strict';
    var SETTINGS = { 'SERVICE_URL': 'http://localhost:5322/' };

    angular.module('db1.avaliacao.tecnica').factory('TechnologyFactory', TechnologyFactory);

    //TechnologyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    //function TechnologyFactory($http, $rootScope, SETTINGS) {
    function TechnologyFactory($http, $rootScope) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove
        }

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/technologies', $rootScope.header);
        }

        function post(technology) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/technologies', technology, $rootScope.header);
        }

        function put(technology) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/technologies/' + technology.id, technology, $rootScope.header);
        }

        function remove(technology) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/technologies/' + technology.id, $rootScope.header);
        }
    }
})();