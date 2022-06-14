using kolokwium2.DataAccess;
using kolokwium2.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services
{
    public class MusicService:IMusicService
    {
        private readonly MusicContext _context;

        public MusicService(MusicContext context)
        {
            _context = context;
        }

        public IQueryable<Album> GetAlbum(int IdAlbum)
        {
            return _context.Album
                .Where(e => e.IdAlbum == IdAlbum)
                .Include(e => e.Track);
        }

        public IQueryable<Album> GetAlbumExist(int IdAlbum)
        {
            return _context.Album
                .Where(e => e.IdAlbum == IdAlbum);
        }
    }
}
