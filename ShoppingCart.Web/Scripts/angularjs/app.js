var app = angular.module('theApp', []);
app.run(['$rootScope', function ($rootScope) {
    $rootScope.date = new Date();
    var showitem = true, showlist = true, showcart = false;
}]);