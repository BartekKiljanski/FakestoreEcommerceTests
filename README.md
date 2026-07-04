# FakestoreEcommerceTests

[![.NET UI tests](https://github.com/BartekKiljanski/FakestoreEcommerceTests/actions/workflows/dotnet-tests.yml/badge.svg)](https://github.com/BartekKiljanski/FakestoreEcommerceTests/actions/workflows/dotnet-tests.yml)

Automated UI test framework for [fakestore.testelka.pl](https://fakestore.testelka.pl/) built with Selenium WebDriver, SpecFlow, NUnit and Allure.
The project shows a BDD-style test automation setup with Page Object Model, reusable helpers and browser configuration for local and CI runs.

## Tech stack

- C# / .NET 6
- Selenium WebDriver
- SpecFlow
- NUnit
- FluentAssertions
- Allure Reports
- GitHub Actions

## Project structure

```text
Features/          BDD scenarios written in Gherkin
StepDefinitions/   SpecFlow step definitions
PageObject/        Page Object classes for tested pages
Helpers/           Hooks, configuration and shared helper classes
Models/            Simple test data models
TestData/          JSON files with reusable test users
TestSupport/       WebDriver factory and Selenium utilities
```

## Test scenarios

The test suite currently covers basic account and cart flows:

- customer login with valid and invalid data,
- new customer registration,
- registration validation,
- adding product to cart,
- changing product quantity,
- removing product from cart,
- moving from cart to checkout.

Feature files are stored in `Features/`:

```text
Features/Account.feature
Features/Cart.feature
```

| Area | Scenario | Tag |
| --- | --- | --- |
| Account | Login with valid user | `@smoke` |
| Account | Login with invalid user | `@regression` |
| Account | Register random user | `@smoke` |
| Account | Register without password | `@regression` |
| Cart | Add product to cart | `@smoke` |
| Cart | Change product quantity | `@regression` |
| Cart | Remove product from cart | `@regression` |
| Cart | Go to checkout | `@regression` |

## How to run tests

Requirements:

- .NET 6 SDK
- Google Chrome
- Allure CLI, optional, only for local report preview

Restore dependencies:

```bash
dotnet restore FakestoreEcommerceTests.sln
```

Run tests locally:

```bash
dotnet test FakestoreEcommerceTests.sln
```

Run tests in headless mode:

```bash
HEADLESS=true dotnet test FakestoreEcommerceTests.sln
```

Run tests in Docker:

```bash
docker compose run --rm tests
```

The tested website and browser can be changed in `appsettings.json`:

```json
{
  "AppSettings": {
    "WebSitePage": "https://fakestore.testelka.pl/",
    "Driver": "Chrome"
  }
}
```

Reusable users are stored in:

```text
TestData/users.json
```

## Allure report

Test execution creates Allure results in:

```text
allure-results/
```

Generate and open a local report:

```bash
allure serve allure-results
```

Failed steps and failed scenarios attach screenshots to Allure and also save them in:

```text
Screenshots/
```

## CI

GitHub Actions workflow is available in:

```text
.github/workflows/dotnet-tests.yml
```

The pipeline restores dependencies, builds the solution, runs tests in headless mode and uploads test artifacts.
