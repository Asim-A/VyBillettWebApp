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


let fra_input = document.getElementById("fra");
let til_input = document.getElementById("til");

function setup_dropdown() {
    setup_individual_dropdown("myDropdownFra");
    setup_individual_dropdown("myDropdownTil");
}

function setup_individual_dropdown(id) {
    let dropdown = document.getElementById(id);
    let input;

    if (id === "myDropdownFra") {
        input = fra_input;
    }

    else {
        input = til_input;
    }

    for (let i = 0; i < liste_stasjoner.length; i++) {
        
        let node = create_menu_item(liste_stasjoner[i], input, dropdown);
        dropdown.appendChild(node);
    }
}

function create_menu_item(value, input, dropdown) {
    let node = document.createElement("a");
    node.setAttribute("href", "#");
    node.innerHTML = value;

    node.addEventListener("click", function () {
        input.value = value;
        dropdown.classList.remove("show");
    });

    return node;
}

function setup_filter_function() {

    filter_function(document.getElementById("fra"), document.getElementById("myDropdownFra"));
    filter_function(document.getElementById("til"), document.getElementById("myDropdownTil"));
}

function filter_function(input_id, dropdown_id) {
    var filter, a, i, input, dropdown;
    input = document.getElementById(input_id);
    dropdown = document.getElementById(dropdown_id);
    filter = input.value.toUpperCase();
    a = dropdown.getElementsByTagName("a");
    for (i = 0; i < a.length; i++) {
        txtValue = a[i].textContent || a[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            a[i].style.display = "";
        } else {
            a[i].style.display = "none";
        }
    }
}

function show_menu() {
    show_menu_id("myDropdownFra", document.getElementById("fra"));
    show_menu_id("myDropdownTil", document.getElementById("til"));
}

function show_menu_id(id, input) {
    let el = document.getElementById(id);


    if (input !== "") {

        if (!el.classList.contains("show"))
            el.classList.add("show");

    }
    if (input.value === "") {
        el.classList.remove("show");
    }
}


fra_input.setAttribute("autocomplete", "off");
til_input.setAttribute("autocomplete", "off");

setup_dropdown();

$("#fra").keyup(function (event) {

    filter_function("fra", "myDropdownFra");
    show_menu_id("myDropdownFra", "fra");

});

$("#til").keyup(function () {
    filter_function("til", "myDropdownTil");
    show_menu_id("myDropdownTil", "til");
});


