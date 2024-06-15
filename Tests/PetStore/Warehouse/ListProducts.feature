Feature: List Products

  Scenario: Successfully retrieve list of products
    When I send a GET request to "/api/products"
    Then the response status should be 200
    And the response body should contain a list of products
