using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            IWebElement idOfCreateButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);
            InsertKindergartenData(driver);
            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);
            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("GroupNameInput"));

            IWebElement idOfGroupName = driver.FindElement(By.Id("GroupNameInput"));
            var groupnameinindex = idOfGroupName.Text;
            IWebElement idOfChildrenCount = driver.FindElement(By.Id("ChildrenCountInput"));
            var childrencountinindex = idOfChildrenCount.Text;

            NUnit.Framework.Assert.That(groupnameinindex, Is.EqualTo("Name"));
            NUnit.Framework.Assert.That(childrencountinindex, Is.EqualTo("500"));
            Console.WriteLine("Test passed");
        }

        private static void InsertKindergartenData(IWebDriver driver)
        {
            IWebElement idOfGroupNameInput = driver.FindElement(By.Id("GroupNameInput"));
            idOfGroupNameInput.SendKeys("Name"); //sisesta väljale klahvivajutusena NameAddingTest

            IWebElement idOfChildrenCountInput = driver.FindElement(By.Id("ChildrenCountInput"));
            idOfChildrenCountInput.SendKeys("500"); //sisesta väljale klahvivajutusena ChildrenCountAddingTest

            IWebElement idOfindergartenNameInput = driver.FindElement(By.Id("KindergartenNameInput"));
            idOfindergartenNameInput.SendKeys("NameName");

            IWebElement idOfTeacherNameInput = driver.FindElement(By.Id("TeacherNameInput"));
            idOfTeacherNameInput.SendKeys("Teacher");

        }

        [Test]
        public void DetailsKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            IWebElement idOfCreateButton = driver.FindElement(By.Id("DetailsButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);


            IWebElement idOfGroupName = driver.FindElement(By.Id("testIdGrouN_D"));
            var groupnameindetails = idOfGroupName.Text;
            IWebElement idOfChildrenCount = driver.FindElement(By.Id("testIdChildrenC_D"));
            var childrencountindetails = idOfChildrenCount.Text;
            IWebElement idOfKindergartenName = driver.FindElement(By.Id("testIdKindergartenN_D"));
            var kindergartennameindetails = idOfChildrenCount.Text;
            IWebElement idOfTeacherName = driver.FindElement(By.Id("testIdTeacherN_D"));
            var teachernameindetails = idOfTeacherName.Text;

            NUnit.Framework.Assert.That(groupnameindetails, Is.EqualTo("Name"));
            NUnit.Framework.Assert.That(childrencountindetails, Is.EqualTo("500"));
            NUnit.Framework.Assert.That(kindergartennameindetails, Is.EqualTo("NameName"));
            NUnit.Framework.Assert.That(teachernameindetails, Is.EqualTo("Teacher"));
            Console.WriteLine("Test passed");
        }


        [Test]
        public void UpdateKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            IWebElement idOfCreateButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);
            UpdateKindergartenData(driver);
            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);
            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("GroupNameInput"));

            IWebElement idOfGroupName = driver.FindElement(By.Id("GroupNameInput"));
            var groupnameinindex = idOfGroupName.Text;
            IWebElement idOfChildrenCount = driver.FindElement(By.Id("ChildrenCountInput"));
            var childrencountinindex = idOfChildrenCount.Text;

            NUnit.Framework.Assert.That(groupnameinindex, Is.EqualTo("NameName"));
            NUnit.Framework.Assert.That(childrencountinindex, Is.EqualTo("500500"));
            Console.WriteLine("Test passed");
        }

        private static void UpdateKindergartenData(IWebDriver driver)
        {
            IWebElement idOfGroupNameInput = driver.FindElement(By.Id("GroupNameInput"));
            idOfGroupNameInput.SendKeys("Name");

            IWebElement idOfChildrenCountInput = driver.FindElement(By.Id("ChildrenCountInput"));
            idOfChildrenCountInput.SendKeys("500");

            IWebElement idOfindergartenNameInput = driver.FindElement(By.Id("KindergartenNameInput"));
            idOfindergartenNameInput.SendKeys("NameName");

            IWebElement idOfTeacherNameInput = driver.FindElement(By.Id("TeacherNameInput"));
            idOfTeacherNameInput.SendKeys("Teacher");

        }

        [Test]
        public void DeleteKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            IWebElement idOfCreateButton = driver.FindElement(By.Id("DeleteButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);
            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("DeleteButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);
            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("GroupNameInput"));

            IWebElement idOfGroupName = driver.FindElement(By.Id("GroupNameInput"));
            var groupnameinindex = idOfGroupName.Text;
            IWebElement idOfChildrenCount = driver.FindElement(By.Id("ChildrenCountInput"));
            var childrencountinindex = idOfChildrenCount.Text;

            NUnit.Framework.Assert.That(groupnameinindex, Is.Not.EqualTo("NameName"));
            NUnit.Framework.Assert.That(childrencountinindex, Is.Not.EqualTo("500500"));
            Console.WriteLine("Test passed");
        }
    }
}
