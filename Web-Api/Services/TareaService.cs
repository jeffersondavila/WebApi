using Web_Api.Models;

namespace Web_Api.Services
{
	public class TareaService : ITareaService
	{
		TareasDbContext context;

		public TareaService(TareasDbContext db)
		{
			context = db;
		}

		public IEnumerable<Tarea> GetTarea()
		{
			return context.Tareas;
		}

		public Tarea GetTarea(Guid id)
		{
			return context.Tareas.Find(id) ?? new Tarea();
		}

		public async Task SaveTarea(Tarea tarea)
		{
			context.Tareas.Add(tarea);
			await context.SaveChangesAsync();
		}

		public async Task UpdateTarea(Tarea tarea, Guid id)
		{
			var tareaActual = context.Tareas.Find(id);

			if (tareaActual != null)
			{
				tareaActual.CodigoCategoria = tarea.CodigoCategoria;
				tareaActual.Titulo = tarea.Titulo;
				tareaActual.Descripcion = tarea.Descripcion;
				tareaActual.PrioridadTarea = tarea.PrioridadTarea;

				await context.SaveChangesAsync();
			}
		}

		public async Task DeleteTarea(Guid id)
		{
			var tareaActual = context.Tareas.Find(id);

			if (tareaActual != null)
			{
				context.Remove(tareaActual);
				await context.SaveChangesAsync();
			}
		}
	}

	public interface ITareaService
	{
		IEnumerable<Tarea> GetTarea();
		Tarea GetTarea(Guid id);
		Task SaveTarea(Tarea tarea);
		Task UpdateTarea(Tarea tarea, Guid id);
		Task DeleteTarea(Guid id);
	}
}
