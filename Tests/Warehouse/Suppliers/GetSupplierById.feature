Feature: Pobierz dostawcę po ID

  Scenario: Pobranie dostawcy po ID
    Given istnieje dostawca o następujących szczegółach:
      | Id                                   | Name           | Email              | Phone         | Street           | City        | State  | ZipCode | Country    |
      | 123e4567-e89b-12d3-a456-426614174000 | ABC Supplier   | abc@example.com    | 123-456-7890  | Main St 123      | Warsaw      | Mazovia| 00-001  | Poland     |
    When żądam dostawcy o ID "123e4567-e89b-12d3-a456-426614174000"
    Then odpowiedź powinna być:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "ABC Supplier",
        "Email": "abc@example.com",
        "Phone": "123-456-7890",
        "Street": "Main St 123",
        "City": "Warsaw",
        "State": "Mazovia",
        "ZipCode": "00-001",
        "Country": "Poland"
      }
      """
