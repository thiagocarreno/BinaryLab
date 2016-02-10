(function () {
    'use strict';

    var api = angular.module('ApiModule', ['ngResource']);
    api.factory('Api', ['$resource', function ($resource) {
        return {
            movie: $resource(
                    '/api/movie/:id',
                    {},
                    {
                        get: {
                            method: 'GET',
                        },
                        query: {
                            method: 'GET',
                            isArray: true
                        },
                        update: {
                            method: 'PUT'
                        }
                    }
                )
        }
    }]);
})();