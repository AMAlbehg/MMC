using AutoMapper;
using MMC.Application.Modules.Speakers.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMC.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateSpeakerCommand, DOMAIN.Models.Speaker>().ReverseMap();
        }
    }
}
