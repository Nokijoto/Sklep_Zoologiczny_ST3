Feature: Update Category

  Scenario: Successfully update a category
    Given the category ID is "1"
    And the updated category details are:
      | name        | description        | parentCategoryId |
      | Electronics | Updated description | 1               |
    When I send a PUT request to "/api/categories/1"
    Then the response status should be 200
    And the response body should contain the updated details of the category
