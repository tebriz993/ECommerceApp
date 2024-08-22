$(document).ready(function () {
    LoadProduct();


   
});

$("#close-modal-btn").click(function () {
    console.log("Close modal");
    $('#image-modal').css("display", "none")
    $('#image-modal').removeClass("show")
})
function LoadProduct() {
    $("#product-datatable").dataTable({
        autoWidth: false,
        pageLength: 5,
        lengthMenu: [[5], [10], [15]],
        ajax: {
            url: "/Adminarea/Product/GetProduct",
            dataSrc: ""
        },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'price' },
            { data: 'category' },
            { data: 'description' },
            {
                data: 'imagePath',
                render: function (data, type, row) {
                    return '<button id="showImageBtn"  class="btn btn-success" data-image-path="' + data + '">View Image</button>';
                }

            },
            {
                data: 'edit',
                render: function (data, type, row) {
                    console.log(row.id);
                    return '<button id="edit-product"  class="btn btn-outline-success" data-id="' + row.id + '">Edit</button>';
                }

            },
            {
                data: 'delete',
                render: function (data, type, row) {
                    console.log(row.id);
                    return '<button id="delete-product"  class="btn btn-outline-warning" data-id="' + row.id + '">Delete</button>';
                }

            },
        ]
    })



    $("#product-datatable > tbody ").on("click", "button.btn-success", function () {
        console.log("Modal is work");
        let imagePath = $(this).data("image-path");
       
        $("#image-product").attr("src", imagePath)
        $('#image-modal').css("display", "block")
        $('#image-modal').addClass("show")

    })

    $("#product-datatable > tbody").on("click", "button.btn-outline-success", function () {
        console.log("Edite clicklendi");
        let id = $(this).data("id");
           
        window.location.href = `/adminarea/product/addproduct/${id}`
    })


    $("#product-datatable > tbody").on("click", "button.btn-outline-warning", function () {
        console.log("Edite clicklendi");
        let id = $(this).data("id");

        Swal.fire({
            title: "Do you want to remove the product?",
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: "Delete",
            denyButtonText: `Don't Delete`
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "GET",
                    url: `/Adminarea/Product/RemoveProduct/${id}`,
                    dataType: "json",
                    success: function (response) {
                        window.location.reload();
                    }
                })
            } else if (result.isDenied) {
                Swal.fire("Changes are not saved", "", "info");
            }
        });

      
    })



        
}