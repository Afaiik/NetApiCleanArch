using NetApi.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository SongsRepository { get; }

        IArtistRepository ArtistRepository { get; }

        Task<int> CommitAsync();
    }
}
