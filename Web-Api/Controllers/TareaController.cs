using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TareaController : ControllerBase
	{
		ITareaService tareaService;

		public TareaController(ITareaService service)
		{
			tareaService = service;
		}

		// GET: api/<TaareaController>
		[HttpGet]
		public IActionResult Get()
		{
			tareaService.GetTarea();
			return Ok();
		}

		// GET api/<TaareaController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok();
		}

		// POST api/<TaareaController>
		[HttpPost]
		public IActionResult Post([FromBody] Tarea tarea)
		{
			tareaService.SaveTarea(tarea);
			return Ok();
		}

		// PUT api/<TaareaController>/5
		[HttpPut("{id}")]
		public IActionResult Put(Guid id, [FromBody] Tarea tarea)
		{
			tareaService.UpdateTarea(tarea, id);
			return Ok();
		}

		// DELETE api/<TaareaController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			tareaService.DeleteTarea(id);
			return Ok();
		}
	}
}
