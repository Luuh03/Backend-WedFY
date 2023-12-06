using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class Projeto
{
    public int IdProjeto { get; set; }

    public int IdCliente { get; set; }

    public int? IdProgramador { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime DataPublicacao { get; set; }

    public DateTime? DataFinalizacao { get; set; }

    public virtual Usuario IdClienteNavigation { get; set; } = null!;

    public virtual Usuario? IdProgramadorNavigation { get; set; }

    public virtual ICollection<Solicitacao> Solicitacaos { get; set; } = new List<Solicitacao>();
}
