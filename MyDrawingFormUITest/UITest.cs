using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms.VisualStyles;

namespace MyDrawingFormUITest
{
    public class UITest
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        public UITest(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        //test
        public void AssertSelected(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Selected);
        }

        public void AssertChecked(string controlName, bool state)
        {
            var control = _driver.FindElementByName(controlName);
            string toggleState = control.GetAttribute("Toggle.ToggleState");
            bool isChecked;
            if (bool.TryParse(toggleState, out isChecked))
            {
                Assert.AreEqual(state, isChecked);
            }
        }

        public void MouseClickAndHold(int x1, int y1, int x2, int y2)
        {
            var panel = _driver.FindElementByName("drawPanel");
            var action = new Actions(_driver);
            action.MoveToElement(panel, x1, y1).ClickAndHold().MoveByOffset(x2, y2).Release().Perform();
        }

        public void MouseMove(int x, int y)
        {
            var panel = _driver.FindElementByName("drawPanel");
            var action = new Actions(_driver);
            action.MoveToElement(panel, x, y).Perform();
        }

        public void EnterTextBox(string name, string text)
        {
            var textBox = _driver.FindElementByName(name);
            textBox.Clear();
            textBox.SendKeys(text);
        }

        public void EnterComboBox(string name, string text)
        {
            ClickButton("開啟");
            WindowsElement element = _driver.FindElementByName(name);
            element.FindElementByName(text).Click();
        }

        public void ClickAt(string name, int x, int y)
        {
            WindowsElement element = _driver.FindElementByName(name);
            new Actions(_driver)
                .MoveToElement(element, x, y)
                .Click()
                .Perform();
        }


        public void ClickRemoveDataGridViewRow(string name, int rowIndex)
        {
            var dataGridView = _driver.FindElementByName(name);
            var row = dataGridView.FindElementByName($"資料列 {rowIndex}");
            row.FindElementByName($"刪除 資料列 {rowIndex}").Click();
        }
    }
}
