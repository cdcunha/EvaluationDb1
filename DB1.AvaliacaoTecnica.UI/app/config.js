(function () {
    'use strict';

    angular.module('db1.avaliacao.tecnica').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'SERVICE_URL': 'http://localhost:5322/'
    });

    //angular.module('db1.avaliacao.tecnica').run(function ($rootScope, $location, SETTINGS) { });
})