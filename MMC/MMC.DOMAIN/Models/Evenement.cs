using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class Evenement
{
    public int EvenementId { get; set; }

    public string? Nom { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public DateTime? DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public string? TypeEvenement { get; set; }

    public string? Ville { get; set; }

    public string? Adresse { get; set; }

    public string? Categorie { get; set; }

    public int? NbrPlaces { get; set; }

    public string? FacebookLink { get; set; }

    public string? InstagramLink { get; set; }

    public virtual ICollection<Partenaire> Partenaires { get; set; } = new List<Partenaire>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Theme> Themes { get; set; } = new List<Theme>();
}
