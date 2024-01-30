using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MMC.Application.Mapping;
using MMC.Application.Modules.Speakers.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDependecyInjectionApplication(this IServiceCollection services)
        {
            //mediatR   
            services.AddMediatR(typeof(GetAllSpeaker));

            

            return services;
        }
    }
}
