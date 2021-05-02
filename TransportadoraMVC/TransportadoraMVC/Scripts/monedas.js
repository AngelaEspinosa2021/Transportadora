function ListarMonedas() {
    $.ajax({
        url: '/Monedas/Listar',
        type: 'get',
        dataType: 'json',
        success: function (datos) {
            var tabla = '<table class="highlight">';
            tabla += '<tr>';
            tabla += '<th class="fuente">Nombre</th>';
            tabla += '<th class="fuente">Código</th>';
            tabla += '<th class="fuente">Valor Moneda</th>';
            tabla += '<th class="fuente">Fecha</th>';
            tabla += '<th class="fuente">Descripción</th>';            
            tabla += '<th></th>';
            tabla += '</tr >';

            for (var i = 0; i < datos.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Nombre + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Codigo + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Valor + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Fecha + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Descripcion + '</td>';                
                tabla += '<td><a href="/Monedas/Edit/' + datos[i].Id + '" type="button" class="btnGenerico margenBoton">Editar</a><a href="#modal1" onclick="detalleMonedas(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="#modal2" onclick="eliminarMoneda(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Eliminar</a></td>';
                tabla += '</tr>';
            }

            tabla += '</table>';

            $('#datosMonedas').html(tabla);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function detalleMonedas(id) {
    var id = id;
    $.ajax({
        url: '/Monedas/Detalle/' + id,
        type: 'get',
        dataType: 'json',
        success: function (datos) {

            var monedaDetalle = '<form class="col s12">';
            monedaDetalle += '<div class="row">';
            monedaDetalle += '<div class="col s2 fuente">';
            monedaDetalle += 'Nombre:';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="col s10 fuenteTitulo">';
            monedaDetalle += datos.Nombre;
            monedaDetalle += '</div>';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="row">';
            monedaDetalle += '<div class="col s2 fuente">';
            monedaDetalle += 'Codigo:';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="col s10 fuenteTitulo">';
            monedaDetalle += datos.Codigo;
            monedaDetalle += '</div>';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="row">';
            monedaDetalle += '<div class="col s2 fuente">';
            monedaDetalle += 'Valor:';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="col s10 fuenteTitulo">';
            monedaDetalle += datos.Valor;
            monedaDetalle += '</div>';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="row">';
            monedaDetalle += '<div class="col s2 fuente">';
            monedaDetalle += 'Fecha:';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="col s10 fuenteTitulo">';
            monedaDetalle += datos.Fecha;
            monedaDetalle += '</div>';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="row">';
            monedaDetalle += '<div class="col s2 fuente">';
            monedaDetalle += 'Descripción:';
            monedaDetalle += '</div>';
            monedaDetalle += '<div class="col s10 fuenteTitulo">';
            monedaDetalle += datos.Descripcion;
            monedaDetalle += '</div>';
            monedaDetalle += '</div>';
            monedaDetalle += '</form>';

            $('#datosdetalleMoneda').html(monedaDetalle);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function eliminarMoneda(id) {
    var boton = '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat" onclick="confirmarEliminacion(' + id + ')">Eliminar</a>';
    boton += '</div>';
    boton += '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancelar</a>';
    boton += '</div>';

    $('#datoseliminarMoneda').html(boton);
}

function confirmarEliminacion(id) {
    var id = id;
    $.ajax({
        url: '/Monedas/eliminar/' + id,
        type: 'GET',
        success: function () {
            window.location.href = '/Monedas/Index';
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

$(document).ready(function () {
    ListarMonedas();
    $('.modal').modal();
});