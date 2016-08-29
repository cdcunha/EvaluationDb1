var app = angular.module('db1.avaliacao.tecnica')
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
            .when('/github/users/:id', {
                templateUrl: 'app/templates/GitHub.Users/Users.html',
                controller: 'GitHubUsersCtrl',
            })
            .when('/github/user/detail/:login', {
                templateUrl: 'app/templates/GitHub.Users/Details.html',
                controller: 'GitHubUserDetCtrl'
            })
            .when('/github/users/repo/:login', {
                templateUrl: 'app/templates/GitHub.Users/Repo.html',
                controller: 'GitHubUserRepoCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
        }
    ]);
/****************************************
* Controle para buscar todos os usuários
*****************************************/
app.controller('GitHubUsersCtrl', function ($rootScope, $location, $http, $routeParams) {
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

/****************************************
* Controle para pegar repositório público de um usuário específico
*****************************************/
app.controller('GitHubUserRepoCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.RepoNotFound = false;
    $rootScope.activetab = $location.path();
    $http.get("https://api.github.com/users/" + $routeParams.login + "/repos?visibility=public&type=public&sort=created&direction=asc")
        .success(function (data) {
            $rootScope.RepoData = data;
        })
        .error(function () {
            $rootScope.RepoNotFound = true;
        });
    $rootScope.loading = false;
});