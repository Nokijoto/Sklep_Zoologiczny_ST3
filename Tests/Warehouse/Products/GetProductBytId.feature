Feature: Get Product by ID

  Scenario: Successfully retrieve a product by ID
    Given the product ID is "1"
    When I send a GET request to "/api/products/1"
    Then the response status should be 200
    And the response body should contain the details of the product
