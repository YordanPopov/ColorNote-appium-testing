using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;

namespace ColorNoteTests.Pages
{
	public class MainPageHeaderComponents : BasePage
	{
		public MainPageHeaderComponents(AndroidDriver driver) : base(driver) { }

		private By leftMenuButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/icon_nav");

		private By addButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1");

		private By searchButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn2");

		private By rightMenuButton = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn3");

		private By searchField = MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_search");

		public void OpenRightMenu() => ClickElement(rightMenuButton);

		public void OpenLeftMenu() => ClickElement(leftMenuButton);

		public void ClickAddButton() => ClickElement(addButton);

		public void ClickSearchButton() => ClickElement(searchButton);

		public void SearchForNote(string noteTitle)
		{
			EnterText(searchField, noteTitle);
		}

	}
}
