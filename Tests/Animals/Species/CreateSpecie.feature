Feature: Create Species

  Scenario: Successfully create a species
    Given the species details are:
      | name  |
      | Canine |
    When I send a POST request to "/api/species"
    Then the response status should be 201
    And the response body should contain the species ID
