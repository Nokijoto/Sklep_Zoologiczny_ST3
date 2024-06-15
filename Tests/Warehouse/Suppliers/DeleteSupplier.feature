Feature: Delete Supplier

  Scenario: Successfully delete a supplier
    Given the supplier ID is "1"
    When I send a DELETE request to "/api/suppliers/1"
    Then the response status should be 204

