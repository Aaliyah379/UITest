using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITest
{
    using System;
    using System.Diagnostics;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.Events;
    using Xunit.Abstractions;

    public class CreditCardWebAppShould
    {
        private readonly ITestOutputHelper _output;
        private const string homeUrl = "https://passport-photo.online/en-gb";
        private const string AboutUrl = "https://passport-photo.online/en-gb/contact/";
        private const string homeTitle = "Passport and Visa photos online - Passport-Photo.online";

        private const string YURII_PHOTO = @"C:\Users\Yurii\Pictures\test\Julia-Roberts-Natural-Hair-Color.jpg";
        private const string AALIYAH_PHOTO = @"C:\Users\robby\Desktop\Game of Thrones\228408_600.jpg";

        private int navigationCount = 0; 

        public CreditCardWebAppShould(ITestOutputHelper output)
        {
            _output = output;
        }
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
                driver.Navigate().GoToUrl(homeUrl);
                DemoHelper.Pause();
                driver.Navigate().GoToUrl(AboutUrl);
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();

                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeUrl, driver.Url);
                //TODO: assert that page was reloaded
            }
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageOnForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(AboutUrl);
                DemoHelper.Pause();
                driver.Navigate().GoToUrl(homeUrl);
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();
                driver.Navigate().Forward();
                DemoHelper.Pause();

                Assert.Equal(homeTitle, driver.Title);
                Assert.Equal(homeUrl, driver.Url);

                //TODO: assert that page was reloaded
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void UserShouldBeAbleToUploadPhoto()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://passport-photo.online/pl/zdjecie-do-mlegitymacji");
                var addFile = driver.FindElement(By.Id("upload-form-file-input"));

                Assert.NotNull(addFile);

                addFile.SendKeys(YURII_PHOTO);
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ShowLoadingTimeAndNavigationCountWhileUploadingImage()
        {
            Stopwatch stopWatch = new Stopwatch();

            using (IWebDriver driver = new ChromeDriver())
            {
                var firingDriver = new EventFiringWebDriver(driver);
                navigationCount = 0;

                firingDriver.Navigating += FiringDriver_Navigated;

                firingDriver.Navigate().GoToUrl("https://passport-photo.online/pl/zdjecie-do-mlegitymacji");
                var addFile = firingDriver.FindElement(By.Id("upload-form-file-input"));

                stopWatch.Start();
                addFile.SendKeys(YURII_PHOTO);
                stopWatch.Stop();
            }

            _output.WriteLine(stopWatch.Elapsed.ToString());
            _output.WriteLine($"Navigation was called {navigationCount} times");
        }

        private void FiringDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            navigationCount++;
        }
    }
}
