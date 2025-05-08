using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;

namespace ColorNoteTests.Pages
{
	public class ChecklistPage : BasePage
	{
		public NoteHeaderComponents Header { get; }
		public ChecklistPage(AndroidDriver driver) : base(driver)
		{
			Header = new NoteHeaderComponents(driver);
		}

		private By addFirstItemElement = MobileBy.AndroidUIAutomator("new UiSelector().resourceId(\"com.socialnmobile.dictapps.notepad.color.note:id/text\").instance(0)");

		private By addNextItemElement = MobileBy.AndroidUIAutomator("new UiSelector().text(\"Add Item\").instance(1)");

		private By textField = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit");

		private By okayBtn = MobileBy.Id("android:id/button1");

		public void CreateChecklist(string title, string[] items)
		{
			Header.EnterTitle(title);

			for (int i = 0; i < items.Length; i++)
			{
				string currentItem = items[i];
				if (i == 0)
				{
					ClickElement(addFirstItemElement);
				}
				else
				{
					ClickElement(addNextItemElement);
				}

				EnterText(textField, currentItem);
				ClickElement(okayBtn);
			}

			Header.TapDone();
			Header.TapDone();
		}

		public void EditChecklistTitle(string newTitle)
		{
			Header.TapEdit();
			Header.EnterTitle(newTitle);
			Header.TapDone();
			Header.TapDone();
		}

		public void DeleteChecklist()
		{
			Header.OpenMenu();
			Header.TapDelete();
			Header.ChooseOkay();
		}
	}
}
