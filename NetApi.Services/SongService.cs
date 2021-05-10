using NetApi.Core.Entities;
using NetApi.Core.Interfaces;
using NetApi.Core.Interfaces.Services;
using NetApi.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApi.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Song> CreateSong(Song newSong)
        {
            SongValidator validator = new();
            var validationResult = await validator.ValidateAsync(newSong);
            if (validationResult.IsValid)
            {
                await _unitOfWork.SongsRepository.AddAsync(newSong);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }
            
            return newSong;
        }

        public async Task DeleteSong(int songId)
        {
            Song song = await _unitOfWork.SongsRepository.GetByIdAsync(songId);
            _unitOfWork.SongsRepository.Remove(song);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Song>> GetAllWithArtist()
        {
            return await _unitOfWork.SongsRepository.GetAllWithArtistAsync();
        }

        public async Task<IEnumerable<Song>> GetSongByArtistId(int artistId)
        {
            return await _unitOfWork.SongsRepository.GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task<Song> GetSongById(int id)
        {
            return await _unitOfWork.SongsRepository.GetWithArtistByIdAsync(id);
        }

        public async Task<Song> GetSongsByIdWithArtist(int id)
        {
            //var songs = await _unitOfWork.SongsRepository.GetSongsByIdWithArtist(id);
            
            return new Song();
        }

        public async Task<Song> UpdateSong(int songToBeUpdatedId, Song songNewValues)
        {
            SongValidator songValidator = new();
            var validationResult = await songValidator.ValidateAsync(songNewValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            Song songToBeUpdated = await _unitOfWork.SongsRepository.GetByIdAsync(songToBeUpdatedId);

            if(songToBeUpdated == null)
                throw new ArgumentException("Invalid song ID while updating");

            songToBeUpdated.Name = songNewValues.Name;
            songToBeUpdated.ArtistId = songNewValues.ArtistId;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.SongsRepository.GetByIdAsync(songToBeUpdatedId);
        }
    }
}
