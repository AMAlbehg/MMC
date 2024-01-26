using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class Theme
{
    public int ThemeId { get; set; }

    public string? NomTheme { get; set; }

    public int? EvenementId { get; set; }

    public virtual Evenement? Evenement { get; set; }
}
