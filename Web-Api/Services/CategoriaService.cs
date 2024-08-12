using System.Collections;
using Web_Api.Models;

namespace Web_Api.Services
{
	public class CategoriaService : ICategoriaService
	{
		TareasDbContext context;

		public CategoriaService(TareasDbContext db)
		{
			context = db;
		}

		public IEnumerable<Categorium> GetCategoria()
		{
			return context.Categoria;
		}

		public async Task SaveCategoria(Categorium categoria)
		{
			context.Add(categoria);
			await context.SaveChangesAsync();
		}

		public async Task UpdateCategoria(Categorium categoria, Guid id)
		{
			var categoriaActual = context.Categoria.Find(id);

			if (categoriaActual != null)
			{
				categoriaActual.Nombre = categoria.Nombre;
				categoriaActual.Descripcion = categoria.Descripcion;
				categoriaActual.Peso = categoria.Peso;

				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteCategoria(Guid id)
		{
			var categoriaActual = context.Categoria.Find(id);

			if (categoriaActual != null)
			{
				context.Remove(categoriaActual);
				await context.SaveChangesAsync();
			}
		}
	}

	public interface ICategoriaService
	{
		IEnumerable<Categorium> GetCategoria();
		Task SaveCategoria(Categorium categoria);
		Task UpdateCategoria(Categorium categoria, Guid id);
		Task DeleteCategoria(Guid id);

	}
}
