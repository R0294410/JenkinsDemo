Feature: I want to be able to execute basic additions inside the Calculator page

  Scenario Outline: I want to execute simple additions on the calculator page
    Given I navigate to the "<page>" page
    When I click on the following buttons
      | number1 | calculationSymbol | number2 |
      | <num1>  | <calcSymbol>      | <num2>  |
    Then The displayed calculation is "<displayedCalculation>"
    When I want to calculate the result
    Then The result is "<calculationResult>"

    Examples:
      | page       | num1 |  calcSymbol | num2 | displayedCalculation | calculationResult |
      | Calculator | 5    | +           | 5    | 5+5                  | 10                |
      | Calculator | 0    | +           | 27   | 0+27                 | 27                |
      | Calculator | 115  | +           | 37   | 115+37               | 152               |
      | Calculator | 2579 | +           | 6984 | 2579+6984            | 9563              |
      | Calculator | 565  | +           | 6987 | 565+6987             | 7552              |

  Scenario Outline: I want to execute simple additions using decimals on the calculator page
    Given I navigate to the "<page>" page
    When I click on the following buttons
      | number1 | calculationSymbol | number2 |
      | <num1>  | <calcSymbol>      | <num2>  |
    Then The displayed calculation is "<displayedCalculation>"
    When I want to calculate the result
    Then The result is "<calculationResult>"

    Examples:
      | page       | num1     |  calcSymbol | num2   | displayedCalculation | calculationResult |
      | Calculator | 5.5      | +           | 3.5    | 5.5+3.5              | 9                 |
      | Calculator | 45.5     | +           | 69.7   | 45.5+69.7            | 115.2             |
      | Calculator | 186.6    | +           | 9.45   | 186.6+9.45           | 196.05            |
      | Calculator | 1.5698   | +           | 0.2895 | 1.5698+0.2895        | 1.86              |
      | Calculator | 0.333333 | +           | 0.9    | 0.333333+0.9         | 1.23              |