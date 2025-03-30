using OrangeDemo.UiElemenets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Pages.Login
{
    public class LoginPage : WebPage
    {
        public LoginPage(BaseDriver driver) : base("auth/login", driver) { }
    }
}
