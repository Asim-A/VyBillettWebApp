Vi har satt opp lagdeling per instrukser. Hensikten med lagdeling er at hvert "lag" kaller på funksjoner til lagene under. Dette brukes for å separere ansvar og som konsekvens føre til et mindre avhengig system (loose coupling & high cohesion). 

Slik som oppgaven har lagt det opp, ser arkitekturen slik ut: Prosjekt -> BLL -> DAL -> Model.
Dette fører til at mesteparten av logikken ligger i DAL og måten man grensesnitter (interfacer) med databatabasen skjer via DAL. Man grensesnitter med DAL gjennom BLL. 

I denne oppgaven har vi prøvd å sette opp administrasjon på en så virksom måte som mulig. Det mest relevante å implementere var å utføre CRUD operasjoner på billett typer. Dette er et tillegg fra forrige oppgave fordi vi tenkte det mest aktuelt å gjøre noe med. 