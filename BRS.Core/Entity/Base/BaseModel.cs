using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRS.Core.Entity.Base
{
    public class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public Guid Id { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdateDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
