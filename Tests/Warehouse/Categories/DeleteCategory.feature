Feature: Usunięcie kategorii

  Scenario: Usunięcie istniejącej kategorii
    Given istnieje kategoria o następujących szczegółach:
      | Id                                   | Name      | Description           | ParentCategoryId                     | ParentCategory |
      | 123e4567-e89b-12d3-a456-426614174000 | Akcesoria | Akcesoria dla zwierząt | 223e4567-e89b-12d3-a456-426614174001 | Zwierzęta       |
    When usuwam kategorię o ID "123e4567-e89b-12d3-a456-426614174000"
    Then kategoria o ID "123e4567-e89b-12d3-a456-426614174000" nie powinna już istnieć w systemie
