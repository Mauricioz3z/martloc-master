

$(document).ready(function () {



    function List() {


    }

    var table = $('#example').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json"
        },
        "ajax": "https://localhost:44344/marca/GetMarcas",
        "columns": [
            { "data": "id", },
            { "data": "descricao" },
            {
                "data": "status", "render": function (data, type, row, meta) {
                    if (data == 1) { return '<span class="right badge badge-success">Ativo</span>'; }
                    else { return '<span class="right badge badge-danger">Inativo</span>'; }
                }
            },

            {
                "data": null, "render": function (data, type, row, meta) {

                    return `<button type="button" class="btn btn-primary create" data-descricao="${data.descricao}" data-id="${data.id}" data-toggle="modal" data-target="#modal-lg" >
                            <i class="fas fa-edit"></i>
                        </button> <button type="button"  class="btn btn-danger delete"  data-id="${data.id}" >
                            <i class="fas fa-trash"></i>
                        </button>`;
                }
            },
        ],
        "order": [[1, 'asc']],});

    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });


    $('#example tbody').on('click', '.create', function () {
        $('#Id').val($(this).data('id'))
        $('#descricao').val($(this).data('descricao'))
    });

    $('#example tbody').on('click', '.delete', function () {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {


                $.ajax({
                    type: "POST",
                    url: "/marca/Delete",
                    data: { id: $(this).data('id') },
                    success: function (e) {

                        if (e > 0) {
                            table.ajax.reload();
                            Swal.fire(
                                'Deletado!',
                                'Marca excluída',
                                'success'
                            )
                        } else {
                            table.ajax.reload();
                            Swal.fire(
                                'Erro!',
                                'Não foi possivel excluir esta marca',
                                'error'
                            )

                        }


                
                    },
                    error: function (e) { console.log(e) },

                });

             
            }
        })



       
    });

    

    

    $('#btnSalvarContinuar').on('click', function () {

        if ($("#fmarca").valid()) {

            if ($('#Id').val() <= 0) {
                Toast.fire({
                    type: 'success',
                    title: 'Marca salva com sucesso!'
                })

                $.ajax({
                    type: "POST",
                    url: "/marca/Create",
                    data: { Status: 1, Descricao: $('#descricao').val() },
                    success: function (e) {
                        table.ajax.reload();
                        console.log(e)

                    },
                    error: function (e) { console.log(e) },

                });

            } else {

                Toast.fire({
                    type: 'success',
                    title: 'Marca Atualizada com sucesso!'
                })

                $.ajax({
                    type: "POST",
                    url: "/marca/Edit",
                    data: { id: $('#Id').val(), Status: 1, Descricao: $('#descricao').val() },
                    success: function (e) {
                        table.ajax.reload();
                        console.log(e)
                    },
                    error: function (e) { console.log(e) },

                });
            }
            $('#Id').val(0)
            $('#descricao').val("")
        }
    })


    $('#btnSalvar').on('click', function () {

        if ($("#fmarca").valid()) {

            if ($('#Id').val() <= 0) {
                Toast.fire({
                    type: 'success',
                    title: 'Marca salva com sucesso!'
                })

                $.ajax({
                    type: "POST",
                    url: "/marca/Create",
                    data: { Status: 1, Descricao: $('#descricao').val() },
                    success: function (e) {
                        table.ajax.reload();
                        $('.modal').modal('hide');
                        console.log(e)

                    },
                    error: function (e) { console.log(e) },

                });

            } else {

                Toast.fire({
                    type: 'success',
                    title: 'Marca Atualizada com sucesso!'
                })

                $.ajax({
                    type: "POST",
                    url: "/marca/Edit",
                    data: { id: $('#Id').val(), Status: 1, Descricao: $('#descricao').val() },
                    success: function (e) {
                        table.ajax.reload();
                        console.log(e)
                    },
                    error: function (e) { console.log(e) },

                });
            }
            $('#Id').val(0)
            $('#descricao').val("")
        }


    });


    $("#fmarca").validate({
        rules: {
            descricao: {
                required: true,
                maxlength: 100
            }
        },
        messages: {
            descricao: {
                required: "Por favor informe a descrição da marca!",
                maxlength: "Máximo de 100 caracteres permitido"
            },
        }
    });
});