Feature: Get Animal by ID for Species

  Scenario: Successfully retrieve an animal by ID for a species
    Given the species ID is "1"
    And the animal ID is "2"
    When I send a GET request to "/api/Species/1/animals/2"
    Then the response status should be 200
    And the response body should contain the details of the animal for the species
