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
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        // GET: api/<ArtistController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> Get()
        {
            var artists = await _artistService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistModel>>(artists));
        }

        // GET api/<ArtistController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistModel>> Get(int id)
        {
            var artist = await _artistService.GetByIdAsync(id);

            return Ok(_mapper.Map<Artist, ArtistModel>(artist));
        }

        // POST api/<ArtistController>
        [HttpPost]
        public async Task<ActionResult<ArtistModel>> Post([FromBody] SaveArtistModel value)
        {
            ArtistModel model = new();
            //Hateoas, return a link to request the created resource
            
            await _artistService.AddAsync(_mapper.Map<SaveArtistModel, Artist>(value));

            return Ok(model);
        }

        // PUT api/<ArtistController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistModel>> Put(int id, [FromBody] SaveArtistModel value)
        {
            await _artistService.Update(id, _mapper.Map<SaveArtistModel, Artist>(value));
            return Ok();
        }

        // DELETE api/<ArtistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
