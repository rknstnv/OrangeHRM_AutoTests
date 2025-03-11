using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OrangeDemo.UiElemenets
{
    public class BaseDriver
    {
        protected IWebDriver driver;

        public BaseDriver()
        {
            driver = StartBrowser();
        }

        private WebDriver StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments("--incognito");

            return new ChromeDriver(options);
        }

        public void Quiet()
        {
            driver.Quit();
        }

        public void GoToUrl(string url)
        {
            driver.Url = Utilities.url + url;
            driver.Navigate().Refresh();
        }

        //public void Click(By locator)
        //{
        //    try
        //    {
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        //        wait.Until(e => e.FindElement(locator));

        //        IWebElement elementToClick = driver.FindElement(locator);

        //        elementToClick.Click();
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception($"{locator} не кликабелен");
        //    }
        //}

        //public void SendKeys(By locator, string text, bool pressEnter = false) // Нажатие Enter, по умолчанию - Нет
        //{
        //    try 
        //    {
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        //        wait.Until(e => e.FindElement(locator));

        //        IWebElement elementToClick = driver.FindElement(locator);

        //        elementToClick.SendKeys(text);

        //        if (pressEnter)
        //            elementToClick.SendKeys(Keys.Enter);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception($"{locator} ");
        //    }
        //}

        //public string GetElementText(By locator)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        //    wait.Until(e => e.FindElement(locator));

        //    IWebElement elementToClick = driver.FindElement(locator);

        //    string text = elementToClick.Text;

        //    return text;
        //}

        //public void WaitForElement(By locator, int timeout = 10)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        //}

        public void WaitUntilElementVisible(By locator, TimeSpan timeSpan = default)
        {
            try
            {
                if (timeSpan == default)
                    timeSpan = TimeSpan.FromSeconds(10);

                WebDriverWait wait = new WebDriverWait(driver, timeSpan);
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception ex)
            {
                throw new Exception($"{locator} не видно на странице");
            }

        }

        public void WaitUntilElementClicable(By locator, TimeSpan timeSpan = default)
        {
            try
            {
                if (timeSpan == default)
                    timeSpan = TimeSpan.FromSeconds(10);

                WebDriverWait wait = new WebDriverWait(driver, timeSpan);
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception ex)
            {
                throw new Exception($"{locator} не кликабелен");
            }

        }

        public IWebElement GetElement(By locator)
        {
            WaitUntilElementVisible(locator);

            return driver.FindElement(locator);
        }

        public void Click(By locator)
        {
            IWebElement elementToClick = GetElement(locator);

            WaitUntilElementClicable(locator);

            elementToClick.Click();
        }

        public void SendKeys(By locator, string value, bool pressEnter = false)
        {
            IWebElement elementToSendKey = GetElement(locator);

            WaitUntilElementClicable(locator);

            elementToSendKey.SendKeys(value);

            if (pressEnter)
                elementToSendKey.SendKeys(Keys.Enter);
        }
    }
}
