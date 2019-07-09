namespace ExamPreparation.Pages
{
    using OpenQA.Selenium;

    public class BasePage
    {
        public IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string url)
        {
            if (url.Contains(" ") || url.Contains("'"))
            {
                url = url.Replace(" ", "-");
                url = url.Replace("'", "-");
            }

            this.Driver.Url = url;
        }

    }
}
