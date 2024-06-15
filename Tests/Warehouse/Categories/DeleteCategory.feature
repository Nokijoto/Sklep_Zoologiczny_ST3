Feature: Delete Category

  Scenario: Successfully delete a category
    Given the category ID is "1"
    When I send a DELETE request to "/api/categories/1"
    Then the response status should be 204
