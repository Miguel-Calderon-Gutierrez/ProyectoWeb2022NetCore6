var agregar = document.getElementById("agregar");
var guardarb = document.getElementById("guardar");
var lista = document.getElementById("lista");
var data = [];
var cant = 0;
agregar.addEventListener("click", agregarD);
guardarb.addEventListener("click", save);

function agregarD() {
    var cantidad = parseInt(document.getElementById("cantidad").value);
    var fecha = document.getElementById("fecha").value;
    var tipo_donacion = document.getElementById("tipo").value;
    data.push({
        "id": cant,
        "cantidad": cantidad,
        "tipo": tipo_donacion
    });

    var id_row = "row" + cant;
    var fila = '<tr id=' + id_row + '><td>' + cantidad + '</td>' + '<td>' + tipo_donacion + '</td><td><button type="button" class="eliminar-botoncito2" onclick="eliminar(' + cant + ')";>Eliminar</button></td></tr>';

    $("#lista").append(fila);
    $("#cantidad").val('');
    $("#tipo").val('');
    cant++;
}

function eliminar(row) {
    //remover la fila de la tabla
    $("#row" + row).remove();
    var i = 0;
    var pos = 0;
    for (x of data) {
        if (x.id = row) {
            pos = i;
        }
        i++;
    }

    data.splice(pos, 1);
}

//En proceso porque toca recorrerlo mi loco
function save() {
    var json = JSON.stringify(data);
    console.log(json);
    $.ajax({
        type: "POST",
        url: "https://localhost:7198/Beneficiario/Beneficiario/GuardarJson",
        data: "json=" + json,
        succes: function () {
            location.reload();
        }
    })
}