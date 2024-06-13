Feature: Pobieranie listy przedmiotów w magazynie
  Jako użytkownik API
  Chcę pobrać listę dostępnych przedmiotów w magazynie
  Aby móc zobaczyć jakie produkty są dostępne

  Scenario: Pobranie wszystkich przedmiotów
    Given istnieje API pod adresem "/warehouse/items"
    When wysyłam żądanie GET na endpoint "/warehouse/items"
    Then otrzymuję odpowiedź z kodem statusu 200
    And odpowiedź zawiera listę przedmiotów z polami "id", "name", "supplier"
