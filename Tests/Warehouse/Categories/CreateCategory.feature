Feature: Create Category

  Scenario: Successfully create a category
    Given the category details are:
      | name        | description        | parentCategoryId |
      | Electronics | Electronic devices | 1                |
    When I send a POST request to "/api/categories"
    Then the response status should be 201
    And the response body should contain the category ID
