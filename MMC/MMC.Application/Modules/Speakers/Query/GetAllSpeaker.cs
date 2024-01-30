using MediatR;
using MMC.Application.Modules.Speakers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Modules.Speakers.Query
{
    public class GetAllSpeaker :IRequest<List<SpeakerViewModel>>
    {
    }
}
