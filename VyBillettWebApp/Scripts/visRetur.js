$(document).ready(function () {
    console.log("yaaah");
    $('input[type="radio"]').click(function () {
        if ($(this).attr('id') == 'knappretur') {
            $('#retur').show();
        }

        else {
            $('#retur').hide();
        }
    });
});