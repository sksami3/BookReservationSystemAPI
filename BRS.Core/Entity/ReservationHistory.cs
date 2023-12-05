using BRS.Core.Entity.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace BRS.Core.Entity
{
    public class ReservationHistory : BaseModel
    {
        [Required]
        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        public int Status { get; set; } 
        public string? Comment { get; set; }
    }
}
