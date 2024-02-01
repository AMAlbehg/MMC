using AutoMapper;
using MediatR;
using MMC.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Modules.Speakers.Commands.Delete
{
    public class DeleteSpeakerHandler : IRequestHandler<DeleteSpeakerCommand , int>
    {
        private readonly ISpeakersRepo _speakersRepo;
        public DeleteSpeakerHandler(ISpeakersRepo speakersRepo, IMapper mapper)
        {
            _speakersRepo = speakersRepo;

        }
        public async Task<int> Handle(DeleteSpeakerCommand request , CancellationToken cancellationToken)
        {
            var deleteSpeaker = await _speakersRepo.GetById(request.Id);
            if (deleteSpeaker == null)
            {
                return -1;
            }
            await _speakersRepo.DeleteById(deleteSpeaker.Id);
            return deleteSpeaker.SpeakerId;
        }

    }


}
