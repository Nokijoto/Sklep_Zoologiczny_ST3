Feature: Lista produktów według kategorii

  Scenario: Pobranie listy produktów dla danej kategorii
    Given istnieją następujące produkty w kategorii o ID "223e4567-e89b-12d3-a456-426614174001":
      | Id                                   | Name       | Description           | Quantity | Price | CategorieId                           | SupplierId                            |
      | 123e4567-e89b-12d3-a456-426614174000 | Karma      | Sucha karma dla psa   | 50       | 100   | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  |
      | 223e4567-e89b-12d3-a456-426614174001 | Obroża     | Obroża dla kota       | 100      | 50    | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  |
    When żądam listy produktów dla kategorii o ID "223e4567-e89b-12d3-a456-426614174001"
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
          "SupplierId": "323e4567-e89b-12d3-a456-426614174002"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "Obroża",
          "Description": "Obroża dla kota",
          "Quantity": 100,
          "Price": 50,
          "CategorieId": "223e4567-e89b-12d3-a456-426614174001",
          "SupplierId": "323e4567-e89b-12d3-a456-426614174002"
        }
      ]
      """
