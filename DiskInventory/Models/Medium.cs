using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Medium
    {
        public Medium()
        {
            ArtistIntersectionTables = new HashSet<ArtistIntersectionTable>();
            MediaIntersectiontables = new HashSet<MediaIntersectiontable>();
        }

        public int MediaId { get; set; }
        public string MediaName { get; set; }
        public DateTime ReleseDate { get; set; }
        public int GenreId { get; set; }
        public int StatusId { get; set; }
        public int MediaTypeId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ArtistIntersectionTable> ArtistIntersectionTables { get; set; }
        public virtual ICollection<MediaIntersectiontable> MediaIntersectiontables { get; set; }
    }
}
