using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTester
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Order(1)]
        public void CreateSpaceshipTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Spaceships")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfCreateButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);

            //Insering spaceship data using the same method as kindergarten for simplicity
            InsertSpaceshipData(driver);

            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);

            //Checking if spaceship was created by checking for elements in index
            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdName_I"));

            IWebElement idOfName = driver.FindElement(By.Id("testIdName_I"));
            var nameinindex = idOfName.Text;

            IWebElement idOfClassification = driver.FindElement(By.Id("testIdClassification_I"));
            var Classificationinindex = idOfClassification.Text;

            IWebElement idOfCrew = driver.FindElement(By.Id("testIdCrew_I"));
            var crewinindex = idOfCrew.Text;

            NUnit.Framework.Assert.That(nameinindex, Is.EqualTo("Mountain"));
            NUnit.Framework.Assert.That(Classificationinindex, Is.EqualTo("NoobCrasher"));
            Console.WriteLine("Test passed");
        }

        private static void InsertSpaceshipData(IWebDriver driver)
        {
            IWebElement idOfNameInput = driver.FindElement(By.Id("NameInput"));
            idOfNameInput.SendKeys("Mountain");

            IWebElement idOfClassificationInput = driver.FindElement(By.Id("ClassificationInput"));
            idOfClassificationInput.SendKeys("NoobCrasher");

            IWebElement idOfCrewInput = driver.FindElement(By.Id("CrewInput"));
            idOfCrewInput.SendKeys("800");

            IWebElement idOfEnginePowerInput = driver.FindElement(By.Id("EnginePowerInput"));
            idOfEnginePowerInput.SendKeys("9000");

        }

        [Test, Order(2)]
        public void DetailsKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Spaceships")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfDetailsButton = driver.FindElement(By.Id("DetailsButtonAction"));
            idOfDetailsButton.Click();
            Thread.Sleep(500);

            IWebElement idOfName = driver.FindElement(By.Id("testIdName_D"));
            var nameinindex = idOfName.Text;

            IWebElement idOfClassification = driver.FindElement(By.Id("testIdClassification_D"));
            var Classificationindetails = idOfClassification.Text;

            IWebElement idOfCrew = driver.FindElement(By.Id("testIdCrew_D"));
            var crewindetails = idOfCrew.Text;

            NUnit.Framework.Assert.That(nameinindex, Is.EqualTo("Mountain"));
            NUnit.Framework.Assert.That(Classificationindetails, Is.EqualTo("NoobCrasher"));
            Console.WriteLine("Test passed");
        }


        [Test, Order(3)]
        public void UpdateSpaceshipTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Spaceships")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfUpdateButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdateButton.Click();
            Thread.Sleep(500);

            // Muudame andmed kustutades eelnevad ja sisestades uued
            UpdatetSpaceshipData(driver);

            IWebElement idOfUpdatePostButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdatePostButton.Click();
            Thread.Sleep(500);

            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdName_I"));

            IWebElement idOfName = driver.FindElement(By.Id("testIdName_I"));
            var nameinindex = idOfName.Text;

            IWebElement idOfClassification = driver.FindElement(By.Id("testIdClassification_I"));
            var classificationinindex = idOfClassification.Text;

            IWebElement idOfCrew = driver.FindElement(By.Id("testIdCrew_I"));
            var crewinindex = idOfCrew.Text;

            NUnit.Framework.Assert.That(nameinindex, Is.EqualTo("Mountain5000"));
            NUnit.Framework.Assert.That(classificationinindex, Is.EqualTo("NoobCrasher1000"));
            Console.WriteLine("Test passed");
        }

        private static void UpdatetSpaceshipData(IWebDriver driver)
        {
            IWebElement idOfNameInput = driver.FindElement(By.Id("NameInput"));
            idOfNameInput.Clear();
            idOfNameInput.SendKeys("Mountain5000");

            IWebElement idOfClassificationInput = driver.FindElement(By.Id("ClassificationInput"));
            idOfClassificationInput.Clear();
            idOfClassificationInput.SendKeys("NoobCrasher1000");

            IWebElement idOfCrewInput = driver.FindElement(By.Id("CrewInput"));
            idOfCrewInput.Clear();
            idOfCrewInput.SendKeys("800");

            IWebElement idOfEnginePowerInput = driver.FindElement(By.Id("EnginePowerInput"));
            idOfEnginePowerInput.Clear();
            idOfEnginePowerInput.SendKeys("9000");

        }

        [Test, Order(4)]
        public void DeleteSpaceshipTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Spaceships")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfDeleteButton = driver.FindElement(By.Id("DeleteButtonAction"));
            idOfDeleteButton.Click();
            Thread.Sleep(500);

            IWebElement idOfDeletePostButton = driver.FindElement(By.Id("DeleteButtonAction"));
            idOfDeletePostButton.Click();
            Thread.Sleep(500);

            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdName_I"));

            var nameElements = driver.FindElements(By.Id("testIdName_I"));
            var classificationElements = driver.FindElements(By.Id("testChildrenC_I"));

            Assert.That(nameElements.Count, Is.EqualTo(0));
            Assert.That(classificationElements.Count, Is.EqualTo(0));

            Console.WriteLine("Test passed");
        }

        [Test, Order(5)]
        public void CreateNegativeSpaceshipTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Spaceships")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfCreateButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);

            InsertNegativeSpaceshipData(driver);
            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);

            // 1. No new record should appear
            var rows = driver.FindElements(By.Id("testIdName_I"));
            Assert.That(rows.Count, Is.EqualTo(0));

            // 2. Optional: Page did not navigate away
            //Assert.That(driver.Url, Does.Contain("create"));
            Assert.That(driver.Url.ToLower(), Does.EndWith("/spaceships/create"));

            Console.WriteLine("Negative create test passed");
        }

        private static void InsertNegativeSpaceshipData(IWebDriver driver)
        {
            IWebElement idOfNameInput = driver.FindElement(By.Id("NameInput"));
            idOfNameInput.SendKeys("Mountain");

            IWebElement idOfClassificationInput = driver.FindElement(By.Id("ClassificationInput"));
            idOfClassificationInput.SendKeys("NoobCrasher");

            IWebElement idOfCrewInput = driver.FindElement(By.Id("CrewInput"));
            idOfCrewInput.SendKeys("This is not a number");

            IWebElement idOfEnginePowerInput = driver.FindElement(By.Id("EnginePowerInput"));
            idOfEnginePowerInput.SendKeys("This is DEFINETLY not a number");

        }

        [Test, Order(6)]
        public void UpdateNegativeSpaceshipTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Spaceships")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfCreateButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);

            InsertCreatedSpaceshipData(driver);
            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);

            IWebElement idOfUpdateButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdateButton.Click();
            Thread.Sleep(500);

            UpdateNegativeSpaceshipData(driver);
            IWebElement idOfUpdatePostButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdatePostButton.Click();
            Thread.Sleep(500);

            UpdateNegativeSpaceshipData(driver);

            driver.FindElement(By.Id("UpdateButtonAction")).Click();
            Thread.Sleep(500);

            //Kontrollime ainult et URL sisaldab "/kindergartens/update/"
            Assert.That(driver.Url.ToLower(), Does.Contain("/spaceships/update/"));

            Console.WriteLine("Negative update test passed");
        }

        private static void UpdateNegativeSpaceshipData(IWebDriver driver)
        {
            IWebElement idOfNameInput = driver.FindElement(By.Id("NameInput"));
            idOfNameInput.Clear();
            idOfNameInput.SendKeys("Mountain5000");

            IWebElement idOfClassificationInput = driver.FindElement(By.Id("ClassificationInput"));
            idOfClassificationInput.Clear();
            idOfClassificationInput.SendKeys("NoobCrasher1000");

            IWebElement idOfCrewInput = driver.FindElement(By.Id("CrewInput"));
            idOfCrewInput.Clear();
            idOfCrewInput.SendKeys("This is not a number");

            IWebElement idOfEnginePowerInput = driver.FindElement(By.Id("EnginePowerInput"));
            idOfEnginePowerInput.Clear();
            idOfEnginePowerInput.SendKeys("This is DEFINETLY not a number");
        }

        private static void InsertCreatedSpaceshipData(IWebDriver driver)
        {
            IWebElement idOfNameInput = driver.FindElement(By.Id("NameInput"));
            idOfNameInput.SendKeys("Mountain");

            IWebElement idOfClassificationInput = driver.FindElement(By.Id("ClassificationInput"));
            idOfClassificationInput.SendKeys("NoobCrasher");

            IWebElement idOfCrewInput = driver.FindElement(By.Id("CrewInput"));
            idOfCrewInput.SendKeys("500");

            IWebElement idOfEnginePowerInput = driver.FindElement(By.Id("EnginePowerInput"));
            idOfEnginePowerInput.SendKeys("900000");

        }
    }
}