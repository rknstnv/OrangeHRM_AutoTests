using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages
{
    public class RecruitmentPage : BaseDriver
    {
        public WebPage page;

        public RecruitmentPage()
        {
            page = new WebPage();
            EnsureLoggedIn();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Quiet();
        }

        private void EnsureLoggedIn()
        {
            GoToUrl();

            //  Проверяем, авторизован ли пользователь (например, поиск элемента в меню)
            bool isLoggedIn = driver.FindElements(By.XPath("//span[text()='Dashboard']")).Count > 0;

            if (!isLoggedIn) // Если не залогинен – вводим логин и пароль
            {
                Console.WriteLine("Пользователь не авторизован. Выполняем вход...");
                page.Fill_Field("Username", Utilities.login);
                page.Fill_Field("Password", Utilities.password);
                page.Press_Button("Login");

                // ⏳ Ждём загрузку страницы после логина
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.XPath("//span[text()='Dashboard']")));
            }
            else
            {
                Console.WriteLine("Пользователь уже авторизован.");
            }
        }

    }
}
