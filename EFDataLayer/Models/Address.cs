using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDataAccessLib.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string StreetAddress { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string ZipCode { get; set; }

    }
}
