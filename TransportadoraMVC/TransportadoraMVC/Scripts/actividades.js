function ListarActividades() {
    $.ajax({
        url: '/Actividad/Listar',
        type: 'get',
        dataType: 'json',
        success: function (datos) {
            console.log(datos);
            var tabla = '<table class="highlight">';
            tabla += '<tr>';
            tabla += '<th class="fuente">Asunto</th>';
            tabla += '<th class="fuente">Fecha Vencimiento</th>';
            tabla += '<th class="fuente">Estado</th>';
            tabla += '<th class="fuente">Prioridad</th>';
            tabla += '<th class="fuente">Sucursal</th>';
            tabla += '<th class="fuente">Usuario</th>';
            tabla += '<th class="fuente">Observacion</th>';
            tabla += '<th></th>';
            tabla += '</tr >';

            for (var i = 0; i < datos.Model.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Asunto + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].FechaVencimiento + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Estado + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Prioridad + '</td>';
                //tabla += '<td class="fuenteTitulo">' + datos.Model[i].Proceso.Sucursal + '</td>';
                //tabla += '<td class="fuenteTitulo">' + datos.Model[i].Usuario.Correo + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos.Model[i].Observacion + '</td>';
                tabla += '<td><a href="/Actividad/Edit/' + datos.Model[i].Id + '" type="button" class="btnGenerico margenBoton">Editar</a><a href="#modal1" onclick="detalleActividad(' + datos.Model[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="#modal2" onclick="eliminarActividad(' + datos.Model[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Eliminar</a></td>';
                tabla += '</tr>';
            }

            tabla += '</table>';

            $('#datosActividades').html(tabla);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function detalleActividad(id) {
    var id = id;
    $.ajax({
        url: '/Actividad/Detalle/' + id,
        type: 'get',
        dataType: 'json',
        success: function (datos) {

            var actividad = '<form class="col s12">';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Asunto:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.Asunto;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Fecha:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.FechaVencimiento;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Estado:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.Estado;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Prioridad:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.Prioridad;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Sucursal:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.Proceso.Sucursal;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Usuario:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.Usuario.Correo;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Obsevación:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.Observacion;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '</form>';

            $('#datosdetalleActividad').html(actividad);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function eliminarActividad(id) {
    var boton = '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat" onclick="confirmarEliminacion(' + id + ')">Eliminar</a>';
    boton += '</div>';
    boton += '<div class="col s6 center">';
    boton += '<a href="#!" class="modal-close waves-effect waves-green btn-flat">Cancelar</a>';
    boton += '</div>';   

    $('#datoseliminarActividad').html(boton);
}

function confirmarEliminacion(id) {
    var id = id;
    $.ajax({
        url: '/Actividad/eliminar/' + id,
        type: 'GET',
        success: function () {
            window.location.href = '/Actividad/Index';
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}


$(document).ready(function () {
    ListarActividades();
    $('.modal').modal();
});