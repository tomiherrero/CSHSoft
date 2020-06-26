var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblVeterinarios").DataTable({
        "ajax": {
            "url": "/admin/veterinarios/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
           
            { "data": "idVeterinario", "width": "20%" },
            { "data": "RazonSocial", "width": "20%" },
            { "data": "Direccion", "width": "20%" },
            { "data": "HorarioAtencion", "width": "20%" },
            { "data": "Internacion", "width": "20%" },
            { "data": "Observaciones", "width": "20%" },
            {
                "data": "idVeterinario",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/Veterinarios/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/Admin/Veterinarios/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}


function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}


