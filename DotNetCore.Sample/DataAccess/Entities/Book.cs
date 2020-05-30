using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore.Sample.DataAccess.Entities
{
    public class Book
    {
        [Key]
        [Column("Pk_Id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public bool IsShelf { get; set; }

        public Guid? ModifyBy { get; set; }
    }
}
