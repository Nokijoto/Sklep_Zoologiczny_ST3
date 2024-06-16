Feature: Lista zwierząt

  Scenario: Pobranie listy zwierząt
    Given istnieją następujące zwierzęta:
      | Id                                   | Name     | Breed     | Age | Gender  | Price | SpecieId                            | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | Max      | Labrador  | 5   | Male    | 300   | 456e7890-e89b-12d3-a456-426614174111 | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
      | 223e4567-e89b-12d3-a456-426614174001 | Bella    | Poodle    | 3   | Female  | 400   | 556e7890-e89b-12d3-a456-426614174222 | 889e4567-e89b-12d3-a456-426614174333  | SourceName2          |
    When żądam listy zwierząt
    Then odpowiedź powinna być:
      """
      [
        {
          "Id": "123e4567-e89b-12d3-a456-426614174000",
          "Name": "Max",
          "Breed": "Labrador",
          "Age": 5,
          "Gender": "Male",
          "Price": 300,
          "SpecieId": "456e7890-e89b-12d3-a456-426614174111",
          "ExternalId": "789e4567-e89b-12d3-a456-426614174222",
          "ExternalSourceName": "SourceName1"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "Bella",
          "Breed": "Poodle",
          "Age": 3,
          "Gender": "Female",
          "Price": 400,
          "SpecieId": "556e7890-e89b-12d3-a456-426614174222",
          "ExternalId": "889e4567-e89b-12d3-a456-426614174333",
          "ExternalSourceName": "SourceName2"
        }
      ]
      """
