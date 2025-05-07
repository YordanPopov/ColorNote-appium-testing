using ColorNoteTests.Helpers;
using ColorNoteTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorNoteTests.Tests
{
	public class ChecklistTests : BaseTest
	{
		private MainPage _mainPage;
		private ChecklistPage _checklistPage;
		private string lastCreatedChecklistTitle;
		string[] items =
			{
				"TEST_ITEM_1",
				"TEST_ITEM_2",
				"TEST_ITEM_3",
				"TEST_ITEM_4"
			};

		[OneTimeSetUp]
		public void PageInitialization()
		{
			_mainPage = new MainPage(_driver);
			_checklistPage = new ChecklistPage(_driver);
		}

		[Test, Order(1)]
		public void CreateChecklistSuccessfully()
		{
			lastCreatedChecklistTitle = NoteHelpers.GenerateRandomTitle();

			_mainPage.OpenChecklist();
			_checklistPage.CreateChecklist(lastCreatedChecklistTitle, items);

			var checklists = _mainPage.WaitForCreatedNote();

			Assert.Multiple(() =>
			{
				Assert.That(checklists, Is.Not.Empty);
				Assert.That(checklists.Last().Text, Is.EqualTo(lastCreatedChecklistTitle));
			});

		}

		[Test, Order(2)]
		public void EditChecklistSuccessfully()
		{
			string editedTitle = "EDITED-" + lastCreatedChecklistTitle;

			var checklist = _mainPage.Notes.First(checklist => checklist.Text == lastCreatedChecklistTitle);
			checklist.Click();

			_checklistPage.EditChecklistTitle(editedTitle);

			var editedChecklist = _mainPage.WaitForCreatedNote();

			Assert.Multiple(() =>
			{
				Assert.That(editedChecklist, Is.Not.Empty);
				Assert.That(editedChecklist.Last().Text, Is.EqualTo(editedTitle));
			});

			lastCreatedChecklistTitle = editedTitle;
		}

		[Test, Order(3)]
		public void DeleteChecklistSuccessfully()
		{
			var checklist = _mainPage.Notes.First(checklist => checklist.Text == lastCreatedChecklistTitle);
			checklist.Click();

			_checklistPage.DeleteChecklist();

			var checklistAfterDeletion = _mainPage.Notes;
			Assert.That(checklistAfterDeletion, Is.Empty);
		}
	}
}
