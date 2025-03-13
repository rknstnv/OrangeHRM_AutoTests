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

        public void CreateRecruitment(string firstName, string lastName, string Email, string middleName = null, string contactNumber = null, string date = null, string notes = null)
        {
            OpenPage();

            SelectMenu("Recruitment");

            Press_Button("Add");

            Fill_Field("First Name", firstName);

            Fill_Field("Last Name", lastName);

         //   Fill_FieldByLabel("Email", Email);

            Fill_Field("Email", Email);

            if (!string.IsNullOrEmpty(middleName))
            {
                Fill_Field("Middle Name", middleName);
            }
            
            if(!string.IsNullOrEmpty(contactNumber))
            {
             //  Fill_FieldByLabel("Contact Number", contactNumber);
                Fill_Field("Contact Number", contactNumber);
            }
            
            if(!string.IsNullOrEmpty(date))
            {
              Fill_Field("Data", date);
            }

            if(!string.IsNullOrEmpty(notes))
            {
             //  Fill_FieldByLabel("Notes", notes);
                Fill_Field("Notes", notes);
            }
        }
    }
}
