(function () {
    'use strict';

    angular
        .module('StudySpaApp')
        .controller('movieController', movieController);

    movieController.$inject = ['$scope', '$routeParams', '$location', 'Api'];

    function movieController($scope, $routeParams, $location, api) {
        $scope.movie = {
            Id: 0,
            Title: '',
            Director: ''
        };

        $scope.index = function () {
            $scope.movies = api.movie.query();
        }

        $scope.add = function () {
            api.movie.save($scope.movie, function () {
                $location.path('/movie');
            });
        }

        $scope.edit = function () {
            api.movie.update({ id: $scope.movie.Id }, $scope.movie, function () {
                $location.path('/movie');
            });
        }

        $scope.delete = function () {
            api.movie.delete({ id: $scope.movie.Id }, function () {
                $location.path('/movie');
            });
        }

        $scope.$on('$viewContentLoaded', function () {
            if ($routeParams.id) {
                $scope.load_movie();
            } else if ($location.$$path === '/' || $location.$$path === '/movie') {
                $scope.index();
            }
        });

        $scope.load_movie = function () {
            $scope.movie = api.movie.get({ id: $routeParams.id });
        };
    }
})();