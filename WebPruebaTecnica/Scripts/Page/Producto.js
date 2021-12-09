function CargarProductos() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Home/GetProductos',
        data: {},
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            PintarGrid(data, "gridProductos");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("No se puedo consultar en la BD. Favor intente mas tarde");
        }
    });
}

function PintarGrid(lista, procedencia) {
    var gridProductos = $('#gridProductos');
    if (procedencia === "gridProductos") {
        var createGridProductos = function () {
            gridProductos.grid({
                dataSource: lista,
                uiLibrary: 'bootstrap4',
                columns: [
                    { field: 'IdProducto' },
                    { field: 'Producto', sortable: true }
                ],
                pager: { limit: 10, sizes: [10, 20, 50, 100, 200] }
            });
        };
        gridProductos.grid('destroy', true, true);
        createGridProductos();
    }
}