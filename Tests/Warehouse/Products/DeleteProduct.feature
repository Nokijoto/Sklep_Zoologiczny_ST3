Feature: Usunięcie produktu

  Scenario: Usunięcie istniejącego produktu
    Given istnieje produkt o następujących szczegółach:
      | Id                                   | Name       | Description           | Quantity | Price | CategorieId                           | SupplierId                            |
      | 123e4567-e89b-12d3-a456-426614174000 | Karma      | Sucha karma dla psa   | 50       | 100   | 223e4567-e89b-12d3-a456-426614174001 | 323e4567-e89b-12d3-a456-426614174002  |
    When usuwam produkt o ID "123e4567-e89b-12d3-a456-426614174000"
    Then produkt o ID "123e4567-e89b-12d3-a456-426614174000" nie powinien już istnieć w systemie
