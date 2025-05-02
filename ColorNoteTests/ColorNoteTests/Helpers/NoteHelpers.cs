using Bogus;

namespace ColorNoteTests.Helpers
{
	public static class NoteHelpers
	{
		private static readonly Random _random = new Random();
		private static readonly Faker _faker = new Faker();

		public static string GenerateRandomTitle()
		{
			return "TITLE-" + _random.Next(1000, 9999).ToString();
		}

		public static string GenerateRandomContent()
		{
			return _faker.Lorem.Sentences(2, " ");
		}
	}
}
