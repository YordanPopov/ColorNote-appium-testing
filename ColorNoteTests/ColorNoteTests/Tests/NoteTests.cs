using ColorNoteTests.Helpers;
using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium;

namespace ColorNoteTests.Tests
{
	public class NoteTests : BaseTest
	{
		private MainPage _mainPage;
		private NotePage _notePage;
		private string lastCreatedNoteTitle;
		private string lastCreatedNoteContent;

		[OneTimeSetUp]
		public void PageInitialization()
		{
			_mainPage = new MainPage(_driver);
			_notePage = new NotePage(_driver);
		}
		[Test, Order(1)]
		public void CreateNoteSuccessfully()
		{
			lastCreatedNoteTitle = NoteHelpers.GenerateRandomTitle();
			lastCreatedNoteContent = NoteHelpers.GenerateRandomContent();

			_mainPage.OpenNote();
			_notePage.CreateNote(lastCreatedNoteTitle, lastCreatedNoteContent);

			var notes = _mainPage.WaitForCreatedNote();

			Assert.Multiple(() =>
			{
				Assert.That(notes, Is.Not.Empty, "No notes found!");
				Assert.That(notes.Last().Text, Is.EqualTo(lastCreatedNoteTitle));
			});
		}

		[Test, Order(2)]
		public void EditNoteSuccessfully()
		{
			string editedTitle = "EDITED-" + lastCreatedNoteTitle;
			string editedContent = "EDITED-" + lastCreatedNoteContent;

			_mainPage.WaitForCreatedNote()
			   .Last()
			   .Click();

			_notePage.EditNote(editedTitle, editedContent);

			var editedNote = _mainPage.WaitForCreatedNote().Last();

			Assert.Multiple(() =>
			{
				Assert.That(editedNote.Text, Is.EqualTo(editedTitle));

				editedNote.Click();

				var noteContent = _notePage.ViewNote.Text;
				Assert.That(noteContent, Is.EqualTo(editedContent));
			});
		}

		[Test, Order(3)]
		public void DeleteNoteSuccessfully()
		{
			_notePage.DeleteNote();

			var notesAfterDeletion = _mainPage.Notes;

			Assert.That(notesAfterDeletion, Is.Empty);
		}
	}
}
