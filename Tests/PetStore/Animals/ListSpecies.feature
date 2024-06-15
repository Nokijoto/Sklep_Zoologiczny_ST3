Feature: List Species

  Scenario: Successfully retrieve list of species
    When I send a GET request to "/api/Species"
    Then the response status should be 200
    And the response body should contain a list of species
