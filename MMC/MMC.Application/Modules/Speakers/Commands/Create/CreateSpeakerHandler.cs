using AutoMapper;
using MediatR;
using MMC.Application.Interface;
using MMC.Application.Modules.Speakers.ViewModel;
using MMC.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Modules.Speakers.Commands.Create
{
    public class CreateSpeakerHandler : IRequestHandler<CreateSpeakerCommand, SpeakerViewModel >
    {
        private readonly IMapper _mapper;
        private readonly ISpeakersRepo _speakersRepo;
        private readonly CreateSpeakerValidator _validationRules; 

        public CreateSpeakerHandler(ISpeakersRepo speakersRepo, IMapper mapper )
        {
            _mapper = mapper;
            _speakersRepo = speakersRepo;
            //_validationRules = validations;
        }
        public async Task<SpeakerViewModel> Handle(CreateSpeakerCommand raquest, CancellationToken cancellationToken)
        {

            var speak = _mapper.Map<Speaker>(raquest);

            var createSpeak = await _speakersRepo.Add(speak);
            return _mapper.Map<SpeakerViewModel>(createSpeak);
        }

    }
}