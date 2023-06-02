

productController = (function () {

    var getAllProductDetails = function (jsonData, callbackfunction) {
        var apiPath = "https://localhost:44370/" + "api/Product/GetAllProductDetails/";
        api.postRequest(apiPath, jsonData, function (responseData) {
            callbackfunction(responseData)
        })
    }

    var deleteProductIdWise = function (jsonData, callbackfunction) {
        var apiPath = "https://localhost:44370/" + "api/Product/DeleteProductIdWise/";
        api.postRequest(apiPath, jsonData, function (responseData) {
            callbackfunction(responseData)
        })
    }

    var addToProductCollection = function (jsonData, callbackfunction) {
        var apiPath = "https://localhost:44370/" + "api/Product/AddToProductCollection/";
        api.postRequest(apiPath, jsonData, function (responseData) {
            callbackfunction(responseData)
        })
    }

    var editToProductDetails = function (jsonData, callbackfunction) {
        var apiPath = "https://localhost:44370/" + "api/Product/EditToProductDetails/";
        api.postRequest(apiPath, jsonData, function (responseData) {
            callbackfunction(responseData)
        })
    }

    return {
        getAllProductDetails: getAllProductDetails,
        deleteProductIdWise: deleteProductIdWise,
        addToProductCollection: addToProductCollection,
        editToProductDetails: editToProductDetails
    };


})();