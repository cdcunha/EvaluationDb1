(function () {
    'use strict';
    angular.module('db1.avaliacao.tecnica').controller('GitHubUserDetCtrl', function ($rootScope, $location, $http, $routeParams) {
        $rootScope.loading = true;
        $rootScope.userNotFound = false;
        $rootScope.activetab = $location.path();
        $http.get("https://api.github.com/users/" + $routeParams.login)
            .success(function (data) {
                $rootScope.id = data.id;
                $rootScope.login = data.login;
                $rootScope.html_url = data.html_url;
                $rootScope.created_at = data.created_at;
            })
            .error(function () {
                $rootScope.userNotFound = true;
            });
        $rootScope.loading = false;
    });
})();