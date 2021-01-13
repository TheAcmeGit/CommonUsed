using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEFDBContext.Models
{

    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public bool Isb { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
        public byte[] Rowversion { get; set; }
        public DateTime CreateTime { get; set; }

        public string FullName { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid InsertedGuid { get; set; }
    }
}
