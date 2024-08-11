﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Api.Models
{
	public class Tarea
	{
		public Guid CodigoTarea { get; set; }
		// [ForeignKey("CodigoCategoria")]
		public Guid CodigoCategoria { get; set; }
		// [Required]
		// [MaxLength(200)]
		public string Titulo { get; set; } = string.Empty;
		public string Descripcion { get; set; } = string.Empty;
		public Prioridad PrioridadTarea { get; set; }
		public DateTime FechaCreacion { get; set; }
		public virtual Categoria Categorias { get; set; }
		[NotMapped]
		public string Resumen { get; set; } = string.Empty;
	}
	public enum Prioridad
	{
		Baja,
		Media,
		Alta
	}
}
