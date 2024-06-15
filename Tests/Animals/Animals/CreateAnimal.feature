Feature: Create Animal

  Scenario: Successfully create an animal
    Given the species ID is "1"
    And the animal details are:
      | name  | breed | age | gender | price |
      | Fido  | Dog   | 3   | Male   | 500   |
    When I send a POST request to "/api/species/1/animals"
    Then the response status should be 201
    And the response body should contain the animal ID
