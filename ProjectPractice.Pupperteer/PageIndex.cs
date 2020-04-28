using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Pupperteer
{
    public class PageIndex
    {
        private static string _url = "https://movie.douban.com/";
        private static string _chromePath = @"C:\Program Files (x86)\Google\Chrome\chrome.exe";

        public static async void Start()
        {
            var page = await CreatePage();
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
