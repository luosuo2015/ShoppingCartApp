app.controller('itemListCtrl', ['$scope', '$rootScope','AngularJS_WCFService', function ($scope, $rootScope, WCFService) {
    $scope.selectItem = function (one) {
        WCFService.setItem(one);
    };
    $scope.dispCart = function () {
        //alert("11111");
        //$rootScope.showitem = "",
        //$rootScope.showlist = "";
        //$rootScope.showcart = "";
        //$scope.showitem = true;
        //$scope.showlist = false;
        //$scope.showcart = true;
    }
    WCFService.getItemDetails().then(function (itemLists) {
        $scope.lists = itemLists;
    });
}]);

app.controller('itemCtrl', ['$scope', '$rootScope', 'AngularJS_WCFService', function ($scope, $rootScope, WCFService) {
    $scope.$watch(
        function () { return WCFService.getItem();} ,
        function (newValue ,oldValue) {
            if (oldValue !== newValue) {
                $scope.item = newValue;
                //$rootScope.showitem = "",
                //$rootScope.showlist = "";
                //$rootScope.showcart = "";
                //showitem = true;
                //showlist = true;
                //showcart = false;
            }              
        });
}]);

app.controller('cartCtrl', ['$scope', 'AngularJS_WCFService', function ($scope, WCFService) {
}]);