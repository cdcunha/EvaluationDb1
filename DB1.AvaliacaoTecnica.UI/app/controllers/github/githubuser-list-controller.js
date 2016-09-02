(function () {
    'use strict';
    angular.module('db1.avaliacao.tecnica').controller('GitHubUsersCtrl', function ($rootScope, $location, $http, $routeParams) {
        $rootScope.loading = true;
        $rootScope.userNotFound = false;
        $rootScope.activetab = $location.path();
        var url = "https://api.github.com/users";
        if ($routeParams.id != '0') {
            url = "https://api.github.com/users?since=" + $routeParams.id;
        }
        $http.get(url)
            .success(function (data) {
                $rootScope.UsersData = data;
            })
            .error(function () {
                $rootScope.userNotFound = true;
            });
        $rootScope.loading = false;
    });
})();