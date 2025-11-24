using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V140.WebAuthn;
using OpenQA.Selenium.Firefox;

internal class Program
{

    private static void main(string[] args)
    {
        TestKindergartenCreate();
    }

    [Test]
    public static void TestKindergartenCreate()
    {

        IWebDriver driver = new FirefoxDriver(); //uus fiorefoxi driver
        driver.Url = "https://localhost:5138"; //navigeeri siia
        IWebElement idOfLinkElement = driver.FindElement(By.Id("Kindergartens")); //otsi element Kindergartens id-ga
        idOfLinkElement.Click(); //vajuta sellele elemendile
        Thread.Sleep(500);
        //Thread.Sleep(3000);
        //driver.Navigate().Back();
        IWebElement idOfCreateButton = driver.FindElement(By.Id("testIdAdd"));
        idOfCreateButton.Click();
        Thread.Sleep(500);
        InsertKindergartenData(driver);
        IWebElement idOfCreatePostButton = driver.FindElement(By.Id("testIdCPT"));
        idOfCreatePostButton.Click();
        Thread.Sleep(500);
        ICollection<IWebElement> elementstocheck = driver.FindElements(By.Id("testIdNAM_I"));

        IWebElement idOfTestData1 = driver.FindElement(By.Id("testIdNAM_I"));
        var nameinindex = idOfTestData1.Text;
        IWebElement idOfTestData2 = driver.FindElement(By.Id("testIdEPW_I"));
        var powerinindex = idOfTestData2.Text;
        NUnit.Framework.Assert.That(nameinindex, Is.EqualTo("TESTNAME_01"));
        NUnit.Framework.Assert.That(powerinindex, Is.EqualTo("24857"));
        Console.WriteLine("Test passed");




    }

    private static void InsertKindergartenData(IWebDriver driver)
    {
        IWebElement idOfNameInput = driver.FindElement(By.Id("testIdName"));
        idOfNameInput.SendKeys("NameAddingTest"); //sisesta väljale klahvivajutusena NameAddingTest

        IWebElement idOfClassificationInput = driver.FindElement(By.Id("testIdChildrenCount"));
        idOfClassificationInput.SendKeys("ChildrenCountAddingTest"); //sisesta väljale klahvivajutusena ChildrenCountAddingTest

        IWebElement idOfBuiltDateInput = driver.FindElement(By.Id("testIdKindergartenName"));
        idOfBuiltDateInput.SendKeys("KindergartenNameAddingTest");

        IWebElement idOfCrewInput = driver.FindElement(By.Id("testIdTeacherName"));
        idOfCrewInput.SendKeys("TeacherNameAddingTest");

        IWebElement idOfUpdateButton = driver.FindElement(By.Id("testIdUpdate"));
        idOfUpdateButton.Click();

        IWebElement idOfRemoveImageButton = driver.FindElement(By.Id("testIdRemoveImage"));
        idOfRemoveImageButton.Click();

        IWebElement idOfCreateImageButton = driver.FindElement(By.Id("testIdCreate"));
        idOfCreateImageButton.Click();

    }
}
