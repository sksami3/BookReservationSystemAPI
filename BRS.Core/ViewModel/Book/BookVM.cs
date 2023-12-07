using BRS.Core.Entity;
using BRS.Core.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BRS.Core.ViewModel.Book
{
    public class BookVM
    {
        [JsonIgnore, SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Comment { get; set; }
        [SwaggerSchema(ReadOnly = true), JsonIgnore]
        public Status Status { get; set; }
        [ForeignKey(nameof(Author)), AllowNull, JsonIgnore]
        public Guid AuthorId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore]
        public Author? Author { get; set; }
        [DisplayName("Author Id")]
        public string? AuthorSrtingId { get; set; }
    }
}
