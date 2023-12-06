using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class Solicitacao
{
    public int IdSolicitacao { get; set; }

    public int IdProgramador { get; set; }

    public int IdProjeto { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public virtual Usuario IdProgramadorNavigation { get; set; } = null!;

    public virtual Projeto IdProjetoNavigation { get; set; } = null!;
}
