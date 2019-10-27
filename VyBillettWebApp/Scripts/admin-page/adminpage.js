/*
 * 
*/

$(document).ready(function () {
    setup_modal_delete_bt_ajax();
    setup_modal_add_bt_ajax();
    setup_modal_endre_bt_ajax();
    setup_slett_bestilling_ajax();
});


/*
 * Setter opp on click function på anchor-tag med attribute data-modal_delete=true. 
 * Deretter hentes alle data-attributter sine verdier med nøkler ut. 
 * Disse blir brukt til å sette opp modalen (detail), finne id-en til elementet som skal fjernes (id),
 * redirect url som skal være samme side med oppdatert info (url_self) og til slutt url til "action"
 * som tar seg av oppdateringen av databasen. 
 * 
*/ 
function setup_modal_delete_bt_ajax() {

    // lag en hendelse som utføres når en a-href med "data-SletteModal = true" trykkes.
    $("a[data-modal_delete=true]").click(function() {
        var me = $(this);
        // hent inn data-taggene fra denne a-hef lenken
        let modal_data_detail = me.data("detail");
        let modal_data_id = me.data("id");
        let modal_data_url_self = me.data("url_self");
        let modal_data_url_delete = me.data("url_delete");

        // legg ut dataene i div'en i modal-view'et
        $('#modal_delete_data_detail').html(modal_data_detail);

        // lag en hendelse for knappen for å slette via ajax, knappen ligger i modal-view'et
        // må ligge inne i denne overordnede funksjonen for at id'én som er valgt kan brukes
        $("#modal_delete_btn").click(function () {
            // id som skal slettes ligger i data_id
            $.ajax({
                url: "/Admin/slett_billett_type",
                type: "GET",
                data: { billett_type: modal_data_id },  // en parameter inn i slett(id)-metoden i kunde-kontrolleren (JSON-objekt)
                success: function () {
                    //get_bt();
                    window.location.reload();
                    
                }, error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        })
    })

}

function setup_slett_bestilling_ajax() {
    $("a[data-bestilling=true").click(function () {

        var me = $(this);
        let del_id = me.data("id");

        $.ajax({
            url: "/Admin/slett_bestilling",
            type: "GET",
            data: { id: del_id },
            success: function () {
                window.location.reload();
            }, error: function (x, y, z) {
                alert(x + '\n' + y + '\n' + z);
            }
        });

    });
}

function setup_modal_endre_bt_ajax() {
    $("a[data-modal_endre=true]").click(function () {
        var me = $(this);

        let modal_id = me.data("id");

        $("#modal_endre_btn").click(function () {

            let ny_pris = document.getElementById("bt_nyPris_input").value;
            if (ny_pris < 1) ny_pris = 30 //standard

            let endret_bt = {
                billett_type: modal_id,
                pris: ny_pris
            }

            $.ajax({
                url: "/Admin/endre_billett_pris",
                type: "POST",
                data: JSON.stringify(endret_bt),
                contentType: "application/json;charset=utf-8",
                success: function (ok) {
                    window.location.reload();
                }, error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }

            })

        });

    });
}

function get_bt() {
    $.ajax({
        url: "/Admin/get_billett_typer",
        type: 'GET',
        dataType: 'json',
        success: function (liste) {
            window.location.reload();
            //const container = document.getElementById("component-container");
            //container.innerHTML = "";

            //for (let itemIndex = 0; itemIndex < liste.length; itemIndex++) {
            //    console.log(liste[itemIndex]["billett_type"] + " " + liste[itemIndex]["pris"]);
            //    container.appendChild(get_billett_type_partial(liste[itemIndex]["billett_type"], liste[itemIndex]["pris"]));
            //}
        }, error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function setup_modal_add_bt_ajax() {
    $("#leggTilBillettType").click(function () {
        const bt = document.getElementById("bt_input").value;
        const bt_pris = document.getElementById("bt_pris_input").value;

        let new_bt = {
            billett_type: bt,
            pris: bt_pris
        }

        if (bt != null && bt_pris != null) {
            $.ajax({
                url: "/Admin/ny_billet_type",
                type: "POST",
                data: JSON.stringify(new_bt),
                contentType: "application/json;charset=utf-8",
                success: function (ok) {
                    window.location.reload(true);

                }, error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        }

    });
}

/*
 * Kan sende melding om at en handling har skjedd. Krever ett div med id="snackbar".
 * Brukes i konjuksjon med click-event, f.eks. en knapp. Input message er meldingen du vil vise
 * og timeout er tiden snackbaren vises. Anbefaler verdier [1500-4500] 
 * Hurtig: 1500, Normal: 3000, Treg: 4500
 * Tid er i millisekunder
*/
function setup_snackbar(message="Vellykket", timeout=3000) {
    let snackbar = document.getElementById("snackbar");
    snackbar.className = "show";
    setTimeout(
        () => {
            snackbar.className = snackbar.className.replace("show", "");
            snackbar.innerHTML = message;
        }, timeout
    );

}

/**
 * Den funker men skal ikke brukes fordi vi implementerte sessions sent og det betydde at vi hadde problemer med å bruke denne
 * man må refreshe hver gang en CRUD operasjon skjer.
 * @param String billett_type
 * @param Number pris
 */

function get_billett_type_partial(billett_type, pris) {

    let template = document.getElementById("billett_type_template");

    let templateClone = template.cloneNode(true);

    templateClone.getElementsByClassName("model_billettType")[0].innerHTML = billett_type;
    templateClone.getElementsByClassName("model_pris")[0].innerHTML = pris
    templateClone.getElementsByClassName("billett_type_endre_btn")[0].setAttribute("href", "endre_billett_type/BillettType/" + billett_type);

    let delete_btn = templateClone.getElementsByClassName("delete_container")[0];

    delete_btn.dataset.detail = billett_type + " " + pris;
    delete_btn.dataset.id = billett_type;
    delete_btn.dataset.url_delete = "slett_billett_type/BillettType";

    templateClone.classList.remove("hidden");
    templateClone.removeAttribute("id");

    return templateClone;
}