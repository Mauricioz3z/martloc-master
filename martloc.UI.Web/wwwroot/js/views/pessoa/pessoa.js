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
        "ajax": "/pessoa/GetPessoas",
        "columns": [{
            "data": "id",
        },
        {
            "data": "nomeRazao"
            },
            {
                "data": "fone"
            },
        {
            "data": "tipoPessoa",
            "render": function (data, type, row, meta) {
                if (data == 0) {
                    return '<span class="right badge badge-success">Fisica</span>';
                } else {
                    return '<span class="right badge badge-info">Juridica</span>';
                }
            }
        },

        {
            "data": null,
            "render": function (data, type, row, meta) {

                return `<button type="button" class="btn btn-primary edit"  data-id="${data.id}"    >
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



    if ($("#fpessoa").valid()) {

        buttonLoading.start(button);

        if ($('#Id').val() <= 0) {


            $.ajax({
                type: "POST",
                url: "/pessoa/Create",
                beforeSend: function (request) {
                  
                    request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                },
                data: {
                    //Pessoa
                    NomeRazao: $('#nome').val(),
                    Fone: $('#fone').val(),
                    Endereco: $('#endereco').val(),
                    TipoPessoa: $('#TipoPessoa').val(),
       
                    //Fisica
                    Cpf: $('#Cpf').val(),
                    Rg: $('#Rg').val(),
                    Apelido: $('#Apelido').val(),
                    DataNascimento: $('#DataNascimento').val(),

                
                    Cnpj: $('#Cnpj').val(),
                    NomeFantasia: $('#NomeFantasia').val(),
                    InscricaoMunicipal: $('#InscricaoMunicipal').val(),
                    InscricaoEstadual: $('#InscricaoEstadual').val(),
                    DataFundacao: $('#DataFundacao').val(),



                },
                success: function (e) {

                    if (e.resposta) {
                        console.log(e.resposta)
                    }

                    table.ajax.reload();
                    limpar()
                    if (!keepForm) {
                        $('.modal').modal('hide');
                    }
                    Toast.fire({
                        type: 'success',
                        title: 'Pessoa salva com sucesso!'
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
                url: "/pessoa/Edit",
                data: {
                    Id: $('#Id').val(),
                    NomeRazao: $('#nome').val(),
                    Fone: $('#fone').val(),
                    Endereco: $('#endereco').val(),
                    TipoPessoa: $('#TipoPessoa').val(),
                        //Fisica
                    Cpf: $('#Cpf').val(),
                    Rg: $('#Rg').val(),
                    Apelido: $('#Apelido').val(),
                    DataNascimento: $('#DataNascimento').val(),

                    //juridica
                    Cnpj: $('#Cnpj').val(),
                    NomeFantasia: $('#NomeFantasia').val(),
                    InscricaoMunicipal: $('#InscricaoMunicipal').val(),
                    InscricaoEstadual: $('#InscricaoEstadual').val(),
                    DataFundacao: $('#DataFundacao').val(),



                },
                success: function (e) {
                    table.ajax.reload();
                    limpar()
                    Toast.fire({
                        type: 'success',
                        title: 'Pessoa Atualizada com sucesso!'
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
                url: "/pessoa/Delete",
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
                            title: 'Pessoa excluída com sucesso!'
                        })

                    } else {
                        table.ajax.reload();


                        Toast.fire({
                            type: 'error',
                            title: 'Não foi possivel excluir esta pessoa!'
                        })

                    }



                },
                error: function (e) {
                    console.log(e)
                },

            });


        } else {

            $(button).html('<i class="fas fa-trash"></i>')
        }
    })

}


function limpar() {
    $('#Id').val(0)
    $('#nome').val('')
    $('#fone').val('')
    $('#endereco').val('')

    $('#TipoPessoa').val('0').change()
    //Fisica
    $('#Cpf').val('');
    $('#Rg').val(''),
    $('#Apelido').val('');
    $('#DataNascimento').val('');

   
    $('#Cnpj').val('')
    $('#NomeFantasia').val('')
    $('#InscricaoMunicipal').val('')
    $('#InscricaoEstadual').val('')
    $('#DataFundacao').val('')



}

$(document).ready(function () {


    $("#DataNascimento").datepicker({
        format: 'dd/mm/yyyy',
        language: 'pt-BR'
    });

    $("#DataFundacao").datepicker({
        format: 'dd/mm/yyyy',
        language: 'pt-BR'
    });
    $('#Cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('#Cpf').mask('000.000.000-00', { reverse: true });

    $(document).on('change', '#TipoPessoa', function () {
        if (this.value == 0) {
            $("#juridica").addClass("d-none")
            $("#fisica").removeClass("d-none")
        } else {

            $("#juridica").removeClass("d-none")
            $("#fisica"). addClass("d-none")
        }

      
    })



    var table = List();
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });

    $('#example tbody').on('click', '.edit', function () {
        $('#Id').val($(this).data('id'))

        $.ajax({
            type: "GET",
            url: "/pessoa/Edit",
            data: {
                id: $('#Id').val()
            },
            success: function (e) {

                $('#nome').val(e.nomeRazao)
                $('#fone').val(e.fone)
                $('#endereco').val(e.endereco)

                if (e.tipoPessoa == '0') {
                    $('#TipoPessoa').val('0').change()
                    //Fisica
                    $('#Cpf').val(e.cpf);
                    $('#Rg').val(e.rg),
                    $('#Apelido').val(e.apelido);
                    $('#DataNascimento').val(moment(e.dataNascimento).format('DD/MM/YYYY'));
                
                    $("#juridica").addClass("d-none")
                    $("#fisica").removeClass("d-none")


                } else {
                    $('#TipoPessoa').val('1').change()
                     $('#Cnpj').val(e.cnpj)
                     $('#NomeFantasia').val(e.nomeFantasi)
                     $('#InscricaoMunicipal').val(e.inscricaoMunicipal)
                     $('#InscricaoEstadual').val(e.inscricaoEstadual)
                    $('#DataFundacao').val(moment(e.dataFundacao).format('DD/MM/YYYY') )

                    $("#juridica").removeClass("d-none")
                    $("#fisica").addClass("d-none")
                }

              
               


            





                
                $('#modal-lg').modal({ backdrop: 'static', keyboard: false })
                $('#modal-lg').modal('show')
            },
            error: function (e) {

            }
          
        });







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


    jQuery.validator.addMethod("cnpj", function (value, element) {

        var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
        if (value.length == 0) {
            return false;
        }

        value = value.replace(/\D+/g, '');
        digitos_iguais = 1;

        for (i = 0; i < value.length - 1; i++)
            if (value.charAt(i) != value.charAt(i + 1)) {
                digitos_iguais = 0;
                break;
            }
        if (digitos_iguais)
            return false;

        tamanho = value.length - 2;
        numeros = value.substring(0, tamanho);
        digitos = value.substring(tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) {
            return false;
        }
        tamanho = tamanho + 1;
        numeros = value.substring(0, tamanho);
        soma = 0;
        pos = tamanho - 7;
        for (i = tamanho; i >= 1; i--) {
            soma += numeros.charAt(tamanho - i) * pos--;
            if (pos < 2)
                pos = 9;
        }

        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;

        return (resultado == digitos.charAt(1));
    }, "Informe um CNPJ válido.")

    jQuery.validator.addMethod("cpf", function (value, element) {
        value = jQuery.trim(value);

        value = value.replace('.', '');
        value = value.replace('.', '');
        cpf = value.replace('-', '');
        while (cpf.length < 11) cpf = "0" + cpf;
        var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
        var a = [];
        var b = new Number;
        var c = 11;
        for (i = 0; i < 11; i++) {
            a[i] = cpf.charAt(i);
            if (i < 9) b += (a[i] * --c);
        }
        if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
        b = 0;
        c = 11;
        for (y = 0; y < 10; y++) b += (a[y] * c--);
        if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }
        if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) return false;
        return true;
    }, "Informe um CPF válido."); // Mensagem padrão













    $("#fpessoa").validate({
        rules: {
            nome: {
                required: true,
                maxlength: 100
            },
            fone: {
                required: true,
                maxlength: 20
            },
            endereco: {
                required: true,
                maxlength: 255
            },
            Cpf: {
                required: true,
                cpf: true
            },
            Rg:  {
                required: true,
                maxlength: 20
             },
            Apelido: {
                required: true,
                maxlength: 100
            },
            DataNascimento: {
                required: true,
                maxlength: 20
            },
            Cnpj: {
                required: true,
                cnpj: true
            },
            NomeFantasia: {
                required: true,
                maxlength: 150
            },
            InscricaoMunicipal: {
               
                maxlength: 100
            },
            InscricaoEstadual: {
                maxlength: 100
            },
            DataFundacao: {
                required: true,
                maxlength: 20
            }
        },
        messages: {
            descricao: {
                required: "Por favor informe a descrição da pessoa!",
                maxlength: "Máximo de 100 caracteres permitido"
            },
        }
    });
});