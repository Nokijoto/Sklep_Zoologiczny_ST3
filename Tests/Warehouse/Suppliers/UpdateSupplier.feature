Feature: Update Supplier

  Scenario: Successfully update a supplier
    Given the supplier ID is "1"
    And the updated supplier details are:
      | name     | contactName | address          | city    | country |
      | Supplier | John Doe    | 456 Another St   | Newtown | USA     |
    When I send a PUT request to "/api/suppliers/1"
    Then the response status should be 200
    And the response body should contain the updated details of the supplier
