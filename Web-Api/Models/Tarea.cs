using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Tarea
    {
        public Guid CodigoTarea { get; set; }
        public Guid CodigoCategoria { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int PrioridadTarea { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Categorium CodigoCategoriaNavigation { get; set; } = null!;
    }
}
