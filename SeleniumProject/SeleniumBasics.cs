using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
            Thread.Sleep(1000);
            
            driver.Navigate().GoToUrl("http://uitestpractice.com");
            Thread.Sleep(1000);

            // navigate.back() moves back to single entry in
            // the browser history
            driver.Navigate().Back();

            // navigate.forward() moves the forward
            // to single line in history
            driver.Navigate().Forward();

            // refresh is presnet in inavigation interface
            // and refresh the current page
            driver.Navigate().Refresh();
        }

        [TestMethod]
        public void EverythingaboutLocators()
        {
            // DOM is an application programming interface
            // for valid html and well formed-xml documents
            // it defines logical structure of documents and
            // and a way document is accessed and manipulated

            // Isearchcontext interfaces has 2 methods
            //findelement and findelements()
            //this methods will be abstract
            // isearchcontext is implemeneted by iWebelemtns and Iwebdriver

            // Locating element inIWebdriver is done by using the
            // method FindElement(by.locator)
            
            // FindElement() method takes locator(By Object) as an 
            // argument and returns a object of IWebElement

            // parameters -> by - the locating mechanism
            // returns --> first matching element in current contecxt
            // throws -> nosuchelementexception -> if no element is found

            // FindElements() -> 
            // parameters -> By locating mechanism
            // returns -> list of webelements
            // if no element is found with locator, retuns null

            // by -->
            // it is class.All locators are static methods present in by class
            // Find element and find elements used By class to locate the elements

            // Locators--> 
            // finds the elemnts in html documents
            // static method present in by class
            // locator method return by object
               
        }

        // similar for  name
        [TestMethod]
        public void LocateById()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.hugedomains.com/payment-plan-login.cfm";
            driver.FindElement(By.Id("hdv3CheckoutFormDomainID")).SendKeys("abc@gmail.com");
            driver.Quit();
        }

        [TestMethod]
        public void LocateByTagName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.hugedomains.com/payment-plan-login.cfm";
            IList<IWebElement> elements = driver.FindElements(By.TagName("input"));
            Console.WriteLine(elements.Count);

            foreach (IWebElement ele in elements)
            {
                Console.WriteLine(ele.GetAttribute("name"));
            }
        }

        [TestMethod]
        public void LocateByLinkText()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.hugedomains.com/payment-plan-login.cfm";
            // Partial link text is same as link text
            driver.FindElement(By.LinkText("Home")).Click();
            Thread.Sleep(200);
            driver.Quit();
        }

        [TestMethod]
        public void LocateByCSSSelectors()
        {
            // driver.findElement(By.CssSelector("*")) --> selects all the elements in DOM
            // 
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.lambdatest.com/blog";
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("*"));

            Dictionary<string, int> countofObjects = new Dictionary<string, int>();

            foreach (IWebElement ele in elements)
            {
                    if (countofObjects.ContainsKey(ele.TagName))
                    {
                        countofObjects[ele.TagName]++;
                    }
                    else 
                    {
                        countofObjects.Add(ele.TagName, 1);
                    }
            }

            foreach (var key in countofObjects.Keys)
            {
                Console.WriteLine("The number of "+key+ "objects in web page are "+countofObjects[key]);
            }

        }

        public async Task FindBrokenLinksAsync(string linkUrl)
        {
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(5000);
                HttpResponseMessage response = await client.GetAsync(linkUrl);
                if (response.StatusCode >= HttpStatusCode.NotFound)
                {
                    Console.WriteLine("The " + linkUrl + "is broken link");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The exception is occured");
            }
        }

        [TestMethod]
        public async Task FindLinksAndVerifyBrokenAsync()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.lambdatest.com/blog";
            IList<IWebElement> elements = driver.FindElements(By.TagName("a"));

            foreach (IWebElement ele in elements)
            {
                string url = ele.GetAttribute("href");
                if (url.StartsWith("https://"))
                {
                    await FindBrokenLinksAsync(url);
                }
            }

            driver.Quit();
        }

        [TestMethod]
        public void LearnCSSSelector()
        {
            // ^ --> starts with
            IWebDriver driver = new ChromeDriver();
            driver.FindElement(By.CssSelector("a[href^='Home']"));

            // $ --> ends with
            driver.FindElement(By.CssSelector("a[href$='Home']"));

            // Element Element CSS selector 
            // space will select the decendents of the tag

        }

        [TestMethod]
        public void LearnXPath()
        {
            // Xpath functions
            // Text()
            // Start-with()
            // contains()
            // not()
            // last()
            // position()

            //text

            IWebDriver driver = new ChromeDriver();
        }

        [TestMethod]
        public void EveryThingAboutDropDown()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Select";
            IWebElement element = driver.FindElement(By.Id("countriesSingle"));

        }
    }
}
