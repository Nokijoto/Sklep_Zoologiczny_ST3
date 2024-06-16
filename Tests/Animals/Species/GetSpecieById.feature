Feature: Pobierz gatunek po ID

  Scenario: Pobranie gatunku po ID
    Given istnieje gatunek o następujących szczegółach:
      | Id                                   | Name     |
      | 123e4567-e89b-12d3-a456-426614174000 | Canidae  |
    When żądam gatunku o ID "123e4567-e89b-12d3-a456-426614174000"
    Then odpowiedź powinna być:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "Canidae"
      }
      """
