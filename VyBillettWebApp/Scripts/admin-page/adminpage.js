/*
 * 
*/

$(document).ready(function () {
    setup_modal_delete_ajax();
});


/*
 * Setter opp on click function på anchor-tag med attribute data-modal_delete=true. 
 * Deretter hentes alle data-attributter sine verdier med nøkler ut. 
 * Disse blir brukt til å sette opp modalen (detail), finne id-en til elementet som skal fjernes (id),
 * redirect url som skal være samme side med oppdatert info (url_self) og til slutt url til "action"
 * som tar seg av oppdateringen av databasen. 
 * 
*/ 
function setup_modal_delete_ajax() {

    // lag en hendelse som utføres når en a-href med "data-SletteModal = true" trykkes.
    $("a[data-modal_delete=true]").click(function() {

        console.log($(this).attr("data-id"));

        // hent inn data-taggene fra denne a-hef lenken
        const modal_data_detail = $(this).data("detail");
        const modal_data_id = $(this).data("id");
        let modal_data_url_self = $(this).data("url_self");
        let modal_data_url_delete = $(this).data("url_delete");

        // legg ut dataene i div'en i modal-view'et
        $('#modal_delete_data_detail').html(modal_data_detail);

        // lag en hendelse for knappen for å slette via ajax, knappen ligger i modal-view'et
        // må ligge inne i denne overordnede funksjonen for at id'én som er valgt kan brukes
        $("#modal_delete_btn").click(function () {
            // id som skal slettes ligger i data_id
            $.ajax({
                url: "/Home/slett_billett_type",
                data: { billett_type: modal_data_id },  // en parameter inn i slett(id)-metoden i kunde-kontrolleren (JSON-objekt)
                success: function () {
                    // må kalle liste-metoden for å vise den nye listen av kunder
                    $.ajax({
                        url: "/Home/get_billett_typer",
                        type: 'GET',
                        dataType: 'json',
                        success: function (liste) {
                            const container = document.getElementById("component-container");
                            container.innerHTML = "";

                            console.log(liste[0]["billett_type"] + " " + liste[0]["pris"]);

                            for (let itemIndex = 0; itemIndex < liste.length; itemIndex++) {
                                console.log(liste[itemIndex]["billett_type"] + " " + liste[itemIndex]["pris"]);
                                container.appendChild(get_billett_type_partial(liste[itemIndex]["billett_type"], liste[itemIndex]["pris"]));
                            }
                        },error: function (x, y, z) {
                            alert(x + '\n' + y + '\n' + z);
                        }
                    });
                }, error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        })
    })

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