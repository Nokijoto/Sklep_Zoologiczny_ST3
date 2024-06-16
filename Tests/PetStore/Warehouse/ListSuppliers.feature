Feature: Lista dostawców

  Scenario: Pobranie listy dostawców
    Given istnieją następujący dostawcy:
      | Id                                   | Name           | Email              | Phone         | Street           | City        | State          | ZipCode | Country  | ExternalId                             | ExternalSourceName |
      | 123e4567-e89b-12d3-a456-426614174000 | ABC Supplier   | abc@example.com    | 123-456-7890  | Main St 123      | Warsaw      | Mazovia        | 00-001  | Poland   | 789e4567-e89b-12d3-a456-426614174222  | SourceName1          |
      | 223e4567-e89b-12d3-a456-426614174001 | XYZ Supplier   | xyz@example.com    | 987-654-3210  | Second St 456    | Krakow      | Lesser Poland  | 30-002  | Poland   | 889e4567-e89b-12d3-a456-426614174333  | SourceName2          |
    When żądam listy dostawców
    Then odpowiedź powinna być:
      """
      [
        {
          "Id": "123e4567-e89b-12d3-a456-426614174000",
          "Name": "ABC Supplier",
          "Email": "abc@example.com",
          "Phone": "123-456-7890",
          "Street": "Main St 123",
          "City": "Warsaw",
          "State": "Mazovia",
          "ZipCode": "00-001",
          "Country": "Poland",
          "ExternalId": "789e4567-e89b-12d3-a456-426614174222",
          "ExternalSourceName": "SourceName1"
        },
        {
          "Id": "223e4567-e89b-12d3-a456-426614174001",
          "Name": "XYZ Supplier",
          "Email": "xyz@example.com",
          "Phone": "987-654-3210",
          "Street": "Second St 456",
          "City": "Krakow",
          "State": "Lesser Poland",
          "ZipCode": "30-002",
          "Country": "Poland",
          "ExternalId": "889e4567-e89b-12d3-a456-426614174333",
          "ExternalSourceName": "SourceName2"
        }
      ]
      """
