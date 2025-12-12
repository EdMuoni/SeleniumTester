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



    }
}
