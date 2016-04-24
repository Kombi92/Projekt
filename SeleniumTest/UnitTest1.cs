using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {

        static IWebDriver driver;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new ChromeDriver(@"C:\Users\Konrad\Source\Repos\Projekt\SeleniumTest");
        }
        [TestMethod]
        public void TestAbout()
        { 
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.Navigate().GoToUrl("http://localhost:41340/");
            driver.FindElement(By.CssSelector("a[href*='/Home/About']")).Click();
            driver.FindElement(By.TagName("h2")).Click();
            driver.Navigate().Back();
        }


        [TestMethod]
        public void TestRegister()
        {
            driver.Navigate().GoToUrl("http://localhost:41340/");
            driver.FindElement(By.Id("registerLink")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@admin.pl");
            driver.FindElement(By.Id("Password")).SendKeys("adminadmin");
            driver.FindElement(By.Id("Password")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestUczen()
        {
            driver.Navigate().GoToUrl("http://localhost:41340/");
            driver.FindElement(By.CssSelector("a[href*='/Uczen']")).Click();
            driver.FindElement(By.CssSelector("a[href*='/DodajUczen']")).Click();
        }
    }
}
