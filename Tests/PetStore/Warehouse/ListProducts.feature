Feature: Lista produktów

  Scenario: Pobranie listy produktów
    Given istnieją następujące produkty:
      | Id                                   | Name     | Description          | Quantity | Price | CategorieId                           | SupplierId                            | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | Karma    | Sucha karma dla psa  | 50       | 100   | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
      | 223e4567-e89b-12d3-a456-426614174001 | Obroża   | Obroża dla kota      | 100      | 50    | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  | 889e4567-e89b-12d3-a456-426614174333  | SourceName2          |
    When żądam listy produktów
    Then odpowiedź powinna być:
      """
      [
        {
          "Id": "123e4567-e89b-12d3-a456-426614174000",
          "Name": "Karma",
          "Description": "Sucha karma dla psa",
          "Quantity": 50,
          "Price": 100,
          "CategorieId": "223e4567-e89b-12d3-a456-426614174001",
          "SupplierId": "323e4567-e89b-12d3-a456-426614174002",
          "ExternalId": "789e4567-e89b-12d3-a456-426614174222",
          "ExternalSourceName": "SourceName1"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "Obroża",
          "Description": "Obroża dla kota",
          "Quantity": 100,
          "Price": 50,
          "CategorieId": "223e4567-e89b-12d3-a456-426614174001",
          "SupplierId": "323e4567-e89b-12d3-a456-426614174002",
          "ExternalId": "889e4567-e89b-12d3-a456-426614174333",
          "ExternalSourceName": "SourceName2"
        }
      ]
      """
