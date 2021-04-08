var buttonLoading = {
    start: function (button) {
        $($(button).find('i')).removeClass('d-none');
        $(button).attr('disabled', 'disabled');

    },
    stop: function (button) {
        $($(button).find('i')).addClass('d-none');
        $(button).removeAttr('disabled');

    }
}

function List() {

    return $('#example').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json"
        },
        "ajax": "/marca/GetMarcas",
        "columns": [{
            "data": "id",
        },
        {
            "data": "descricao"
        },
        {
            "data": "status",
            "render": function (data, type, row, meta) {
                if (data == 1) {
                    return '<span class="right badge badge-success">Ativo</span>';
                } else {
                    return '<span class="right badge badge-danger">Inativo</span>';
                }
            }
        },

        {
            "data": null,
            "render": function (data, type, row, meta) {

                return `<button type="button" class="btn btn-primary create" data-descricao="${data.descricao}" data-id="${data.id}"  data-status="${data.status}" data-toggle="modal" data-target="#modal-lg" >
                            <i class="fas fa-edit"></i>
                        </button> <button type="button"  class="btn btn-danger delete"  data-id="${data.id}" >
                            <i class="fas fa-trash"></i>
                        </button>`;
            }
        },
        ],
        "order": [
            [1, 'asc']
        ],
    });
}

function AddOrUpadate(keepForm = false, table, Toast, button) {



    if ($("#fmarca").valid()) {

        buttonLoading.start(button);

        if ($('#Id').val() <= 0) {








         








            $.ajax({
                type: "POST",
                url: "/marca/Create",
                beforeSend: function (request) {

                    request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                },
                data: {
                    Status: $('#status').val(),
                    Descricao: $('#descricao').val()
                },
                success: function (e) {
                    table.ajax.reload();
                    if (!keepForm) {
                        $('.modal').modal('hide');
                    }
                    Toast.fire({
                        type: 'success',
                        title: 'Marca salva com sucesso!'
                    })


                },
                error: function (e) {


                },
                complete: function () {
                    buttonLoading.stop(button);
                }

            });

        } else {



            $.ajax({
                type: "POST",
                url: "/marca/Edit",
                beforeSend: function (request) {

                    request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                },
                data: {
                    id: $('#Id').val(),
                    Status: $('#status').val(),
                    Descricao: $('#descricao').val()
                },
                success: function (e) {
                    table.ajax.reload();
                    Toast.fire({
                        type: 'success',
                        title: 'Marca Atualizada com sucesso!'
                    })
                    if (!keepForm) {
                        $('.modal').modal('hide');
                    }
                   
                },
                error: function (e) {
                   
                },
                complete: function () {
                    buttonLoading.stop(button);
                }
            });
        }


        $('#Id').val(0)
        $('#descricao').val("")
    }



}

function Delete(table, Toast, button) {


    $(button).html('<i class="ld ld-ring ld-spin"></i>')

    Swal.fire({
        title: 'Tem certeza?',
        text: "Você não poderá reverter isso!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim, excluir!'
    }).then((result) => {
        if (result.value) {


            $.ajax({
                type: "POST",
                url: "/marca/Delete",
                beforeSend: function (request) {

                    request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                },
                data: {
                    id: $(button).data('id')
                },
                success: function (e) {

                    if (e > 0) {
                        table.ajax.reload();


                        Toast.fire({
                            type: 'success',
                            title: 'Marca excluída com sucesso!'
                        })

                    } else {
                        table.ajax.reload();


                        Toast.fire({
                            type: 'error',
                            title: 'Não foi possivel excluir esta marca!'
                        })

                    }



                },
                error: function (xhr, textStatus) {
                    table.ajax.reload();
                    if (xhr.status == 403) {
                        Toast.fire({
                            type: 'error',
                            title: 'Você não tem permissão para excluír'
                        })
                    }

                   
                }

            });


        } else {

            $(button).html('<i class="fas fa-trash"></i>')
        }
    })

}

$(document).ready(function () {

    var table = List();
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });

    $('#example tbody').on('click', '.create', function () {
        $('#Id').val($(this).data('id'))
        $('#descricao').val($(this).data('descricao'))
        $('#status').val($(this).data('status'))
    });

    $('#example tbody').on('click', '.delete', function () {
        Delete(table, Toast, this)
    });

    $('#btnSalvarContinuar').on('click', function () {
        AddOrUpadate(true, table, Toast, this)
    })

    $('#btnSalvar').on('click', function () {

        AddOrUpadate(false, table, Toast, this)
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