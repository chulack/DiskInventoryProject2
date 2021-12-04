using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string MediaName { get; set; }
        [Required]
        public DateTime ReleseDate { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int MediaTypeId { get; set; }
       
        public virtual Genre Genre { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ArtistIntersectionTable> ArtistIntersectionTables { get; set; }
        public virtual ICollection<MediaIntersectiontable> MediaIntersectiontables { get; set; }
    }
}
