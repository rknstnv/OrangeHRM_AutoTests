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
        string email = "test" + Utilities.GenerateNumbers(2) + "@test.com";
        string FirstName = "AvtoTest" + Utilities.GenerateLetter(3);
        string LastName = "AvtoTest" + Utilities.GenerateLetter(3);

        [Order(0)]
        [TestCase(Description = "Добавление соискателя")]
        public void Create_Recruitment()
        {
            CreateRecruitment(FirstName, LastName, email);

            page.Press_Button("Save");

            page.Message_Succesfully("Successfully Saved");
        }

        #region Негативные

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Имя")]
        public void Fail_Create_WithoutFirstName()
        {
            CreateRecruitment(FirstName = " ", LastName, email);

            page.Press_Button("Save");

            page.Message_FieldIsRequired("First Name");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Фамилия")]
        public void Fail_Create_WithoutLastName()
        {
            CreateRecruitment(FirstName, LastName = " ", email);

            page.Press_Button("Save");

            page.Message_FieldIsRequired("Last Name");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Email")]
        public void Fail_Create_WithoutEmail()
        {
            CreateRecruitment(FirstName, LastName, email = " ");

            page.Press_Button("Save");

            page.Message_FieldIsRequired("Email");
        }

        #endregion
    }
}