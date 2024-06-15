Feature: Update Species

  Scenario: Successfully update a species
    Given the species ID is "1"
    And the updated species details are:
      | name  |
      | Canine |
    When I send a PUT request to "/api/species/1"
    Then the response status should be 200
    And the response body should contain the updated details of the species
