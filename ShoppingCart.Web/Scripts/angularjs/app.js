var app = angular.module('theApp', []);
app.run(['$rootScope', function ($rootScope) {
    $rootScope.date = new Date();
}]);