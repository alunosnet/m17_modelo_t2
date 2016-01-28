$(document).ready(function () {
    //quando o form é submetido
    $("#form1").submit(function (evento) {
        var nome = $("#tbNome").val();
        var erros = "";
        
        if (nome == "") {
            erros += "Tem de indicar o nome";
            alert('Tem de indicar o nome');
            $("#tbNome").focus();
            evento.preventDefault();
        }

        if (erros != "")
            $("#Label1").text(erros);
    });
    

});