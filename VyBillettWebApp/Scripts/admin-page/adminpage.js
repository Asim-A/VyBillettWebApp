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
    $("a[data-modal_delete=true]").click(function () {

        // hent inn data-taggene fra denne a-hef lenken
        let modal_data_detail = $(this).data("detail");
        let modal_data_id = $(this).data("id");
        let modal_data_url_self = $(this).data("url_self");
        let modal_data_url_delete = $(this).data(url_delete);


        // legg ut dataene i div'en i modal-view'et
        $('#modal_delete_data_detail').html(modal_data_detail);

        // lag en hendelse for knappen for å slette via ajax, knappen ligger i modal-view'et
        // må ligge inne i denne overordnede funksjonen for at id'én som er valgt kan brukes
        $("#modal_delete_btn").click(function () {
            // id som skal slettes ligger i data_id
            $.ajax({
                url: modal_data_url_delete,
                data: { id: data_id },  // en parameter inn i slett(id)-metoden i kunde-kontrolleren (JSON-objekt)
                success: function () {
                    // må kalle liste-metoden for å vise den nye listen av kunder
                    $.ajax({
                        url: modal_data_url_self,
                        success: function () {
                            // så må siden reloades!
                            window.location.reload();
                        }
                    });
                }
            });
        })
    })

}

