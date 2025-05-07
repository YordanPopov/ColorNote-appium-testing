using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace ColorNoteTests.Pages
{
	public class MainPage : BasePage
	{
		public MainPage(AndroidDriver driver) : base(driver) { }

		private By addButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1");

		private By noteButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")");

		private By checklistButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Checklist\")");

		private By noteLocator = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title");

		public ReadOnlyCollection<AppiumElement> Notes => _driver.FindElements(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));

		public void OpenNote()
		{
			ClickElement(addButton);
			ClickElement(noteButton);
		}

		public void OpenChecklist()
		{
			ClickElement(addButton);
			ClickElement(checklistButton);
		}

		public ReadOnlyCollection<IWebElement> WaitForCreatedNote()
		{
			return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(noteLocator));
		}
	}
}
