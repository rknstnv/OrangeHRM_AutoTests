using NUnit.Allure.Core;
using OrangeDemo.Pages.Recruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.UiTests.Recruitment.Vacancies
{
    [Parallelizable]
    [TestFixture]
    [AllureNUnit]
    class VacanciesPageTests : Support
    {
        private RecruitmentPage page;
        string vacansyName = "AvtoTest" + Utilities.GenerateLetter(5);
        public override void SetUp()
        {
            base.SetUp();
            page = new RecruitmentPage(Driver);
        }

        [Order(0)]
        [TestCase(Description = "")]
        public void CreateVacancies()
        {
            page.CreateVacansy(vacansyName, "QA Lead");

            Thread.Sleep(5000);
        }
    }
}
