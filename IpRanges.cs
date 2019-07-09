namespace ExamPreparation
{
    using ExamPreparation.Pages.IpHomePage;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class IpRanges
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
        public void ExtractAllIpsInTheWorld()
        {
            var ipHomePage = new IpHomePage(_driver);
            ipHomePage.NavigateTo("http://services.ce3c.be/ciprg/");
            var othernames = ipHomePage.GetNames();
            var names = othernames.Where(x => !x.Equals(""));  

            foreach (var name in names) 
            {
                ipHomePage.SearchBox.Clear();
                ipHomePage.SearchBox.SendKeys(name);
                ipHomePage.RadioButton.Click();
                ipHomePage.Generate.Click();
                File.WriteAllText(Path.GetFullPath($@"../../../CountryIp/{name}.txt"), ipHomePage.Ips);
                ipHomePage.NavigateTo("http://services.ce3c.be/ciprg/");
            }
        }

    }
}
