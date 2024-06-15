Feature: Delete Animal

  Scenario: Successfully delete an animal
    Given the species ID is "1"
    And the animal ID is "2"
    When I send a DELETE request to "/api/species/1/animals/2"
    Then the response status should be 204
