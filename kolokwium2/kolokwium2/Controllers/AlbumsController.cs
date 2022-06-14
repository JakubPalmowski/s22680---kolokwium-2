using kolokwium2.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IMusicService _service;

        public AlbumsController(IMusicService service)
        {
            _service = service;
        }

        [HttpGet("{IdAlbum}")]
        public async Task<IActionResult> GetAlbum(int IdAlbum)
        {
            var exist = await _service.GetAlbumById(IdAlbum).FirstOrDefaultAsync();

            if (exist == null) return NotFound("Nie znaleziono albumu");


            return Ok(await _service.GetAlbum(IdAlbum)
                .Select(e =>
                new AlbumGet
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    Tracks = e.Track.Select(e => new Track
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration



                    }).OrderBy(e=>e.Duration).ToList()
                }).ToListAsync()
                );


        }

       


    }
}
