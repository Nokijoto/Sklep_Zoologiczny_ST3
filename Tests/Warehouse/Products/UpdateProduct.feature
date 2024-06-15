Feature: Update Product

  Scenario: Successfully update a product
    Given the product ID is "1"
    And the updated product details are:
      | name        | description     | quantity | price | categoryId |
      | Smartphone  | Updated model   | 150      | 899   | 1          |
    When I send a PUT request to "/api/products/1"
    Then the response status should be 200
    And the response body should contain the updated details of the product
