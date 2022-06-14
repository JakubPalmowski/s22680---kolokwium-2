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

        public IQueryable<Album> GetAlbumById(int IdAlbum)
        {
            return _context.Album
                .Where(e => e.IdAlbum == IdAlbum);
        }

        public IQueryable<Musican> GetMusicanById(int IdMusican)
        {
            return _context.Musican
                .Where(e => e.IdMusican == IdMusican);
        }

        public IQueryable<Musican> GetMusican(int IdMusican)
        {
            return _context.Musican
                .Where(e => e.IdMusican == IdMusican)
                .Include(e => e.MusicanTrack)
                .ThenInclude(e => e.Track);
        }

        public async Task DeleteMusican(int IdMusican)
        {
            var MusicanDelete = new Musican
            {
                IdMusican = IdMusican,
            };

            var entry = _context.Entry(MusicanDelete);
            entry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMusicanTrack(int IdTrack,int IdMusican)
        {
            var TrackDelete = new MusicanTrack
            {
                IdTrack = IdTrack,
                IdMusican = IdMusican
            };

            var entry = _context.Entry(TrackDelete);
            entry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
