using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjectPractice.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver selenium = new ChromeDriver();

            selenium.Navigate().GoToUrl("http://www.baidu.com");
            selenium.Navigate().GoToUrl("http://www.hao123.com");
            selenium.Navigate().Back();

            Console.ReadLine();

        }
    }
}
