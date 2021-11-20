using FBTool.BLL.Interface.Facebook;
using FBTool.Domain.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;

namespace FBTool.BLL.Implement.Facebook
{
    public class FacebookBussiness : IFacebookBussiness
    {
        private IWebDriver _webDriver;
        private string _profilePath;
        private string _profile;
        private bool _headless;

        public FacebookBussiness()
        {
        }

        public void ChromeProfile(string path, string name, bool headless)
        {
            _profilePath = path;
            _profile = name;
            _headless = headless;
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("user-data-dir=" + _profilePath);
            options.AddArgument("profile-directory=" + _profile);
            options.AddArgument("start-maximized");
            if (_headless)
            {
                options.AddArgument("--headless");
            }
            _webDriver = new ChromeDriver(chromeDriverService, options);
        }
        
        public void Close()
        {
            _webDriver.Quit();
        }

        public void Login(FacebookAccount facebookAccount)
        {
            //_webDriver.Url = FacebookURL.LOGIN_URL;
            //_webDriver.Wait(By.Id("input[name=email]"))?.SendKeys(facebookAccount.Username);
            //_webDriver.Wait(By.CssSelector("input[name=pass]"))?.SendKeys(facebookAccount.Password);
            //_webDriver.Wait(By.CssSelector("input[name=login]"))?.Click();
        }

        [Obsolete]
        public void ReviewsPage(string page, string text, string photo)
        {
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60));
                var reviewsURL = page + "/reviews";

                _webDriver.Navigate().GoToUrl(reviewsURL);

                var buttonYes = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()=\"Yes\"]")));
                buttonYes.Click();

                var editorBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@aria-label, \"What do you recommend about\")]")));
                editorBox.SendKeys(text);

                var buttonPost = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()=\"Post\"]")));
                buttonPost.Click();

                //Refrest page to get reviews
                _webDriver.Navigate().Refresh();

                if (!string.IsNullOrEmpty(photo))
                {
                    var actions = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label=\"Actions for this post\"]")));
                    actions.Click();

                    var editPost = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()=\"Edit post\"]")));
                    editPost.Click();

                    var attachment = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label=\"Photo/Video\"]")));
                    attachment.Click();

                    var addAttachment = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@accept, \"image/*\")]")));
                    addAttachment.SendKeys(photo);

                    var buttonSave = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()=\"Save\"]")));
                    buttonSave.Click();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
