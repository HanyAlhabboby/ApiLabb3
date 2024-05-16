## API

#### I den här labben ska du testa att bygga ditt första enkla Webb-API. Det API du kommer konstruera använder en REST-arkitektur och kommer möjliggöra för externa tjänster och applikationer att hämta och ändra data i din egen applikation.



## **Applikationen/databasen**

#### Det första du ska skapa är en väldigt grundläggande API med en databas som klarar följande.

#### - [ ]  Det ska gå att lagra personer med grundläggande information om dem som namn och telefonnummer.
#### - [ ]  Systemet ska kunna lagra ett obegränsat antal intressen som de har. Varje intresse ska ha en titel och en kort beskrivning.
#### - [ ]  Varje person ska kunna vara kopplad till ett valfritt antal intressen
#### - [ ]  Det ska gå att lagra ett obegränsat antal länkar (till webbplatser) till varje intresse för varje person. Om en person lägger in en länk så är den alltså kopplad både till den personen och till det intresset.


## **Skapa ett REST-API**

#### Det andra steget du ska göra är att skapa ett REST-API som tillåter externa tjänster att utföra följande anrop till ditt API samt genomför dessa förändringar i din applikation.

#### - [ ]  Hämta alla personer i systemet
#### - [ ]  Hämta alla intressen som är kopplade till en specifik person
#### - [ ]  Hämta alla länkar som är kopplade till en specifik person
#### - [ ]  Koppla en person till ett nytt intresse
#### - [ ]  Lägga in nya länkar för en specifik person och ett specifikt intresse



####  Get all people
#### https://localhost:7240/persons
#### [
  {
    "personId": 2,
    "personName": "Hany Alhabboby",
    "phoneNumber": 735546615,
    "interests": []
  },
  {
    "personId": 3,
    "personName": "Nil Nilson",
    "phoneNumber": 649929944,
    "interests": []
  },
  {
    "personId": 4,
    "personName": "Sebastian Larson",
    "phoneNumber": 499994888,
    "interests": []
  },
  {
    "personId": 5,
    "personName": "Ali Abbas",
    "phoneNumber": 548181151,
    "interests": []
  }
]
#### GET person by ID (3 for exampel)
#### https://localhost:7240/person/3

#### {
  "$id": "1",
  "PersonId": 3,
  "PersonName": "Nil Nilson",
  "PhoneNumber": 649929944,
  "Interests": {
    "$id": "2",
    "$values": [
      {
        "$id": "3",
        "InterestId": 3,
        "Titel": "Builder",
        "Description": "Building Houses",
        "FkPersonId": 3,
        "Person": {
          "$ref": "1"
        },
        "Links": null
      },
      {
        "$id": "4",
        "InterestId": 13,
        "Titel": "Books",
        "Description": "reading",
        "FkPersonId": 3,
        "Person": {
          "$ref": "1"
        },
        "Links": null
      }
    ]
  }
}

#### GET Link by ID (3 for exampel)
#### https://localhost:7240/InterestLinks/3

#### {
  "$id": "1",
  "InterestId": 3,
  "Titel": "Builder",
  "Description": "Building Houses",
  "FkPersonId": 3,
  "Person": null,
  "Links": {
    "$id": "2",
    "$values": [
      {
        "$id": "3",
        "LinkId": 2,
        "LinkInfo": "https://www.houseplans.com/",
        "FkInterestId": 3,
        "Interest": {
          "$ref": "1"
        }
      }
    ]
  }
}

#### POST Interest (for ID 5 for exampel)
#### https://localhost:7240/person/5/Interests

#### {
  "$id": "1",
  "InterestId": 15,
  "Titel": "Playstation",
  "Description": "Playing games",
  "FkPersonId": 5,
  "Person": {
    "$id": "2",
    "PersonId": 5,
    "PersonName": "Ali Abbas",
    "PhoneNumber": 548181151,
    "Interests": {
      "$id": "3",
      "$values": [
        {
          "$ref": "1"
        }
      ]
    }
  },
  "Links": null
}

#### POST Link (for interest ID 4 for exampel)
#### https://localhost:7240/person/4/Links

#### {
  "$id": "1",
  "LinkId": 10,
  "LinkInfo": "www.github.com",
  "FkInterestId": 4,
  "Interest": null
}
