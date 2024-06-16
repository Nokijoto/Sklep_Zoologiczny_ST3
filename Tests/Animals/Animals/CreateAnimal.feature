Feature: Tworzenie zwierzęcia

  Scenario: Dodanie nowego zwierzęcia
    Given następujące szczegóły zwierzęcia:
      | Name     | Breed   | Age | Gender  | Price | SpecieId                            |
      | Charlie  | Beagle  | 2   | Male    | 200   | 789e7890-e89b-12d3-a456-426614174333 |
    When tworzę nowe zwierzę z tymi szczegółami
    Then odpowiedź powinna być:
      """
      {
        "Id": "<generated-id>",
        "Name": "Charlie",
        "Breed": "Beagle",
        "Age": 2,
        "Gender": "Male",
        "Price": 200,
        "SpecieId": "789e7890-e89b-12d3-a456-426614174333"
      }
      """
    And zwierzę o ID "<generated-id>" powinno istnieć w systemie
