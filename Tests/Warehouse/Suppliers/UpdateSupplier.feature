Feature: Aktualizacja dostawcy

  Scenario: Aktualizacja szczegółów istniejącego dostawcy
    Given istnieje dostawca o następujących szczegółach:
      | Id                                   | Name           | Email              | Phone         | Street           | City        | State  | ZipCode | Country    |
      | 123e4567-e89b-12d3-a456-426614174000 | ABC Supplier   | abc@example.com    | 123-456-7890  | Main St 123      | Warsaw      | Mazovia| 00-001  | Poland     |
    When aktualizuję dostawcę o ID "123e4567-e89b-12d3-a456-426614174000" do:
      """
      {
        "Name": "ABC Supplier Updated",
        "Email": "abc_updated@example.com",
        "Phone": "123-456-7899",
        "Street": "Main St 124",
        "City": "Warsaw",
        "State": "Mazovia",
        "ZipCode": "00-002",
        "Country": "Poland"
      }
      """
    Then dostawca o ID "123e4567-e89b-12d3-a456-426614174000" powinien mieć następujące szczegóły:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "ABC Supplier Updated",
        "Email": "abc_updated@example.com",
        "Phone": "123-456-7899",
        "Street": "Main St 124",
        "City": "Warsaw",
        "State": "Mazovia",
        "ZipCode": "00-002",
        "Country": "Poland"
      }
      """
