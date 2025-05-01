using ColorNoteTests.Drivers;
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
