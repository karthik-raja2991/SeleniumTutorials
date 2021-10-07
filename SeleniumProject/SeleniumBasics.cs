using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Drawing;

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

            driver.Manage().Window.Minimize();

            driver.Manage().Window.FullScreen();

            // position property sets the position of browser
            // window relative to the upper left corner of
            // the screen
            // it is read and write property

            driver.Manage().Window.Position = new Point(400, 200);
            Thread.Sleep(3000);

            // to get the posotion of browser
            Point point = driver.Manage().Window.Position;
            Console.WriteLine("the position is "+point);

            // size is property present in iwindow interface
            // size of outer browser window including title, bars
            // and window borders
            driver.Manage().Window.Size = new Size(400, 600);
            Thread.Sleep(1000);

            // gets the size in height and width
            Size size = driver.Manage().Window.Size;
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
