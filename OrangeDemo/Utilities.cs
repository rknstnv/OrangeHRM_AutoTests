using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo
{
    public static class Utilities
    {
        public const string url = "https://opensource-demo.orangehrmlive.com/web/index.php/";
        public const string login = "Admin";
        public const string password = "admin123";

        public static string GenerateLetter(int length, bool russian = false)
        {
            string chars;

            if (russian)
                {
                    chars = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбю";
                }
            else
                {
                   chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                }
              
                Random random = new Random();
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateNumbers(int length) 
        {
            const string digits = "0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(digits, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
