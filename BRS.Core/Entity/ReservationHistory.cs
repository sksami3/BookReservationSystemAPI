using BRS.Core.Entity.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace BRS.Core.Entity
{
    public class ReservationHistory : BaseModel
    {
        [Required]
        public Guid BookId { get; set; } // reference
        [JsonIgnore]
        public virtual Book? Book { get; set; }
        public int? Status { get; set; } 
        public string? Comment { get; set; }
    }
}
