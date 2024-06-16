Feature: Tworzenie produktu

  Scenario: Dodanie nowego produktu
    Given następujące szczegóły produktu:
      | Name        | Description           | Quantity | Price | CategorieId                           | SupplierId                            |
      | Zabawka     | Zabawka dla psa       | 30       | 20    | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  |
    When tworzę nowy produkt z tymi szczegółami
    Then odpowiedź powinna być:
      """
      {
        "Id": "<generated-id>",
        "Name": "Zabawka",
        "Description": "Zabawka dla psa",
        "Quantity": 30,
        "Price": 20,
        "CategorieId": "223e4567-e89b-12d3-a456-426614174001",
        "SupplierId": "323e4567-e89b-12d3-a456-426614174002"
      }
      """
    And produkt o ID "<generated-id>" powinien istnieć w systemie
