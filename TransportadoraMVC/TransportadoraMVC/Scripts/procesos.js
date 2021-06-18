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

            for (var i = 0; i < datos.Model.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Sucursal + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Nombre + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Estado + '</td>';
                tabla += '<td><a href="/Procesos/Edit/' + datos.Model[i].Id + '" type="button" class="btnGenerico margenBoton">Editar</a><a href="#modal1" onclick="detalleProcesos(' + datos.Model[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="#modal2" onclick="eliminarProceso(' + datos.Model[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Eliminar</a></td>';
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

function eliminarProceso(id) {
    var boton = '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat" onclick="confirmarEliminacion(' + id + ')">Eliminar</a>';
    boton += '</div>';
    boton += '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancelar</a>';
    boton += '</div>';

    $('#datoseliminarProceso').html(boton);
}

function confirmarEliminacion(id) {
    var id = id;
    $.ajax({
        url: '/Procesos/eliminar/' + id,
        type: 'GET',
        success: function () {
            window.location.href = '/Procesos/Index';
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