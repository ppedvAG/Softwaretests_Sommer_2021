using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Blumenklavier.UI.WPF.Tests
{
    [TestClass]
    public class BlumenViewTest
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WpfAppId = @"C:\Users\Fred\source\repos\ppedvAG\Softwaretests_Sommer_2021\ppedv.Blumenklavier\ppedv.Blumenklavier.UI.WPF\bin\Debug\net5.0-windows\ppedv.Blumenklavier.UI.WPF.exe";

        protected static WindowsDriver<WindowsElement> session;


        public BlumenViewTest()
        {
            if (session == null)
            {
                var appiumOptions = new AppiumOptions();
                
                appiumOptions.AddAdditionalCapability("app", WpfAppId);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
            }
        }

        [TestMethod]
        public void BlumenView_click_SetRedButton_should_set_Farbe_to_red()
        {
            session.FindElementByAccessibilityId("SetRedButton").Click();

            var farbTxt = session.FindElementByAccessibilityId("ColorTextBox");
            
            Assert.AreEqual("Red", farbTxt.Text);
        }


    }
}
