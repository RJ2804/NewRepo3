<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ShopBridge.About" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqgrid/5.8.2/js/jquery.jqGrid.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.13.2/jquery-ui.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

    <link href="https://cdn.jsdelivr.net/npm/jqgrid@4.6.4/css/ui.jqgrid.min.css" rel="stylesheet">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">    


    <script type="text/javascript" src="Scripts/Categories.js"></script>
    <script type="text/javascript" src="Scripts/RESTAPI/CategoryController.js"></script>
    <script type="text/javascript" src="Scripts/RESTAPI/ProductController.js"></script>
    <script type="text/javascript" src="Scripts/RESTAPI/Api.js"></script>


    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Launch demo modal
</button>

     <style>
        .btn {
            background-color: light-green;
            padding: 12px 16px;
            font-size: 16px;
        }
        .btn:hover {
            background-color: green;
        }
    </style>

    <div class="container" style="background-image:url('Content/Images/Products/Fashion/background_blue.jfif')">


        <div class="modal fade in" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Add New Category</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body container">

                        <div class="form-group" hidden>
                            <label>ID:</label>
                            <input type="text" id="idedit" class="form-control" />
                        </div>

                        <div class="form-group">
                            <label>Category Name:</label>
                            <input type="text" id="catName" class="form-control" />
                            <label id="validateCatName" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Category Code:</label>
                            <input type="text" id="catCode" class="form-control" />
                            <label id="validateCatCode" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Category Description:</label>
                            <input type="text" id="catDes" class="form-control">
                            <label id="validateCatDes" style="color: orangered"></label>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="bi bi-x-lg"></i></button>
                        <button type="button" class="btn btn-primary" onclick="category.addCategory();"><i class="bi bi-arrow-bar-up"></i></button>
                    </div>
                </div>
            </div>

        </div>

        <div class="modal fade in" id="productModal" tabindex="-1" role="dialog" aria-labelledby="productModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="productModalLongTitle">Add New Product</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body container">

                        <div class="form-group">
                            <label>Product Name:</label>
                            <input type="text" id="prodName" class="form-control" />
                            <label id="validateProdName" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Product Description:</label>
                            <input type="text" id="prodDes" class="form-control" />
                            <label id="validateProdDes" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Price:</label>
                            <input type="text" id="prodPrice" class="form-control">
                            <label id="validateProdPrice" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Image Path:</label>
                            <input type="text" id="prodImg" class="form-control">
                            <label id="validateProdImg" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Cateory Type:</label>
                            <select class="form-select" aria-label="Default select example" id="prodCategory">
                                <option selected>Select</option>
                                <option value="1">Electronics</option>
                                <option value="2">Fashion</option>
                            </select>
                            <label id="validateProdCategory" style="color: orangered"></label>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="bi bi-x-lg"></i></button>
                        <button type="button" class="btn btn-primary" onclick="category.addProducts();"><i class="bi bi-arrow-bar-up"></i></button>
                    </div>
                </div>
            </div>

        </div>

        <!--  Add products  --->
        <div class="modal fade in" id="addProductModal" tabindex="-1" role="dialog" aria-labelledby="addProductModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="addProductModalTitle">Edit Product Details</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body container">

                                                <div class="form-group" hidden>
                            <label>ID:</label>
                            <input type="text" id="editProductId" class="form-control" />
                        </div>

                        <div class="form-group">
                            <label>Product Name:</label>
                            <input type="text" id="productName" class="form-control" />
                            <label id="validateEditProdName" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Product Description:</label>
                            <input type="text" id="productDescription" class="form-control" />
                            <label id="validateEditProdDes" style="color: orangered"></label>
                        </div>

                        <div class="form-group">
                            <label>Price:</label>
                            <input type="text" id="productPrice" class="form-control">
                            <label id="validateEditProdPrice" style="color: orangered"></label>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" onclick="category.editProducts();">Save changes</button>
                    </div>
                </div>
            </div>

        </div>

        <div class="container">

            <div class="text-end">
            <%--<button type="button" class="btn btn-primary" onclick="category.addProduct();">Add Product To Inventory</button>--%>
        <%--          <button class="btn">
            <i class="fa fa-trash"></i>
        </button>--%>

                <%--<button class="btn"><i class="fa fa-trash"></i> Trash</button>--%>
               <button class="btn btn-primary" onclick="category.addProduct();"><i class="bi bi-bag-plus"></i>Add Product</button>
                </div>

            <div class="row" id="cards">
            </div>

        </div>

    </div>
</asp:Content>
