namespace Web_Api.Services
{
	public class HelloWordService : IHelloWordService
	{
		public string GetHelloWord()
		{
			return "Hello word";
		}
	}

	public interface IHelloWordService
	{
		string GetHelloWord();
	}
}
