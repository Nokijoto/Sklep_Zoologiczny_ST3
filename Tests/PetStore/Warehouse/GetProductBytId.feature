Feature: Pobierz produkt po ID

  Scenario: Pobranie produktu po ID
    Given istnieje produkt o następujących szczegółach:
      | Id                                   | Name     | Description          | Quantity | Price | CategorieId                           | SupplierId                            | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | Karma    | Sucha karma dla psa  | 50       | 100   | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
    When żądam produktu o ID "123e4567-e89b-12d3-a456-426614174000"
    Then odpowiedź powinna być:
      """
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
      }
      """
