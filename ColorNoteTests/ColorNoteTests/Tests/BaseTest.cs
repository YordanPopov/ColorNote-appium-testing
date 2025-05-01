using ColorNoteTests.Drivers;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
