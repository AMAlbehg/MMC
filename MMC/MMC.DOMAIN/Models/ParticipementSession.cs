using System;
using System.Collections.Generic;

namespace MMC.DOMAIN.Models;

public partial class ParticipementSession
{
    public int? ParticipantId { get; set; }

    public int? SessionId { get; set; }

    public DateTime? DateParticipation { get; set; }

    public virtual Participant? Participant { get; set; }

    public virtual Session? Session { get; set; }
}
