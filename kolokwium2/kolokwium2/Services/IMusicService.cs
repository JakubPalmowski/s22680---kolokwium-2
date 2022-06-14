using kolokwium2.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services
{
   public interface IMusicService
    {
        IQueryable<Album> GetAlbum(int IdAlbum);
        IQueryable<Album> GetAlbumById(int IdAlbum);

        IQueryable<Musican> GetMusicanById(int IdMusican);

        IQueryable<Musican> GetMusican(int IdMusican);

        Task DeleteMusican(int IdMusican);

        Task DeleteMusicanTrack(int IdTrack,int IdMusican);

    }
}
