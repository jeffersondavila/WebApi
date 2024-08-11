using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Tareas = new HashSet<Tarea>();
        }

        public Guid CodigoCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Peso { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
