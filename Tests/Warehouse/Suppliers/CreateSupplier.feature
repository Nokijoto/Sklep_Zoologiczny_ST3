Feature: Tworzenie dostawcy

  Scenario: Dodanie nowego dostawcy
    Given następujące szczegóły dostawcy:
      | Name           | Email              | Phone         | Street         | City        | State          | ZipCode | Country    |
      | New Supplier   | new@example.com    | 555-555-5555  | New St 789     | Lodz        | Lodz Voivodeship | 90-003  | Poland     |
    When tworzę nowego dostawcę z tymi szczegółami
    Then odpowiedź powinna być:
      """
      {
        "Id": "<generated-id>",
        "Name": "New Supplier",
        "Email": "new@example.com",
        "Phone": "555-555-5555",
        "Street": "New St 789",
        "City": "Lodz",
        "State": "Lodz Voivodeship",
        "ZipCode": "90-003",
        "Country": "Poland"
      }
      """
    And dostawca o ID "<generated-id>" powinien istnieć w systemie
