using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class Sponsor
{
    public int SponsorId { get; set; }

    public string? Nom { get; set; }

    public string? Logo { get; set; }

    public int? SessionId { get; set; }

    public virtual Session? Session { get; set; }
}
