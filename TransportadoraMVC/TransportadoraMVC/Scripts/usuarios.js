function ListarUsuarios() {
    $.ajax({
        url: '/Usuarios/Listar',
        type: 'get',
        dataType: 'json',
        success: function (datos) {
            var tabla = '<table class="highlight">';
            tabla += '<tr>';
            tabla += '<th class="fuente">Correo</th>';            
            tabla += '<th></th>';
            tabla += '</tr >';
            
            for (var i = 0; i < datos.Model.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Correo + '</td>';
                tabla += '<td><a href="#modal1" onclick="detalleUsuarios(' + datos.Model[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="/Usuarios/Edit/' + datos.Model[i].Id + '" type="button" class="btnContrasena margenBoton">Cambiar Contraseña</a><a href="#modal2" onclick="eliminarUsuario(' + datos.Model[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Eliminar</a></td>';
                tabla += '</tr>';
            }

            tabla += '</table>';

            $('#datosUsuarios').html(tabla);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function detalleUsuarios(id) {
    var id = id;
    $.ajax({
        url: '/Usuarios/Detalle/' + id,
        type: 'get',
        dataType: 'json',
        success: function (datos) {

            var usuarioDetalle = '<form class="col s12">';
            usuarioDetalle += '<div class="row">';
            usuarioDetalle += '<div class="col s2 fuente">';
            usuarioDetalle += 'Usuario - Correo:';
            usuarioDetalle += '</div>';
            usuarioDetalle += '<div class="col s10 fuenteTitulo">';
            usuarioDetalle += datos.Correo;
            usuarioDetalle += '</div>';
            usuarioDetalle += '</div>';
            usuarioDetalle += '<div class="row">';
            usuarioDetalle += '<div class="col s2 fuente">';
            usuarioDetalle += 'Contraseña:';
            usuarioDetalle += '</div>';
            usuarioDetalle += '<div class="col s10 fuenteTitulo">';
            usuarioDetalle += datos.Contraseña;
            usuarioDetalle += '</div>';
            usuarioDetalle += '</div>';
            usuarioDetalle += '</form>';

            $('#datosdetalleUsuario').html(usuarioDetalle);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}
function eliminarUsuario(id) {
    var boton = '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat" onclick="confirmarEliminacion(' + id + ')">Eliminar</a>';
    boton += '</div>';
    boton += '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancelar</a>';
    boton += '</div>';

    $('#datoseliminarUsuario').html(boton);
}

function confirmarEliminacion(id) {
    var id = id;
    $.ajax({
        url: '/Usuarios/eliminar/' + id,
        type: 'GET',
        success: function () {
            window.location.href = '/Usuarios/Index';
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

$(document).ready(function () {
    ListarUsuarios();
    $('.modal').modal();
});