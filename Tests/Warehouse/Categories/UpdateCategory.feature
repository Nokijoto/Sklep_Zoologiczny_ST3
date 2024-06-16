Feature: Aktualizacja kategorii

  Scenario: Aktualizacja szczegółów istniejącej kategorii
    Given istnieje kategoria o następujących szczegółach:
      | Id                                   | Name      | Description           | ParentCategoryId                     | ParentCategory |
      | 123e4567-e89b-12d3-a456-426614174000 | Akcesoria | Akcesoria dla zwierząt | 223e4567-e89b-12d3-a456-426614174001 | Zwierzęta       |
    When aktualizuję kategorię o ID "123e4567-e89b-12d3-a456-426614174000" do:
      """
      {
        "Name": "Akcesoria dla psów",
        "Description": "Specjalne akcesoria dla psów",
        "ParentCategoryId": "223e4567-e89b-12d3-a456-426614174001",
        "ParentCategory": "Zwierzęta"
      }
      """
    Then kategoria o ID "123e4567-e89b-12d3-a456-426614174000" powinna mieć następujące szczegóły:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "Akcesoria dla psów",
        "Description": "Specjalne akcesoria dla psów",
        "ParentCategoryId": "223e4567-e89b-12d3-a456-426614174001",
        "ParentCategory": "Zwierzęta"
      }
      """
