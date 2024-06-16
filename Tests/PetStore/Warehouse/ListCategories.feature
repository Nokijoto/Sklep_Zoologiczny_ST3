Feature: Lista kategorii

  Scenario: Pobranie listy kategorii
    Given istnieją następujące kategorie:
      | Id                                   | Name      | Description            | ParentCategoryId                     | ParentCategory | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | Akcesoria | Akcesoria dla zwierząt | 223e4567-e89b-12d3-a456-426614174001 | Zwierzęta      | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
      | 223e4567-e89b-12d3-a456-426614174001 | Zwierzęta | Wszystkie zwierzęta    | null                                  | null            | 889e4567-e89b-12d3-a456-426614174333  | SourceName2          |
    When żądam listy kategorii
    Then odpowiedź powinna być:
      """
      [
        {
          "Id": "123e4567-e89b-12d3-a456-426614174000",
          "Name": "Akcesoria",
          "Description": "Akcesoria dla zwierząt",
          "ParentCategoryId": "223e4567-e89b-12d3-a456-426614174001",
          "ParentCategory": "Zwierzęta",
          "ExternalId": "789e4567-e89b-12d3-a456-426614174222",
          "ExternalSourceName": "SourceName1"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "Zwierzęta",
          "Description": "Wszystkie zwierzęta",
          "ParentCategoryId": null,
          "ParentCategory": null,
          "ExternalId": "889e4567-e89b-12d3-a456-426614174333",
          "ExternalSourceName": "SourceName2"
        }
      ]
      """
