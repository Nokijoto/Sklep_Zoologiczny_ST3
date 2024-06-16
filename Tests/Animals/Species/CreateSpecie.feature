Feature: Tworzenie gatunku

  Scenario: Dodanie nowego gatunku
    Given następujące szczegóły gatunku:
      | Name     |
      | Ursidae  |
    When tworzę nowy gatunek z tymi szczegółami
    Then odpowiedź powinna być:
      """
      {
        "Id": "<generated-id>",
        "Name": "Ursidae"
      }
      """
    And gatunek o ID "<generated-id>" powinien istnieć w systemie
