function CargarFacturas() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Home/GetFacturas',
        data: {},
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            PintarGrid(data, "gridFacturas");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("No se puedo consultar en la BD. Favor intente mas tarde");
        }
    });
}

function PintarGrid(lista, procedencia) {
    var gridFacturas = $('#gridFacturas');
    if (procedencia === "gridFacturas") {
        var createGridFacturas = function () {
            gridFacturas.grid({
                dataSource: lista,
                uiLibrary: 'bootstrap4',
                columns: [
                    { field: 'IdFactura' },
                    { field: 'NumeroFactura', sortable: true },
                    { field: 'Fecha', type: 'date', format: 'dd/mm/yyyy' },
                    { field: 'TipoDePago', sortable: true },
                    { field: 'DocumentoCliente', sortable: true },
                    { field: 'NombreCliente', sortable: true },
                    { field: 'SubTotal', sortable: true },
                    { field: 'Descuento', sortable: true },
                    { field: 'Iva', sortable: true },
                    { field: 'TotalDescuento', sortable: true },
                    { field: 'TotalImpuesto', sortable: true },
                    { field: 'Total', sortable: true }
                ],
                pager: { limit: 10, sizes: [10, 20, 50, 100, 200] }
            });
        };
        gridFacturas.grid('destroy', true, true);
        createGridFacturas();
    }
}