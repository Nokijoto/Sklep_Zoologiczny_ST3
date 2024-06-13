Feature: Usuwanie zwierzęcia
  Jako administrator
  Chcę usunąć zwierzę z systemu
  Aby móc zarządzać ofertą sklepu

  Scenario: Usunięcie zwierzęcia po ID
    Given istnieje API pod adresem "/animals/{id}"
    And zwierzę o ID 1 istnieje w systemie
    When wysyłam żądanie DELETE na endpoint "/animals/1"
    Then otrzymuję odpowiedź z kodem statusu 204
    And zwierzę o ID 1 nie istnieje już w systemie
