using ColorNoteTests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ColorNoteTests.Tests
{
	public class BaseTest
	{
		protected AndroidDriver _driver;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			_driver = DriverFactory.CreateAndroidDriver();

			try
			{
				var skipButton = _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip"));
				skipButton.Click();
			}
			catch (NoSuchElementException)
			{
				Assert.Pass("Skip button not found!");
			}
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			_driver.Quit();
			_driver.Dispose();
			DriverFactory.StopService();
		}
	}
}
