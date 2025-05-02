using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Pages
{
	public class BasePage
	{
		protected AndroidDriver _driver;

		protected WebDriverWait _wait;

		public BasePage(AndroidDriver driver)
		{
			_driver = driver;
			_wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
		}

		public void ClickElement(By locator)
		{
			_wait.Until(ExpectedConditions.ElementToBeClickable(locator))
				.Click();
		}

		public void EnterText(By locator, string text)
		{
			var element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
			element.Clear();
			element.SendKeys(text);
		}
	}
}
