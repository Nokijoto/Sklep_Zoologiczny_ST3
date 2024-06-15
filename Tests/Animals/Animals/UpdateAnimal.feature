Feature: Update Animal

  Scenario: Successfully update an animal
    Given the species ID is "1"
    And the animal ID is "2"
    And the updated animal details are:
      | name  | breed | age | gender | price |
      | Fido  | Dog   | 4   | Male   | 550   |
    When I send a PUT request to "/api/species/1/animals/2"
    Then the response status should be 200
    And the response body should contain the updated details of the animal
