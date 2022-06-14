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
        IQueryable<Album> GetAlbumExist(int IdAlbum);



    }
}
