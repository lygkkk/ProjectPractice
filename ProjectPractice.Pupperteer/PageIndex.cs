using ProjectPractice.Pupperteer.Pages;
using PuppeteerSharp;
using PuppeteerSharp.Contrib.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Pupperteer
{
    public class PageIndex
    {
        private static string _url = "https://www.xl720.com/";
        private static string _chromePath = @"C:\Program Files (x86)\Google\Chrome\chrome.exe";

        public static async Task<bool> Start()
        {
            var page = await CreatePage();
            var home = await page.GoToAsync<HomePage>(_url, new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.Networkidle2 } });
            var result = await home.GetMovieDataList();
            return true;
        }

        private static async Task<Page> CreatePage()
        {
            var broswer = await Puppeteer.LaunchAsync(new LaunchOptions()
            {
                DefaultViewport = new ViewPortOptions { Width = 1200, Height = 800 },
                ExecutablePath = _chromePath,
                Headless = false
            });

            var page = (await broswer.PagesAsync()).FirstOrDefault();
            page.DefaultNavigationTimeout = 300000;
            page.DefaultTimeout = 300000;
            return page;
        }
    }
}
