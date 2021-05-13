namespace Assets.Rudeco.CustomCommands
{
	using PoyLang;

	public class Test : CustomCommand
	{
		public Test()
			: base("TEST_CUSTOM_COMMAND", new string[] { "returns message if custom commands work" })
		{ }

		public override string Command(string[] parameters)
		{
			return "Custom command works";
		}
	}
}
