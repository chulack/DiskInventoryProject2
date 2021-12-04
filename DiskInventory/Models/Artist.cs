using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace DiskInventory.Models
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistIntersectionTables = new HashSet<ArtistIntersectionTable>();
        }

        public int ArtistId { get; set; }
        [Required]

        public string ArtistFname { get; set; }
        public string ArtistLname { get; set; }
        [Required]
        public int ArtistTypeId { get; set; }

        public virtual ArtistType ArtistType { get; set; }
        public virtual ICollection<ArtistIntersectionTable> ArtistIntersectionTables { get; set; }
    }
}
