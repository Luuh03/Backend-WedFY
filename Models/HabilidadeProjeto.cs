using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class HabilidadeProjeto
{
    public int IdHabilidade { get; set; }

    public int IdProjeto { get; set; }

    public virtual Habilidade IdHabilidadeNavigation { get; set; } = null!;

    public virtual Projeto IdProjetoNavigation { get; set; } = null!;
}
