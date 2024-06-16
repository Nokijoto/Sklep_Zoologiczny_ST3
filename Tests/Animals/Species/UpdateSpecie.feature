Feature: Aktualizacja gatunku

  Scenario: Aktualizacja szczegółów istniejącego gatunku
    Given istnieje gatunek o następujących szczegółach:
      | Id                                   | Name      |
      | 123e4567-e89b-12d3-a456-426614174000 | Canidae   |
    When aktualizuję gatunek o ID "123e4567-e89b-12d3-a456-426614174000" do:
      """
      {
        "Name": "Canis"
      }
      """
    Then gatunek o ID "123e4567-e89b-12d3-a456-426614174000" powinien mieć następujące szczegóły:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "Canis"
      }
      """
