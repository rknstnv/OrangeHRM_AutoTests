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
    public class WebPage
    {
        private string path;

        public BaseDriver driver { get; private set; }

        public WebPage(string path, BaseDriver driver)
        {
            this.path = path;
            this.driver = driver;
        }

        public void OpenPage()
        {
            driver.GoToUrl(path);
        }

        public void Press_Button(string buttonName, int elementCount = 1)
        {
            driver.Click(By.XPath($"//button[text()=' {buttonName} '][{elementCount}]"));
        }
        public void Fill_Field(string fieldName, string text)
        {
            driver.SendKeys(By.XPath($"//input[@placeholder='{fieldName}']"), text);
        }

        public void Fill_FieldByLabel(string fieldName, string text)
        {
            driver.SendKeys(By.XPath($"//label[text()='{fieldName}']/../..//input[@placeholder='Type here']"), text);

        }

        public void SelectMenu(string menuName) 
        {
            driver.Click(By.XPath($"//span[text()='{menuName}']"));
        }

        public void ErrorMessage(string fieldName, string message) // Проверка, что в поле вышло сообщение о том, что оно не заполнено
        {
            string xpath;
            bool hasNotLabel = driver.FindElements(By.XPath($"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']")).Count > 0;

            if (hasNotLabel) // Проверяем два разных пути
            {
                xpath = $"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']"; // Тут поле где наименование внутри поля
            }
            else
            {
                xpath = $"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='{message}']"; // Тут путь, где наименование над полем
            }

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Ожидание элемента 10 секунд

            //IWebElement errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath))); // Обращаемся к элементу errorMessage по нашему xpath

            //Assert.IsTrue(errorMessage.Displayed); // Проверка, что наша ошибка отображается

        }

        public void Message_Succesfully(string messageValue)
        {
            string xpath = $"//p[text()='{messageValue}']";

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //IWebElement succesMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath))); 

            //Assert.IsTrue(succesMessage.Displayed);

            driver.WaitUntilElementVisible(By.XPath(xpath));
        }

        public void Assert_HasRecord(string recordName)
        {
            driver.WaitUntilElementVisible(By.XPath($"//div[text() = '{recordName}'"));
        }
    }
}
