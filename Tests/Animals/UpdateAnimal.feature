Feature: Aktualizowanie informacji o zwierzęciu
  Jako administrator
  Chcę zaktualizować informacje o zwierzęciu
  Aby dane w systemie były aktualne

  Scenario: Aktualizacja zwierzęcia po ID
    Given istnieje API pod adresem "/animals/{id}"
    And zwierzę o ID 1 istnieje w systemie
    When wysyłam żądanie PUT na endpoint "/animals/1" z danymi:
      """
      {
        "name": "Leo",
        "species": "Lion"
      }
      """
    Then otrzymuję odpowiedź z kodem statusu 200
    And odpowiedź zawiera zaktualizowane dane zwierzęcia
    And odpowiedź zawiera "name" = "Leo"
    And odpowiedź zawiera "species" = "Lion"
