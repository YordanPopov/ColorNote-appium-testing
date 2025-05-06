using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace ColorNoteTests.Pages
{
	public class NotePage : BasePage
	{
		public NotePage(AndroidDriver driver) : base(driver) { }

		private By titleField = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_title");

		private By textField = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note");

		private By doneButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn");

		private By noteLocator = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title");

		private By EditButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn");

		private By menuButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn");

		private By deleteButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")");

		private By OkayConfirmButton = MobileBy.Id("android:id/button1");

		public ReadOnlyCollection<AppiumElement> Notes => _driver.FindElements(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title"));

		public AppiumElement ViewNote => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/view_note"));

		public void CreateNote(string title, string content)
		{
			EnterText(titleField, title);
			EnterText(textField, content);
			ClickElement(doneButton);
			ClickElement(doneButton);
		}

		public void EditNote(string newTitle, string newContent)
		{
			ClickElement(EditButton);

			EnterText(titleField, newTitle);
			EnterText(textField, newContent);

			ClickElement(doneButton);
			ClickElement(doneButton);
		}

		public void DeleteNote()
		{
			ClickElement(menuButton);
			ClickElement(deleteButton);
			ClickElement(OkayConfirmButton);
		}

		public ReadOnlyCollection<IWebElement> WaitForLastCreatedNote()
		{
			return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(noteLocator));
		}
	}
}
