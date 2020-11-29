using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITest
{
    public class CreditCardWebAppShould

    {
        private const string homeUrl = "https://passport-photo.online/pl/zdjecie-do-mlegitymacji";
        private const string homeTitle = "Zdjęcie do mLegitymacji - Passport-Photo.online";


        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
          
            using (IWebDriver driver = new ChromeDriver())
            {
                
                driver.Navigate().GoToUrl(homeUrl);

                DemoHelper.Pause();

                Assert.Equal( homeTitle,driver.Title);
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
    }
}
