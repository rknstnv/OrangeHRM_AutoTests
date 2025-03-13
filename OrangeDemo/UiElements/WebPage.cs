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
            string xpath1 = $"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']";
            string xpath2 = $"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='{message}']";
            // Почему через два драйвера? Потому что, мой метод нельзя преобразовать в bool, поэтому перетянул базовый метод
            bool hasNotLabel = driver.driver.FindElements(By.XPath(xpath1)).Count > 0; // Убеждаемся, что отображается элемент

            string finalXpath = hasNotLabel ? xpath1 : xpath2; // Тернарный оператор

            driver.WaitUntilElementVisible(By.XPath(finalXpath)); // Метод ожидания отображения

            IWebElement errorMessage = driver.GetElement(By.XPath(finalXpath)); // Обращаемся к элементу errorMessage по нашему finalXpath

            Assert.IsTrue(errorMessage.Displayed);

            //bool hasNotLabel = driver.GetElement(By.XPath($"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']")) !=null; // Без null будет ошибка, проверяем, что объект не null
            //bool hasNotLabel = driver.FindElements(By.XPath($"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']")).Count>0;
            //if (hasNotLabel) // Проверяем два разных пути
            //{
            //    xpath = $"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']"; // Тут поле где наименование внутри поля
            //}
            //else
            //{
            //    xpath = $"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='{message}']"; // Тут путь, где наименование над полем
            //}
            // Поменять на тернарный оператор, добавить два xpath для проверки вверху и один общий finalXpath
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
