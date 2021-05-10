using NetApi.Core.Entities;
using NetApi.Core.Interfaces;
using NetApi.Core.Interfaces.Repositories;
using NetApi.Core.Interfaces.Services;
using NetApi.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Services
{
    public class ArtistService : BaseService<Artist/*, ArtistValidator*/>, IArtistService
    {
        public ArtistService(IBaseRepository<Artist> _tRepository) : base(_tRepository)
        {

        }
    }
}
