function ListarEmbarques() {
    $.ajax({
        url: '/Embarques/Listar',
        type: 'get',
        dataType: 'json',
        success: function (datos) {
            var tabla = '<table class="highlight">';
            tabla += '<tr>';
            tabla += '<th class="fuente">Direccion</th>';
            tabla += '<th class="fuente">Telefono</th>';
            tabla += '<th class="fuente">Fax</th>';
            tabla += '<th class="fuente">Contacto</th>';
            tabla += '<th class="fuente">Orden de Compra</th>';
            tabla += '<th class="fuente">Consignatario</th>';
            tabla += '<th class="fuente">Zona Aduanera</th>';
            tabla += '<th class="fuente">Origen</th>';
            tabla += '<th class="fuente">Destino</th>';
            tabla += '<th class="fuente">Embarque Aereo</th>';
            tabla += '<th class="fuente">Embarque Maritimo</th>';
            tabla += '<th class="fuente">Contenedor</th>';
            tabla += '<th class="fuente">INCOTERM</th>';
            tabla += '<th class="fuente">Observación</th>';
            tabla += '<th></th>';
            tabla += '</tr >';
            console.log(datos);
            for (var i = 0; i < datos.length; i++) {
                tabla += '<tr>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Direccion + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Telefono + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Fax + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Contacto + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].OrdenCompra + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Consignatario + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].ZonaAduanera + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Origen + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Destino + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].EmbarqueAereo + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].EmbarqueMaritimo + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Contenedor + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].INCOTERM + '</td>';
                tabla += '<td class="fuenteTitulo">' + datos[i].Observacion + '</td>';
                tabla += '<td><a href="#modal1" onclick="detalleEmbarque(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Detalle</a><a href="/Embarques/Edit/' + datos[i].Id + '" type="button" class="btnContrasena margenBoton">Editar</a>';
                tabla += '<td><a href="#modal2" onclick="OpenModalCreateTrazabilidad(' + datos[i].Id + ');" type="button" class="btnGenerico margenBoton modal-trigger">Trazabilidad</a>';
                tabla += '</tr>';
            }

            tabla += '</table>';

            $('#datosEmbarques').html(tabla);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function detalleEmbarque(id) {
    var id = id;
    $.ajax({
        url: '/Embarques/Detalle/' + id,
        type: 'get',
        dataType: 'json',
        success: function (datos) {

            var embarqueDetalle = '<form class="col s12">';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Direccion:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Direccion;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Telefono:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Telefono;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Fax:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Fax;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Contacto:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Contacto;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'OrdenCompra:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.OrdenCompra;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Consignatario:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Consignatario;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'ZonaAduanera:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.ZonaAduanera;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Origen:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Origen;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Destino:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Destino;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'EmbarqueAereo:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.EmbarqueAereo;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'EmbarqueMaritimo:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.EmbarqueMaritimo;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Contenedor:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Contenedor;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'INCOTERM:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.INCOTERM;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="row">';
            embarqueDetalle += '<div class="col s3 fuente">';
            embarqueDetalle += 'Observacion:';
            embarqueDetalle += '</div>';
            embarqueDetalle += '<div class="col s9 fuenteTitulo">';
            embarqueDetalle += datos.Observacion;
            embarqueDetalle += '</div>';
            embarqueDetalle += '</div>';
            embarqueDetalle += '</form>';

            $('#datosdetalleEmbarque').html(embarqueDetalle);
        },
        error: function () {
            alert('Peticion con error');
        }
    });
}

function GuardarTrazabilidad(id) {
    
    $.ajax({
        url: '/Trazabilidades/Create/',
        type: 'post',
        data: {
            TipoOperacion: $('#tipoOperacion').val(),
            PaisOrigen: $('#paisOrigen').val(),
            CiudadOrigen: $('#ciudadOrigen').val(),
            PaisDestino: $('#paisDestino').val(),
            CiudadDesstino: $('#ciudadDestino').val(),
            Kilos: $('#kilos').val(),
            Teus: $('#teus').val(),
            IdEmbarque: $('#idEmbarque').val(),
        },
        
        success: function (datos) {
            alert('Trazabilidad Creada.');
            window.location.href = '/Embarques/Index';
        },
        error: function () {
            alert('Peticion con error');
        }

    });
}

function OpenModalCreateTrazabilidad(id) {
    $('#idEmbarque').val(id);
}



$(document).ready(function () {
    ListarEmbarques();
    $('.modal').modal();
});