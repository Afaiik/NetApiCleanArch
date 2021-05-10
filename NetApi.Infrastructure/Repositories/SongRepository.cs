using Microsoft.EntityFrameworkCore;
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
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Song>> GetAllWithArtistAsync()
        {
            return await Context.Songs.Include(x => x.Artist).ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await Context.Songs.Include(x => x.Artist).Where(x => x.ArtistId == artistId).ToListAsync();
        }

        public async Task<Song> GetWithArtistByIdAsync(int id)
        {
            return await Context.Songs.Include(x => x.Artist).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
