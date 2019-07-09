namespace ExamPreparation.Pages.CountryPage
{
    using OpenQA.Selenium;
    using System.Linq;

    public partial class CountryPage
    {
        public IWebElement Name => Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[2]"));

        public IWebElement Capital => Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[3]"));

        public IWebElement Content => Driver.FindElement(By.Id("content"));

        public IWebElement Code => Content.FindElements(By.TagName("em")).ToList().Last();


    }
}
