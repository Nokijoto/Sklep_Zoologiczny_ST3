Feature: Create Supplier

  Scenario: Successfully create a supplier
    Given the supplier details are:
      | name     | contactName | address          | city    | country |
      | Supplier | John Doe    | 123 Main St      | Anytown | USA     |
    When I send a POST request to "/api/suppliers"
    Then the response status should be 201
    And the response body should contain the supplier ID
