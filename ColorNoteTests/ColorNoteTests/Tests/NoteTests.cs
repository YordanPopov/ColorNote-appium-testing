using ColorNoteTests.Helpers;
using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium;

namespace ColorNoteTests.Tests
{
	public class NoteTests : BaseTest
	{
		private MainPage _mainPage;
		private NotePage _notePage;

		[OneTimeSetUp]
		public void PageInitialization()
		{
			_mainPage = new MainPage(_driver);
			_notePage = new NotePage(_driver);
		}
		[Test, Order(1)]
		public void CreateNoteSuccessfully()
		{
			string noteTitle = NoteHelpers.GenerateRandomTitle();
			string noteContent = NoteHelpers.GenerateRandomContent();

			_mainPage.OpenNote();
			_notePage.CreateNote(noteTitle, noteContent);

			var notes = _notePage.WaitForLastCreatedNote();

			Assert.Multiple(() =>
			{
				Assert.That(notes, Is.Not.Empty, "No notes found!");
				Assert.That(notes.Last().Text, Is.EqualTo(noteTitle));
			});
		}

		[Test, Order(2)]
		public void EditNoteSuccessfully()
		{
			string editedTitle = "EDITED-" + NoteHelpers.GenerateRandomTitle();
			string editedContent = "EDITED CONTENT";

			_notePage.WaitForLastCreatedNote()
			   .Last()
			   .Click();

			_notePage.EditNote(editedTitle, editedContent);

			var editedNote = _notePage.WaitForLastCreatedNote().Last();

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

			var notesAfterDeletion = _notePage.Notes;

			Assert.That(notesAfterDeletion, Is.Empty);
		}
	}
}
