Feature: Pobieranie informacji o dostawcy
  Jako użytkownik API
  Chcę pobrać informacje o konkretnym dostawcy
  Aby móc zobaczyć szczegóły dotyczące tego dostawcy

  Scenario: Pobranie dostawcy po ID
    Given istnieje API pod adresem "/warehouse/suppliers/{id}"
    And dostawca o ID 1 istnieje w systemie
    When wysyłam żądanie GET na endpoint "/warehouse/suppliers/1"
    Then otrzymuję odpowiedź z kodem statusu 200
    And odpowiedź zawiera "id" = 1
    And odpowiedź zawiera "name" i "contact"
