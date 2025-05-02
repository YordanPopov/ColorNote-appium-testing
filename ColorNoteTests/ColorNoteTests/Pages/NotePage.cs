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

		public ReadOnlyCollection<IWebElement> Notes => _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title")));

		public void CreateNote(string title, string content)
		{
			EnterText(titleField, title);
			EnterText(textField, content);
			ClickElement(doneButton);
			ClickElement(doneButton);
		}

		public ReadOnlyCollection<IWebElement> WaitForLastCreatedNote()
		{
			return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(noteLocator));
		}
	}
}
