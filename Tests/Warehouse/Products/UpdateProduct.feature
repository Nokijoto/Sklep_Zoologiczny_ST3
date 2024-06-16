Feature: Aktualizacja produktu

  Scenario: Aktualizacja szczegółów istniejącego produktu
    Given istnieje produkt o następujących szczegółach:
      | Id                                   | Name       | Description           | Quantity | Price | CategorieId                           | SupplierId                            |
      | 123e4567-e89b-12d3-a456-426614174000 | Karma      | Sucha karma dla psa   | 50       | 100   | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  |
    When aktualizuję produkt o ID "123e4567-e89b-12d3-a456-426614174000" do:
      """
      {
        "Name": "Karma premium",
        "Description": "Sucha karma premium dla psa",
        "Quantity": 60,
        "Price": 150,
        "CategorieId": "223e4567-e89b-12d3-a456-426614174001",
        "SupplierId": "323e4567-e89b-12d3-a456-426614174002"
      }
      """
    Then produkt o ID "123e4567-e89b-12d3-a456-426614174000" powinien mieć następujące szczegóły:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "Karma premium",
        "Description": "Sucha karma premium dla psa",
        "Quantity": 60,
        "Price": 150,
        "CategorieId": "223e4567-e89b-12d3-a456-426614174001",
        "SupplierId": "323e4567-e89b-12d3-a456-426614174002"
      }
      """
