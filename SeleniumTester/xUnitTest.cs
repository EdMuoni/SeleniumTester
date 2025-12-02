using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace ToolsQA
{
    class xUnitTest
    {
        IWebDriver driver;

        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        public void OpenAppTest()
        {
            driver.Url = "https://demoqa.com";
        }
        public void EndTest()
        {
            driver.Close();
        }

    }
}