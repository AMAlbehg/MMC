using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Modules.Speakers.Commands.Delete
{
    internal class DeleteSpeakerCommand : IRequest<int>
    {
        public int Id { get; set; }

    }
}
