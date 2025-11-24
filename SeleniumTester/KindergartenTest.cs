using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTester.Tests
{
    [TestFixture]
    public class KindergartenTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://localhost:5138";

        [SetUp]
        public void Setup()
        {
            // Iga testi ees käivitame uue brauseri
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            // Pärast iga testi sulgeme brauseri
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

        // TEST 1: Navigeerimine Kindergarten lehele
        [Test]
        public void Test_NavigateToKindergartenPage()
        {
            // Arrange & Act
            driver.Navigate().GoToUrl(baseUrl);
            IWebElement kindergartenLink = driver.FindElement(By.Id("Kindergartens"));
            kindergartenLink.Click();
            Thread.Sleep(500);

            // Assert
            Assert.That(driver.Url.Contains("Kindergarten"), Is.True, "Ei jõudn ud Kindergarten lehele");
            Console.WriteLine("✓ Navigeerimine õnnestus!");
        }

        // TEST 2: Lisamine õigete andmetega
        [Test]
        public void Test_CreateKindergarten_WithValidData()
        {
            // Arrange
            driver.Navigate().GoToUrl($"{baseUrl}/Kindergarten");
            Thread.Sleep(500);

            // Act - Vajuta "Create New" nuppu
            IWebElement createButton = driver.FindElement(By.Id("testIdAdd"));
            createButton.Click();
            Thread.Sleep(500);

            // Täida vorm õigete andmetega
            driver.FindElement(By.Id("testIdName")).SendKeys("Päikese Lasteaed");
            driver.FindElement(By.Id("testIdChildrenCount")).SendKeys("45");
            driver.FindElement(By.Id("testIdKindergartenName")).SendKeys("Päikese OÜ");
            driver.FindElement(By.Id("testIdTeacherName")).SendKeys("Mari Maasikas");

            // Salvesta
            IWebElement saveButton = driver.FindElement(By.Id("testIdCPT"));
            saveButton.Click();
            Thread.Sleep(1000);

            // Assert - Kontrolli, et uus lasteaed on nimekirjas
            var pageSource = driver.PageSource;
            Assert.That(pageSource.Contains("Päikese Lasteaed"), Is.True,
                "Uut lasteaeda ei leitud nimekirjast!");
            Console.WriteLine("✓ Lisamine õigete andmetega õnnestus!");
        }

        // TEST 3: Lisamine valede andmetega (negatiivne test)
        [Test]
        public void Test_CreateKindergarten_WithInvalidData()
        {
            // Arrange
            driver.Navigate().GoToUrl($"{baseUrl}/Kindergarten");
            Thread.Sleep(500);

            // Act
            IWebElement createButton = driver.FindElement(By.Id("testIdAdd"));
            createButton.Click();
            Thread.Sleep(500);

            // Ürita sisestada teksti numbri väljale
            IWebElement childrenCountField = driver.FindElement(By.Id("testIdChildrenCount"));
            childrenCountField.SendKeys("ViiskümmendViis"); // Vale andmetüüp - tekst numbri asemel

            // Ürita salvestada
            IWebElement saveButton = driver.FindElement(By.Id("testIdCPT"));
            bool isButtonEnabled = saveButton.Enabled;

            // Kui nupp on aktiivne, proovi vajutada
            if (isButtonEnabled)
            {
                saveButton.Click();
                Thread.Sleep(500);

                // Assert - Kontrolli, et on valideerimise viga
                bool hasValidationError = driver.PageSource.Contains("validation-summary-errors")
                    || driver.PageSource.Contains("field-validation-error")
                    || driver.Url.Contains("Create"); // Peaks jääma Create lehele

                Assert.That(hasValidationError || driver.Url.Contains("Create"), Is.True,
                    "Vale andmetüübiga peaks olema valideerimise viga!");
            }

            Console.WriteLine("✓ Validatsioon töötab - vale andmetüübiga ei saa salvestada!");
        }

        // TEST 4: Vaatamine (Details)
        [Test]
        public void Test_ViewKindergartenDetails()
        {
            // Arrange
            driver.Navigate().GoToUrl($"{baseUrl}/Kindergarten");
            Thread.Sleep(500);

            // Act - Leia esimene "Details" link ja vajuta
            IWebElement detailsLink = driver.FindElement(By.LinkText("Details"));
            detailsLink.Click();
            Thread.Sleep(500);

            // Assert
            Assert.That(driver.Url.Contains("Details"), Is.True,
                "Ei jõudnud detailide lehele!");

            // Kontrolli, et detailid on nähtavad
            var pageSource = driver.PageSource;
            Assert.That(pageSource.Contains("Name") || pageSource.Contains("Nimi"), Is.True,
                "Detailide leht ei sisalda oodatud informatsiooni!");

            Console.WriteLine("✓ Detailide vaatamine õnnestus!");
        }

        // TEST 5: Muutmine õigete andmetega
        [Test]
        public void Test_EditKindergarten_WithValidData()
        {
            // Arrange
            driver.Navigate().GoToUrl($"{baseUrl}/Kindergarten");
            Thread.Sleep(500);

            // Act - Leia esimene "Edit" link
            IWebElement editLink = driver.FindElement(By.LinkText("Edit"));
            editLink.Click();
            Thread.Sleep(500);

            // Muuda nime
            IWebElement nameField = driver.FindElement(By.Id("testIdName"));
            nameField.Clear();
            nameField.SendKeys("Muudetud Lasteaed");

            // Salvesta
            IWebElement updateButton = driver.FindElement(By.Id("testIdUpdate"));
            updateButton.Click();
            Thread.Sleep(1000);

            // Assert
            var pageSource = driver.PageSource;
            Assert.That(pageSource.Contains("Muudetud Lasteaed"), Is.True,
                "Muudetud nime ei leitud nimekirjast!");

            Console.WriteLine("✓ Muutmine õigete andmetega õnnestus!");
        }

        // TEST 6: Muutmine valede andmetega
        [Test]
        public void Test_EditKindergarten_WithInvalidData()
        {
            // Arrange
            driver.Navigate().GoToUrl($"{baseUrl}/Kindergarten");
            Thread.Sleep(500);

            // Act
            IWebElement editLink = driver.FindElement(By.LinkText("Edit"));
            editLink.Click();
            Thread.Sleep(500);

            // Ürita sisestada negatiivsed numbrid
            IWebElement childrenCountField = driver.FindElement(By.Id("testIdChildrenCount"));
            childrenCountField.Clear();
            childrenCountField.SendKeys("-50"); // Vale väärtus

            IWebElement updateButton = driver.FindElement(By.Id("testIdUpdate"));
            updateButton.Click();
            Thread.Sleep(500);

            // Assert - Peaks jääma Edit lehele või näitama viga
            bool stayedOnEditPage = driver.Url.Contains("Edit");
            bool hasValidationError = driver.PageSource.Contains("validation")
                || driver.PageSource.Contains("error");

            Assert.That(stayedOnEditPage || hasValidationError, Is.True,
                "Negatiivse väärtusega peaks olema valideerimise viga!");

            Console.WriteLine("✓ Validatsioon töötab - vale andmetega ei saa uuendada!");
        }

        // TEST 7: Kustutamine
        [Test]
        public void Test_DeleteKindergarten()
        {
            // Arrange - Esmalt loo testlasteaed
            Test_CreateKindergarten_WithValidData();
            driver.Navigate().GoToUrl($"{baseUrl}/Kindergarten");
            Thread.Sleep(500);

            // Leia äsja loodud lasteaed
            var pageSourceBefore = driver.PageSource;
            Assert.That(pageSourceBefore.Contains("Päikese Lasteaed"), Is.True,
                "Test lasteaeda ei leitud enne kustutamist!");

            // Act - Leia "Delete" link
            IWebElement deleteLink = driver.FindElement(By.LinkText("Delete"));
            deleteLink.Click();
            Thread.Sleep(500);

            // Kinnita kustutamine
            IWebElement confirmDeleteButton = driver.FindElement(By.CssSelector("input[type='submit'][value='Delete']"));
            confirmDeleteButton.Click();
            Thread.Sleep(1000);

            // Assert
            var pageSourceAfter = driver.PageSource;
            Assert.That(pageSourceAfter.Contains("Päikese Lasteaed"), Is.False,
                "Kustutatud lasteaed on ikka nimekirjas!");

            Console.WriteLine("✓ Kustutamine õnnestus!");
        }
    }
}
