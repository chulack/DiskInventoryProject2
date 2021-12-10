using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            MediaIntersectiontables = new HashSet<MediaIntersectiontable>();
        }

        public int BorrowerId { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string BorrowerPhoneNum { get; set; }

        public virtual ICollection<MediaIntersectiontable> MediaIntersectiontables { get; set; }
    }
}
