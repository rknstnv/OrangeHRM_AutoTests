using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OrangeDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiTests
{
    public class RecruitmentPageTests : Support
    {
        string email = "test" + Utilities.GenerateNumbers(2) + "@test.com";
        string FirstName = "AvtoTest" + Utilities.GenerateLetter(3);
        string LastName = "AvtoTest" + Utilities.GenerateLetter(3);
        private RecruitmentPage page;

        public override void SetUp()
        {
            base.SetUp();
            page = new RecruitmentPage(Driver);
        }

        [Order(0)]
        [TestCase(Description = "Добавление соискателя")]
        public void Create_Recruitment()
        {
            page.CreateRecruitment(FirstName, LastName, email, middleName:Utilities.GenerateLetter(5), contactNumber:Utilities.GenerateNumbers(11), notes:Utilities.GenerateLetter(10));

            page.Press_Button("Save");

            page.Message_Succesfully("Successfully Saved");
        }

        #region Негативные

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Имя")]
        public void Fail_Create_WithoutFirstName()
        {
            page.CreateRecruitment(" ", LastName, email);

            page.Press_Button("Save");
            Thread.Sleep(5000);
            page.ErrorMessage("First Name", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Фамилия")]
        public void Fail_Create_WithoutLastName()
        {
            page.CreateRecruitment(FirstName, " ", email);

            page.Press_Button("Save");
            Thread.Sleep(5000);
            page.ErrorMessage("Last Name", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Email")]
        public void Fail_Create_WithoutEmail()
        {
            page.CreateRecruitment(FirstName, LastName, " ");

            page.Press_Button("Save");
            Thread.Sleep(5000);
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