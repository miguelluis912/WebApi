using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Mediatype
    {
        public Mediatype()
        {
            Tracks = new HashSet<Track>();
        }

        public int MediaTypeId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
