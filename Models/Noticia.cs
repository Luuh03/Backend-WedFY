using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class Noticia
{
    public int IdNoticia { get; set; }

    public int IdAdministrador { get; set; }

    public string Texto { get; set; } = null!;

    public string LinkNoticia { get; set; } = null!;

    public DateTime DataPublicacao { get; set; }

    public int? Acessos { get; set; }

    public virtual Usuario IdAdministradorNavigation { get; set; } = null!;
}
