using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class ProjetoPortfolio
{
    public int IdProjetoPortfolio { get; set; }

    public int IdProgramador { get; set; }

    public string NomeProjeto { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string? Link { get; set; }

    public virtual Usuario IdProgramadorNavigation { get; set; } = null!;
}
