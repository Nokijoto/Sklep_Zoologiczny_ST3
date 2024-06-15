Feature: List Products by Category

  Scenario: Successfully retrieve list of products by category
    Given the category ID is "1"
    When I send a GET request to "/api/products/bycategory/1"
    Then the response status should be 200
    And the response body should contain a list of products for the category
