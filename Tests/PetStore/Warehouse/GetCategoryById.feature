Feature: Get Category by ID

  Scenario: Successfully retrieve a category by ID
    Given the category ID is "1"
    When I send a GET request to "/api/categories/1"
    Then the response status should be 200
    And the response body should contain the details of the category

