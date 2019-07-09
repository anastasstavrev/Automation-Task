namespace ExamPreparation.Pages.IpHomePage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class IpHomePage
    {
        public IWebElement Body => Driver.FindElement(By.XPath("/html/body/table/tbody"));

        public List<IWebElement> Names => Body.FindElements(By.TagName("a")).ToList();

        public IWebElement SearchBox => Driver.FindElement(By.XPath("/html/body/form/input[1]")); // ili s name tag

        public IWebElement RadioButton => Driver.FindElement(By.XPath("/html/body/form/input[3]"));

        public IWebElement Generate => Driver.FindElement(By.XPath("/html/body/form/input[5]"));

        public string Ips => Driver.FindElement(By.XPath("/html/body/pre")).Text; 
    }
}
