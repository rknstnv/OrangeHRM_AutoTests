using OpenQA.Selenium;
using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiTests
{
    public class LoginFormPage : BaseDriver
    {
        public WebPage page;

        [Test]
        public void OpenLoginPage()
        {
            GoToUrl();

            SendKeys(By.XPath($"//input[@placeholder='Username']"), Utilities.login);
            SendKeys(By.XPath($"//input[@placeholder='Password']"), Utilities.password);

            Click(By.XPath($"//button[text()=' Login ']"));

            //   page.Fill_Field("Username", Utilities.login);

            //   page.Fill_Field("Password", Utilities.password);

            //   page.Press_Button(" Login ");
            Thread.Sleep(50000);

            Quiet();

           
        }
    }
}
