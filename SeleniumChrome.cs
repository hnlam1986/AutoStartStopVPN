using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutoStartStopVPN
{
    public class SeleniumChrome : SeleniumHelper
    {
        public SeleniumChrome()
        {
            
        }
        public void StartVPN()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--disable-web-security");
            using (IWebDriver driver = new ChromeDriver(options))
            {
                string url = "https://192.168.1.8:8443/Main_Login.asp";
                WebDriver = driver;
                LaunchToURL(url);
                SetTextbox("#login_username", "admin");
                SetTextbox("input[name='login_passwd']", "P@ssw0rd");
                ClickToElement("#login_filed div.button");
                WaitForPageLoad();
                Console.WriteLine("VPN started successfully.");
            }
        }
        public void StopVPN()
        {
        }
    }
}
