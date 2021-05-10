using NetApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Core.Interfaces.Services
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetAllWithArtist();
        Task<Song> GetSongById(int id);
        Task<IEnumerable<Song>> GetSongByArtistId(int artistId);
        Task<Song> CreateSong(Song newSong);
        Task<Song> UpdateSong(int songToBeUpdatedId, Song songNewValues);
        Task DeleteSong(int songId);
        Task<Song> GetSongsByIdWithArtist(int id);
    }
}
