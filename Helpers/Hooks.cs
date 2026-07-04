using Allure.Net.Commons;
using BoDi;
using FakestoreEcommerceTests.TestSupport;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace FakestoreEcommerceTests.Helpers
{

    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver? _driver;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            try
            {
                _driver = DriverFactory.GetDriver();
                _container.RegisterInstanceAs<IWebDriver>(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd inicjalizacji WebDrivera: {ex.Message}");
                throw;
            }
        }

        [AfterStep]
        public void TakeScreenshotAfterStep()
        {
            if (_scenarioContext.TestError != null && _driver != null)
            {
                try
                {
                    var stepInfo = _scenarioContext.StepContext.StepInfo;
                    var stepTitle = $"{stepInfo.StepDefinitionType} {stepInfo.Text}";
                    var title = _scenarioContext.ScenarioInfo.Title;
                    var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    var screenshotFilePath = Path.Combine("Screenshots", $"{title}-{stepTitle}_{timestamp}.png");

                    TakeScreenshot(_driver, screenshotFilePath);
                    AllureApi.AddAttachment(stepTitle, "image/png", screenshotFilePath);

                    Console.WriteLine($"Zrzut ekranu dla '{stepTitle}' zapisany do: {screenshotFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas robienia zrzutu ekranu po kroku: {ex.Message}");
                }
            }
        }

        public void TakeScreenshot(IWebDriver driver, string filePath)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var artifactDirectory = Path.GetDirectoryName(filePath);

                if (!string.IsNullOrEmpty(artifactDirectory) && !Directory.Exists(artifactDirectory))
                {
                    Directory.CreateDirectory(artifactDirectory);
                }

                // Skraca nazwę pliku, jeśli jest zbyt długa
                var maxLength = 250; // Długość mniejsza niż maksymalna, aby uwzględnić ścieżkę katalogu
                if (filePath.Length > maxLength)
                {
                    var extension = Path.GetExtension(filePath);
                    filePath = filePath.Substring(0, maxLength - extension.Length) + extension;
                }

                screenshot.SaveAsFile(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas robienia zrzutu ekranu: {ex.Message}");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null && _driver != null)
            {
                try
                {
                    var title = _scenarioContext.ScenarioInfo.Title;
                    var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    var screenshotFilePath = Path.Combine("Screenshots", $"{title}_{timestamp}.png");
                    TakeScreenshot(_driver, screenshotFilePath);
                    AllureApi.AddAttachment(title, "image/png", screenshotFilePath);
                    Console.WriteLine($"Zapisz screenshot do: {screenshotFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas zapisywania zrzutu ekranu po scenariuszu: {ex.Message}");
                }
            }

            try
            {
                _driver?.Quit();
                _driver?.Dispose();
                _driver = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zamykania i usuwania WebDrivera: {ex.Message}");
            }
        }
    }
}
