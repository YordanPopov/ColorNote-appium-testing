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

		private By menuButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn");

		private By deleteButton = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")");

		private By OkayConfirmButton = MobileBy.Id("android:id/button1");

		public void TapDone() => _driver.FindElement(doneButton).Click();

		public void TapEdit() => _driver.FindElement(EditButton).Click();

		public void OpenMenu() => _driver.FindElement(menuButton).Click();

		public void TapDelete() => _wait.Until(ExpectedConditions.ElementToBeClickable(deleteButton)).Click();

		public void ChooseOkay() => _wait.Until(ExpectedConditions.ElementToBeClickable(OkayConfirmButton)).Click();

		public void EnterTitle(string title)
		{
			var titleElement = _driver.FindElement(titleField);
			titleElement.Clear();
			titleElement.SendKeys(title);
		}
	}
}
