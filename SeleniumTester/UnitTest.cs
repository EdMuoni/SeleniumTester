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

        [Test, Order(1)]
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

            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdGrouN_I"));

            IWebElement idOfGroupName = driver.FindElement(By.Id("testIdGrouN_I"));
            var groupnameinindex = idOfGroupName.Text;

            IWebElement idOfChildrenCount = driver.FindElement(By.Id("testChildrenC_I"));
            var childrencountinindex = idOfChildrenCount.Text;

            IWebElement idOfKindergartenName = driver.FindElement(By.Id("testKindergartenN_I"));
            var kindergartennameinindex = idOfKindergartenName.Text;

            IWebElement idOfTeacherName = driver.FindElement(By.Id("testTeacherN_I"));
            var teachernameinindex = idOfTeacherName.Text;

            NUnit.Framework.Assert.That(groupnameinindex, Is.EqualTo("Name"));
            NUnit.Framework.Assert.That(childrencountinindex, Is.EqualTo("500"));
            Console.WriteLine("Test passed");
        }

        private static void InsertKindergartenData(IWebDriver driver)
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

        [Test, Order(2)]
        public void DetailsKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            IWebElement idOfDetailsButton = driver.FindElement(By.Id("DetailsButtonAction"));
            idOfDetailsButton.Click();
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
            Console.WriteLine("Test passed");
        }


        [Test, Order(3)]
        public void UpdateKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfCreateButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);

            // Muudame andmed kustutades eelnevad ja sisestades uued
            UpdateKindergartenData(driver);

            IWebElement idOfUpdatePostButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdatePostButton.Click();
            Thread.Sleep(500);

            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdGrouN_I"));

            IWebElement idOfGroupName = driver.FindElement(By.Id("testIdGrouN_I"));
            var groupnameinindex = idOfGroupName.Text;
            IWebElement idOfChildrenCount = driver.FindElement(By.Id("testChildrenC_I"));
            var childrencountinindex = idOfChildrenCount.Text;
            IWebElement idOfKindergartenName = driver.FindElement(By.Id("testKindergartenN_I"));
            var kindergartennameinindex = idOfKindergartenName.Text;
            IWebElement idOfTeacherName = driver.FindElement(By.Id("testTeacherN_I"));
            var Teachernameinindex = idOfTeacherName.Text;

            NUnit.Framework.Assert.That(groupnameinindex, Is.EqualTo("NameName"));
            NUnit.Framework.Assert.That(childrencountinindex, Is.EqualTo("500500"));
            Console.WriteLine("Test passed");
        }

        private static void UpdateKindergartenData(IWebDriver driver)
        {
            IWebElement idOfGroupNameInput = driver.FindElement(By.Id("GroupNameInput"));
            idOfGroupNameInput.Clear();
            idOfGroupNameInput.SendKeys("NameName");

            IWebElement idOfChildrenCountInput = driver.FindElement(By.Id("ChildrenCountInput"));
            idOfChildrenCountInput.Clear();
            idOfChildrenCountInput.SendKeys("500500");

            IWebElement idOfindergartenNameInput = driver.FindElement(By.Id("KindergartenNameInput"));
            idOfindergartenNameInput.Clear();
            idOfindergartenNameInput.SendKeys("NameName");

            IWebElement idOfTeacherNameInput = driver.FindElement(By.Id("TeacherNameInput"));
            idOfTeacherNameInput.Clear();
            idOfTeacherNameInput.SendKeys("Teacher");

        }

        [Test, Order(4)]
        public void DeleteKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);
            //Thread.Sleep(3000);
            //driver.Navigate().Back();
            IWebElement idOfDeleteButton = driver.FindElement(By.Id("DeleteButtonAction"));
            idOfDeleteButton.Click();
            Thread.Sleep(500);

            IWebElement idOfDeletePostButton = driver.FindElement(By.Id("DeleteButtonAction"));
            idOfDeletePostButton.Click();
            Thread.Sleep(500);

            ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdGrouN_I"));

            var groupNameElements = driver.FindElements(By.Id("testIdGrouN_I"));
            var childrenCountElements = driver.FindElements(By.Id("testChildrenC_I"));

            Assert.That(groupNameElements.Count, Is.EqualTo(0));
            Assert.That(childrenCountElements.Count, Is.EqualTo(0));

            Console.WriteLine("Test passed");
        }

        [Test, Order(5)]
        public void CreateNegativeKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfCreateButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);

            InsertNegativeKindergartenData(driver);
            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);

            // 1. No new record should appear
            var rows = driver.FindElements(By.Id("testIdGrouN_I"));
            Assert.That(rows.Count, Is.EqualTo(0));

            // 2. Optional: Page did not navigate away
            //Assert.That(driver.Url, Does.Contain("create"));
            Assert.That(driver.Url.ToLower(), Does.EndWith("/kindergartens/create"));

            Console.WriteLine("Negative create test passed");
        }

        private static void InsertNegativeKindergartenData(IWebDriver driver)
        {
            IWebElement idOfGroupNameInput = driver.FindElement(By.Id("GroupNameInput"));
            idOfGroupNameInput.SendKeys("Name");

            IWebElement idOfChildrenCountInput = driver.FindElement(By.Id("ChildrenCountInput"));
            idOfChildrenCountInput.SendKeys("It is not a number");

            IWebElement idOfindergartenNameInput = driver.FindElement(By.Id("KindergartenNameInput"));
            idOfindergartenNameInput.SendKeys("NameName");

            IWebElement idOfTeacherNameInput = driver.FindElement(By.Id("TeacherNameInput"));
            idOfTeacherNameInput.SendKeys("Teacher");

        }

        [Test, Order(6)]
        public void UpdateNegativeKindergartenTest()
        {
            IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
            driver.Url = "http://localhost:5138"; //navigeeri siia
            IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
            idOfLinkElement.Click(); //vajuta sellele elemendile
            Thread.Sleep(500);

            IWebElement idOfCreateButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreateButton.Click();
            Thread.Sleep(500);

            InsertCreatedKindergartenData(driver);

            IWebElement idOfCreatePostButton = driver.FindElement(By.Id("CreateButtonAction"));
            idOfCreatePostButton.Click();
            Thread.Sleep(500);

            IWebElement idOfUpdateButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdateButton.Click();
            Thread.Sleep(500);

            UpdateNegativeKindergartenData(driver);
            IWebElement idOfUpdatePostButton = driver.FindElement(By.Id("UpdateButtonAction"));
            idOfUpdatePostButton.Click();
            Thread.Sleep(500);

            UpdateNegativeKindergartenData(driver);

            driver.FindElement(By.Id("UpdateButtonAction")).Click();
            Thread.Sleep(500);

            //Kontrollime ainult et URL sisaldab "/kindergartens/update/"
            Assert.That(driver.Url.ToLower(), Does.Contain("/kindergartens/update/"));

            Console.WriteLine("Negative update test passed");
        }

        private static void UpdateNegativeKindergartenData(IWebDriver driver)
        {
            IWebElement idOfGroupNameInput = driver.FindElement(By.Id("GroupNameInput"));
            idOfGroupNameInput.Clear();
            idOfGroupNameInput.SendKeys("NameName");

            IWebElement idOfChildrenCountInput = driver.FindElement(By.Id("ChildrenCountInput"));
            idOfChildrenCountInput.Clear();
            idOfChildrenCountInput.SendKeys("It is not a number");

            IWebElement idOfindergartenNameInput = driver.FindElement(By.Id("KindergartenNameInput"));
            idOfindergartenNameInput.Clear();
            idOfindergartenNameInput.SendKeys("NameName");

            IWebElement idOfTeacherNameInput = driver.FindElement(By.Id("TeacherNameInput"));
            idOfTeacherNameInput.Clear();
            idOfTeacherNameInput.SendKeys("Teacher");

        }

        private static void InsertCreatedKindergartenData(IWebDriver driver)
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
    }
}
