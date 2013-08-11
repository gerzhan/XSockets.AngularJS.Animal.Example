var animalApp = angular.module('animalApp', ['XSockets']).
  config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
      $routeProvider.
          when('/animals/', { templateUrl: '/app/partials/animals.html', controller: AnimalsController }).
            when("/create/", { templateUrl: '/app/partials/create.html', controller: CreateAnimalController }).
          otherwise({ redirectTo: '/animals' });
  }]);
