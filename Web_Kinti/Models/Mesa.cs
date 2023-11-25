using System;
using System.Collections.Generic;

namespace Web_Kinti.Models;

public partial class Mesa
{
    public int IdMesa { get; set; }

    public int? IdReservacion { get; set; }

    public virtual Reservacion? IdReservacionNavigation { get; set; }
}
