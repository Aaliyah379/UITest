using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITest
{
  public  class CreditCardWebAppShould
    {
        [Fact]
        [Trait("Category","Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://passport-photo.online/pl/zdjecie-do-mlegitymacji");
                string pageTitle = driver.Title;
                Assert.Equal("Zdjęcie do mLegitymacji - Passport-Photo.online", pageTitle);
            }
        }
    }

}
