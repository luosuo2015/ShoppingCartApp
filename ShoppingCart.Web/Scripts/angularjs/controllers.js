app.controller('shoppingCtrl', ['$scope', 'AngularJS_WCFService', function ($scope, WCFService) {
    $scope.showitem = false;
    $scope.showlist = true;
    $scope.showcart = false;

    $scope.total = {
        totalPrice: 0,
        totalCount: 0,
        Sum: 0
    };

    $scope.cartlists = [];

    var itemCountExisting = 0;

    getlists();

    function getlists() {
        WCFService.getItemDetails().then(function (itemLists) {
            $scope.lists = itemLists;
        });
    };
   
    $scope.selectItem = function (item) {
        $scope.item = item;
        $scope.showitem = true;
        $scope.showlist = true;
        $scope.showcart = false;
    };

    $scope.showCart = function () {
        $scope.showitem = true;
        $scope.showlist = false;
        $scope.showcart = true;
        itemCountExisting = 0;
        addtoCart();
    };
    $scope.showlists = function () {
        $scope.showitem = false;
        $scope.showlist = true;
        $scope.showcart = false;
    };

    function addtoCart() {
        if ($scope.cartlists.length > 0) {
            for (var i = 0; i < $scope.cartlists.length; i++) {
                if ($scope.cartlists[i].itemName == $scope.item.itemName) {
                    itemCountExisting = $scope.cartlists[i].itemCount + 1;
                    $scope.cartlists[i].itemCount = itemCountExisting;
                };
            };
        };
        if (itemCountExisting <= 0) {
            itemCountExisting = 1;
            var cartItem = {
                itemID: $scope.item.itemID,
                itemName: $scope.item.itemName,
                description: $scope.item.description,
                imageName: $scope.item.imageName,
                itemPrice: $scope.item.itemPrice,
                addedBy: $scope.item.addedBy,
                itemCount: itemCountExisting
            };
            $scope.cartlists.push(cartItem);
            //$scope.item = [];
        }
        getSum();
    };
    function getSum() {
        $scope.totalPrice = 0;
        $scope.totalQuantity = 0;
        $scope.totalAmount = 0;
        for (var i = 0; i < $scope.cartlists.length; i++) {
            $scope.totalPrice += parseInt($scope.cartlists[i].itemPrice);
            $scope.totalQuantity += parseInt($scope.cartlists[i].itemCount);
            $scope.totalAmount += $scope.cartlists[i].itemPrice * $scope.cartlists[i].itemCount;
        };
    };

    $scope.removeCartitem = function (index) {
        $scope.cartlists.splice(index, 1);
        getSum();
    }

}]);

app.controller('addItemCtrl', ['$scope', 'AngularJS_WCFService', function ($scope, WCFService) {

    getlists();

    function getlists() {
        WCFService.getItemDetails().then(function (itemLists) {
            $scope.lists = itemLists;
        });
    };

    $scope.Frmitem = {
        itemID: '',
        itemName: '',
        description: '',
        imageName: '',
        itemPrice: '',
        addedBy: ''
    };

    $scope.isFileValid = false;
    $scope.isFormValid = false;
    $scope.IsFormSubmitted = false;
    $scope.fileInvalidMsg = "";
    $scope.selectedFile = null;
    $scope.editmode = false;
    $scope.addmode = true;

    $scope.$watch('addItemFrm.$isvalid', function (isvalid) {
        $scope.isFormValid = isvalid;
    });

   
    $scope.setFile = function (file) {
        var onefile = file[0];
        $scope.selectedFile = onefile;
        $scope.Frmitem.imageName = onefile.name;
    };

    $scope.editItem = function (item) {
        $scope.editmode = true;
        $scope.addmode = false;
        $scope.Frmitem = item;
    }

    $scope.checkFileValid = function (file) {
        var isValid = false;
        if ($scope.selectedFile != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/jpg' || file.type == 'image/gif') && file.size <= (800 * 800)) {
                isValid = true;
                $scope.fileInvalidMsg = "";
            } else {
                $scope.fileInvalidMsg = "Only PNG/GIF/JPEG/JPG image can be uploaded";
            }
        } else {
            $scope.fileInvalidMsg = "Image must be required.";
        }
        $scope.isFileValid = isValid;
    };

    $scope.saveFile = function () {
        debugger;
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.checkFileValid($scope.selectedFile);
        if ($scope.IsFormSubmitted && $scope.isFileValid) {
            WCFService.uploadFile($scope.selectedFile).then(function (d) {
                var newitem = $scope.Frmitem;
                if (newitem.itemID == 0) {
                    WCFService.addItem(newitem).then(function (d) {
                        getlists();
                    }, function (err) {
                        console.log("Data insert Error, " + err.Message);
                    });
                } else {
                    WCFService.editItem(newitem).then(function (d) {
                        getlists();
                    }, function (err) {
                        console.log("Data edit Error, " + err.Message);
                    });
                };               
                $scope.IsFormSubmitted = false;
                console.log("File upload Success.")
            }, function (err) {
                console.log("File upload Failed, " + err.Message);
            })
        } else {
            console.log("No Valid " + fileInvalidMsg);
            $scope.Message = "All Fields must be required.";
        }
    }
    $scope.clearForm = function () {
        $scope.FrmitemID = "";
        $scope.FrmitemName = "";
        $scope.Frmdescription = "";
        $scope.FrmitemPrice = "";
        $scope.FrmaddedBy = "";
    }
}]);