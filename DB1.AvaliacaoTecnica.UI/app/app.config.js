var app = angular.module('db1.avaliacao.tecnica')
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
            .when('/github.users', {
                templateUrl: 'app/templates/GitHub.Users/Users.html',
                controller: 'GitHubUsersCtrl',
            })
            .when('/github.users/Next/:id', {
                templateUrl: 'app/templates/GitHub.Users/Users.html',
                controller: 'GitHubUsersNextCtrl',
            })
            .when('/github.userDetail/:login', {
                templateUrl: 'app/templates/GitHub.Users/Details.html',
                controller: 'GitHubUserDetCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
        }
    ]);
/****************************************
* Controle para buscar todos os usuários
*****************************************/
app.controller('GitHubUsersCtrl', function ($rootScope, $location, $http) {
    $rootScope.loading = true;
    $rootScope.userNotFound = false;
    $rootScope.activetab = $location.path();
    $http.get("https://api.github.com/users")
        .success(function (data) {
            $rootScope.UsersData = data;
        })
        .error(function () {
            $rootScope.userNotFound = true;
        });
    $rootScope.loading = false;
});
/****************************************
* Controle para buscar próximos usuários
*****************************************/
app.controller('GitHubUsersNextCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.userNotFound = false;
    $rootScope.activetab = $location.path();
    $http.get("https://api.github.com/users?since=" + $routeParams.login)
        .success(function (data) {
            $rootScope.UsersData = data;
        })
        .error(function () {
            $rootScope.userNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Controle para pegar detalhes de um usuário específico
*****************************************/
app.controller('GitHubUserDetCtrl', function ($rootScope, $location, $http, $routeParams) {
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