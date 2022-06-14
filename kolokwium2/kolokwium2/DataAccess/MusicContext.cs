using kolokwium2.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DataAccess
{
    public class MusicContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Musican> Musican { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<MusicanTrack> MusicanTrack { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }




        public MusicContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musican>(e => {
                e.ToTable("Musican");
                e.HasKey(e => e.IdMusican);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20).IsRequired(false);

                e.HasData(
                    new Musican
                    {
                        IdMusican = 1,
                        FirstName = "Till",
                        LastName = "Linderman",
                        Nickname = "DR"

                    },
                    new Musican
                    {
                        IdMusican = 2,
                        FirstName = "Musican2",
                        LastName = "Nazwisko musicana 2",
                        Nickname = "nick2"

                    },
                     new Musican
                     {
                         IdMusican = 3,
                         FirstName = "test3",
                         LastName = "Nazwisko musicana 2",
                         Nickname = "nick2"

                     },
                      new Musican
                      {
                          IdMusican = 4,
                          FirstName = "test4",
                          LastName = "Nazwisko musicana 2",
                          Nickname = "nick2"

                      },
                       new Musican
                       {
                           IdMusican = 5,
                           FirstName = "test5",
                           LastName = "Nazwisko musicana 2",
                           Nickname = "nick2"

                       }


                    );

            });

            modelBuilder.Entity<MusicanTrack>(e =>
            {
                e.ToTable("Musican_Track");
                e.HasKey(e => new { e.IdMusican, e.IdTrack });

                e.HasOne(e => e.Musican).WithMany(e => e.MusicanTrack).HasForeignKey(e => e.IdMusican).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.Track).WithMany(e => e.MusicanTrack).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(

                    new MusicanTrack
                    {
                        IdTrack = 1,
                        IdMusican = 1
                    },
                    new MusicanTrack
                    {
                        IdTrack = 2,
                        IdMusican = 1
                    },
                    new MusicanTrack
                    {
                        IdTrack = 3,
                        IdMusican = 2
                    }

               );

                modelBuilder.Entity<Track>(e => {
                    e.ToTable("Track");
                    e.HasKey(e => e.IdTrack);
                    e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                    e.Property(e => e.Duration).IsRequired();

                    e.HasOne(e => e.Album).WithMany(e => e.Track).HasForeignKey(e => e.IdMusicAlbum).OnDelete(DeleteBehavior.ClientSetNull).IsRequired(false);


                    e.HasData(
                        new Track
                        {
                            IdTrack = 1,
                            TrackName = "Du Hast",
                            Duration = 3,
                            IdMusicAlbum = 1
                        },

                        new Track
                        {
                            IdTrack = 2,
                            TrackName = "Ich Will",
                            Duration = 3,
                            IdMusicAlbum = 1
                        },

                        new Track
                        {
                            IdTrack = 3,
                            TrackName = "jakas piosenka",
                            Duration = 3,
                            IdMusicAlbum = 2
                        }

                        );

                });

                modelBuilder.Entity<Album>(e => {
                    e.ToTable("Album");
                    e.HasKey(e => e.IdAlbum);
                    e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                    e.Property(e => e.PublishDate).IsRequired();

                    e.HasOne(e => e.MusicLabel).WithMany(e => e.Album).HasForeignKey(e => e.IdMusicLabel).OnDelete(DeleteBehavior.ClientSetNull).IsRequired();

                    e.HasData(
                        new Album
                        {
                            IdAlbum = 1,
                            AlbumName = "jakiś niemiecki album",
                            PublishDate = DateTime.Now,
                            IdMusicLabel = 1,

                        },

                        new Album
                        {
                            IdAlbum = 2,
                            AlbumName = "jakiś inny album",
                            PublishDate = DateTime.Now,
                            IdMusicLabel = 2,

                        }

                        );

                    modelBuilder.Entity<MusicLabel>(e => {
                        e.ToTable("MusicLabel");
                        e.HasKey(e => e.IdMusicLabel);
                        e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                        e.HasData(
                            new MusicLabel
                            {
                                IdMusicLabel = 1,
                                Name = "label1"
                            },
                            new MusicLabel
                            {
                                IdMusicLabel = 2,
                                Name = "label2"
                            }

                            );

                    });


                });


            });


        }
    }
}
