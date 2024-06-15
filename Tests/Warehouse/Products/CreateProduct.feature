Feature: Create Product

  Scenario: Successfully create a product
    Given the product details are:
      | name        | description     | quantity | price | categoryId |
      | Smartphone  | Latest model    | 100      | 999   | 1          |
    When I send a POST request to "/api/products"
    Then the response status should be 201
    And the response body should contain the product ID
