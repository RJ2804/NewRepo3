$(document).ready(function () {
    category.onload();
});

category = (function () {

    var copyData = [];

    var onload = function () {

        getCategoryDetails();

        getProductDetails();
    }

    var addToCategory = function () {

        $('#validateCatName').hide();
        $('#validateCatCode').hide();
        $('#validateCatDes').hide();

        $('#catName').val('');
        $('#catCode').val('');
        $('#catDes').val('');

        $('#exampleModalCenter').modal('show');
    }

    var addProduct = function () {

        $('#validateProdName').hide();
        $('#validateProdDes').hide();
        $('#validateProdPrice').hide();
        $('#validateProdImg').hide();
        $('#validateProdCategory').hide();

        $('#prodName').val('');
        $('#prodDes').val('');
        $('#prodPrice').val('');
        $('#prodImg').val('');
        $('#prodCategory').val('Select');

        $('#productModal').modal('show');
    }

    var getCategoryDetails = function () {

        var inputParamaters = {
            'Id': '1',
            'CategoryName': 'hh',
            'CategoryCode': 'jj',
            'CategoryDescription': 'jj'
        };

        categoryController.getAllCategoryDetails(inputParamaters, function (responseData) {
            bindToCategoryDropDown(responseData)
        });
    }

    var getProductDetails = function () {

        var inputParamaters = {
            'Id': '2',
            'CategoryName': 'hh',
            'CategoryCode': 'jj',
            'CategoryDescription': 'jj'
        };

        productController.getAllProductDetails(inputParamaters, function (responseData) {
            bindToProductCards(responseData);
            copyData = responseData;
        });
    }

    var addCategory = function () {

        $('#validateCatName').hide();
        $('#validateCatCode').hide();
        $('#validateCatDes').hide();

        var inputParamaters = {
            'Id': '1',
            'CategoryName': $('#catName').val(),
            'CategoryCode': $('#catCode').val(),
            'CategoryDescription': $('#catDes').val()
        };


        if ($('#catName').val() == '') {

            $('#validateCatName').show();
            $('#validateCatName').text('Please Enter Category Name');
        }
        if ($('#catCode').val() == '') {
            $('#validateCatCode').show();
            $('#validateCatCode').text('Please Enter Category Code');
        }

        if ($('#catDes').val() == '') {
            $('#validateCatDes').show();
            $('#validateCatDes').text('Please Enter Category Description');
        }

        else {

            categoryController.addToCategory(inputParamaters, function (responseData) {

                $('#exampleModalCenter').modal('hide');
            });
        }

    }

    var addProducts = function () {

        $('#validateCatName').hide();
        $('#validateCatCode').hide();
        $('#validateCatDes').hide();

        var inputParamaters = {
            'ProductName': $('#prodName').val(),
            'ProductDescription': $('#prodDes').val(),
            'ProductImage': $('#prodImg').val(),
            'Price': $('#prodPrice').val(),
            'CategoryId': $('#prodCategory').val()
        };


        if ($('#prodName').val() == '') {

            $('#validateProdName').show();
            $('#validateProdName').text('Please Enter Product Name');
        }
        if ($('#prodDes').val() == '') {
            $('#validateProdDes').show();
            $('#validateProdDes').text('Please Enter Product Description');
        }

        if ($('#prodImg').val() == '') {
            $('#validateProdImg').show();
            $('#validateProdImg').text('Please Enter Product Image Path');
        }

        if ($('#prodPrice').val() == '') {
            $('#validateProdPrice').show();
            $('#validateProdPrice').text('Please Enter Product Price');
        }

        if ($('#prodCategory').val() == 'Select') {
            $('#validateProdCategory').show();
            $('#validateProdCategory').text('Please Enter Category');
        }

        else {

            productController.addToProductCollection(inputParamaters, function (responseData) {


                $('#cards').append(

                    "<div class='card'" + "id=" + "'" + 'card' + inputParamaters.ProductId + "'" + "style='width: 28rem; height: 40rem'>" +
                    "<img src=" + "'" + inputParamaters.ProductImage + "'" + ">" +
                    "<div class='card-body'>" +
                    "<h5 class='card-title' id='cardTitle" + inputParamaters.ProductId + "'" + ">" + inputParamaters.ProductName + "</h5>" +
                    "<p class='card-text' id='cardPrice" + inputParamaters.ProductId + "'" + ">" + inputParamaters.Price + "</p>" +
                    "</div>" +
                    "<ul class='list-group list-group-flush'>" +
                    "<li class='list-group-item' id='cardDescription" + inputParamaters.ProductId + "'" + ">" + inputParamaters.ProductDescription + "</li>" +
                    "</ul>" +
                    "<div class='card-body'>" +
                    "<button type='button'' class='btn btn-primary'onclick=" + "'" +
                    "category.editProduct(" + inputParamaters.ProductId + ");" + "'" + "> Edit</button > " +
                    "<button type='button'' class='btn btn-danger' onclick=" + "'" +
                    "category.deleteProduct(" + inputParamaters.ProductId + ");" + "'" + "> Delete</button > " +
                    "</div></div>"

                );


                $('#productModal').modal('hide');

                Swal.fire(
                    'Good job!',
                    'You successfully added new product to inventry!',
                    'success'
                )
            });
        }
    }

    var editProducts = function () {


        var inputParamaters = {
            'ProductId': $('#editProductId').val(),
            'ProductName': $('#productName').val(),
            'ProductDescription': $('#productDescription').val(),
            'ProductImage': $('#prodImg').val(),
            'Price': $('#productPrice').val(),
            'CategoryId': $('#prodCategory').val()
        };

        // copyData[0] = inputParamaters;
        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].ProductId == inputParamaters.ProductId) {
                copyData[i] = inputParamaters;
            }
        }

        if ($('#productName').val() == '') {

            $('#validateProdName').show();
            $('#validateProdName').text('Please Enter Product Name');
        }
        if ($('#productDescription').val() == '') {
            $('#validateProdDes').show();
            $('#validateProdDes').text('Please Enter Product Description');
        }

        if ($('#prodImg').val() == '') {
            $('#validateProdImg').show();
            $('#validateProdImg').text('Please Enter Product Image Path');
        }

        if ($('#productPrice').val() == '') {
            $('#validateProdPrice').show();
            $('#validateProdPrice').text('Please Enter Product Price');
        }

        else {

            productController.editToProductDetails(inputParamaters, function (responseData) {

                $('#addProductModal').modal('hide');



            });

            var editedProductId = $('#editProductId').val();
           // var title = '#cardTitle' + editedProductId;

            $('#cardTitle' + editedProductId).text(inputParamaters.ProductName);
            $('#cardDescription' + editedProductId).text(inputParamaters.ProductDescription);
            $('#cardPrice' + editedProductId).text(inputParamaters.Price);

            Swal.fire(
                'Good job!',
                'You successfully updated product details!',
                'success'
            )
        }

    }

    var bindToCategoryDropDown = function (responseData) {

        $.each(responseData, function (index, value) {

            $("#categoryCollection").append(

                "<li><a class='dropdown-item' href='#'>" + value.CategoryName + "</a></li>"
            )
        });

    }

    var bindToProductCards = function (responseData) {

        $.each(responseData, function (index, value) {

            $('#cards').append(
                "<div class='col-md-3'>" +
                "<div class='mb-3'>" +
                "<div class='card'" + "id=" + "'" + 'card' + value.ProductId + "'" + "style='height: 40rem'>" +
                "<img src=" + "'" + value.ProductImage + "'" + ">" +
                "<div class='card-body'>" +
                "<h5 class='card-title' id='cardTitle" + value.ProductId + "'" +">" + value.ProductName + "</h5>" +
                "<p class='card-text' id='cardPrice" + value.ProductId + "'" + ">" + value.Price + "</p>" +
                "</div>" +
                "<ul class='list-group list-group-flush'>" +
                "<li class='list-group-item' id='cardDescription" + value.ProductId + "'" + ">" + value.ProductDescription + "</li>" +
                "</ul>" +
                "<div class='card-body'>" +
                //"<button type='button'' class='btn btn-primary'onclick=" + "'" +
                //"category.editProduct(" + value.ProductId + ");" + "'" + "> Edit</button > " +
                //"<button type='button'' class='btn btn-danger' onclick=" + "'" +
                //"category.deleteProduct(" + value.ProductId + ");" + "'" + "> Delete</button > " +
                //"<button class=''btn btn-default'><i class=''glyphicon glyphicon-pencil'></i> Edit</button>" +
                //"<i class='bi bi-pen'></i>" +
                 "<button type='button'' class='btn btn-primary'onclick=" + "'" +
                "category.editProduct(" + value.ProductId + ");" + "'" + "><i class='bi bi-pen'></i></button > " +
                //"<div class='text-end'>" +
                //"<div class='mb-1'>" +
                "<button class='btn  btn-danger' onclick=" + "'" +
                "category.deleteProduct(" + value.ProductId + ");" + "'" + "><i class='fa fa-trash'></i></button>" +
               /* "</div></div>" +*/
                "</div></div></div></div>"

            );
        });
    }


    var editProduct = function (data) {
        var productItem;
        $('#addProductModal').modal('show');

        for (var i = 0; i < copyData.length; i++) {
            if (copyData[i].ProductId == data) {
                productItem = copyData[i];
            }
        }

        $('#editProductId').val(productItem.ProductId);
        $('#productName').val(productItem.ProductName);
        $('#productDescription').val(productItem.ProductDescription);
        $('#productPrice').val(productItem.Price);
    }

    var deleteProduct = function (id) {

        var inputParamaters = {
            'ProductId': id,

        };

        productController.deleteProductIdWise(inputParamaters, function (responseData) {
            // bindToProductCards(responseData);
        });

        var cardId = '#' + 'card' + id;

        $(cardId).remove();

    }

    return {
        onload: onload,
        getCategoryDetails: getCategoryDetails,
        bindToCategoryDropDown: bindToCategoryDropDown,
        addToCategory: addToCategory,
        addCategory: addCategory,
        getProductDetails: getProductDetails,
        bindToProductCards: bindToProductCards,
        deleteProduct: deleteProduct,
        editProduct: editProduct,
        addProduct: addProduct,
        addProducts: addProducts,
        editProducts: editProducts
    };

})();