$(document).ready(function () {
    $('.datepicker').datepicker({
        firstDay: true,
        format: 'yyyy-mm-dd',
        i18n: {
            months: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
            monthsShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Set", "Oct", "Nov", "Dic"],
            weekdays: ["Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"],
            weekdaysShort: ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"],
            weekdaysAbbrev: ["D", "L", "M", "M", "J", "V", "S"]
        }
    });
    $('select').formSelect();
});

$(document).ready(function () {
    $('.timepicker').timepicker();
});


$(document).ready(function () {

    $('.frm').submit(function (e) {
        e.preventDefault();

        Url = "@Url.Content('~/Access/Enter')"
        parametro = $(this).serialize();

        $.post(url, parametros, function (data) {
            if (data == "1") {
                document.location.href = "@Url.Content('~/')";
            }
            else {
                alert(data)
            }
        })
    })

});

