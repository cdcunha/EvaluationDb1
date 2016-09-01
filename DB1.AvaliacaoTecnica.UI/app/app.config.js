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
            /****************************************
            * Tecnologia
            *****************************************/
            .when('/technologies', {
                controller: 'TechnologyCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/technology/index.html'
            })
            /****************************************
            * Vaga
            *****************************************/
            .when('/vacancies/create', {
                controller: 'VacancyCreateCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/vacancy/create.html'
            })
            .when('/vacancies/edit/:id', {
                controller: 'VacancyEditCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/vacancy/edit.html'
            })
            .when('/vacancies/remove/:id', {
                controller: 'VacancyRemoveCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/vacancy/edit.html'
            })
            .otherwise({
                redirectTo: '/'
            });
        }
    ]);
/****************************************
* GitHub - User - Listagem
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
* GitHub - User - Detalhes
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
* GitHub - User - Repositório
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


/****************************************
* Tecnologia - Listagem
*****************************************/
app.controller('TechnologiesListCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.technologyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/technologies";
    $http.get(url)
        .success(function (data) {
            $rootScope.TechnologiesData = data;
        })
        .error(function () {
            $rootScope.technologyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Tecnologia - Detalhe
*****************************************/
app.controller('TechnologyDetailCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.technologyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/technologies/" + $routeParams.login;
    $http.get(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.technologyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Tecnologia - Deleta
*****************************************/
app.controller('TechnologyDeleteCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.technologyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/technologies/" + $routeParams.id;
    $http.delete(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.technologyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Tecnologia - Novo
*****************************************/
app.controller('TechnologyNewCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.technologyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/Technology?code=" + $routeParams.id;
    $http.get(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.technologyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Tecnologia - Salva/Atualiza
*****************************************/
app.controller('TechnologySaveCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.technologyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/technologies/" + $routeParams.id;
    $http.put(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.technologyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Vaga - Listagem
*****************************************/
app.controller('VacanciesListCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.vacancyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/vacancies";
    $http.get(url)
        .success(function (data) {
            $rootScope.VacanciesData = data;
        })
        .error(function () {
            $rootScope.vacancyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Vaga - Detalhe
*****************************************/
app.controller('VacancyDetailCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.vacancyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/vacancies/" + $routeParams.login;
    $http.get(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.vacancyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Vaga - Deleta
*****************************************/
app.controller('VacancyDeleteCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.vacancyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/vacancies/" + $routeParams.id;
    $http.delete(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.vacancyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Vaga - Novo
*****************************************/
app.controller('VacancyNewCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.vacancyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/Vacancy?code=" + $routeParams.id;
    $http.get(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.vacancyNotFound = true;
        });
    $rootScope.loading = false;
});

/****************************************
* Vaga - Salva/Atualiza
*****************************************/
app.controller('VacancySaveCtrl', function ($rootScope, $location, $http, $routeParams) {
    $rootScope.loading = true;
    $rootScope.vacancyNotFound = false;
    $rootScope.activetab = $location.path();
    var url = "http://localhost:5322/api/vacancies/" + $routeParams.id;
    $http.put(url)
        .success(function (data) {
            $rootScope.id = data.id;
            $rootScope.description = data.description;
        })
        .error(function () {
            $rootScope.vacancyNotFound = true;
        });
    $rootScope.loading = false;
});