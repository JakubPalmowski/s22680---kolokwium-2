using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DTOs
{
    public class MusicanDelete
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public List<MusicanTrack> Tracks { get; set; }
    }

    public class MusicanTrack
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }

    }
}
