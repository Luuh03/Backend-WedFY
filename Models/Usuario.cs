using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Celular { get; set; }

    public virtual ICollection<Noticia> Noticia { get; set; } = new List<Noticia>();

    public virtual ICollection<Projeto> ProjetoIdClienteNavigations { get; set; } = new List<Projeto>();

    public virtual ICollection<Projeto> ProjetoIdProgramadorNavigations { get; set; } = new List<Projeto>();

    public virtual ICollection<ProjetoPortfolio> ProjetoPortfolios { get; set; } = new List<ProjetoPortfolio>();

    public virtual ICollection<Solicitacao> Solicitacoes { get; set; } = new List<Solicitacao>();
}
