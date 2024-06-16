Feature: Usunięcie gatunku

  Scenario: Usunięcie istniejącego gatunku
    Given istnieje gatunek o następujących szczegółach:
      | Id                                   | Name     |
      | 123e4567-e89b-12d3-a456-426614174000 | Canidae  |
    When usuwam gatunek o ID "123e4567-e89b-12d3-a456-426614174000"
    Then gatunek o ID "123e4567-e89b-12d3-a456-426614174000" nie powinien już istnieć w systemie
