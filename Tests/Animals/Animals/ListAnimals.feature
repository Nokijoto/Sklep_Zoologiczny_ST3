Feature: List Animals

  Scenario: Successfully retrieve list of animals
    Given the species ID is "1"
    When I send a GET request to "/api/species/1/animals"
    Then the response status should be 200
    And the response body should contain a list of animals
