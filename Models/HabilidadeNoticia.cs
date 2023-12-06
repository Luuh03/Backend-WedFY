using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class HabilidadeNoticia
{
    public int IdHabilidade { get; set; }

    public int IdNoticia { get; set; }

    public virtual Habilidade IdHabilidadeNavigation { get; set; } = null!;

    public virtual Noticia IdNoticiaNavigation { get; set; } = null!;
}
