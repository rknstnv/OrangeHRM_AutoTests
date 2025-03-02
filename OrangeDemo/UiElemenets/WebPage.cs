using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiElemenets
{
    public class WebPage : BaseDriver
    {
        public WebPage() { }

        public void Press_Button(string buttonName)
        {
            Click(By.XPath($"//button[text()=' {buttonName} ']"));
        }
        public void Fill_Field(string fieldName, string text)
        {
            SendKeys(By.XPath($"//input[@placeholder='{fieldName}']"), text);
        }

        public void Fill_FieldByLabel(string fieldName, string text)
        {
            SendKeys(By.XPath($"//label[text()='{fieldName}']/../..//input[@placeholder='Type here']"), text);
         //       $"//label[text()= '{fieldName}']"), text);
        }

        public void SelectMenu(string menuName) 
        {
            Click(By.XPath($"//span[text()='{menuName}']"));
        }

        public void OpenPage(string pageUrl = "")
        {
            string fullUrl = Utilities.url + pageUrl;

            if (driver.Url != fullUrl) // Проверяем, не находимся ли мы уже на нужной странице
            {
                driver.Navigate().GoToUrl(fullUrl);
            }
        }

        public void Message_FieldIsRequired(string fieldName) // Проверка, что в поле вышло сообщение о том, что оно не заполнено
        {
            string xpath;
            bool hasPlaceholder = driver.FindElements(By.XPath($"//input[@placeholder= '{fieldName}']/../..//span[text()='Required']")).Count > 0;

            if (hasPlaceholder)
            {
                 xpath = $"//input[@placeholder= '{fieldName}']/../..//span[text()='Required']"; 
            }
            else 
            {
                 xpath = $"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='Required']";
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath))); // Обращаемся к элементу errorMessage по нашему xpath

            Assert.IsTrue(errorMessage.Displayed); // Проверка, что наша ошибка отображается
        }

        public void Message_Succesfully(string messageValue)
        {
            string xpath = $"//p[text()='{messageValue}']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement succesMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath))); 
            
            Assert.IsTrue(succesMessage.Displayed);
        }
    }
}
