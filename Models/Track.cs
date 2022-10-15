using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Track
    {
        public Track()
        {
            Invoicelines = new HashSet<Invoiceline>();
            Playlists = new HashSet<Playlist>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; } = null!;
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string? Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Album? Album { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Mediatype MediaType { get; set; } = null!;
        public virtual ICollection<Invoiceline> Invoicelines { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
