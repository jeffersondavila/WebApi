using Microsoft.AspNetCore.Mvc;
using Web_Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HelloWordController : ControllerBase
	{
		private readonly IHelloWordService _helloWordService;
		private readonly ILogger<HelloWordController> logger;

		public HelloWordController(IHelloWordService helloWordService, ILogger<HelloWordController> logger)
		{
			_helloWordService = helloWordService;
			this.logger = logger;
		}

		// GET: api/<HelloWordController>
		[HttpGet]
		public IActionResult Get()
		{
			var message = _helloWordService.GetHelloWord();
			logger.LogInformation($"Logger: {message}");
			return Ok(message);
		}

		// GET api/<HelloWordController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<HelloWordController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<HelloWordController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<HelloWordController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
