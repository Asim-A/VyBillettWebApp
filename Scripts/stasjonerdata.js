﻿let liste_stasjoner = [
    "Alna",
    "Alvdal",
    "Arendal",
    "Arna",
    "Asker",
    "Askim",
    "Atna",
    "Audnedal",
    "Auli",
    "Auma",
    "Bellingmo",
    "Berekvam",
    "Bergen",
    "Bergsgrav",
    "Berkåk",
    "Billingstad",
    "Bjerka",
    "Bjorli",
    "Bjørnfjell ",
    "Blaker",
    "Blakstad",
    "Bleiken",
    "Blomheller",
    "Blommenholm",
    "Bodung",
    "Bodø",
    "Bolstadøyri",
    "Bondivann",
    "Brakerøya",
    "Breland",
    "Brumunddal",
    "Brusand",
    "Bryn",
    "Bryne",
    "Bråstad",
    "Bulken",
    "Bø",
    "Bøylestad",
    "Charlottenberg (grense )",
    "Dal",
    "Dale",
    "Darbu",
    "Dombås",
    "Dovre",
    "Drammen",
    "Drangedal",
    "Drevvatn",
    "Dunderland",
    "Egersund",
    "Eidsberg",
    "Eidsvoll",
    "Eidsvoll verk",
    "Eina",
    "Elverum",
    "Evanger",
    "Evenstad",
    "Fauske",
    "Fetsund",
    "Finse",
    "Fjellhamar",
    "Flaten",
    "Flå",
    "Flåm",
    "Fredrikstad",
    "Frogner",
    "Froland",
    "Ganddal",
    "Gausel",
    "Geilo",
    "Gjerdåker",
    "Gjerstad",
    "Gjøvik",
    "Glåmos",
    "Gol",
    "Gran",
    "Grefsen",
    "Greverud",
    "Grong",
    "Grorud",
    "Grua",
    "Gudå",
    "Gullhella",
    "Gulskogen",
    "Gyland",
    "Haga",
    "Hakadal",
    "Halden",
    "Hallingskeid",
    "Haltdalen",
    "Hamar",
    "Hanaborg",
    "Hanestad",
    "Harestua",
    "Harran",
    "Hauerseter",
    "Haugastøl",
    "Haugenstua",
    "Hauketo",
    "Heggedal",
    "Hegra",
    "Heia",
    "Heimdal",
    "Hell",
    "Hellvik",
    "Hjerkinn",
    "Hokksund",
    "Holmestrand",
    "Holmlia",
    "Hommelvik",
    "Hovin",
    "Hunderfossen",
    "Hvalstad",
    "Høn",
    "Hønefoss",
    "Høvik",
    "Høybråten",
    "Håreina",
    "Ilseng",
    "Jaren",
    "Jessheim",
    "Jørstad",
    "Jåttåvågen",
    "Kambo",
    "Katterat",
    "Kjelsås",
    "Kjosfossen",
    "Klepp",
    "Kløfta",
    "Kløve",
    "Knapstad",
    "Kolbotn",
    "Kongsberg",
    "Kongsvinger",
    "Kongsvoll",
    "Koppang",
    "Kopperå",
    "Kotsøy",
    "Kristiansand",
    "Kråkstad",
    "Kvam",
    "Kvål",
    "Lademoen",
    "Langhus",
    "Langlete",
    "Larvik",
    "Lassemoen",
    "Leangen",
    "Leirsund",
    "Ler",
    "Lerkendal",
    "Lesja",
    "Lesjaverk",
    "Levanger",
    "Lier",
    "Lilleby",
    "Lillehammer",
    "Lillestrøm",
    "Lindeberg",
    "Ljan",
    "Ljosanbotn",
    "Lundamo",
    "Lunde",
    "Lunden",
    "Lunner",
    "Lysaker",
    "Lønsdal",
    "Lørenskog",
    "Løten",
    "Majavatn",
    "Marienborg",
    "Mariero",
    "Marnardal",
    "Melhus",
    "Meråker",
    "Mjølfjell",
    "Mjøndalen",
    "Mo i Rana",
    "Moelv",
    "Moi",
    "Mosjøen",
    "Moss",
    "Movatn",
    "Myrdal",
    "Myrvoll",
    "Mysen",
    "Mørkved",
    "Namsskogan",
    "Narvik",
    "Nationaltheatret",
    "Nelaug",
    "Nerdrum",
    "Nesbyen",
    "Neslandsvatn",
    "Nisterud",
    "Nittedal",
    "Nodeland",
    "Nordagutu",
    "Nordby",
    "Nordstrand",
    "Notodden",
    "Nydalen",
    "Nyland",
    "Nærbø",
    "Ogna",
    "Oppdal",
    "Oppegård",
    "Opphus",
    "Os",
    "Oslo Lufthavn",
    "Oslo S",
    "Oteråga",
    "Otta",
    "Paradis",
    "Porsgrunn",
    "Rakkestad",
    "Raufoss",
    "Reimegrend",
    "Reinsvoll",
    "Reinunga",
    "Reitan",
    "Rena",
    "Riksgränsen (Sverige)",
    "Ringebu",
    "Rise",
    "Roa",
    "Rognan",
    "Rognes",
    "Rombak",
    "Ronglan",
    "Rosenholm",
    "Rotvoll",
    "Rygge",
    "Røkland",
    "Røra",
    "Røros",
    "Røstad",
    "Røyken",
    "Råde",
    "Rånåsfoss",
    "Sagdalen",
    "Sande",
    "Sandefjord",
    "Sandnes sentrum",
    "Sandvika",
    "Sarpsborg",
    "Seimsgrend",
    "Selsbakk",
    "Singsås",
    "Sira",
    "Sirevåg",
    "Skansen",
    "Skarnes",
    "Skatval",
    "Skeiane",
    "Ski",
    "Skien",
    "Skiple",
    "Skogn",
    "Skonseng",
    "Skoppum",
    "Skotbu",
    "Skøyen",
    "Slependen",
    "Slitu",
    "Snartemo",
    "Snippen",
    "Snåsa",
    "Solbråtan",
    "Sonsveien",
    "Sparbu",
    "Spikkestad",
    "Spydeberg",
    "Stabekk",
    "Stai",
    "Stange",
    "Stanghelle",
    "Stavanger",
    "Steinberg",
    "Steinkjer",
    "Steinvik",
    "Stjørdal",
    "Stoa",
    "Stokke",
    "Storekvina",
    "Storlien (grense)",
    "Stryken",
    "Strømmen",
    "Støren",
    "Svingen",
    "Sørumsand",
    "Søsterbekk",
    "Tangen",
    "Tolga",
    "Tomter",
    "Torp",
    "Trengereid",
    "Trofors",
    "Trondheim Lufthavn",
    "Trondheim S",
    "Trykkerud",
    "Tuen",
    "Tverlandet",
    "Tynset",
    "Tønsberg",
    "Tøyen",
    "Upsete",
    "Urdland",
    "Ustaoset",
    "Vaksdal",
    "Vakås",
    "Valnesfjord",
    "Varhaug",
    "Varingskollen",
    "Vatnahalsen",
    "Vegårshei",
    "Vennesla",
    "Verdal",
    "Vestby",
    "Vestfossen",
    "Vevelstad",
    "Vieren",
    "Vigrestad",
    "Vikersund",
    "Vikhammer",
    "Vinstra",
    "Voss",
    "Ygre",
    "Øksnavadporten",
    "Ørneberget",
    "Øyeflaten",
    "Ål",
    "Ålen",
    "Åndalsnes",
    "Åneby",
    "Årnes",
    "Ås",
    "Åsen"
];