function ListarActividades() {
    $.ajax({
        url: '/Actividad/Listar',
        type: 'get',
        dataType: 'json',
        success: function(datos) {
            var tabla = '<table class="highlight">';
            tabla += '<tr>';
            tabla += '<th class="fuente">Asunto</th>';
            tabla += '<th class="fuente">Creada Por</th>';
            tabla += '<th class="fuente">Fecha Vencimiento</th>';
            tabla += '<th class="fuente">Estado</th>';
            tabla += '<th class="fuente">Prioridad</th>';
            tabla += '<th class="fuente">Sucursal</th>';
            tabla += '<th class="fuente">Asignada A</th>';
            tabla += '<th class="fuente">Observacion</th>';
            tabla += '<th></th>';
            tabla += '</tr >';
            console.log(datos);
            for (var i = 0; i < datos.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Asunto + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].CreadaPor + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].FechaVencimiento + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Estado + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Prioridad + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].RelacionadaCon + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].AsignadaA + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Observacion + '</td>';
                tabla += '<td><a href="/Actividad/Edit/' + datos[i].Id + '" type="button" class="btnGenerico margenBoton">Editar</a><a href="#modal1" onclick="detalleActividad(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="#modal2" onclick="eliminarActividad(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Eliminar</a></td>';
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
            actividad += 'Creada Por:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.CreadaPor;
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
            actividad += datos.RelacionadaCon;
            actividad += '</div>';
            actividad += '</div>';
            actividad += '<div class="row">';
            actividad += '<div class="col s2 fuente">';
            actividad += 'Usuario:';
            actividad += '</div>';
            actividad += '<div class="col s10 fuenteTitulo">';
            actividad += datos.AsignadaA;
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