Feature: Lista gatunków

  Scenario: Pobranie listy gatunków
    Given istnieją następujące gatunki:
      | Id                                   | Name      | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | Canidae   | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
      | 223e4567-e89b-12d3-a456-426614174001 | Felidae   | 889e4567-e89b-12d3-a456-426614174333  | SourceName2          |
    When żądam listy gatunków
    Then odpowiedź powinna być:
      """
      [
        {
          "Id": "123e4567-e89b-12d3-a456-426614174000",
          "Name": "Canidae",
          "ExternalId": "789e4567-e89b-12d3-a456-426614174222",
          "ExternalSourceName": "SourceName1"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "Felidae",
          "ExternalId": "889e4567-e89b-12d3-a456-426614174333",
          "ExternalSourceName": "SourceName2"
        }
      ]
      """
