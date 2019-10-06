﻿var picker = new Pikaday(
    {
        field: document.getElementById('datepicker'),
        minDate: new Date(),
        onSelect: function () {
            console.log(this);
        }
    });

//$(function () {
//    $.ajax({
//        url: '/Home/ajaxtest',
//        type: 'GET',
//        dataType: 'json',
//        success: function (n) {
//            alert(n);
//        },
//        error: function (x, y, z) {
//            alert(x + '\n' + y + '\n' + z);
//        }
//    });
//})

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

function setup_timepicker() {
    let timepicker = document.getElementById("timepicker");

    for (let i = 0; i < 24; i++) {
        let node;
        let value = "";

        if (i < 10) {
            value = "0" + i + ":00";
        }
        else {
            value = i + ":00";
        }

        node = create_option(value);
        timepicker.appendChild(node);
    }

}

function bind_input_timepicker() {
    let timepicker_form = document.getElementById("reise_dato_tid");
    let timepicker = document.getElementById("timepicker");

    timepicker.addEventListener("change", function () {
        timepicker_form.value = timepicker.options[timepicker.selectedIndex].value;
    }, false);

}

function create_option(option) {
    const element_name = "option";
    const node = document.createElement(element_name);
    node.innerHTML = option; 
    return node;

}

function setup_dropdown() {
    let dropdownFra = document.getElementById("myDropdownFra");
    let dropdownTil = document.getElementById("myDropdownTil");
    

    setup_individual_dropdown(dropdownFra);
    setup_individual_dropdown(dropdownTil);

    setup_onfocusout_dropdown(document.getElementById("fra"), dropdownFra);
    setup_onfocusout_dropdown(document.getElementById("til"), dropdownTil);
    
}

function setup_individual_dropdown(dropdown) {
    id = dropdown.id;
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

function setup_onfocusout_dropdown(input, dropdown) {

    input.addEventListener("focusout", function () {

        setTimeout(function () {
            dropdown.classList.remove("show");
        }, 100)
        
    });

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

function show_menu_id(id, input_id) {
    let el = document.getElementById(id);
    let input = document.getElementById(input_id);

    if (input.value !== "") {

        if (!el.classList.contains("show")) 
            el.classList.add("show");

    }

    if(input.value === "")
        el.classList.remove("show");

}

function find_increment_buttons(className) {
    return document.getElementsByClassName(className);
}

function bind_input_to_buttons(inputId) {

    let input = document.getElementById(inputId);
    let input_parent = input.parentElement;
    let input_source = input_parent.getElementsByClassName("count");

    let increment_button = input_parent.getElementsByClassName("plus")[0];
    let decrememnt_button = input_parent.getElementsByClassName("minus")[0];
    let user_input = input_source[0];
  
    increment_button.addEventListener("click", function () {

        let current = user_input.value;
        let incremented_value = parseInt(current) + 1;

        user_input.value = incremented_value;
        input.value = user_input.value;

    }, false);

    decrememnt_button.addEventListener("click", function () {

        let current = user_input.value;
        let decremented_value = parseInt(current) - 1;
        if (decremented_value <= 0) decremented_value = 0;

        user_input.value = decremented_value;
        input.value = user_input.value;

    }, false)


}

function setup_bind_increment_input() {
    bind_input_to_buttons("antall_voksne");
    bind_input_to_buttons("antall_barn");
    bind_input_to_buttons("antall_studenter");
}

fra_input.setAttribute("autocomplete", "off");
til_input.setAttribute("autocomplete", "off");
setup_timepicker();
bind_input_timepicker()
setup_dropdown();
setup_bind_increment_input();

$("#fra").keyup(function (event) {

    filter_function("fra", "myDropdownFra");
    show_menu_id("myDropdownFra", "fra");

});

$("#til").keyup(function () {
    filter_function("til", "myDropdownTil");
    show_menu_id("myDropdownTil", "til");
});


