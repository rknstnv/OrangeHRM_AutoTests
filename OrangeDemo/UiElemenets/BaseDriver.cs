using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace OrangeDemo.UiElemenets
{
    public class BaseDriver
    {
        protected static IWebDriver driver;

        public BaseDriver()
        {
            if (driver == null)
            {
                driver = StartBrowser();
            }
        }

        private WebDriver StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArguments("--incognito");

            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            return new ChromeDriver(path + @"\drivers\", options);
        }

        public void Quiet()
        {
            driver.Quit();
            driver = null;
        }

        public void GoToUrl()
        {
            driver.Url = Utilities.url;
            driver.Navigate().Refresh();
        }

        public void Click(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(e => e.FindElement(locator));

            IWebElement elementToClick = driver.FindElement(locator);

            elementToClick.Click();
        }
        public void SendKeys(By locator, string text, bool pressEnter = false) // Нажатие Enter, по умолчанию - Нет

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(e => e.FindElement(locator));

            IWebElement elementToClick = driver.FindElement(locator);

            elementToClick.SendKeys(text);

            if (pressEnter)
                elementToClick.SendKeys(Keys.Enter); 
        }
        public string GetElementText(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(e => e.FindElement(locator));

            IWebElement elementToClick = driver.FindElement(locator);

            string text = elementToClick.Text;

            return text;
        }
    }
}
