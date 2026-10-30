using AutoStartStopVPN;

args = new string[] { "start" };
SeleniumChrome chrome = new SeleniumChrome();
if (args[0] == "start")
{
    chrome.StartVPN();
}
else
{
    chrome.StopVPN();
}

