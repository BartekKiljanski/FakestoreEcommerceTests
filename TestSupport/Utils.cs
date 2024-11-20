using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Globalization;


namespace FakestoreEcommerceTests.TestSupport
{
  


    public class Utils
    {
        public static readonly TimeSpan TimeSpan15 = TimeSpan.FromSeconds(15);
        public static readonly TimeSpan TimeSpan5 = TimeSpan.FromSeconds(5);

        /// <summary>
                    /// Uruchamia przeglądarkę zgodną z ustawionym w appsetingsach web driverem.
                    /// Przechodzi na url podany w parametrach.
                    /// </summary>
                    /// <param name="url">Adres strony na którą nastąpi inicjalne przekierowanie</param>
        public static void GoToUrl(IWebDriver driver, string url)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = url;

        }

        /// <summary>
                    /// Klika w przycisk o danym lokatorze.
                    /// Podejmując próbę co 0.25 sekundy do maksymalnej wartości podanej w drugim parametrze.
                    /// </summary>
                    /// <param name="xpath">Lokator przycisku</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na przycisk</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <exception cref="Exception"></exception>
        public static void ClickButton(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                // Oczekujemy, że element będzie kliknialny i klikamy
                var element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                element.Click();
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
        }

        /// <summary>
                    /// Klika w link wyszukując go po prezentowanym tekście, np. &lt;a href="..."&gt;tekst_do_wyszukania&lt;/a&gt;.
                    /// </summary>
                    /// <param name="linkText"></param>
                    /// <param name="timeSpan"></param>
                    /// <param name="message"></param>
        public static void ClickButtonByLinkText(IWebDriver driver, string linkText, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                // Oczekiwanie na element, który jest kliknialny
                var element = wait.Until(d => d.FindElement(By.LinkText(linkText)));
                element.Click();
            }
            catch
            {
                throw new Exception($"Not found element for link text: {linkText}. {message}");
            }
        }

        /// <summary>
                    /// Klika w link wyszukując go po części prezentowanego tekście
                    /// </summary>
                    /// <param name="partiallinkText"></param>
                    /// <param name="timeSpan"></param>
                    /// <param name="message"></param>
                    /// <exception cref="Exception"></exception>
        public static void ClickButtonByPartialLinkText(IWebDriver driver, string partiallinkText, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                // Oczekiwanie na element, który jest kliknialny
                var element = wait.Until(d => d.FindElement(By.PartialLinkText(partiallinkText)));
                element.Click();
            }
            catch
            {
                throw new Exception($"Not found element for link text: {partiallinkText}. {message}");
            }
        }


        /// <summary>
                    /// Wpisuje daną frazę w element o podanym lokatorze. Oczekując maksymalnie na element, określony czas w drugim parametrze.
                    /// </summary>
                    /// <param name="xpath">Lokator elementu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na element</param>
                    /// <param name="keys">Fraza, która ma zostać wpisana</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <exception cref="Exception"></exception>
        public static void SendKeysByXPath(IWebDriver driver, string xpath, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                // Oczekiwanie na element kliknialny
                var element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                element.SendKeys(keys);
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
        }

        /// <summary>
                    /// Ustawia wartość w elemencie o podanym lokatorze przy użyciu JavaScript, oczekując maksymalnie na element, określony czas w drugim parametrze.
                    /// </summary>
                    /// <param name="xpath">Lokator elementu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na element</param>
                    /// <param name="value">Wartość, która ma zostać wpisana</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <exception cref="Exception"></exception>
        public static void SetValueByXPath(IWebDriver driver, string xpath, TimeSpan timeSpan, string value, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                // Oczekiwanie na widoczny element
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].value = arguments[1];", element, value);
            }
            catch
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message}");
            }
        }


        /// <summary>
                    /// Wpisuje daną frazę w element o podanym lokatorze (id). Oczekując maksymalnie na element, określony czas w drugim parametrze
                    /// </summary>
                    /// <param name="id"></param>
                    /// <param name="timeSpan"></param>
                    /// <param name="keys"></param>
                    /// <param name="message"></param>
                    /// <exception cref="Exception"></exception>
        public static void SendKeysById(IWebDriver driver, string id, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    var element = wait.Until(d => d.FindElement(By.Id(id)));
                    element.SendKeys(keys);
                    return; // Jeśli się udało, zakończ
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with ID: '{id}' was not found. {message}");
                    attempts++;
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"Timed out after {timeSpan.TotalSeconds} seconds waiting for element with ID: '{id}'. {message}");
                    attempts++;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error occurred while trying to find element with ID: '{id}'. {ex.Message}");
                }
            }

            throw new Exception($"Failed to find or interact with element with ID: '{id}' after 3 attempts. {message}");
        }


        /// <summary>
                    /// Wpisuje daną frazę w element o podanym lokatorze (id). Oczekując maksymalnie na element, określony czas w drugim parametrze jak element nie zostaje znaleziony przechodzi do następnego
                    /// </summary>
                    /// <param name="id"></param>
                    /// <param name="timeSpan"></param>
                    /// <param name="keys"></param>
                    /// <param name="message"></param>
                    /// <exception cref="Exception"></exception>
        public static void SendKeysByIdNext(IWebDriver driver, string id, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                var element = wait.Until(d => d.FindElement(By.Id(id)));
                if (element.Enabled && element.Displayed)
                {
                    element.SendKeys(keys);
                }
                else
                {
                    Console.WriteLine($"Element with id: {id} is not interactable.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element with id: {id} not found. {message}");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element with id: {id} not found within the given time. {message}");
            }
        }



        /// <summary>
                    /// Sprawdza czy na aktualnej stronie znajduje się element o danym lokatorze.
                    /// </summary>
                    /// <param name="xpath">Lokator obiektu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <exception cref="Exception"></exception>
        public static bool FindVisibleElement(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Element with xpath: '{xpath}' was not visible after {timeSpan.TotalSeconds} seconds. {message}");
                return false;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine($"Element with xpath: '{xpath}' was not found. {message}");
                return false;
            }
        }



        /// <summary>
                    /// Sprawdza czy na aktualnej stronie znajduje się element o danym lokatorze. Jeżeli się nie znajduje funkcja przechodzi dalej
                    /// </summary>
                    /// <param name="xpath">Lokator obiektu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <exception cref="Exception"></exception>

        public static bool IsElementPresent(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine($"Not found element for xpath: {xpath}. {message}");
                }
                return false;
            }
            catch (NoSuchElementException)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine($"Element with xpath: '{xpath}' was not found. {message}");
                }
                return false;
            }
        }

        /// <summary>
                    /// Sprawdza czy na aktualnej stronie znajduje się element o danym lokatorze. Jeżeli się nie znajduje funkcja przechodzi dalej
                    /// </summary>
                    /// <param name="driver">Obiekt drivera</param>
                    /// <param name="xpath">Lokator obiektu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
                    /// <param name="message">Opcjonalnie: Treść błędu przy niepowodzeniu</param>
                    /// <returns>Zwraca true jeżeli element jest widoczny i klikalny, w przeciwnym przypadku false</returns>
                    /// <exception cref="Exception"></exception>
        public static bool IsElementClickable(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));

                // Sprawdzenie, czy element jest wyświetlany i włączony
                if (element.Displayed && element.Enabled)
                {
                    return true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine($"Element not clickable for xpath: {xpath}. {message}");
                    }
                    return false;
                }
            }
            catch (WebDriverTimeoutException)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine($"Element not clickable for xpath: {xpath}. {message}");
                }
                return false;
            }
        }


        /// <summary>
                    /// Zwraca tekst elementu zapisany jako wartość atrybutu, np. &lt;element name="tekst" /&gt;
                    /// </summary>
                    /// <param name="xpath">Lokator obiektu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <returns></returns>
        public static string GetAttributeValueFromElement(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                return element.GetAttribute("value"); // Zwraca wartość atrybutu "value" (lub inny atrybut, jeśli potrzebne)
            }
            catch (Exception ex)
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message} Error: {ex.Message}");
            }
        }


        /// <summary>
                    /// Zwraca tekst elementu zapisany pomiędzy znacznikami początku i końca, np. &lt;element&gt;tekst&lt;/element&gt;
                    /// </summary>
                    /// <param name="xpath">Lokator obiektu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <returns></returns>
        public static string GetTextFromVisibleElement(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                return element.Text;
            }
            catch (Exception ex)
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message} Error: {ex.Message}");
            }
        }


        /// <summary>
                    /// Czyści wartość elementu (np. textbox'a) o podanym lokatorze.
                    /// </summary>
                    /// <param name="xpath">Lokator obiektu</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na obiekt</param>
                    /// <param name="message">Opcjonalnie:Treść błędu przy niepowodzeniu</param>
                    /// <returns></returns>
                    /// <exception cref="Exception"></exception>
        public static void Clear(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));
                element.Clear(); // Czyści wartość pola tekstowego
            }
            catch (Exception ex)
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message} Error: {ex.Message}");
            }
        }


        /// <summary>
                    /// Zamyka okno przeglądarki.
                    /// </summary>
        public static void CloseWindow(IWebDriver driver)
        {
            try
            {
                driver.Quit(); // Zamyka przeglądarkę
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing browser: {ex.Message}");
            }
        }


        /// <summary>
                    /// Zwraca listę wartości elementów o nazwie tagName, dzieci elementu ze ścieżki xpath.
                    /// Uwaga! Zwrócone zostają tylko wartości elementów widocznych na formatce (ograniczenie techniczne selenium).
                    /// </summary>
                    /// <param name="xpath">ścieżka do elementu przeszukiwanego</param>
                    /// <param name="tagName">nazwa elementu szukanego</param>
                    /// <param name="timeSpan"></param>
                    /// <param name="message"></param>
                    /// <returns></returns>
        public static List<string> GetListOfValues(IWebDriver driver, string xpath, string tagName, TimeSpan timeSpan, string message = null)
        {
            List<string> result = new List<string>();
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);

            try
            {
                // Czekaj, aż element będzie widoczny
                IWebElement element = wait.Until(d => d.FindElement(By.XPath(xpath)));

                if (element != null)
                {
                    // Znajdź wszystkie elementy o danym tagu wewnątrz elementu
                    IReadOnlyList<IWebElement> list = element.FindElements(By.TagName(tagName));

                    foreach (IWebElement e in list)
                    {
                        result.Add(e.Text); // Dodaj tekst każdego elementu do listy
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Not found element for xpath: {xpath}. {message} Error: {ex.Message}");
            }

            return result;
        }


        /// <summary>
                    /// Czeka, az okno modalne zostanie zamkniete.
                    /// </summary>
                    /// <param name="xpath"></param>
                    /// <param name="timeSpan"></param>
                    /// <param name="message"></param>
                    /// <returns></returns>
        public static bool IsModalPopupClosed(IWebDriver driver, string xpath, TimeSpan timeSpan, string message = null)
        {
            bool result = false;
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);

            try
            {
                // Czekaj, aż element stanie się niewidoczny
                result = wait.Until(d => !d.FindElement(By.XPath(xpath)).Displayed);
            }
            catch (Exception ex)
            {
                // Zgłoszenie błędu, jeśli element nie jest niewidoczny
                throw new Exception($"Not found element for xpath: {xpath}. {message} Error: {ex.Message}");
            }

            return result;
        }


        /// <summary>
                    /// Odświeża bieżącą stronę.
                    /// </summary>
        public static void ReloadSite(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            Wait(5);
        }

        /// <summary>
                    /// Robi pauzę na określoną ilość sekund.
                    /// </summary>
                    /// <param name="seconds"></param>
        public static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        /// <summary>
                    /// Zamienia tablicę na słownik.
                    /// </summary>
                    /// <param name="table"></param>
                    /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        /// <summary>
                    /// Metoda czyszcząca po testach.
                    /// Zamyka przeglądarkę i ubija proces drivera.
                    /// </summary>
        public static void CleanUp(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

        /// <summary>
                    /// Przewija stronę do elementu określonego przez selektor i wykonuje na nim kliknięcie.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki, używana do interakcji z przeglądarką.</param>
                    /// <param name="by">Selektor używany do lokalizacji elementu na stronie.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na to, aby element stał się widoczny i klikalny.</param>
                    /// <param name="retries">Liczba maksymalnych prób, które zostaną podjęte, jeśli element nie będzie klikalny po pierwszej próbie. Domyślnie 3.</param>
        public static void ScrollToElementAndClick(IWebDriver driver, By by, TimeSpan timeSpan, int retries = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;
            while (attempts < retries)
            {
                try
                {
                    var element = wait.Until(driver =>
                        driver.FindElement(by).Displayed && driver.FindElement(by).Enabled ? driver.FindElement(by) : null);

                    if (element != null)
                    {
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(element);
                        actions.Perform();

                        // Sprawdzamy, czy element jest klikalny przed kliknięciem
                        wait.Until(drv => element.Enabled && element.Displayed);
                        element.Click();
                        return; // Zakończ, jeśli uda się kliknąć
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Element with locator: '{by}' was not clickable after {timeSpan.TotalSeconds} seconds.");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with locator: '{by}' was not found.");
                }
                attempts++;
            }

            throw new Exception($"Failed to click element after {retries} attempts.");
        }


        /// <summary>
                    /// Przewija stronę do elementu określonego przez selektor i wykonuje na nim kliknięcie.
                    /// W przypadku, gdy element nie jest widoczny lub klikalny, metoda podejmuje określoną liczbę prób.
                    /// Jeśli po maksymalnej liczbie prób nie uda się kliknąć elementu, metoda zwraca false,
                    /// zamiast rzucać wyjątek, co pozwala na kontynuację testu.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki, używana do interakcji z przeglądarką.</param>
                    /// <param name="by">Selektor używany do lokalizacji elementu na stronie.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na to, aby element stał się widoczny i klikalny.</param>
                    /// <param name="retries">Liczba maksymalnych prób, które zostaną podjęte, jeśli element nie będzie klikalny po pierwszej próbie. Domyślnie 3.</param>
                    /// <returns>Zwraca true, jeśli udało się kliknąć element, w przeciwnym razie zwraca false.</returns>

        public static bool TryScrollToElementAndClick(IWebDriver driver, By by, TimeSpan timeSpan, int retries = 2)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;
            while (attempts < retries)
            {
                try
                {
                    var element = wait.Until(driver =>
                        driver.FindElement(by).Displayed && driver.FindElement(by).Enabled ? driver.FindElement(by) : null);

                    if (element != null)
                    {
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(element);
                        actions.Perform();

                        // Sprawdzamy, czy element jest klikalny przed kliknięciem
                        wait.Until(drv => element.Enabled && element.Displayed);
                        element.Click();
                        return true; // Zakończ, jeśli uda się kliknąć
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Element with locator: '{by}' was not clickable after {timeSpan.TotalSeconds} seconds.");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with locator: '{by}' was not found.");
                }
                attempts++;
            }

            // Zwróć false, jeśli nie udało się kliknąć, ale nie rzucaj wyjątku
            return false;
        }


        public static void ForceClickElementWithMessage(IWebDriver driver, By by, TimeSpan timeSpan, string message = null, int retries = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;

            while (attempts < retries)
            {
                try
                {
                    var element = wait.Until(driver =>
                        driver.FindElement(by).Displayed && driver.FindElement(by).Enabled ? driver.FindElement(by) : null);

                    if (element != null)
                    {
                        // Przewiń do elementu, jeśli nie jest widoczny
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

                        // Czekaj, aż element będzie gotowy do kliknięcia
                        wait.Until(drv => element.Enabled && element.Displayed);

                        // Użyj JavaScript do kliknięcia na elemencie
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                        return; // Zakończ, jeśli się udało
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Element with locator: '{by}' was not clickable after {timeSpan.TotalSeconds} seconds. {message}");
                }
                catch (ElementClickInterceptedException)
                {
                    Console.WriteLine($"Element with locator: '{by}' was intercepted and not clickable. {message}");
                }
                catch (NoSuchElementException)
                {
                    throw new Exception($"Element with locator: '{by}' was not found. {message}");
                }
                catch (JavaScriptException jsEx)
                {
                    Console.WriteLine($"JavaScript error occurred: {jsEx.Message}");
                }

                attempts++;
            }

            throw new Exception($"Failed to click element with locator: '{by}' after {retries} attempts. {message}");
        }





        /// <summary>
                    /// Czyści pole tekstowe określone przez identyfikator i wprowadza nowy tekst.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki, używana do interakcji z przeglądarką.</param>
                    /// <param name="id">Identyfikator elementu HTML, do którego tekst ma być wprowadzony.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na to, aby element stał się klikalny i można było na nim wykonać operacje.</param>
                    /// <param name="keys">Tekst do wprowadzenia w czyszczonym polu tekstowym.</param>
                    /// <param name="message">Opcjonalny komunikat dołączany do wyjątku, gdy operacja nie powiedzie się.</param>

        public static void ClearAndSendKeysById(IWebDriver driver, string id, TimeSpan timeSpan, string keys, string message = null, int retries = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;
            while (attempts < retries)
            {
                try
                {
                    var element = wait.Until(driver =>
                        driver.FindElement(By.Id(id)).Displayed && driver.FindElement(By.Id(id)).Enabled ? driver.FindElement(By.Id(id)) : null);

                    if (element != null)
                    {
                        element.Clear();
                        element.SendKeys(keys);
                        return;
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Element with ID: '{id}' was not clickable after {timeSpan.TotalSeconds} seconds. {message}");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with ID: '{id}' was not found. {message}");
                }
                attempts++;
            }
            throw new Exception($"Failed to interact with element after {retries} attempts.");
        }



        /// <summary>
                    /// Czyści pole tekstowe określone przez XPath i wprowadza nowy tekst.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki, używana do interakcji z przeglądarką.</param>
                    /// <param name="xpath">XPath elementu HTML, do którego tekst ma być wprowadzony.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na to, aby element stał się klikalny i można było na nim wykonać operacje.</param>
                    /// <param name="keys">Tekst do wprowadzenia w czyszczonym polu tekstowym.</param>
                    /// <param name="message">Opcjonalny komunikat dołączany do wyjątku, gdy operacja nie powiedzie się.</param>
        public static void ClearAndSendKeysByXPath(IWebDriver driver, string xpath, TimeSpan timeSpan, string keys, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                // Czekaj na element, który jest kliknialny
                IWebElement elementToInteract = wait.Until(driver =>
                {
                    var element = driver.FindElement(By.XPath(xpath));
                    return (element != null && element.Displayed && element.Enabled) ? element : null;
                });

                if (elementToInteract == null)
                {
                    throw new Exception($"Element with XPath: '{xpath}' was not found or is not interactable. {message}");
                }

                elementToInteract.Clear();
                elementToInteract.SendKeys(keys);
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element with XPath: '{xpath}' was not clickable after {timeSpan.TotalSeconds} seconds. {message}");
            }
            catch (NoSuchElementException)
            {
                throw new Exception($"Element with XPath: '{xpath}' was not found. {message}");
            }
        }



        /// <summary>
                    /// Wymusza kliknięcie na elemencie określonym przez selektor, używając JavaScript, jeśli standardowe metody kliknięcia zawiodą.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki.</param>
                    /// <param name="by">Selektor używany do lokalizacji elementu na stronie.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na to, aby element stał się klikalny.</param>
                    /// <param name="retries">Liczba prób, które zostaną podjęte, jeśli element nie będzie klikalny po pierwszej próbie. Domyślnie 3.</param>
                    /// <exception cref="Exception">Zgłaszany, jeśli po określonej liczbie prób element nadal nie jest klikalny.</exception>
        public static void ForceClickElement(IWebDriver driver, By by, TimeSpan timeSpan, int retries = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;

            while (attempts < retries)
            {
                try
                {
                    var element = wait.Until(driver =>
                    {
                        var foundElement = driver.FindElement(by);
                        return (foundElement != null && foundElement.Displayed && foundElement.Enabled) ? foundElement : null;
                    });

                    if (element == null)
                    {
                        throw new Exception($"Element with locator: '{by}' is not interactable.");
                    }

                    // Przewiń do elementu, jeśli nie jest widoczny
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

                    // Użyj JavaScript do kliknięcia na elemencie
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
                    return; // Zakończ, jeśli kliknięcie powiodło się
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Attempt {attempts + 1}: Element with locator: '{by}' was not clickable after {timeSpan.TotalSeconds} seconds.");
                }
                catch (ElementClickInterceptedException)
                {
                    Console.WriteLine($"Attempt {attempts + 1}: Element with locator: '{by}' was intercepted.");
                }
                catch (NoSuchElementException)
                {
                    throw new Exception($"Element with locator: '{by}' was not found.");
                }

                // Sleep briefly before retrying
                Thread.Sleep(500);
                attempts++;
            }

            throw new Exception($"Failed to click element with locator: '{by}' after {retries} attempts.");
        }


        /// <summary>
                    /// Przewija do elementu określonego przez selektor i wykonuje na nim akcję kliknięcia. W przypadku niepowodzenia,
                    /// próbuje przewinąć do elementu i kliknąć ponownie. Jeśli element nadal nie jest dostępny, zgłasza wyjątek.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki.</param>
                    /// <param name="by">Selektor używany do lokalizacji elementu na stronie.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na pojawienie się elementu.</param>

        public static void ScrollToElementAndClickWithFallback(IWebDriver driver, By by, TimeSpan timeSpan)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                var element = wait.Until(driver =>
                {
                    var foundElement = driver.FindElement(by);
                    return (foundElement != null && foundElement.Displayed) ? foundElement : null;
                });

                if (element == null)
                {
                    throw new Exception($"Element with locator: '{by}' was not found or is not visible.");
                }

                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Click().Perform();
            }
            catch (WebDriverTimeoutException)
            {
                // Jeśli element nie jest interaktywny, spróbuj przewinąć i kliknąć ponownie
                IWebElement element = ScrollToElement(driver, by, timeSpan);
                var clickableElement = wait.Until(driver =>
                {
                    var foundElement = driver.FindElement(by);
                    return (foundElement != null && foundElement.Enabled) ? foundElement : null;
                });
                clickableElement.Click();
            }
            catch (NoSuchElementException)
            {
                throw new Exception($"Element with locator: '{by}' was not found.");
            }
            catch (ElementNotInteractableException)
            {
                throw new Exception($"Element with locator: '{by}' is not interactable.");
            }
        }

        /// <summary>
                    /// Przewija stronę do określonego elementu, zapewniając jego widoczność w obszarze przeglądarki.
                    /// </summary>
                    /// <param name="driver">Instancja przeglądarki, w której ma zostać wykonana akcja.</param>
                    /// <param name="by">Selektor używany do znalezienia elementu na stronie.</param>
                    /// <param name="timeSpan">Czas oczekiwania na dostępność elementu przed wykonaniem
        private static IWebElement ScrollToElement(IWebDriver driver, By by, TimeSpan timeSpan)
        {
            IWebElement element = driver.FindElement(by);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Utils.Wait(1); // Dodatkowe opóźnienie, aby upewnić się, że element jest widoczny
            return element;
        }

        /// <summary>
                    /// Generuje losowy ciąg tekstowy o danej długości, składający się wyłącznie z liter alfabetu .
                    /// </summary>
        public static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
                    /// Generuje datę, która jest większa o określoną liczbę dni niż dzisiaj.
                    /// </summary>
        public static DateTime GetFutureDate(int daysToAdd)
        {

            DateTime today = DateTime.Today;

            DateTime futureDate = today.AddDays(daysToAdd);

            return futureDate;
        }

        /// <summary>
                    /// Przewija stronę do elementu określonego przez selektor i wykonuje na nim kliknięcie.
                    /// </summary>
                    /// <param name="driver">Instancja sterownika przeglądarki, używana do interakcji z przeglądarką.</param>
                    /// <param name="by">Selektor używany do lokalizacji elementu na stronie.</param>
                    /// <param name="timeSpan">Maksymalny czas oczekiwania na to, aby element stał się widoczny i klikalny.</param>
                    /// <param name="message">Opcjonalnie: Treść błędu przy niepowodzeniu.</param>
        public static void ScrollToElementAndClickMessage(IWebDriver driver, By by, TimeSpan timeSpan, string message = null)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            try
            {
                var element = wait.Until(driver =>
                {
                    var foundElement = driver.FindElement(by);
                    return (foundElement != null && foundElement.Displayed) ? foundElement : null;
                });

                if (element == null)
                {
                    Console.WriteLine($"Element with locator: '{by}' was not found or is not visible. {message}");
                    return;
                }

                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Perform();
                element.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Logowanie zamiast rzucania wyjątku
                Console.WriteLine($"Element with locator: '{by}' was not clickable after {timeSpan.TotalSeconds} seconds. {message}");
            }
            catch (NoSuchElementException)
            {
                // Logowanie zamiast rzucania wyjątku
                Console.WriteLine($"Element with locator: '{by}' was not found. {message}");
            }
        }


        public static void ScrollToElementAndClickWithMessage(IWebDriver driver, By by, TimeSpan timeSpan, string message = null, int retries = 3)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeSpan);
            int attempts = 0;

            while (attempts < retries)
            {
                try
                {
                    var element = wait.Until(driver =>
                    {
                        var foundElement = driver.FindElement(by);
                        return (foundElement != null && foundElement.Displayed) ? foundElement : null;
                    });

                    if (element == null)
                    {
                        Console.WriteLine($"Element with locator: '{by}' was not found or is not visible. {message}");
                        return;
                    }

                    Actions actions = new Actions(driver);
                    actions.MoveToElement(element).Perform();
                    element.Click();
                    return; // Zakończ, jeśli kliknięcie powiodło się
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine($"Attempt {attempts + 1}: Element with locator: '{by}' was not clickable after {timeSpan.TotalSeconds} seconds. {message}");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Attempt {attempts + 1}: Element with locator: '{by}' was not found. {message}");
                }
                attempts++;
            }

            // Jeśli po liczbie prób element nie został kliknięty, zgłoś wyjątek
            throw new Exception($"Failed to click element with locator: '{by}' after {retries} attempts. {message}");
        }



        /*public static string ParseDateString(string dateString)
            {
                  DateTime parsedDate;
                  bool isParsed = DateTime.TryParseExact(dateString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
                  return isParsed ? parsedDate.ToString("dd-MM-yyyy") : dateString;
            }*/

        public static string ParseDateString(string dateString)
        {
            DateTime parsedDate;
            string[] formats = { "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss.fff", "yyyy-MM-dd" };
            bool isParsed = DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

            if (isParsed)
            {
                return parsedDate.ToString("yyyy-MM-dd");
            }
            return dateString;
        }



    }
}

