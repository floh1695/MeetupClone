const app = angular
    .module('meetupApp', ['ngRoute']);

app.config(function ($routeProvider) {

    $routeProvider.when('/', {
        templateUrl: '/Scripts/app/views/main.html',
        controller: 'meetupController'
    });

    $routeProvider.when('/event/:id', {
        templateUrl: '/Scripts/app/views/event.html',
        controller: 'eventController'
    });

    $routeProvider.otherwise({ redirectTo: '/' });
});

app.controller('meetupController',
    ['$scope', '$http', function ($scope, $http) {

        const init = () => {
            $scope.searchData = { city: '', title: '' };
            $scope.searchResults = []
            $scope.search = () => {
                const url = `/api/events?city=${$scope.searchData.city}&title=${$scope.searchData.title}`;
                $http({
                    method: 'GET',
                    url: url
                })
                .then(response => {
                    return response.data;
                })
                .then(data => {
                    console.group(`search: ${url}`);

                    $scope.searchResults = data;

                    data.forEach(datum => {
                        console.log(datum);
                    });

                    console.groupEnd();
                });
            };
        };

        init();

    }]);

app.controller('eventController',
    ["$scope", "$routeParams", "$http", function ($scope, $routeParams, $http) {

        const init = () => {
            $scope.result = {};
            $http({
                method: 'GET',
                url: `/api/event/${$routeParams.id}`
            })
            .then(response => response.data)
            .then(event => $scope.result = event);
        };

        init();

    }]);
