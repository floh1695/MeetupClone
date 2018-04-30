const app = angular
    .module('meetupApp', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: '/Scripts/app/views/main.html',
        controller: 'meetupController'
    });

    $routeProvider.otherwise({ redirectTo: "/" });
});

app.controller('meetupController',
    ['$scope', '$http', function ($scope, $http) {
        // TODO: Add stuff here
    }]);
