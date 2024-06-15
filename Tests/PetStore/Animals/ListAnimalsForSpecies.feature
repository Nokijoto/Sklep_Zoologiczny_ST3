Feature: List Animals for Species

  Scenario: Successfully retrieve list of animals for a species
    Given the species ID is "1"
    When I send a GET request to "/api/Species/1/animals"
    Then the response status should be 200
    And the response body should contain a list of animals for the species
