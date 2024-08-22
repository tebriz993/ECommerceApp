$(document).ready(function () {
    FillCategory();
    //LoadProduct();

    $("#add-product-btn").click(AddNewCategory)
});

function FillCategory() {
    var selectBox = $("#product-category");
    var selectedid = $("#product-category-id")
    $.ajax({
        type: "GET",
        url: "/Adminarea/Product/GetCategories",
        dataType: "json",
        success: function (response) {
            console.log(response);
            for (let i = 0; i < response.length; i++) {
                selectBox.append($('<option>',
                    {
                        value: response[i].id,
                        text: response[i].name,
                        selected: selectedid
                    }
                ));
            }
        }
    })
}



function AddNewCategory() {
    console.log("Add Product is work")
    var productName = $("#product-name").val();
    var price = $("#product-price").val();
    var description = $("#product-description").val();
    var categoryId = $("#product-category").val();
    var producId = $("#product-id").val();

    const product = {
        id: producId,
        name: productName,
        description: description,
        price: price,
        categoryId: categoryId,
        imagePath: "",
    }

    debugger

    let files = $("#product-image").get(0).files;
    console.log(files)

    let formData = new FormData();

    for (i = 0; i < files.length; i++) {
        formData.append("image", files[i])
    }


    $.ajax({
        async: true,
        type: "POST",
        url: "/AdminArea/Product/UploadImage",
        data: formData,
        dataType: "JSON",
        processData: false,
        contentType: false,
        success: function (imageResponse) {

            product.imagePath = imageResponse.image
            $.ajax({
                type: "POST",
                url: "/Adminarea/Product/AddProduct",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(product),
                success: function (response) {
                    Swal.fire({
                        position: "top-end",
                        icon: "success",
                        title: response.message,
                        showConfirmButton: false,
                        timer: 1500
                    });
                    window.location.href = "/adminarea/product/product";
                },

            })
        }
    })

  
}

//function LoadProduct() {
//    console.log("BU isdiyir");
//    $("#product-datatable").dataTable({
//        autoWidth: false,
//        pageLength: 5,
//        lengthMenu: [[5], [10], [15]],
//        ajax: {
//            url: "/Adminarea/Product/GetProduct",
//            dataSrc: ""
//        },
//        columns: [
//            { data: 'id' },
//            { data: 'name' },
//            { data: 'price' },
//            { data: 'category' },
//            { data: 'description' },
//        ]
//    })


//}



//function LoadProduct() {
//    console.log("BU isdiyir");
//    $("#product-datatable").dataTable({
//        autoWidth: false,
//        pageLength: 5,
//        lengthMenu: [[5], [10], [15]],
//        ajax: {
//            url: "/Adminarea/Product/GetProduct",
//            dataSrc: ""
//        },
//        columns: [
//            { data: 'id' },
//            { data: 'name' },
//            { data: 'price' },
//            { data: 'category' },
//            { data: 'description' },
//        ]
//    })


//}