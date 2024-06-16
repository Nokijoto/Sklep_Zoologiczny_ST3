Feature: Pobierz kategorię po ID

  Scenario: Pobranie kategorii po ID
    Given istnieje kategoria o następujących szczegółach:
      | Id                                   | Name       | Description           | ParentCategoryId                     | ParentCategory |
      | 123e4567-e89b-12d3-a456-426614174000 | Akcesoria  | Akcesoria dla zwierząt | 223e4567-e89b-12d3-a456-426614174001 | Zwierzęta       |
    When żądam kategorii o ID "123e4567-e89b-12d3-a456-426614174000"
    Then odpowiedź powinna być:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "Akcesoria",
        "Description": "Akcesoria dla zwierząt",
        "ParentCategoryId": "223e4567-e89b-12d3-a456-426614174001",
        "ParentCategory": "Zwierzęta"
      }
      """
