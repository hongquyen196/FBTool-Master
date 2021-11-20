using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FBTool.Domain.Extensions
{
    public static class WebdriverExtentions
    {
        public static IWebElement Wait(this IWebDriver webDriver, By findBy, int timeout = 10)
        {
            try
            {
                return new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout)).Until(_ =>
                {
                    try
                    {
                        return _.FindElement(findBy);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}
