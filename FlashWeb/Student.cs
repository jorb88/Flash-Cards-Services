namespace FlashWeb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [StringLength(8)]
        public string Id { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        public bool Teacher { get; set; }

        public int Tries { get; set; }

        public int Correct { get; set; }
    }
}
