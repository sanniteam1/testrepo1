//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;

namespace SmartHotel360.Selenium
{
    [TestClass]
    public class SeleniumTest
    {
        public TestContext TestContext { get; set; }
        private IWebDriver driver;
        private string appURL;
        public int delayCounter = 3000;

        [TestMethod]
        //[TestCategory("Chrome")]
        public void TestSelenium()
        {

            try
            {
                ChromeOptions options = new ChromeOptions();
                bool success = false;
                var errorstring = "";
                for (int y = 0; y < 10; y++)
                {
                    try
                    {

                        driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"), options, TimeSpan.FromMinutes(5));
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                        driver.Navigate().GoToUrl(appURL);

                        try
                        {
                            Thread.Sleep(delayCounter);
                            var login = driver.FindElement(By.XPath("/html/body/div[2]/ul/div/li/span"));
                            if (login != null)
                                driver.FindElement(By.XPath("/html/body/div[2]/ul/div/li/span")).Click();
                        }
                        catch (Exception) { }

                        Thread.Sleep(delayCounter);
                        var whereBox = driver.FindElement(By.XPath("//*[@id=\"reservation_Location\"]"));
                        ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0, 750);", whereBox);
                        whereBox.SendKeys("New");
                        Thread.Sleep(delayCounter);
                        driver.FindElement(By.XPath("//*[@id=\"locationList\"]")).FindElement(By.TagName("li")).Click();
                        Thread.Sleep(delayCounter);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/section/div/form/div/div/section/div[2]/div[1]/div/div[1]/a[2]/span")).Click();
                        Thread.Sleep(delayCounter);
                        driver.FindElement(By.XPath("/html/body/div[3]/div/section/div/form/div/div/section/div[2]/div[1]/div/div[3]/div[3]/div[7]/a")).Click();
                        Thread.Sleep(delayCounter);
                        driver.FindElement(By.XPath("//*[@id=\"AnswerDiv\"]/div[2]/div[2]/div/input[2]")).Click();
                        Thread.Sleep(delayCounter);
                        driver.FindElement(By.XPath("//*[@id=\"react-app\"]/div/section/div/form/div/div/ul[2]/li[4]/input")).Click();
                        Thread.Sleep(delayCounter);
                        driver.FindElement(By.ClassName("sh-rooms-item")).Click();
                        Thread.Sleep(delayCounter);
                        success = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(appURL);
                        Console.WriteLine("Try " + y.ToString() + " " + ex.Message);
                        driver.Dispose();
                        errorstring = ex.Message;
                    }
                    Thread.Sleep(5000);
                }
                if (!success)
                { throw new Exception(errorstring); }
            }
            catch (Exception e)
            {
                driver.Quit();
                Assert.Fail(e.Message);
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = TestContext.Properties["appURL"].ToString();


            //string browser = "Chrome";
            //switch (browser)
            //{
            //    case "Chrome":
                    
            //        break;
            //    default:
            //        driver = new ChromeDriver("./");
            //        break;
            //}

        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
