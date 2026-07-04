# FakestoreEcommerceTests

[![.NET UI tests](https://github.com/BartekKiljanski/FakestoreEcommerceTests/actions/workflows/dotnet-tests.yml/badge.svg)](https://github.com/BartekKiljanski/FakestoreEcommerceTests/actions/workflows/dotnet-tests.yml)

Projekt z testami automatycznymi UI dla strony:

https://fakestore.testelka.pl/

Repozytorium przygotowałem jako prosty przykład frameworka testowego w C#.
Testy są napisane w SpecFlow, korzystają z Selenium WebDriver i są ułożone w stylu Page Object Model.

## Technologie

- C# / .NET 6
- Selenium WebDriver
- SpecFlow
- NUnit
- FluentAssertions
- Allure
- Docker
- GitHub Actions

## Co jest testowane

Aktualnie testy obejmują podstawowe scenariusze konta klienta i koszyka:

- rejestracja nowego użytkownika,
- ponowne logowanie utworzonego użytkownika,
- próba logowania błędnymi danymi,
- walidacja rejestracji bez hasła,
- dodanie produktu do koszyka,
- zmiana ilości produktu w koszyku,
- usunięcie produktu z koszyka,
- przejście z koszyka do zamówienia.

Scenariusze znajdują się w katalogu `Features`:

```text
Features/Account.feature
Features/Cart.feature
```

## Struktura projektu

Najważniejsze katalogi:

```text
Features/          scenariusze BDD w Gherkinie
StepDefinitions/   implementacja kroków SpecFlow
PageObject/        klasy Page Object dla stron i widoków
Helpers/           hooki, konfiguracja i pomocnicze klasy
Models/            proste modele danych testowych
TestData/          dane testowe w plikach JSON
TestSupport/       konfiguracja WebDrivera i metody pomocnicze Selenium
```

## Uruchomienie testów

Do lokalnego uruchomienia bez Dockera potrzebne są:

- .NET 6 SDK,
- Google Chrome.

Instalacja zależności:

```bash
dotnet restore FakestoreEcommerceTests.sln
```

Uruchomienie testów:

```bash
dotnet test FakestoreEcommerceTests.sln
```

Uruchomienie w trybie headless:

```bash
HEADLESS=true dotnet test FakestoreEcommerceTests.sln
```

## Docker

Jeśli nie chcesz instalować .NET SDK i Chrome lokalnie, testy można odpalić w Dockerze:

```bash
docker compose build tests
docker compose run --rm tests
```

W kontenerze testy uruchamiają się w trybie headless.

## Konfiguracja

Adres testowanej strony i przeglądarka są ustawione w `appsettings.json`:

```json
{
  "AppSettings": {
    "WebSitePage": "https://fakestore.testelka.pl/",
    "Driver": "Chrome"
  }
}
```

Dane przykładowych użytkowników są w:

```text
TestData/users.json
```

## Allure

Po uruchomieniu testów wyniki Allure zapisują się w:

```text
allure-results/
```

Raport można podejrzeć lokalnie:

```bash
allure serve allure-results
```

Jeżeli test się wywali, screenshot jest zapisywany w katalogu `Screenshots/` i dodawany do raportu Allure.

## CI

W repo jest dodany prosty workflow GitHub Actions:

```text
.github/workflows/dotnet-tests.yml
```

Pipeline robi restore, build, odpala testy w trybie headless i zapisuje wyniki jako artifact.
