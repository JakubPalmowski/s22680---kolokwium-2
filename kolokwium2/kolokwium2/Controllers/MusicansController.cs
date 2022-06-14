using kolokwium2.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicansController : ControllerBase
    {

        private readonly IMusicService _service;

        public MusicansController(IMusicService service)
        {
            _service = service;
        }

        [HttpDelete("{IdMusican}")]
        public async Task<IActionResult> DeleteMusican(int IdMusican)
        {
            var exist = await _service.GetMusicanById(IdMusican).FirstOrDefaultAsync();

            if (exist == null) return NotFound("nie znaleziono takiego muzyka");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                try
                {

              var musicanForDelete = await _service.GetMusican(IdMusican).Select(e =>
              new MusicanDelete
              {
                  FirstName = e.FirstName,
                  LastName = e.LastName,
                  Nickname = e.Nickname,
                  Tracks = e.MusicanTrack.Select(e => new MusicanTrack
                  {
                      IdTrack = e.IdTrack,
                      TrackName = e.Track.TrackName,
                      Duration = e.Track.Duration,
                      IdMusicAlbum = e.Track.IdMusicAlbum

                  }).ToList()

              }).ToListAsync();

                    var tracks = musicanForDelete[0];

                    foreach (MusicanTrack track in tracks.Tracks)
                    {
                        if (track.IdMusicAlbum != null) return Conflict("ten muzyk posiada piosenke w albumie");
                        await _service.DeleteTrack(track.IdTrack);
                    }


                    await _service.DeleteMusican(IdMusican);


                    scope.Complete();
                }
                catch (Exception)
                {
                    return Problem("Nieoczekiwany błąd serwera");
                }
            }
            

            return NoContent();
        }
    }
}
