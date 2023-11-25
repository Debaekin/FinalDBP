using System;
using System.Collections.Generic;

namespace Web_Kinti.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Comidum> Comida { get; set; } = new List<Comidum>();
}
