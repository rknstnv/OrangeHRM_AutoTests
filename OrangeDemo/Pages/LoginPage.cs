using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages
{
    public class LoginPage : BaseDriver
    {
        public WebPage page;

        public LoginPage()
        {
            page = new WebPage();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Quiet();
        }
    }
}
