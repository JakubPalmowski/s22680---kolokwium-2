using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Entities.Models
{
    public class Musican
    {
        public int IdMusican { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<MusicanTrack> MusicanTrack { get; set; }

    }
}
