using ProjectPractice.Pupperteer.Models;
using PuppeteerSharp;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Pupperteer.Pages
{
    public class HomePage : PageObject
    {
        [Selector(".slider ul li a")]
        public virtual Task<ElementHandle[]> MovieElements { get; set; }

        public async Task<List<string>> GetMovieDataList()
        {
            var aEls = await MovieElements;
            var linkAddress = new List<string>();
            foreach (var item in aEls)
            {
                var attrVal = await item.GetAttributeAsync("href");
                linkAddress.Add(attrVal);
            }
            //var tempPage = await Page.Browser.NewPageAsync();
            //var result = new List<MovieModel>();
            //foreach (var address in linkAddress)
            //{
            //    var movie = await tempPage.GoToAsync<Movie>(address,
            //        new NavigationOptions { WaitUntil = new[] { WaitUntilNavigation.DOMContentLoaded } });
            //    var model = await movie.GetMovieInfo();
            //    result.Add(model);
            //}
            return linkAddress;
        }
    }
}
