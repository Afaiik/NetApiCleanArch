using NetApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Core.Interfaces.Repositories
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        
        Task<IEnumerable<Song>> GetAllWithArtistAsync();
        Task<Song> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Song>> GetAllWithArtistByArtistIdAsync(int artistId);

    }
}
