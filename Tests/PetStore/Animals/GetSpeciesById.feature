Feature: Get Species by ID

  Scenario: Successfully retrieve a species by ID
    Given the species ID is "1"
    When I send a GET request to "/api/Species/1"
    Then the response status should be 200
    And the response body should contain the details of the species
