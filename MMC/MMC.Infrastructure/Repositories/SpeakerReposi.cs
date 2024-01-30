using MMC.Application.Interface;
using MMC.DOMAIN.Models;
using MMC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Infrastructure.Repositories
{
    public class SpeakerReposi : GenericRepository<Speaker>, ISpeakersRepo 
    {
        public SpeakerReposi(AppDbContext appDbContext) :base(appDbContext) { }

            
        
    }
}
