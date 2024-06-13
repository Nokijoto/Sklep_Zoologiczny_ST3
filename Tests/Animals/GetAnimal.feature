Feature: Pobieranie informacji o konkretnym zwierzęciu
  Jako użytkownik API
  Chcę pobrać informacje o konkretnym zwierzęciu
  Aby móc zobaczyć szczegóły dotyczące tego zwierzęcia

  Scenario: Pobranie zwierzęcia po ID
    Given istnieje API pod adresem "/animals/{id}"
    And zwierzę o ID 1 istnieje w systemie
    When wysyłam żądanie GET na endpoint "/animals/1"
    Then otrzymuję odpowiedź z kodem statusu 200
    And odpowiedź zawiera "id" = 1
    And odpowiedź zawiera "name" i "species"
