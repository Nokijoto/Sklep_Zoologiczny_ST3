Feature: Delete Species

  Scenario: Successfully delete a species
    Given the species ID is "1"
    When I send a DELETE request to "/api/species/1"
    Then the response status should be 204
