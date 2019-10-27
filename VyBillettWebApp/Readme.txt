Vi har satt opp lagdeling per instrukser. Hensikten med lagdeling er at hvert "lag" kaller på funksjoner til lagene under. Dette brukes for å separere ansvar og som konsekvens føre til et mindre avhengig system (loose coupling & high cohesion). 

Slik som oppgaven har lagt det opp, ser arkitekturen slik ut: Prosjekt -> BLL -> DAL -> Model.
Dette fører til at mesteparten av logikken ligger i DAL og måten man grensesnitter (interfacer) med databatabasen skjer via DAL. Man grensesnitter med DAL gjennom BLL. 

I denne oppgaven har vi prøvd å sette opp administrasjon på en så virksom måte som mulig. Det mest relevante å implementere var å utføre CRUD operasjoner på billett typer. Dette er et tillegg fra forrige oppgave fordi vi tenkte det mest aktuelt å gjøre noe med. 

Vi fikk ikke tid for administrering av admin brukere. For å vise forståelse legger vi til hvordan vi hadde løst problemstillingen hvis vi hadde annledning: Hatt veldig likt oppsett slik som billett typer sin side. En add knapp som åpner opp en modal der man kan taste inn brukernavn og passord. Ved tastetrykk vil så et ajax post call som kaller på en metode i AdminController. Post callet vil vært av et json objekt der nøkkel/verdi -ene hadde vært epost og passord. I AdminController ville det så bli opprettet en BrukerBLL der "registrerBruker" metoden hadde blitt brukt.

Det vi også veldig gjerne ville gjøre var å implementere interfacer i DAL for hver modell, som både DAL og stubbene arvet fra. 

Pålogginginformasjon for admin:
email: tester1@oslomet.com
passord: Tester1 