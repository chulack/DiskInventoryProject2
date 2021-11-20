using System;
using System.Collections.Generic;

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
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string BorrowerPhoneNum { get; set; }

        public virtual ICollection<MediaIntersectiontable> MediaIntersectiontables { get; set; }
    }
}
