using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class Participant
{
    public int ParticipantId { get; set; }

    public string? AdresseMail { get; set; }

    public string? MotDePasse { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Sexe { get; set; }

    public string? Societe { get; set; }

    public string? Gsm { get; set; }

    public string? Ville { get; set; }

    public int? UtilisateurId { get; set; }

    public virtual Utilisateur? Utilisateur { get; set; }
}
