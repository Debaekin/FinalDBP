using System;
using System.Collections.Generic;

namespace Web_Kinti.Models;

public partial class Reservacion
{
    public int IdReservacion { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();
}
