using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Locators
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void LocatorIdentifiers()
        {
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyaccademy");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("123456");
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.CssSelector(".text-info span input")).Click();
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Click();
            //driver.FindElement(By.XPath("//input[@value='Sign In']")).Click();

            Thread.Sleep(3000);
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText
                ("Free Access to InterviewQues/ResumeAssistance/Material"));
            String urlAttr = link.GetAttribute("href");
            String expectedUrl = "https://rahulshettyacademy.com/#/documents-request";
            Assert.AreEqual(urlAttr, expectedUrl);

        }

        [TearDown]
        public void CloseBrowser()
    {
        driver.Close();

    }
  }

}
