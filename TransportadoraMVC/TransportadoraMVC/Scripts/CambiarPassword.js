function CambiarPassword() {
    
    $.ajax({
        type: 'post',
        url: '/Usuarios/CambiarPassword',
        data: { id: $('#Id').val() ,contraseñaActual: $('#ContraseñaActual').val(), nuevaContraseña: $('#NuevaContraseña').val() },
        dataType: 'json',
        success: function () {
            alert('Cambio de Contraseña Exitoso.');
            window.location.href = '/Usuarios/Index';
        },
        error: function () {
            alert('fue mal');
        }
    })
}