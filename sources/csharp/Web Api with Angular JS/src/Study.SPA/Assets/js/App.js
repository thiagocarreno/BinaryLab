(function () {
    'use strict';

    angular.module(
        'StudySpaApp',
        ['ngRoute', 'ApiModule']
    ).config(config);

    config.$inject = ['$routeProvider', '$locationProvider'];

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/Views/Movie/index.html',
                controller: 'movieController'
            })
            .when('/movie', {
                templateUrl: '/Views/Movie/index.html',
                controller: 'movieController'
            })
            .when('/movie/add', {
                templateUrl: '/Views/Movie/add.html',
                controller: 'movieController'
            })
            .when('/movie/edit/:id', {
                templateUrl: '/Views/Movie/edit.html',
                controller: 'movieController'
            })
            .when('/movie/delete/:id', {
                templateUrl: '/Views/Movie/delete.html',
                controller: 'movieController'
            })
            .otherwise('404', {
                redirectTo: '/Views/Errors/404.html'
            });

        $locationProvider.html5Mode(true);
    }
})();