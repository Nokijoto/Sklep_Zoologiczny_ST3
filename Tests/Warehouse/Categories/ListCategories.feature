Feature: List Categories

  Scenario: Successfully retrieve list of categories
    When I send a GET request to "/api/categories"
    Then the response status should be 200
    And the response body should contain a list of categories
