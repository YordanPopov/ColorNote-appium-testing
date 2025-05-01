using Newtonsoft.Json;

namespace ColorNoteTests.Config
{
	public class ConfigReader
	{
		public static dynamic GetConfig()
		{
			string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\.."));
			string configPath = Path.Combine(projectRoot, "config", "appsettings.json");

			if (!File.Exists(configPath))
			{
				throw new FileNotFoundException($"Config file not found at: {configPath}");
			}

			var json = File.ReadAllText(configPath);
			return JsonConvert.DeserializeObject<dynamic>(json);
		}
	}
}
