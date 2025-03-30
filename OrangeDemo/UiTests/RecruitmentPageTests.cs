using NUnit.Allure.Core;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OrangeDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiTests
{
    [Parallelizable]
    [TestFixture]
    [AllureNUnit]
    public class RecruitmentPageTests : Support
    {
        string Email = "test" + Utilities.GenerateNumbers(2) + "@test.com";
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
            page.CreateRecruitment(FirstName, LastName, Email, middleName:Utilities.GenerateLetter(5), vacancy:"Senior QA Lead", contactNumber:Utilities.GenerateNumbers(11), keywords:Utilities.GenerateLetter(5), date: "2025-18-02", notes:Utilities.GenerateLetter(10));

            page.Press_Button("Save");

            page.Message_Succesfully("Successfully Saved");

            page.OpenPage();

            page.SelectMenu("Recruitment");
            
            page.Assert_HasRecord(FirstName);
        }

        // Скорее всего тут о хранении персональных данных
        [Order(0)]
        [TestCase(Description = "Добавление соискателя с согласием на хранение персональных данных")] 
        public void Create_RecruitmentWithKeepData()
        {
            page.CreateRecruitment(FirstName, LastName, Email);

            page.ActivateCheckbox("Consent to keep data");

            page.Press_Button("Save");

            page.Message_Succesfully("Successfully Saved");

            page.OpenPage();

            page.SelectMenu("Recruitment");

            page.Assert_HasRecord(FirstName);
        }

        [Order(1)]
        [TestCase(Description = "Удаление соискателя")]
        public void Delete_Recruitment()
        {
            page.OpenPage();

            page.SelectMenu("Recruitment");

            page.Press_DeleteButton(FirstName);

            page.Press_Button("Yes, Delete");

            page.Message_Succesfully("Successfully Deleted");
        }

        #region Негативные

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Имя")]
        public void Fail_Create_WithoutFirstName()
        {
            page.CreateRecruitment(" ", "Testasd", Email);

            page.Press_Button("Save");

            page.ErrorMessage("First Name", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Фамилия")]
        public void Fail_Create_WithoutLastName()
        {
            page.CreateRecruitment("Testasd", " ", Email);

            page.Press_Button("Save");
 
            page.ErrorMessage("Last Name", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи без заполнения поля Email")]
        public void Fail_Create_WithoutEmail()
        {
            page.CreateRecruitment("Testasd", "TestASD", " ");
            
            page.Press_Button("Save");

            page.ErrorMessage("Email", "Required");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с масимальной длиной более 30 символов в поле Имя")]
        public void Fail_Create_LongFirstName()
        {
            page.CreateRecruitment(Utilities.GenerateLetter(31), "Testasd", Email);

            page.Press_Button("Save");

            page.ErrorMessage("First Name", "Should not exceed 30 characters");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с масимальной длиной более 30 символов в поле Фамилия")]
        public void Fail_Create_LongLastName()
        {
            page.CreateRecruitment("Testasd", Utilities.GenerateLetter(31), Email);

            page.Press_Button("Save");

            page.ErrorMessage("Last Name", "Should not exceed 30 characters");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с масимальной длиной более 30 символов в поле Отчество")]
        public void Fail_Create_LongMiddleName()
        {
            page.CreateRecruitment("Testasd", "TestASD", Email, middleName: Utilities.GenerateLetter(31));

            page.Press_Button("Save");

            page.ErrorMessage("Middle Name", "Should not exceed 30 characters");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с не валидным эмейлом")]
        public void Fail_Create_WrongEmail()
        {
            page.CreateRecruitment("Testasd", "TestASD", Utilities.GenerateLetter(5));

            page.Press_Button("Save");

            page.ErrorMessage("Email", "Expected format: admin@example.com");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с невалидным номером телефона")]
        public void Fail_Create_WrongContactNumber()
        {
            page.CreateRecruitment("Testasd", "TestASD", Email, contactNumber:Utilities.GenerateLetter(5));

            page.Press_Button("Save");

            page.ErrorMessage("Contact Number", "Allows numbers and only + - / ( )");
        }

        [Order(1)]
        [TestCase(Description = "Добавление записи с невалидной датой")]
        public void Fail_Create_WrongDateFormat()
        {
            page.CreateRecruitment("Testasd", "TestASD", Email, date: Utilities.GenerateLetter(5), notes:Utilities.GenerateLetter(5));
            // При заполнении поля даты выходит окно с календарем и перекрывает сообщение об ошибке
            // Тут я немного схитрил, вместо написания метода на снятие фокуса с поля даты, просто заполняю следующее поле
            page.Press_Button("Save");

            page.ErrorMessage("Date of Application", "Should be a valid date in yyyy-dd-mm format");
        }

        #endregion

    }
}