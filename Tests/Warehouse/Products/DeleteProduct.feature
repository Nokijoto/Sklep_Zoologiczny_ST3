Feature: Delete Product

  Scenario: Successfully delete a product
    Given the product ID is "1"
    When I send a DELETE request to "/api/products/1"
    Then the response status should be 204
