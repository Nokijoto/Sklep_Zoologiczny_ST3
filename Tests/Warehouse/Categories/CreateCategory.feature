Feature: Tworzenie kategorii

  Scenario: Dodanie nowej kategorii
    Given następujące szczegóły kategorii:
      | Name     | Description          | ParentCategoryId                     | ParentCategory |
      | Karmy    | Karmy dla zwierząt   | 223e4567-e89b-12d3-a456-426614174001 | Zwierzęta       |
    When tworzę nową kategorię z tymi szczegółami
    Then odpowiedź powinna być:
      """
      {
        "Id": "<generated-id>",
        "Name": "Karmy",
        "Description": "Karmy dla zwierząt",
        "ParentCategoryId": "223e4567-e89b-12d3-a456-426614174001",
        "ParentCategory": "Zwierzęta"
      }
      """
    And kategoria o ID "<generated-id>" powinna istnieć w systemie
