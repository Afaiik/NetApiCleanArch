using NetApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Core.Interfaces.Repositories
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);

    }
}
