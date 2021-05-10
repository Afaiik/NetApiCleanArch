using NetApi.Core.Entities;
using NetApi.Core.Interfaces.Repositories;
using NetApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Infrastructure.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context)
        { }
        public Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return GetAsync(includeProperties: "Songs");
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
