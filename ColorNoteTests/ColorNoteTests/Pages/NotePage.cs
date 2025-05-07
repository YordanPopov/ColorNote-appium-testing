using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace ColorNoteTests.Pages
{
	public class NotePage : BasePage
	{
		public NoteHeaderComponents Header { get; }

		public NotePage(AndroidDriver driver) : base(driver)
		{
			Header = new NoteHeaderComponents(driver);
		}

		private By textField = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note");

		public AppiumElement ViewNote => _driver.FindElement(MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/view_note"));

		public void CreateNote(string title, string content)
		{
			Header.EnterTitle(title);
			_driver.FindElement(textField).SendKeys(content);
			Header.TapDone();
			Header.TapDone();
		}

		public void EditNote(string newTitle, string newContent)
		{
			Header.TapEdit();

			Header.EnterTitle(newTitle);
			var content = _driver.FindElement(textField);
			content.Clear();
			content.SendKeys(newContent);

			Header.TapDone();
			Header.TapDone();	
		}

		public void DeleteNote()
		{
			Header.OpenMenu();
			Header.TapDelete();
			Header.ChooseOkay();
		}
	}
}
