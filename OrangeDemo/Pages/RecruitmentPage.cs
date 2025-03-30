using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages
{
    public class RecruitmentPage : WebPage
    {
        public RecruitmentPage(BaseDriver driver) : base("dashboard/index", driver) { }

        public void CreateRecruitment(string firstName, string lastName, string Email, string middleName = null, string vacancy = null, string contactNumber = null, string keywords = null, string date = null, string notes = null)
        {
            OpenPage();

            SelectMenu("Recruitment");

            Press_Button("Add");

            Fill_Field("First Name", firstName);

            Fill_Field("Last Name", lastName);

            Fill_FieldByLabel("Email", Email);

            if (!string.IsNullOrEmpty(middleName))
            {
                Fill_Field("Middle Name", middleName);
            }

            if (!string.IsNullOrEmpty(vacancy))
            {
                Select_DropDownRecord("Vacancy",vacancy);
            }
            
            if (!string.IsNullOrEmpty(contactNumber))
            {
                Fill_FieldByLabel("Contact Number", contactNumber);
            }
            
            if (!string.IsNullOrEmpty(keywords))
            {
                Fill_FieldByLabel("Keywords", keywords);
            }
            // Если поле изначально заполнено, но мы не всегда хотим его изменять
            if (date != null)
            {
                Fill_FieldByLabel("Date of Application", date);
            }
            // Если поле изначально не заполнено и мы хотим его заполнить
            if (!string.IsNullOrEmpty(notes))
            {
                Fill_FieldByLabelAndTextarea("Notes", notes);
            }
        }
    }
}