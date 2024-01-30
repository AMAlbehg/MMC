using AutoMapper;
using MediatR;
using MMC.Application.Interface;
using MMC.Application.Modules.Speakers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Modules.Speakers.Query
{
    public class GetAllSpeakerQueryHandler : IRequestHandler<GetAllSpeaker, List<SpeakerViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ISpeakersRepo _speakersRepo;

        public GetAllSpeakerQueryHandler(ISpeakersRepo speakersRepo , IMapper mapper)
        {
            _mapper = mapper;
            _speakersRepo = speakersRepo;
        }

        public async Task<List<SpeakerViewModel>> Handle(GetAllSpeaker request, CancellationToken cancellationToken)
        {
           var speak = await _speakersRepo.GetAll();
            return _mapper.Map<List<SpeakerViewModel>>(speak);
        }
    }
}
