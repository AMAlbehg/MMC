﻿using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public string? TitreSession { get; set; }

    public int? SpeakerId { get; set; }

    public string? Description { get; set; }

    public string? Ville { get; set; }

    public string? Adresse { get; set; }

    public int? EvenementId { get; set; }

    public int? UtilisateurId { get; set; }

    public string? TypeSession { get; set; }

    public virtual Evenement? Evenement { get; set; }

    public virtual Speaker? Speaker { get; set; }

    public virtual ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();

    public virtual Utilisateur? Utilisateur { get; set; }
}
