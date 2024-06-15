Feature: Get Supplier by ID

  Scenario: Successfully retrieve a supplier by ID
    Given the supplier ID is "1"
    When I send a GET request to "/api/suppliers/1"
    Then the response status should be 200
    And the response body should contain the details of the supplier
