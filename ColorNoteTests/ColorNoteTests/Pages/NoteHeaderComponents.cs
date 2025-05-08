using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace ColorNoteTests.Pages
{
	public class NoteHeaderComponents : BasePage
	{
		public NoteHeaderComponents(AndroidDriver driver) : base(driver) { }

		private By titleField = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_title");

		private By doneButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn");

		private By EditButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn");

		private By deleteButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")");

		private By checkButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Check\")");

		private By uncheckButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Uncheck\")");

		private By sendButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Send\")");

		private By reminderButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Reminder\")");

		private By findButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Find\")");

		private By lockButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Lock\")");

		private By archiveButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Lock\")");

		private By menuButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn");

		private By OkayConfirmButton = MobileBy.Id("android:id/button1");

		private By cancelButton = MobileBy.Id("android:id/button2");

		public void TapDone() => ClickElement(doneButton);

		public void TapEdit() => ClickElement(EditButton);

		public void OpenMenu() => ClickElement(menuButton);

		public void TapDelete() => ClickElement(deleteButton);

		public void ChooseOkay() => ClickElement(OkayConfirmButton);

		public void ChooseCancel() => ClickElement(cancelButton);

		public void CheckNote() => ClickElement(checkButton);

		public void UncheckNote() => ClickElement(uncheckButton);

		public void EnterTitle(string title)
		{
			EnterText(titleField, title);
		}
	}
}
