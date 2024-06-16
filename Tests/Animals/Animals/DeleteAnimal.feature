Feature: Usunięcie zwierzęcia

  Scenario: Usunięcie istniejącego zwierzęcia
    Given istnieje zwierzę o następujących szczegółach:
      | Id                                   | Name  | Breed    | Age | Gender  | Price | SpecieId                            |
      | 123e4567-e89b-12d3-a456-426614174000 | Max   | Labrador | 5   | Male    | 300   | 456e7890-e89b-12d3-a456-426614174111 |
    When usuwam zwierzę o ID "123e4567-e89b-12d3-a456-426614174000"
    Then zwierzę o ID "123e4567-e89b-12d3-a456-426614174000" nie powinno już istnieć w systemie
