using AutoMapper;
using NetApi.Api.Models;
using NetApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetApi.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Song
            //Entity to Model
            CreateMap<Song, SongModel>();

            //Model to Entity
            CreateMap<SongModel, Song>();
            CreateMap<SaveSongModel, Song>();
            
            //Artist
            CreateMap<ArtistModel, Artist>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<SaveArtistModel, Artist>();
        }
    }
}
