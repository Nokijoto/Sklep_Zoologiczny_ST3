Feature: List Suppliers

  Scenario: Successfully retrieve list of suppliers
    When I send a GET request to "/api/suppliers"
    Then the response status should be 200
    And the response body should contain a list of suppliers
