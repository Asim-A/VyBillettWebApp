Vi har lagd en mappe "Logiskemodeller" den inneholder modeller for klasser som kan brukes i framtiden,
men den mappen er ikke i bruk i denne oppgaven.


"Utillity"-mappen inneholder to klasser: en for å konstruere objekter som skal bli lagt inn i databasen,
det vil si at den har en metode for konstruere bestillinger og en annen metode for å konstruere billetter.
klassen "MappingUtillity" blir brukt til å ha riktig dato-format, få dato nå og noen generelle tidsmetoder
og til å definere en Dictionary for pris og forskjellige billett-typer.
Den inneholder også en metode for å få totalpris basert på hvilke type billett det er.

Pikaday er en tredjepart JavaScript Datepicker. Den består av følgende mapper og filer
pikaday er en mappe som inneholder css og et script pikaday.js, dette blir brukt for å gi kunden, 
en UI for å velge dato.

Etter du trykker "kjøp billet" tas du til et nytt view med en QRkode.
QR-koden inneholder verdien til id-en som kan bli brukt til å aksessere databasen. Hensikten med QR koden er at man ikke trenger å ha et innlogging system.
Dette er egentlig ikke sikkert, men det gjør at besvarelsen er mer komplett siden da har man "fått billettene".

