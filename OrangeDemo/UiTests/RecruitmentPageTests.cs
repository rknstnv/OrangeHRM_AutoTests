using OrangeDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiTests
{
    public class RecruitmentPageTests : RecruitmentPage
    {
        string email = "test@test.com";

        [Order(0)]
        [TestCase(Description = "Добавление соискателя")]
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
