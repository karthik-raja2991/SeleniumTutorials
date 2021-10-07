using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumProject
{
    [TestClass]
    public class SeleniumBasics
    {
        [TestMethod]
        public void LaunchBrowser()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "http://ankpro.com";
            driver.Quit();

            // iwebdriver is interface. 
        }

        [TestMethod]
        public void GetPageTitleURLAndPageSource() 
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://ankpro.com";
            Console.WriteLine(driver.Title);
            Console.WriteLine(driver.Url);
            driver.Url = "http://uitestpractice.com";

            string pagesource = driver.PageSource;
            Console.WriteLine(pagesource);
        }

        [TestMethod]
        public void ManageBrowserWindows()
        {
            // driver.manage is method that returns
            // instance of IOption interface
            // ioption interface has propertry window
            // which returns instance of IWindow interface 
            // this interface has maximise and minimize
            // methods
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://ankpro.com";
            driver.Manage().Window.Maximize();
            driver.Quit();
        }

        [TestMethod]
        public void NavigateBrowsers()
        {
            // navigate is method in Iwebdriver interface
            // it returns Inavigation type
            // gotourl is method in inavigation interface

            // driver.navigate() return instance of INavigation
            // I navigation has method gotourl
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://ankpro.com";
            
            driver.Navigate().GoToUrl("http://ankpro.com");

        }
    }
}
