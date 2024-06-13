Feature: Pobieranie listy zwierząt
  Jako użytkownik API
  Chcę pobrać listę dostępnych zwierząt
  Aby móc zobaczyć jakie zwierzęta są dostępne w sklepie

  Scenario: Pobranie wszystkich zwierząt
    Given istnieje API pod adresem "/animals"
    When wysyłam żądanie GET na endpoint "/animals"
    Then otrzymuję odpowiedź z kodem statusu 200
    And odpowiedź zawiera listę zwierząt z polami "id", "name", "species"
