using System;
using System.Collections.Generic;

namespace Web_Kinti.Models;

public partial class Comidum
{
    public int IdComida { get; set; }

    public string? CodigoBarra { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public string? UrlFoto { get; set; }

    public decimal? Precio { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }
}
