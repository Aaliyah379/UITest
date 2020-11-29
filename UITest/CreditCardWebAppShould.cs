using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITest
{
    public class CreditCardWebAppShould

    {
        private const string homeUrl = "https://passport-photo.online/en-gb";
        private const string AboutUrl = "https://passport-photo.online/en-gb/contact/";
        private const string homeTitle = "Passport and Visa photos online - Passport-Photo.online";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(homeUrl);
                DemoHelper.Pause();

                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeUrl, driver.Url);
            }
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void reloadPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(homeUrl);

                DemoHelper.Pause();
                driver.Navigate().Refresh();

                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeUrl, driver.Url);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //driver.Navigate().GoToUrl(homeUrl);
                //DemoHelper.Pause();
                //driver.Navigate().GoToUrl(AboutUrl);
                //DemoHelper.Pause();
                //driver.Navigate().Back();
                //DemoHelper.Pause();

                //Assert.Equal(homeTitle, driver.Title);
                //Assert.Equal(homeUrl, driver.Url);

                driver.Navigate().GoToUrl("https://passport-photo.online/en-gb/uk-linkedin-photo");
                var addFile = driver.FindElement(By.Id("upload-form-file-input"));
                addFile.SendKeys(@"C:\Users\robby\Desktop\Game of Thrones\228408_600.jpg");


                //TODO: assert that page was reloaded
            }
        }
    }
}
