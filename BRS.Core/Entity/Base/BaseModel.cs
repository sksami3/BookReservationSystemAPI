using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace BRS.Core.Entity.Base
{
    public class BaseModel
    {
        [Key]
        [Required]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        [Column(TypeName = "datetime2")]
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime2")]
        [SwaggerSchema(ReadOnly = true), AllowNull]
        public DateTime? UpdateDate { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        [Newtonsoft.Json.JsonIgnore]
        public bool IsDelete { get; set; }
    }
}
