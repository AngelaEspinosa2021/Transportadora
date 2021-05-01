function ListarProcesos() {
    $.ajax({
        url: '/Procesos/Listar',
        type: 'get',
        dataType: 'json',
        success: function (datos) {
            var tabla = '<table class="highlight">';
            tabla += '<tr>';
            tabla += '<th class="fuente">Sucursal</th>';
            tabla += '<th class="fuente">Nombre</th>';
            tabla += '<th class="fuente">Estado<th>';
            tabla += '<th></th>';
            tabla += '</tr >';

            for (var i = 0; i < datos.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Sucursal + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Nombre + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Estado + '</td>';
                tabla += '<td><a href="/Procesos/Edit/' + datos[i].Id + '" type="button" class="btnGenerico margenBoton">Editar</a><a href="#modal1" onclick="detalleProcesos(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="/Procesos/Delete/' + datos[i].Id + '" type="button" class="btnGenerico margenBoton">Eliminar</a></td>';
                tabla += '</tr>';
            }

            tabla += '</table>';

            $('#datosProcesos').html(tabla);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function detalleProcesos(id) {
    var id = id;
    $.ajax({
        url: '/Procesos/Detalle/' + id,
        type: 'get',
        dataType: 'json',
        success: function (datos) {

            var procesoDetalle = '<form class="col s12">';
            procesoDetalle += '<div class="row">';
            procesoDetalle += '<div class="col s2 fuente">';
            procesoDetalle += 'Sucursal:';
            procesoDetalle += '</div>';
            procesoDetalle += '<div class="col s10 fuenteTitulo">';
            procesoDetalle += datos.Sucursal;
            procesoDetalle += '</div>';
            procesoDetalle += '</div>';
            procesoDetalle += '<div class="row">';
            procesoDetalle += '<div class="col s2 fuente">';
            procesoDetalle += 'Nombre:';
            procesoDetalle += '</div>';
            procesoDetalle += '<div class="col s10 fuenteTitulo">';
            procesoDetalle += datos.Nombre;
            procesoDetalle += '</div>';
            procesoDetalle += '</div>';
            procesoDetalle += '<div class="row">';
            procesoDetalle += '<div class="col s2 fuente">';
            procesoDetalle += 'Estado:';
            procesoDetalle += '</div>';
            procesoDetalle += '<div class="col s10 fuenteTitulo">';
            procesoDetalle += datos.Estado;
            procesoDetalle += '</div>';
            procesoDetalle += '</div>';            
            procesoDetalle += '</form>';

            $('#datosdetalleProceso').html(procesoDetalle);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

$(document).ready(function () {
    ListarProcesos();
    $('.modal').modal();
});