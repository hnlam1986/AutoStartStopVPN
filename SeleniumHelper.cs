using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoStartStopVPN
{
    public class SeleniumHelper
    {
        public IWebDriver WebDriver { get; set; }
        //public static void WaitForElementToBeClickable(IWebDriver driver, By by, int timeoutInSeconds = 10)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        //}

        //public static void WaitForElementToBeVisible(IWebDriver driver, By by, int timeoutInSeconds = 10)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        //}

        public void SetTextbox(string cssSelector, string text, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement textbox = wait.Until(d => d.FindElement(By.CssSelector(cssSelector)));
            textbox.Clear();
            textbox.SendKeys(text);
        }

        public void ClickToElement(string cssSelector, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement element = wait.Until(d => d.FindElement(By.CssSelector(cssSelector)));
            element.Click();
        }

        public void LaunchToURL(string url, int timeoutInSeconds = 30)
        {
            WebDriver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                try
                {
                    string readyState = ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString();
                    return readyState == "complete";
                }
                catch (WebDriverException)
                {
                    // Handles edge cases if the browser is mid-navigation or reloading
                    return false;
                }
            });
        }

        public void WaitForPageLoad(int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d =>
            {
                try
                {
                    string readyState = ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString();
                    return readyState == "complete";
                }
                catch (WebDriverException)
                {
                    // Handles edge cases if the browser is mid-navigation or reloading
                    return false;
                }
            });
        }
    }
}
