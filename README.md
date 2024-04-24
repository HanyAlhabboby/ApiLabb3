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
