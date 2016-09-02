angular.module('db1.avaliacao.tecnica')
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
            .when('/vacancies', {
                controller: 'VacancyListCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/templates/vacancy/index.html'
            })
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
