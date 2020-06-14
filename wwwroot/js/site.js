"use strict";

$(() => {

    if ($('#tbl-peoples').length !== 0) {

        var table = $('#tbl-peoples').DataTable({
            language: {
                "lengthMenu": "Mostrar _MENU_ registros",
                "zeroRecords": "No se encontraron resultados",
                "emptyTable": "Ningún dato disponible en esta tabla",
                "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                "processing": "Procesando...",                
                "loadingRecords": "Cargando...",
                "paginate":
                {
                    "first": "Primero",
                    "previous": "Anterior",
                    "next": "Siguiente",
                    "last": "Último"
                }
            },
            pagingType: "full_numbers",
            searching: true,
            processing: true,
            serverSide: true,
            orderCellsTop: true,
            autoWidth: true,
            deferRender: true,
            lengthMenu: [[5, 10, 15, 20, 100], [5, 10, 15, 20, 100]],            
            //lengthMenu: [[5, 10, 15, 20, -1], [5, 10, 15, 20, "All"]],        
            //dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 text-right"B>><"row"<"col-sm-12"tr>><"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
            dom: '<"row"<"col-sm-12 col-md-6"B><"col-sm-12 col-md-6 text-right"l>><"row"<"col-sm-12"tr>><"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
            buttons: [
                {
                    text: 'Create',
                    className: 'btn btn-sm btn-success',
                    action: function (e, dt, node, config) {
                        $('#createModal').modal('show');
                    },
                    init: function (api, node, config) {
                        $(node).removeClass('dt-button');
                    }
                },
                {
                    text: 'Excel',
                    className: 'btn btn-sm btn-outline-dark',
                    action: function (e, dt, node, config) {
                        window.location.href = "/Home/GetExcel";
                    },
                    init: function (api, node, config) {
                        $(node).removeClass('dt-button');
                    }
                },
                {
                    text: 'Imprimir',
                    className: 'btn btn-sm btn-outline-dark',
                    action: function (e, dt, node, config) {
                        window.location.href = "/Home/GetExcel";
                    },
                    init: function (api, node, config) {
                        $(node).removeClass('dt-button');
                    }
                },
                //{
                //    text: 'CSV',
                //    className: 'btn btn-sm btn-outline-dark',
                //    action: function (e, dt, node, config) {
                //        window.location.href = "/Home/GetExcel";
                //    },
                //    init: function (api, node, config) {
                //        $(node).removeClass('dt-button');
                //    }
                //}
            ],
            ajax: {
                type: "POST",
                url: '/Home/SearchPersonas/',
                contentType: "application/json; charset=utf-8",
                async: true,
                headers: {
                    "XSRF-TOKEN": document.querySelector('[name="__RequestVerificationToken"]').value
                },
                data: function (data) {
                    let additionalValues = [];
                    additionalValues[0] = "Additional Parameters 1";
                    additionalValues[1] = "Additional Parameters 2";
                    data.AdditionalValues = additionalValues;

                    return JSON.stringify(data);
                }
            },
            columns: [
                {
                    data: "Codigo",
                    name: "eq",
                    visible: false,
                    searchable: false,                    
                    orderable: false
                },
                {
                    data: "Nombres",
                    name: "eq",
                },
                {
                    data: "Apellidos",
                    name: "eq",
                },
                {
                    data: "Cargo",
                    name: "eq",
                },
                {
                    data: "Oficina",
                    name: "eq"
                },
                {
                    data: "Experiencia",
                    name: "eq"
                },
                {
                    data: "FechaInicio",
                    render: function (data, type, row) {
                        if (data)
                            return window.moment(data).format("DD/MM/YYYY");
                        else
                            return null;
                    },
                    name: "gt"
                },
                {
                    data: "Salario",
                    render: $.fn.dataTable.render.number('', '.', 3),
                    name: "lte"
                },
                {
                    orderable: false,
                    width: 100,
                    data: "Action",
                    render: function (data, type, row) {
                        return `<div>
                                    <button type="button" class="btn btn-sm btn-info mr-2 btnEdit" data-key="${row.Codigo}">Edit</button>
                                    <button type="button" class="btn btn-sm btn-danger btnDelete" data-key="${row.Codigo}">Delete</button>
                                </div>`;
                    }
                }
            ]
        });

        table.columns().every(function (index)
        {
            console.log(index);
            $('#tbl-peoples thead tr:last th:eq(' + index + ') input')
                .on('keyup',
                    function (e)
                    {
                        console.log(e);
                        if (e.keyCode === 13)
                        {
                            //table.column($(this).parent().index() + ':visible').search(this.value).draw();
                            table.search(this.value).draw();
                        }
                    });
        });

        //$(document)
        //    .off('click', '#btnCreate')
        //    .on('click', '#btnCreate', function () {
        //        fetch('/Home/Create/',
        //            {
        //                method: 'POST',
        //                cache: 'no-cache',
        //                body: new URLSearchParams(new FormData(document.querySelector('#frmCreate')))
        //            })
        //            .then((response) => {
        //                table.ajax.reload();
        //                $('#createModal').modal('hide');
        //                document.querySelector('#frmCreate').reset();
        //            })
        //            .catch((error) => {
        //                console.log(error);
        //            });
        //    });

        $(document)
            .off('click', '.btnEdit')
            .on('click', '.btnEdit', function () {
                const id = $(this).attr('data-key');

                fetch(`/Home/Edit/${id}`,
                    {
                        method: 'GET',
                        cache: 'no-cache'
                    })
                    .then((response) => {
                        return response.text();
                    })
                    .then((result) => {
                        $('#editPartial').html(result);
                        $('#editModal').modal('show');
                    })
                    .catch((error) => {
                        console.log(error);
                    });
            });

        //$(document)
        //    .off('click', '#btnUpdate')
        //    .on('click', '#btnUpdate', function () {
        //        fetch('/Home/Edit/',
        //            {
        //                method: 'PUT',
        //                cache: 'no-cache',
        //                body: new URLSearchParams(new FormData(document.querySelector('#frmEdit')))
        //            })
        //            .then((response) => {
        //                table.ajax.reload();
        //                $('#editModal').modal('hide');
        //                $('#editPartial').html('');
        //            })
        //            .catch((error) => {
        //                console.log(error);
        //            });
        //    });

        $(document)
            .off('click', '.btnDelete')
            .on('click', '.btnDelete', function () {
                const id = $(this).attr('data-key');

                if (confirm('Esta seguro de eliminar el registro?')) {
                    fetch(`/Home/Delete/${id}`,
                        {
                            method: 'DELETE',
                            cache: 'no-cache'
                        })
                        .then((response) => {
                            table.ajax.reload();
                        })
                        .catch((error) => {
                            console.log(error);
                        });
                }
            });

        $('#btnExternalSearch').click(function ()
        {
            var data = $('#txtExternalSearch').val();
            console.log(data);
            //table.column('0:visible').search(data).draw(); // Busqueda Independiente por Columna
            table.search(data).draw();
        });

        $('#txtExternalSearch').keyup(function (e) {
            if (e.keyCode === 13) {
                //table.column($(this).parent().index() + ':visible').search(this.value).draw();
                table.search(this.value).draw();
            }
        });

    }
});
