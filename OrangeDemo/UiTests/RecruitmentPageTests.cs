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

            page.ErrorMessage("First Name", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Фамилия")]
        public void Fail_Create_WithoutLastName()
        {
            CreateRecruitment(FirstName, LastName = " ", email);

            page.Press_Button("Save");

            page.ErrorMessage("Last Name", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Email")]
        public void Fail_Create_WithoutEmail()
        {
            CreateRecruitment(FirstName, LastName, email = " ");

            page.Press_Button("Save");

            page.ErrorMessage("Email", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с масимальной длиной более 30 символов в поле Имя")]
        public void Fail_Create_LongFirstName()
        {

        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с масимальной длиной более 30 символов в поле Фамилия")]
        public void Fail_Create_LongLastName()
        {

        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с масимальной длиной более 30 символов в поле Отчество")]
        public void Fail_Create_LongMiddleName()
        {

        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с не валидным эмейлом")]
        public void Fail_Create_WrongEmail()
        {

        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с невалидным номером телефона")]
        public void Fail_Create_WrongContactNumber()
        {

        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с невалидной датой")]
        public void Fail_Create_WrongDateFormat()
        {

        }

        #endregion
    }
}