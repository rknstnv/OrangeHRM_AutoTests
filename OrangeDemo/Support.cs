using OpenQA.Selenium;
using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo
{
    public class Support
    {
        public BaseDriver Driver { get; private set; } // Тут приват на сете, означает что передать значение можем только тут, а тянуть можем куда хотим

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            Driver = new BaseDriver();
            login();
        }
        public void login()
        {
            Driver.GoToUrl(); // Переиди по юрл, переменную юрл задали в бейсдрайвере, а он в свою очередь тянет инфу с utilities 

            Driver.SendKeys(By.Name("username"), Utilities.login); // Введи в поле такие то данные, найденные в utilities
            Driver.SendKeys(By.Name("password"), Utilities.password, true);
        }

        [OneTimeTearDown]
        public void Quiet()
        {
            Driver.Quiet();
        }
    }
}
