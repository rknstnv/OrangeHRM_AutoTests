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
            Click(By.XPath($"//button[text()=' {buttonName}']"));
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
            string xpath = $"//input[@placeholder= '{fieldName}']/../..//span[text()='Required']"; // Указываем наш путь

            IWebElement errorMessage = driver.FindElement(By.XPath(xpath)); // Обращаемся к элементу errorMessage по нашему xpath

            Assert.IsTrue(errorMessage.Displayed); // Проверка, что наша ошибка отображается
        }

        public void Message_Succesfully(string messageValue)
        {
            string xpath = $"//p[text()='{messageValue}']";

            IWebElement succesMessage = driver.FindElement(By.XPath(xpath)); 
            
            Assert.IsTrue(succesMessage.Displayed);
        }
    }
}
