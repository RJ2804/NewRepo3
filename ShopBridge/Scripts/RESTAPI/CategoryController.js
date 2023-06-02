

categoryController = (function () {

    var getAllCategoryDetails = function (jsonData, callbackfunction) {
        var apiPath = "https://localhost:44370/" + "api/Categories/GetAllCategories/";
        api.postRequest(apiPath, jsonData, function (responseData) {
            callbackfunction(responseData)
        })
    }

    var addToCategory = function (jsonData, callbackfunction) {
        var apiPath = "https://localhost:44370/" + "api/Categories/AddToCategories/";
        api.postRequest(apiPath, jsonData, function (responseData) {
            callbackfunction(responseData)
        })
    }

    return {
        getAllCategoryDetails: getAllCategoryDetails,
        addToCategory: addToCategory
    };


})();