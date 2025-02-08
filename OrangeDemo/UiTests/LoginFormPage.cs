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
        string email = "test@test.com";

        [Order(0)]
        [TestCase(Description = "Логин")]
        public void OpenLoginPage()
        {
            page.OpenPage();

            page.Fill_Field("Username", Utilities.login);

            page.Fill_Field("Password", Utilities.password);

            page.Press_Button("Login");
        }

        [Order(1)]
        [TestCase(Description = " ")]
        public void Create_Recruitment()
        {
            page.OpenPage("dashboard/index");

            page.SelectMenu("Recruitment");

            page.Press_Button("Add");

            page.Fill_Field("First Name", "Avtotest" + Utilities.GenerateLetter(3));

            page.Fill_Field("Last Name", "Avtotest" + Utilities.GenerateLetter(3));

            page.Fill_FieldByLabel("Email", email);

            page.Press_Button("Save");
        }
    }
}
