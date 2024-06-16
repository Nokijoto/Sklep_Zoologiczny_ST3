Feature: Lista gatunków

  Scenario: Pobranie listy gatunków
    Given istnieją następujące gatunki:
      | Id                                   | Name      |
      | 123e4567-e89b-12d3-a456-426614174000 | Canidae   |
      | 223e4567-e89b-12d3-a456-426614174001 | Felidae   |
    When żądam listy gatunków
    Then odpowiedź powinna być:
      """
      [
        {
          "Id": "123e4567-e89b-12d3-a456-426614174000",
          "Name": "Canidae"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "Felidae"
        }
      ]
      """
