

api = (function () {

    var postRequest = function (apiPath, jsonData, callbackfunction) {
        $.ajax({
            url: apiPath,
            type: 'Post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(jsonData),
            success: function (responseData) {
                callbackfunction(responseData);
            },

        });

    }


    return {
        postRequest: postRequest

    }
})();