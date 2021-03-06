// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium2.DataAccess;

namespace kolokwium2.Entities.Migrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium2.Entities.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "jakiś niemiecki album",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 6, 14, 8, 55, 39, 78, DateTimeKind.Local).AddTicks(4355)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "jakiś inny album",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2022, 6, 14, 8, 55, 39, 79, DateTimeKind.Local).AddTicks(9465)
                        });
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "label1"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "label2"
                        });
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Musican", b =>
                {
                    b.Property<int>("IdMusican")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusican");

                    b.ToTable("Musican");

                    b.HasData(
                        new
                        {
                            IdMusican = 1,
                            FirstName = "Till",
                            LastName = "Linderman",
                            Nickname = "DR"
                        },
                        new
                        {
                            IdMusican = 2,
                            FirstName = "Musican2",
                            LastName = "Nazwisko musicana 2",
                            Nickname = "nick2"
                        },
                        new
                        {
                            IdMusican = 3,
                            FirstName = "test3",
                            LastName = "Nazwisko musicana 2",
                            Nickname = "nick2"
                        },
                        new
                        {
                            IdMusican = 4,
                            FirstName = "test4",
                            LastName = "Nazwisko musicana 2",
                            Nickname = "nick2"
                        },
                        new
                        {
                            IdMusican = 5,
                            FirstName = "test5",
                            LastName = "Nazwisko musicana 2",
                            Nickname = "nick2"
                        });
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.MusicanTrack", b =>
                {
                    b.Property<int>("IdMusican")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdMusican", "IdTrack");

                    b.HasIndex("IdTrack");

                    b.ToTable("Musican_Track");

                    b.HasData(
                        new
                        {
                            IdMusican = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusican = 1,
                            IdTrack = 2
                        },
                        new
                        {
                            IdMusican = 2,
                            IdTrack = 3
                        });
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 3f,
                            IdMusicAlbum = 1,
                            TrackName = "Du Hast"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 3f,
                            IdMusicAlbum = 1,
                            TrackName = "Ich Will"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 3f,
                            IdMusicAlbum = 2,
                            TrackName = "jakas piosenka"
                        });
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Album", b =>
                {
                    b.HasOne("kolokwium2.Entities.Models.MusicLabel", "MusicLabel")
                        .WithMany("Album")
                        .HasForeignKey("IdMusicLabel")
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.MusicanTrack", b =>
                {
                    b.HasOne("kolokwium2.Entities.Models.Musican", "Musican")
                        .WithMany("MusicanTrack")
                        .HasForeignKey("IdMusican")
                        .IsRequired();

                    b.HasOne("kolokwium2.Entities.Models.Track", "Track")
                        .WithMany("MusicanTrack")
                        .HasForeignKey("IdTrack")
                        .IsRequired();

                    b.Navigation("Musican");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Track", b =>
                {
                    b.HasOne("kolokwium2.Entities.Models.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Album", b =>
                {
                    b.Navigation("Track");
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.MusicLabel", b =>
                {
                    b.Navigation("Album");
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Musican", b =>
                {
                    b.Navigation("MusicanTrack");
                });

            modelBuilder.Entity("kolokwium2.Entities.Models.Track", b =>
                {
                    b.Navigation("MusicanTrack");
                });
#pragma warning restore 612, 618
        }
    }
}
