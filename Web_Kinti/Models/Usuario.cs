using System;
using System.Collections.Generic;

namespace Web_Kinti.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? UrlFoto { get; set; }

    public string? Clave { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
