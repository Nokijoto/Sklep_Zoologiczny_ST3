Feature: Usunięcie dostawcy

  Scenario: Usunięcie istniejącego dostawcy
    Given istnieje dostawca o następujących szczegółach:
      | Id                                   | Name           | Email              | Phone         | Street           | City        | State  | ZipCode | Country    |
      | 123e4567-e89b-12d3-a456-426614174000 | ABC Supplier   | abc@example.com    | 123-456-7890  | Main St 123      | Warsaw      | Mazovia| 00-001  | Poland     |
    When usuwam dostawcę o ID "123e4567-e89b-12d3-a456-426614174000"
    Then dostawca o ID "123e4567-e89b-12d3-a456-426614174000" nie powinien już istnieć w systemie
