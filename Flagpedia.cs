namespace ExamPreparation
{
    using ExamPreparation.Pages.CountryPage;
    using ExamPreparation.Pages.IndexPage;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class Flagpedia
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void ExtractAllFlagsInTheWorld()
        {
            var indexPage = new IndexPage(_driver);
            var countryPage = new CountryPage(_driver); 
            indexPage.NavigateTo("http://flagpedia.net/index");

            var countryNames = indexPage.GetNames(); 
            //List<string> listOfNames = new List<string>(); --> po lesen variant bez 2ri foreach samo s 1 foreach, i NOV URL za vsqka dyrjava
            foreach (var element in countryNames)
            {
                //listOfNames.Add(element.Text);
                string url = "http://flagpedia.net/" + element.ToLower(); 
                countryPage.NavigateTo(url);
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(2000);
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(Path.GetFullPath(@"../../../Screenshots/") + BuildName(countryPage) + ".png", ScreenshotImageFormat.Png);
            }
        }

        private string BuildName(CountryPage page)
        {
            return $"{ page.Name.Text}-{ page.Capital.Text}-{ page.Capital.Text}";
        }

    }
}
