app.factory("AngularJS_WCFService", ['$http', '$q', function ($http, $q) {
    var itemDetails;
    var item = {
        itemID: '',
        itemName: '',
        description: '',
        imageName: '',
        itemPrice: '',
        addedBy: ''
    };
    //var displaymode = {
    //    showitem:  false, 
    //    showlist: true, 
    //    showcart: false
    //};
    var ret = {
        getItem: function(){
            return item;
        },
        setItem: function(data){
            item = data;
        },
        getItemDetails: function () {
            return $http.get("http://localhost:30362/ItemDetailsWCF.svc/getAll")
                .then(function (resp) {
                    itemLists = resp.data;
                    return itemLists;
                }, function () {
                    alert("WCF service failed")
                })
        },
        addItem: function (ItemDetails) {
            return $http.post("http://localhost:30362/ItemDetailsWCF.svc/addItemDetail", ItemDetails);
        },
        editItem: function(itemDetails){
            return $http.post("http://localhost:30362/ItemDetailsWCF.svc/editItemDetail",itemDetails);
        },
        uploadFile: function (file) {
            var formData = new FormData();
            formData.append('file', file);

            var defer = $q.defer();
            $http.post("/ShoppingCart/UploadFile", formData, {
                withCredentials: true,
                transformRequest: angular.identity,
                headers:{'Content-Type': undefined}
            }).success(function(d){
                defer.resolve(d);
            }).error(function(err){
                defer.reject(err);
            });
            return defer.promise;
        }
    }
    return ret;
}])