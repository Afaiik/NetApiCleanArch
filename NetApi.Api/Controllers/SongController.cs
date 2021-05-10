using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetApi.Api.Models;
using NetApi.Core.Entities;
using NetApi.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongController(ISongService songService, IMapper mapper)
        {
            this._songService = songService;
            this._mapper = mapper;
        }

        // GET: api/<SongController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongModel>>> Get()
        {
            var songs = await _songService.GetAllWithArtist();

            return Ok(_mapper.Map<IEnumerable<Song>, IEnumerable<SongModel>>(songs));
        }

        [HttpGet]
        public async Task<ActionResult<SongModel>> GetSongsByIdWithArtist(int id)
        {
            var song = await _songService.GetSongsByIdWithArtist(id);

            return Ok(song);
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongModel>> Get(int id)
        {
            var song = await _songService.GetSongById(id);

            return Ok(_mapper.Map<Song, SongModel>(song));
        }

        // POST api/<SongController>
        [HttpPost]
        public async Task<ActionResult<SongModel>> Create([FromBody] SaveSongModel song)
        {
            try
            {
                var createdSong = await _songService.CreateSong(_mapper.Map<SaveSongModel, Song>(song));

                return Ok(_mapper.Map<Song, SongModel>(createdSong));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SongModel>> Update(int id, [FromBody] SaveSongModel song)
        {
            try
            {
                var updatedSong = await _songService.UpdateSong(id, _mapper.Map<SaveSongModel, Song>(song));

                return Ok(_mapper.Map<Song, SongModel>(updatedSong));

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _songService.DeleteSong(id);

            return NoContent();
        }
    }
}
