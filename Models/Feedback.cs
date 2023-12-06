using System;
using System.Collections.Generic;

namespace APIWedfy.Models;

public partial class Feedback
{
    public int IdProjeto { get; set; }

    public int IdRemetente { get; set; }

    public int IdDestinatario { get; set; }

    public int Nota { get; set; }

    public string Texto { get; set; } = null!;

    public DateTime DataPublicacao { get; set; }

    public virtual Usuario IdDestinatarioNavigation { get; set; } = null!;

    public virtual Projeto IdProjetoNavigation { get; set; } = null!;

    public virtual Usuario IdRemetenteNavigation { get; set; } = null!;
}
