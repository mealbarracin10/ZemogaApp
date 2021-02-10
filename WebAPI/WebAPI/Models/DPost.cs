using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DPost
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string fullName { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }


        [Column(TypeName = "text")]
        public string post { get; set; }
    }
}
