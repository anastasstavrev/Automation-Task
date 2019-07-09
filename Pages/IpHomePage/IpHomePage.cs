namespace ExamPreparation.Pages.IpHomePage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class IpHomePage : BasePage
    {
        public IpHomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public List<string> GetNames()
        {
            var list = new List<string>();
            foreach (var element in Names)
            {
                list.Add(element.Text);
            }
            return list;
        }
    }
}
