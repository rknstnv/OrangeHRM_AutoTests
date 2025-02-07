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
               page.Fill_Field("", Utilities.login);
               page.Fill_Field("", Utilities.password);
               page.Press_Button(" Login ");
         //   Click(By.XPath("//div[text()=' Login ']"));
        }
    }
}
