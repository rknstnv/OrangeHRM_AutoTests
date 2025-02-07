using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Lesson
{
    public class Tests
    {
        IWebDriver driver;  //Инцеализация драйвера

        [OneTimeSetUp] //Действия перед тестами
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; //Установка пути к браузеру
            driver = new ChromeDriver(path + @"\drivers\"); //Путь до папки
        }

        [OneTimeTearDown]//Действия после тестов
        public void TearDown()
        {
            driver.Quit(); //Закрытие браузера
        }

        [Test] //атрибут указывающий что это тест
        public void verifyLogo()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.Id("logo")).Displayed); //Нахождение елемента по id

        }

        [Test] //атрибут указывающий что это тест
        public void verifyLogoCss()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.CssSelector(".dashboard-item-title")).Displayed); //Нахождение елемента по css

        }
         
        [Test] //атрибут указывающий что это тест
        public void verifyLogoClassName()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.ClassName("dashboard-item-title")).Displayed); //Нахождение елемента по класу 
        }

        [Test] //атрибут указывающий что это тест
        public void verifyLogoLinkText()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.LinkText("Не можете попасть в систему?")).Displayed); //Нахождение елемента по тексту с линком

        }

        [Test] //атрибут указывающий что это тест
        public void verifyLogoPartialLinkText()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.PartialLinkText("Не можете")).Displayed); //Нахождение елемента по части текста с линком

        }

        [Test] //атрибут указывающий что это тест
        public void verifyByName()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.Name("login")).Displayed); //Нахождение елемента по name

        }

        [Test] //атрибут указывающий что это тест
        public void verifyByTagName()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.TagName("a")).Displayed); //Нахождение елемента по тегу

        }

        [Test] //атрибут указывающий что это тест
        public void verifyLogoXpath()
        {
            driver.Navigate().GoToUrl("https://jira.bars.group/"); //Переход на джиру

            Assert.IsTrue(driver.FindElement(By.XPath("//a[text() = 'Не можете попасть в систему?']")).Displayed); //Нахождение елемента по xpath

        }
    }

}