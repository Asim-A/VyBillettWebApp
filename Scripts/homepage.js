var picker = new Pikaday(
    {
        field: document.getElementById('datepicker'),
        minDate: new Date(),
        onSelect: function () {
            console.log(this);
        }
    });

$(function () {
    $.ajax({
        url: '/Home/ajaxtest',
        type: 'GET',
        dataType: 'json',
        success: function (n) {
            alert(n);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
})

$("#submit_buy_btn").click(function () {
    var Inn = {
        reise_dato_tid: $("#datepicker").val()
    }

    $.ajax({
        url: '/Home/ajaxtestinn',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(Inn),
        contentType: "application/json;charset=utf-8",
        success: function (i) {
            alert(i);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

})


