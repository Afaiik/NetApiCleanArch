using NetApi.Core.Interfaces;
using NetApi.Core.Interfaces.Repositories;
using NetApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private SongRepository _songRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public ISongRepository SongsRepository => _songRepository = _songRepository ?? new SongRepository(_context);

        public IArtistRepository ArtistRepository => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
