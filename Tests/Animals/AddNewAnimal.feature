Feature: Dodawanie nowego zwierzęcia
  Jako administrator
  Chcę dodać nowe zwierzę do systemu
  Aby móc rozszerzyć ofertę sklepu

  Scenario: Dodanie nowego zwierzęcia
    Given istnieje API pod adresem "/animals"
    When wysyłam żądanie POST na endpoint "/animals" z danymi zwierzęcia:
      """
      {
        "name": "Leo",
        "species": "Lion"
      }
      """
    Then otrzymuję odpowiedź z kodem statusu 201
    And odpowiedź zawiera "id" nowo dodanego zwierzęcia
    And odpowiedź zawiera "name" = "Leo"
    And odpowiedź zawiera "species" = "Lion"
