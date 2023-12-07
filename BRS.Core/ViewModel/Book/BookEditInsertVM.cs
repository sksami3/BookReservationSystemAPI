using BRS.Core.Entity;
using BRS.Core.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BRS.Core.ViewModel.Book
{
    public class BookEditInsertVM
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
