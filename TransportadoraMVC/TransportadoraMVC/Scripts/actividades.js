function ListarActividades() {
    $.ajax({
        url: '/Actividad/Listar',
        type: 'get',
        dataType: 'json',
        success: function(datos) {
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

            for (var i = 0; i < datos.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Asunto + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].FechaVencimiento + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Estado + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Prioridad + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Proceso.Sucursal + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Usuario.Correo + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Observacion + '</td>';
                tabla += '<td><a href="/Actividad/Edit/' + datos[i].Id + '" type="button" class="btnGenerico margenBoton">Editar</a><a href="#modal1" onclick="detalleActividad(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="/Actividad/Delete/' + datos[i].Id + '" type="button" class="btnGenerico margenBoton">Eliminar</a></td>';
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

$(document).ready(function () {
    ListarActividades();
    $('.modal').modal();
});