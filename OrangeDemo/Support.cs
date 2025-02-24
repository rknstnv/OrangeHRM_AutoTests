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
        public BaseDriver Driver { get; private set; }

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            Driver = new BaseDriver();
            login();
        }
        public void login()
        {
            Driver.GoToUrl();

            Driver.SendKeys(By.Name("username"), Utilities.login); 
            Driver.SendKeys(By.Name("password"), Utilities.password, true);
        }

        [OneTimeTearDown]
        public void Quiet()
        {
            Driver.Quiet();
        }
    }
}
