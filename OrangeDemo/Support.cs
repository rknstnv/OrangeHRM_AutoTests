using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeDemo.UiElemenets;
using OrangeDemo.UiTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OrangeDemo
{
    public class Support
    {
        public BaseDriver Driver { get; private set; }

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            Driver = new BaseDriver();
            LogIn();
        }
       
        [OneTimeTearDown]
        public void Quiet()
        {
            Driver.Quiet();
        }

        private void LogIn()
        {
            Driver.GoToUrl("auth/login");

         //   Driver.SendKeys(By.XPath("//input[@placeholder='Username']"), Utilities.login);
         //   Driver.SendKeys(By.XPath("//input[@placeholder='Password']"), Utilities.password);

         //   Driver.Click(By.XPath(""));

            Driver.SendKeys(By.Name("username"), Utilities.login);
            Driver.SendKeys(By.Name("password"), Utilities.password, true);
        }
    }
}
