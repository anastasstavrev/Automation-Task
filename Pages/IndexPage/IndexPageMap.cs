namespace ExamPreparation.Pages.IndexPage
{

    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class IndexPage
    {
        public List<IWebElement> CountryNames => Driver.FindElements(By.ClassName("td-country")).ToList();      
    }
}
