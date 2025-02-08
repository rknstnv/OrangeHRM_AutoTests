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

        public LoginFormPage()
        {
            page = new WebPage();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Quiet();
        }

        [Order(0)]
        [TestCase(Description = "Логин")]
        public void OpenLoginPage()
        {
            GoToUrl();

               page.Fill_Field("Username", Utilities.login);

               page.Fill_Field("Password", Utilities.password);

               page.Press_Button(" Login ");

        }
    }
}
