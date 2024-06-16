Feature: Aktualizacja zwierzęcia

  Scenario: Aktualizacja szczegółów istniejącego zwierzęcia
    Given istnieje zwierzę o następujących szczegółach:
      | Id                                   | Name  | Breed    | Age | Gender  | Price | SpecieId                            |
      | 123e4567-e89b-12d3-a456-426614174000 | Max   | Labrador | 5   | Male    | 300   | 456e7890-e89b-12d3-a456-426614174111 |
    When aktualizuję zwierzę o ID "123e4567-e89b-12d3-a456-426614174000" do:
      """
      {
        "Name": "Maximus",
        "Breed": "Golden Retriever",
        "Age": 6,
        "Gender": "Male",
        "Price": 350,
        "SpecieId": "456e7890-e89b-12d3-a456-426614174111"
      }
      """
    Then zwierzę o ID "123e4567-e89b-12d3-a456-426614174000" powinno mieć następujące szczegóły:
      """
      {
        "Id": "123e4567-e89b-12d3-a456-426614174000",
        "Name": "Maximus",
        "Breed": "Golden Retriever",
        "Age": 6,
        "Gender": "Male",
        "Price": 350,
        "SpecieId": "456e7890-e89b-12d3-a456-426614174111"
      }
      """
