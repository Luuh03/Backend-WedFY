using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class HabilidadeProgramador
{
    public int IdHabilidade { get; set; }

    public int IdProgramador { get; set; }

    public virtual Habilidade IdHabilidadeNavigation { get; set; } = null!;

    public virtual Usuario IdProgramadorNavigation { get; set; } = null!;
}
