Feature: Pobierz zwierzę po ID

  Scenario: Pobranie zwierzęcia po ID
    Given istnieje zwierzę o następujących szczegółach:
      | Id                                   | Name     | Breed       | Age | Gender  | Price | SpecieId                            | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | Max      | Labrador    | 5   | Male    | 300   | 456e7890-e89b-12d3-a456-426614174111 | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
    When żądam zwierzęcia o ID "123e4567-e89b-12d3-a456-426614174000"
    Then odpowiedź powinna być:
      """
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
      }
      """
