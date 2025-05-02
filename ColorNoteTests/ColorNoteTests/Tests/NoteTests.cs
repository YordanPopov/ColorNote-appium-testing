using ColorNoteTests.Helpers;
using ColorNoteTests.Pages;
using OpenQA.Selenium.Appium;

namespace ColorNoteTests.Tests
{
	public class NoteTests : BaseTest
	{
		private MainPage _mainPage;
		private NotePage _notePage;

		[SetUp]
		public void SetUp()
		{
			_mainPage = new MainPage(_driver);
			_notePage = new NotePage(_driver);
		}
		[Test]
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
	}
}
