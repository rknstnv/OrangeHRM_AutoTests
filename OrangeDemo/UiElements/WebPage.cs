using Allure.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

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

        public enum FieldType
        {
            Input,
            LabelInput,
            Textarea
        }
        public void OpenPage()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.GoToUrl(path);
            }, $"Открытие страницы {Utilities.url}{path}"); 
        }

        public void Press_Button(string buttonName, int elementCount = 1)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Click(By.XPath($"//button[text()=' {buttonName} '][{elementCount}]"));
            }, $"Нажатие кнопки {buttonName}");
        }

        public void Fill_Field(string fieldName, string text)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                // 1 вариант
                string xpath = $"//input[@placeholder='{fieldName}']";
                IWebElement inputField = driver.GetElement(By.XPath(xpath));
                inputField.Clear();
                driver.SendKeys(By.XPath(xpath), text); 


                // 2 вариант
                //string xpath1 = $"//input[@placeholder='{fieldName}']";
                //string xpath2 = $"//label[text()='{fieldName}']/../..//input";
                //bool hasLabel = driver.driver.FindElements(By.XPath(xpath1)).Count > 0;

                //string finalXpath = hasLabel ? xpath1 : xpath2;
                //driver.SendKeys(By.XPath(finalXpath), text);
 

                // 3 вариант
                //string xpath; 
                //bool hasNotLabel = driver.driver.FindElements(By.XPath($"//input[@placeholder='{fieldName}']")).Count > 0;

                //if (hasNotLabel)
                //{
                //    xpath = $"//input[@placeholder='{fieldName}']";
                //}
                //else if(!hasNotLabel)
                //{
                //    xpath = $"//label[text()='{fieldName}']/../..//input";
                //}
                //else
                //{
                //    xpath = $"//label[text()='{fieldName}']/../..//textarea";
                //}

                //driver.SendKeys(By.XPath(xpath), text); // Ты не поверишь, как и во втором варианте - эта дура смотрит только 2 вариант


                // 4 вариант
                //string xpath1 = $"//input[@placeholder='{fieldName}']";
                //string xpath2 = $"//label[text()='{fieldName}']/../..//input";
                //string xpath3 = $"//label[text()='{fieldName}']/../..//textarea";

                //string finalXpath;

                //if (driver.driver.FindElements(By.XPath(xpath1)).Count > 0)
                //{
                //    finalXpath = xpath1;
                //}
                //else if (driver.driver.FindElements(By.XPath(xpath2)).Count > 0)
                //{
                //    finalXpath = xpath2;
                //}
                //else if (driver.driver.FindElements(By.XPath(xpath3)).Count > 0)
                //{
                //    finalXpath = xpath3;
                //}
                //else
                //{
                //    throw new Exception($" Поле '{fieldName}' не найдено!");
                //}

                //driver.SendKeys(By.XPath(finalXpath), text);

                // switch enum 5 вариант
                // Пошел я нахер говорит мне этот код тоже, опять он не видит поля
                //string xpath1 = $"//input[@placeholder='{fieldName}']";
                //string xpath2 = $"//label[text()='{fieldName}']/../..//input";
                //string xpath3 = $"//label[text()='{fieldName}']/../..//textarea";

                //FieldType fieldType;

                //switch (true)
                //{
                //    case bool _ when driver.driver.FindElements(By.XPath(xpath1)).Count > 0:
                //        fieldType = FieldType.Input;
                //        break;

                //    case bool _ when driver.driver.FindElements(By.XPath(xpath2)).Count > 0:
                //        fieldType = FieldType.LabelInput;
                //        break;

                //    case bool _ when driver.driver.FindElements(By.XPath(xpath3)).Count > 0:
                //        fieldType = FieldType.Textarea;
                //        break;

                //    default:
                //        throw new Exception($"Поле '{fieldName}' не найдено!");
                //}

                //string finalXpath = fieldType switch
                //{
                //    FieldType.Input => xpath1,
                //    FieldType.LabelInput => xpath2,
                //    FieldType.Textarea => xpath3,
                //    _ => throw new Exception($"Неизвестный тип поля '{fieldName}'")
                //};

                //IWebElement inputField = driver.GetElement(By.XPath(finalXpath));

                //inputField.SendKeys(text);
            }, $"Заполнение поля {fieldName} значением {text}");
        }

        public void Fill_FieldByLabel(string fieldName, string text)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                string xpath = $"//label[text()='{fieldName}']/../..//input";
                IWebElement inputField = driver.GetElement(By.XPath(xpath));
                inputField.Click();
                inputField.SendKeys(Keys.Control + "a");
                inputField.SendKeys(Keys.Delete);
                //   inputField.Clear();
                //   inputField.SendKeys(Keys.Clear);
                driver.SendKeys(By.XPath(xpath), text);

                //   driver.SendKeys(By.XPath("//label[text()='Notes']/../..//textarea[@placeholder='Type here']"), text);
            }, $"Заполнение поля {fieldName} значением {text}");
        }

        public void Fill_FieldByLabelAndTextarea(string fieldName, string text)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                string xpath = "//label[text()='Notes']/../..//textarea[@placeholder='Type here']";
                IWebElement inputField = driver.GetElement(By.XPath(xpath));
                inputField.Clear();
                driver.SendKeys(By.XPath(xpath), text);
            }, $"Заполнение поля {fieldName} значением {text}");
        }

        public void SelectMenu(string menuName)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Click(By.XPath($"//span[text()='{menuName}']"));
            }, $"Переход к вкладке {menuName}");            
        }

        public void SelectTopbarMenu(string menuName)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Click(By.XPath($"//nav//a[text()='{menuName}']"));
            }, $"Выбор вкладки меню {menuName}");
        }

        public void ErrorMessage(string fieldName, string message) // Проверка, что в поле вышло сообщение о том, что оно не заполнено
        {
            AllureLifecycle.Instance.WrapInStep(() => 
            {
                //string xpath1 = $"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']";
                //string xpath2 = $"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='{message}']";
                
                //// Почему через два драйвера? Потому что, мой метод нельзя преобразовать в bool, поэтому перетянул базовый метод
                //bool hasNotLabel = driver.driver.FindElements(By.XPath(xpath1)).Count > 0; // Убеждаемся, что отображается элемент

                //string finalXpath = hasNotLabel ? xpath1 : xpath2; // Тернарный оператор

                //driver.WaitUntilElementVisible(By.XPath(finalXpath)); // Метод ожидания отображения

                //IWebElement errorMessage = driver.GetElement(By.XPath(finalXpath)); // Обращаемся к элементу errorMessage по нашему finalXpath

                //Assert.IsTrue(errorMessage.Displayed);

                string xpath;
                bool hasNotLabel = driver.driver.FindElements(By.XPath($"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']")).Count > 0;
                bool hasLabel = driver.driver.FindElements(By.XPath($"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='{message}']")).Count > 0;

                if (hasNotLabel) // Проверяем два разных пути
                {
                    xpath = $"//input[@placeholder= '{fieldName}']/../..//span[text()='{message}']"; // Тут поле где наименование внутри поля
                }
                else if (hasLabel)
                {
                    xpath = $"//label[text()= '{fieldName}']/../..//input[@placeholder='Type here']/../..//span[text()='{message}']"; // Тут путь, где наименование над полем
                }
                else
                {
                    xpath = $"//label[text()= '{fieldName}']/../..//span[text()='{message}']";
                }

                driver.WaitUntilElementVisible(By.XPath(xpath));

                IWebElement errorMessage = driver.GetElement(By.XPath(xpath));

                Assert.IsTrue(errorMessage.Displayed);
            }, $"Отображение ошибки {message} в поле {fieldName}" );
        }

        public void Message_Succesfully(string messageValue)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                string xpath = $"//p[text()='{messageValue}']";

                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                //IWebElement succesMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath))); 

                //Assert.IsTrue(succesMessage.Displayed);

                driver.WaitUntilElementVisible(By.XPath(xpath));
            }, $"Успешно: {messageValue}");
        }

        public void Assert_HasRecord(string recordName)
        { 
             AllureLifecycle.Instance.WrapInStep(() => 
             { 
                driver.WaitUntilElementVisible(By.XPath($"//div[contains(text(), '{recordName}')]"));
             }, $"Проверка отображения элемента: {recordName}");
        }

        public void Press_DeleteButton(string recordName)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Click(By.XPath($"//div[contains(text(), '{recordName}')]/../../../..//button//i[contains(@class, 'trash')]"));
            }, $"Нажатие на иконку удаления для записи {recordName}");
        }

        public void Select_DropDownRecord(string fieldName, string recordName)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Click(By.XPath($"//label[contains(text(), '{fieldName}')]/../..//div[contains(@class, 'oxd-select-text--after')]"));
                driver.Click(By.XPath($"//div[contains(@class, 'oxd-select-dropdown --positon-bottom')]//div//span[contains(text(), '{recordName}')]"));
            }, $"Выбор записи {recordName} в выпадающем списке");  
        }

        public void ActivateCheckbox(string checkboxName)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                driver.Click(By.XPath($"//label[text()='{checkboxName}']/../..//input/..//span"));
            }, $"Установка флажка у поля чекбокса {checkboxName}");
        }
    }
}