using OpenQA.Selenium;
using OrangeDemo.Pages;
using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiTests
{
    public class LoginFormPage : LoginPage
    {

        [Order(0)]
        [TestCase(Description = "Логин")]
        public void OpenLoginPage()
        {
            OpenPage();

            page.Fill_Field("Username", Utilities.login);

            page.Fill_Field("Password", Utilities.password);

            page.Press_Button("Login");
        }
    }
}
