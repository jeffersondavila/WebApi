using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		ICategoriaService categoriaService;

		public CategoriaController(ICategoriaService service)
		{
			categoriaService = service;
		}

		// GET: api/<CategoriaController>
		[HttpGet]
		public IActionResult Get()
		{
			var categoria = categoriaService.GetCategoria();
			return Ok(categoria);
		}

		// GET api/<CategoriaController>/5
		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			var categoria = categoriaService.GetCategoria(id);
			return Ok(categoria);
		}

		// POST api/<CategoriaController>
		[HttpPost]
		public IActionResult Post([FromBody] Categorium categoria)
		{
			categoriaService.SaveCategoria(categoria);
			return Ok();
		}

		// PUT api/<CategoriaController>/5
		[HttpPut("{id}")]
		public IActionResult Put(Guid id, [FromBody] Categorium categoria)
		{
			categoriaService.UpdateCategoria(categoria, id);
			return Ok();
		}

		// DELETE api/<CategoriaController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			categoriaService.DeleteCategoria(id);
			return Ok();
		}
	}
}
