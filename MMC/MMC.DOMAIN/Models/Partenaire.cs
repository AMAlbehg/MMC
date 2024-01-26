using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class Partenaire
{
    public int PartenaireId { get; set; }

    public string? Nom { get; set; }

    public string? Logo { get; set; }

    public int? EvenementId { get; set; }

    public virtual Evenement? Evenement { get; set; }
}
